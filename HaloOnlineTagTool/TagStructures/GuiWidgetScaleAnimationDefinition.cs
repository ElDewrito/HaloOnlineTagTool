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
	[TagStructure(Class = "wscl", Size = 0x24)]
	public class GuiWidgetScaleAnimationDefinition
	{
		public float Unknown;
		public List<UnknownBlock> Unknown2;
		public byte[] Unknown3;

		[TagStructure(Size = 0x24)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
		}
	}
}
