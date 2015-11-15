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
	[TagStructure(Class = "cfxs", Size = 0x170)]
	public class CameraFxSettings
	{
		public ushort Flags;
		public short Unknown;
		public float OverexposureAmount;
		public float OverexposureUnknown;
		public float OverexposureUnknown2;
		public float BrightnessAmount;
		public float BrightnessUnknown;
		public float BrightnessUnknown2;
		public float BrightnessUnknown3;
		public ushort Flags2;
		public short Unknown2;
		public uint Unknown3;
		public ushort Flags3;
		public short Unknown4;
		public uint Unknown5;
		public ushort Flags4;
		public short Unknown6;
		public float Base;
		public float Min;
		public float Max;
		public ushort Flags5;
		public short Unknown7;
		public float Base2;
		public float Min2;
		public float Max2;
		public ushort Flags6;
		public short Unknown8;
		public float Base3;
		public float Min3;
		public float Max3;
		public ushort Flags7;
		public short Unknown9;
		public float Red;
		public float Green;
		public float Blue;
		public ushort Flags8;
		public short Unknown10;
		public float Red2;
		public float Green2;
		public float Blue2;
		public ushort Flags9;
		public short Unknown11;
		public float Red3;
		public float Green3;
		public float Blue3;
		public ushort Flags10;
		public short Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public ushort Flags11;
		public short Unknown16;
		public uint Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public ushort Flags12;
		public short Unknown20;
		public uint Unknown21;
		public uint Unknown22;
		public uint Unknown23;
		public int Unknown24;
		public ushort Flags13;
		public short Unknown25;
		public float Base4;
		public float Min4;
		public float Max4;
		public ushort Flags14;
		public short Unknown26;
		public float Base5;
		public float Min5;
		public float Max5;
		public ushort Flags15;
		public short Unknown27;
		public uint Unknown28;
		public uint Unknown29;
		public uint Unknown30;
		public ushort Flags16;
		public short Unknown31;
		public uint Unknown32;
		public List<UnknownBlock> Unknown33;
		public List<UnknownBlock2> Unknown34;
		public List<UnknownBlock3> Unknown35;
		public List<UnknownBlock4> Unknown36;
		public List<UnknownBlock5> Unknown37;
		public List<UnknownBlock6> Unknown38;
		public ushort Flags17;
		public short Unknown39;
		public uint Unknown40;
		public uint Unknown41;
		public float ColorR;
		public float ColorG;
		public float ColorB;
		public uint Unknown42;
		public uint Unknown43;
		public uint Unknown44;
		public uint Unknown45;
		public uint Unknown46;

		[TagStructure(Size = 0x58)]
		public class UnknownBlock
		{
			public uint Unknown;
			public int Unknown2;
			public byte[] Unknown3;
			public byte[] Unknown4;
			public byte[] Unknown5;
			public byte[] Unknown6;
		}

		[TagStructure(Size = 0xC)]
		public class UnknownBlock2
		{
			public int Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock3
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock4
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
		}

		[TagStructure(Size = 0x94)]
		public class UnknownBlock5
		{
			public int Unknown;
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
			public uint Unknown36;
			public uint Unknown37;
		}

		[TagStructure(Size = 0x28)]
		public class UnknownBlock6
		{
			public int Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
		}
	}
}
