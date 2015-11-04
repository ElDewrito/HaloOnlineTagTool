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
	[TagStructure(Class = "trdf", Size = 0x48)]
	public class TextureRenderList
	{
		public List<UnknownBlock> Unknown;
		public List<UnknownBlock2> Unknown2;
		public List<UnknownBlock3> Unknown3;
		public List<UnknownBlock4> Unknown4;
		public List<UnknownBlock5> Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;

		[TagStructure(Size = 0x110)]
		public class UnknownBlock
		{
			public int Unknown;
			public string String;
			public float Unknown2;
			public int Unknown3;
			public int Unknown4;
		}

		[TagStructure(Size = 0x1C)]
		public class UnknownBlock2
		{
			public List<UnknownBlock> Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;

			[TagStructure(Size = 0x28)]
			public class UnknownBlock
			{
				public float Unknown;
				public float Unknown2;
				public float Unknown3;
				public Angle Unknown4;
				public Angle Unknown5;
				public float Unknown6;
				public HaloTag Unknown7;
			}
		}

		[TagStructure(Size = 0x30)]
		public class UnknownBlock3
		{
			public string String;
			public HaloTag Unknown;
		}

		[TagStructure(Size = 0x4C)]
		public class UnknownBlock4
		{
			public float Unknown;
			public HaloTag Unknown2;
			public float Unknown3;
			public float Unknown4;
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
		}

		[TagStructure(Size = 0x64)]
		public class UnknownBlock5
		{
			public string String;
			public HaloTag Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
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
		}
	}
}
