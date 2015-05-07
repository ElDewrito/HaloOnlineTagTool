using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "cntl", Size = 0xC)]
	public class ContrailSystem
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }

		[TagStructure(Size = 0x26C)]
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
			public byte[] Unknown28 { get; set; }
			[TagElement]
			public int Unknown3C { get; set; }
			[TagElement]
			public int Unknown40 { get; set; }
			[TagElement]
			public int Unknown44 { get; set; }
			[TagElement]
			public byte[] Unknown48 { get; set; }
			[TagElement]
			public int Unknown5C { get; set; }
			[TagElement]
			public int Unknown60 { get; set; }
			[TagElement]
			public int Unknown64 { get; set; }
			[TagElement]
			public byte[] Unknown68 { get; set; }
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
			public byte[] UnknownA0 { get; set; }
			[TagElement]
			public int UnknownB4 { get; set; }
			[TagElement]
			public int UnknownB8 { get; set; }
			[TagElement]
			public int UnknownBC { get; set; }
			[TagElement]
			public byte[] UnknownC0 { get; set; }
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
			public byte[] UnknownF0 { get; set; }
			[TagElement]
			public int Unknown104 { get; set; }
			[TagElement]
			public int Unknown108 { get; set; }
			[TagElement]
			public int Unknown10C { get; set; }
			[TagElement]
			public byte[] Unknown110 { get; set; }
			[TagElement]
			public int Unknown124 { get; set; }
			[TagElement]
			public int Unknown128 { get; set; }
			[TagElement]
			public int Unknown12C { get; set; }
			[TagElement]
			public HaloTag Unknown130 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown140 { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown14C { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown158 { get; set; }
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
			public byte[] Unknown184 { get; set; }
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
			public byte[] Unknown1C4 { get; set; }
			[TagElement]
			public int Unknown1D8 { get; set; }
			[TagElement]
			public int Unknown1DC { get; set; }
			[TagElement]
			public int Unknown1E0 { get; set; }
			[TagElement]
			public byte[] Unknown1E4 { get; set; }
			[TagElement]
			public int Unknown1F8 { get; set; }
			[TagElement]
			public int Unknown1FC { get; set; }
			[TagElement]
			public int Unknown200 { get; set; }
			[TagElement]
			public byte[] Unknown204 { get; set; }
			[TagElement]
			public int Unknown218 { get; set; }
			[TagElement]
			public int Unknown21C { get; set; }
			[TagElement]
			public int Unknown220 { get; set; }
			[TagElement]
			public byte[] Unknown224 { get; set; }
			[TagElement]
			public int Unknown238 { get; set; }
			[TagElement]
			public int Unknown23C { get; set; }
			[TagElement]
			public int Unknown240 { get; set; }
			[TagElement]
			public int Unknown244 { get; set; }
			[TagElement]
			public List<TagBlock6> Unknown248 { get; set; }
			[TagElement]
			public List<TagBlock7> Unknown254 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown260 { get; set; }

			[TagStructure(Size = 0x2)]
			public class TagBlock1
			{
				[TagElement]
				public short Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x3C)]
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
			}

			[TagStructure(Size = 0x84)]
			public class TagBlock3
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public List<TagBlock4> Unknown10 { get; set; }
				[TagElement]
				public List<TagBlock5> Unknown1C { get; set; }
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

				[TagStructure(Size = 0x18)]
				public class TagBlock4
				{
					[TagElement]
					public HaloTag Unknown0 { get; set; }
					[TagElement]
					public int Unknown10 { get; set; }
					[TagElement]
					public int Unknown14 { get; set; }
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
			}

			[TagStructure(Size = 0x10)]
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
			}

			[TagStructure(Size = 0x40)]
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
		}
	}
}
