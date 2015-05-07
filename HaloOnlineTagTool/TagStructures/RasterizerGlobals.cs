using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "rasg", Size = 0xBC)]
	public class RasterizerGlobals
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock1> UnknownC { get; set; }
		[TagElement]
		public HaloTag Unknown18 { get; set; }
		[TagElement]
		public HaloTag Unknown28 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown38 { get; set; }
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
		public HaloTag Unknown78 { get; set; }
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
		public int UnknownB4 { get; set; }
		[TagElement]
		public int UnknownB8 { get; set; }

		[TagStructure(Size = 0x14)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown4 { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock1
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock2
		{
			[TagElement]
			public HaloTag Unknown0 { get; set; }
			[TagElement]
			public HaloTag Unknown10 { get; set; }
		}
	}
}
