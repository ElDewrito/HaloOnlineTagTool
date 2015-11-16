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
		public List<ArmorSound> ArmorSounds2;
		public uint Unknown;

		[TagStructure(Size = 0x24)]
		public class ArmorSound
		{
			public List<UnknownBlock> Unknown;
			public List<UnknownBlock2> Unknown2;
			public List<UnknownBlock3> Unknown3;

			[TagStructure(Size = 0x10)]
			public class UnknownBlock
			{
				public HaloTag Unknown;
			}

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
		}
	}
}
