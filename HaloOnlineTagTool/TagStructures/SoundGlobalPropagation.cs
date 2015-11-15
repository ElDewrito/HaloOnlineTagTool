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
	[TagStructure(Class = "sgp!", Size = 0x50)]
	public class SoundGlobalPropagation
	{
		public HaloTag Unknown;
		public HaloTag Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public HaloTag Unknown5;
		public HaloTag Unknown6;
		public uint Unknown7;
		public uint Unknown8;
	}
}
