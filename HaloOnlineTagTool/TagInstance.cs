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
        /// <summary>
        /// Initializes an empty tag description.
        /// </summary>
        public TagInstance()
        {
            Dependencies = new HashSet<int>();
            DataFixups = new List<TagFixup>();
            ResourceFixups = new List<TagFixup>();
            Index = -1;
            HeaderOffset = -1;
            DataOffset = -1;
        }

        /// <summary>
        /// Gets the tag's index, or -1 if it is not in the table.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets or sets the tag's group tag.
        /// </summary>
        public Tag GroupTag { get; set; }

        /// <summary>
        /// Gets or sets the tag's parent group tag. Can be -1.
        /// </summary>
        public Tag ParentGroupTag { get; set; }

        /// <summary>
        /// Gets or sets the tag's grandparent group tag. Can be -1.
        /// </summary>
        public Tag GrandparentGroupTag { get; set; }

        /// <summary>
        /// Gets or sets the stringID for the tag's group.
        /// </summary>
        public StringId GroupName { get; set; }

        /// <summary>
        /// Gets the offset of the tag's header. Can be -1 if the tag is not in a file.
        /// </summary>
        public long HeaderOffset { get; internal set; }

        /// <summary>
        /// Gets the size of the tag's header. Can be 0 if the tag is not in a file.
        /// </summary>
        public long HeaderSize
        {
            get { return (HeaderOffset >= 0 && DataOffset >= 0) ? DataOffset - HeaderOffset : 0; }
        }

        /// <summary>
        /// Gets the total size of the tag, including both its header and data.
        /// </summary>
        public long TotalSize
        {
            get { return HeaderSize + DataSize; }
        }

        /// <summary>
        /// Gets the offset of the tag's data (after the header). Can be -1 if the tag is not in a file.
        /// </summary>
        public long DataOffset { get; internal set; }

        /// <summary>
        /// Gets the size of the tag's data (not including the header).
        /// </summary>
        public long DataSize { get; internal set; }

        /// <summary>
        /// Gets or sets the offset of the tag's main structure from the start of its data.
        /// </summary>
        public uint MainStructOffset { get; set; }

        /// <summary>
        /// Checksum (adler32?) of the tag's data. Ignored if checksum verification is patched out.
        /// </summary>
        public uint Checksum { get; set; }

        /// <summary>
        /// Gets the indices of tags that this tag depends on.
        /// </summary>
        public HashSet<int> Dependencies { get; private set; }

        /// <summary>
        /// Gets the tag's data fixups.
        /// </summary>
        public List<TagFixup> DataFixups { get; private set; }

        /// <summary>
        /// Gets the tag's resource fixups.
        /// </summary>
        public List<TagFixup> ResourceFixups { get; private set; }

        /// <summary>
        /// Determines whether a tag belongs to a tag group.
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
        /// Determines whether a tag belongs to a tag group.
        /// </summary>
        /// <param name="groupTag">A 4-character string representing the group tag, e.g. "scnr".</param>
        /// <returns><c>true</c> if the tag belongs to the group.</returns>
        public bool IsInGroup(string groupTag)
        {
            return IsInGroup(new Tag(groupTag));
        }

        public override string ToString() =>
            $"0x{Index:X8}";
    }

    /// <summary>
    /// Contains information about a fixup that needs to be performed on the tag data.
    /// </summary>
    public class TagFixup
    {
        /// <summary>
        /// Gets or sets the offset of the pointer to adjust from the start of the tag's data.
        /// </summary>
        public uint WriteOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset that the pointer should point to from the start of the tag's data.
        /// </summary>
        public uint TargetOffset { get; set; }
    }
}
