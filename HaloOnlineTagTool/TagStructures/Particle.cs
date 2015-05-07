using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "prt3", Size = 0x1A0)]
	public class Particle
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown4 { get; set; }
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
		public HaloTag Unknown3C { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown4C { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown58 { get; set; }
		[TagElement]
		public List<TagBlock4> Unknown64 { get; set; }
		[TagElement]
		public int Unknown70 { get; set; }
		[TagElement]
		public int Unknown74 { get; set; }
		[TagElement]
		public int Unknown78 { get; set; }
		[TagElement]
		public int Unknown7C { get; set; }
		[TagElement]
		public byte[] Unknown80 { get; set; }
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
		public byte[] UnknownE0 { get; set; }
		[TagElement]
		public int UnknownF4 { get; set; }
		[TagElement]
		public int UnknownF8 { get; set; }
		[TagElement]
		public int UnknownFC { get; set; }
		[TagElement]
		public int Unknown100 { get; set; }
		[TagElement]
		public byte[] Unknown104 { get; set; }
		[TagElement]
		public int Unknown118 { get; set; }
		[TagElement]
		public int Unknown11C { get; set; }
		[TagElement]
		public int Unknown120 { get; set; }
		[TagElement]
		public byte[] Unknown124 { get; set; }
		[TagElement]
		public int Unknown138 { get; set; }
		[TagElement]
		public int Unknown13C { get; set; }
		[TagElement]
		public int Unknown140 { get; set; }
		[TagElement]
		public byte[] Unknown144 { get; set; }
		[TagElement]
		public int Unknown158 { get; set; }
		[TagElement]
		public int Unknown15C { get; set; }
		[TagElement]
		public HaloTag Unknown160 { get; set; }
		[TagElement]
		public int Unknown170 { get; set; }
		[TagElement]
		public int Unknown174 { get; set; }
		[TagElement]
		public int Unknown178 { get; set; }
		[TagElement]
		public List<TagBlock11> Unknown17C { get; set; }
		[TagElement]
		public List<TagBlock12> Unknown188 { get; set; }
		[TagElement]
		public int Unknown194 { get; set; }
		[TagElement]
		public int Unknown198 { get; set; }
		[TagElement]
		public int Unknown19C { get; set; }

		[TagStructure(Size = 0x14)]
		public class TagBlock0
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
		}

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
			public HaloTag Unknown8 { get; set; }
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
			public List<TagBlock3> Unknown30 { get; set; }

			[TagStructure(Size = 0x24)]
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
				public byte[] Unknown10 { get; set; }
			}
		}

		[TagStructure(Size = 0x84)]
		public class TagBlock4
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock5> Unknown10 { get; set; }
			[TagElement]
			public List<TagBlock6> Unknown1C { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
			[TagElement]
			public int Unknown30 { get; set; }
			[TagElement]
			public int Unknown34 { get; set; }
			[TagElement]
			public List<TagBlock7> Unknown38 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown44 { get; set; }
			[TagElement]
			public List<TagBlock9> Unknown50 { get; set; }
			[TagElement]
			public List<TagBlock10> Unknown5C { get; set; }
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
			public class TagBlock5
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
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

			[TagStructure(Size = 0x4)]
			public class TagBlock7
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x8)]
			public class TagBlock8
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}

			[TagStructure(Size = 0x4)]
			public class TagBlock9
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x24)]
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
				public byte[] Unknown10 { get; set; }
			}
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

		[TagStructure(Size = 0x10)]
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
		}
	}
}
