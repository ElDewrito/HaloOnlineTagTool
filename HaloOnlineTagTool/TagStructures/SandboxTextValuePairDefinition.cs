using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "jmrq", Size = 0xC)]
	public class SandboxTextValuePairDefinition
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }

		[TagStructure(Size = 0x10)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown4 { get; set; }

			[TagStructure(Size = 0x14)]
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
			}
		}
	}
}
