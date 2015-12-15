using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Layouts
{
    /// <summary>
    /// Base class for a field in a tag layout.
    /// </summary>
    public abstract class TagLayoutField
    {
        protected TagLayoutField(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the power of two to align the field's data on.
        /// Only applicable to fields which contain pointers.
        /// Can be 0 if not set.
        /// </summary>
        public uint DataAlign { get; set; }

        public abstract void Accept(ITagLayoutFieldVisitor visitor);
    }
}
