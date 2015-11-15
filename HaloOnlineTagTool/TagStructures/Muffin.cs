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
	[TagStructure(Class = "mffn", Size = 0x38)]
	public class Muffin
	{
		public HaloTag Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public List<UnknownBlock> Unknown6;
		public List<UnknownBlock2> Unknown7;

		[TagStructure(Size = 0x8)]
		public class UnknownBlock
		{
			public StringId Name;
			public short Unknown;
			public short Unknown2;
		}

		[TagStructure(Size = 0x70)]
		public class UnknownBlock2
		{
			public short Unknown;
			public short Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public byte[] Unknown7;
			public uint Unknown8;
			public byte[] Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public HaloTag Unknown18;
		}
	}
}
