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
		public float MaximumVitality;
		public HaloTag Effect;
		public HaloTag Sound;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public HaloTag CrackBitmap;
		public HaloTag HoleBitmap;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
	}
}
