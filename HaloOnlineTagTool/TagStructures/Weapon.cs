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
	[TagStructure(Class = "weap", Size = 0x384, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "weap", Size = 0x390, MaxVersion = EngineVersion.V11_1_498295_Live)]
	public class Weapon : Item
	{
		public uint Flags3;
		public uint MoreFlags;
		public StringId Unknown8;
		public SecondaryTriggerModeValue SecondaryTriggerMode;
		public short MaximumAlternateShotsLoaded;
		public float TurnOnTime;
		public float ReadyTime;
		public HaloTag ReadyEffect;
		public HaloTag ReadyDamageEffect;
		public float HeatRecoveryThreshold;
		public float OverheatedThreshold;
		public float HeatDetonationThreshold;
		public float HeatDetonationFraction;
		public float HeatLossPerSecond;
		public float HeatIllumination;
		public float OverheatedHeatLossPerSecond;
		public HaloTag Overheated;
		public HaloTag OverheatedDamageEffect;
		public HaloTag Detonation;
		public HaloTag DetonationDamageEffect2;
		public HaloTag PlayerMeleeDamage;
		public HaloTag PlayerMeleeResponse;
		public Angle DamagePyramidAnglesY;
		public Angle DamagePyramidAnglesP;
		public float DamagePyramidDepth;
		public HaloTag _1stHitDamage;
		public HaloTag _1stHitResponse;
		public HaloTag _2ndHitDamage;
		public HaloTag _2ndHitResponse;
		public HaloTag _3rdHitDamage;
		public HaloTag _3rdHitResponse;
		public HaloTag LungeMeleeDamage;
		public HaloTag LungeMeleeResponse;
		public HaloTag GunGunClangDamage;
		public HaloTag GunGunClangResponse;
		public HaloTag GunSwordClangDamage;
		public HaloTag GunSwordClangResponse;
		public HaloTag ClashEffect;
		public MeleeDamageReportingTypeValue MeleeDamageReportingType;
		public sbyte Unknown9;
		public short MagnificationLevels;
		public float MagnificationRangeMin;
		public float MagnificationRangeMax;
		public uint MagnificationFlags;
		public float WeaponSwitchReadySpeed0Default;
		public Angle AutoaimAngle;
		public float AutoaimRangeLong;
		public float AutoaimRangeShort;
		public float AutoaimSafeRadius;
		public Angle MagnetismAngle;
		public float MagnetismRangeLong;
		public float MagnetismRangeShort;
		public float MagnetismSafeRadius;
		public Angle DeviationAngle;
		public uint Unknown10;
		public uint Unknown11;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public List<TargetTrackingBlock> TargetTracking;
		public uint Unknown16;
		public uint Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public MovementPenalizedValue MovementPenalized;
		public short Unknown20;
		public float ForwardsMovementPenalty;
		public float SidewaysMovementPenalty;
		public float AiScariness;
		public float WeaponPowerOnTime;
		public float WeaponPowerOffTime;
		public HaloTag WeaponPowerOnEffect;
		public HaloTag WeaponPowerOffEffect;
		public float AgeHeatRecoveryPenalty;
		public float AgeRateOfFirePenalty;
		public float AgeMisfireStart;
		public float AgeMisfireChance;
		public HaloTag PickupSound;
		public HaloTag ZoomInSound;
		public HaloTag ZoomOutSound;
		public float ActiveCamoDing;
		public uint Unknown21;
		public uint Unknown22;
		public uint Unknown23;
		public StringId WeaponClass;
		public StringId WeaponName;
		public uint Unknown24;
		public MultiplayerWeaponTypeValue MultiplayerWeaponType;
		public WeaponTypeValue WeaponType;
		public SpecialHudVersionValue SpecialHudVersion;
		public int SpecialHudIcon;
		public List<FirstPersonBlock> FirstPerson;
		public HaloTag HudInterface;
		public List<PredictedResource> PredictedResources;
		public List<Magazine> Magazines;
		public List<Trigger> Triggers;
		public List<Barrel> Barrels;
		public uint Unknown25;
		public uint Unknown26;
		public float MaximumMovementAcceleration;
		public float MaximumMovementVelocity;
		public float MaximumTurningAcceleration;
		public float MaximumTurningVelocity;
		public HaloTag DeployedVehicle;
		public HaloTag DeployedWeapon;
		public HaloTag AgeModel;
		public HaloTag AgeWeapon;
		public HaloTag AgedMaterialEffects;
		public float HammerAgePerUse;
		public uint UnknownSwordAgePerUse;
		public float FirstPersonWeaponOffsetI;
		public float FirstPersonWeaponOffsetJ;
		public float FirstPersonWeaponOffsetK;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public List<NewFirstPersonWeaponOffset> NewFirstPersonWeaponOffsets;
		public float FirstPersonScopeSizeI;
		public float FirstPersonScopeSizeJ;
		public float ThirdPersonPitchBoundsMin;
		public float ThirdPersonPitchBoundsMax;
		public float ZoomTransitionTime;
		public float MeleeWeaponDelay;
		public float ReadyAnimationDuration;
		public StringId WeaponHolsterMarker;

		public enum SecondaryTriggerModeValue : short
		{
			Normal,
			SlavedToPrimary,
			InhibitsPrimary,
			LoadsAlternateAmmunition,
			LoadsMultiplePrimaryAmmunition,
		}

		public enum MeleeDamageReportingTypeValue : sbyte
		{
			GuardiansUnknown,
			Guardians,
			FallingDamage,
			GenericCollision,
			ArmorLockCrush,
			GenericMelee,
			GenericExplosion,
			Magnum,
			PlasmaPistol,
			Needler,
			Mauler,
			Smg,
			PlasmaRifle,
			BattleRifle,
			Carbine,
			Shotgun,
			SniperRifle,
			BeamRifle,
			AssaultRifle,
			Spiker,
			FuelRodCannon,
			MissilePod,
			RocketLauncher,
			SpartanLaser,
			BruteShot,
			Flamethrower,
			SentinelGun,
			EnergySword,
			GravityHammer,
			FragGrenade,
			PlasmaGrenade,
			SpikeGrenade,
			FirebombGrenade,
			Flag,
			Bomb,
			BombExplosion,
			Ball,
			MachinegunTurret,
			PlasmaCannon,
			PlasmaMortar,
			PlasmaTurret,
			ShadeTurret,
			Banshee,
			Ghost,
			Mongoose,
			Scorpion,
			ScorpionGunner,
			Spectre,
			SpectreGunner,
			Warthog,
			WarthogGunner,
			WarthogGaussTurret,
			Wraith,
			WraithGunner,
			Tank,
			Chopper,
			Hornet,
			Mantis,
			Prowler,
			SentinelBeam,
			SentinelRpg,
			Teleporter,
			Tripmine,
			Dmr,
		}

		[TagStructure(Size = 0x38)]
		public class TargetTrackingBlock
		{
			public List<TrackingType> TrackingTypes;
			public float AcquireTime;
			public float GraceTime;
			public float DecayTime;
			public HaloTag TrackingSound;
			public HaloTag LockedSound;

			[TagStructure(Size = 0x4)]
			public class TrackingType
			{
				public StringId TrackingType2;
			}
		}

		public enum MovementPenalizedValue : short
		{
			Always,
			WhenZoomed,
			WhenZoomedOrReloading,
		}

		public enum MultiplayerWeaponTypeValue : short
		{
			None,
			CtfFlag,
			OddballBall,
			HeadhunterHead,
			JuggernautPowerup,
		}

		public enum WeaponTypeValue : short
		{
			Undefined,
			Shotgun,
			Needler,
			PlasmaPistol,
			PlasmaRifle,
			RocketLauncher,
			EnergySword,
			SpartanLaser,
		}

		public enum SpecialHudVersionValue : int
		{
			DefaultNoOutline2 = -28,
			Default30 = 0,
			Ammo31,
			Damage32,
			Accuracy33,
			RateOfFire34,
			Range35,
			Power36,
		}

		[TagStructure(Size = 0x20)]
		public class FirstPersonBlock
		{
			public HaloTag FirstPersonModel;
			public HaloTag FirstPersonAnimations;
		}

		[TagStructure(Size = 0x8)]
		public class PredictedResource
		{
			public short Type;
			public short ResourceIndex;
			[TagField(Flags = TagFieldFlags.Short)] public HaloTag TagIndex;
		}

		[TagStructure(Size = 0x80)]
		public class Magazine
		{
			public uint Flags;
			public short RoundsRecharged;
			public short RoundsTotalInitial;
			public short RoundsTotalMaximum;
			public short RoundsTotalLoadedMaximum;
			public short MaximumRoundsHeld;
			public short Unknown;
			public float ReloadTime;
			public short RoundsReloaded;
			public short Unknown2;
			public float ChamberTime;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public HaloTag ReloadingEffect;
			public HaloTag ReloadingDamageEffect;
			public HaloTag ChamberingEffect;
			public HaloTag ChamberingDamageEffect;
			public List<MagazineEquipmentBlock> MagazineEquipment;

			[TagStructure(Size = 0x14)]
			public class MagazineEquipmentBlock
			{
				public short Rounds0ForMax;
				public short Unknown;
				public HaloTag Equipment;
			}
		}

		[TagStructure(Size = 0x90)]
		public class Trigger
		{
			public uint Flags;
			public ButtonUsedValue ButtonUsed;
			public BehaviorValue Behavior;
			public short PrimaryBarrel;
			public short SecondaryBarrel;
			public PredictionValue Prediction;
			public short Unknown;
			public float AutofireTime;
			public float AutofireThrow;
			public SecondaryActionValue SecondaryAction;
			public PrimaryActionValue PrimaryAction;
			public float ChargingTime;
			public float ChargedTime;
			public OverchargeActionValue OverchargeAction;
			public ushort ChargeFlags;
			public float ChargedIllumination;
			public float SpewTime;
			public HaloTag ChargingEffect;
			public HaloTag ChargingDamageEffect;
			public HaloTag ChargingResponse;
			public float ChargingAgeDegeneration;
			public HaloTag Unknown2;
			public HaloTag Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;

			public enum ButtonUsedValue : short
			{
				RightTrigger,
				LeftTrigger,
				MeleeAttack,
				AutomatedFire,
				RightBumper,
			}

			public enum BehaviorValue : short
			{
				Spew,
				Latch,
				LatchAutofire,
				Charge,
				LatchZoom,
				LatchRocketlauncher,
				SpewCharge,
			}

			public enum PredictionValue : short
			{
				None,
				Spew,
				Charge,
			}

			public enum SecondaryActionValue : short
			{
				Fire,
				Charge,
				Track,
				FireOther,
			}

			public enum PrimaryActionValue : short
			{
				Fire,
				Charge,
				Track,
				FireOther,
			}

			public enum OverchargeActionValue : short
			{
				None,
				Explode,
				Discharge,
			}
		}

		[TagStructure(Size = 0x1AC)]
		public class Barrel
		{
			public uint Flags;
			public float RoundsPerSecondMin;
			public float RoundsPerSecondMax;
			public float AccelerationTime;
			public float DecelerationTime;
			public float BarrelSpinScale;
			public float BlurredRateOfFire;
			public short ShotsPerFireMin;
			public short ShotsPerFireMax;
			public float FireRecoveryTime;
			public float SoftRecoveryFraction;
			public short Magazine;
			public short RoundsPerShot;
			public short MinimumRoundsLoaded;
			public short RoundsBetweenTracers;
			public StringId OptionalBarrelMarkerName;
			public PredictionTypeValue PredictionType;
			public FiringNoiseValue FiringNoise;
			public float AccelerationTime2;
			public float DecelerationTime2;
			public float DamageErrorMin;
			public float DamageErrorMax;
			public Angle BaseTurningSpeed;
			public Angle DynamicTurningSpeedMin;
			public Angle DynamicTurningSpeedMax;
			public float AccelerationTime3;
			public float DecelerationTime3;
			public uint Unknown;
			public uint Unknown2;
			public Angle MinimumError;
			public Angle ErrorAngleMin;
			public Angle ErrorAngleMax;
			public float DualWieldDamageScale;
			public DistributionFunctionValue DistributionFunction;
			public short ProjectilesPerShot;
			public Angle DistributionAngle;
			public Angle MinimumError2;
			public Angle ErrorAngleMin2;
			public Angle ErrorAngleMax2;
			public float ReloadPenalty;
			public float SwitchPenalty;
			public float ZoomPenalty;
			public float JumpPenalty;
			public List<FiringPenaltyFunctionBlock> FiringPenaltyFunction;
			public List<FiringCrouchedPenaltyFunctionBlock> FiringCrouchedPenaltyFunction;
			public List<MovingPenaltyFunctionBlock> MovingPenaltyFunction;
			public List<TurningPenaltyFunctionBlock> TurningPenaltyFunction;
			public float ErrorAngleMaximumRotation;
			public List<DualFiringPenaltyFunctionBlock> DualFiringPenaltyFunction;
			public List<DualFiringCrouchedPenaltyFunctionBlock> DualFiringCrouchedPenaltyFunction;
			public List<DualMovingPenaltyFunctionBlock> DualMovingPenaltyFunction;
			public List<DualTurningPenaltyFunctionBlock> DualTurningPenaltyFunction;
			public float DualErrorAngleMaximumRotation;
			public List<FirstPersonOffset> FirstPersonOffsets;
			public DamageReportingTypeValue DamageReportingType;
			public sbyte Unknown3;
			public short Unknown4;
			public HaloTag InitialProjectile;
			public HaloTag TrailingProjectile;
			public HaloTag DamageEffect;
			public HaloTag CrateProjectile;
			public float CrateProjectileSpeed;
			public float EjectionPortRecoveryTime;
			public float IlluminationRecoveryTime;
			public float HeatGeneratedPerRound;
			public float AgeGeneratedPerRoundMp;
			public float AgeGeneratedPerRoundSp;
			public float OverloadTime;
			public Angle AngleChangePerShotMin;
			public Angle AngleChangePerShotMax;
			public float AngleChangeAccelerationTime;
			public float AngleChangeDecelerationTime;
			public AngleChangeFunctionValue AngleChangeFunction;
			public short Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public float FiringEffectDecelerationTime;
			public uint Unknown8;
			public float RateOfFireAccelerationTime;
			public float RateOfFireDecelerationTime;
			public uint Unknown9;
			public float BloomRateOfDecay;
			public List<FiringEffect> FiringEffects;

			public enum PredictionTypeValue : short
			{
				None,
				Continuous,
				Instant,
			}

			public enum FiringNoiseValue : short
			{
				Silent,
				Medium,
				Loud,
				Shout,
				Quiet,
			}

			public enum DistributionFunctionValue : short
			{
				Point,
				HorizontalFan,
			}

			[TagStructure(Size = 0x14)]
			public class FiringPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class FiringCrouchedPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class MovingPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class TurningPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class DualFiringPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class DualFiringCrouchedPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class DualMovingPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0x14)]
			public class DualTurningPenaltyFunctionBlock
			{
				public byte[] Function;
			}

			[TagStructure(Size = 0xC)]
			public class FirstPersonOffset
			{
				public float FirstPersonOffsetX;
				public float FirstPersonOffsetY;
				public float FirstPersonOffsetZ;
			}

			public enum DamageReportingTypeValue : sbyte
			{
				GuardiansUnknown,
				Guardians,
				FallingDamage,
				GenericCollision,
				ArmorLockCrush,
				GenericMelee,
				GenericExplosion,
				Magnum,
				PlasmaPistol,
				Needler,
				Mauler,
				Smg,
				PlasmaRifle,
				BattleRifle,
				Carbine,
				Shotgun,
				SniperRifle,
				BeamRifle,
				AssaultRifle,
				Spiker,
				FuelRodCannon,
				MissilePod,
				RocketLauncher,
				SpartanLaser,
				BruteShot,
				Flamethrower,
				SentinelGun,
				EnergySword,
				GravityHammer,
				FragGrenade,
				PlasmaGrenade,
				SpikeGrenade,
				FirebombGrenade,
				Flag,
				Bomb,
				BombExplosion,
				Ball,
				MachinegunTurret,
				PlasmaCannon,
				PlasmaMortar,
				PlasmaTurret,
				ShadeTurret,
				Banshee,
				Ghost,
				Mongoose,
				Scorpion,
				ScorpionGunner,
				Spectre,
				SpectreGunner,
				Warthog,
				WarthogGunner,
				WarthogGaussTurret,
				Wraith,
				WraithGunner,
				Tank,
				Chopper,
				Hornet,
				Mantis,
				Prowler,
				SentinelBeam,
				SentinelRpg,
				Teleporter,
				Tripmine,
				Dmr,
			}

			public enum AngleChangeFunctionValue : short
			{
				Linear,
				Early,
				VeryEarly,
				Late,
				VeryLate,
				Cosine,
				One,
				Zero,
			}

			[TagStructure(Size = 0xC4)]
			public class FiringEffect
			{
				public short ShotCountLowerBound;
				public short ShotCountUpperBound;
				public HaloTag FiringEffect2;
				public HaloTag MisfireEffect;
				public HaloTag EmptyEffect;
				public HaloTag UnknownEffect;
				public HaloTag FiringResponse;
				public HaloTag MisfireResponse;
				public HaloTag EmptyResponse;
				public HaloTag UnknownResponse;
				public HaloTag RiderFiringResponse;
				public HaloTag RiderMisfireResponse;
				public HaloTag RiderEmptyResponse;
				public HaloTag RiderUnknownResponse;
			}
		}

		[TagStructure(Size = 0xC)]
		public class NewFirstPersonWeaponOffset
		{
			public float OffsetI;
			public float OffsetJ;
			public float OffsetK;
		}
	}
}
