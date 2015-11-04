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
		public float Unknown;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public HaloTag Unknown10;
		public float Unknown11;
		public float Unknown12;
		public float Unknown13;
		public float Unknown14;
		public List<UnknownBlock> Unknown15;
		public float Unknown16;
		public List<UnknownBlock2> Unknown17;
		public List<UnknownBlock3> Unknown18;
		public float Unknown19;
		public float Unknown20;
		public float Unknown21;
		public List<UnknownBlock4> Unknown22;
		public List<UnknownBlock5> Unknown23;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;

		[TagStructure(Size = 0x8C)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public HaloTag Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public byte[] Unknown8;
			public byte[] Unknown9;
			public byte[] Unknown10;
			public byte[] Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
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
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public byte[] Unknown5;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock5
		{
			public byte[] Unknown;
		}
	}
}
