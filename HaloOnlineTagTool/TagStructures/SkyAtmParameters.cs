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
		public int Unknown;
		public HaloTag FogBitmap;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public int Unknown9;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public float Unknown10;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public int Unknown11;
		public List<AtmosphereProperty> AtmosphereProperties;
		public List<UnderwaterBlock> Underwater;

		[TagStructure(Size = 0xA4)]
		public class AtmosphereProperty
		{
			public short Unknown;
			public short Unknown2;
			public StringId Name;
			public float LightSourceY;
			public float LightSourceX;
			public float FogColorR;
			public float FogColorG;
			public float FogColorB;
			public float Brightness;
			public float FogGradientThreshold;
			public float LightIntensity;
			public float SkyInvisiblilityThroughFog;
			public float Unknown3;
			public float Unknown4;
			public float LightSourceSpread;
			public uint Unknown5;
			public float FogIntensity;
			public float Unknown6;
			public float TintCyan;
			public float TintMagenta;
			public float TintYellow;
			public float FogIntensityCyan;
			public float FogIntensityMagenta;
			public float FogIntensityYellow;
			public float BackgroundColorRed;
			public float BackgroundColorGreen;
			public float BackgroundColorBlue;
			public float TintRed;
			public float Tint2Green;
			public float Tint2Blue;
			public float FogIntensity2;
			public float StartDistance;
			public float EndDistance;
			public float FogVelocityX;
			public float FogVelocityY;
			public float FogVelocityZ;
			public HaloTag WeatherEffect;
			public uint Unknown7;
			public uint Unknown8;
		}

		[TagStructure(Size = 0x14)]
		public class UnderwaterBlock
		{
			public StringId Name;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
		}
	}
}
