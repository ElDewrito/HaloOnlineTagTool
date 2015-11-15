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
	[TagStructure(Class = "lens", Size = 0x9C)]
	public class LensFlare
	{
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public HaloTag Unknown10;
		public uint Unknown11;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public List<UnknownBlock> Unknown15;
		public uint Unknown16;
		public List<UnknownBlock2> Unknown17;
		public List<UnknownBlock3> Unknown18;
		public uint Unknown19;
		public uint Unknown20;
		public uint Unknown21;
		public List<UnknownBlock4> Unknown22;
		public List<UnknownBlock5> Unknown23;
		public uint Unknown24;
		public uint Unknown25;
		public uint Unknown26;

		[TagStructure(Size = 0x8C)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public HaloTag Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public byte[] Unknown8;
			public byte[] Unknown9;
			public byte[] Unknown10;
			public byte[] Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock2
		{
			public byte[] Unknown;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock3
		{
			public byte[] Unknown;
		}

		[TagStructure(Size = 0x24)]
		public class UnknownBlock4
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public byte[] Unknown5;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock5
		{
			public byte[] Unknown;
		}
	}
}
