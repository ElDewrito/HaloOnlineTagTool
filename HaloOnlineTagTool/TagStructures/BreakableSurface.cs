using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "bsdt", Size = 0x60)]
	public class BreakableSurface
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public HaloTag Unknown4 { get; set; }
		[TagElement]
		public HaloTag Unknown14 { get; set; }
		[TagElement]
		public int Unknown24 { get; set; }
		[TagElement]
		public int Unknown28 { get; set; }
		[TagElement]
		public int Unknown2C { get; set; }
		[TagElement]
		public int Unknown30 { get; set; }
		[TagElement]
		public HaloTag Unknown34 { get; set; }
		[TagElement]
		public HaloTag Unknown44 { get; set; }
		[TagElement]
		public int Unknown54 { get; set; }
		[TagElement]
		public int Unknown58 { get; set; }
		[TagElement]
		public int Unknown5C { get; set; }
	}
}
