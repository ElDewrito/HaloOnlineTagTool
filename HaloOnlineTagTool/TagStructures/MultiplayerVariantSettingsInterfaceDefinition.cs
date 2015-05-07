using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "goof", Size = 0x10)]
	public class MultiplayerVariantSettingsInterfaceDefinition
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown4 { get; set; }

		[TagStructure(Size = 0x14)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public List<TagBlock1> Unknown8 { get; set; }

			[TagStructure(Size = 0x3C)]
			public class TagBlock1
			{
				[TagElement]
				public HaloTag Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown10 { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public HaloTag Unknown2C { get; set; }
			}
		}
	}
}
