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
	[TagStructure(Class = "lens", Size = 0x9C)]
	public class LensFlare
	{
		public Angle FalloffAngle;
		public Angle CutoffAngle;
		public float OcclusionRadius;
		public float Unknown;
		public short Unknown2;
		public short Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public float NearFadeDistance;
		public float FarFadeDistance;
		public HaloTag Bitmap;
		public short Unknown6;
		public short Unknown7;
		public short Unknown8;
		public short Unknown9;
		public Angle RotationFunctionScale;
		public short Unknown10;
		public short Unknown11;
		public List<Reflection> Reflections;
		public uint Unknown12;
		public List<BrightnessBlock> Brightness;
		public List<ColorBlock> Color;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public List<UnknownBlock> Unknown16;
		public List<UnknownBlock2> Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public uint Unknown20;

		[TagStructure(Size = 0x8C)]
		public class Reflection
		{
			public uint Unknown;
			public uint Unknown2;
			public HaloTag Bitmap;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public byte[] Function;
			public byte[] Function2;
			public byte[] Function3;
			public byte[] Function4;
			public float TintModulationFactor;
			public float TintColorR;
			public float TintColorG;
			public float TintColorB;
			public uint Unknown7;
		}

		[TagStructure(Size = 0x14)]
		public class BrightnessBlock
		{
			public byte[] Function;
		}

		[TagStructure(Size = 0x14)]
		public class ColorBlock
		{
			public byte[] Function;
		}

		[TagStructure(Size = 0x24)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public byte[] Function;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock2
		{
			public byte[] Function;
		}
	}
}
