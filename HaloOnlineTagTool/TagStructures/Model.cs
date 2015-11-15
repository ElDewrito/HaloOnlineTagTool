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
	[TagStructure(Class = "hlmt", Size = 0x1B4, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "hlmt", Size = 0x1B8, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class Model
	{
		public HaloTag RenderModel;
		public HaloTag CollisionModel;
		public HaloTag Animation;
		public HaloTag PhysicsModel;
		public float ReduceToL1SuperLow;
		public float ReduceToL2Low;
		public float ReduceToL3Medium;
		public float ReduceToL4High;
		public float ReduceToL5SuperHigh;
		public HaloTag LodModel;
		public List<Variant> Variants;
		public List<UnknownBlock> Unknown;
		public List<FlairApplication> FlairApplications;
		public List<Material> Materials;
		public List<NewDamageInfoBlock> NewDamageInfo;
		public List<Target> Targets;
		public List<CollisionRegion> CollisionRegions;
		public List<Node> Nodes;
		public uint Unknown2;
		public List<ModelObjectDatum> ModelObjectData;
		public HaloTag PrimaryDialogue;
		public HaloTag SecondaryDialogue;
		public uint Flags;
		public StringId DefaultDialogueEffect;
		public uint RenderOnlyNodeFlags1;
		public uint RenderOnlyNodeFlags2;
		public uint RenderOnlyNodeFlags3;
		public uint RenderOnlyNodeFlags4;
		public uint RenderOnlyNodeFlags5;
		public uint RenderOnlyNodeFlags6;
		public uint RenderOnlyNodeFlags7;
		public uint RenderOnlyNodeFlags8;
		public uint RenderOnlySectionFlags1;
		public uint RenderOnlySectionFlags2;
		public uint RenderOnlySectionFlags3;
		public uint RenderOnlySectionFlags4;
		public uint RenderOnlySectionFlags5;
		public uint RenderOnlySectionFlags6;
		public uint RenderOnlySectionFlags7;
		public uint RenderOnlySectionFlags8;
		public uint RuntimeFlags;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown3; // TODO: Version number
		public float ScenarioLoadParametersBlock;
		public float ScenarioLoadParametersBlock2;
		public float ScenarioLoadParametersBlock3;
		public short Unknown4;
		public short Unknown5;
		public List<UnknownBlock2> Unknown6;
		public List<UnknownBlock3> Unknown7;
		public List<UnknownBlock4> Unknown8;
		public HaloTag ShieldImpactThirdPerson;
		public HaloTag ShieldImpactFirstPerson;
		public HaloTag OvershieldThirdPerson;
		public HaloTag OvershieldFirstPerson;

		[TagStructure(Size = 0x50)]
		public class Variant
		{
			public StringId Name;
			public HaloTag VariantDialogue;
			public StringId DefaultDialogEffect;
			public sbyte Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public sbyte ModelRegion0Index;
			public sbyte ModelRegion1Index;
			public sbyte ModelRegion2Index;
			public sbyte ModelRegion3Index;
			public sbyte ModelRegion4Index;
			public sbyte ModelRegion5Index;
			public sbyte ModelRegion6Index;
			public sbyte ModelRegion7Index;
			public sbyte ModelRegion8Index;
			public sbyte ModelRegion9Index;
			public sbyte ModelRegion10Index;
			public sbyte ModelRegion11Index;
			public sbyte ModelRegion12Index;
			public sbyte ModelRegion13Index;
			public sbyte ModelRegion14Index;
			public sbyte ModelRegion15Index;
			public List<Region> Regions;
			public List<Object> Objects;
			public int Unknown5;
			public uint Unknown6;
			public uint Unknown7;

			[TagStructure(Size = 0x18)]
			public class Region
			{
				public StringId Name;
				public sbyte RenderModelRegionIndex;
				public sbyte Unknown;
				public sbyte Unknown2;
				public sbyte Unknown3;
				public List<Permutation> Permutations;
				public SortOrderValue SortOrder;

				[TagStructure(Size = 0x24)]
				public class Permutation
				{
					public StringId Name;
					public sbyte RenderModelPermutationIndex;
					public sbyte Unknown;
					public sbyte Unknown2;
					public byte Flags;
					public float Probability;
					public List<State> States;
					public uint Unknown3;
					public uint Unknown4;
					public uint Unknown5;

					[TagStructure(Size = 0x20)]
					public class State
					{
						public StringId Name;
						public sbyte Unknown;
						public byte PropertyFlags;
						public StateValue State2;
						public HaloTag LoopingEffect;
						public StringId LoopingEffectMarkerName;
						public float InitialProbability;

						public enum StateValue : short
						{
							Default,
							MinorDamage,
							MediumDamage,
							MajorDamage,
							Destroyed,
						}
					}
				}

				public enum SortOrderValue : int
				{
					NoSorting,
					_5Closest,
					_4,
					_3,
					_2,
					_1,
					_0SameAsModel,
					_1_2,
					_2_2,
					_3_2,
					_4_2,
					_5Farthest,
				}
			}

			[TagStructure(Size = 0x1C)]
			public class Object
			{
				public StringId ParentMarker;
				public StringId ChildMarker;
				public StringId ChildVariant;
				public HaloTag ChildObject;
			}
		}

		[TagStructure(Size = 0x4)]
		public class UnknownBlock
		{
			public uint Unknown;
		}

		[TagStructure(Size = 0x18)]
		public class FlairApplication
		{
			public StringId Name;
			public int Unknown;
			public List<UnknownBlock> Unknown2;
			public uint Unknown3;

			[TagStructure(Size = 0x1C)]
			public class UnknownBlock
			{
				public int Unknown;
				public StringId Unknown2;
				public uint Unknown3;
				public uint FlairFlags1;
				public uint FlairFlags2;
				public uint Unknown4;
				public uint Unknown5;
			}
		}

		[TagStructure(Size = 0x14)]
		public class Material
		{
			public StringId Name;
			public short Unknown;
			public short DamageSectionIndex;
			public short Unknown2;
			public short Unknown3;
			public StringId MaterialName;
			public short GlobalMaterialIndex;
			public short Unknown4;
		}

		[TagStructure(Size = 0x100)]
		public class NewDamageInfoBlock
		{
			public uint Flags;
			public StringId GlobalIndirectMaterialName;
			public short IndirectDamageSection;
			public short Unknown;
			public uint Unknown2;
			public CollisionDamageReportingTypeValue CollisionDamageReportingType;
			public ResponseDamageReportingTypeValue ResponseDamageReportingType;
			public short Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public float MaxVitality;
			public float MinStunDamage;
			public float StunTime;
			public float RechargeTime;
			public float RechargeFraction;
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
			public float MaxShieldVitality;
			public StringId GlobalShieldMaterialName;
			public float MinStunDamage2;
			public float StunTime2;
			public float ShieldRechargeTime;
			public float ShieldDamagedThreshold;
			public HaloTag ShieldDamagedEffect;
			public HaloTag ShieldDepletedEffect;
			public HaloTag ShieldRechargingEffect;
			public List<DamageSection> DamageSections;
			public List<Node> Nodes;
			public short GlobalShieldMaterialIndex;
			public short GlobalIndirectMaterialIndex;
			public uint Unknown25;
			public uint Unknown26;
			public List<DamageSeat> DamageSeats;
			public List<DamageConstraint> DamageConstraints;

			public enum CollisionDamageReportingTypeValue : sbyte
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

			public enum ResponseDamageReportingTypeValue : sbyte
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

			[TagStructure(Size = 0x44)]
			public class DamageSection
			{
				public StringId Name;
				public uint Flags;
				public float VitalityPercentage;
				public List<InstantRespons> InstantResponses;
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
				public uint Unknown6;
				public float StunTime;
				public float RechargeTime;
				public uint Unknown7;
				public StringId ResurrectionRegionName;
				public short RessurectionRegionRuntimeIndex;
				public short Unknown8;

				[TagStructure(Size = 0x88)]
				public class InstantRespons
				{
					public ResponseTypeValue ResponseType;
					public ConstraintDamageTypeValue ConstraintDamageType;
					public StringId Trigger;
					public uint Flags;
					public float DamageThreshold;
					public HaloTag PrimaryTransitionEffect;
					public HaloTag SecondaryTransitionEffect;
					public HaloTag TransitionDamageEffect;
					public StringId Region;
					public NewStateValue NewState;
					public short RuntimeRegionIndex;
					public StringId SecondaryRegion;
					public SecondaryNewStateValue SecondaryNewState;
					public short SecondaryRuntimeRegionIndex;
					public short Unknown;
					public UnknownSpecialDamageValue UnknownSpecialDamage;
					public StringId SpecialDamageCase;
					public StringId EffectMarkerName;
					public StringId DamageEffectMarkerName;
					public float ResponseDelay;
					public HaloTag DelayEffect;
					public StringId DelayEffectMarkerName;
					public StringId EjectingSeatLabel;
					public float SkipFraction;
					public StringId DestroyedChildObjectMarkerName;
					public float TotalDamageThreshold;

					public enum ResponseTypeValue : short
					{
						RecievesAllDamage,
						RecievesAreaEffectDamage,
						RecievesLocalDamage,
					}

					public enum ConstraintDamageTypeValue : short
					{
						None,
						DestroyOneOfGroup,
						DestroyEntireGroup,
						LoosenOneOfGroup,
						LoosenEntireGroup,
					}

					public enum NewStateValue : short
					{
						Default,
						MinorDamage,
						MediumDamage,
						MajorDamage,
						Destroyed,
					}

					public enum SecondaryNewStateValue : short
					{
						Default,
						MinorDamage,
						MediumDamage,
						MajorDamage,
						Destroyed,
					}

					public enum UnknownSpecialDamageValue : short
					{
						None,
						_1,
						_2,
						_3,
					}
				}
			}

			[TagStructure(Size = 0x10)]
			public class Node
			{
				public short Unknown;
				public short Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
			}

			[TagStructure(Size = 0x20)]
			public class DamageSeat
			{
				public StringId SeatLabel;
				public float DirectDamageScale;
				public float DamageTransferFallOffRadius;
				public float MaximumTransferDamageScale;
				public float MinimumTransferDamageScale;
				public List<UnknownBlock> Unknown;

				[TagStructure(Size = 0x2C)]
				public class UnknownBlock
				{
					public StringId Node;
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
			}

			[TagStructure(Size = 0x14)]
			public class DamageConstraint
			{
				public StringId PhysicsModelConstraintName;
				public StringId DamageConstraintName;
				public StringId DamageConstraintGroupName;
				public float GroupProbabilityScale;
				public TypeValue Type;
				public short Index;

				public enum TypeValue : short
				{
					Hinge,
					LimitedHinge,
					Ragdoll,
					StiffSpring,
					BallAndSocket,
					Prismatic,
				}
			}
		}

		[TagStructure(Size = 0x28)]
		public class Target
		{
			public uint Unknown;
			public StringId MarkerName;
			public float Size;
			public Angle ConeAngle;
			public short DamageSection;
			public short Variant;
			public float TargetingRelevance;
			public uint Unknown2;
			public uint Flags;
			public float LockOnDistance;
			public StringId TargetFilter;
		}

		[TagStructure(Size = 0x14)]
		public class CollisionRegion
		{
			public StringId Name;
			public sbyte CollisionRegionIndex;
			public sbyte PhysicsRegionIndex;
			public sbyte Unknown;
			public sbyte Unknown2;
			public List<Permutation> Permutations;

			[TagStructure(Size = 0x8)]
			public class Permutation
			{
				public StringId Name;
				public byte Flags;
				public sbyte CollisionPermutationIndex;
				public sbyte PhysicsPermutationIndex;
				public sbyte Unknown;
			}
		}

		[TagStructure(Size = 0x5C)]
		public class Node
		{
			public StringId Name;
			public short ParentNode;
			public short FirstChildNode;
			public short NextSiblingNode;
			public short ImportNodeIndex;
			public float DefaultTranslationX;
			public float DefaultTranslationY;
			public float DefaultTranslationZ;
			public float DefaultRotationI;
			public float DefaultRotationJ;
			public float DefaultRotationK;
			public float DefaultRotationW;
			public float DefaultScale;
			public float InverseForwardI;
			public float InverseForwardJ;
			public float InverseForwardK;
			public float InverseLeftI;
			public float InverseLeftJ;
			public float InverseLeftK;
			public float InverseUpI;
			public float InverseUpJ;
			public float InverseUpK;
			public float InversePositionX;
			public float InversePositionY;
			public float InversePositionZ;
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

		[TagStructure(Size = 0x8)]
		public class UnknownBlock2
		{
			public StringId Region;
			public StringId Permutation;
		}

		[TagStructure(Size = 0x8)]
		public class UnknownBlock3
		{
			public StringId Unknown;
			public uint Unknown2;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock4
		{
			public StringId Marker;
			public uint Unknown;
			public StringId Marker2;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
