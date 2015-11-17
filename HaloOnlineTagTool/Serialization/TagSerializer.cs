using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Serializes classes into tag data by using reflection.
	/// </summary>
	public class TagSerializer
	{
		private const int DefaultBlockAlign = 4;

		private readonly EngineVersion _version;

		/// <summary>
		/// Constructs a tag serializer for a specific engine version.
		/// </summary>
		/// <param name="version">The engine version to target.</param>
		public TagSerializer(EngineVersion version)
		{
			_version = version;
		}

		/// <summary>
		/// Serializes a tag structure into a context.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStructure">The tag structure.</param>
		public void Serialize(ISerializationContext context, object tagStructure)
		{
			// Serialize the structure to a data block
			var info = new TagStructureInfo(tagStructure.GetType(), _version);
			context.BeginSerialize(info);
			var tagStream = new MemoryStream();
			var structBlock = context.CreateBlock();
			SerializeStruct(context, tagStream, structBlock, info, tagStructure);

			// Finalize the block and write all of the tag data out
			var mainStructOffset = structBlock.Finalize(tagStream);
			var data = tagStream.ToArray();
			context.EndSerialize(info, data, mainStructOffset);
		}

		/// <summary>
		/// Serializes a structure into a temporary memory block.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="info">Information about the tag structure type.</param>
		/// <param name="structure">The structure to serialize.</param>
		/// <exception cref="System.InvalidOperationException">Structure type must have TagStructureAttribute</exception>
		private void SerializeStruct(ISerializationContext context, MemoryStream tagStream, IDataBlock block, TagStructureInfo info, object structure)
		{
			var baseOffset = block.Stream.Position;
			var enumerator = new TagFieldEnumerator(info);
			while (enumerator.Next())
				SerializeProperty(context, tagStream, block, structure, enumerator, baseOffset);

			// Honor the struct size if it's defined
			if (enumerator.Info.TotalSize > 0)
			{
				block.Stream.Position = baseOffset + enumerator.Info.TotalSize;
				if (block.Stream.Position > block.Stream.Length)
					block.Stream.SetLength(block.Stream.Position);
			}
		}

		/// <summary>
		/// Serializes a property.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="instance">The object that the property belongs to.</param>
		/// <param name="structInfo">The structure information.</param>
		/// <param name="property">The property.</param>
		/// <param name="baseOffset">The base offset of the structure from the start of its block.</param>
		/// <exception cref="System.InvalidOperationException">Offset for property \ + property.Name + \ is outside of its structure</exception>
		private void SerializeProperty(ISerializationContext context, MemoryStream tagStream, IDataBlock block, object instance, TagFieldEnumerator enumerator, long baseOffset)
		{
			// Seek to the value if it has an offset specified and write it
			var valueInfo = enumerator.Attribute;
			if (enumerator.Attribute.Offset >= 0)
				block.Stream.Position = baseOffset + valueInfo.Offset;
			var startOffset = block.Stream.Position;
			var val = enumerator.Field.GetValue(instance);
			SerializeValue(context, tagStream, block, val, valueInfo, enumerator.Field.FieldType);
			if (valueInfo.Size > 0)
				block.Stream.Position = startOffset + valueInfo.Size;
		}

		/// <summary>
		/// Serializes a value.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="val">The value.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		/// <param name="valueType">Type of the value.</param>
		private void SerializeValue(ISerializationContext context, MemoryStream tagStream, IDataBlock block, object val, TagFieldAttribute valueInfo, Type valueType)
		{
			// Call the data block's PreSerialize callback to determine if the value should be mutated
			val = block.PreSerialize(valueInfo, val);
			if (val != null)
				valueType = val.GetType(); // TODO: Fix hax

			if (valueType.IsPrimitive)
				SerializePrimitiveValue(block.Writer, val, valueType);
			else
				SerializeComplexValue(context, tagStream, block, val, valueInfo, valueType);
		}

		/// <summary>
		/// Serializes a primitive value.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="val">The value.</param>
		/// <param name="valueType">Type of the value.</param>
		private static void SerializePrimitiveValue(BinaryWriter writer, object val, Type valueType)
		{
			switch (Type.GetTypeCode(valueType))
			{
				case TypeCode.Boolean:
					writer.Write((bool)val);
					break;
				case TypeCode.Byte:
					writer.Write((byte)val);
					break;
				case TypeCode.Double:
					writer.Write((double)val);
					break;
				case TypeCode.Int16:
					writer.Write((short)val);
					break;
				case TypeCode.Int32:
					writer.Write((int)val);
					break;
				case TypeCode.Int64:
					writer.Write((long)val);
					break;
				case TypeCode.SByte:
					writer.Write((sbyte)val);
					break;
				case TypeCode.Single:
					writer.Write((float)val);
					break;
				case TypeCode.UInt16:
					writer.Write((ushort)val);
					break;
				case TypeCode.UInt32:
					writer.Write((uint)val);
					break;
				case TypeCode.UInt64:
					writer.Write((ulong)val);
					break;
				default:
					throw new ArgumentException("Unsupported type " + valueType.Name);
			}
		}

		/// <summary>
		/// Serializes a complex value.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="val">The value.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		/// <param name="valueType">Type of the value.</param>
		private void SerializeComplexValue(ISerializationContext context, MemoryStream tagStream, IDataBlock block, object val, TagFieldAttribute valueInfo, Type valueType)
		{
			if (valueInfo != null && ((valueInfo.Flags & TagFieldFlags.Indirect) != 0 || valueType == typeof(ResourceReference)))
				SerializeIndirectValue(context, tagStream, block, val, valueType);
			else if (valueType.IsEnum)
				SerializePrimitiveValue(block.Writer, val, valueType.GetEnumUnderlyingType());
			else if (valueType == typeof(string))
				SerializeString(block.Writer, (string)val, valueInfo);
			else if (valueType == typeof(HaloTag))
				SerializeTagReference(block.Writer, (HaloTag)val, valueInfo);
			else if (valueType == typeof(ResourceAddress))
				block.Writer.Write(((ResourceAddress)val).Value);
			else if (valueType == typeof(byte[]))
				SerializeDataReference(tagStream, block, (byte[])val);
			else if (valueType == typeof(Vector2))
				SerializeVector(block, (Vector2)val);
			else if (valueType == typeof(Vector3))
				SerializeVector(block, (Vector3)val);
			else if (valueType == typeof(Vector4))
				SerializeVector(block, (Vector4)val);
			else if (valueType == typeof(StringId))
				block.Writer.Write(((StringId)val).Value);
			else if (valueType == typeof(Angle))
				block.Writer.Write(((Angle)val).Radians);
			else if (valueType.IsArray)
				SerializeInlineArray(context, tagStream, block, (Array)val, valueInfo);
			else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
				SerializeTagBlock(context, tagStream, block, val, valueType);
			else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Range<>))
				SerializeRange(block, val);
			else
				SerializeStruct(context, tagStream, block, new TagStructureInfo(val.GetType(), _version), val);
		}

		/// <summary>
		/// Serializes a string.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="str">The string to serialize.</param>
		/// <param name="valueInfo">Information about the value.</param>
		private static void SerializeString(BinaryWriter writer, string str, TagFieldAttribute valueInfo)
		{
			if (valueInfo == null || valueInfo.Length == 0)
				throw new ArgumentException("Cannot serialize a string with no length set");
			var clampedLength = 0;
			if (str != null)
			{
				var bytes = Encoding.ASCII.GetBytes(str);
				clampedLength = Math.Min(valueInfo.Length - 1, bytes.Length);
				writer.Write(bytes, 0, clampedLength);
			}
			for (var i = clampedLength; i < valueInfo.Length; i++)
				writer.Write((byte)0);
		}

		/// <summary>
		/// Serializes a tag reference.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="referencedTag">The referenced tag.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		private static void SerializeTagReference(BinaryWriter writer, HaloTag referencedTag, TagFieldAttribute valueInfo)
		{
			// Write the reference out
			if (valueInfo == null || (valueInfo.Flags & TagFieldFlags.Short) == 0)
			{
				writer.Write((referencedTag != null) ? referencedTag.GroupTag.Value : -1);
				writer.Write(0);
				writer.Write(0);
			}
			writer.Write((referencedTag != null) ? referencedTag.Index : -1);
		}

		/// <summary>
		/// Serializes a data reference composed of raw bytes.
		/// </summary>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="data">The data.</param>
		private static void SerializeDataReference(MemoryStream tagStream, IDataBlock block, byte[] data)
		{
			var writer = block.Writer;
			uint offset = 0;
			uint size = 0;
			if (data != null && data.Length > 0)
			{
				// The block has data - write it out to the tag
				StreamUtil.Align(tagStream, DefaultBlockAlign);
				offset = (uint)tagStream.Position;
				size = (uint)data.Length;
				tagStream.Write(data, 0, data.Length);
				StreamUtil.Align(tagStream, DefaultBlockAlign);
			}

			// Write the reference data
			writer.Write(size);
			writer.Write(0);
			writer.Write(0);
			if (size > 0)
				block.WritePointer(offset, typeof(byte[]));
			else
				writer.Write(0);
			writer.Write(0);
		}

		/// <summary>
		/// Serializes an inline array.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="data">The array.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		private void SerializeInlineArray(ISerializationContext context, MemoryStream tagStream, IDataBlock block, Array data, TagFieldAttribute valueInfo)
		{
			if (valueInfo == null || valueInfo.Count == 0)
				throw new ArgumentException("Cannot serialize an inline array with no count set");
			if (data == null || data.Length != valueInfo.Count)
				throw new ArgumentException("Array length does not match the fixed count of " + valueInfo.Count);

			// Serialize each element into the current block
			var elementType = data.GetType().GetElementType();
			foreach (var elem in data)
				SerializeValue(context, tagStream, block, elem, null, elementType);
		}

		/// <summary>
		/// Serializes a tag block.
		/// </summary>
		/// <param name="context">The serialization context to use.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="list">The list of values in the tag block.</param>
		/// <param name="listType">Type of the list.</param>
		private void SerializeTagBlock(ISerializationContext context, MemoryStream tagStream, IDataBlock block, object list, Type listType)
		{
			var writer = block.Writer;
			var listCount = 0;
			if (list != null)
			{
				// Use reflection to get the number of elements in the list
				var countProperty = listType.GetProperty("Count");
				listCount = (int)countProperty.GetValue(list);
			}
			if (listCount == 0)
			{
				writer.Write(0);
				writer.Write(0);
				writer.Write(0);
				return;
			}

			// Serialize each value in the list to a data block
			var tagBlock = context.CreateBlock();
			var enumerableList = (System.Collections.IEnumerable)list;
			var valueType = listType.GenericTypeArguments[0];
			foreach (var val in enumerableList)
				SerializeValue(context, tagStream, tagBlock, val, null, valueType);

			// Finalize the block and write the tag block reference
			writer.Write(listCount);
			block.WritePointer(tagBlock.Finalize(tagStream), listType);
			writer.Write(0);
		}

		private void SerializeIndirectValue(ISerializationContext context, MemoryStream tagStream, IDataBlock block, object val, Type valueType)
		{
			var writer = block.Writer;
			if (val == null)
			{
				writer.Write(0);
				return;
			}

			// Serialize the value to a temporary block
			var valueBlock = context.CreateBlock();
			SerializeValue(context, tagStream, valueBlock, val, null, valueType);

			// Finalize the block and write the pointer
			block.WritePointer(valueBlock.Finalize(tagStream), valueType);
		}

		private static void SerializeVector(IDataBlock block, Vector2 vec)
		{
			block.Writer.Write(vec.X);
			block.Writer.Write(vec.Y);
		}

		private static void SerializeVector(IDataBlock block, Vector3 vec)
		{
			block.Writer.Write(vec.X);
			block.Writer.Write(vec.Y);
			block.Writer.Write(vec.Z);
		}

		private static void SerializeVector(IDataBlock block, Vector4 vec)
		{
			block.Writer.Write(vec.X);
			block.Writer.Write(vec.Y);
			block.Writer.Write(vec.Z);
			block.Writer.Write(vec.W);
		}

		private static void SerializeRange(IDataBlock block, object val)
		{
			var type = val.GetType();
			var boundsType = type.GenericTypeArguments[0];
			var min = type.GetField("Min").GetValue(val);
			var max = type.GetField("Max").GetValue(val);
			SerializePrimitiveValue(block.Writer, min, boundsType);
			SerializePrimitiveValue(block.Writer, max, boundsType);
		}
	}
}
