using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
    public class TagReferenceGuess : ITagElementGuess
    {
        public uint Size
        {
            get { return 0x10; }
        }

        public bool Merge(ITagElementGuess other)
        {
            return (other is TagReferenceGuess);
        }

        public void Accept(uint offset, ITagElementGuessVisitor visitor)
        {
            visitor.Visit(offset, this);
        }
    }
}
