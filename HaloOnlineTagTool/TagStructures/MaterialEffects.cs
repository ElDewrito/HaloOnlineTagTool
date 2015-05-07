using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "foot", Size = 0xC)]
	public class MaterialEffects
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }

		[TagStructure(Size = 0x24)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
			[TagElement]
			public List<TagBlock1> UnknownC { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown18 { get; set; }

			[TagStructure(Size = 0x2C)]
			public class TagBlock1
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown10 { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
			}

			[TagStructure(Size = 0x2C)]
			public class TagBlock2
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown10 { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
			}
		}
	}
}
