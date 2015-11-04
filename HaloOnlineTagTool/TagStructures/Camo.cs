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
	[TagStructure(Class = "cmoe", Size = 0x40)]
	public class Camo
	{
		public float Unknown;
		public float Unknown2;
		public float Unknown3;
		public byte[] Unknown4;
		public float Unknown5;
		public float Unknown6;
		public byte[] Unknown7;
		public float Unknown8;
	}
}
