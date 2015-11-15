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
	[TagStructure(Class = "jpt!", Size = 0xF4)]
	public class DamageEffect
	{
		public float RadiusMin;
		public float RadiusMax;
		public float CutoffScale;
		public uint Flags;
		public SideEffectValue SideEffect;
		public CategoryValue Category;
		public uint Flags2;
		public float AreaOfEffectCoreRadius;
		public float DamageLowerBound;
		public float DamageUpperBoundMin;
		public float DamageUpperBoundMax;
		public Angle DamageInnerConeAngle;
		public Angle DamageOuterConeAngle;
		public float ActiveCamoflageDamage;
		public float Stun;
		public float MaxStun;
		public float StunTime;
		public float InstantaneousAcceleration;
		public float RiderDirectDamageScale;
		public float RiderMaxTransferDamageScale;
		public float RiderMinTransferDamageScale;
		public StringId GeneralDamage;
		public StringId SpecificDamage;
		public StringId SpecialDamage;
		public float AiStunRadius;
		public float AiStunBoundsMin;
		public float AiStunBoundsMax;
		public float ShakeRadius;
		public float EmpRadius;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public List<PlayerRespons> PlayerResponses;
		public HaloTag DamageResponse;
		public float Duration;
		public FadeFunctionValue FadeFunction;
		public short Unknown4;
		public Angle Rotation;
		public float Pushback;
		public float JitterMin;
		public float JitterMax;
		public float Duration2;
		public FalloffFunctionValue FalloffFunction;
		public short Unknown5;
		public float RandomTranslation;
		public Angle RandomRotation;
		public WobbleFunctionValue WobbleFunction;
		public short Unknown6;
		public float WobbleFunctionPeriod;
		public float WobbleWeight;
		public HaloTag Sound;
		public float ForwardVelocity;
		public float ForwardRadius;
		public float ForwardExponent;
		public float OutwardVelocity;
		public float OutwardRadius;
		public float OutwardExponent;

		public enum SideEffectValue : short
		{
			None,
			Harmless,
			LethalToTheUnsuspecting,
			Emp,
		}

		public enum CategoryValue : short
		{
			None,
			Falling,
			Bullet,
			Grenade,
			HighExplosive,
			Sniper,
			Melee,
			Flame,
			MountedWeapon,
			Vehicle,
			Plasma,
			Needle,
			Shotgun,
		}

		[TagStructure(Size = 0x70)]
		public class PlayerRespons
		{
			public ResponseTypeValue ResponseType;
			public short Unknown;
			public TypeValue Type;
			public PriorityValue Priority;
			public float Duration;
			public FadeFunctionValue FadeFunction;
			public short Unknown2;
			public float MaximumIntensity;
			public float ColorAlpha;
			public float ColorRed;
			public float ColorGreen;
			public float ColorBlue;
			public float LowFrequencyVibrationDuration;
			public byte[] LowFrequencyVibrationFunction;
			public float HighFrequencyVibrationDuration;
			public byte[] HighFrequencyVibrationFunction;
			public StringId EffectName;
			public float Duration2;
			public byte[] EffectScaleFunction;

			public enum ResponseTypeValue : short
			{
				Shielded,
				Unshielded,
				All,
			}

			public enum TypeValue : short
			{
				None,
				Lighten,
				Darken,
				Max,
				Min,
				Invert,
				Tint,
			}

			public enum PriorityValue : short
			{
				Low,
				Medium,
				High,
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
