using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
    /// <summary>
    /// Contains tag data and a description of it.
    /// </summary>
    public class TagData
    {
        /// <summary>
        /// Gets or sets the tag data's group.
        /// </summary>
        public TagGroup Group { get; set; } = TagGroup.Null;

        /// <summary>
        /// Gets or sets the offset of the main structure in the tag data.
        /// </summary>
        public uint MainStructOffset { get; set; }

        /// <summary>
        /// Gets the indices of tags that the tag data depends on.
        /// </summary>
        public HashSet<int> Dependencies { get; } = new HashSet<int>();

        /// <summary>
        /// Gets a list of fixups for pointers in the tag data.
        /// </summary>
        public List<TagPointerFixup> PointerFixups { get; } = new List<TagPointerFixup>();

        /// <summary>
        /// Gets a list of offsets to each resource pointer in the tag data.
        /// </summary>
        public List<uint> ResourcePointerOffsets { get; } = new List<uint>();

        /// <summary>
        /// Gets or sets the serialized tag data.
        /// </summary>
        public byte[] Data { get; set; }
    }

    /// <summary>
    /// Contains information about a pointer in tag data that needs to be adjusted.
    /// </summary>
    public class TagPointerFixup
    {
        /// <summary>
        /// Gets or sets the offset (from the start of the tag's data) of the pointer.
        /// </summary>
        public uint WriteOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset (from the start of the tag's data) that the pointer should point to.
        /// </summary>
        public uint TargetOffset { get; set; }
    }
}
