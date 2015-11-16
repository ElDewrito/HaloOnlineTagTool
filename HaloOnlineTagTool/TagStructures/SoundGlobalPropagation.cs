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
		public HaloTag UnderwaterEnvironment;
		public HaloTag UnderwaterLoop;
		public uint Unknown;
		public uint Unknown2;
		public HaloTag EnterUnderater;
		public HaloTag ExitUnderwater;
		public uint Unknown3;
		public uint Unknown4;
	}
}
