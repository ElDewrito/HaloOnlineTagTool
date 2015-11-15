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
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public byte[] Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public byte[] Unknown7;
		public uint Unknown8;
	}
}
