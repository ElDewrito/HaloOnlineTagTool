using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "arms", Size = 0x10)]
	public class ArmorSounds
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }
		[TagElement]
		public int UnknownC { get; set; }

		[TagStructure(Size = 0x24)]
		public class TagBlock0
		{
			[TagElement]
			public List<TagBlock1> Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock2> UnknownC { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown18 { get; set; }

			[TagStructure(Size = 0x10)]
			public class TagBlock1
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x10)]
			public class TagBlock2
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
			}

			[TagStructure(Size = 0x10)]
			public class TagBlock3
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
			}
		}
	}
}
