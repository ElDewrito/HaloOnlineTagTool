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
	[TagStructure(Class = "wrot", Size = 0x2C)]
	public class GuiWidgetRotationAnimationDefinition
	{
		public uint Unknown;
		public List<UnknownBlock> Unknown2;
		public byte[] Unknown3;
		public uint Unknown4;
		public uint Unknown5;

		[TagStructure(Size = 0x20)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
		}
	}
}
