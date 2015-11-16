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
		public HaloTag RenderModel;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public int Unknown4;
		public List<LocationsBlock> Locations;
		public List<UnknownBlock> Unknown5;

		[TagStructure(Size = 0x8)]
		public class LocationsBlock
		{
			public StringId Name;
			public short Unknown;
			public short Unknown2;
		}

		[TagStructure(Size = 0x70)]
		public class UnknownBlock
		{
			public short Unknown;
			public short Unknown2;
			public uint Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public byte[] Unknown7;
			public float Unknown8;
			public byte[] Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public HaloTag Effect;
		}
	}
}
