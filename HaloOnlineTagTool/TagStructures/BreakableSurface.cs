using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "bsdt", Size = 0x60)]
	public class BreakableSurface
	{
		public uint Unknown;
		public HaloTag Unknown2;
		public HaloTag Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public HaloTag Unknown8;
		public HaloTag Unknown9;
		public uint Unknown10;
		public uint Unknown11;
		public uint Unknown12;
	}
}
