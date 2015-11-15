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
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public HaloTag Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public uint Unknown10;
		public uint Unknown11;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public uint Unknown16;
		public uint Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public uint Unknown20;
		public uint Unknown21;
		public uint Unknown22;
		public List<UnknownBlock> Unknown23;
		public List<UnknownBlock2> Unknown24;
		public uint Unknown25;
		public uint Unknown26;
		public uint Unknown27;
		public List<UnknownBlock3> Unknown28;

		[TagStructure(Size = 0x14)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
		}

		[TagStructure(Size = 0x2)]
		public class UnknownBlock2
		{
			public short Unknown;
		}

		[TagStructure(Size = 0x8)]
		public class UnknownBlock3
		{
			public uint Unknown;
			public uint Unknown2;
		}
	}
}
