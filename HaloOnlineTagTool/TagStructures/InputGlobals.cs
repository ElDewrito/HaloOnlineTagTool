using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "inpg", Size = 0x34)]
	public class InputGlobals
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public int Unknown4 { get; set; }
		[TagElement]
		public byte[] Unknown8 { get; set; }
		[TagElement]
		public byte[] Unknown1C { get; set; }
		[TagElement]
		public int Unknown30 { get; set; }
	}
}
