using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
	public class DataReferenceGuess : ITagElementGuess
	{
		public uint Size
		{
			get { return 0x14; }
		}

		public bool Merge(ITagElementGuess other)
		{
			return (other is DataReferenceGuess);
		}

		public void Accept(uint offset, ITagElementGuessVisitor visitor)
		{
			visitor.Visit(offset, this);
		}
	}
}
