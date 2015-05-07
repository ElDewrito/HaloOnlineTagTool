using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "beam", Size = 0x10)]
	public class BeamSystem
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }
		[TagElement]
		public int UnknownC { get; set; }

		[TagStructure(Size = 0x208)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown4 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown14 { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown20 { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown2C { get; set; }
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
			public byte[] Unknown6C { get; set; }
			[TagElement]
			public int Unknown80 { get; set; }
			[TagElement]
			public int Unknown84 { get; set; }
			[TagElement]
			public int Unknown88 { get; set; }
			[TagElement]
			public byte[] Unknown8C { get; set; }
			[TagElement]
			public int UnknownA0 { get; set; }
			[TagElement]
			public int UnknownA4 { get; set; }
			[TagElement]
			public int UnknownA8 { get; set; }
			[TagElement]
			public byte[] UnknownAC { get; set; }
			[TagElement]
			public int UnknownC0 { get; set; }
			[TagElement]
			public int UnknownC4 { get; set; }
			[TagElement]
			public int UnknownC8 { get; set; }
			[TagElement]
			public byte[] UnknownCC { get; set; }
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
			public byte[] UnknownFC { get; set; }
			[TagElement]
			public int Unknown110 { get; set; }
			[TagElement]
			public int Unknown114 { get; set; }
			[TagElement]
			public int Unknown118 { get; set; }
			[TagElement]
			public byte[] Unknown11C { get; set; }
			[TagElement]
			public int Unknown130 { get; set; }
			[TagElement]
			public int Unknown134 { get; set; }
			[TagElement]
			public int Unknown138 { get; set; }
			[TagElement]
			public byte[] Unknown13C { get; set; }
			[TagElement]
			public int Unknown150 { get; set; }
			[TagElement]
			public int Unknown154 { get; set; }
			[TagElement]
			public int Unknown158 { get; set; }
			[TagElement]
			public byte[] Unknown15C { get; set; }
			[TagElement]
			public int Unknown170 { get; set; }
			[TagElement]
			public int Unknown174 { get; set; }
			[TagElement]
			public int Unknown178 { get; set; }
			[TagElement]
			public byte[] Unknown17C { get; set; }
			[TagElement]
			public int Unknown190 { get; set; }
			[TagElement]
			public int Unknown194 { get; set; }
			[TagElement]
			public int Unknown198 { get; set; }
			[TagElement]
			public byte[] Unknown19C { get; set; }
			[TagElement]
			public int Unknown1B0 { get; set; }
			[TagElement]
			public int Unknown1B4 { get; set; }
			[TagElement]
			public int Unknown1B8 { get; set; }
			[TagElement]
			public byte[] Unknown1BC { get; set; }
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
			public List<TagBlock6> Unknown1E4 { get; set; }
			[TagElement]
			public List<TagBlock7> Unknown1F0 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown1FC { get; set; }

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
