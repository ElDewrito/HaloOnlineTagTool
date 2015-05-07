using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "wind", Size = 0x7C)]
	public class Wind
	{
		[TagElement]
		public byte[] Unknown0 { get; set; }
		[TagElement]
		public byte[] Unknown14 { get; set; }
		[TagElement]
		public byte[] Unknown28 { get; set; }
		[TagElement]
		public byte[] Unknown3C { get; set; }
		[TagElement]
		public byte[] Unknown50 { get; set; }
		[TagElement]
		public int Unknown64 { get; set; }
		[TagElement]
		public HaloTag Unknown68 { get; set; }
		[TagElement]
		public int Unknown78 { get; set; }
	}
}
