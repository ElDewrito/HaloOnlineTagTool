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
	[TagStructure(Class = "proj", Size = 0x2CC)]
	public class Projectile
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
		public DetonationTimerStartsValue DetonationTimerStarts;
		public ImpactNoiseValue ImpactNoise;
		public float CollisionRadius;
		public float ArmingTime;
		public float DangerRadius;
		public float TimerMin;
		public float TimerMax;
		public float MinimumVelocity;
		public float MaximumRange;
		public float DetonationChargeTime;
		public DetonationNoiseValue DetonationNoise;
		public short SuperDetonationProjectileCount;
		public float SuperDetonationDelay;
		public HaloTag DetonationStarted;
		public HaloTag AirborneDetonationEffect;
		public HaloTag GroundDetonationEffect;
		public HaloTag DetonationDamage;
		public HaloTag AttachedDetonationDamage;
		public HaloTag SuperDetonation;
		public HaloTag SuperDetonationDamage;
		public HaloTag DetonationSound;
		public DamageReportingTypeValue DamageReportingType;
		public sbyte Unknown6;
		public sbyte Unknown7;
		public sbyte Unknown8;
		public HaloTag AttachedSuperDetonationDamage;
		public float MaterialEffectRadius;
		public HaloTag FlybySound;
		public HaloTag FlybyResponse;
		public HaloTag ImpactEffect;
		public HaloTag ImpactDamage;
		public float BoardingDetonationTime;
		public HaloTag BoardingDetonationDamage;
		public HaloTag BoardingAttachedDetonationDamage;
		public float AirGravityScale;
		public float AirDamageRangeMin;
		public float AirDamageRangeMax;
		public float WaterGravityScale;
		public float WaterDamageScaleMin;
		public float WaterDamageScaleMax;
		public float InitialVelocity;
		public float FinalVelocity;
		public float Unknown9;
		public float Unknown10;
		public Angle GuidedAngularVelocityLower;
		public Angle GuidedAngularVelocityUpper;
		public Angle Unknown11;
		public float AccelerationRangeMin;
		public float AccelerationRangeMax;
		public float Unknown12;
		public float Unknown13;
		public float TargetedLeadingFraction;
		public float Unknown14;
		public List<MaterialRespons> MaterialResponses;
		public List<ImpactProperty> ImpactProperties;
		public List<UnknownBlock> Unknown15;
		public List<ShotgunProperty> ShotgunProperties;

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

		public enum DetonationTimerStartsValue : short
		{
			Immediately,
			AfterFirstBounce,
			WhenAtRest,
			AfterFirstBounceOffAnySurface,
		}

		public enum ImpactNoiseValue : short
		{
			Silent,
			Medium,
			Loud,
			Shout,
			Quiet,
		}

		public enum DetonationNoiseValue : short
		{
			Silent,
			Medium,
			Loud,
			Shout,
			Quiet,
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

		[TagStructure(Size = 0x40)]
		public class MaterialRespons
		{
			public ushort Flags;
			public ResponseValue Response;
			public StringId MaterialName;
			public short GlobalMaterialIndex;
			public short Unknown;
			public ResponseValue2 Response2;
			public ushort Flags2;
			public float ChanceFraction;
			public Angle BetweenAngleMin;
			public Angle BetweenAngleMax;
			public float AndVelocityMin;
			public float AndVelocityMax;
			public ScaleEffectsByValue ScaleEffectsBy;
			public short Unknown2;
			public Angle AngularNoise;
			public float VelocityNoise;
			public float InitialFriction;
			public float MaximumDistance;
			public float ParallelFriction;
			public float PerpendicularFriction;

			public enum ResponseValue : short
			{
				ImpactDetonate,
				Fizzle,
				Overpenetrate,
				Attach,
				Bounce,
				BounceDud,
				FizzleRicochet,
			}

			public enum ResponseValue2 : short
			{
				ImpactDetonate,
				Fizzle,
				Overpenetrate,
				Attach,
				Bounce,
				BounceDud,
				FizzleRicochet,
			}

			public enum ScaleEffectsByValue : short
			{
				Damage,
				Angle,
			}
		}

		[TagStructure(Size = 0x30)]
		public class ImpactProperty
		{
			public Angle Unknown;
			public Angle Unknown2;
			public Angle Unknown3;
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

		[TagStructure(Size = 0x4)]
		public class UnknownBlock
		{
			public float Unknown;
		}

		[TagStructure(Size = 0xC)]
		public class ShotgunProperty
		{
			public short Amount;
			public short Distance;
			public float Accuracy;
			public Angle SpreadConeAngle;
		}
	}
}
