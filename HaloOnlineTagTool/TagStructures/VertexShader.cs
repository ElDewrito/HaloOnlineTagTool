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
	[TagStructure(Class = "vtsh", Size = 0x20)]
	public class VertexShader
	{
		public float Unknown;
		public List<UnknownBlock> Unknown2;
		public float Unknown3;
		public List<VertexShader2> VertexShaders;

		[TagStructure(Size = 0xC)]
		public class UnknownBlock
		{
			public List<UnknownBlock2> Unknown;

			[TagStructure(Size = 0x2)]
			public class UnknownBlock2
			{
				public short Unknown;
			}
		}

		[TagStructure(Size = 0x50)]
		public class VertexShader2
		{
			public byte[] Unknown;
			public byte[] Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public List<UnknownBlock> Unknown7;
			public float Unknown8;
			public float Unknown9;
			public uint VertexShader;

			[TagStructure(Size = 0x8)]
			public class UnknownBlock
			{
				public StringId Unknown;
				public float Unknown2;
			}
		}
	}
}
