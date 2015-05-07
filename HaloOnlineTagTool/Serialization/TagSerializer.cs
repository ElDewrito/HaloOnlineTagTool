using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Serializes classes into tag data by using reflection.
	/// </summary>
	public class TagSerializer
	{
		private const int DefaultBlockAlign = 4;

		private readonly TagCache _cache;

		/// <summary>
		/// Initializes a new instance of the <see cref="TagSerializer"/> class.
		/// </summary>
		/// <param name="cache">The tag cache that will be used.</param>
		public TagSerializer(TagCache cache)
		{
			_cache = cache;
		}

		/// <summary>
		/// Serializes a structure into a tag, overwriting it.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="stream">The stream.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="tagStructure">The tag structure.</param>
		public void Serialize<T>(Stream stream, HaloTag tag, T tagStructure)
		{
			// Clear out the tag
			tag.Dependencies.Clear();
			tag.DataFixups.Clear();
			tag.ResourceFixups.Clear();

			// Serialize the structure to a temporary block
			var tagStream = new MemoryStream();
			var structBlock = new TemporaryBlock();
			SerializeStruct(tag, tagStream, structBlock, tagStructure);

			// Finalize the block and write all of the tag data out to the tag
			tag.MainStructOffset = structBlock.Finalize(tag, tagStream);
			var data = new byte[tagStream.Length];
			Buffer.BlockCopy(tagStream.GetBuffer(), 0, data, 0, (int)tagStream.Length);
			_cache.OverwriteTag(stream, tag, data);
			_cache.UpdateTag(stream, tag);
		}

		/// <summary>
		/// Serializes a structure into a temporary memory block.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="structure">The structure to serialize.</param>
		/// <exception cref="System.InvalidOperationException">Structure type must have TagStructureAttribute</exception>
		private void SerializeStruct(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, object structure)
		{
			// Get the TagStructureAttribute associated with the structure type
			var structType = structure.GetType();
			var structAttrib = structType.GetCustomAttributes(typeof(TagStructureAttribute), false).FirstOrDefault() as TagStructureAttribute;
			if (structAttrib == null)
				throw new InvalidOperationException("Structure type must have TagStructureAttribute");

			// Serialize each property
			var properties = structType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			var baseOffset = block.Stream.Position;
			foreach (var property in properties)
				SerializeProperty(tag, tagStream, block, structure, structAttrib, property, baseOffset);

			// Honor the struct size if it's defined
			if (structAttrib.Size > 0)
			{
				block.Stream.Position = baseOffset + structAttrib.Size;
				if (block.Stream.Position > block.Stream.Length)
					block.Stream.SetLength(block.Stream.Position);
			}
		}

		/// <summary>
		/// Serializes a property.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="instance">The object that the property belongs to.</param>
		/// <param name="structInfo">The structure information.</param>
		/// <param name="property">The property.</param>
		/// <param name="baseOffset">The base offset of the structure from the start of its block.</param>
		/// <exception cref="System.InvalidOperationException">Offset for property \ + property.Name + \ is outside of its structure</exception>
		private void SerializeProperty(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, object instance, TagStructureAttribute structInfo, PropertyInfo property, long baseOffset)
		{
			// Get the property's TagValueAttribute
			var valueInfo = property.GetCustomAttributes(typeof(TagElementAttribute), false).FirstOrDefault() as TagElementAttribute;
			if (valueInfo == null)
				return; // Ignore the property
			if (valueInfo.Offset >= structInfo.Size)
				throw new InvalidOperationException("Offset for property \"" + property.Name + "\" is outside of its structure");

			// Seek to the value if it has an offset specified and write it
			if (valueInfo.Offset >= 0)
				block.Stream.Position = baseOffset + valueInfo.Offset;
			var startOffset = block.Stream.Position;
			var val = property.GetValue(instance);
			SerializeValue(tag, tagStream, block, val, valueInfo, property.PropertyType);
			if (valueInfo.Size > 0)
				block.Stream.Position = startOffset + valueInfo.Size;
		}

		/// <summary>
		/// Serializes a value.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="val">The value.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		/// <param name="valueType">Type of the value.</param>
		private void SerializeValue(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, object val, TagElementAttribute valueInfo, Type valueType)
		{
			if (valueType.IsPrimitive)
				SerializePrimitiveValue(block.Writer, val, valueType);
			else
				SerializeComplexValue(tag, tagStream, block, val, valueInfo, valueType);
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
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="val">The value.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		/// <param name="valueType">Type of the value.</param>
		private void SerializeComplexValue(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, object val, TagElementAttribute valueInfo, Type valueType)
		{
			if (valueType.IsEnum)
				SerializePrimitiveValue(block.Writer, val, valueType.GetEnumUnderlyingType());
			else if (valueType == typeof(string))
				SerializeString(block.Writer, (string)val);
			else if (valueType == typeof(HaloTag))
				SerializeTagReference(tag, block.Writer, (HaloTag)val);
			else if (valueType == typeof(ResourceReference))
				SerializeResourceReference(tag, tagStream, block, (ResourceReference)val);
			else if (valueType == typeof(byte[]))
				SerializeDataReference(tagStream, block, (byte[])val);
			else if (valueType.IsArray)
				SerializeInlineArray(tag, tagStream, block, (Array)val, valueInfo);
			else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
				SerializeTagBlock(tag, tagStream, block, val, valueType);
			else
				SerializeStruct(tag, tagStream, block, val);
		}

		/// <summary>
		/// Serializes a string.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="str">The string to serialize.</param>
		private static void SerializeString(BinaryWriter writer, string str)
		{
			var bytes = Encoding.UTF8.GetBytes(str);
			writer.Write(bytes);
			writer.Write((byte)0);
		}

		/// <summary>
		/// Serializes a tag reference.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="referencedTag">The referenced tag.</param>
		private void SerializeTagReference(HaloTag tag, BinaryWriter writer, HaloTag referencedTag)
		{
			// Add the tag as a dependency of the current tag
			if (referencedTag != null)
				tag.Dependencies.Add(referencedTag.Index);

			// Write the reference out
			writer.Write((referencedTag != null) ? referencedTag.Class.Value : -1);
			writer.Write(0);
			writer.Write(0);
			writer.Write((referencedTag != null) ? referencedTag.Index : -1);
		}

		/// <summary>
		/// Serializes a data reference composed of raw bytes.
		/// </summary>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="data">The data.</param>
		private void SerializeDataReference(MemoryStream tagStream, TemporaryBlock block, byte[] data)
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
				block.WritePointer(offset);
			else
				writer.Write(0);
			writer.Write(0);
		}

		/// <summary>
		/// Serializes an inline array.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="data">The array.</param>
		/// <param name="valueInfo">Information about the value. Can be <c>null</c>.</param>
		private void SerializeInlineArray(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, Array data, TagElementAttribute valueInfo)
		{
			if (valueInfo == null || valueInfo.Count == 0)
				throw new ArgumentException("Cannot serialize an inline array with no count set");
			if (data == null || data.Length != valueInfo.Count)
				throw new ArgumentException("Array length does not match the fixed count of " + valueInfo.Count);

			// Serialize each element into the current block
			var elementType = data.GetType().GetElementType();
			foreach (var elem in data)
				SerializeValue(tag, tagStream, block, elem, null, elementType);
		}

		/// <summary>
		/// Serializes a tag block.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="list">The list of values in the tag block.</param>
		/// <param name="listType">Type of the list.</param>
		private void SerializeTagBlock(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, object list, Type listType)
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

			// Serialize each value in the list to a temporary block
			var tagBlock = new TemporaryBlock();
			var enumerableList = (System.Collections.IEnumerable)list;
			var valueType = listType.GenericTypeArguments[0];
			foreach (var val in enumerableList)
				SerializeValue(tag, tagStream, tagBlock, val, null, valueType);

			// Finalize the block and write the tag block reference
			writer.Write(listCount);
			block.WritePointer(tagBlock.Finalize(tag, tagStream));
			writer.Write(0);
		}

		/// <summary>
		/// Serializes a resource reference.
		/// </summary>
		/// <param name="tag">The tag currently being serialized.</param>
		/// <param name="tagStream">The stream to write completed blocks of tag data to.</param>
		/// <param name="block">The temporary block to write incomplete tag data to.</param>
		/// <param name="resource">The resource reference to serialize.</param>
		private void SerializeResourceReference(HaloTag tag, MemoryStream tagStream, TemporaryBlock block, ResourceReference resource)
		{
			var writer = block.Writer;
			if (resource == null)
			{
				writer.Write(0);
				return;
			}

			// Serialize the reference data to a temporary block
			var resourceBlock = new TemporaryBlock();
			SerializeStruct(tag, tagStream, resourceBlock, resource);

			// Finalize the block and write the pointer
			block.WriteResourcePointer(resourceBlock.Finalize(tag, tagStream));
		}

		/// <summary>
		/// An incomplete block of tag data which is not ready to be written to a tag.
		/// </summary>
		private class TemporaryBlock
		{
			private readonly List<TagFixup> _fixups = new List<TagFixup>(); 
			private readonly List<TagFixup> _resourceFixups = new List<TagFixup>();

			public TemporaryBlock()
			{
				Stream = new MemoryStream();
				Writer = new BinaryWriter(Stream);
			}

			/// <summary>
			/// Writes a pointer to the current position in the block and adds a fixup for it.
			/// </summary>
			/// <param name="targetOffset">The target offset of the pointer.</param>
			public void WritePointer(uint targetOffset)
			{
				_fixups.Add(MakeFixup(targetOffset));
				Writer.Write(targetOffset + 0x40000000);
			}

			/// <summary>
			/// Writes a resource pointer to the current position in the block and adds a fixup for it.
			/// </summary>
			/// <param name="targetOffset">The target offset of the pointer.</param>
			public void WriteResourcePointer(uint targetOffset)
			{
				_resourceFixups.Add(MakeFixup(targetOffset));
				WritePointer(targetOffset);
			}

			/// <summary>
			/// Finalizes the block, writing it out to a tag and adding the block's fixups to the tag.
			/// </summary>
			/// <param name="tag">The tag.</param>
			/// <param name="tagStream">The tag stream.</param>
			/// <returns>The offset of the block within the tag data.</returns>
			public uint Finalize(HaloTag tag, Stream tagStream)
			{
				// Write the data out, aligning the offset and size
				StreamUtil.Align(tagStream, DefaultBlockAlign);
				var dataOffset = (uint)tagStream.Position;
				tagStream.Write(Stream.GetBuffer(), 0, (int)Stream.Length);
				StreamUtil.Align(tagStream, DefaultBlockAlign);

				// Adjust fixups and add them to the tag
				tag.DataFixups.AddRange(_fixups.Select(f => FinalizeFixup(f, dataOffset)));
				tag.ResourceFixups.AddRange(_resourceFixups.Select(f => FinalizeFixup(f, dataOffset)));
				return dataOffset;
			}

			/// <summary>
			/// Gets or sets the block's stream.
			/// </summary>
			public MemoryStream Stream { get; private set; }

			/// <summary>
			/// Gets or sets the writer for the block's stream.
			/// </summary>
			public BinaryWriter Writer { get; private set; }

			/// <summary>
			/// Makes a fixup which will be written to the current offset and will point to a target offset.
			/// </summary>
			/// <param name="targetOffset">The target offset.</param>
			/// <returns>The fixup.</returns>
			private TagFixup MakeFixup(uint targetOffset)
			{
				return new TagFixup
				{
					TargetOffset = targetOffset,
					WriteOffset = (uint)Stream.Position
				};
			}

			/// <summary>
			/// Finalizes a fixup, adding to its write offset.
			/// </summary>
			/// <param name="fixup">The fixup.</param>
			/// <param name="dataOffset">The data offset.</param>
			/// <returns>The finalized fixup.</returns>
			private static TagFixup FinalizeFixup(TagFixup fixup, uint dataOffset)
			{
				return new TagFixup
				{
					TargetOffset = fixup.TargetOffset,
					WriteOffset = dataOffset + fixup.WriteOffset
				};
			}
		}
	}
}
