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
	[TagStructure(Class = "glvs", Size = 0x1C)]
	public class GlobalVertexShader
	{
		public List<UnknownBlock> Unknown;
		public uint Unknown2;
		public List<UnknownBlock2> Unknown3;

		[TagStructure(Size = 0xC)]
		public class UnknownBlock
		{
			public List<UnknownBlock2> Unknown;

			[TagStructure(Size = 0x10)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
			}
		}

		[TagStructure(Size = 0x50)]
		public class UnknownBlock2
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public byte[] Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public List<UnknownBlock> Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;

			[TagStructure(Size = 0x8)]
			public class UnknownBlock
			{
				public uint Unknown;
				public uint Unknown2;
			}
		}
	}
}
