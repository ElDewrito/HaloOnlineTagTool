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
	[TagStructure(Class = "wpos", Size = 0x24)]
	public class GuiWidgetPositionAnimationDefinition
	{
		public uint Unknown;
		public List<UnknownBlock> Unknown2;
		public byte[] Unknown3;

		[TagStructure(Size = 0x1C)]
		public class UnknownBlock
		{
			public uint Unknown;
			public float KeyframeX;
			public float KeyframeY;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
		}
	}
}
