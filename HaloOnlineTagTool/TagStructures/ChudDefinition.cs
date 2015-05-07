using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "chdt", Size = 0x18)]
	public class ChudDefinition
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }
		[TagElement]
		public int UnknownC { get; set; }
		[TagElement]
		public int Unknown10 { get; set; }
		[TagElement]
		public int Unknown14 { get; set; }

		[TagStructure(Size = 0x60)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown8 { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown14 { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown20 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
			[TagElement]
			public int Unknown30 { get; set; }
			[TagElement]
			public int Unknown34 { get; set; }
			[TagElement]
			public HaloTag Unknown38 { get; set; }
			[TagElement]
			public List<TagBlock4> Unknown48 { get; set; }
			[TagElement]
			public List<TagBlock9> Unknown54 { get; set; }

			[TagStructure(Size = 0x44)]
			public class TagBlock1
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
			}

			[TagStructure(Size = 0x1C)]
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
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
			}

			[TagStructure(Size = 0x90)]
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
				public HaloTag Unknown4C { get; set; }
				[TagElement]
				public int Unknown5C { get; set; }
				[TagElement]
				public int Unknown60 { get; set; }
				[TagElement]
				public HaloTag Unknown64 { get; set; }
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
			}

			[TagStructure(Size = 0x54)]
			public class TagBlock4
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public List<TagBlock5> Unknown8 { get; set; }
				[TagElement]
				public List<TagBlock6> Unknown14 { get; set; }
				[TagElement]
				public List<TagBlock7> Unknown20 { get; set; }
				[TagElement]
				public List<TagBlock8> Unknown2C { get; set; }
				[TagElement]
				public int Unknown38 { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public HaloTag Unknown40 { get; set; }
				[TagElement]
				public int Unknown50 { get; set; }

				[TagStructure(Size = 0x44)]
				public class TagBlock5
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
				}

				[TagStructure(Size = 0x1C)]
				public class TagBlock6
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
				}

				[TagStructure(Size = 0x90)]
				public class TagBlock7
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public HaloTag Unknown4 { get; set; }
					[TagElement]
					public int Unknown14 { get; set; }
					[TagElement]
					public int Unknown18 { get; set; }
					[TagElement]
					public HaloTag Unknown1C { get; set; }
					[TagElement]
					public int Unknown2C { get; set; }
					[TagElement]
					public int Unknown30 { get; set; }
					[TagElement]
					public HaloTag Unknown34 { get; set; }
					[TagElement]
					public int Unknown44 { get; set; }
					[TagElement]
					public int Unknown48 { get; set; }
					[TagElement]
					public HaloTag Unknown4C { get; set; }
					[TagElement]
					public int Unknown5C { get; set; }
					[TagElement]
					public int Unknown60 { get; set; }
					[TagElement]
					public HaloTag Unknown64 { get; set; }
					[TagElement]
					public int Unknown74 { get; set; }
					[TagElement]
					public int Unknown78 { get; set; }
					[TagElement]
					public HaloTag Unknown7C { get; set; }
					[TagElement]
					public int Unknown8C { get; set; }
				}

				[TagStructure(Size = 0x48)]
				public class TagBlock8
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
				}
			}

			[TagStructure(Size = 0x48)]
			public class TagBlock9
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public List<TagBlock10> Unknown8 { get; set; }
				[TagElement]
				public List<TagBlock11> Unknown14 { get; set; }
				[TagElement]
				public List<TagBlock12> Unknown20 { get; set; }
				[TagElement]
				public List<TagBlock13> Unknown2C { get; set; }
				[TagElement]
				public int Unknown38 { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public int Unknown40 { get; set; }
				[TagElement]
				public int Unknown44 { get; set; }

				[TagStructure(Size = 0x44)]
				public class TagBlock10
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
				}

				[TagStructure(Size = 0x1C)]
				public class TagBlock11
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
				}

				[TagStructure(Size = 0x90)]
				public class TagBlock12
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public HaloTag Unknown4 { get; set; }
					[TagElement]
					public int Unknown14 { get; set; }
					[TagElement]
					public int Unknown18 { get; set; }
					[TagElement]
					public HaloTag Unknown1C { get; set; }
					[TagElement]
					public int Unknown2C { get; set; }
					[TagElement]
					public int Unknown30 { get; set; }
					[TagElement]
					public HaloTag Unknown34 { get; set; }
					[TagElement]
					public int Unknown44 { get; set; }
					[TagElement]
					public int Unknown48 { get; set; }
					[TagElement]
					public HaloTag Unknown4C { get; set; }
					[TagElement]
					public int Unknown5C { get; set; }
					[TagElement]
					public int Unknown60 { get; set; }
					[TagElement]
					public HaloTag Unknown64 { get; set; }
					[TagElement]
					public int Unknown74 { get; set; }
					[TagElement]
					public int Unknown78 { get; set; }
					[TagElement]
					public HaloTag Unknown7C { get; set; }
					[TagElement]
					public int Unknown8C { get; set; }
				}

				[TagStructure(Size = 0x48)]
				public class TagBlock13
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
				}
			}
		}
	}
}
