using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "jmad", Size = 0x104)]
	public class ModelAnimationGraph
	{
		[TagElement]
		public HaloTag Unknown0 { get; set; }
		[TagElement]
		public int Unknown10 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown14 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown20 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown2C { get; set; }
		[TagElement]
		public List<TagBlock3> Unknown38 { get; set; }
		[TagElement]
		public int Unknown44 { get; set; }
		[TagElement]
		public int Unknown48 { get; set; }
		[TagElement]
		public int Unknown4C { get; set; }
		[TagElement]
		public List<TagBlock4> Unknown50 { get; set; }
		[TagElement]
		public List<TagBlock10> Unknown5C { get; set; }
		[TagElement]
		public List<TagBlock26> Unknown68 { get; set; }
		[TagElement]
		public List<TagBlock27> Unknown74 { get; set; }
		[TagElement]
		public List<TagBlock28> Unknown80 { get; set; }
		[TagElement]
		public List<TagBlock31> Unknown8C { get; set; }
		[TagElement]
		public int Unknown98 { get; set; }
		[TagElement]
		public int Unknown9C { get; set; }
		[TagElement]
		public int UnknownA0 { get; set; }
		[TagElement]
		public int UnknownA4 { get; set; }
		[TagElement]
		public int UnknownA8 { get; set; }
		[TagElement]
		public int UnknownAC { get; set; }
		[TagElement]
		public int UnknownB0 { get; set; }
		[TagElement]
		public int UnknownB4 { get; set; }
		[TagElement]
		public int UnknownB8 { get; set; }
		[TagElement]
		public int UnknownBC { get; set; }
		[TagElement]
		public int UnknownC0 { get; set; }
		[TagElement]
		public int UnknownC4 { get; set; }
		[TagElement]
		public int UnknownC8 { get; set; }
		[TagElement]
		public int UnknownCC { get; set; }
		[TagElement]
		public int UnknownD0 { get; set; }
		[TagElement]
		public int UnknownD4 { get; set; }
		[TagElement]
		public int UnknownD8 { get; set; }
		[TagElement]
		public int UnknownDC { get; set; }
		[TagElement]
		public int UnknownE0 { get; set; }
		[TagElement]
		public int UnknownE4 { get; set; }
		[TagElement]
		public int UnknownE8 { get; set; }
		[TagElement]
		public int UnknownEC { get; set; }
		[TagElement]
		public int UnknownF0 { get; set; }
		[TagElement]
		public int UnknownF4 { get; set; }
		[TagElement]
		public List<TagBlock32> UnknownF8 { get; set; }

		[TagStructure(Size = 0x20)]
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
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock1
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock2
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
		}

		[TagStructure(Size = 0x1C)]
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
		}

		[TagStructure(Size = 0x88)]
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
			public List<TagBlock5> Unknown2C { get; set; }
			[TagElement]
			public List<TagBlock6> Unknown38 { get; set; }
			[TagElement]
			public List<TagBlock7> Unknown44 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown50 { get; set; }
			[TagElement]
			public List<TagBlock9> Unknown5C { get; set; }
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

			[TagStructure(Size = 0x4)]
			public class TagBlock5
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x8)]
			public class TagBlock6
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}

			[TagStructure(Size = 0xC)]
			public class TagBlock7
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
			}

			[TagStructure(Size = 0x4)]
			public class TagBlock8
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x1C)]
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
			}
		}

		[TagStructure(Size = 0x28)]
		public class TagBlock10
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock11> Unknown4 { get; set; }
			[TagElement]
			public List<TagBlock25> Unknown10 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public int Unknown20 { get; set; }
			[TagElement]
			public int Unknown24 { get; set; }

			[TagStructure(Size = 0x28)]
			public class TagBlock11
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public List<TagBlock12> Unknown4 { get; set; }
				[TagElement]
				public List<TagBlock20> Unknown10 { get; set; }
				[TagElement]
				public List<TagBlock21> Unknown1C { get; set; }

				[TagStructure(Size = 0x34)]
				public class TagBlock12
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public List<TagBlock13> Unknown4 { get; set; }
					[TagElement]
					public List<TagBlock14> Unknown10 { get; set; }
					[TagElement]
					public List<TagBlock15> Unknown1C { get; set; }
					[TagElement]
					public List<TagBlock18> Unknown28 { get; set; }

					[TagStructure(Size = 0x8)]
					public class TagBlock13
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
					}

					[TagStructure(Size = 0x8)]
					public class TagBlock14
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
					}

					[TagStructure(Size = 0x10)]
					public class TagBlock15
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public List<TagBlock16> Unknown4 { get; set; }

						[TagStructure(Size = 0xC)]
						public class TagBlock16
						{
							[TagElement]
							public List<TagBlock17> Unknown0 { get; set; }

							[TagStructure(Size = 0x4)]
							public class TagBlock17
							{
								[TagElement]
								public int Unknown0 { get; set; }
							}
						}
					}

					[TagStructure(Size = 0x18)]
					public class TagBlock18
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public int Unknown4 { get; set; }
						[TagElement]
						public int Unknown8 { get; set; }
						[TagElement]
						public List<TagBlock19> UnknownC { get; set; }

						[TagStructure(Size = 0x14)]
						public class TagBlock19
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
					}
				}

				[TagStructure(Size = 0x8)]
				public class TagBlock20
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public int Unknown4 { get; set; }
				}

				[TagStructure(Size = 0x10)]
				public class TagBlock21
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public List<TagBlock22> Unknown4 { get; set; }

					[TagStructure(Size = 0x1C)]
					public class TagBlock22
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public List<TagBlock23> Unknown4 { get; set; }
						[TagElement]
						public List<TagBlock24> Unknown10 { get; set; }

						[TagStructure(Size = 0x30)]
						public class TagBlock23
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
						}

						[TagStructure(Size = 0x14)]
						public class TagBlock24
						{
							[TagElement]
							public int Unknown0 { get; set; }
							[TagElement]
							public HaloTag Unknown4 { get; set; }
						}
					}
				}
			}

			[TagStructure(Size = 0x8)]
			public class TagBlock25
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}
		}

		[TagStructure(Size = 0x28)]
		public class TagBlock26
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
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock27
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

		[TagStructure(Size = 0x30)]
		public class TagBlock28
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock29> Unknown10 { get; set; }
			[TagElement]
			public List<TagBlock30> Unknown1C { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }

			[TagStructure(Size = 0x2)]
			public class TagBlock29
			{
				[TagElement]
				public short Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x4)]
			public class TagBlock30
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x8)]
		public class TagBlock31
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
		}

		[TagStructure(Size = 0xC)]
		public class TagBlock32
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public ResourceReference Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
		}
	}
}
