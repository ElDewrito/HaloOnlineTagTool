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
		public List<VertexShader> VertexShaders;

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
		public class VertexShader
		{
			public byte[] Unknown;
			public byte[] Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public List<UnknownBlock> Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint VertexShader2;

			[TagStructure(Size = 0x8)]
			public class UnknownBlock
			{
				public StringId Unknown;
				public uint Unknown2;
			}
		}
	}
}
