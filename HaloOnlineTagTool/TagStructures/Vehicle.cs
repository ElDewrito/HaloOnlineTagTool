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
	[TagStructure(Class = "vehi", Size = 0x530)]
	public class Vehicle
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
		public uint Flags2;
		public DefaultTeamValue DefaultTeam;
		public ConstantSoundVolumeValue ConstantSoundVolume;
		public HaloTag HologramUnit;
		public List<MetagameProperty> MetagameProperties;
		public HaloTag IntegratedLightToggle;
		public Angle CameraFieldOfView;
		public float CameraStiffness;
		public short Flags3;
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
		public short Flags4;
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
		public uint Flags5;
		public List<TankEngineMotionProperty> TankEngineMotionProperties;
		public List<EngineMotionProperty> EngineMotionProperties;
		public List<DropshipMotionProperty> DropshipMotionProperties;
		public List<AntigravityMotionProperty> AntigravityMotionProperties;
		public List<JetEngineMotionProperty> JetEngineMotionProperties;
		public List<TurretProperty> TurretProperties;
		public float Unknown20;
		public float Unknown21;
		public float Unknown22;
		public List<HelicopterMotionProperty> HelicopterMotionProperties;
		public List<AntigravityEngineMotionProperty> AntigravityEngineMotionProperties;
		public List<AutoturretEquipmentBlock> AutoturretEquipment;
		public uint Flags6;
		public float GroundFriction;
		public float GroundDepth;
		public float GroundDampFactor;
		public float GroundMovingFriction;
		public float GroundMaximumSlope0;
		public float GroundMaximumSlope1LessThanSlope0;
		public float Unknown23;
		public float AntiGravityBankLift;
		public float SteeringBankReactionScale;
		public float GravityScale;
		public float Radius;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;
		public List<AntiGravityPoint> AntiGravityPoints;
		public List<FrictionPoint> FrictionPoints;
		public List<PhantomShape> PhantomShapes;
		public PlayerTrainingVehicleTypeValue PlayerTrainingVehicleType;
		public VehicleSizeValue VehicleSize;
		public sbyte Unknown27;
		public sbyte Unknown28;
		public float MinimumFlippingAngularVelocity;
		public float MaximumFlippingAngularVelocity;
		public float Unknown29;
		public float Unknown30;
		public float SeatEntranceAccelerationScale;
		public float SeatExitAccelerationScale;
		public float FlipTime;
		public StringId FlipOverMessage;
		public HaloTag SuspensionSound;
		public HaloTag RunningEffect;
		public HaloTag UnknownResponse;
		public HaloTag UnknownResponse2;
		public float Unknown31;
		public float Unknown32;

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

		[TagStructure(Size = 0x58)]
		public class TankEngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public float Unknown;
			public float SpeedLeft;
			public float SpeedRight;
			public float TurningSpeedLeft;
			public float TurningSpeedRight;
			public float SpeedLeft2;
			public float SpeedRight2;
			public float TurningSpeedLeft2;
			public float TurningSpeedRight2;
			public float EngineMomentum;
			public float EngineMaximumAngularVelocity;
			public List<Gear> Gears;
			public HaloTag ChangeGearSound;
			public float Unknown2;
			public float Unknown3;

			[TagStructure(Size = 0x44)]
			public class Gear
			{
				public float MinTorque;
				public float MaxTorque;
				public float PeakTorqueScale;
				public float PastPeakTorqueExponent;
				public float TorqueAtMaxAngularVelovity;
				public float TorqueAt2xMaxAngularVelocity;
				public float MinTorque2;
				public float MaxTorque2;
				public float PeakTorqueScale2;
				public float PastPeakTorqueExponent2;
				public float TorqueAtMaxAngularVelovity2;
				public float TorqueAt2xMaxAngularVelocity2;
				public float MinTimeToUpshift;
				public float EngineUpshiftScale;
				public float GearRatio;
				public float MinTimeToDownshift;
				public float EngineDownshiftScale;
			}
		}

		[TagStructure(Size = 0x40)]
		public class EngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle TurnRate;
			public float EngineMomentum;
			public float EngineMaximumAngularVelocity;
			public List<Gear> Gears;
			public HaloTag ChangeGearSound;
			public float Unknown;
			public float Unknown2;

			[TagStructure(Size = 0x44)]
			public class Gear
			{
				public float MinTorque;
				public float MaxTorque;
				public float PeakTorqueScale;
				public float PastPeakTorqueExponent;
				public float TorqueAtMaxAngularVelovity;
				public float TorqueAt2xMaxAngularVelocity;
				public float MinTorque2;
				public float MaxTorque2;
				public float PeakTorqueScale2;
				public float PastPeakTorqueExponent2;
				public float TorqueAtMaxAngularVelovity2;
				public float TorqueAt2xMaxAngularVelocity2;
				public float MinTimeToUpshift;
				public float EngineUpshiftScale;
				public float GearRatio;
				public float MinTimeToDownshift;
				public float EngineDownshiftScale;
			}
		}

		[TagStructure(Size = 0x4C)]
		public class DropshipMotionProperty
		{
			public float Unknown;
			public float ForwardAcceleration;
			public float Unknown2;
			public float BackwardAcceleration;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float LeftStrafeAcceleration;
			public float RightStrafeAcceleration;
			public float Unknown6;
			public float Unknown7;
			public float LiftAcceleration;
			public float DropAcceleration;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public Angle Unknown14;
			public float Unknown15;
			public Angle Unknown16;
		}

		[TagStructure(Size = 0x70)]
		public class AntigravityMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public float MaximumForwardSpeed;
			public float MaximumReverseSpeed;
			public float SpeedAcceleration;
			public float SpeedDeceleration;
			public float MaximumLeftSlide;
			public float MaximumRightSlide;
			public float SlideAcceleration;
			public float SlideDeceleration;
			public sbyte Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public float Traction;
			public float Unknown5;
			public float TurningRate;
			public StringId Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public StringId Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public float Unknown18;
			public Angle Unknown19;
		}

		[TagStructure(Size = 0x68)]
		public class JetEngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle TurnRate;
			public float FlyingSpeed;
			public float Acceleration;
			public float SpeedAcceleration;
			public float SpeedDeceleration;
			public float PitchLeftSpeed;
			public float PitchRightSpeed;
			public float PitchRate;
			public float UnpitchRate;
			public float FlightStability;
			public float Unknown;
			public float NoseAngle;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float FallingSpeed;
			public float FallingSpeed2;
			public float Unknown5;
			public float Unknown6;
			public float IdleRise;
			public float IdleForward;
			public float Unknown7;
		}

		[TagStructure(Size = 0x8)]
		public class TurretProperty
		{
			public float Unknown;
			public float Unknown2;
		}

		[TagStructure(Size = 0x74)]
		public class HelicopterMotionProperty
		{
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle Unknown;
			public StringId ThrustFrontLeft;
			public StringId ThrustFrontRight;
			public StringId Thrust;
			public Angle Unknown2;
			public Angle Unknown3;
			public Angle Unknown4;
			public Angle Unknown5;
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
			public Angle Unknown21;
			public Angle Unknown22;
			public float Unknown23;
			public float Unknown24;
		}

		[TagStructure(Size = 0x70)]
		public class AntigravityEngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle TurnRate;
			public float EngineMomentum;
			public float EngineMaximumAngularVelocity;
			public List<Gear> Gears;
			public HaloTag ChangeGearSound;
			public float Unknown;
			public StringId Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public Angle Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;

			[TagStructure(Size = 0x44)]
			public class Gear
			{
				public float MinTorque;
				public float MaxTorque;
				public float PeakTorqueScale;
				public float PastPeakTorqueExponent;
				public float TorqueAtMaxAngularVelovity;
				public float TorqueAt2xMaxAngularVelocity;
				public float MinTorque2;
				public float MaxTorque2;
				public float PeakTorqueScale2;
				public float PastPeakTorqueExponent2;
				public float TorqueAtMaxAngularVelovity2;
				public float TorqueAt2xMaxAngularVelocity2;
				public float MinTimeToUpshift;
				public float EngineUpshiftScale;
				public float GearRatio;
				public float MinTimeToDownshift;
				public float EngineDownshiftScale;
			}
		}

		[TagStructure(Size = 0x30)]
		public class AutoturretEquipmentBlock
		{
			public Angle Unknown;
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
		}

		[TagStructure(Size = 0x4C)]
		public class AntiGravityPoint
		{
			public StringId MarkerName;
			public uint Flags;
			public float AntigravStrength;
			public float AntigravOffset;
			public float AntigravHeight;
			public float AntigravDumpFactor;
			public float AntigravNormalK1;
			public float AntigravNormalK0;
			public float Radius;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public short Unknown4;
			public short DamageSourceRegionIndex;
			public StringId DamageSourceRegionName;
			public float DefaultStateError;
			public float MinorDamageError;
			public float MediumDamageError;
			public float MajorDamageError;
			public float DestroyedStateError;
		}

		[TagStructure(Size = 0x4C)]
		public class FrictionPoint
		{
			public StringId MarkerName;
			public uint Flags;
			public float FractionOfTotalMass;
			public float Radius;
			public float DamagedRadius;
			public FrictionTypeValue FrictionType;
			public short Unknown;
			public float MovingFrictionVelocityDiff;
			public float EBrakeMovingFriction;
			public float EBrakeFriction;
			public float EBrakeMovingFrictionVelocityDiff;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public StringId CollisionMaterialName;
			public short CollisionGlobalMaterialIndex;
			public ModelStateDestroyedValue ModelStateDestroyed;
			public StringId RegionName;
			public int RegionIndex;

			public enum FrictionTypeValue : short
			{
				Point,
				Forward,
			}

			public enum ModelStateDestroyedValue : short
			{
				Default,
				MinorDamage,
				MediumDamage,
				MajorDamage,
				Destroyed,
			}
		}

		[TagStructure(Size = 0x330)]
		public class PhantomShape
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int OverallShapeIndex;
			public int Offset;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public int Unknown5;
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
			public int MultisphereCount;
			public uint Flags;
			public float X0;
			public float X1;
			public float Y0;
			public float Y1;
			public float Z0;
			public float Z1;
			public int Unknown18;
			public short Size2;
			public short Count2;
			public int OverallShapeIndex2;
			public int Offset2;
			public int NumberOfSpheres;
			public float Unknown19;
			public float Unknown20;
			public float Unknown21;
			public float Sphere0X;
			public float Sphere0Y;
			public float Sphere0Z;
			public float Sphere0Radius;
			public float Sphere1X;
			public float Sphere1Y;
			public float Sphere1Z;
			public float Sphere1Radius;
			public float Sphere2X;
			public float Sphere2Y;
			public float Sphere2Z;
			public float Sphere2Radius;
			public float Sphere3X;
			public float Sphere3Y;
			public float Sphere3Z;
			public float Sphere3Radius;
			public float Sphere4X;
			public float Sphere4Y;
			public float Sphere4Z;
			public float Sphere4Radius;
			public float Sphere5X;
			public float Sphere5Y;
			public float Sphere5Z;
			public float Sphere5Radius;
			public float Sphere6X;
			public float Sphere6Y;
			public float Sphere6Z;
			public float Sphere6Radius;
			public float Sphere7X;
			public float Sphere7Y;
			public float Sphere7Z;
			public float Sphere7Radius;
			public int Unknown22;
			public short Size3;
			public short Count3;
			public int OverallShapeIndex3;
			public int Offset3;
			public int NumberOfSpheres2;
			public float Unknown23;
			public float Unknown24;
			public float Unknown25;
			public float Sphere0X2;
			public float Sphere0Y2;
			public float Sphere0Z2;
			public float Sphere0Radius2;
			public float Sphere1X2;
			public float Sphere1Y2;
			public float Sphere1Z2;
			public float Sphere1Radius2;
			public float Sphere2X2;
			public float Sphere2Y2;
			public float Sphere2Z2;
			public float Sphere2Radius2;
			public float Sphere3X2;
			public float Sphere3Y2;
			public float Sphere3Z2;
			public float Sphere3Radius2;
			public float Sphere4X2;
			public float Sphere4Y2;
			public float Sphere4Z2;
			public float Sphere4Radius2;
			public float Sphere5X2;
			public float Sphere5Y2;
			public float Sphere5Z2;
			public float Sphere5Radius2;
			public float Sphere6X2;
			public float Sphere6Y2;
			public float Sphere6Z2;
			public float Sphere6Radius2;
			public float Sphere7X2;
			public float Sphere7Y2;
			public float Sphere7Z2;
			public float Sphere7Radius2;
			public int Unknown26;
			public short Size4;
			public short Count4;
			public int OverallShapeIndex4;
			public int Offset4;
			public int NumberOfSpheres3;
			public float Unknown27;
			public float Unknown28;
			public float Unknown29;
			public float Sphere0X3;
			public float Sphere0Y3;
			public float Sphere0Z3;
			public float Sphere0Radius3;
			public float Sphere1X3;
			public float Sphere1Y3;
			public float Sphere1Z3;
			public float Sphere1Radius3;
			public float Sphere2X3;
			public float Sphere2Y3;
			public float Sphere2Z3;
			public float Sphere2Radius3;
			public float Sphere3X3;
			public float Sphere3Y3;
			public float Sphere3Z3;
			public float Sphere3Radius3;
			public float Sphere4X3;
			public float Sphere4Y3;
			public float Sphere4Z3;
			public float Sphere4Radius3;
			public float Sphere5X3;
			public float Sphere5Y3;
			public float Sphere5Z3;
			public float Sphere5Radius3;
			public float Sphere6X3;
			public float Sphere6Y3;
			public float Sphere6Z3;
			public float Sphere6Radius3;
			public float Sphere7X3;
			public float Sphere7Y3;
			public float Sphere7Z3;
			public float Sphere7Radius3;
			public int Unknown30;
			public short Size5;
			public short Count5;
			public int OverallShapeIndex5;
			public int Offset5;
			public int NumberOfSpheres4;
			public float Unknown31;
			public float Unknown32;
			public float Unknown33;
			public float Sphere0X4;
			public float Sphere0Y4;
			public float Sphere0Z4;
			public float Sphere0Radius4;
			public float Sphere1X4;
			public float Sphere1Y4;
			public float Sphere1Z4;
			public float Sphere1Radius4;
			public float Sphere2X4;
			public float Sphere2Y4;
			public float Sphere2Z4;
			public float Sphere2Radius4;
			public float Sphere3X4;
			public float Sphere3Y4;
			public float Sphere3Z4;
			public float Sphere3Radius4;
			public float Sphere4X4;
			public float Sphere4Y4;
			public float Sphere4Z4;
			public float Sphere4Radius4;
			public float Sphere5X4;
			public float Sphere5Y4;
			public float Sphere5Z4;
			public float Sphere5Radius4;
			public float Sphere6X4;
			public float Sphere6Y4;
			public float Sphere6Z4;
			public float Sphere6Radius4;
			public float Sphere7X4;
			public float Sphere7Y4;
			public float Sphere7Z4;
			public float Sphere7Radius4;
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
		}

		public enum PlayerTrainingVehicleTypeValue : sbyte
		{
			None,
			Warthog,
			WarthogTurret,
			Ghost,
			Banshee,
			Tank,
			Wraith,
		}

		public enum VehicleSizeValue : sbyte
		{
			Small,
			Large,
		}
	}
}
