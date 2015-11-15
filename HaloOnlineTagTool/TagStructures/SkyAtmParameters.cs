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
		public uint Unknown;
		public HaloTag Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public uint Unknown10;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown11;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown12;
		public List<UnknownBlock> Unknown13;
		public List<UnknownBlock2> Unknown14;

		[TagStructure(Size = 0xA4)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public uint Unknown18;
			public uint Unknown19;
			public uint Unknown20;
			public uint Unknown21;
			public uint Unknown22;
			public uint Unknown23;
			public uint Unknown24;
			public uint Unknown25;
			public uint Unknown26;
			public uint Unknown27;
			public uint Unknown28;
			public uint Unknown29;
			public uint Unknown30;
			public uint Unknown31;
			public uint Unknown32;
			public uint Unknown33;
			public uint Unknown34;
			public uint Unknown35;
			public HaloTag Unknown36;
			public uint Unknown37;
			public uint Unknown38;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock2
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
		}
	}
}
