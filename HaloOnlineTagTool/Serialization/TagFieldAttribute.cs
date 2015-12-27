using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
    /// <summary>
    /// Attribute for automatically-serializable values in a tag.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class TagFieldAttribute : Attribute
    {
        public TagFieldAttribute()
        {
            Offset = -1;
        }

        /// <summary>
        /// Gets or sets the offset of the value from the beginning of the structure.
        /// If this is -1 (default), then the current stream position will be used.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the size of the value in bytes.
        /// If this is 0 (default), then the size will be inferred from the value type.
        /// </summary>
        public uint Size { get; set; }

        /// <summary>
        /// If the value is an inline array, gets or sets the number of elements in the array.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// If the value is a string, gets or sets the maximum number of characters in the string (including the null terminator).
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets flags for the tag element.
        /// </summary>
        public TagFieldFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the power of two to align the field's data to.
        /// Only applicable to fields which contain pointers.
        /// </summary>
        public uint DataAlign { get; set; }
    }

    /// <summary>
    /// Tag element flags.
    /// </summary>
    [Flags]
    public enum TagFieldFlags
    {
        /// <summary>
        /// The tag element is a pointer to a structure.
        /// </summary>
        Indirect = 1 << 0,

        /// <summary>
        /// The tag element is "short" and doesn't have debug info. Currently only valid for tag references.
        /// </summary>
        Short = 1 << 1,
    }
}
