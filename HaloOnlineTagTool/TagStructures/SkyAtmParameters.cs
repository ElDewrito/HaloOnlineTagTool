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
	[TagStructure(Class = "skya", Size = 0x4C, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "skya", Size = 0x54, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class SkyAtmParameters
	{
		public float Unknown;
		public HaloTag Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public float Unknown11;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public float Unknown12;
		public List<UnknownBlock> Unknown13;
		public List<UnknownBlock2> Unknown14;

		[TagStructure(Size = 0xA4)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public float Unknown18;
			public float Unknown19;
			public float Unknown20;
			public float Unknown21;
			public float Unknown22;
			public float Unknown23;
			public float Unknown24;
			public float Unknown25;
			public float Unknown26;
			public float Unknown27;
			public float Unknown28;
			public float Unknown29;
			public float Unknown30;
			public float Unknown31;
			public float Unknown32;
			public float Unknown33;
			public float Unknown34;
			public float Unknown35;
			public HaloTag Unknown36;
			public float Unknown37;
			public float Unknown38;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock2
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
		}
	}
}
