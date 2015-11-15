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
	[TagStructure(Class = "rmt2", Size = 0x84)]
	public class RenderMethodTemplate
	{
		public HaloTag VertexShader;
		public HaloTag PixelShader;
		public uint Unknown;
		public List<UnknownBlock> Unknown2;
		public List<UnknownBlock2> Unknown3;
		public List<UnknownBlock3> Unknown4;
		public List<Argument> Arguments;
		public List<UnknownBlock4> Unknown5;
		public List<UnknownBlock5> Unknown6;
		public List<ShaderMap> ShaderMaps;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;

		[TagStructure(Size = 0x2)]
		public class UnknownBlock
		{
			public short Unknown;
		}

		[TagStructure(Size = 0x1C)]
		public class UnknownBlock2
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
		}

		[TagStructure(Size = 0x4)]
		public class UnknownBlock3
		{
			public uint Unknown;
		}

		[TagStructure(Size = 0x4)]
		public class Argument
		{
			public StringId Name;
		}

		[TagStructure(Size = 0x4)]
		public class UnknownBlock4
		{
			public StringId Unknown;
		}

		[TagStructure(Size = 0x4)]
		public class UnknownBlock5
		{
			public StringId Unknown;
		}

		[TagStructure(Size = 0x4)]
		public class ShaderMap
		{
			public StringId Name;
		}
	}
}
