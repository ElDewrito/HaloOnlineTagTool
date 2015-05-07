using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "chgd", Size = 0x2C0)]
	public class ChudGlobalsDefinition
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock5> UnknownC { get; set; }
		[TagElement]
		public List<TagBlock6> Unknown18 { get; set; }
		[TagElement]
		public List<TagBlock7> Unknown24 { get; set; }
		[TagElement]
		public List<TagBlock9> Unknown30 { get; set; }
		[TagElement]
		public HaloTag Unknown3C { get; set; }
		[TagElement]
		public HaloTag Unknown4C { get; set; }
		[TagElement]
		public HaloTag Unknown5C { get; set; }
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
		public HaloTag Unknown88 { get; set; }
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
		public HaloTag UnknownB4 { get; set; }
		[TagElement]
		public HaloTag UnknownC4 { get; set; }
		[TagElement]
		public HaloTag UnknownD4 { get; set; }
		[TagElement]
		public HaloTag UnknownE4 { get; set; }
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
		public byte[] Unknown150 { get; set; }
		[TagElement]
		public int Unknown164 { get; set; }
		[TagElement]
		public int Unknown168 { get; set; }
		[TagElement]
		public int Unknown16C { get; set; }
		[TagElement]
		public int Unknown170 { get; set; }
		[TagElement]
		public int Unknown174 { get; set; }
		[TagElement]
		public int Unknown178 { get; set; }
		[TagElement]
		public int Unknown17C { get; set; }
		[TagElement]
		public int Unknown180 { get; set; }
		[TagElement]
		public int Unknown184 { get; set; }
		[TagElement]
		public int Unknown188 { get; set; }
		[TagElement]
		public int Unknown18C { get; set; }
		[TagElement]
		public int Unknown190 { get; set; }
		[TagElement]
		public int Unknown194 { get; set; }
		[TagElement]
		public int Unknown198 { get; set; }
		[TagElement]
		public int Unknown19C { get; set; }
		[TagElement]
		public int Unknown1A0 { get; set; }
		[TagElement]
		public byte[] Unknown1A4 { get; set; }
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
		public byte[] Unknown1D8 { get; set; }
		[TagElement]
		public byte[] Unknown1EC { get; set; }
		[TagElement]
		public byte[] Unknown200 { get; set; }
		[TagElement]
		public byte[] Unknown214 { get; set; }
		[TagElement]
		public byte[] Unknown228 { get; set; }
		[TagElement]
		public int Unknown23C { get; set; }
		[TagElement]
		public byte[] Unknown240 { get; set; }
		[TagElement]
		public byte[] Unknown254 { get; set; }
		[TagElement]
		public byte[] Unknown268 { get; set; }
		[TagElement]
		public byte[] Unknown27C { get; set; }
		[TagElement]
		public byte[] Unknown290 { get; set; }
		[TagElement]
		public int Unknown2A4 { get; set; }
		[TagElement]
		public int Unknown2A8 { get; set; }
		[TagElement]
		public int Unknown2AC { get; set; }
		[TagElement]
		public int Unknown2B0 { get; set; }
		[TagElement]
		public int Unknown2B4 { get; set; }
		[TagElement]
		public int Unknown2B8 { get; set; }
		[TagElement]
		public int Unknown2BC { get; set; }

		[TagStructure(Size = 0x2B0)]
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
			public List<TagBlock1> Unknown98 { get; set; }
			[TagElement]
			public List<TagBlock2> UnknownA4 { get; set; }
			[TagElement]
			public int UnknownB0 { get; set; }
			[TagElement]
			public int UnknownB4 { get; set; }
			[TagElement]
			public int UnknownB8 { get; set; }
			[TagElement]
			public int UnknownBC { get; set; }
			[TagElement]
			public HaloTag UnknownC0 { get; set; }
			[TagElement]
			public HaloTag UnknownD0 { get; set; }
			[TagElement]
			public HaloTag UnknownE0 { get; set; }
			[TagElement]
			public HaloTag UnknownF0 { get; set; }
			[TagElement]
			public HaloTag Unknown100 { get; set; }
			[TagElement]
			public HaloTag Unknown110 { get; set; }
			[TagElement]
			public HaloTag Unknown120 { get; set; }
			[TagElement]
			public HaloTag Unknown130 { get; set; }
			[TagElement]
			public HaloTag Unknown140 { get; set; }
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
			public int Unknown164 { get; set; }
			[TagElement]
			public HaloTag Unknown168 { get; set; }
			[TagElement]
			public HaloTag Unknown178 { get; set; }
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
			public HaloTag Unknown1C8 { get; set; }
			[TagElement]
			public HaloTag Unknown1D8 { get; set; }
			[TagElement]
			public HaloTag Unknown1E8 { get; set; }
			[TagElement]
			public HaloTag Unknown1F8 { get; set; }
			[TagElement]
			public List<TagBlock4> Unknown208 { get; set; }
			[TagElement]
			public HaloTag Unknown214 { get; set; }
			[TagElement]
			public HaloTag Unknown224 { get; set; }
			[TagElement]
			public HaloTag Unknown234 { get; set; }
			[TagElement]
			public int Unknown244 { get; set; }
			[TagElement]
			public int Unknown248 { get; set; }
			[TagElement]
			public int Unknown24C { get; set; }
			[TagElement]
			public int Unknown250 { get; set; }
			[TagElement]
			public int Unknown254 { get; set; }
			[TagElement]
			public int Unknown258 { get; set; }
			[TagElement]
			public int Unknown25C { get; set; }
			[TagElement]
			public int Unknown260 { get; set; }
			[TagElement]
			public int Unknown264 { get; set; }
			[TagElement]
			public int Unknown268 { get; set; }
			[TagElement]
			public int Unknown26C { get; set; }
			[TagElement]
			public int Unknown270 { get; set; }
			[TagElement]
			public int Unknown274 { get; set; }
			[TagElement]
			public int Unknown278 { get; set; }
			[TagElement]
			public int Unknown27C { get; set; }
			[TagElement]
			public int Unknown280 { get; set; }
			[TagElement]
			public int Unknown284 { get; set; }
			[TagElement]
			public int Unknown288 { get; set; }
			[TagElement]
			public int Unknown28C { get; set; }
			[TagElement]
			public int Unknown290 { get; set; }
			[TagElement]
			public int Unknown294 { get; set; }
			[TagElement]
			public int Unknown298 { get; set; }
			[TagElement]
			public int Unknown29C { get; set; }
			[TagElement]
			public int Unknown2A0 { get; set; }
			[TagElement]
			public int Unknown2A4 { get; set; }
			[TagElement]
			public int Unknown2A8 { get; set; }
			[TagElement]
			public int Unknown2AC { get; set; }

			[TagStructure(Size = 0xE8)]
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
				public HaloTag Unknown58 { get; set; }
				[TagElement]
				public HaloTag Unknown68 { get; set; }
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

				[TagStructure(Size = 0x14)]
				public class TagBlock3
				{
					[TagElement]
					public int Unknown0 { get; set; }
					[TagElement]
					public HaloTag Unknown4 { get; set; }
				}
			}

			[TagStructure(Size = 0x4)]
			public class TagBlock4
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock5
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown10 { get; set; }
		}

		[TagStructure(Size = 0x40)]
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
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock7
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown4 { get; set; }

			[TagStructure(Size = 0xE4)]
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
			}
		}

		[TagStructure(Size = 0x14)]
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
		}
	}
}
