using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "clwd", Size = 0x94)]
	public class Cloth
	{
		public float Unknown;
		public float Unknown2;
		public float Unknown3;
		public HaloTag Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		public float Unknown11;
		public float Unknown12;
		public float Unknown13;
		public float Unknown14;
		public float Unknown15;
		public float Unknown16;
		public float Unknown17;
		public float Unknown18;
		public float Unknown19;
		public float Unknown20;
		public float Unknown21;
		public float Unknown22;
		public List<UnknownBlock> Unknown23;
		public List<UnknownBlock2> Unknown24;
		public float Unknown25;
		public float Unknown26;
		public float Unknown27;
		public List<UnknownBlock3> Unknown28;

		[TagStructure(Size = 0x14)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
		}

		[TagStructure(Size = 0x2)]
		public class UnknownBlock2
		{
			public short Unknown;
		}

		[TagStructure(Size = 0x8)]
		public class UnknownBlock3
		{
			public float Unknown;
			public float Unknown2;
		}
	}
}
