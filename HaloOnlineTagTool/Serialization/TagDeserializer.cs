using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Deserializes tag data into objects by using reflection.
	/// </summary>
	public class TagDeserializer
	{
		private readonly TagCache _cache;

		/// <summary>
		/// Initializes a new instance of the <see cref="TagDeserializer"/> class.
		/// </summary>
		/// <param name="cache">The tag cache to use.</param>
		public TagDeserializer(TagCache cache)
		{
			_cache = cache;
		}

		/// <summary>
		/// Reads a tag from a tag cache file and deserializes it into an object.
		/// </summary>
		/// <typeparam name="T">The type of object to deserialize the tag as.</typeparam>
		/// <param name="stream">The tag cache stream.</param>
		/// <param name="tag">The tag to read.</param>
		/// <returns>The object that was read.</returns>
		public T Deserialize<T>(Stream stream, HaloTag tag)
		{
			// TODO: Add support for tag inheritance

			// Extract the tag data and open a memory stream on it
			var data = _cache.ExtractTag(stream, tag);
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				reader.BaseStream.Position = tag.MainStructOffset;
				return (T)DeserializeStruct(reader, tag, typeof(T), new HashSet<uint>());
			}
		}

		/// <summary>
		/// Deserializes a structure.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="tag">The tag that the structure belongs to.</param>
		/// <param name="structType">The type of the structure to deserialize.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized structure.</returns>
		/// <exception cref="System.InvalidOperationException">Target type must have TagStructureAttribute</exception>
		private object DeserializeStruct(BinaryReader reader, HaloTag tag, Type structType, HashSet<uint> fixupCoverage)
		{
			// Get the TagStructureAttribute associated with the target type
			var structAttrib = structType.GetCustomAttributes(typeof(TagStructureAttribute), false).FirstOrDefault() as TagStructureAttribute;
		    if (structAttrib == null)
		        throw new InvalidOperationException("Target type must have TagStructureAttribute");

			// Deserialize each property in the structure
			var baseOffset = reader.BaseStream.Position;
			var properties = structType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			var instance = Activator.CreateInstance(structType);
			foreach (var property in properties)
				DeserializeProperty(reader, tag, instance, structAttrib, property, baseOffset, fixupCoverage);
			if (structAttrib.Size > 0)
				reader.BaseStream.Position = baseOffset + structAttrib.Size;

#if DEBUG
		    var endOffset = reader.BaseStream.Position;
		    foreach (var fixup in tag.DataFixups)
		    {
		        if (fixup.WriteOffset >= baseOffset && fixup.WriteOffset < endOffset && !fixupCoverage.Contains(fixup.WriteOffset))
                    Debug.WriteLine("FIXUP COVERAGE: Missed fixup at 0x{0:X} in {1} (0x{2:X} - 0x{3:X})", fixup.WriteOffset - baseOffset, structType.ToString(), baseOffset, endOffset);
		    }
#endif

			return instance;
		}

		/// <summary>
		/// Deserializes a property of a structure.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="instance">The instance to store the property to.</param>
		/// <param name="structInfo">The structure information.</param>
		/// <param name="property">The property.</param>
		/// <param name="baseOffset">The offset of the start of the structure.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <exception cref="System.InvalidOperationException">Offset for property is outside of its structure</exception>
		private void DeserializeProperty(BinaryReader reader, HaloTag tag, object instance, TagStructureAttribute structInfo, PropertyInfo property, long baseOffset, HashSet<uint> fixupCoverage)
		{
			// Get the property's TagValueAttribute
			var valueInfo = property.GetCustomAttributes(typeof(TagElementAttribute), false).FirstOrDefault() as TagElementAttribute;
			if (valueInfo == null)
				return; // Ignore the property
			if (valueInfo.Offset >= structInfo.Size)
				throw new InvalidOperationException("Offset for property \"" + property.Name + "\" is outside of its structure");

			// Seek to the value if it has an offset specified and then read it
			if (valueInfo.Offset >= 0)
				reader.BaseStream.Position = baseOffset + valueInfo.Offset;
			var startOffset = reader.BaseStream.Position;
			property.SetValue(instance, DeserializeValue(reader, tag, valueInfo, property.PropertyType, fixupCoverage));
			if (valueInfo.Size > 0)
				reader.BaseStream.Position = startOffset + valueInfo.Size; // Honor the value's size if it has one set
		}

		/// <summary>
		/// Deserializes a value.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized value.</returns>
		private object DeserializeValue(BinaryReader reader, HaloTag tag, TagElementAttribute valueInfo, Type valueType, HashSet<uint> fixupCoverage)
		{
			if (valueType.IsPrimitive)
				return DeserializePrimitiveValue(reader, valueType);
			return DeserializeComplexValue(reader, tag, valueInfo, valueType, fixupCoverage);
		}

		/// <summary>
		/// Deserializes a primitive value.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <returns>The deserialized value.</returns>
		/// <exception cref="System.ArgumentException">Unsupported type</exception>
		private static object DeserializePrimitiveValue(BinaryReader reader, Type valueType)
		{
			switch (Type.GetTypeCode(valueType))
			{
				case TypeCode.Boolean:
					return reader.ReadBoolean();
				case TypeCode.Byte:
					return reader.ReadByte();
				case TypeCode.Double:
					return reader.ReadDouble();
				case TypeCode.Int16:
					return reader.ReadInt16();
				case TypeCode.Int32:
					return reader.ReadInt32();
				case TypeCode.Int64:
					return reader.ReadInt64();
				case TypeCode.SByte:
					return reader.ReadSByte();
				case TypeCode.Single:
					return reader.ReadSingle();
				case TypeCode.UInt16:
					return reader.ReadUInt16();
				case TypeCode.UInt32:
					return reader.ReadUInt32();
				case TypeCode.UInt64:
					return reader.ReadUInt64();
				default:
					throw new ArgumentException("Unsupported type " + valueType.Name);
			}
		}

		/// <summary>
		/// Deserializes a complex value.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized value.</returns>
		private object DeserializeComplexValue(BinaryReader reader, HaloTag tag, TagElementAttribute valueInfo, Type valueType, HashSet<uint> fixupCoverage)
		{
			// enum = Enum type
			if (valueType.IsEnum)
				return DeserializePrimitiveValue(reader, valueType.GetEnumUnderlyingType());

			// string = ASCII string
			if (valueType == typeof(string))
				return DeserializeString(reader);

			// HaloTag = Tag reference
			if (valueType == typeof(HaloTag))
				return DeserializeTagReference(reader);

			// ResourceReference = Resource reference
			if (valueType == typeof(ResourceReference))
				return DeserializeResourceReference(reader, tag, fixupCoverage);

			// Byte array = Data reference
			// TODO: Allow other types to be in data references, since sometimes they can point to a structure
			if (valueType == typeof(byte[]))
				return DeserializeDataReference(reader, fixupCoverage);

			// Non-byte array = Inline array
			// TODO: Define more clearly in general what constitutes a data reference and what doesn't
			if (valueType.IsArray)
				return DeserializeInlineArray(reader, tag, valueInfo, valueType, fixupCoverage);

			// List = Tag block
			if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
				return DeserializeTagBlock(reader, tag, valueType, fixupCoverage);

			// Assume the value is a structure
			return DeserializeStruct(reader, tag, valueType, fixupCoverage);
		}

		/// <summary>
		/// Deserializes a tag block (list of values).
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized tag block.</returns>
		private object DeserializeTagBlock(BinaryReader reader, HaloTag tag, Type valueType, HashSet<uint> fixupCoverage)
		{
			var elementType = valueType.GenericTypeArguments[0];
			var result = Activator.CreateInstance(valueType);
			
			// Read count and offset
			var startOffset = reader.BaseStream.Position;
			var count = reader.ReadInt32();
		    fixupCoverage.Add((uint)reader.BaseStream.Position);
			var pointer = reader.ReadUInt32();
			if (count == 0 || pointer == 0)
			{
				// Null tag block
				reader.BaseStream.Position = startOffset + 0xC;
				return result;
			}

			// Read each value
			var addMethod = valueType.GetMethod("Add");
			reader.BaseStream.Position = pointer - 0x40000000;
			for (var i = 0; i < count; i++)
			{
				var element = DeserializeValue(reader, tag, null, elementType, new HashSet<uint>());
				addMethod.Invoke(result, new[] { element });
			}
			reader.BaseStream.Position = startOffset + 0xC;
			return result;
		}

		/// <summary>
		/// Deserializes a resource reference.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized resource reference.</returns>
		private object DeserializeResourceReference(BinaryReader reader, HaloTag tag, HashSet<uint> fixupCoverage)
		{
			// Resource references are just a pointer to a ResourceReference structure
			fixupCoverage.Add((uint)reader.BaseStream.Position);
			var pointer = reader.ReadUInt32();
			if (pointer == 0)
				return null; // Null resource reference

			var nextOffset = reader.BaseStream.Position;
			reader.BaseStream.Position = pointer - 0x40000000;
			var result = DeserializeStruct(reader, tag, typeof(ResourceReference), new HashSet<uint>());
			reader.BaseStream.Position = nextOffset;
			return result;
		}

		/// <summary>
		/// Deserializes a tag reference.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>The deserialized tag reference.</returns>
		private HaloTag DeserializeTagReference(BinaryReader reader)
		{
			reader.BaseStream.Position += 0xC; // Skip the class name and zero bytes, it's not important
			var index = reader.ReadInt32();
			return (index >= 0 && index < _cache.Tags.Count) ? _cache.Tags[index] : null;
		}

		/// <summary>
		/// Deserializes a data reference.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized data reference.</returns>
		private static byte[] DeserializeDataReference(BinaryReader reader, HashSet<uint> fixupCoverage)
		{
			// Read size and pointer
			var startOffset = reader.BaseStream.Position;
			var size = reader.ReadInt32();
			reader.BaseStream.Position = startOffset + 0xC;
		    fixupCoverage.Add((uint)reader.BaseStream.Position);
			var pointer = reader.ReadUInt32();
			if (pointer == 0)
			{
				// Null data reference
				reader.BaseStream.Position = startOffset + 0x14;
				return new byte[0];
			}

			// Read the data
			var result = new byte[size];
			reader.BaseStream.Position = pointer - 0x40000000;
			reader.Read(result, 0, size);
			reader.BaseStream.Position = startOffset + 0x14;
			return result;
		}

		/// <summary>
		/// Deserializes an inline array.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <param name="fixupCoverage">Fixup coverage information.</param>
		/// <returns>The deserialized array.</returns>
		private Array DeserializeInlineArray(BinaryReader reader, HaloTag tag, TagElementAttribute valueInfo, Type valueType, HashSet<uint> fixupCoverage)
		{
			if (valueInfo == null || valueInfo.Count == 0)
				throw new ArgumentException("Cannot deserialize an inline array with no count set");

			// Create the array and read the elements in order
			var elementCount = valueInfo.Count;
			var elementType = valueType.GetElementType();
			var result = Array.CreateInstance(elementType, elementCount);
			for (var i = 0; i < elementCount; i++)
				result.SetValue(DeserializeValue(reader, tag, null, elementType, fixupCoverage), i);
			return result;
		}

		/// <summary>
		/// Deserializes a null-terminated ASCII string.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>The deserialized string.</returns>
		private static string DeserializeString(BinaryReader reader)
		{
			// Keep reading until a null terminator is found
			// TODO: Fix this for UTF-8 strings
			var result = new StringBuilder();
			while (true)
			{
				var ch = reader.ReadByte();
				if (ch == 0)
					break;
				result.Append((char)ch);
			}
			return result.ToString();
		}
	}
}
