using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	// TODO: Convert over a newer plugin and make this inherit from GameObject once versioning issues are sorted out
	[TagStructure(Class = "ctrl", Size = 0x1FC)]
	public class DeviceControl
	{
		public int Unknown0;
		public int Unknown4;
		public int Unknown8;
		public int UnknownC;
		public int Unknown10;
		public int Unknown14;
		public int Unknown18;
		public int Unknown1C;
		public int Unknown20;
		public int Unknown24;
		public int Unknown28;
		public int Unknown2C;
		public int Unknown30;
		public HaloTag Unknown34;
		public int Unknown44;
		public int Unknown48;
		public int Unknown4C;
		public int Unknown50;
		public int Unknown54;
		public int Unknown58;
		public int Unknown5C;
		public int Unknown60;
		public int Unknown64;
		public int Unknown68;
		public int Unknown6C;
		public int Unknown70;
		public int Unknown74;
		public int Unknown78;
		public int Unknown7C;
		public int Unknown80;
		public int Unknown84;
		public int Unknown88;
		public int Unknown8C;
		public int Unknown90;
		public int Unknown94;
		public int Unknown98;
		public int Unknown9C;
		public int UnknownA0;
		public int UnknownA4;
		public int UnknownA8;
		public int UnknownAC;
		public int UnknownB0;
		public int UnknownB4;
		public int UnknownB8;
		public List<TagBlock0> UnknownBC;
		public int UnknownC8;
		public int UnknownCC;
		public int UnknownD0;
		public int UnknownD4;
		public int UnknownD8;
		public int UnknownDC;
		public int UnknownE0;
		public int UnknownE4;
		public int UnknownE8;
		public int UnknownEC;
		public int UnknownF0;
		public int UnknownF4;
		public int UnknownF8;
		public List<TagBlock1> UnknownFC;
		public int Unknown108;
		public int Unknown10C;
		public int Unknown110;
		public int Unknown114;
		public int Unknown118;
		public int Unknown11C;
		public int Unknown120;
		public int Unknown124;
		public int Unknown128;
		public int Unknown12C;
		public int Unknown130;
		public int Unknown134;
		public int Unknown138;
		public int Unknown13C;
		public HaloTag Unknown140;
		public HaloTag Unknown150;
		public int Unknown160;
		public int Unknown164;
		public int Unknown168;
		public int Unknown16C;
		public int Unknown170;
		public int Unknown174;
		public int Unknown178;
		public int Unknown17C;
		public int Unknown180;
		public int Unknown184;
		public int Unknown188;
		public int Unknown18C;
		public int Unknown190;
		public int Unknown194;
		public int Unknown198;
		public int Unknown19C;
		public int Unknown1A0;
		public int Unknown1A4;
		public int Unknown1A8;
		public int Unknown1AC;
		public int Unknown1B0;
		public int Unknown1B4;
		public int Unknown1B8;
		public int Unknown1BC;
		public int Unknown1C0;
		public int Unknown1C4;
		public int Unknown1C8;
		public int Unknown1CC;
		public int Unknown1D0;
		public int Unknown1D4;
		public int Unknown1D8;
		public int Unknown1DC;
		public int Unknown1E0;
		public int Unknown1E4;
		public int Unknown1E8;
		public int Unknown1EC;
		public int Unknown1F0;
		public int Unknown1F4;
		public int Unknown1F8;

		[TagStructure(Size = 0x2C)]
		public class TagBlock0
		{
			public int Unknown0;
			public int Unknown4;
			public int Unknown8;
			public int UnknownC;
			public int Unknown10;
			public byte[] Unknown14;
			public int Unknown28;
		}

		[TagStructure(Size = 0xC4)]
		public class TagBlock1
		{
			public int Unknown0;
			public int Unknown4;
			public int Unknown8;
			public int UnknownC;
			public int Unknown10;
			public int Unknown14;
			public int Unknown18;
			public int Unknown1C;
			public int Unknown20;
			public int Unknown24;
			public int Unknown28;
			public int Unknown2C;
			public int Unknown30;
			public int Unknown34;
			public int Unknown38;
			public int Unknown3C;
			public int Unknown40;
			public int Unknown44;
			public int Unknown48;
			public int Unknown4C;
			public int Unknown50;
			public int Unknown54;
			public int Unknown58;
			public int Unknown5C;
			public int Unknown60;
			public int Unknown64;
			public int Unknown68;
			public int Unknown6C;
			public int Unknown70;
			public int Unknown74;
			public int Unknown78;
			public int Unknown7C;
			public int Unknown80;
			public int Unknown84;
			public int Unknown88;
			public int Unknown8C;
			public int Unknown90;
			public int Unknown94;
			public int Unknown98;
			public int Unknown9C;
			public int UnknownA0;
			public int UnknownA4;
			public int UnknownA8;
			public int UnknownAC;
			public int UnknownB0;
			public int UnknownB4;
			public int UnknownB8;
			public int UnknownBC;
			public int UnknownC0;
		}
	}
}
