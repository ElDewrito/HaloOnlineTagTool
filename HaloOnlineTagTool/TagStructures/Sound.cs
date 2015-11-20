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
	[TagStructure(Class = "snd!", Size = 0xD8, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "snd!", Size = 0xD4, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class Sound
	{
		public uint Flags;
		public uint Unknown;
		public uint Unknown2;
		public SoundClassValue SoundClass;
		public SampleRateValue SampleRate;
		public sbyte Unknown3;
		public ImportTypeValue ImportType;
		public uint FieldDisableFlags;
		public float DistanceA;
		public float DistanceB;
		public float DistanceC;
		public float DistanceD;
		public float SkipFraction;
		public float MaximumBendPerSecond;
		public float GainBase;
		public float GainVariance;
		public short RandomPitchBoundsMin;
		public short RandomPitchBoundsMax;
		public Angle InnerConeAngle;
		public Angle OuterConeAngle;
		public float OuterConeGain;
		public uint Flags2;
		public Angle Azimuth;
		public float PositionalGain;
		public float FirstPersonGain;
		public float GainModifierMin;
		public float GainModifierMax;
		public short PitchModifierMin;
		public short PitchModifierMax;
		public float SkipFractionModifierMin;
		public float SkipFractionModifierMax;
		public short Unknown4;
		public EncodingValue Encoding;
		public sbyte Compression;
		public List<Rule> Rules;
		public List<RuntimeTimer> RuntimeTimers;
		public int Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public uint Unknown10;
		public List<PitchRange> PitchRanges;
		public List<CustomPlayback> CustomPlaybacks;
		public List<ExtraInfoBlock> ExtraInfo;
		public List<Language> Languages;
		public ResourceReference Resource;
		public int UselessPadding;
		[MaxVersion(EngineVersion.V10_1_449175_Live)] public uint Unknown11;

		public enum SoundClassValue : sbyte
		{
			ProjectileImpact,
			ProjectileDetonation,
			ProjectileFlyby,
			ProjectileDetonationLod,
			WeaponFire,
			WeaponReady,
			WeaponReload,
			WeaponEmpty,
			WeaponCharge,
			WeaponOverheat,
			WeaponIdle,
			WeaponMelee,
			WeaponAnimation,
			ObjectImpacts,
			ParticleImpacts,
			WeaponFireLod,
			WeaponFireLodFar,
			Unused2Impacts,
			UnitFootsteps,
			UnitDialog,
			UnitAnimation,
			UnitUnused,
			VehicleCollision,
			VehicleEngine,
			VehicleAnimation,
			VehicleEngineLod,
			DeviceDoor,
			DeviceUnused0,
			DeviceMachinery,
			DeviceStationary,
			DeviceUnused1,
			DeviceUnused2,
			Music,
			AmbientNature,
			AmbientMachinery,
			AmbientStationary,
			HugeAss,
			ObjectLooping,
			CinematicMusic,
			PlayerArmor,
			UnknownUnused1,
			AmbientFlock,
			NoPad,
			NoPadStationary,
			Arg,
			CortanaMission,
			CortanaGravemindChannel,
			MissionDialog,
			CinematicDialog,
			ScriptedCinematicFoley,
			Hud,
			GameEvent,
			Ui,
			Test,
			MultilingualTest,
			AmbientNatureDetails,
			AmbientMachineryDetails,
			InsideSurroundTail,
			OutsideSurroundTail,
			VehicleDetonation,
			AmbientDetonation,
			FirstPersonInside,
			FirstPersonOutside,
			FirstPersonAnywhere,
			UiPda,
		}

		public enum SampleRateValue : sbyte
		{
			_22khz,
			_44khz,
			_32khz,
		}

		public enum ImportTypeValue : sbyte
		{
			Unknown,
			SingleShot,
			SingleLayer,
			MultiLayer,
		}

		public enum EncodingValue : sbyte
		{
			Mono,
			Stereo,
			Surround,
			_51Surround,
		}

		[TagStructure(Size = 0x10)]
		public class Rule
		{
			public short PitchRangeIndex;
			public short MaximumPlayingCount;
			public float SuppressionTime;
			public int Unknown;
			public int Unknown2;
		}

		[TagStructure(Size = 0x4)]
		public class RuntimeTimer
		{
			public int Unknown;
		}

		[TagStructure(Size = 0x38)]
		public class PitchRange
		{
			public StringId Name;
			public short NaturalPitch;
			public short Unknown;
			public short BendBoundsMin;
			public short BendBoundsMax;
			public short MaxGainPitchBoundsMin;
			public short MaxGainPitchBoundsMax;
			public short UnknownBoundsMin;
			public short UnknownBoundsMax;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public List<Permutation> Permutations;

			[TagStructure(Size = 0x2C)]
			public class Permutation
			{
				public StringId Name;
				public float SkipFractionMin;
				public float SkipFractionMax;
				public uint SampleSize;
				public uint Unknown;
				public uint Unknown2;
				public List<PermutationChunk> PermutationChunks;
				public uint Unknown3;
				public uint Unknown4;

				[TagStructure(Size = 0x14)]
				public class PermutationChunk
				{
					public uint FileOffset;
					public byte Flags;
					public byte ChunkSizeLeftmostByte;
					public ushort ChunkSize;
					public int RuntimeIndex;
					public int UnknownA;
					public int UnknownSize;
				}
			}
		}

		[TagStructure(Size = 0x54)]
		public class CustomPlayback
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public List<UnknownBlock> Unknown7;
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

			[TagStructure(Size = 0x48)]
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
			}
		}

		[TagStructure(Size = 0x28)]
		public class ExtraInfoBlock
		{
			public List<LanguagePermutationInfoBlock> LanguagePermutationInfo;
			public List<EncodedPermuationSectionBlock> EncodedPermuationSection;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;

			[TagStructure(Size = 0xC)]
			public class LanguagePermutationInfoBlock
			{
				public List<RawInfoBlockBlock> RawInfoBlock;

				[TagStructure(Size = 0x7C)]
				public class RawInfoBlockBlock
				{
					public StringId SkipFractionName;
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
					public List<UnknownBlock> Unknown19;
					public short Compression;
					public sbyte Language;
					public sbyte Unknown20;
					public uint SampleCount;
					public uint ResourceSampleOffset;
					public uint ResourceSampleSize;
					public uint Unknown21;
					public uint Unknown22;
					public uint Unknown23;
					public uint Unknown24;
					public int Unknown25;

					[TagStructure(Size = 0x18)]
					public class UnknownBlock
					{
						public uint Unknown;
						public uint Unknown2;
						public uint Unknown3;
						public uint Unknown4;
						public uint Unknown5;
						public uint Unknown6;
					}
				}
			}

			[TagStructure(Size = 0x2C)]
			public class EncodedPermuationSectionBlock
			{
				public byte[] EncodedData;
				public List<SoundDialogueInfoBlock> SoundDialogueInfo;
				public List<UnknownBlock> Unknown;

				[TagStructure(Size = 0x10)]
				public class SoundDialogueInfoBlock
				{
					public uint MouthDataOffset;
					public uint MouthDataLength;
					public uint LipsyncDataOffset;
					public uint LipsynceDataLength;
				}

				[TagStructure(Size = 0xC)]
				public class UnknownBlock
				{
					public uint Unknown;
					public uint Unknown2;
					public uint Unknown3;
				}
			}
		}

		[TagStructure(Size = 0x1C)]
		public class Language
		{
			public LanguageValue Language2;
			public List<UnknownABlock> UnknownA;
			public List<UnknownBBlock> UnknownB;

			public enum LanguageValue : int
			{
				English,
				Japanese,
				German,
				French,
				Spanish,
				LatinAmericanSpanish,
				Italian,
				Korean,
				ChineseTraditional,
				ChineseSimplified,
				Portuguese,
				Polish,
			}

			[TagStructure(Size = 0x2)]
			public class UnknownABlock
			{
				public short Unknown;
			}

			[TagStructure(Size = 0x4)]
			public class UnknownBBlock
			{
				public short UnknownAStartIndex;
				public short UnknownACount;
			}
		}
	}
}
