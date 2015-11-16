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
	[TagStructure(Class = "drdf", Size = 0x10)]
	public class DamageResponseDefinition
	{
		public List<Respons> Responses;
		public uint Unknown;

		[TagStructure(Size = 0xC0)]
		public class Respons
		{
			public ResponseTypeValue ResponseType;
			public short Unknown;
			public short Unknown2;
			public short Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public float Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public float Unknown10;
			public float Unknown11;
			public short Unknown12;
			public short Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public short Unknown18;
			public short Unknown19;
			public float Unknown20;
			public float Unknown21;
			public float Unknown22;
			public float Unknown23;
			public float Unknown24;
			public float Unknown25;
			public float Unknown26;
			public float LowFrequencyVibrationDuration;
			public byte[] LowFrequencyVibrationFunction;
			public float HighFrequencyVibrationDuration;
			public byte[] HighFrequencyVibrationFunction;
			public float Duration;
			public FadeFunctionValue FadeFunction;
			public short Unknown27;
			public Angle Rotation;
			public float Pushback;
			public float JitterMin;
			public float JitterMax;
			public float Duration2;
			public FalloffFunctionValue FalloffFunction;
			public short Unknown28;
			public float RandomTranslation;
			public Angle RandomRotation;
			public WobbleFunctionValue WobbleFunction;
			public short Unknown29;
			public float WobbleFunctionPeriod;
			public float WobbleWeight;

			public enum ResponseTypeValue : short
			{
				Shielded,
				Unshielded,
				All,
			}

			public enum FadeFunctionValue : short
			{
				Linear,
				Late,
				VeryLate,
				Early,
				VeryEarly,
				Cosine,
				Zero,
				One,
			}

			public enum FalloffFunctionValue : short
			{
				Linear,
				Late,
				VeryLate,
				Early,
				VeryEarly,
				Cosine,
				Zero,
				One,
			}

			public enum WobbleFunctionValue : short
			{
				One,
				Zero,
				Cosine,
				CosineVariablePeriod,
				DiagonalWave,
				DiagonalWaveVariablePeriod,
				Slide,
				SlideVariablePeriod,
				Noise,
				Jitter,
				Wander,
				Spark,
			}
		}
	}
}
