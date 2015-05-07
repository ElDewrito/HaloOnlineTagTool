using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "uise", Size = 0x150)]
	public class UserInterfaceSoundsDefinition
	{
		[TagElement]
		public HaloTag Unknown0 { get; set; }
		[TagElement]
		public HaloTag Unknown10 { get; set; }
		[TagElement]
		public HaloTag Unknown20 { get; set; }
		[TagElement]
		public HaloTag Unknown30 { get; set; }
		[TagElement]
		public HaloTag Unknown40 { get; set; }
		[TagElement]
		public HaloTag Unknown50 { get; set; }
		[TagElement]
		public int Unknown60 { get; set; }
		[TagElement]
		public int Unknown64 { get; set; }
		[TagElement]
		public int Unknown68 { get; set; }
		[TagElement]
		public int Unknown6C { get; set; }
		[TagElement]
		public HaloTag Unknown70 { get; set; }
		[TagElement]
		public HaloTag Unknown80 { get; set; }
		[TagElement]
		public HaloTag Unknown90 { get; set; }
		[TagElement]
		public HaloTag UnknownA0 { get; set; }
		[TagElement]
		public HaloTag UnknownB0 { get; set; }
		[TagElement]
		public HaloTag UnknownC0 { get; set; }
		[TagElement]
		public HaloTag UnknownD0 { get; set; }
		[TagElement]
		public HaloTag UnknownE0 { get; set; }
		[TagElement]
		public HaloTag UnknownF0 { get; set; }
		[TagElement]
		public HaloTag Unknown100 { get; set; }
		[TagElement]
		public HaloTag Unknown110 { get; set; }
		[TagElement]
		public HaloTag Unknown120 { get; set; }
		[TagElement]
		public HaloTag Unknown130 { get; set; }
		[TagElement]
		public int Unknown140 { get; set; }
		[TagElement]
		public int Unknown144 { get; set; }
		[TagElement]
		public int Unknown148 { get; set; }
		[TagElement]
		public int Unknown14C { get; set; }
	}
}
