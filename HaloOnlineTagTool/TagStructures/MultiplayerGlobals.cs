using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "mulg", Size = 0x18)]
	public class MultiplayerGlobals
	{
		[TagElement]
		public List<UniversalGlobals> Universal { get; set; }
		[TagElement]
		public List<RuntimeGlobals> Runtime { get; set; }

		[TagStructure(Size = 0xD8)]
		public class UniversalGlobals
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown10 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown20 { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown2C { get; set; }
			[TagElement]
			public List<TagBlock5> Unknown38 { get; set; }
			[TagElement]
			public List<TagBlock6> Unknown44 { get; set; }
			[TagElement]
			public HaloTag Unknown50 { get; set; }
			[TagElement]
			public HaloTag Unknown60 { get; set; }
			[TagElement]
			public HaloTag Unknown70 { get; set; }
			[TagElement]
			public List<TagBlock7> Unknown80 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown8C { get; set; }
			[TagElement]
			public List<TagBlock9> Unknown98 { get; set; }
			[TagElement]
			public List<TagBlock10> UnknownA4 { get; set; }
			[TagElement]
			public List<TagBlock12> UnknownB0 { get; set; }
			[TagElement]
			public List<TagBlock14> UnknownBC { get; set; }
			[TagElement]
			public HaloTag UnknownC8 { get; set; }

			[TagStructure(Size = 0x14)]
			public class TagBlock1
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public List<TagBlock2> Unknown8 { get; set; }

				[TagStructure(Size = 0x30)]
				public class TagBlock2
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public HaloTag Unknown4 { get; set; }
					[TagElement]
					public HaloTag Unknown14 { get; set; }
					[TagElement]
					public int Unknown24 { get; set; }
					[TagElement]
					public int Unknown28 { get; set; }
					[TagElement]
					public int Unknown2C { get; set; }
				}
			}

			[TagStructure(Size = 0x14)]
			public class TagBlock3
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public List<TagBlock4> Unknown8 { get; set; }

				[TagStructure(Size = 0x30)]
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
				}
			}

			[TagStructure(Size = 0x18)]
			public class TagBlock5
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown4 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
			}

			[TagStructure(Size = 0x8)]
			public class TagBlock6
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}

			[TagStructure(Size = 0x18)]
			public class TagBlock7
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public HaloTag Unknown8 { get; set; }
			}

			[TagStructure(Size = 0x14)]
			public class TagBlock8
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown4 { get; set; }
			}

			[TagStructure(Size = 0x14)]
			public class TagBlock9
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown4 { get; set; }
			}

			[TagStructure(Size = 0x10)]
			public class TagBlock10
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public List<TagBlock11> Unknown4 { get; set; }

				[TagStructure(Size = 0x8)]
				public class TagBlock11
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public int Unknown4 { get; set; }
				}
			}

			[TagStructure(Size = 0x10)]
			public class TagBlock12
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public List<TagBlock13> Unknown4 { get; set; }

				[TagStructure(Size = 0x8)]
				public class TagBlock13
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public int Unknown4 { get; set; }
				}
			}

			[TagStructure(Size = 0x30)]
			public class TagBlock14
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public List<TagBlock15> Unknown18 { get; set; }
				[TagElement]
				public List<TagBlock16> Unknown24 { get; set; }

				[TagStructure(Size = 0x34)]
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
				}

				[TagStructure(Size = 0x50)]
				public class TagBlock16
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
					public HaloTag Unknown30 { get; set; }
					[TagElement]
					public HaloTag Unknown40 { get; set; }
				}
			}
		}

		[TagStructure(Size = 0x2A8)]
		public class RuntimeGlobals
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown10 { get; set; }
			[TagElement]
			public HaloTag Unknown20 { get; set; }
			[TagElement]
			public HaloTag Unknown30 { get; set; }
			[TagElement]
			public HaloTag Unknown40 { get; set; }
			[TagElement]
			public HaloTag Unknown50 { get; set; }
			[TagElement]
			public HaloTag Unknown60 { get; set; }
			[TagElement]
			public HaloTag Unknown70 { get; set; }
			[TagElement]
			public HaloTag Unknown80 { get; set; }
			[TagElement]
			public HaloTag Unknown90 { get; set; }
			[TagElement]
			public HaloTag UnknownA0 { get; set; }
			[TagElement]
			public HaloTag UnknownB0 { get; set; }
			[TagElement]
			public List<TagBlock18> UnknownC0 { get; set; }
			[TagElement]
			public List<TagBlock19> UnknownCC { get; set; }
			[TagElement]
			public List<Event> UnknownD8 { get; set; }
			[TagElement]
			public List<Event> UnknownE4 { get; set; }
			[TagElement]
			public List<Event> UnknownF0 { get; set; }
			[TagElement]
			public List<Event> UnknownFC { get; set; }
			[TagElement]
			public List<Event> Unknown108 { get; set; }
			[TagElement]
			public List<Event> Unknown114 { get; set; }
			[TagElement]
			public List<Event> Unknown120 { get; set; }
			[TagElement]
			public List<Event> Unknown12C { get; set; }
			[TagElement]
			public List<Event> Unknown138 { get; set; }
			[TagElement]
			public List<Event> Unknown144 { get; set; }
			[TagElement]
			public List<Event> Unknown150 { get; set; }
			[TagElement]
			public List<Event> Unknown15C { get; set; }
			[TagElement]
			public int Unknown168 { get; set; }
			[TagElement]
			public int Unknown16C { get; set; }
			[TagElement]
			public List<TagBlock32> Unknown170 { get; set; }
			[TagElement]
			public List<TagBlock37> Unknown17C { get; set; }
			[TagElement]
			public HaloTag Unknown188 { get; set; }
			[TagElement]
			public HaloTag Unknown198 { get; set; }
			[TagElement]
			public HaloTag Unknown1A8 { get; set; }
			[TagElement]
			public int Unknown1B8 { get; set; }
			[TagElement]
			public int Unknown1BC { get; set; }
			[TagElement]
			public int Unknown1C0 { get; set; }
			[TagElement]
			public int Unknown1C4 { get; set; }
			[TagElement]
			public int Unknown1C8 { get; set; }
			[TagElement]
			public int Unknown1CC { get; set; }
			[TagElement]
			public int Unknown1D0 { get; set; }
			[TagElement]
			public int Unknown1D4 { get; set; }
			[TagElement]
			public HaloTag Unknown1D8 { get; set; }
			[TagElement]
			public HaloTag Unknown1E8 { get; set; }
			[TagElement]
			public HaloTag Unknown1F8 { get; set; }
			[TagElement]
			public HaloTag Unknown208 { get; set; }
			[TagElement]
			public HaloTag Unknown218 { get; set; }
			[TagElement]
			public HaloTag Unknown228 { get; set; }
			[TagElement]
			public HaloTag Unknown238 { get; set; }
			[TagElement]
			public int Unknown248 { get; set; }
			[TagElement]
			public int Unknown24C { get; set; }
			[TagElement]
			public int Unknown250 { get; set; }
			[TagElement]
			public int Unknown254 { get; set; }
			[TagElement]
			public HaloTag Unknown258 { get; set; }
			[TagElement]
			public HaloTag Unknown268 { get; set; }
			[TagElement]
			public HaloTag Unknown278 { get; set; }
			[TagElement]
			public HaloTag Unknown288 { get; set; }
			[TagElement]
			public int Unknown298 { get; set; }
			[TagElement]
			public int Unknown29C { get; set; }
			[TagElement]
			public int Unknown2A0 { get; set; }
			[TagElement]
			public int Unknown2A4 { get; set; }

			[TagStructure(Size = 0x10)]
			public class TagBlock18
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x10)]
			public class TagBlock19
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x10C)]
			public class Event
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
				public int StringId { get; set; }
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
				public HaloTag Unknown4C { get; set; }
				[TagElement]
				public HaloTag Unknown5C { get; set; }
				[TagElement]
				public HaloTag Unknown6C { get; set; }
				[TagElement]
				public HaloTag Unknown7C { get; set; }
				[TagElement]
				public HaloTag Unknown8C { get; set; }
				[TagElement]
				public HaloTag Unknown9C { get; set; }
				[TagElement]
				public HaloTag UnknownAC { get; set; }
				[TagElement]
				public HaloTag UnknownBC { get; set; }
				[TagElement]
				public HaloTag UnknownCC { get; set; }
				[TagElement]
				public HaloTag UnknownDC { get; set; }
				[TagElement]
				public int UnknownEC { get; set; }
				[TagElement]
				public int UnknownF0 { get; set; }
				[TagElement]
				public int UnknownF4 { get; set; }
				[TagElement]
				public int UnknownF8 { get; set; }
				[TagElement]
				public int UnknownFC { get; set; }
				[TagElement]
				public int Unknown100 { get; set; }
				[TagElement]
				public int Unknown104 { get; set; }
				[TagElement]
				public int Unknown108 { get; set; }
			}

			[TagStructure(Size = 0x220)]
			public class TagBlock32
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
				public List<TagBlock33> Unknown68 { get; set; }
				[TagElement]
				public List<TagBlock34> Unknown74 { get; set; }
				[TagElement]
				public List<TagBlock35> Unknown80 { get; set; }
				[TagElement]
				public List<TagBlock36> Unknown8C { get; set; }
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
				public int UnknownF8 { get; set; }
				[TagElement]
				public int UnknownFC { get; set; }
				[TagElement]
				public int Unknown100 { get; set; }
				[TagElement]
				public int Unknown104 { get; set; }
				[TagElement]
				public int Unknown108 { get; set; }
				[TagElement]
				public int Unknown10C { get; set; }
				[TagElement]
				public int Unknown110 { get; set; }
				[TagElement]
				public int Unknown114 { get; set; }
				[TagElement]
				public int Unknown118 { get; set; }
				[TagElement]
				public int Unknown11C { get; set; }
				[TagElement]
				public int Unknown120 { get; set; }
				[TagElement]
				public int Unknown124 { get; set; }
				[TagElement]
				public int Unknown128 { get; set; }
				[TagElement]
				public int Unknown12C { get; set; }
				[TagElement]
				public int Unknown130 { get; set; }
				[TagElement]
				public int Unknown134 { get; set; }
				[TagElement]
				public int Unknown138 { get; set; }
				[TagElement]
				public int Unknown13C { get; set; }
				[TagElement]
				public int Unknown140 { get; set; }
				[TagElement]
				public int Unknown144 { get; set; }
				[TagElement]
				public int Unknown148 { get; set; }
				[TagElement]
				public int Unknown14C { get; set; }
				[TagElement]
				public int Unknown150 { get; set; }
				[TagElement]
				public int Unknown154 { get; set; }
				[TagElement]
				public int Unknown158 { get; set; }
				[TagElement]
				public int Unknown15C { get; set; }
				[TagElement]
				public int Unknown160 { get; set; }
				[TagElement]
				public HaloTag Unknown164 { get; set; }
				[TagElement]
				public int Unknown174 { get; set; }
				[TagElement]
				public int Unknown178 { get; set; }
				[TagElement]
				public int Unknown17C { get; set; }
				[TagElement]
				public int Unknown180 { get; set; }
				[TagElement]
				public HaloTag Unknown184 { get; set; }
				[TagElement]
				public int Unknown194 { get; set; }
				[TagElement]
				public int Unknown198 { get; set; }
				[TagElement]
				public int Unknown19C { get; set; }
				[TagElement]
				public int Unknown1A0 { get; set; }
				[TagElement]
				public HaloTag Unknown1A4 { get; set; }
				[TagElement]
				public int Unknown1B4 { get; set; }
				[TagElement]
				public int Unknown1B8 { get; set; }
				[TagElement]
				public int Unknown1BC { get; set; }
				[TagElement]
				public int Unknown1C0 { get; set; }
				[TagElement]
				public HaloTag Unknown1C4 { get; set; }
				[TagElement]
				public int Unknown1D4 { get; set; }
				[TagElement]
				public int Unknown1D8 { get; set; }
				[TagElement]
				public int Unknown1DC { get; set; }
				[TagElement]
				public int Unknown1E0 { get; set; }
				[TagElement]
				public int Unknown1E4 { get; set; }
				[TagElement]
				public int Unknown1E8 { get; set; }
				[TagElement]
				public int Unknown1EC { get; set; }
				[TagElement]
				public int Unknown1F0 { get; set; }
				[TagElement]
				public int Unknown1F4 { get; set; }
				[TagElement]
				public int Unknown1F8 { get; set; }
				[TagElement]
				public int Unknown1FC { get; set; }
				[TagElement]
				public int Unknown200 { get; set; }
				[TagElement]
				public int Unknown204 { get; set; }
				[TagElement]
				public int Unknown208 { get; set; }
				[TagElement]
				public int Unknown20C { get; set; }
				[TagElement]
				public int Unknown210 { get; set; }
				[TagElement]
				public int Unknown214 { get; set; }
				[TagElement]
				public int Unknown218 { get; set; }
				[TagElement]
				public int Unknown21C { get; set; }

				[TagStructure(Size = 0x20)]
				public class TagBlock33
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
				}

				[TagStructure(Size = 0x20)]
				public class TagBlock34
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
				}

				[TagStructure(Size = 0x1C)]
				public class TagBlock35
				{
					[TagElement]
					public HaloTag Unknown0 { get; set; }
					[TagElement]
					public int Unknown10 { get; set; }
					[TagElement]
					public int Unknown14 { get; set; }
					[TagElement]
					public int Unknown18 { get; set; }
				}

				[TagStructure(Size = 0x14)]
				public class TagBlock36
				{
					[TagElement]
					public HaloTag Unknown0 { get; set; }
					[TagElement]
					public int Unknown10 { get; set; }
				}
			}

			[TagStructure(Size = 0x24)]
			public class TagBlock37
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
