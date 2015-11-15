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
	[TagStructure(Class = "inpg", Size = 0x34)]
	public class InputGlobals
	{
		public uint Unknown;
		public uint Unknown2;
		public byte[] Unknown3;
		public byte[] Unknown4;
		public uint Unknown5;
	}
}
