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
	[TagStructure(Class = "matg", Size = 0x608, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "matg", Size = 0x618, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class Globals
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
		public uint Unknown36;
		public uint Unknown37;
		public uint Unknown38;
		public uint Unknown39;
		public uint Unknown40;
		public uint Unknown41;
		public uint Unknown42;
		public uint Unknown43;
		public uint Unknown44;
		public List<HavokCleanupResource> HavokCleanupResources;
		public List<SoundGlobal> SoundGlobals;
		public List<AiGlobal> AiGlobals;
		public HaloTag AiGlobals2;
		public List<DamageTableBlock> DamageTable;
		public uint Unknown45;
		public uint Unknown46;
		public uint Unknown47;
		public List<Sound> Sounds;
		public List<CameraBlock> Camera;
		public List<PlayerControlBlock> PlayerControl;
		public List<DifficultyBlock> Difficulty;
		public List<Grenade> Grenades;
		public uint Unknown48;
		public uint Unknown49;
		public uint Unknown50;
		public List<InterfaceTag> InterfaceTags;
		public uint Unknown51;
		public uint Unknown52;
		public uint Unknown53;
		public uint Unknown54;
		public uint Unknown55;
		public uint Unknown56;
		public List<PlayerInformationBlock> PlayerInformation;
		public List<PlayerRepresentationBlock> PlayerRepresentation;
		public uint Unknown57;
		public uint Unknown58;
		public uint Unknown59;
		public List<FallingDamageBlock> FallingDamage;
		public List<UnknownBlock> Unknown60;
		public List<Material> Materials;
		public HaloTag MultiplayerGlobals;
		public HaloTag SurvivalGlobals;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public HaloTag ArmorGlobals;
		public List<CinematicAnchor> CinematicAnchors;
		public List<MetagameGlobal> MetagameGlobals;
		public uint Unknown61;
		public uint Unknown62;
		public uint Unknown63;
		public uint Unknown64;
		public uint Unknown65;
		public uint Unknown66;
		public uint Unknown67;
		public uint Unknown68;
		public uint Unknown69;
		public uint Unknown70;
		public uint Unknown71;
		public uint Unknown72;
		public uint Unknown73;
		public uint Unknown74;
		public uint Unknown75;
		public uint Unknown76;
		public uint Unknown77;
		public uint Unknown78;
		public uint Unknown79;
		public uint Unknown80;
		public uint Unknown81;
		public uint Unknown82;
		public uint Unknown83;
		public uint Unknown84;
		public uint Unknown85;
		public uint Unknown86;
		public uint Unknown87;
		public uint Unknown88;
		public uint Unknown89;
		public uint Unknown90;
		public uint Unknown91;
		public uint Unknown92;
		public uint Unknown93;
		public uint Unknown94;
		public uint Unknown95;
		public uint Unknown96;
		public uint Unknown97;
		public uint Unknown98;
		public uint Unknown99;
		public uint Unknown100;
		public uint Unknown101;
		public uint Unknown102;
		public uint Unknown103;
		public uint Unknown104;
		public uint Unknown105;
		public uint Unknown106;
		public uint Unknown107;
		public uint Unknown108;
		public uint Unknown109;
		public uint Unknown110;
		public uint Unknown111;
		public uint Unknown112;
		public uint Unknown113;
		public uint Unknown114;
		public uint Unknown115;
		public uint Unknown116;
		public uint Unknown117;
		public uint Unknown118;
		public uint Unknown119;
		public uint Unknown120;
		public uint Unknown121;
		public uint Unknown122;
		public uint Unknown123;
		public uint Unknown124;
		public uint Unknown125;
		public uint Unknown126;
		public uint Unknown127;
		public uint Unknown128;
		public uint Unknown129;
		public uint Unknown130;
		public uint Unknown131;
		public uint Unknown132;
		public uint Unknown133;
		public uint Unknown134;
		public uint Unknown135;
		public uint Unknown136;
		public uint Unknown137;
		public uint Unknown138;
		public uint Unknown139;
		public uint Unknown140;
		public uint Unknown141;
		public uint Unknown142;
		public uint Unknown143;
		public uint Unknown144;
		public uint Unknown145;
		public uint Unknown146;
		public uint Unknown147;
		public uint Unknown148;
		public uint Unknown149;
		public uint Unknown150;
		public uint Unknown151;
		public uint Unknown152;
		public uint Unknown153;
		public uint Unknown154;
		public uint Unknown155;
		public uint Unknown156;
		public uint Unknown157;
		public uint Unknown158;
		public uint Unknown159;
		public uint Unknown160;
		public uint Unknown161;
		public uint Unknown162;
		public uint Unknown163;
		public uint Unknown164;
		public uint Unknown165;
		public uint Unknown166;
		public uint Unknown167;
		public uint Unknown168;
		public uint Unknown169;
		public uint Unknown170;
		public uint Unknown171;
		public uint Unknown172;
		public uint Unknown173;
		public uint Unknown174;
		public uint Unknown175;
		public uint Unknown176;
		public uint Unknown177;
		public uint Unknown178;
		public uint Unknown179;
		public uint Unknown180;
		public uint Unknown181;
		public uint Unknown182;
		public uint Unknown183;
		public uint Unknown184;
		public uint Unknown185;
		public uint Unknown186;
		public uint Unknown187;
		public uint Unknown188;
		public uint Unknown189;
		public uint Unknown190;
		public uint Unknown191;
		public uint Unknown192;
		public uint Unknown193;
		public uint Unknown194;
		public uint Unknown195;
		public uint Unknown196;
		public uint Unknown197;
		public uint Unknown198;
		public uint Unknown199;
		public uint Unknown200;
		public uint Unknown201;
		public uint Unknown202;
		public uint Unknown203;
		public uint Unknown204;
		public uint Unknown205;
		public uint Unknown206;
		public uint Unknown207;
		public uint Unknown208;
		public uint Unknown209;
		public uint Unknown210;
		public uint Unknown211;
		public uint Unknown212;
		public uint Unknown213;
		public uint Unknown214;
		public uint Unknown215;
		public uint Unknown216;
		public uint Unknown217;
		public uint Unknown218;
		public uint Unknown219;
		public uint Unknown220;
		public uint Unknown221;
		public uint Unknown222;
		public uint Unknown223;
		public uint Unknown224;
		public uint Unknown225;
		public uint Unknown226;
		public uint Unknown227;
		public uint Unknown228;
		public uint Unknown229;
		public uint Unknown230;
		public uint Unknown231;
		public uint Unknown232;
		public uint Unknown233;
		public uint Unknown234;
		public uint Unknown235;
		public uint Unknown236;
		public uint Unknown237;
		public uint Unknown238;
		public uint Unknown239;
		public uint Unknown240;
		public uint Unknown241;
		public uint Unknown242;
		public uint Unknown243;
		public uint Unknown244;
		public uint Unknown245;
		public uint Unknown246;
		public uint Unknown247;
		public uint Unknown248;
		public uint Unknown249;
		public uint Unknown250;
		public uint Unknown251;
		public uint Unknown252;
		public uint Unknown253;
		public uint Unknown254;
		public uint Unknown255;
		public uint Unknown256;
		public uint Unknown257;
		public uint Unknown258;
		public uint Unknown259;
		public uint Unknown260;
		public uint Unknown261;
		public uint Unknown262;
		public uint Unknown263;
		public uint Unknown264;
		public HaloTag RasterizerGlobals;
		public HaloTag DefaultCameraEffect;
		public HaloTag PodiumDefinition;
		public HaloTag DefaultWind;
		public HaloTag DefaultDamageEffect;
		public HaloTag DefaultCollisionDamage;
		public StringId UnknownMaterial;
		public short UnknownGlobalMaterialIndex;
		public short Unknown265;
		public HaloTag EffectGlobals;
		public HaloTag GameProgressionGlobals;
		public HaloTag AchievementGlobals;
		public HaloTag InputGlobals;
		public uint Unknown266;
		public uint Unknown267;
		public uint Unknown268;
		public uint Unknown269;
		public byte[] Unknown270;
		public uint Unknown271;
		public uint Unknown272;
		public uint Unknown273;
		public uint Unknown274;
		public uint Unknown275;
		public List<DamageReportingType> DamageReportingTypes;
		public uint Unknown276;

		[TagStructure(Size = 0x10)]
		public class HavokCleanupResource
		{
			public HaloTag ObjectCleanupEffect;
		}

		[TagStructure(Size = 0x60)]
		public class SoundGlobal
		{
			public HaloTag SoundClasses;
			public HaloTag SoundEffects;
			public HaloTag SoundMix;
			public HaloTag SoundCombatDialogueConstants;
			public HaloTag SoundGlobalPropagation;
			public HaloTag GfxUiSounds;
		}

		[TagStructure(Size = 0x144)]
		public class AiGlobal
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public float DangerBroadlyFacing;
			public float DangerShootingNear;
			public float DangerShootingAt;
			public float DangerExtremelyClose;
			public float DangerShieldDamage;
			public float DangerExtendedShieldDamage;
			public float DangerBodyDamage;
			public float DangerExtendedBodyDamage;
			public HaloTag GlobalDialogue;
			public float DefaultMissionDialogueSoundEffect;
			public float JumpDown;
			public float JumpStep;
			public float JumpCrouch;
			public float JumpStand;
			public float JumpStorey;
			public float JumpTower;
			public float MaxJumpDownHeightDown;
			public float MaxJumpDownHeightStep;
			public float MaxJumpDownHeightCrouch;
			public float MaxJumpDownHeightStand;
			public float MaxJumpDownHeightStorey;
			public float MaxJumpDownHeightTower;
			public float HoistStepMin;
			public float HoistStepMax;
			public float HoistCrouchMin;
			public float HoistCrouchMax;
			public float HoistStandMin;
			public float HoistStandMax;
			public float VaultStepMin;
			public float VaultStepMax;
			public float VaultCrouchMin;
			public float VaultCrouchMax;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public List<GravemindProperty> GravemindProperties;
			public float ScaryTargetThreshold;
			public float ScaryWeaponThreshold;
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
			public List<Style> Styles;
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
			public uint Unknown38;

			[TagStructure(Size = 0xC)]
			public class GravemindProperty
			{
				public float MinimumRetreatTime;
				public float IdealRetreatTime;
				public float MaximumRetreatTime;
			}

			[TagStructure(Size = 0x10)]
			public class Style
			{
				public HaloTag Style2;
			}
		}

		[TagStructure(Size = 0xC)]
		public class DamageTableBlock
		{
			public List<DamageGroup> DamageGroups;

			[TagStructure(Size = 0x10)]
			public class DamageGroup
			{
				public StringId Name;
				public List<ArmorModifier> ArmorModifiers;

				[TagStructure(Size = 0x8)]
				public class ArmorModifier
				{
					public StringId Name;
					public float DamageMultiplier;
				}
			}
		}

		[TagStructure(Size = 0x10)]
		public class Sound
		{
			public HaloTag SoundObsolete;
		}

		[TagStructure(Size = 0xA4)]
		public class CameraBlock
		{
			public HaloTag DefaultUnitCameraTrack;
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
			public short Unknown25;
			public short Unknown26;
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
			public uint Unknown38;
		}

		[TagStructure(Size = 0x70, MaxVersion = EngineVersion.V10_1_449175_Live)]
		[TagStructure(Size = 0x78, MinVersion = EngineVersion.V11_1_498295_Live)]
		public class PlayerControlBlock
		{
			public float MagnetismFriction;
			public float MagnetismAdhesion;
			public float InconsequentialTargetScale;
			[MaxVersion(EngineVersion.V10_1_449175_Live)] public float CrosshairLocationX;
			[MaxVersion(EngineVersion.V10_1_449175_Live)] public float CrosshairLocationY;
			[MinVersion(EngineVersion.V11_1_498295_Live)] public List<CrosshairLocation> CrosshairLocations;
			public float SecondsToStart;
			public float SecondsToFullSpeed;
			public float DecayRate;
			public float FullSpeedMultiplierS1X;
			public float PeggedMagnitude;
			public float PeggedAngularThreshold;
			public uint Unknown;
			public uint Unknown2;
			[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown3;
			public float LookDefaultPitchRate;
			public float LookDefaultYawRate;
			public float LookPegThreshold;
			public float LookYawAccelerationTime;
			public float LookYawAccelerationScale;
			public float LookPitchAccelerationTime;
			public float LookPitchAccelerationScale;
			public float LookAutolevelingScale;
			public uint Unknown4;
			public uint Unknown5;
			public float GravityScale;
			public short Unknown6;
			public short MinimumAutolevelingTicks;
			public List<LookFunctionBlock> LookFunction;

			[TagStructure(Size = 0x28)]
			public class CrosshairLocation
			{
				public float DefaultCrosshairLocationY;
				public uint Unknown;
				public float CenteredCrosshairLocationY;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
				public uint Unknown6;
				public uint Unknown7;
			}

			[TagStructure(Size = 0x4)]
			public class LookFunctionBlock
			{
				public float Scale;
			}
		}

		[TagStructure(Size = 0x284)]
		public class DifficultyBlock
		{
			public float EasyEnemyDamage;
			public float NormalEnemyDamage;
			public float HardEnemyDamage;
			public float ImpossibleEnemyDamage;
			public float EasyEnemyVitality;
			public float NormalEnemyVitality;
			public float HardEnemyVitality;
			public float ImpossibleEnemyVitality;
			public float EasyEnemyShield;
			public float NormalEnemyShield;
			public float HardEnemyShield;
			public float ImpossibleEnemyShield;
			public float EasyEnemyRecharge;
			public float NormalEnemyRecharge;
			public float HardEnemyRecharge;
			public float ImpossibleEnemyRecharge;
			public float EasyFriendDamage;
			public float NormalFriendDamage;
			public float HardFriendDamage;
			public float ImpossibleFriendDamage;
			public float EasyFriendVitality;
			public float NormalFriendVitality;
			public float HardFriendVitality;
			public float ImpossibleFriendVitality;
			public float EasyFriendShield;
			public float NormalFriendShield;
			public float HardFriendShield;
			public float ImpossibleFriendShield;
			public float EasyFriendRecharge;
			public float NormalFriendRecharge;
			public float HardFriendRecharge;
			public float ImpossibleFriendRecharge;
			public float EasyInfectionForms;
			public float NormalInfectionForms;
			public float HardInfectionForms;
			public float ImpossibleInfectionForms;
			public float EasyUnknown;
			public float NormalUnknown;
			public float HardUnknown;
			public float ImpossibleUnknown;
			public float EasyRateOfFire;
			public float NormalRateOfFire;
			public float HardRateOfFire;
			public float ImpossibleRateOfFire;
			public float EasyProjectileError;
			public float NormalProjectileError;
			public float HardProjectileError;
			public float ImpossibleProjectileError;
			public float EasyBurstError;
			public float NormalBurstError;
			public float HardBurstError;
			public float ImpossibleBurstError;
			public float EasyTargetDelay;
			public float NormalTargetDelay;
			public float HardTargetDelay;
			public float ImpossibleTargetDelay;
			public float EasyBurstSeparation;
			public float NormalBurstSeparation;
			public float HardBurstSeparation;
			public float ImpossibleBurstSeparation;
			public float EasyTargetTracking;
			public float NormalTargetTracking;
			public float HardTargetTracking;
			public float ImpossibleTargetTracking;
			public float EasyTargetLeading;
			public float NormalTargetLeading;
			public float HardTargetLeading;
			public float ImpossibleTargetLeading;
			public float EasyOverchargeChance;
			public float NormalOverchargeChance;
			public float HardOverchargeChance;
			public float ImpossibleOverchargeChance;
			public float EasySpecialFireDelay;
			public float NormalSpecialFireDelay;
			public float HardSpecialFireDelay;
			public float ImpossibleSpecialFireDelay;
			public float EasyGuidanceVsPlayer;
			public float NormalGuidanceVsPlayer;
			public float HardGuidanceVsPlayer;
			public float ImpossibleGuidanceVsPlayer;
			public float EasyMeleeDelayBase;
			public float NormalMeleeDelayBase;
			public float HardMeleeDelayBase;
			public float ImpossibleMeleeDelayBase;
			public float EasyMeleeDelayScale;
			public float NormalMeleeDelayScale;
			public float HardMeleeDelayScale;
			public float ImpossibleMeleeDelayScale;
			public float EasyUnknown2;
			public float NormalUnknown2;
			public float HardUnknown2;
			public float ImpossibleUnknown2;
			public float EasyGrenadeChanceScale;
			public float NormalGrenadeChanceScale;
			public float HardGrenadeChanceScale;
			public float ImpossibleGrenadeChanceScale;
			public float EasyGrenadeTimerScale;
			public float NormalGrenadeTimerScale;
			public float HardGrenadeTimerScale;
			public float ImpossibleGrenadeTimerScale;
			public float EasyUnknown3;
			public float NormalUnknown3;
			public float HardUnknown3;
			public float ImpossibleUnknown3;
			public float EasyUnknown4;
			public float NormalUnknown4;
			public float HardUnknown4;
			public float ImpossibleUnknown4;
			public float EasyUnknown5;
			public float NormalUnknown5;
			public float HardUnknown5;
			public float ImpossibleUnknown5;
			public float EasyMajorUpgradeNormal;
			public float NormalMajorUpgradeNormal;
			public float HardMajorUpgradeNormal;
			public float ImpossibleMajorUpgradeNormal;
			public float EasyMajorUpgradeFew;
			public float NormalMajorUpgradeFew;
			public float HardMajorUpgradeFew;
			public float ImpossibleMajorUpgradeFew;
			public float EasyMajorUpgradeMany;
			public float NormalMajorUpgradeMany;
			public float HardMajorUpgradeMany;
			public float ImpossibleMajorUpgradeMany;
			public float EasyPlayerVehicleRamChance;
			public float NormalPlayerVehicleRamChance;
			public float HardPlayerVehicleRamChance;
			public float ImpossiblePlayerVehicleRamChance;
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
		}

		[TagStructure(Size = 0x44)]
		public class Grenade
		{
			public short MaximumCount;
			public short Unknown;
			public HaloTag ThrowingEffect;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public HaloTag Equipment;
			public HaloTag Projectile;
		}

		[TagStructure(Size = 0x12C)]
		public class InterfaceTag
		{
			public HaloTag Spinner;
			public HaloTag Obsolete;
			public HaloTag ScreenColorTable;
			public HaloTag HudColorTable;
			public HaloTag EditorColorTable;
			public HaloTag DialogColorTable;
			public HaloTag MotionSensorSweepBitmap;
			public HaloTag MotionSensorSweepBitmapMask;
			public HaloTag MultiplayerHudBitmap;
			public HaloTag HudDigitsDefinition;
			public HaloTag MotionSensorBlipBitmap;
			public HaloTag InterfaceGooMap1;
			public HaloTag InterfaceGooMap2;
			public HaloTag InterfaceGooMap3;
			public HaloTag MainMenuUiGlobals;
			public HaloTag SinglePlayerUiGlobals;
			public HaloTag MultiplayerUiGlobals;
			public HaloTag HudGlobals;
			public List<GfxUiString> GfxUiStrings;

			[TagStructure(Size = 0x30)]
			public class GfxUiString
			{
				[TagField(Length = 32)] public string Name;
				public HaloTag Strings;
			}
		}

		[TagStructure(Size = 0xCC)]
		public class PlayerInformationBlock
		{
			public float WalkingSpeed;
			public float RunForward;
			public float RunBackward;
			public float RunSideways;
			public float RunAcceleration;
			public float SneakForward;
			public float SneakBackward;
			public float SneakSideways;
			public float SneakAcceleration;
			public float AirborneAcceleration;
			public float GrenadeOriginX;
			public float GrenadeOriginY;
			public float GrenadeOriginZ;
			public float StunMovementPenalty;
			public float StunTurningPenalty;
			public float StunJumpingPenalty;
			public float MinimumStunTime;
			public float MaximumStunTime;
			public float FirstPersonIdleTimeMin;
			public float FirstPersonIdleTimeMax;
			public float FirstPersonSkipFraction;
			public uint Unknown;
			public HaloTag Unknown2;
			public HaloTag Unknown3;
			public HaloTag Unknown4;
			public int BinocularsZoomCount;
			public float BinocularZoomRangeMin;
			public float BinocularZoomRangeMax;
			public uint Unknown5;
			public uint Unknown6;
			public HaloTag FlashlightOn;
			public HaloTag FlashlightOff;
			public HaloTag DefaultDamageResponse;
		}

		[TagStructure(Size = 0x6C)]
		public class PlayerRepresentationBlock
		{
			public StringId Name;
			public uint Flags;
			public HaloTag FirstPersonHands;
			public HaloTag FirstPersonBody;
			public HaloTag ThirdPersonUnit;
			public StringId ThirdPersonVariant;
			public HaloTag BinocularsZoomInSound;
			public HaloTag BinocularsZoomOutSound;
			public HaloTag Unknown;
		}

		[TagStructure(Size = 0x78)]
		public class FallingDamageBlock
		{
			public float HarmfulFallingDistanceMin;
			public float HarmfulFallingDistanceMax;
			public HaloTag FallingDamage;
			public HaloTag Unknown;
			public HaloTag SoftLanding;
			public HaloTag HardLanding;
			public HaloTag ScriptDamage;
			public float MaximumFallingDistance;
			public HaloTag DistanceDamage;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
		}

		[TagStructure(Size = 0xC)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}

		[TagStructure(Size = 0x178)]
		public class Material
		{
			public StringId Name;
			public StringId ParentName;
			public short ParentIndex;
			public ushort Flags;
			public StringId GeneralArmor;
			public StringId SpecificArmor;
			public uint Unknown;
			public float Friction;
			public float Restitution;
			public float Density;
			public List<WaterDragProperty> WaterDragProperties;
			public HaloTag BreakableSurface;
			public HaloTag SoundSweetenerSmall;
			public HaloTag SoundSweetenerMedium;
			public HaloTag SoundSweetenerLarge;
			public HaloTag SoundSweetenerRolling;
			public HaloTag SoundSweetenerGrinding;
			public HaloTag SoundSweetenerMeleeSmall;
			public HaloTag SoundSweetenerMeleeMedium;
			public HaloTag SoundSweetenerMeleeLarge;
			public HaloTag EffectSweetenerSmall;
			public HaloTag EffectSweetenerMedium;
			public HaloTag EffectSweetenerLarge;
			public HaloTag EffectSweetenerRolling;
			public HaloTag EffectSweetenerGrinding;
			public HaloTag EffectSweetenerMelee;
			public HaloTag WaterRippleSmall;
			public HaloTag WaterRippleMedium;
			public HaloTag WaterRippleLarge;
			public uint SweetenerInheritanceFlags;
			public HaloTag MaterialEffects;
			public List<WaterInteractionBlock> WaterInteraction;
			public uint Unknown2;
			public short Unknown3;
			public short Unknown4;

			[TagStructure(Size = 0x28)]
			public class WaterDragProperty
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
			}

			[TagStructure(Size = 0xC)]
			public class WaterInteractionBlock
			{
				public StringId SurfaceName;
				public StringId SubmergedName;
				public short SurfaceIndex;
				public short SubmergedIndex;
			}
		}

		[TagStructure(Size = 0x18)]
		public class CinematicAnchor
		{
			public HaloTag CinematicAnchor2;
			public uint Unknown;
			public uint Unknown2;
		}

		[TagStructure(Size = 0x98)]
		public class MetagameGlobal
		{
			public List<Medal> Medals;
			public List<DifficultyBlock> Difficulty;
			public List<PrimarySkull> PrimarySkulls;
			public List<SecondarySkull> SecondarySkulls;
			public int Unknown;
			public int DeathPenalty;
			public int BetrayalPenalty;
			public int Unknown2;
			public float MultikillWindow;
			public float EmpWindow;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public int FirstWeaponSpree;
			public int SecondWeaponSpree;
			public int KillingSpree;
			public int KillingFrenzy;
			public int RunningRiot;
			public int Rampage;
			public int Untouchable;
			public int Invincible;
			public int DoubleKill;
			public int TripleKill;
			public int Overkill;
			public int Killtacular;
			public int Killtrocity;
			public int Killimanjaro;
			public int Killtastrophe;
			public int Killpocalypse;
			public int Killionaire;

			[TagStructure(Size = 0x10)]
			public class Medal
			{
				public float Multiplier;
				public int AwardedPoints;
				public int MedalUptime;
				public StringId EventName;
			}

			[TagStructure(Size = 0x4)]
			public class DifficultyBlock
			{
				public float Multiplier;
			}

			[TagStructure(Size = 0x4)]
			public class PrimarySkull
			{
				public float Multiplier;
			}

			[TagStructure(Size = 0x4)]
			public class SecondarySkull
			{
				public float Multiplier;
			}
		}

		[TagStructure(Size = 0x24)]
		public class DamageReportingType
		{
			public short Index;
			public short Version;
			[TagField(Length = 32)] public string Name;
		}
	}
}
