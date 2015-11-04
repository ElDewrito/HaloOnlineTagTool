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
	[TagStructure(Class = "arms", Size = 0x10)]
	public class ArmorSounds
	{
		public List<UnknownBlock> Unknown;
		public float Unknown2;

		[TagStructure(Size = 0x24)]
		public class UnknownBlock
		{
			public List<UnknownBlock2> Unknown;
			public List<UnknownBlock3> Unknown2;
			public List<UnknownBlock4> Unknown3;

			[TagStructure(Size = 0x10)]
			public class UnknownBlock2
			{
				public HaloTag Unknown;
			}

			[TagStructure(Size = 0x10)]
			public class UnknownBlock3
			{
				public HaloTag Unknown;
			}

			[TagStructure(Size = 0x10)]
			public class UnknownBlock4
			{
				public HaloTag Unknown;
			}
		}
	}
}
