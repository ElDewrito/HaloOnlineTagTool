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
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		public HaloTag Unknown11;
		public HaloTag Unknown12;
		public HaloTag Unknown13;
		public HaloTag Unknown14;
		public float Unknown15;
		public float Unknown16;
		public float Unknown17;
		public float Unknown18;
		public float Unknown19;
		public float Unknown20;
		public float Unknown21;
		public float Unknown22;
		public float Unknown23;

		[TagStructure(Size = 0x14)]
		public class UnknownBlock
		{
			public float Unknown;
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
