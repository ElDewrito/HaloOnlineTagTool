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
	[TagStructure(Class = "smdt", Size = 0x48)]
	public class SurvivalModeGlobals
	{
		public uint Unknown;
		public HaloTag InGameStrings;
		public HaloTag TimerSound;
		public HaloTag TimerSoundZero;
		public List<SurvivalEvent> SurvivalEvents;
		public uint Unknown2;
		public uint Unknown3;

		[TagStructure(Size = 0x10C)]
		public class SurvivalEvent
		{
			public ushort Flags;
			public TypeValue Type;
			public StringId Event;
			public AudienceValue Audience;
			public short Unknown;
			public short Unknown2;
			public TeamValue Team;
			public StringId DisplayString;
			public StringId DisplayMedal;
			public uint Unknown3;
			public float DisplayDuration;
			public RequiredFieldValue RequiredField;
			public ExcludedAudienceValue ExcludedAudience;
			public RequiredField2Value RequiredField2;
			public ExcludedAudience2Value ExcludedAudience2;
			public StringId PrimaryString;
			public int PrimaryStringDuration;
			public StringId PluralDisplayString;
			public float SoundDelayAnnouncerOnly;
			public ushort SoundFlags;
			public short Unknown4;
			public HaloTag EnglishSound;
			public HaloTag JapaneseSound;
			public HaloTag GermanSound;
			public HaloTag FrenchSound;
			public HaloTag SpanishSound;
			public HaloTag LatinAmericanSpanishSound;
			public HaloTag ItalianSound;
			public HaloTag KoreanSound;
			public HaloTag ChineseTraditionalSound;
			public HaloTag ChineseSimplifiedSound;
			public HaloTag PortugueseSound;
			public HaloTag PolishSound;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;

			public enum TypeValue : short
			{
				General,
				Flavor,
				Slayer,
				CaptureTheFlag,
				Oddball,
				Unused,
				KingOfTheHill,
				Vip,
				Juggernaut,
				Territories,
				Assault,
				Infection,
				Survival,
				Unknown,
			}

			public enum AudienceValue : short
			{
				CausePlayer,
				CauseTeam,
				EffectPlayer,
				EffectTeam,
				All,
			}

			public enum TeamValue : short
			{
				NonePlayerOnly,
				Cause,
				Effect,
				All,
			}

			public enum RequiredFieldValue : short
			{
				None,
				CausePlayer,
				CauseTeam,
				EffectPlayer,
				EffectTeam,
			}

			public enum ExcludedAudienceValue : short
			{
				None,
				CausePlayer,
				CauseTeam,
				EffectPlayer,
				EffectTeam,
			}

			public enum RequiredField2Value : short
			{
				None,
				CausePlayer,
				CauseTeam,
				EffectPlayer,
				EffectTeam,
			}

			public enum ExcludedAudience2Value : short
			{
				None,
				CausePlayer,
				CauseTeam,
				EffectPlayer,
				EffectTeam,
			}
		}
	}
}
