using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "rmdf", Size = 0x5C)]
	public class RenderMethodDefinition
	{
		[TagElement]
		public HaloTag Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown10 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown1C { get; set; }
		[TagElement]
		public List<TagBlock5> Unknown28 { get; set; }
		[TagElement]
		public HaloTag Unknown34 { get; set; }
		[TagElement]
		public HaloTag Unknown44 { get; set; }
		[TagElement]
		public int Unknown54 { get; set; }
		[TagElement]
		public int Unknown58 { get; set; }

		[TagStructure(Size = 0x18)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown4 { get; set; }
			[TagElement]
			public int Unknown10 { get; set; }
			[TagElement]
			public int Unknown14 { get; set; }

			[TagStructure(Size = 0x1C)]
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
			}
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock2
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown4 { get; set; }

			[TagStructure(Size = 0x10)]
			public class TagBlock3
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public List<TagBlock4> Unknown4 { get; set; }

				[TagStructure(Size = 0x4)]
				public class TagBlock4
				{
					[TagElement]
					public int Unknown0 { get; set; }
				}
			}
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
}
