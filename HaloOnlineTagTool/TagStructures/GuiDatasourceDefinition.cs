using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "dsrc", Size = 0x20)]
	public class GuiDatasourceDefinition
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
		public List<TagBlock0> Unknown10 { get; set; }
		[TagElement]
		public int Unknown1C { get; set; }

		[TagStructure(Size = 0x28)]
		public class TagBlock0
		{
			[TagElement]
			public List<TagBlock1> Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock2> UnknownC { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown18 { get; set; }
			[TagElement]
			public int Unknown24 { get; set; }

			[TagStructure(Size = 0x8)]
			public class TagBlock1
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}

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
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
			}

			[TagStructure(Size = 0x8)]
			public class TagBlock3
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}
		}
	}
}
