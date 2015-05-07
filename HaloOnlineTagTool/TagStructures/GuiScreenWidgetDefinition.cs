using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "scn3", Size = 0xA8)]
	public class GuiScreenWidgetDefinition
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public int Unknown4 { get; set; }
		[TagElement]
		public int Unknown8 { get; set; }
		[TagElement]
		public int UnknownC { get; set; }
		[TagElement]
		public int Unknown10 { get; set; }
		[TagElement]
		public int Unknown14 { get; set; }
		[TagElement]
		public int Unknown18 { get; set; }
		[TagElement]
		public HaloTag Unknown1C { get; set; }
		[TagElement]
		public HaloTag Unknown2C { get; set; }
		[TagElement]
		public HaloTag Unknown3C { get; set; }
		[TagElement]
		public int Unknown4C { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown50 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown5C { get; set; }
		[TagElement]
		public List<TagBlock8> Unknown68 { get; set; }
		[TagElement]
		public int Unknown74 { get; set; }
		[TagElement]
		public int Unknown78 { get; set; }
		[TagElement]
		public int Unknown7C { get; set; }
		[TagElement]
		public int Unknown80 { get; set; }
		[TagElement]
		public int Unknown84 { get; set; }
		[TagElement]
		public int Unknown88 { get; set; }
		[TagElement]
		public int Unknown8C { get; set; }
		[TagElement]
		public int Unknown90 { get; set; }
		[TagElement]
		public int Unknown94 { get; set; }
		[TagElement]
		public int Unknown98 { get; set; }
		[TagElement]
		public int Unknown9C { get; set; }
		[TagElement]
		public int UnknownA0 { get; set; }
		[TagElement]
		public int UnknownA4 { get; set; }

		[TagStructure(Size = 0x10)]
		public class TagBlock0
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x6C)]
		public class TagBlock1
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
			[TagElement]
			public int Unknown14 { get; set; }
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public int Unknown20 { get; set; }
			[TagElement]
			public int Unknown24 { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public HaloTag Unknown2C { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown3C { get; set; }
			[TagElement]
			public List<TagBlock4> Unknown48 { get; set; }
			[TagElement]
			public List<TagBlock5> Unknown54 { get; set; }
			[TagElement]
			public List<TagBlock6> Unknown60 { get; set; }

			[TagStructure(Size = 0x80)]
			public class TagBlock2
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public HaloTag Unknown2C { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public HaloTag Unknown40 { get; set; }
				[TagElement]
				public int Unknown50 { get; set; }
				[TagElement]
				public List<TagBlock3> Unknown54 { get; set; }
				[TagElement]
				public HaloTag Unknown60 { get; set; }
				[TagElement]
				public HaloTag Unknown70 { get; set; }

				[TagStructure(Size = 0x30)]
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
					[TagElement]
					public int Unknown10 { get; set; }
					[TagElement]
					public int Unknown14 { get; set; }
					[TagElement]
					public int Unknown18 { get; set; }
					[TagElement]
					public HaloTag Unknown1C { get; set; }
					[TagElement]
					public int Unknown2C { get; set; }
				}
			}

			[TagStructure(Size = 0x4C)]
			public class TagBlock4
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public HaloTag Unknown2C { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public int Unknown40 { get; set; }
				[TagElement]
				public int Unknown44 { get; set; }
				[TagElement]
				public int Unknown48 { get; set; }
			}

			[TagStructure(Size = 0x6C)]
			public class TagBlock5
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public HaloTag Unknown2C { get; set; }
				[TagElement]
				public HaloTag Unknown3C { get; set; }
				[TagElement]
				public int Unknown4C { get; set; }
				[TagElement]
				public int Unknown50 { get; set; }
				[TagElement]
				public int Unknown54 { get; set; }
				[TagElement]
				public int Unknown58 { get; set; }
				[TagElement]
				public int Unknown5C { get; set; }
				[TagElement]
				public int Unknown60 { get; set; }
				[TagElement]
				public int Unknown64 { get; set; }
				[TagElement]
				public int Unknown68 { get; set; }
			}

			[TagStructure(Size = 0x94)]
			public class TagBlock6
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public HaloTag Unknown2C { get; set; }
				[TagElement]
				public List<TagBlock7> Unknown3C { get; set; }
				[TagElement]
				public int Unknown48 { get; set; }
				[TagElement]
				public int Unknown4C { get; set; }
				[TagElement]
				public int Unknown50 { get; set; }
				[TagElement]
				public int Unknown54 { get; set; }
				[TagElement]
				public int Unknown58 { get; set; }
				[TagElement]
				public int Unknown5C { get; set; }
				[TagElement]
				public int Unknown60 { get; set; }
				[TagElement]
				public int Unknown64 { get; set; }
				[TagElement]
				public int Unknown68 { get; set; }
				[TagElement]
				public int Unknown6C { get; set; }
				[TagElement]
				public int Unknown70 { get; set; }
				[TagElement]
				public int Unknown74 { get; set; }
				[TagElement]
				public int Unknown78 { get; set; }
				[TagElement]
				public int Unknown7C { get; set; }
				[TagElement]
				public int Unknown80 { get; set; }
				[TagElement]
				public int Unknown84 { get; set; }
				[TagElement]
				public int Unknown88 { get; set; }
				[TagElement]
				public int Unknown8C { get; set; }
				[TagElement]
				public int Unknown90 { get; set; }

				[TagStructure(Size = 0xA0)]
				public class TagBlock7
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public int Unknown4 { get; set; }
					[TagElement]
					public int Unknown8 { get; set; }
					[TagElement]
					public int UnknownC { get; set; }
					[TagElement]
					public int Unknown10 { get; set; }
					[TagElement]
					public int Unknown14 { get; set; }
					[TagElement]
					public int Unknown18 { get; set; }
					[TagElement]
					public int Unknown1C { get; set; }
					[TagElement]
					public int Unknown20 { get; set; }
					[TagElement]
					public int Unknown24 { get; set; }
					[TagElement]
					public int Unknown28 { get; set; }
					[TagElement]
					public int Unknown2C { get; set; }
					[TagElement]
					public int Unknown30 { get; set; }
					[TagElement]
					public int Unknown34 { get; set; }
					[TagElement]
					public int Unknown38 { get; set; }
					[TagElement]
					public int Unknown3C { get; set; }
					[TagElement]
					public int Unknown40 { get; set; }
					[TagElement]
					public int Unknown44 { get; set; }
					[TagElement]
					public int Unknown48 { get; set; }
					[TagElement]
					public int Unknown4C { get; set; }
					[TagElement]
					public int Unknown50 { get; set; }
					[TagElement]
					public int Unknown54 { get; set; }
					[TagElement]
					public int Unknown58 { get; set; }
					[TagElement]
					public int Unknown5C { get; set; }
					[TagElement]
					public int Unknown60 { get; set; }
					[TagElement]
					public int Unknown64 { get; set; }
					[TagElement]
					public int Unknown68 { get; set; }
					[TagElement]
					public int Unknown6C { get; set; }
					[TagElement]
					public int Unknown70 { get; set; }
					[TagElement]
					public int Unknown74 { get; set; }
					[TagElement]
					public int Unknown78 { get; set; }
					[TagElement]
					public int Unknown7C { get; set; }
					[TagElement]
					public int Unknown80 { get; set; }
					[TagElement]
					public int Unknown84 { get; set; }
					[TagElement]
					public int Unknown88 { get; set; }
					[TagElement]
					public int Unknown8C { get; set; }
					[TagElement]
					public int Unknown90 { get; set; }
					[TagElement]
					public int Unknown94 { get; set; }
					[TagElement]
					public int Unknown98 { get; set; }
					[TagElement]
					public int Unknown9C { get; set; }
				}
			}
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock8
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
		}
	}
}
