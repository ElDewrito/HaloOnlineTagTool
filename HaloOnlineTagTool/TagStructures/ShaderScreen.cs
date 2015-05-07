using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "rmss", Size = 0x54)]
	public class ShaderScreen
	{
		[TagElement]
		public HaloTag Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown10 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown1C { get; set; }
		[TagElement]
		public List<TagBlock3> Unknown28 { get; set; }
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

		[TagStructure(Size = 0x2)]
		public class TagBlock0
		{
			[TagElement]
			public short Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x3C)]
		public class TagBlock1
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
			public List<TagBlock2> Unknown30 { get; set; }

			[TagStructure(Size = 0x24)]
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
				public byte[] Unknown10 { get; set; }
			}
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

			[TagStructure(Size = 0x4)]
			public class TagBlock6
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x8)]
			public class TagBlock7
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}

			[TagStructure(Size = 0x4)]
			public class TagBlock8
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x24)]
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
				public byte[] Unknown10 { get; set; }
			}
		}
	}
}
