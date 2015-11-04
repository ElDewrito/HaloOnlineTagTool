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
	[TagStructure(Class = "bipd", Size = 0x628)]
	public class Biped
	{
		public ObjectTypeValue ObjectType;
		public ushort Flags;
		public float BoundingRadius;
		public float BoundingOffsetX;
		public float BoundingOffsetY;
		public float BoundingOffsetZ;
		public float AccelerationScale;
		public LightmapShadowModeSizeValue LightmapShadowModeSize;
		public SweetenerSizeValue SweetenerSize;
		public WaterDensityValue WaterDensity;
		public int Unknown;
		public float DynamicLightSphereRadius;
		public float DynamicLightSphereOffsetX;
		public float DynamicLightSphereOffsetY;
		public float DynamicLightSphereOffsetZ;
		public StringId DefaultModelVariant;
		public HaloTag Model;
		public HaloTag CrateObject;
		public HaloTag CollisionDamage;
		public List<EarlyMoverProperty> EarlyMoverProperties;
		public HaloTag CreationEffect;
		public HaloTag MaterialEffects;
		public HaloTag ArmorSounds;
		public HaloTag MeleeImpact;
		public List<AiProperty> AiProperties;
		public List<Function> Functions;
		public short HudTextMessageIndex;
		public short Unknown2;
		public List<Attachment> Attachments;
		public List<Widget> Widgets;
		public List<ChangeColor> ChangeColors;
		public List<NodeMap> NodeMaps;
		public List<MultiplayerObjectProperty> MultiplayerObjectProperties;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public List<ModelObjectDatum> ModelObjectData;
		public uint FlagsWarningHalo4Values;
		public DefaultTeamValue DefaultTeam;
		public ConstantSoundVolumeValue ConstantSoundVolume;
		public HaloTag HologramUnit;
		public List<MetagameProperty> MetagameProperties;
		public HaloTag IntegratedLightToggle;
		public Angle CameraFieldOfView;
		public float CameraStiffness;
		public short Flags2;
		public short Unknown6;
		public StringId CameraMarkerName;
		public StringId CameraSubmergedMarkerName;
		public Angle PitchAutoLevel;
		public Angle PitchRangeMin;
		public Angle PitchRangeMax;
		public List<CameraTrack> CameraTracks;
		public Angle Unknown7;
		public Angle Unknown8;
		public Angle Unknown9;
		public List<UnknownBlock> Unknown10;
		public short Flags3;
		public short Unknown11;
		public StringId CameraMarkerName2;
		public StringId CameraSubmergedMarkerName2;
		public Angle PitchAutoLevel2;
		public Angle PitchRangeMin2;
		public Angle PitchRangeMax2;
		public List<CameraTrack2> CameraTracks2;
		public Angle Unknown12;
		public Angle Unknown13;
		public Angle Unknown14;
		public List<UnknownBlock2> Unknown15;
		public HaloTag AssassinationResponse;
		public HaloTag AssassinationWeapon;
		public StringId AssasinationToolStowAnchor;
		public StringId AssasinationToolHandMarker;
		public StringId AssasinationToolMarker;
		public float AccelerationRangeI;
		public float AccelerationRangeJ;
		public float AccelerationRangeK;
		public float AccelerationActionScale;
		public float AccelerationAttachScale;
		public float SoftPingThreshold;
		public float SoftPingInterruptTime;
		public float HardPingThreshold;
		public float HardPingInterruptTime;
		public float FeignDeathThreshold;
		public float FeignDeathTime;
		public float DistanceOfEvadeAnimation;
		public float DistanceOfDiveAnimation;
		public float StunnedMovementThreshold;
		public float FeignDeathChance;
		public float FeignRepeatChance;
		public HaloTag SpawnedTurretCharacter;
		public short SpawnedActorCountMin;
		public short SpawnedActorCountMax;
		public float SpawnedVelocity;
		public Angle AimingVelocityMaximum;
		public Angle AimingAccelerationMaximum;
		public float CasualAimingModifier;
		public Angle LookingVelocityMaximum;
		public Angle LookingAccelerationMaximum;
		public StringId RightHandNode;
		public StringId LeftHandNode;
		public StringId PreferredGunNode;
		public HaloTag MeleeDamage;
		public HaloTag BoardingMeleeDamage;
		public HaloTag BoardingMeleeResponse;
		public HaloTag EjectionMeleeDamage;
		public HaloTag EjectionMeleeResponse;
		public HaloTag LandingMeleeDamage;
		public HaloTag FlurryMeleeDamage;
		public HaloTag ObstacleSmashMeleeDamage;
		public HaloTag ShieldPopDamage;
		public HaloTag AssassinationDamage;
		public MotionSensorBlipSizeValue MotionSensorBlipSize;
		public ItemScaleValue ItemScale;
		public List<Posture> Postures;
		public List<HudInterface> HudInterfaces;
		public List<DialogueVariant> DialogueVariants;
		public float Unknown16;
		public float Unknown17;
		public float Unknown18;
		public float Unknown19;
		public float GrenadeVelocity;
		public GrenadeTypeValue GrenadeType;
		public short GrenadeCount;
		public List<PoweredSeat> PoweredSeats;
		public List<Weapon> Weapons;
		public List<TargetTrackingBlock> TargetTracking;
		public List<Seat> Seats;
		public float EmpRadius;
		public HaloTag EmpEffect;
		public HaloTag BoostCollisionDamage;
		public float BoostPeakPower;
		public float BoostRisePower;
		public float BoostPeakTime;
		public float BoostFallPower;
		public float BoostDeadTime;
		public float LipsyncAttackWeight;
		public float LipsyncDecayWeight;
		public HaloTag DetachDamage;
		public HaloTag DetachedWeapon;
		public Angle MovingTurningSpeed;
		public uint Flags4;
		public Angle StationaryTurningSpeed;
		public float Unknown20;
		public float Unknown21;
		public float JumpVelcoity;
		public float MaximumSoftLandingTime;
		public float MinimumHardLandingTime;
		public float MinimumSoftLandingVelocity;
		public float MinimumHardLandingVelocity;
		public float MaximumHardLandingVelocity;
		public float DeathHardLandingVelocity;
		public float StunDuration;
		public float StationaryStandingCameraHeight;
		public float MovingStandingCameraHeight;
		public float StationaryCrouchingCameraHeight;
		public float MovingCrouchingCameraHeight;
		public float CrouchTransitionTime;
		public byte[] CrouchingCameraFunction;
		public List<WeaponCameraHeightBlock> WeaponCameraHeight;
		public Angle Unknown22;
		public Angle Unknown23;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;
		public float Unknown27;
		public float Unknown28;
		public short Unknown29;
		public short Unknown30;
		public float Unknown31;
		public short Unknown32;
		public short Unknown33;
		public float Unknown34;
		public float Unknown35;
		public float Unknown36;
		public short Unknown37;
		public short Unknown38;
		public float Unknown39;
		public float HeadshotAccelerationScale;
		public HaloTag AreaDamageEffect;
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
		public uint Flags5;
		public float HeightStanding;
		public float HeightCrouching;
		public float Radius;
		public float Mass;
		public StringId LivingMaterialName;
		public StringId DeadMaterialName;
		public short LivingMaterialGlobalIndex;
		public short DeadMaterialGlobalIndex;
		public List<DeadSphereShape> DeadSphereShapes;
		public List<PillShape> PillShapes;
		public List<SphereShape> SphereShapes;
		public Angle MaximumSlopeAngle;
		public Angle DownhillFalloffAngle;
		public Angle DownhillCutoffAngle;
		public Angle UphillFalloffAngle;
		public Angle UphillCutoffAngle;
		public float DownhillVelocityScale;
		public float UphillVelocityScale;
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
		public Angle BankAngle;
		public float BankApplyTime;
		public float BankDecayTime;
		public float PitchRatio;
		public float MaximumVelocity;
		public float MaximumSidestepVelocity;
		public float Acceleration;
		public float Deceleration;
		public Angle AngularVelocityMaximum;
		public Angle AngularAccelerationMaximum;
		public float CrouchVelocityModifier;
		public List<ContactPoint> ContactPoints;
		public HaloTag ReanimationCharacter;
		public HaloTag TransformationMuffin;
		public HaloTag DeathSpawnCharacter;
		public short DeathSpawnCount;
		public short Unknown62;
		public Angle Unknown63;
		public Angle Unknown64;
		public float Unknown65;
		public float Unknown66;
		public float Unknown67;
		public float Unknown68;
		public float Unknown69;
		public float Unknown70;
		public float Unknown71;
		public float Unknown72;
		public float Unknown73;
		public float Unknown74;
		public float Unknown75;
		public float Unknown76;
		public float Unknown77;
		public float Unknown78;
		public float Unknown79;
		public float Unknown80;
		public float Unknown81;
		public float Unknown82;
		public float Unknown83;
		public float Unknown84;
		public float Unknown85;
		public float Unknown86;
		public float Unknown87;

		public enum ObjectTypeValue : short
		{
			Biped,
			Vehicle,
			Weapon,
			Equipment,
			ArgDevice,
			Terminal,
			Projectile,
			Scenery,
			Machine,
			Control,
			SoundScenery,
			Crate,
			Creature,
			Giant,
			EffectScenery,
		}

		public enum LightmapShadowModeSizeValue : short
		{
			Default,
			Never,
			Always,
			Unknown,
		}

		public enum SweetenerSizeValue : sbyte
		{
			Small,
			Medium,
			Large,
		}

		public enum WaterDensityValue : sbyte
		{
			Default,
			Least,
			Some,
			Equal,
			More,
			MoreStill,
			LotsMore,
		}

		[TagStructure(Size = 0x28)]
		public class EarlyMoverProperty
		{
			public StringId Name;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
		}

		[TagStructure(Size = 0xC)]
		public class AiProperty
		{
			public uint Flags;
			public StringId AiTypeName;
			public SizeValue Size;
			public LeapJumpSpeedValue LeapJumpSpeed;

			public enum SizeValue : short
			{
				Default,
				Tiny,
				Small,
				Medium,
				Large,
				Huge,
				Immobile,
			}

			public enum LeapJumpSpeedValue : short
			{
				None,
				Down,
				Step,
				Crouch,
				Stand,
				Storey,
				Tower,
				Infinite,
			}
		}

		[TagStructure(Size = 0x2C)]
		public class Function
		{
			public uint Flags;
			public StringId ImportName;
			public StringId ExportName;
			public StringId TurnOffWith;
			public float MinimumValue;
			public byte[] DefaultFunction;
			public StringId ScaleBy;
		}

		[TagStructure(Size = 0x24)]
		public class Attachment
		{
			public uint AtlasFlags;
			public HaloTag Attachment2;
			public StringId Marker;
			public ChangeColorValue ChangeColor;
			public short Unknown;
			public StringId PrimaryScale;
			public StringId SecondaryScale;

			public enum ChangeColorValue : short
			{
				None,
				Primary,
				Secondary,
				Tertiary,
				Quaternary,
			}
		}

		[TagStructure(Size = 0x10)]
		public class Widget
		{
			public HaloTag Type;
		}

		[TagStructure(Size = 0x18)]
		public class ChangeColor
		{
			public List<InitialPermutation> InitialPermutations;
			public List<Function> Functions;

			[TagStructure(Size = 0x20)]
			public class InitialPermutation
			{
				public float Weight;
				public float ColorLowerBoundR;
				public float ColorLowerBoundG;
				public float ColorLowerBoundB;
				public float ColorUpperBoundR;
				public float ColorUpperBoundG;
				public float ColorUpperBoundB;
				public StringId VariantName;
			}

			[TagStructure(Size = 0x20)]
			public class Function
			{
				public uint ScaleFlags;
				public float ColorLowerBoundR;
				public float ColorLowerBoundG;
				public float ColorLowerBoundB;
				public float ColorUpperBoundR;
				public float ColorUpperBoundG;
				public float ColorUpperBoundB;
				public StringId DarkenBy;
				public StringId ScaleBy;
			}
		}

		[TagStructure(Size = 0x1)]
		public class NodeMap
		{
			public sbyte TargetNode;
		}

		[TagStructure(Size = 0xC4)]
		public class MultiplayerObjectProperty
		{
			public ushort EngineFlags;
			public ObjectTypeValue ObjectType;
			public byte TeleporterFlags;
			public sbyte Unknown;
			public byte Flags;
			public ShapeValue Shape;
			public SpawnTimerModeValue SpawnTimerMode;
			public short SpawnTime;
			public short UnknownSpawnTime;
			public float RadiusWidth;
			public float Length;
			public float Top;
			public float Bottom;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public int Unknown5;
			public int Unknown6;
			public HaloTag ChildObject;
			public int Unknown7;
			public HaloTag ShapeShader;
			public HaloTag UnknownShader;
			public HaloTag Unknown8;
			public HaloTag Unknown9;
			public HaloTag Unknown10;
			public HaloTag Unknown11;
			public HaloTag Unknown12;
			public HaloTag Unknown13;

			public enum ObjectTypeValue : sbyte
			{
				Ordinary,
				Weapon,
				Grenade,
				Projectile,
				Powerup,
				Equipment,
				LightLandVehicle,
				HeavyLandVehicle,
				FlyingVehicle,
				Teleporter2way,
				TeleporterSender,
				TeleporterReceiver,
				PlayerSpawnLocation,
				PlayerRespawnZone,
				HoldSpawnObjective,
				CaptureSpawnObjective,
				HoldDestinationObjective,
				CaptureDestinationObjective,
				HillObjective,
				InfectionHavenObjective,
				TerritoryObjective,
				VipBoundaryObjective,
				VipDestinationObjective,
				JuggernautDestinationObjective,
			}

			public enum ShapeValue : sbyte
			{
				None,
				Sphere,
				Cylinder,
				Box,
			}

			public enum SpawnTimerModeValue : sbyte
			{
				DefaultOne,
				Multiple,
			}
		}

		[TagStructure(Size = 0x14)]
		public class ModelObjectDatum
		{
			public TypeValue Type;
			public short Unknown;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float Radius;

			public enum TypeValue : short
			{
				NotSet,
				UserDefined,
				AutoGenerated,
			}
		}

		public enum DefaultTeamValue : short
		{
			Default,
			Player,
			Human,
			Covenant,
			Flood,
			Sentinel,
			Heretic,
			Prophet,
			Guilty,
			Unused9,
			Unused10,
			Unused11,
			Unused12,
			Unused13,
			Unused14,
			Unused15,
		}

		public enum ConstantSoundVolumeValue : short
		{
			Silent,
			Medium,
			Loud,
			Shout,
			Quiet,
		}

		[TagStructure(Size = 0x8)]
		public class MetagameProperty
		{
			public UnitKindValue UnitKind;
			public UnitValue Unit;
			public ClassificationValue Classification;
			public sbyte Unknown;
			public short BasePointWorth;
			public short Unknown2;

			public enum UnitKindValue : sbyte
			{
				Actor,
				Vehicle,
			}

			public enum UnitValue : sbyte
			{
				Brute,
				Grunt,
				Jackal,
				Marine,
				Drone,
				Hunter,
				Unknown,
				FloodCarrier,
				FloodCombat,
				FloodPureform,
				Forerunner,
				Elite,
				Unknown2,
				Mongoose,
				Warthog,
				Scorpion,
				Hornet,
				Pelican,
				Shade,
				Unknown3,
				Ghost,
				Chopper,
				Mauler,
				Wraith,
				Banshee,
				Phantom,
				Scarab,
				Unknown4,
				Engineer,
			}

			public enum ClassificationValue : sbyte
			{
				Infantry,
				Leader,
				Hero,
				Specialist,
				LightVehicle,
				HeavyVehicle,
				GiantVehicle,
				MediumVehicle,
			}
		}

		[TagStructure(Size = 0x10)]
		public class CameraTrack
		{
			public HaloTag Track;
		}

		[TagStructure(Size = 0x4C)]
		public class UnknownBlock
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
		}

		[TagStructure(Size = 0x10)]
		public class CameraTrack2
		{
			public HaloTag Track;
		}

		[TagStructure(Size = 0x4C)]
		public class UnknownBlock2
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
		}

		public enum MotionSensorBlipSizeValue : short
		{
			Medium,
			Small,
			Large,
		}

		public enum ItemScaleValue : short
		{
			Human,
			Player,
			Covenant,
			Boss,
		}

		[TagStructure(Size = 0x10)]
		public class Posture
		{
			public StringId Name;
			public float PillOffsetI;
			public float PillOffsetJ;
			public float PillOffsetK;
		}

		[TagStructure(Size = 0x10)]
		public class HudInterface
		{
			public HaloTag UnitHudInterface;
		}

		[TagStructure(Size = 0x14)]
		public class DialogueVariant
		{
			public short VariantNumber;
			public short Unknown;
			public HaloTag Dialogue;
		}

		public enum GrenadeTypeValue : short
		{
			HumanFragmentation,
			CovenantPlasma,
			BruteSpike,
			Incendiary,
		}

		[TagStructure(Size = 0x8)]
		public class PoweredSeat
		{
			public float DriverPowerupTime;
			public float DriverPowerdownTime;
		}

		[TagStructure(Size = 0x10)]
		public class Weapon
		{
			public HaloTag Weapon2;
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

		[TagStructure(Size = 0xE4)]
		public class Seat
		{
			public uint Flags;
			public StringId SeatAnimation;
			public StringId SeatMarkerName;
			public StringId EntryMarkerSName;
			public StringId BoardingGrenadeMarker;
			public StringId BoardingGrenadeString;
			public StringId BoardingMeleeString;
			public StringId DetachWeaponString;
			public float PingScale;
			public float TurnoverTime;
			public float AccelerationRangeI;
			public float AccelerationRangeJ;
			public float AccelerationRangeK;
			public float AccelerationActionScale;
			public float AccelerationAttachScale;
			public float AiScariness;
			public AiSeatTypeValue AiSeatType;
			public short BoardingSeat;
			public float ListenerInterpolationFactor;
			public float YawRateBoundsMin;
			public float YawRateBoundsMax;
			public float PitchRateBoundsMin;
			public float PitchRateBoundsMax;
			public float Unknown;
			public float MinimumSpeedReference;
			public float MaximumSpeedReference;
			public float SpeedExponent;
			public short Unknown2;
			public short Unknown3;
			public StringId CameraMarkerName;
			public StringId CameraSubmergedMarkerName;
			public Angle PitchAutoLevel;
			public Angle PitchRangeMin;
			public Angle PitchRangeMax;
			public List<CameraTrack> CameraTracks;
			public Angle Unknown4;
			public Angle Unknown5;
			public Angle Unknown6;
			public List<UnknownBlock> Unknown7;
			public List<UnitHudInterfaceBlock> UnitHudInterface;
			public StringId EnterSeatString;
			public Angle YawRangeMin;
			public Angle YawRangeMax;
			public HaloTag BuiltInGunner;
			public float EntryRadius;
			public Angle EntryMarkerConeAngle;
			public Angle EntryMarkerFacingAngle;
			public float MaximumRelativeVelocity;
			public StringId InvisibleSeatRegion;
			public int RuntimeInvisibleSeatRegionIndex;

			public enum AiSeatTypeValue : short
			{
				None,
				Passenger,
				Gunner,
				SmallCargo,
				LargeCargo,
				Driver,
			}

			[TagStructure(Size = 0x10)]
			public class CameraTrack
			{
				public HaloTag Track;
			}

			[TagStructure(Size = 0x4C)]
			public class UnknownBlock
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
			}

			[TagStructure(Size = 0x10)]
			public class UnitHudInterfaceBlock
			{
				public HaloTag UnitHudInterface;
			}
		}

		[TagStructure(Size = 0x18)]
		public class WeaponCameraHeightBlock
		{
			public StringId Class;
			public float StandingHeightFraction;
			public float CrouchingHeightFraction;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
		}

		[TagStructure(Size = 0x70)]
		public class DeadSphereShape
		{
			public StringId Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float TranslationI;
			public float TranslationJ;
			public float TranslationK;
			public float TranslationRadius;
		}

		[TagStructure(Size = 0x60)]
		public class PillShape
		{
			public StringId Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short Index;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float BottomI;
			public float BottomJ;
			public float BottomK;
			public float BottomRadius;
			public float TopI;
			public float TopJ;
			public float TopK;
			public float TopRadius;
		}

		[TagStructure(Size = 0x70)]
		public class SphereShape
		{
			public StringId Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float TranslationI;
			public float TranslationJ;
			public float TranslationK;
			public float TranslationRadius;
		}

		[TagStructure(Size = 0x4)]
		public class ContactPoint
		{
			public StringId MarkerName;
		}
	}
}
