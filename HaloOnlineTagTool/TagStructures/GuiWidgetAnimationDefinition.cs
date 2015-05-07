using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "wgan", Size = 0x80)]
	public class GuiWidgetAnimationDefinition
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public int Unknown4 { get; set; }
		[TagElement]
		public HaloTag Unknown8 { get; set; }
		[TagElement]
		public HaloTag Unknown18 { get; set; }
		[TagElement]
		public HaloTag Unknown28 { get; set; }
		[TagElement]
		public HaloTag Unknown38 { get; set; }
		[TagElement]
		public HaloTag Unknown48 { get; set; }
		[TagElement]
		public HaloTag Unknown58 { get; set; }
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
	}
}
