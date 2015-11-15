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
	[TagStructure(Class = "rasg", Size = 0xBC)]
	public class RasterizerGlobals
	{
		public List<UnknownBlock> Unknown;
		public List<UnknownBlock2> Unknown2;
		public HaloTag Unknown3;
		public HaloTag Unknown4;
		public List<UnknownBlock3> Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public uint Unknown10;
		public HaloTag Unknown11;
		public HaloTag Unknown12;
		public HaloTag Unknown13;
		public HaloTag Unknown14;
		public uint Unknown15;
		public uint Unknown16;
		public uint Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public uint Unknown20;
		public uint Unknown21;
		public uint Unknown22;
		public uint Unknown23;

		[TagStructure(Size = 0x14)]
		public class UnknownBlock
		{
			public uint Unknown;
			public HaloTag Unknown2;
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock2
		{
			public HaloTag Unknown;
		}

		[TagStructure(Size = 0x20)]
		public class UnknownBlock3
		{
			public HaloTag Unknown;
			public HaloTag Unknown2;
		}
	}
}
