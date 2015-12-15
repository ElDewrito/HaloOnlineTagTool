using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
    public class ResourceReferenceGuess : ITagElementGuess
    {
        public uint Size
        {
            get { return 0x4; }
        }

        public bool Merge(ITagElementGuess other)
        {
            return (other is ResourceReferenceGuess);
        }

        public void Accept(uint offset, ITagElementGuessVisitor visitor)
        {
            visitor.Visit(offset, this);
        }
    }
}
