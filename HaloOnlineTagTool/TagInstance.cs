using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
    /// <summary>
    /// Describes a tag in a tag cache.
    /// </summary>
    public class TagInstance
    {
        private HashSet<int> _dependencies = new HashSet<int>();
        private List<uint> _pointerOffsets = new List<uint>();
        private List<uint> _resourceOffsets = new List<uint>();

        // Magic constant (NOT a build-specific memory address) used for pointers in tag data
        private const uint FixupPointerBase = 0x40000000;

        // Size of a tag header with no dependencies or offsets
        private const uint TagHeaderSize = 0x24;

        internal TagInstance(int index)
        {
            Index = index;
        }

        internal TagInstance(int index, TagTypeDescriptor type)
        {
            Index = index;
            if (type != null)
            {
                GroupTag = type.GroupTag;
                ParentGroupTag = type.ParentGroupTag;
                GrandparentGroupTag = type.GrandparentGroupTag;
                GroupName = type.GroupName;
            }
        }

        /// <summary>
        /// Gets the tag's index.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Gets the offset of the tag's header, or -1 if the tag is not in a file.
        /// </summary>
        public long HeaderOffset { get; internal set; } = -1;

        /// <summary>
        /// Gets the total size of the tag (including both its header and data), or -1 if the tag is not in a file.
        /// </summary>
        public long TotalSize { get; internal set; } = -1;

        /// <summary>
        /// Gets the tag's group tag.
        /// </summary>
        public Tag GroupTag { get; private set; }

        /// <summary>
        /// Gets the tag's parent group tag. Can be -1.
        /// </summary>
        public Tag ParentGroupTag { get; private set; }

        /// <summary>
        /// Gets the tag's grandparent group tag. Can be -1.
        /// </summary>
        public Tag GrandparentGroupTag { get; private set; }

        /// <summary>
        /// Gets the stringID for the tag's group.
        /// </summary>
        public StringId GroupName { get; private set; }

        /// <summary>
        /// Gets the offset of the tag's main structure from the start of its header.
        /// </summary>
        public uint MainStructOffset { get; private set; }

        /// <summary>
        /// Gets the checksum (adler32?) of the tag's data. Ignored if checksum verification is patched out.
        /// </summary>
        public uint Checksum { get; private set; }

        /// <summary>
        /// Gets the indices of tags that this tag depends on.
        /// </summary>
        public IReadOnlyCollection<int> Dependencies => _dependencies;

        /// <summary>
        /// Gets a list of offsets to each pointer in the tag, relative to the beginning of the tag's header.
        /// </summary>
        /// <remarks>
        /// This previously used offsets relative to the beginning of the tag's data.
        /// This was changed in order to speed up loading and be more closer to the engine.
        /// </remarks>
        public IReadOnlyList<uint> PointerOffsets => _pointerOffsets;

        /// <summary>
        /// Gets a list of offsets to each resource pointer in the tag, relative to the beginning of the tag's header.
        /// </summary>
        /// <remarks>
        /// See the remarks for <see cref="PointerOffsets"/>.
        /// </remarks>
        public IReadOnlyList<uint> ResourcePointerOffsets => _resourceOffsets;

        /// <summary>
        /// Determines whether the tag belongs to a tag group.
        /// </summary>
        /// <param name="groupTag">The group tag.</param>
        /// <returns><c>true</c> if the tag belongs to the group.</returns>
        public bool IsInGroup(Tag groupTag)
        {
            if (groupTag.Value == -1)
                return false;
            return (GroupTag == groupTag || ParentGroupTag == groupTag || GrandparentGroupTag == groupTag);
        }

        /// <summary>
        /// Determines whether the tag belongs to a tag group.
        /// </summary>
        /// <param name="groupTag">A 4-character string representing the group tag, e.g. "scnr".</param>
        /// <returns><c>true</c> if the tag belongs to the group.</returns>
        public bool IsInGroup(string groupTag)
        {
            return IsInGroup(new Tag(groupTag));
        }

        /// <summary>
        /// Converts a pointer to an offset relative to the tag's header.
        /// </summary>
        /// <param name="pointer">The pointer to convert.</param>
        /// <returns>The offset.</returns>
        public uint PointerToOffset(uint pointer) => pointer - FixupPointerBase;

        /// <summary>
        /// Converts an offset relative to the tag's header to a pointer.
        /// </summary>
        /// <param name="offset">The offset to convert.</param>
        /// <returns>The pointer.</returns>
        public uint OffsetToPointer(uint offset) => offset + FixupPointerBase;

        /// <summary>
        /// Gets a type descriptor for the tag.
        /// </summary>
        /// <returns>A type descriptor for the tag.</returns>
        public TagTypeDescriptor GetTypeDescriptor()
        {
            return new TagTypeDescriptor
            {
                GroupTag = GroupTag,
                ParentGroupTag = ParentGroupTag,
                GrandparentGroupTag = GrandparentGroupTag,
                GroupName = GroupName,
            };
        }

        public override string ToString() => $"0x{Index:X8}";

        /// <summary>
        /// Reads the header for the tag instance from a stream.
        /// </summary>
        /// <param name="reader">The stream to read from.</param>
        internal void ReadHeader(BinaryReader reader)
        {
            Checksum = reader.ReadUInt32();                    // 0x00 uint32 checksum
            TotalSize = reader.ReadUInt32();                   // 0x04 uint32 total size
            var numDependencies = reader.ReadInt16();          // 0x08 int16  dependencies count
            var numDataFixups = reader.ReadInt16();            // 0x0A int16  data fixup count
            var numResourceFixups = reader.ReadInt16();        // 0x0C int16  resource fixup count
            reader.BaseStream.Position += 2;                   // 0x0E int16  (padding)
            MainStructOffset = reader.ReadUInt32();            // 0x10 uint32 main struct offset
            GroupTag = new Tag(reader.ReadInt32());            // 0x14 int32  group tag
            ParentGroupTag = new Tag(reader.ReadInt32());      // 0x18 int32  parent group tag
            GrandparentGroupTag = new Tag(reader.ReadInt32()); // 0x1C int32  grandparent group tag
            GroupName = new StringId(reader.ReadUInt32());     // 0x20 uint32 group name stringid

            // Read dependencies
            _dependencies = new HashSet<int>();
            for (var j = 0; j < numDependencies; j++)
                _dependencies.Add(reader.ReadInt32());

            // Read offsets
            _pointerOffsets = new List<uint>(numDataFixups);
            for (var j = 0; j < numDataFixups; j++)
                _pointerOffsets.Add(PointerToOffset(reader.ReadUInt32()));
            _resourceOffsets = new List<uint>(numResourceFixups);
            for (var j = 0; j < numResourceFixups; j++)
                _resourceOffsets.Add(PointerToOffset(reader.ReadUInt32()));
        }

        /// <summary>
        /// Writes the header for the tag instance to a stream.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        internal void WriteHeader(BinaryWriter writer)
        {
            writer.Write(Checksum);
            writer.Write((uint)TotalSize);
            writer.Write((short)Dependencies.Count);
            writer.Write((short)PointerOffsets.Count);
            writer.Write((short)ResourcePointerOffsets.Count);
            writer.Write((short)0);
            writer.Write(MainStructOffset);
            writer.Write(GroupTag.Value);
            writer.Write(ParentGroupTag.Value);
            writer.Write(GrandparentGroupTag.Value);
            writer.Write(GroupName.Value);

            // Write dependencies
            foreach (var dependency in _dependencies)
                writer.Write(dependency);

            // Write offsets
            foreach (var offset in _pointerOffsets.Concat(_resourceOffsets))
                writer.Write(OffsetToPointer(offset));
        }

        /// <summary>
        /// Calculates the header size that would be needed for a given block of tag data.
        /// </summary>
        /// <param name="data">The descriptor to use.</param>
        /// <returns>The size of the tag's header.</returns>
        internal static uint CalculateHeaderSize(TagData data) =>
            (uint)(TagHeaderSize + data.Dependencies.Count * 4 + data.PointerFixups.Count * 4 + data.ResourcePointerOffsets.Count * 4);

        /// <summary>
        /// Updates the tag instance's state from a block of tag data.
        /// </summary>
        /// <param name="data">The tag data.</param>
        /// <param name="dataOffset">The offset of the tag data relative to the tag instance's header.</param>
        internal void Update(TagData data, uint dataOffset)
        {
            GroupTag = data.Type.GroupTag;
            ParentGroupTag = data.Type.ParentGroupTag;
            GrandparentGroupTag = data.Type.GrandparentGroupTag;
            GroupName = data.Type.GroupName;
            MainStructOffset = data.MainStructOffset + dataOffset;
            _dependencies = new HashSet<int>(data.Dependencies);
            _pointerOffsets = data.PointerFixups.Select(fixup => fixup.WriteOffset + dataOffset).ToList();
            _resourceOffsets = data.ResourcePointerOffsets.Select(offset => offset + dataOffset).ToList();
        }
    }
}
