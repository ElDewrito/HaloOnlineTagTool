using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "sddt", Size = 0x44)]
	public class StructureDesign
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown4 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown10 { get; set; }
		[TagElement]
		public List<TagBlock4> Unknown1C { get; set; }
		[TagElement]
		public List<TagBlock6> Unknown28 { get; set; }
		[TagElement]
		public List<TagBlock7> Unknown34 { get; set; }
		[TagElement]
		public int Unknown40 { get; set; }

		[TagStructure(Size = 0x40)]
		public class TagBlock0
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
			public List<TagBlock1> Unknown30 { get; set; }
			[TagElement]
			public int Unknown3C { get; set; }

			[TagStructure(Size = 0x1)]
			public class TagBlock1
			{
				[TagElement]
				public byte Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock2
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown8 { get; set; }

			[TagStructure(Size = 0x44)]
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
		}

		[TagStructure(Size = 0x40)]
		public class TagBlock4
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
			public List<TagBlock5> Unknown30 { get; set; }
			[TagElement]
			public int Unknown3C { get; set; }

			[TagStructure(Size = 0x1)]
			public class TagBlock5
			{
				[TagElement]
				public byte Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock6
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x2C)]
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
			public List<TagBlock8> Unknown14 { get; set; }
			[TagElement]
			public List<TagBlock9> Unknown20 { get; set; }

			[TagStructure(Size = 0x10)]
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
			}

			[TagStructure(Size = 0x24)]
			public class TagBlock9
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
			}
		}
	}
}
