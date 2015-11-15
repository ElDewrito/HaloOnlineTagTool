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
	[TagStructure(Class = "rmop", Size = 0x10)]
	public class RenderMethodOption
	{
		public List<UnknownBlock> Unknown;
		public uint Unknown2;

		[TagStructure(Size = 0x48)]
		public class UnknownBlock
		{
			public StringId Type;
			public uint Unknown;
			public uint Unknown2;
			public HaloTag Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
		}
	}
}
