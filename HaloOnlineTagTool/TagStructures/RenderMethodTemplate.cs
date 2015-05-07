using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "rmt2", Size = 0x84)]
	public class RenderMethodTemplate
	{
		[TagElement]
		public HaloTag Unknown0 { get; set; }
		[TagElement]
		public HaloTag Unknown10 { get; set; }
		[TagElement]
		public int Unknown20 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown24 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown30 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown3C { get; set; }
		[TagElement]
		public List<TagBlock3> Unknown48 { get; set; }
		[TagElement]
		public List<TagBlock4> Unknown54 { get; set; }
		[TagElement]
		public List<TagBlock5> Unknown60 { get; set; }
		[TagElement]
		public List<TagBlock6> Unknown6C { get; set; }
		[TagElement]
		public int Unknown78 { get; set; }
		[TagElement]
		public int Unknown7C { get; set; }
		[TagElement]
		public int Unknown80 { get; set; }

		[TagStructure(Size = 0x2)]
		public class TagBlock0
		{
			[TagElement]
			public short Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x1C)]
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
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock2
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock3
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock4
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock5
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock6
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}
	}
}
