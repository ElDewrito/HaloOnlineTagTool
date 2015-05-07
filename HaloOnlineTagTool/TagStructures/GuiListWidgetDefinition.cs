using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "lst3", Size = 0x70)]
	public class GuiListWidgetDefinition
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
		public HaloTag Unknown1C { get; set; }
		[TagElement]
		public int Unknown2C { get; set; }
		[TagElement]
		public HaloTag Unknown30 { get; set; }
		[TagElement]
		public int Unknown40 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown44 { get; set; }
		[TagElement]
		public HaloTag Unknown50 { get; set; }
		[TagElement]
		public HaloTag Unknown60 { get; set; }

		[TagStructure(Size = 0x30)]
		public class TagBlock0
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
			public HaloTag Unknown1C { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
		}
	}
}
