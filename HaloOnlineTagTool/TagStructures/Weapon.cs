using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "weap", Size = 0x558)]
	public class Weapon
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
		public HaloTag Unknown34 { get; set; }
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
		public HaloTag Unknown80 { get; set; }
		[TagElement]
		public int Unknown90 { get; set; }
		[TagElement]
		public int Unknown94 { get; set; }
		[TagElement]
		public int Unknown98 { get; set; }
		[TagElement]
		public int Unknown9C { get; set; }
		[TagElement]
		public HaloTag UnknownA0 { get; set; }
		[TagElement]
		public List<TagBlock0> UnknownB0 { get; set; }
		[TagElement]
		public List<TagBlock1> UnknownBC { get; set; }
		[TagElement]
		public int UnknownC8 { get; set; }
		[TagElement]
		public List<TagBlock2> UnknownCC { get; set; }
		[TagElement]
		public List<TagBlock3> UnknownD8 { get; set; }
		[TagElement]
		public List<TagBlock4> UnknownE4 { get; set; }
		[TagElement]
		public int UnknownF0 { get; set; }
		[TagElement]
		public int UnknownF4 { get; set; }
		[TagElement]
		public int UnknownF8 { get; set; }
		[TagElement]
		public List<TagBlock6> UnknownFC { get; set; }
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
		public int Unknown1A4 { get; set; }
		[TagElement]
		public int Unknown1A8 { get; set; }
		[TagElement]
		public int Unknown1AC { get; set; }
		[TagElement]
		public int Unknown1B0 { get; set; }
		[TagElement]
		public int Unknown1B4 { get; set; }
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
		[TagElement]
		public int Unknown220 { get; set; }
		[TagElement]
		public int Unknown224 { get; set; }
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
		public HaloTag Unknown278 { get; set; }
		[TagElement]
		public int Unknown288 { get; set; }
		[TagElement]
		public int Unknown28C { get; set; }
		[TagElement]
		public int Unknown290 { get; set; }
		[TagElement]
		public HaloTag Unknown294 { get; set; }
		[TagElement]
		public HaloTag Unknown2A4 { get; set; }
		[TagElement]
		public HaloTag Unknown2B4 { get; set; }
		[TagElement]
		public HaloTag Unknown2C4 { get; set; }
		[TagElement]
		public HaloTag Unknown2D4 { get; set; }
		[TagElement]
		public HaloTag Unknown2E4 { get; set; }
		[TagElement]
		public HaloTag Unknown2F4 { get; set; }
		[TagElement]
		public HaloTag Unknown304 { get; set; }
		[TagElement]
		public HaloTag Unknown314 { get; set; }
		[TagElement]
		public HaloTag Unknown324 { get; set; }
		[TagElement]
		public HaloTag Unknown334 { get; set; }
		[TagElement]
		public HaloTag Unknown344 { get; set; }
		[TagElement]
		public HaloTag Unknown354 { get; set; }
		[TagElement]
		public int Unknown364 { get; set; }
		[TagElement]
		public int Unknown368 { get; set; }
		[TagElement]
		public int Unknown36C { get; set; }
		[TagElement]
		public int Unknown370 { get; set; }
		[TagElement]
		public int Unknown374 { get; set; }
		[TagElement]
		public int Unknown378 { get; set; }
		[TagElement]
		public int Unknown37C { get; set; }
		[TagElement]
		public int Unknown380 { get; set; }
		[TagElement]
		public int Unknown384 { get; set; }
		[TagElement]
		public int Unknown388 { get; set; }
		[TagElement]
		public int Unknown38C { get; set; }
		[TagElement]
		public int Unknown390 { get; set; }
		[TagElement]
		public int Unknown394 { get; set; }
		[TagElement]
		public int Unknown398 { get; set; }
		[TagElement]
		public int Unknown39C { get; set; }
		[TagElement]
		public int Unknown3A0 { get; set; }
		[TagElement]
		public int Unknown3A4 { get; set; }
		[TagElement]
		public int Unknown3A8 { get; set; }
		[TagElement]
		public int Unknown3AC { get; set; }
		[TagElement]
		public int Unknown3B0 { get; set; }
		[TagElement]
		public List<TagBlock7> Unknown3B4 { get; set; }
		[TagElement]
		public int Unknown3C0 { get; set; }
		[TagElement]
		public int Unknown3C4 { get; set; }
		[TagElement]
		public int Unknown3C8 { get; set; }
		[TagElement]
		public int Unknown3CC { get; set; }
		[TagElement]
		public int Unknown3D0 { get; set; }
		[TagElement]
		public int Unknown3D4 { get; set; }
		[TagElement]
		public int Unknown3D8 { get; set; }
		[TagElement]
		public int Unknown3DC { get; set; }
		[TagElement]
		public int Unknown3E0 { get; set; }
		[TagElement]
		public int Unknown3E4 { get; set; }
		[TagElement]
		public int Unknown3E8 { get; set; }
		[TagElement]
		public int Unknown3EC { get; set; }
		[TagElement]
		public int Unknown3F0 { get; set; }
		[TagElement]
		public int Unknown3F4 { get; set; }
		[TagElement]
		public int Unknown3F8 { get; set; }
		[TagElement]
		public int Unknown3FC { get; set; }
		[TagElement]
		public int Unknown400 { get; set; }
		[TagElement]
		public int Unknown404 { get; set; }
		[TagElement]
		public int Unknown408 { get; set; }
		[TagElement]
		public int Unknown40C { get; set; }
		[TagElement]
		public int Unknown410 { get; set; }
		[TagElement]
		public int Unknown414 { get; set; }
		[TagElement]
		public HaloTag Unknown418 { get; set; }
		[TagElement]
		public HaloTag Unknown428 { get; set; }
		[TagElement]
		public HaloTag Unknown438 { get; set; }
		[TagElement]
		public int Unknown448 { get; set; }
		[TagElement]
		public int Unknown44C { get; set; }
		[TagElement]
		public int Unknown450 { get; set; }
		[TagElement]
		public int Unknown454 { get; set; }
		[TagElement]
		public int Unknown458 { get; set; }
		[TagElement]
		public int Unknown45C { get; set; }
		[TagElement]
		public int Unknown460 { get; set; }
		[TagElement]
		public int Unknown464 { get; set; }
		[TagElement]
		public int Unknown468 { get; set; }
		[TagElement]
		public int Unknown46C { get; set; }
		[TagElement]
		public List<TagBlock9> Unknown470 { get; set; }
		[TagElement]
		public HaloTag Unknown47C { get; set; }
		[TagElement]
		public int Unknown48C { get; set; }
		[TagElement]
		public int Unknown490 { get; set; }
		[TagElement]
		public int Unknown494 { get; set; }
		[TagElement]
		public List<TagBlock10> Unknown498 { get; set; }
		[TagElement]
		public List<TagBlock12> Unknown4A4 { get; set; }
		[TagElement]
		public List<TagBlock13> Unknown4B0 { get; set; }
		[TagElement]
		public int Unknown4BC { get; set; }
		[TagElement]
		public int Unknown4C0 { get; set; }
		[TagElement]
		public int Unknown4C4 { get; set; }
		[TagElement]
		public int Unknown4C8 { get; set; }
		[TagElement]
		public int Unknown4CC { get; set; }
		[TagElement]
		public int Unknown4D0 { get; set; }
		[TagElement]
		public int Unknown4D4 { get; set; }
		[TagElement]
		public int Unknown4D8 { get; set; }
		[TagElement]
		public int Unknown4DC { get; set; }
		[TagElement]
		public int Unknown4E0 { get; set; }
		[TagElement]
		public int Unknown4E4 { get; set; }
		[TagElement]
		public int Unknown4E8 { get; set; }
		[TagElement]
		public int Unknown4EC { get; set; }
		[TagElement]
		public int Unknown4F0 { get; set; }
		[TagElement]
		public int Unknown4F4 { get; set; }
		[TagElement]
		public int Unknown4F8 { get; set; }
		[TagElement]
		public int Unknown4FC { get; set; }
		[TagElement]
		public int Unknown500 { get; set; }
		[TagElement]
		public HaloTag Unknown504 { get; set; }
		[TagElement]
		public HaloTag Unknown514 { get; set; }
		[TagElement]
		public int Unknown524 { get; set; }
		[TagElement]
		public int Unknown528 { get; set; }
		[TagElement]
		public int Unknown52C { get; set; }
		[TagElement]
		public int Unknown530 { get; set; }
		[TagElement]
		public int Unknown534 { get; set; }
		[TagElement]
		public List<TagBlock17> Unknown538 { get; set; }
		[TagElement]
		public int Unknown544 { get; set; }
		[TagElement]
		public int Unknown548 { get; set; }
		[TagElement]
		public int Unknown54C { get; set; }
		[TagElement]
		public int Unknown550 { get; set; }
		[TagElement]
		public int Unknown554 { get; set; }

		[TagStructure(Size = 0xC)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
		}

		[TagStructure(Size = 0x2C)]
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
			public byte[] Unknown14 { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
		}

		[TagStructure(Size = 0x24)]
		public class TagBlock2
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
			public int Unknown1C { get; set; }
			[TagElement]
			public int Unknown20 { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock3
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x18)]
		public class TagBlock4
		{
			[TagElement]
			public List<TagBlock5> Unknown0 { get; set; }
			[TagElement]
			public int UnknownC { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
			[TagElement]
			public int Unknown14 { get; set; }

			[TagStructure(Size = 0x20)]
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
			}
		}

		[TagStructure(Size = 0xC4)]
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
		}

		[TagStructure(Size = 0x38)]
		public class TagBlock7
		{
			[TagElement]
			public List<TagBlock8> Unknown0 { get; set; }
			[TagElement]
			public int UnknownC { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
			[TagElement]
			public int Unknown14 { get; set; }
			[TagElement]
			public HaloTag Unknown18 { get; set; }
			[TagElement]
			public HaloTag Unknown28 { get; set; }

			[TagStructure(Size = 0x4)]
			public class TagBlock8
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock9
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown10 { get; set; }
		}

		[TagStructure(Size = 0x80)]
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
			public HaloTag Unknown34 { get; set; }
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
			public List<TagBlock11> Unknown74 { get; set; }

			[TagStructure(Size = 0x14)]
			public class TagBlock11
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown4 { get; set; }
			}
		}

		[TagStructure(Size = 0x90)]
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
			public HaloTag Unknown50 { get; set; }
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
		}

		[TagStructure(Size = 0x1AC)]
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
			public List<TagBlock14> Unknown98 { get; set; }
			[TagElement]
			public List<TagBlock15> UnknownA4 { get; set; }
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
			public List<TagBlock16> Unknown100 { get; set; }
			[TagElement]
			public int Unknown10C { get; set; }
			[TagElement]
			public HaloTag Unknown110 { get; set; }
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
			public List<TagBlock17> Unknown1A0 { get; set; }

			[TagStructure(Size = 0x14)]
			public class TagBlock14
			{
				[TagElement]
				public byte[] Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x14)]
			public class TagBlock15
			{
				[TagElement]
				public byte[] Unknown0 { get; set; }
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

			[TagStructure(Size = 0xC4)]
			public class TagBlock17
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown4 { get; set; }
				[TagElement]
				public HaloTag Unknown14 { get; set; }
				[TagElement]
				public HaloTag Unknown24 { get; set; }
				[TagElement]
				public int Unknown34 { get; set; }
				[TagElement]
				public int Unknown38 { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public int Unknown40 { get; set; }
				[TagElement]
				public HaloTag Unknown44 { get; set; }
				[TagElement]
				public HaloTag Unknown54 { get; set; }
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
				public HaloTag Unknown84 { get; set; }
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
			}
		}

		[TagStructure(Size = 0xC)]
		public class TagBlock17
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
