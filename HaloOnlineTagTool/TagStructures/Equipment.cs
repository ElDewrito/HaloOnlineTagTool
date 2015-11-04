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
	[TagStructure(Class = "eqip", Size = 0x384)]
	public class Equipment
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
		public short OldMessageIndex;
		public short SortOrder;
		public float OldMultiplayerOnGroundScale;
		public float OldCampaignOnGroundScale;
		public StringId PickupMessage;
		public StringId SwapMessage;
		public StringId PickupOrDualWieldMessage;
		public StringId SwapOrDualWieldMessage;
		public StringId PickedUpMessage;
		public StringId SwitchToMessage;
		public StringId SwitchToFromAiMessage;
		public StringId AllWeaponsEmptyMessage;
		public HaloTag CollisionSound;
		public List<PredictedBitmap> PredictedBitmaps;
		public HaloTag DetonationDamageEffect;
		public float DetonationDelayMin;
		public float DetonationDelayMax;
		public HaloTag DetonatingEffect;
		public HaloTag DetonationEffect;
		public float CampaignGroundScale;
		public float MultiplayerGroundScale;
		public float HumanHoldScale;
		public float HumanHolsterScale;
		public float CovenantHoldScale;
		public float CovenantHolsterScale;
		public float PlayerHoldScale;
		public float PlayerHoldScale2;
		public float BossHoldScale;
		public float BossHolsterScale;
		public float Unknown6;
		public float Unknown7;
		public float UseDuration;
		public float Unknown8;
		public short NumberOfUses;
		public ushort Flags3;
		public float Unknown9;
		public float Unknown10;
		public float Unknown11;
		public List<EquipmentCameraBlock> EquipmentCamera;
		public List<HealthPackBlock> HealthPack;
		public List<PowerupBlock> Powerup;
		public List<ObjectCreationBlock> ObjectCreation;
		public List<DestructionBlock> Destruction;
		public List<RadarManipulationBlock> RadarManipulation;
		public float Unknown12;
		public float Unknown13;
		public float Unknown14;
		public List<InvisibilityBlock> Invisibility;
		public List<InvincibilityBlock> Invincibility;
		public List<RegeneratorBlock> Regenerator;
		public float Unknown15;
		public float Unknown16;
		public float Unknown17;
		public List<ForcedReloadBlock> ForcedReload;
		public List<ConcussiveBlastBlock> ConcussiveBlast;
		public List<TankModeBlock> TankMode;
		public List<MagPulseBlock> MagPulse;
		public List<HologramBlock> Hologram;
		public List<ReactiveArmorBlock> ReactiveArmor;
		public List<BombRunBlock> BombRun;
		public List<ArmorLockBlock> ArmorLock;
		public List<AdrenalineBlock> Adrenaline;
		public List<LightningStrikeBlock> LightningStrike;
		public List<ScramblerBlock> Scrambler;
		public List<WeaponJammerBlock> WeaponJammer;
		public List<AmmoPackBlock> AmmoPack;
		public List<VisionBlock> Vision;
		public HaloTag HudInterface;
		public HaloTag PickupSound;
		public HaloTag EmptySound;
		public HaloTag ActivationEffect;
		public HaloTag ActiveEffect;
		public HaloTag DeactivationEffect;
		public StringId EnterAnimation;
		public StringId IdleAnimation;
		public StringId ExitAnimation;

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

		[TagStructure(Size = 0x10)]
		public class PredictedBitmap
		{
			public HaloTag Bitmap;
		}

		[TagStructure(Size = 0x3C)]
		public class EquipmentCameraBlock
		{
			public short Flags;
			public short Unknown;
			public StringId CameraMarkerName;
			public StringId CameraSubmergedMarkerName;
			public Angle PitchAutoLevel;
			public Angle PitchRangeMin;
			public Angle PitchRangeMax;
			public List<CameraTrack> CameraTracks;
			public Angle Unknown2;
			public Angle Unknown3;
			public Angle Unknown4;
			public List<UnknownBlock> Unknown5;

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
		}

		[TagStructure(Size = 0x3C)]
		public class HealthPackBlock
		{
			public float Unknown;
			public float Unknown2;
			public float ShieldsGiven;
			public HaloTag Unknown3;
			public HaloTag Unknown4;
			public HaloTag Unknown5;
		}

		[TagStructure(Size = 0x4)]
		public class PowerupBlock
		{
			public PowerupTraitSetValue PowerupTraitSet;

			public enum PowerupTraitSetValue : int
			{
				Red,
				Blue,
				Yellow,
			}
		}

		[TagStructure(Size = 0x34)]
		public class ObjectCreationBlock
		{
			public HaloTag Object;
			public HaloTag Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float ObjectForce;
			public float Unknown5;
		}

		[TagStructure(Size = 0x30)]
		public class DestructionBlock
		{
			public HaloTag DestroyEffect;
			public HaloTag DestroyDamageEffect;
			public float Unknown;
			public float SelfDestructionTime;
			public float Unknown2;
			public float Unknown3;
		}

		[TagStructure(Size = 0x10)]
		public class RadarManipulationBlock
		{
			public float Unknown;
			public float FakeBlipRadius;
			public int FakeBlipCount;
			public float Unknown2;
		}

		[TagStructure(Size = 0x8)]
		public class InvisibilityBlock
		{
			public float Unknown;
			public float Unknown2;
		}

		[TagStructure(Size = 0x2C)]
		public class InvincibilityBlock
		{
			public StringId NewPlayerMaterial;
			public short NewPlayerMaterialGlobalIndex;
			public short Unknown;
			public float Unknown2;
			public HaloTag Unknown3;
			public HaloTag Unknown4;
		}

		[TagStructure(Size = 0x10)]
		public class RegeneratorBlock
		{
			public HaloTag RegeneratingEffect;
		}

		[TagStructure(Size = 0x14)]
		public class ForcedReloadBlock
		{
			public HaloTag Effect;
			public float Unknown;
		}

		[TagStructure(Size = 0x20)]
		public class ConcussiveBlastBlock
		{
			public HaloTag Unknown;
			public HaloTag Unknown2;
		}

		[TagStructure(Size = 0x28)]
		public class TankModeBlock
		{
			public StringId NewPlayerMaterial;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public HaloTag ActiveHud;
		}

		[TagStructure(Size = 0x34)]
		public class MagPulseBlock
		{
			public HaloTag Unknown;
			public HaloTag Unknown2;
			public HaloTag Unknown3;
			public float Unknown4;
		}

		[TagStructure(Size = 0x6C)]
		public class HologramBlock
		{
			public float Unknown;
			public HaloTag ActiveEffect;
			public HaloTag Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public HaloTag DeathEffect;
			public float Unknown6;
			public float Unknown7;
			public byte[] Function;
			public HaloTag NavPointHud;
		}

		[TagStructure(Size = 0x4C)]
		public class ReactiveArmorBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public HaloTag Unknown4;
			public HaloTag Unknown5;
			public HaloTag Unknown6;
			public HaloTag Unknown7;
		}

		[TagStructure(Size = 0x34)]
		public class BombRunBlock
		{
			public int Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public HaloTag Projectile;
			public HaloTag ThrowSound;
		}

		[TagStructure(Size = 0x20)]
		public class ArmorLockBlock
		{
			public HaloTag Unknown;
			public HaloTag Unknown2;
		}

		[TagStructure(Size = 0x24)]
		public class AdrenalineBlock
		{
			public float Unknown;
			public HaloTag Unknown2;
			public HaloTag Unknown3;
		}

		[TagStructure(Size = 0x14)]
		public class LightningStrikeBlock
		{
			public float Unknown;
			public HaloTag Unknown2;
		}

		[TagStructure(Size = 0x24)]
		public class ScramblerBlock
		{
			public float Unknown;
			public HaloTag Unknown2;
			public int Unknown3;
			public int Unknown4;
			public int Unknown5;
			public int Unknown6;
		}

		[TagStructure(Size = 0x24)]
		public class WeaponJammerBlock
		{
			public float Unknown;
			public HaloTag Unknown2;
			public int Unknown3;
			public int Unknown4;
			public int Unknown5;
			public int Unknown6;
		}

		[TagStructure(Size = 0x34)]
		public class AmmoPackBlock
		{
			public float Unknown;
			public int Unknown2;
			public int Unknown3;
			public float Unknown4;
			public int Unknown5;
			public int Unknown6;
			public List<Weapon> Weapons;
			public HaloTag Unknown7;

			[TagStructure(Size = 0x18)]
			public class Weapon
			{
				public StringId Name;
				public HaloTag WeaponObject;
				public int Unknown;
			}
		}

		[TagStructure(Size = 0x20)]
		public class VisionBlock
		{
			public HaloTag ScreenEffect;
			public HaloTag Unknown;
		}
	}
}
