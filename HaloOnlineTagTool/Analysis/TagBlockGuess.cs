using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
    public class TagBlockGuess : ITagElementGuess
    {
        public TagBlockGuess(TagLayoutGuess layout)
        {
            if (layout == null)
                throw new ArgumentNullException("layout");
            ElementLayout = layout;
        }

        public uint Size
        {
            get { return 0xC; }
        }

        /// <summary>
        /// Gets the layout of each element in the tag block.
        /// </summary>
        public TagLayoutGuess ElementLayout { get; private set; }

        public bool Merge(ITagElementGuess other)
        {
            var otherBlock = other as TagBlockGuess;
            if (otherBlock == null)
                return false;
            ElementLayout.Merge(otherBlock.ElementLayout);
            return true;
        }

        public void Accept(uint offset, ITagElementGuessVisitor visitor)
        {
            visitor.Visit(offset, this);
        }
    }
}
