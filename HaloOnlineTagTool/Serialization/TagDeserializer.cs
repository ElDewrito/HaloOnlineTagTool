using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
				return (T)DeserializeStruct(reader, typeof(T));
			}
		}

		/// <summary>
		/// Deserializes a structure.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="structType">The type of the structure to deserialize.</param>
		/// <returns>The deserialized structure.</returns>
		/// <exception cref="System.InvalidOperationException">Target type must have TagStructureAttribute</exception>
		private object DeserializeStruct(BinaryReader reader, Type structType)
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
				DeserializeProperty(reader, instance, structAttrib, property, baseOffset);
			if (structAttrib.Size > 0)
				reader.BaseStream.Position = baseOffset + structAttrib.Size;
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
		/// <exception cref="System.InvalidOperationException">Offset for property is outside of its structure</exception>
		private void DeserializeProperty(BinaryReader reader, object instance, TagStructureAttribute structInfo, PropertyInfo property, long baseOffset)
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
			property.SetValue(instance, DeserializeValue(reader, property.PropertyType));
			if (valueInfo.Size > 0)
				reader.BaseStream.Position = startOffset + valueInfo.Size; // Honor the value's size if it has one set
		}

		/// <summary>
		/// Deserializes a value.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <returns>The deserialized value.</returns>
		private object DeserializeValue(BinaryReader reader, Type valueType)
		{
			if (valueType.IsPrimitive)
				return DeserializePrimitiveValue(reader, valueType);
			return DeserializeComplexValue(reader, valueType);
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
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <returns>The deserialized value.</returns>
		private object DeserializeComplexValue(BinaryReader reader, Type valueType)
		{
			// string = ASCII string
			if (valueType == typeof(string))
				return DeserializeString(reader);

			// HaloTag = Tag reference
			if (valueType == typeof(HaloTag))
				return DeserializeTagReference(reader);

			// Byte array = Data reference
			// TODO: Allow other types to be in data references, since sometimes they can point to a structure
			if (valueType == typeof(byte[]))
				return DeserializeDataReference(reader);

			// List = Tag block
			if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
				return DeserializeTagBlock(reader, valueType);

			// Assume the value is a structure
			return DeserializeStruct(reader, valueType);
		}

		/// <summary>
		/// Deserializes a tag block (list of values).
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="valueType">The type of the value to deserialize.</param>
		/// <returns>The deserialized tag block.</returns>
		private object DeserializeTagBlock(BinaryReader reader, Type valueType)
		{
			var elementType = valueType.GenericTypeArguments[0];
			var result = Activator.CreateInstance(valueType);
			
			// Read count and offset
			var startOffset = reader.BaseStream.Position;
			var count = reader.ReadInt32();
			var pointer = reader.ReadUInt32();
			if (pointer == 0)
				return result; // Null tag block

			// Read each value
			var addMethod = valueType.GetMethod("Add");
			reader.BaseStream.Position = pointer - 0x40000000;
			for (var i = 0; i < count; i++)
			{
				var element = DeserializeValue(reader, elementType);
				addMethod.Invoke(result, new[] { element });
			}
			reader.BaseStream.Position = startOffset + 0xC;
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
		/// <returns>The deserialized data reference.</returns>
		private static byte[] DeserializeDataReference(BinaryReader reader)
		{
			// Read size and pointer
			var startOffset = reader.BaseStream.Position;
			var size = reader.ReadInt32();
			reader.BaseStream.Position += 8;
			var pointer = reader.ReadUInt32();
			if (pointer == 0)
				return new byte[0]; // Null data reference

			// Read the data
			var result = new byte[size];
			reader.BaseStream.Position = pointer - 0x40000000;
			reader.Read(result, 0, size);
			reader.BaseStream.Position = startOffset + 0x14;
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
