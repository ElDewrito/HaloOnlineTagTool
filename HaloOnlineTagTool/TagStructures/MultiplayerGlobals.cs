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
	[TagStructure(Class = "mulg", Size = 0x18)]
	public class MultiplayerGlobals
	{
		public List<UniversalBlock> Universal;
		public List<RuntimeBlock> Runtime;

		[TagStructure(Size = 0xD8)]
		public class UniversalBlock
		{
			public HaloTag RandomPlayerNameStrings;
			public HaloTag TeamNameStrings;
			public List<SpartanArmorCustomizationBlock> SpartanArmorCustomization;
			public List<EliteArmorCustomizationBlock> EliteArmorCustomization;
			public List<EquipmentBlock> Equipment;
			public List<UnknownBlock> Unknown;
			public HaloTag MultiplayerStrings;
			public HaloTag SandboxUiStrings;
			public HaloTag SandboxUiProperties;
			public List<GameVariantWeapon> GameVariantWeapons;
			public List<GameVariantVehicle> GameVariantVehicles;
			public List<GameVariantEquipmentBlock> GameVariantEquipment;
			public List<WeaponSet> WeaponSets;
			public List<VehicleSet> VehicleSets;
			public List<PodiumBlock> Podium;
			public HaloTag EngineSettings;

			[TagStructure(Size = 0x14)]
			public class SpartanArmorCustomizationBlock
			{
				public StringId ArmorObjectRegion;
				public StringId BipedRegion;
				public List<Permutation> Permutations;

				[TagStructure(Size = 0x30)]
				public class Permutation
				{
					public StringId Name;
					public HaloTag ThirdPersonArmorObject;
					public HaloTag FirstPersonArmorModel;
					public short Unknown;
					public short Unknown2;
					public StringId ParentAttachMarker;
					public StringId ChildAttachMarker;
				}
			}

			[TagStructure(Size = 0x14)]
			public class EliteArmorCustomizationBlock
			{
				public StringId PieceRegion;
				public StringId CharacterRegion;
				public List<Permutation> Permutations;

				[TagStructure(Size = 0x30)]
				public class Permutation
				{
					public StringId Name;
					public HaloTag ThirdPersonArmorObject;
					public HaloTag FirstPersonArmorModel;
					public short Unknown;
					public short Unknown2;
					public StringId ParentAttachMarker;
					public StringId ChildAttachMarker;
				}
			}

			[TagStructure(Size = 0x18)]
			public class EquipmentBlock
			{
				public StringId Name;
				public HaloTag Equipment;
				public short Unknown;
				public short Unknown2;
			}

			[TagStructure(Size = 0x8)]
			public class UnknownBlock
			{
				public int Unknown;
				public int Unknown2;
			}

			[TagStructure(Size = 0x18)]
			public class GameVariantWeapon
			{
				public StringId Name;
				public float RandomChance;
				public HaloTag Weapon;
			}

			[TagStructure(Size = 0x14)]
			public class GameVariantVehicle
			{
				public StringId Name;
				public HaloTag Vehicle;
			}

			[TagStructure(Size = 0x14)]
			public class GameVariantEquipmentBlock
			{
				public StringId Name;
				public HaloTag Grenade;
			}

			[TagStructure(Size = 0x10)]
			public class WeaponSet
			{
				public StringId Name;
				public List<Substitution> Substitutions;

				[TagStructure(Size = 0x8)]
				public class Substitution
				{
					public StringId OriginalWeapon;
					public StringId SubstitutedWeapon;
				}
			}

			[TagStructure(Size = 0x10)]
			public class VehicleSet
			{
				public StringId Name;
				public List<Substitution> Substitutions;

				[TagStructure(Size = 0x8)]
				public class Substitution
				{
					public StringId OriginalVehicle;
					public StringId SubstitutedVehicle;
				}
			}

			[TagStructure(Size = 0x30)]
			public class PodiumBlock
			{
				public HaloTag AnimationGraph;
				public StringId DefaultUnarmed;
				public StringId DefaultArmed;
				public List<StanceAnimation> StanceAnimations;
				public List<MoveAnimation> MoveAnimations;

				[TagStructure(Size = 0x34)]
				public class StanceAnimation
				{
					[TagField(Length = 32)] public string Name;
					public StringId BaseAnimation;
					public StringId LoopAnimation;
					public StringId UnarmedTransition;
					public StringId ArmedTransition;
					public float Unknown;
				}

				[TagStructure(Size = 0x50)]
				public class MoveAnimation
				{
					[TagField(Length = 32)] public string Name;
					public StringId InAnimation;
					public StringId LoopAnimation;
					public StringId OutAnimation;
					public int Unknown;
					public HaloTag PrimaryWeapon;
					public HaloTag SecondaryWeapon;
				}
			}
		}

		[TagStructure(Size = 0x2A8)]
		public class RuntimeBlock
		{
			public HaloTag SandboxEditorUnit;
			public HaloTag SandboxEditorObject;
			public HaloTag Flag;
			public HaloTag Ball;
			public HaloTag Bomb;
			public HaloTag VipZone;
			public HaloTag InGameStrings;
			public HaloTag Unknown;
			public HaloTag Unknown2;
			public HaloTag Unknown3;
			public HaloTag Unknown4;
			public HaloTag Unknown5;
			public List<Sound> Sounds;
			public List<LoopingSound> LoopingSounds;
			public List<UnknownEvent> UnknownEvents;
			public List<GeneralEvent> GeneralEvents;
			public List<FlavorEvent> FlavorEvents;
			public List<SlayerEvent> SlayerEvents;
			public List<CtfEvent> CtfEvents;
			public List<OddballEvent> OddballEvents;
			public List<KingOfTheHillEvent> KingOfTheHillEvents;
			public List<VipEvent> VipEvents;
			public List<JuggernautEvent> JuggernautEvents;
			public List<TerritoriesEvent> TerritoriesEvents;
			public List<AssaultEvent> AssaultEvents;
			public List<InfectionEvent> InfectionEvents;
			public int DefaultFragGrenadeCount;
			public int DefaultPlasmaGrenadeCount;
			public List<MultiplayerConstant> MultiplayerConstants;
			public List<StateRespons> StateResponses;
			public HaloTag ScoreboardEmblemBitmap;
			public HaloTag ScoreboardDeadEmblemBitmap;
			public HaloTag DefaultShapeShader;
			public HaloTag Unknown6;
			public HaloTag CtfIntroUi;
			public HaloTag SlayerIntroUi;
			public HaloTag OddballIntroUi;
			public HaloTag KingOfTheHillIntroUi;
			public HaloTag SandboxIntroUi;
			public HaloTag VipIntroUi;
			public HaloTag JuggernautIntroUi;
			public HaloTag TerritoriesIntroUi;
			public HaloTag AssaultIntroUi;
			public HaloTag InfectionIntroUi;
			public HaloTag MenuMusic1;
			public HaloTag MenuMusic2;
			public HaloTag MenuMusic3;
			public HaloTag Unknown7;

			[TagStructure(Size = 0x10)]
			public class Sound
			{
				public HaloTag Sound2;
			}

			[TagStructure(Size = 0x10)]
			public class LoopingSound
			{
				public HaloTag LoopingSound2;
			}

			[TagStructure(Size = 0x10C)]
			public class UnknownEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class GeneralEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class FlavorEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class SlayerEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class CtfEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class OddballEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class KingOfTheHillEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class VipEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class JuggernautEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class TerritoriesEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class AssaultEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x10C)]
			public class InfectionEvent
			{
				public ushort Flags;
				public TypeValue Type;
				public StringId Event;
				public AudienceValue Audience;
				public short Unknown;
				public TeamValue Team;
				public short Unknown2;
				public StringId DisplayString;
				public StringId DisplayMedal;
				public uint Unknown3;
				public uint Unknown4;
				public RequiredFieldValue RequiredField;
				public ExcludedAudienceValue ExcludedAudience;
				public RequiredField2Value RequiredField2;
				public ExcludedAudience2Value ExcludedAudience2;
				public StringId PrimaryString;
				public int PrimaryStringDuration;
				public StringId PluralDisplayString;
				public float SoundDelayAnnouncerOnly;
				public ushort SoundFlags;
				public short Unknown5;
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
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;

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

			[TagStructure(Size = 0x220)]
			public class MultiplayerConstant
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
				public List<Weapon> Weapons;
				public List<Vehicle> Vehicles;
				public List<Projectile> Projectiles;
				public List<EquipmentBlock> Equipment;
				public float Unknown27;
				public float Unknown28;
				public float Unknown29;
				public float Unknown30;
				public float Unknown31;
				public float Unknown32;
				public float Unknown33;
				public float Unknown34;
				public float Unknown35;
				public float Unknown36;
				public float Unknown37;
				public float Unknown38;
				public float Unknown39;
				public float Unknown40;
				public float Unknown41;
				public float Unknown42;
				public float Unknown43;
				public float Unknown44;
				public float Unknown45;
				public float Unknown46;
				public float Unknown47;
				public float Unknown48;
				public float Unknown49;
				public float Unknown50;
				public float Unknown51;
				public float Unknown52;
				public float Unknown53;
				public float Unknown54;
				public float Unknown55;
				public float Unknown56;
				public float Unknown57;
				public float Unknown58;
				public float Unknown59;
				public float Unknown60;
				public float Unknown61;
				public float Unknown62;
				public float Unknown63;
				public float Unknown64;
				public float Unknown65;
				public float Unknown66;
				public float MaximumRandomSpawnBias;
				public float TeleporterRechargeTime;
				public float GrenadeDangerWeight;
				public float GrenadeDangerInnerRadius;
				public float GrenadeDangerOuterRadius;
				public float GrenadeDangerLeadTime;
				public float VehicleDangerMinimumSpeed;
				public float VehicleDangerWeight;
				public float VehicleDangerRadius;
				public float VehicleDangerLeadTime;
				public float VehicleNearbyPlayerDistance;
				public HaloTag HillShader;
				public float Unknown67;
				public float Unknown68;
				public float Unknown69;
				public float Unknown70;
				public HaloTag BombExplodeEffect;
				public HaloTag Unknown71;
				public HaloTag BombExplodeDamageEffect;
				public HaloTag BombDefuseEffect;
				public HaloTag CursorImpactEffect;
				public StringId BombDefusalString;
				public StringId BlockedTeleporterString;
				public int Unknown72;
				public StringId Unknown73;
				public StringId SpawnAllowedDefaultRespawnString;
				public StringId SpawnAtPlayerLookingAtSelfString;
				public StringId SpawnAtPlayerLookingAtTargetString;
				public StringId SpawnAtPlayerLookingAtPotentialTargetString;
				public StringId SpawnAtTerritoryAllowedLookingAtTargetString;
				public StringId SpawnAtTerritoryAllowedLookingAtPotentialTargetString;
				public StringId PlayerOutOfLivesString;
				public StringId InvalidSpawnTargetString;
				public StringId TargettedPlayerEnemiesNearbyString;
				public StringId TargettedPlayerUnfriendlyTeamString;
				public StringId TargettedPlayerIsDeadString;
				public StringId TargettedPlayerInCombatString;
				public StringId TargettedPlayerTooFarFromOwnedFlagString;
				public StringId NoAvailableNetpointsString;
				public StringId NetpointContestedString;

				[TagStructure(Size = 0x20)]
				public class Weapon
				{
					public HaloTag Weapon2;
					public float Unknown;
					public float Unknown2;
					public float Unknown3;
					public float Unknown4;
				}

				[TagStructure(Size = 0x20)]
				public class Vehicle
				{
					public HaloTag Vehicle2;
					public float Unknown;
					public float Unknown2;
					public float Unknown3;
					public float Unknown4;
				}

				[TagStructure(Size = 0x1C)]
				public class Projectile
				{
					public HaloTag Projectile2;
					public float Unknown;
					public float Unknown2;
					public float Unknown3;
				}

				[TagStructure(Size = 0x14)]
				public class EquipmentBlock
				{
					public HaloTag Equipment;
					public float Unknown;
				}
			}

			[TagStructure(Size = 0x24)]
			public class StateRespons
			{
				public ushort Flags;
				public short Unknown;
				public StateValue State;
				public short Unknown2;
				public StringId FreeForAllMessage;
				public StringId TeamMessage;
				public HaloTag Unknown3;
				public uint Unknown4;

				public enum StateValue : short
				{
					WaitingForSpaceToClear,
					Observing,
					RespawningSoon,
					SittingOut,
					OutOfLives,
					PlayingWinning,
					PlayingTied,
					PlayingLosing,
					GameOverWon,
					GameOverTied,
					GameOverLost,
					GameOverTied2,
					YouHaveFlag,
					EnemyHasFlag,
					FlagNotHome,
					CarryingOddball,
					YouAreJuggernaut,
					YouControlHill,
					SwitchingSidesSoon,
					PlayerRecentlyStarted,
					YouHaveBomb,
					FlagContested,
					BombContested,
					LimitedLivesMultiple,
					LimitedLivesSingle,
					LimitedLivesFinal,
					PlayingWinningUnlimited,
					PlayingTiedUnlimited,
					PlayingLosingUnlimited,
				}
			}
		}
	}
}
