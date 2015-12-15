using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Layouts
{
    /// <summary>
    /// A string field in a tag layout.
    /// </summary>
    public class StringTagLayoutField : TagLayoutField
    {
        public StringTagLayoutField(string name, int size)
            : base(name)
        {
            Size = size;
        }

        /// <summary>
        /// Gets or sets the size of the string buffer in bytes.
        /// </summary>
        public int Size { get; set; }

        public override void Accept(ITagLayoutFieldVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
