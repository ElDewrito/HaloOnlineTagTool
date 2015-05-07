using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "coll", Size = 0x44)]
	public class CollisionModel
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
		public List<TagBlock0> Unknown14 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown20 { get; set; }
		[TagElement]
		public List<TagBlock15> Unknown2C { get; set; }
		[TagElement]
		public List<TagBlock16> Unknown38 { get; set; }

		[TagStructure(Size = 0x4)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock1
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown4 { get; set; }

			[TagStructure(Size = 0x28)]
			public class TagBlock2
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public List<TagBlock3> Unknown4 { get; set; }
				[TagElement]
				public List<TagBlock12> Unknown10 { get; set; }
				[TagElement]
				public List<TagBlock13> Unknown1C { get; set; }

				[TagStructure(Size = 0x64)]
				public class TagBlock3
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public List<TagBlock4> Unknown4 { get; set; }
					[TagElement]
					public List<TagBlock5> Unknown10 { get; set; }
					[TagElement]
					public List<TagBlock6> Unknown1C { get; set; }
					[TagElement]
					public List<TagBlock7> Unknown28 { get; set; }
					[TagElement]
					public List<TagBlock8> Unknown34 { get; set; }
					[TagElement]
					public List<TagBlock9> Unknown40 { get; set; }
					[TagElement]
					public List<TagBlock10> Unknown4C { get; set; }
					[TagElement]
					public List<TagBlock11> Unknown58 { get; set; }

					[TagStructure(Size = 0x8)]
					public class TagBlock4
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
					}

					[TagStructure(Size = 0x10)]
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
					}

					[TagStructure(Size = 0x8)]
					public class TagBlock6
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
					}

					[TagStructure(Size = 0x4)]
					public class TagBlock7
					{
						[TagElement]
						public int Unknown0 { get; set; }
					}

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

					[TagStructure(Size = 0xC)]
					public class TagBlock9
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
						[TagElement]
						public int Unknown8 { get; set; }
					}

					[TagStructure(Size = 0xC)]
					public class TagBlock10
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
						[TagElement]
						public int Unknown8 { get; set; }
					}

					[TagStructure(Size = 0x10)]
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
					}
				}

				[TagStructure(Size = 0x80)]
				public class TagBlock12
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
				}

				[TagStructure(Size = 0x40)]
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
					public List<TagBlock14> Unknown30 { get; set; }
					[TagElement]
					public int Unknown3C { get; set; }

					[TagStructure(Size = 0x1)]
					public class TagBlock14
					{
						[TagElement]
						public byte Unknown0 { get; set; }
					}
				}
			}
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock15
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
		}

		[TagStructure(Size = 0xC)]
		public class TagBlock16
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
		}
	}
}
