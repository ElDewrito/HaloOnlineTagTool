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
    /// Deserializes tag data into objects by using reflection.
    /// </summary>
    public class TagDeserializer
    {
        private readonly EngineVersion _version;

        /// <summary>
        /// Constructs a tag deserializer for a specific engine version.
        /// </summary>
        /// <param name="version">The engine version to target.</param>
        public TagDeserializer(EngineVersion version)
        {
            _version = version;
        }

        /// <summary>
        /// Deserializes tag data into an object.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize the tag data as.</typeparam>
        /// <param name="context">The serialization context to use.</param>
        /// <returns>The object that was read.</returns>
        public T Deserialize<T>(ISerializationContext context)
        {
            var result = Deserialize(context, typeof(T));
            return (T)Convert.ChangeType(result, typeof(T));
        }

        /// <summary>
        /// Deserializes tag data into an object.
        /// </summary>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="structureType">The type of object to deserialize the tag data as.</param>
        /// <returns>The object that was read.</returns>
        public object Deserialize(ISerializationContext context, Type structureType)
        {
            var info = new TagStructureInfo(structureType, _version);
            var reader = context.BeginDeserialize(info);
            var result = DeserializeStruct(reader, context, info);
            context.EndDeserialize(info, result);
            return result;
        }

        /// <summary>
        /// Deserializes a structure.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="info">Information about the structure to deserialize.</param>
        /// <returns>The deserialized structure.</returns>
        /// <exception cref="System.InvalidOperationException">Target type must have TagStructureAttribute</exception>
        private object DeserializeStruct(BinaryReader reader, ISerializationContext context, TagStructureInfo info)
        {
            var baseOffset = reader.BaseStream.Position;
            var instance = Activator.CreateInstance(info.Types[0]);
            var enumerator = new TagFieldEnumerator(info);
            while (enumerator.Next())
                DeserializeProperty(reader, context, instance, enumerator, baseOffset);
            if (enumerator.Info.TotalSize > 0)
                reader.BaseStream.Position = baseOffset + enumerator.Info.TotalSize;
            return instance;
        }

        /// <summary>
        /// Deserializes a property of a structure.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="instance">The instance to store the property to.</param>
        /// <param name="enumerator">The active element enumerator.</param>
        /// <param name="baseOffset">The offset of the start of the structure.</param>
        /// <exception cref="System.InvalidOperationException">Offset for property is outside of its structure</exception>
        private void DeserializeProperty(BinaryReader reader, ISerializationContext context, object instance, TagFieldEnumerator enumerator, long baseOffset)
        {
            // Seek to the value if it has an offset specified and then read it
            if (enumerator.Attribute.Offset >= 0)
                reader.BaseStream.Position = baseOffset + enumerator.Attribute.Offset;
            var startOffset = reader.BaseStream.Position;
            enumerator.Field.SetValue(instance, DeserializeValue(reader, context, enumerator.Attribute, enumerator.Field.FieldType));
            if (enumerator.Attribute.Size > 0)
                reader.BaseStream.Position = startOffset + enumerator.Attribute.Size; // Honor the value's size if it has one set
        }

        /// <summary>
        /// Deserializes a value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
        /// <param name="valueType">The type of the value to deserialize.</param>
        /// <returns>The deserialized value.</returns>
        private object DeserializeValue(BinaryReader reader, ISerializationContext context, TagFieldAttribute valueInfo, Type valueType)
        {
            if (valueType.IsPrimitive)
                return DeserializePrimitiveValue(reader, valueType);
            return DeserializeComplexValue(reader, context, valueInfo, valueType);
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
        /// <param name="context">The serialization context to use.</param>
        /// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
        /// <param name="valueType">The type of the value to deserialize.</param>
        /// <returns>The deserialized value.</returns>
        private object DeserializeComplexValue(BinaryReader reader, ISerializationContext context, TagFieldAttribute valueInfo, Type valueType)
        {
            // Indirect objects
            // TODO: Remove ResourceReference hax, the Indirect flag wasn't available when I generated the tag structures
            if (valueInfo != null && ((valueInfo.Flags & TagFieldFlags.Indirect) != 0 || valueType == typeof(ResourceReference)))
                return DeserializeIndirectValue(reader, context, valueType);

            // enum = Enum type
            if (valueType.IsEnum)
                return DeserializePrimitiveValue(reader, valueType.GetEnumUnderlyingType());

            // string = ASCII string
            if (valueType == typeof(string))
                return DeserializeString(reader, valueInfo);

            // TagInstance = Tag reference
            if (valueType == typeof(TagInstance))
                return DeserializeTagReference(reader, context, valueInfo);

            // ResourceAddress = Resource address
            if (valueType == typeof(ResourceAddress))
                return new ResourceAddress(reader.ReadUInt32());

            // Byte array = Data reference
            // TODO: Allow other types to be in data references, since sometimes they can point to a structure
            if (valueType == typeof(byte[]))
                return DeserializeDataReference(reader, context);

            // Euler Angles types
            if (valueType == typeof(Euler2))
            {
                var i = Angle.FromRadians(reader.ReadSingle());
                var j = Angle.FromRadians(reader.ReadSingle());
                return new Euler2(i, j);
            }
            else if (valueType == typeof(Euler3))
            {
                var i = Angle.FromRadians(reader.ReadSingle());
                var j = Angle.FromRadians(reader.ReadSingle());
                var k = Angle.FromRadians(reader.ReadSingle());
                return new Euler3(i, j, k);
            }

            // Vector types
            if (valueType == typeof(Vector2))
                return new Vector2(reader.ReadSingle(), reader.ReadSingle());
            if (valueType == typeof(Vector3))
                return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            if (valueType == typeof(Vector4))
                return new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            // StringID
            if (valueType == typeof(StringId))
                return new StringId(reader.ReadUInt32());

            // Angle (radians)
            if (valueType == typeof(Angle))
                return Angle.FromRadians(reader.ReadSingle());

            // Non-byte array = Inline array
            // TODO: Define more clearly in general what constitutes a data reference and what doesn't
            if (valueType.IsArray)
                return DeserializeInlineArray(reader, context, valueInfo, valueType);

            // List = Tag block
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
                return DeserializeTagBlock(reader, context, valueType);

            // Ranges
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Range<>))
                return DeserializeRange(reader, context, valueType);

            // Assume the value is a structure
            return DeserializeStruct(reader, context, new TagStructureInfo(valueType, _version));
        }

        /// <summary>
        /// Deserializes a tag block (list of values).
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="valueType">The type of the value to deserialize.</param>
        /// <returns>The deserialized tag block.</returns>
        private object DeserializeTagBlock(BinaryReader reader, ISerializationContext context, Type valueType)
        {
            var elementType = valueType.GenericTypeArguments[0];
            var result = Activator.CreateInstance(valueType);
            
            // Read count and offset
            var startOffset = reader.BaseStream.Position;
            var count = reader.ReadInt32();
            var pointer = reader.ReadUInt32();
            if (count == 0 || pointer == 0)
            {
                // Null tag block
                reader.BaseStream.Position = startOffset + 0xC;
                return result;
            }

            // Read each value
            var addMethod = valueType.GetMethod("Add");
            reader.BaseStream.Position = context.AddressToOffset((uint)startOffset + 4, pointer);
            for (var i = 0; i < count; i++)
            {
                var element = DeserializeValue(reader, context, null, elementType);
                addMethod.Invoke(result, new[] { element });
            }
            reader.BaseStream.Position = startOffset + 0xC;
            return result;
        }

        /// <summary>
        /// Deserializes a value which is pointed to by an address.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="valueType">The type of the value to deserialize.</param>
        /// <returns>The deserialized value.</returns>
        private object DeserializeIndirectValue(BinaryReader reader, ISerializationContext context, Type valueType)
        {
            // Read the pointer
            var pointer = reader.ReadUInt32();
            if (pointer == 0)
                return null; // Null object

            // Seek to it and read the object
            var nextOffset = reader.BaseStream.Position;
            reader.BaseStream.Position = context.AddressToOffset((uint)nextOffset - 4, pointer);
            var result = DeserializeValue(reader, context, null, valueType);
            reader.BaseStream.Position = nextOffset;
            return result;
        }

        /// <summary>
        /// Deserializes a tag reference.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
        /// <returns>The deserialized tag reference.</returns>
        private static TagInstance DeserializeTagReference(BinaryReader reader, ISerializationContext context, TagFieldAttribute valueInfo)
        {
            if (valueInfo == null || (valueInfo.Flags & TagFieldFlags.Short) == 0)
                reader.BaseStream.Position += 0xC; // Skip the class name and zero bytes, it's not important
            var index = reader.ReadInt32();
            return context.GetTagByIndex(index);
        }

        /// <summary>
        /// Deserializes a data reference.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <returns>The deserialized data reference.</returns>
        private static byte[] DeserializeDataReference(BinaryReader reader, ISerializationContext context)
        {
            // Read size and pointer
            var startOffset = reader.BaseStream.Position;
            var size = reader.ReadInt32();
            reader.BaseStream.Position = startOffset + 0xC;
            var pointer = reader.ReadUInt32();
            if (pointer == 0)
            {
                // Null data reference
                reader.BaseStream.Position = startOffset + 0x14;
                return new byte[0];
            }

            // Read the data
            var result = new byte[size];
            reader.BaseStream.Position = context.AddressToOffset((uint)startOffset + 0xC, pointer);
            reader.Read(result, 0, size);
            reader.BaseStream.Position = startOffset + 0x14;
            return result;
        }

        /// <summary>
        /// Deserializes an inline array.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="valueInfo">The value information. Can be <c>null</c>.</param>
        /// <param name="valueType">The type of the value to deserialize.</param>
        /// <returns>The deserialized array.</returns>
        private Array DeserializeInlineArray(BinaryReader reader, ISerializationContext context, TagFieldAttribute valueInfo, Type valueType)
        {
            if (valueInfo == null || valueInfo.Count == 0)
                throw new ArgumentException("Cannot deserialize an inline array with no count set");

            // Create the array and read the elements in order
            var elementCount = valueInfo.Count;
            var elementType = valueType.GetElementType();
            var result = Array.CreateInstance(elementType, elementCount);
            for (var i = 0; i < elementCount; i++)
                result.SetValue(DeserializeValue(reader, context, null, elementType), i);
            return result;
        }

        /// <summary>
        /// Deserializes a null-terminated ASCII string.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="valueInfo">The value information.</param>
        /// <returns>The deserialized string.</returns>
        private static string DeserializeString(BinaryReader reader, TagFieldAttribute valueInfo)
        {
            if (valueInfo == null || valueInfo.Length == 0)
                throw new ArgumentException("Cannot deserialize a string with no length set");

            // Keep reading until a null terminator is found
            var result = new StringBuilder();
            var startPos = reader.BaseStream.Position;
            while (true)
            {
                var ch = reader.ReadByte();
                if (ch == 0)
                    break;
                result.Append((char)ch);
            }
            reader.BaseStream.Position = startPos + valueInfo.Length;
            return result.ToString();
        }

        /// <summary>
        /// Deserializes a <see cref="Range{T}"/> value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The serialization context to use.</param>
        /// <param name="rangeType">The range's type.</param>
        /// <returns>The deserialized range.</returns>
        private object DeserializeRange(BinaryReader reader, ISerializationContext context, Type rangeType)
        {
            var boundsType = rangeType.GenericTypeArguments[0];
            var min = DeserializeValue(reader, context, null, boundsType);
            var max = DeserializeValue(reader, context, null, boundsType);
            return Activator.CreateInstance(rangeType, min, max);
        }
    }
}
