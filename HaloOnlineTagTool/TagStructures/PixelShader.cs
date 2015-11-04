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
	[TagStructure(Class = "pixl", Size = 0x20)]
	public class PixelShader
	{
		public float Unknown;
		public List<UnknownBlock> Unknown2;
		public float Unknown3;
		public List<PixelShader2> PixelShaders;

		[TagStructure(Size = 0x2)]
		public class UnknownBlock
		{
			public short Unknown;
		}

		[TagStructure(Size = 0x50)]
		public class PixelShader2
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
			public uint PixelShader;

			[TagStructure(Size = 0x8)]
			public class UnknownBlock
			{
				public StringId Unknown;
				public float Unknown2;
			}
		}
	}
}
