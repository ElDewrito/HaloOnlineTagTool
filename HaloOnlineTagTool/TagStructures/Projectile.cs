using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "proj", Size = 0x2CC)]
	public class Projectile
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
		public List<TagBlock0> UnknownBC { get; set; }
		[TagElement]
		public int UnknownC8 { get; set; }
		[TagElement]
		public List<TagBlock1> UnknownCC { get; set; }
		[TagElement]
		public List<TagBlock2> UnknownD8 { get; set; }
		[TagElement]
		public List<TagBlock3> UnknownE4 { get; set; }
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
		public HaloTag Unknown150 { get; set; }
		[TagElement]
		public HaloTag Unknown160 { get; set; }
		[TagElement]
		public HaloTag Unknown170 { get; set; }
		[TagElement]
		public HaloTag Unknown180 { get; set; }
		[TagElement]
		public HaloTag Unknown190 { get; set; }
		[TagElement]
		public HaloTag Unknown1A0 { get; set; }
		[TagElement]
		public HaloTag Unknown1B0 { get; set; }
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
		public HaloTag Unknown1D4 { get; set; }
		[TagElement]
		public int Unknown1E4 { get; set; }
		[TagElement]
		public HaloTag Unknown1E8 { get; set; }
		[TagElement]
		public HaloTag Unknown1F8 { get; set; }
		[TagElement]
		public HaloTag Unknown208 { get; set; }
		[TagElement]
		public HaloTag Unknown218 { get; set; }
		[TagElement]
		public int Unknown228 { get; set; }
		[TagElement]
		public HaloTag Unknown22C { get; set; }
		[TagElement]
		public HaloTag Unknown23C { get; set; }
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
		public List<TagBlock5> Unknown29C { get; set; }
		[TagElement]
		public List<TagBlock6> Unknown2A8 { get; set; }
		[TagElement]
		public List<TagBlock7> Unknown2B4 { get; set; }
		[TagElement]
		public List<TagBlock8> Unknown2C0 { get; set; }

		[TagStructure(Size = 0x2C)]
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
			public byte[] Unknown14 { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
		}

		[TagStructure(Size = 0x24)]
		public class TagBlock1
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
		}

		[TagStructure(Size = 0x18)]
		public class TagBlock3
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
			[TagElement]
			public List<TagBlock4> UnknownC { get; set; }

			[TagStructure(Size = 0x28)]
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
			}
		}

		[TagStructure(Size = 0x40)]
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
		}

		[TagStructure(Size = 0x30)]
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
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock7
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0xC)]
		public class TagBlock8
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
