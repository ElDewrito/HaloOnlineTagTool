using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "vehi", Size = 0x530)]
	public class Vehicle
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
		public List<TagBlock7> Unknown114 { get; set; }
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
		public List<TagBlock8> Unknown138 { get; set; }
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
		public List<TagBlock9> Unknown174 { get; set; }
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
		public int Unknown228 { get; set; }
		[TagElement]
		public int Unknown22C { get; set; }
		[TagElement]
		public int Unknown230 { get; set; }
		[TagElement]
		public int Unknown234 { get; set; }
		[TagElement]
		public int Unknown238 { get; set; }
		[TagElement]
		public int Unknown23C { get; set; }
		[TagElement]
		public HaloTag Unknown240 { get; set; }
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
		[TagElement]
		public int Unknown2B0 { get; set; }
		[TagElement]
		public int Unknown2B4 { get; set; }
		[TagElement]
		public int Unknown2B8 { get; set; }
		[TagElement]
		public int Unknown2BC { get; set; }
		[TagElement]
		public int Unknown2C0 { get; set; }
		[TagElement]
		public int Unknown2C4 { get; set; }
		[TagElement]
		public int Unknown2C8 { get; set; }
		[TagElement]
		public int Unknown2CC { get; set; }
		[TagElement]
		public int Unknown2D0 { get; set; }
		[TagElement]
		public int Unknown2D4 { get; set; }
		[TagElement]
		public int Unknown2D8 { get; set; }
		[TagElement]
		public int Unknown2DC { get; set; }
		[TagElement]
		public int Unknown2E0 { get; set; }
		[TagElement]
		public int Unknown2E4 { get; set; }
		[TagElement]
		public int Unknown2E8 { get; set; }
		[TagElement]
		public int Unknown2EC { get; set; }
		[TagElement]
		public int Unknown2F0 { get; set; }
		[TagElement]
		public int Unknown2F4 { get; set; }
		[TagElement]
		public int Unknown2F8 { get; set; }
		[TagElement]
		public int Unknown2FC { get; set; }
		[TagElement]
		public int Unknown300 { get; set; }
		[TagElement]
		public int Unknown304 { get; set; }
		[TagElement]
		public int Unknown308 { get; set; }
		[TagElement]
		public int Unknown30C { get; set; }
		[TagElement]
		public int Unknown310 { get; set; }
		[TagElement]
		public int Unknown314 { get; set; }
		[TagElement]
		public int Unknown318 { get; set; }
		[TagElement]
		public int Unknown31C { get; set; }
		[TagElement]
		public int Unknown320 { get; set; }
		[TagElement]
		public int Unknown324 { get; set; }
		[TagElement]
		public List<TagBlock10> Unknown328 { get; set; }
		[TagElement]
		public int Unknown334 { get; set; }
		[TagElement]
		public int Unknown338 { get; set; }
		[TagElement]
		public int Unknown33C { get; set; }
		[TagElement]
		public int Unknown340 { get; set; }
		[TagElement]
		public int Unknown344 { get; set; }
		[TagElement]
		public int Unknown348 { get; set; }
		[TagElement]
		public int Unknown34C { get; set; }
		[TagElement]
		public int Unknown350 { get; set; }
		[TagElement]
		public int Unknown354 { get; set; }
		[TagElement]
		public List<TagBlock11> Unknown358 { get; set; }
		[TagElement]
		public List<TagBlock12> Unknown364 { get; set; }
		[TagElement]
		public int Unknown370 { get; set; }
		[TagElement]
		public int Unknown374 { get; set; }
		[TagElement]
		public int Unknown378 { get; set; }
		[TagElement]
		public List<TagBlock13> Unknown37C { get; set; }
		[TagElement]
		public int Unknown388 { get; set; }
		[TagElement]
		public HaloTag Unknown38C { get; set; }
		[TagElement]
		public HaloTag Unknown39C { get; set; }
		[TagElement]
		public int Unknown3AC { get; set; }
		[TagElement]
		public int Unknown3B0 { get; set; }
		[TagElement]
		public int Unknown3B4 { get; set; }
		[TagElement]
		public int Unknown3B8 { get; set; }
		[TagElement]
		public int Unknown3BC { get; set; }
		[TagElement]
		public int Unknown3C0 { get; set; }
		[TagElement]
		public int Unknown3C4 { get; set; }
		[TagElement]
		public HaloTag Unknown3C8 { get; set; }
		[TagElement]
		public HaloTag Unknown3D8 { get; set; }
		[TagElement]
		public int Unknown3E8 { get; set; }
		[TagElement]
		public List<TagBlock17> Unknown3EC { get; set; }
		[TagElement]
		public List<TagBlock19> Unknown3F8 { get; set; }
		[TagElement]
		public int Unknown404 { get; set; }
		[TagElement]
		public int Unknown408 { get; set; }
		[TagElement]
		public int Unknown40C { get; set; }
		[TagElement]
		public List<TagBlock21> Unknown410 { get; set; }
		[TagElement]
		public List<TagBlock22> Unknown41C { get; set; }
		[TagElement]
		public List<TagBlock23> Unknown428 { get; set; }
		[TagElement]
		public int Unknown434 { get; set; }
		[TagElement]
		public int Unknown438 { get; set; }
		[TagElement]
		public int Unknown43C { get; set; }
		[TagElement]
		public List<TagBlock24> Unknown440 { get; set; }
		[TagElement]
		public List<TagBlock25> Unknown44C { get; set; }
		[TagElement]
		public List<TagBlock27> Unknown458 { get; set; }
		[TagElement]
		public int Unknown464 { get; set; }
		[TagElement]
		public int Unknown468 { get; set; }
		[TagElement]
		public int Unknown46C { get; set; }
		[TagElement]
		public int Unknown470 { get; set; }
		[TagElement]
		public int Unknown474 { get; set; }
		[TagElement]
		public int Unknown478 { get; set; }
		[TagElement]
		public int Unknown47C { get; set; }
		[TagElement]
		public int Unknown480 { get; set; }
		[TagElement]
		public int Unknown484 { get; set; }
		[TagElement]
		public int Unknown488 { get; set; }
		[TagElement]
		public int Unknown48C { get; set; }
		[TagElement]
		public int Unknown490 { get; set; }
		[TagElement]
		public int Unknown494 { get; set; }
		[TagElement]
		public int Unknown498 { get; set; }
		[TagElement]
		public int Unknown49C { get; set; }
		[TagElement]
		public List<TagBlock28> Unknown4A0 { get; set; }
		[TagElement]
		public List<TagBlock29> Unknown4AC { get; set; }
		[TagElement]
		public List<TagBlock30> Unknown4B8 { get; set; }
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
		public HaloTag Unknown4E8 { get; set; }
		[TagElement]
		public int Unknown4F8 { get; set; }
		[TagElement]
		public int Unknown4FC { get; set; }
		[TagElement]
		public int Unknown500 { get; set; }
		[TagElement]
		public int Unknown504 { get; set; }
		[TagElement]
		public HaloTag Unknown508 { get; set; }
		[TagElement]
		public HaloTag Unknown518 { get; set; }
		[TagElement]
		public int Unknown528 { get; set; }
		[TagElement]
		public int Unknown52C { get; set; }

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

		[TagStructure(Size = 0x14)]
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
		}

		[TagStructure(Size = 0x8)]
		public class TagBlock8
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock9
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x10)]
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
		}

		[TagStructure(Size = 0x8)]
		public class TagBlock11
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock12
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
		}

		[TagStructure(Size = 0xE4)]
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
			public List<TagBlock14> Unknown80 { get; set; }
			[TagElement]
			public int Unknown8C { get; set; }
			[TagElement]
			public int Unknown90 { get; set; }
			[TagElement]
			public int Unknown94 { get; set; }
			[TagElement]
			public List<TagBlock15> Unknown98 { get; set; }
			[TagElement]
			public List<TagBlock16> UnknownA4 { get; set; }
			[TagElement]
			public int UnknownB0 { get; set; }
			[TagElement]
			public int UnknownB4 { get; set; }
			[TagElement]
			public int UnknownB8 { get; set; }
			[TagElement]
			public HaloTag UnknownBC { get; set; }
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

			[TagStructure(Size = 0x10)]
			public class TagBlock14
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x4C)]
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
			}

			[TagStructure(Size = 0x10)]
			public class TagBlock16
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x58)]
		public class TagBlock17
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
			public List<TagBlock18> Unknown34 { get; set; }
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

			[TagStructure(Size = 0x44)]
			public class TagBlock18
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
			[TagElement]
			public int Unknown14 { get; set; }
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public List<TagBlock20> Unknown1C { get; set; }
			[TagElement]
			public HaloTag Unknown28 { get; set; }
			[TagElement]
			public int Unknown38 { get; set; }
			[TagElement]
			public int Unknown3C { get; set; }

			[TagStructure(Size = 0x44)]
			public class TagBlock20
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

		[TagStructure(Size = 0x70)]
		public class TagBlock21
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
		}

		// Note: size might actually be 0x64, not sure
		[TagStructure(Size = 0x68)]
		public class TagBlock22
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
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock23
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x74)]
		public class TagBlock24
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
		}

		[TagStructure(Size = 0x70)]
		public class TagBlock25
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
			public List<TagBlock26> Unknown1C { get; set; }
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

			[TagStructure(Size = 0x44)]
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

		[TagStructure(Size = 0x30)]
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

		[TagStructure(Size = 0x4C)]
		public class TagBlock28
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
		}

		[TagStructure(Size = 0x4C)]
		public class TagBlock29
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
		}

		[TagStructure(Size = 0x330)]
		public class TagBlock30
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
			public int Unknown228 { get; set; }
			[TagElement]
			public int Unknown22C { get; set; }
			[TagElement]
			public int Unknown230 { get; set; }
			[TagElement]
			public int Unknown234 { get; set; }
			[TagElement]
			public int Unknown238 { get; set; }
			[TagElement]
			public int Unknown23C { get; set; }
			[TagElement]
			public int Unknown240 { get; set; }
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
			[TagElement]
			public int Unknown2B0 { get; set; }
			[TagElement]
			public int Unknown2B4 { get; set; }
			[TagElement]
			public int Unknown2B8 { get; set; }
			[TagElement]
			public int Unknown2BC { get; set; }
			[TagElement]
			public int Unknown2C0 { get; set; }
			[TagElement]
			public int Unknown2C4 { get; set; }
			[TagElement]
			public int Unknown2C8 { get; set; }
			[TagElement]
			public int Unknown2CC { get; set; }
			[TagElement]
			public int Unknown2D0 { get; set; }
			[TagElement]
			public int Unknown2D4 { get; set; }
			[TagElement]
			public int Unknown2D8 { get; set; }
			[TagElement]
			public int Unknown2DC { get; set; }
			[TagElement]
			public int Unknown2E0 { get; set; }
			[TagElement]
			public int Unknown2E4 { get; set; }
			[TagElement]
			public int Unknown2E8 { get; set; }
			[TagElement]
			public int Unknown2EC { get; set; }
			[TagElement]
			public int Unknown2F0 { get; set; }
			[TagElement]
			public int Unknown2F4 { get; set; }
			[TagElement]
			public int Unknown2F8 { get; set; }
			[TagElement]
			public int Unknown2FC { get; set; }
			[TagElement]
			public int Unknown300 { get; set; }
			[TagElement]
			public int Unknown304 { get; set; }
			[TagElement]
			public int Unknown308 { get; set; }
			[TagElement]
			public int Unknown30C { get; set; }
			[TagElement]
			public int Unknown310 { get; set; }
			[TagElement]
			public int Unknown314 { get; set; }
			[TagElement]
			public int Unknown318 { get; set; }
			[TagElement]
			public int Unknown31C { get; set; }
			[TagElement]
			public int Unknown320 { get; set; }
			[TagElement]
			public int Unknown324 { get; set; }
			[TagElement]
			public int Unknown328 { get; set; }
			[TagElement]
			public int Unknown32C { get; set; }
		}
	}
}
