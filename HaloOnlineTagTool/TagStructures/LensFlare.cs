using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "lens", Size = 0x9C)]
	public class LensFlare
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
		public List<TagBlock0> Unknown44 { get; set; }
		[TagElement]
		public int Unknown50 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown54 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown60 { get; set; }
		[TagElement]
		public int Unknown6C { get; set; }
		[TagElement]
		public int Unknown70 { get; set; }
		[TagElement]
		public int Unknown74 { get; set; }
		[TagElement]
		public List<TagBlock3> Unknown78 { get; set; }
		[TagElement]
		public List<TagBlock4> Unknown84 { get; set; }
		[TagElement]
		public int Unknown90 { get; set; }
		[TagElement]
		public int Unknown94 { get; set; }
		[TagElement]
		public int Unknown98 { get; set; }

		[TagStructure(Size = 0x8C)]
		public class TagBlock0
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
			public byte[] Unknown28 { get; set; }
			[TagElement]
			public byte[] Unknown3C { get; set; }
			[TagElement]
			public byte[] Unknown50 { get; set; }
			[TagElement]
			public byte[] Unknown64 { get; set; }
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
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock1
		{
			[TagElement]
			public byte[] Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x14)]
		public class TagBlock2
		{
			[TagElement]
			public byte[] Unknown0 { get; set; }
		}

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

		[TagStructure(Size = 0x14)]
		public class TagBlock4
		{
			[TagElement]
			public byte[] Unknown0 { get; set; }
		}
	}
}
