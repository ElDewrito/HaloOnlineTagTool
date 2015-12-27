using System;

namespace HaloOnlineTagTool.Resources
{
    /// <summary>
    /// An address pointing to data in either a resource or its info buffer.
    /// </summary>
    public struct ResourceAddress : IComparable<ResourceAddress>
    {
        private const int TypeShift = 29;
        private const uint OffsetMask = (0xFFFFFFF >> (32 - TypeShift));

        public ResourceAddress(uint value)
        {
            Value = value;
        }

        public ResourceAddress(ResourceAddressType type, int offset)
        {
            Value = (((uint)type) << TypeShift) | ((uint)offset & OffsetMask);
        }

        /// <summary>
        /// Gets the address's type.
        /// </summary>
        public ResourceAddressType Type
        {
            get { return (ResourceAddressType)(Value >> TypeShift); }
        }

        /// <summary>
        /// Gets the address's offset.
        /// </summary>
        public int Offset
        {
            get { return (int)(Value & OffsetMask); }
        }

        /// <summary>
        /// Gets the address's raw value.
        /// </summary>
        public readonly uint Value;

        public override bool Equals(object obj)
        {
            if (!(obj is ResourceAddress))
                return false;
            var other = (ResourceAddress)obj;
            return (Value == other.Value);
        }

        public static bool operator ==(ResourceAddress a, ResourceAddress b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ResourceAddress a, ResourceAddress b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public int CompareTo(ResourceAddress other)
        {
            return (int)(Value - other.Value);
        }
    }

    /// <summary>
    /// Resource address types.
    /// </summary>
    public enum ResourceAddressType
    {
        /// <summary>
        /// The address is a memory address.
        /// </summary>
        /// <remarks>
        /// This will never actually be used by anything,
        /// but seems to be supported by the resource loading code in the EXE,
        /// so I'm putting this here for completeness sake.
        /// </remarks>
        Memory,

        /// <summary>
        /// The address points to a location in the resource definition data.
        /// </summary>
        Definition,

        /// <summary>
        /// The address points to a location in the raw resource data.
        /// </summary>
        Resource
    }
}
