using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Class = "obje", Size = 0x120)]
    public abstract class GameObject
    {
        [MaxVersion(EngineVersion.V10_1_449175_Live)] public ObjectTypeValueOld ObjectTypeOld;
        [MinVersion(EngineVersion.V11_1_498295_Live)] public ObjectTypeValueNew ObjectTypeNew;
        public byte Padding;
        public FlagsValue Flags;
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
        public TagInstance Model;
        [MaxVersion(EngineVersion.V10_1_449175_Live)] public TagInstance CrateObject;
        public TagInstance CollisionDamage;
        public List<EarlyMoverProperty> EarlyMoverProperties;
        public TagInstance CreationEffect;
        public TagInstance MaterialEffects;
        public TagInstance ArmorSounds;
        public TagInstance MeleeImpact;
        public List<AiProperty> AiProperties;
        public List<Function> Functions;
        public short HudTextMessageIndex;
        public short Unknown2;
        public List<Attachment> Attachments;
        public List<Widget> Widgets;
        public List<ChangeColor> ChangeColors;
        public List<NodeMap> NodeMaps;
        public List<MultiplayerObjectProperty> MultiplayerObjectProperties;
        [MinVersion(EngineVersion.V11_1_498295_Live)] public TagInstance SimulationInterpolation;
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;
        public List<ModelObjectDatum> ModelObjectData;

        [Flags]
        public enum FlagsValue : ushort
        {
            None = 0,
            DoesNotCastShadow = 1 << 0,
            SearchCardinalDirectionMaps = 1 << 1,
            Bit2 = 1 << 2,
            NotAPathfindingObstacle = 1 << 3,
            ExtensionOfParent = 1 << 4,
            DoesNotCauseCollisionDamage = 1 << 5,
            EarlyMover = 1 << 6,
            EarlyMoverLocalizedPhysics = 1 << 7,
            UseStaticMassiveLightmapSample = 1 << 8,
            ObjectScalesAttachments = 1 << 9,
            InheritsPlayersAppearance = 1 << 10,
            DeadBipedsCantLocalize = 1 << 11,
            AttachToClustersByDynamicSphere = 1 << 12,
            EffectsDoNotSpawnObjectsInMultiplayer = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15
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
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
        }

        [TagStructure(Size = 0xC)]
        public class AiProperty
        {
            public uint Flags;
            public StringId AiTypeName;
            public ObjectSizeValue Size;
            public AiDistanceValue LeapJumpSpeed;
        }

        public enum ObjectSizeValue : short
        {
            Default,
            Tiny,
            Small,
            Medium,
            Large,
            Huge,
            Immobile,
        }

        public enum AiDistanceValue : short
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
            public TagInstance Attachment2;
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
            public TagInstance Type;
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
            public ObjectShapeValue Shape;
            public SpawnTimerModeValue SpawnTimerMode;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public float RadiusWidth;
            public float Length;
            public float Top;
            public float Bottom;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public int Unknown5;
            public int Unknown6;
            public TagInstance ChildObject;
            public int Unknown7;
            public TagInstance ShapeShader;
            public TagInstance UnknownShader;
            public TagInstance Unknown8;
            public TagInstance Unknown9;
            public TagInstance Unknown10;
            public TagInstance Unknown11;
            public TagInstance Unknown12;
            public TagInstance Unknown13;
        }

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

        public enum SpawnTimerModeValue : sbyte
        {
            DefaultOne,
            Multiple,
        }
        public enum ObjectShapeValue : sbyte
        {
            None,
            Sphere,
            Cylinder,
            Box,
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
    }

    public enum ObjectTypeValueOld : sbyte
    {
        None = -1,
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

    public enum ObjectTypeValueNew : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Armor, // Why couldn't they have just put Armor at the end...? :(
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
}
