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
	[TagStructure(Class = "bink", Size = 0x18)]
	public class Bink
	{
		public int FrameCount;
		public ResourceReference Resource;
		public int UselessPadding;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
	}
}
