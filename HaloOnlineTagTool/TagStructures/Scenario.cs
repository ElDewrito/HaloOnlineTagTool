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
    [TagStructure(Name = "scenario", Class = "scnr", Size = 0x824, MaxVersion = EngineVersion.V10_1_449175_Live)]
    [TagStructure(Name = "scenario", Class = "scnr", Size = 0x834, MinVersion = EngineVersion.V11_1_498295_Live)]
    public class Scenario
    {
        public MapTypeValue MapType;
        public ushort Flags;
        public int Unknown;
        public int MapId;
        public Angle LocalNorth;
        public float SandboxBudget;
        public List<StructureBsp> StructureBsps;
        public TagInstance Unknown2;
        public List<SkyReference> SkyReferences;
        public List<BspGroup> BspGroups;
        public List<ScenarioBspAudibilityBlock> ScenarioBspAudibility;
        public List<ScenarioZonesetGroup> ScenarioZonesetGroups;
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
        public List<ObjectName> ObjectNames;
        public List<SceneryBlock> Scenery;
        public List<SceneryPaletteBlock> SceneryPalette;
        public List<Biped> Bipeds;
        public List<BipedPaletteBlock> BipedPalette;
        public List<Vehicle> Vehicles;
        public List<VehiclePaletteBlock> VehiclePalette;
        public List<EquipmentBlock> Equipment;
        public List<EquipmentPaletteBlock> EquipmentPalette;
        public List<Weapon> Weapons;
        public List<WeaponPaletteBlock> WeaponPalette;
        public List<DeviceGroup> DeviceGroups;
        public List<Machine> Machines;
        public List<MachinePaletteBlock> MachinePalette;
        public List<Terminal> Terminals;
        public List<TerminalPaletteBlock> TerminalPalette;
        public List<AlternateRealityDevice> AlternateRealityDevices;
        public List<AlternateRealityDevicePaletteBlock> AlternateRealityDevicePalette;
        public List<Control> Controls;
        public List<ControlPaletteBlock> ControlPalette;
        public List<SoundSceneryBlock> SoundScenery;
        public List<SoundSceneryPaletteBlock> SoundSceneryPalette;
        public List<Giant> Giants;
        public List<GiantPaletteBlock> GiantPalette;
        public List<EffectSceneryBlock> EffectScenery;
        public List<EffectSceneryBlock2> EffectScenery2;
        public List<LightVolume> LightVolumes;
        public List<LightVolumesPaletteBlock> LightVolumesPalette;
        public List<SandboxObject> SandboxVehicles;
        public List<SandboxObject> SandboxWeapons;
        public List<SandboxObject> SandboxEquipment;
        public List<SandboxObject> SandboxScenery;
        public List<SandboxObject> SandboxTeleporters;
        public List<SandboxObject> SandboxGoalObjects;
        public List<SandboxObject> SandboxSpawning;
        public List<SoftCeiling> SoftCeilings;
        public List<PlayerStartingProfileBlock> PlayerStartingProfile;
        public List<PlayerStartingLocation> PlayerStartingLocations;
        public List<TriggerVolume> TriggerVolumes;
        public uint Unknown26;
        public uint Unknown27;
        public uint Unknown28;
        public uint Unknown29;
        public uint Unknown30;
        public uint Unknown31;
        public List<UnknownBlock> Unknown32;
        public uint Unknown35;
        public uint Unknown36;
        public uint Unknown37;
        public uint Unknown38;
        public uint Unknown39;
        public uint Unknown40;
        public uint Unknown41;
        public uint Unknown42;
        public uint Unknown43;
        public List<UnknownBlock> Unknown44;
        public uint Unknown45;
        public uint Unknown46;
        public uint Unknown47;
        public uint Unknown48;
        public uint Unknown49;
        public uint Unknown50;
        public uint Unknown51;
        public uint Unknown52;
        public uint Unknown53;
        public uint Unknown54;
        public uint Unknown55;
        public uint Unknown56;
        public uint Unknown57;
        public uint Unknown58;
        public uint Unknown59;
        public uint Unknown60;
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
        public List<Decal> Decals;
        public List<DecalPaletteBlock> DecalPalette;
        public uint Unknown81;
        public uint Unknown82;
        public uint Unknown83;
        public List<StylePaletteBlock> StylePalette;
        public List<SquadGroup> SquadGroups;
        public List<Squad> Squads;
        public List<Zone> Zones;
        public List<UnknownBlock2> Unknown84;
        public uint Unknown85;
        public uint Unknown86;
        public uint Unknown87;
        public List<CharacterPaletteBlock> CharacterPalette;
        public uint Unknown88;
        public uint Unknown89;
        public uint Unknown90;
        public List<AiPathfindingDatum> AiPathfindingData;
        public uint Unknown91;
        public uint Unknown92;
        public uint Unknown93;
        public byte[] ScriptStrings;
        public List<Script> Scripts;
        public List<Global> Globals;
        public List<ScriptReference> ScriptReferences;
        public uint Unknown94;
        public uint Unknown95;
        public uint Unknown96;
        public List<ScriptingDatum> ScriptingData;
        public List<CutsceneFlag> CutsceneFlags;
        public List<CutsceneCameraPoint> CutsceneCameraPoints;
        public List<CutsceneTitle> CutsceneTitles;
        public TagInstance CustomObjectNameStrings;
        public TagInstance ChapterTitleStrings;
        [MinVersion(EngineVersion.V11_1_498295_Live)]
        public TagInstance Unknown156;
        public List<ScenarioResource> ScenarioResources;
        public List<UnitSeatsMappingBlock> UnitSeatsMapping;
        public List<ScenarioKillTrigger> ScenarioKillTriggers;
        public List<ScenarioSafeTrigger> ScenarioSafeTriggers;
        public List<ScriptExpression> ScriptExpressions;
        public uint Unknown97;
        public uint Unknown98;
        public uint Unknown99;
        public uint Unknown100;
        public uint Unknown101;
        public uint Unknown102;
        public List<BackgroundSoundEnvironmentPaletteBlock> BackgroundSoundEnvironmentPalette;
        public uint Unknown103;
        public uint Unknown104;
        public uint Unknown105;
        public uint Unknown106;
        public uint Unknown107;
        public uint Unknown108;
        public List<UnknownBlock3> Unknown109;
        public List<FogBlock> Fog;
        public List<CameraFxBlock> CameraFx;
        public uint Unknown110;
        public uint Unknown111;
        public uint Unknown112;
        public uint Unknown113;
        public uint Unknown114;
        public uint Unknown115;
        public uint Unknown116;
        public uint Unknown117;
        public uint Unknown118;
        public List<ScenarioClusterDatum> ScenarioClusterData;
        public uint Unknown119;
        public uint Unknown120;
        public uint Unknown121;
        public int ObjectSalts1;
        public int ObjectSalts2;
        public int ObjectSalts3;
        public int ObjectSalts4;
        public int ObjectSalts5;
        public int ObjectSalts6;
        public int ObjectSalts7;
        public int ObjectSalts8;
        public int ObjectSalts9;
        public int ObjectSalts10;
        public int ObjectSalts11;
        public int ObjectSalts12;
        public int ObjectSalts13;
        public int ObjectSalts14;
        public int ObjectSalts15;
        public int ObjectSalts16;
        public int ObjectSalts17;
        public int ObjectSalts18;
        public int ObjectSalts19;
        public int ObjectSalts20;
        public int ObjectSalts21;
        public int ObjectSalts22;
        public int ObjectSalts23;
        public int ObjectSalts24;
        public int ObjectSalts25;
        public int ObjectSalts26;
        public int ObjectSalts27;
        public int ObjectSalts28;
        public int ObjectSalts29;
        public int ObjectSalts30;
        public int ObjectSalts31;
        public int ObjectSalts32;
        public List<SpawnDatum> SpawnData;
        public TagInstance SoundEffectsCollection;
        public List<Crate> Crates;
        public List<CratePaletteBlock> CratePalette;
        public List<FlockPaletteBlock> FlockPalette;
        public List<Flock> Flocks;
        public TagInstance SubtitleStrings;
        public uint Unknown122;
        public uint Unknown123;
        public uint Unknown124;
        public List<CreaturePaletteBlock> CreaturePalette;
        public List<EditorFolder> EditorFolders;
        public TagInstance TerritoryLocationNameStrings;
        public uint Unknown125;
        public uint Unknown126;
        public List<MissionDialogueBlock> MissionDialogue;
        public TagInstance ObjectiveStrings;
        public List<Interpolator> Interpolators;
        public uint Unknown127;
        public uint Unknown128;
        public uint Unknown129;
        public uint Unknown130;
        public uint Unknown131;
        public uint Unknown132;
        public List<SimulationDefinitionTableBlock> SimulationDefinitionTable;
        public TagInstance DefaultCameraFx;
        public TagInstance DefaultScreenFx;
        public TagInstance Unknown133;
        public TagInstance SkyParameters;
        public TagInstance GlobalLighing;
        public TagInstance Lightmap;
        public TagInstance PerformanceThrottles;
        public List<UnknownBlock4> Unknown134;
        public List<AiObjective> AiObjectives;
        public List<DesignerZoneset> DesignerZonesets;
        public List<UnknownBlock5> Unknown135;
        public uint Unknown136;
        public uint Unknown137;
        public uint Unknown138;
        public List<Cinematic> Cinematics;
        public List<CinematicLightingBlock> CinematicLighting;
        public uint Unknown139;
        public uint Unknown140;
        public uint Unknown141;
        public List<ScenarioMetagameBlock> ScenarioMetagame;
        public List<UnknownBlock6> Unknown142;
        public List<UnknownBlock7> Unknown143;
        public uint Unknown144;
        public uint Unknown145;
        public uint Unknown146;
        public uint Unknown147;
        public uint Unknown148;
        public uint Unknown149;
        public uint Unknown150;
        public uint Unknown151;
        public uint Unknown152;
        public TagInstance Unknown153;
        public TagInstance Unknown154;
        public List<UnknownBlock8> Unknown155;

        public enum MapTypeValue : short
        {
            SinglePlayer,
            Multiplayer,
            MainMenu,
        }

        [TagStructure(Size = 0x6C)]
        public class StructureBsp
        {
            public TagInstance StructureBsp2;
            public TagInstance Design;
            public TagInstance Lighting;
            public int Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            public short Unknown8;
            public TagInstance Cubemap;
            public TagInstance Wind;
            public int Unknown9;
        }

        [TagStructure(Size = 0x14)]
        public class SkyReference
        {
            public TagInstance SkyObject;
            public short NameIndex;
            public ushort ActiveBsps;
        }

        [TagStructure(Size = 0x2C)]
        public class BspGroup
        {
            public uint IncludedBsps;
            public int Unknown;
            public List<BspChecksum> BspChecksums;
            public List<Bsp> Bsps;
            public List<Bsp2> Bsps2;

            [TagStructure(Size = 0x4)]
            public class BspChecksum
            {
                public int StructureChecksum;
            }

            [TagStructure(Size = 0x54)]
            public class Bsp
            {
                public List<Cluster> Clusters;
                public List<Cluster2> Clusters2;
                public List<ClusterSky> ClusterSkies;
                public List<ClusterVisibleSky> ClusterVisibleSkies;
                public List<UnknownBlock> Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<Cluster3> Clusters3;

                [TagStructure(Size = 0xC)]
                public class Cluster
                {
                    public List<Bsp> Bsps;

                    [TagStructure(Size = 0xC)]
                    public class Bsp
                    {
                        public List<UnknownBlock> Unknown;

                        [TagStructure(Size = 0x4)]
                        public class UnknownBlock
                        {
                            public uint Allow;
                        }
                    }
                }

                [TagStructure(Size = 0xC)]
                public class Cluster2
                {
                    public List<Bsp> Bsps;

                    [TagStructure(Size = 0xC)]
                    public class Bsp
                    {
                        public List<UnknownBlock> Unknown;

                        [TagStructure(Size = 0x4)]
                        public class UnknownBlock
                        {
                            public uint Allow;
                        }
                    }
                }

                [TagStructure(Size = 0x1)]
                public class ClusterSky
                {
                    public sbyte SkyIndex;
                }

                [TagStructure(Size = 0x1)]
                public class ClusterVisibleSky
                {
                    public sbyte SkyIndex;
                }

                [TagStructure(Size = 0x4)]
                public class UnknownBlock
                {
                    public uint Unknown;
                }

                [TagStructure(Size = 0x4)]
                public class UnknownBlock2
                {
                    public uint Unknown;
                }

                [TagStructure(Size = 0xC)]
                public class Cluster3
                {
                    public List<UnknownBlock> Unknown;

                    [TagStructure(Size = 0x1)]
                    public class UnknownBlock
                    {
                        public sbyte Unknown;
                    }
                }
            }

            [TagStructure(Size = 0x18)]
            public class Bsp2
            {
                public List<UnknownBlock> Unknown;
                public List<UnknownBlock2> Unknown2;

                [TagStructure(Size = 0xC)]
                public class UnknownBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public int Unknown3;
                    public short Unknown4;
                    public short Unknown5;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock2
                {
                    public short Unknown;
                }
            }
        }

        [TagStructure(Size = 0x64)]
        public class ScenarioBspAudibilityBlock
        {
            public int DoorPortalCount;
            public int UniqueClusterCount;
            public float ClusterDistanceBoundsMin;
            public float ClusterDistanceBoundsMax;
            public List<EncodedDoorPa> EncodedDoorPas;
            public List<ClusterDoorPortalEncodedPa> ClusterDoorPortalEncodedPas;
            public List<AiDeafeningPa> AiDeafeningPas;
            public List<ClusterDistance> ClusterDistances;
            public List<Bsp> Bsps;
            public List<BspClusterListBlock> BspClusterList;
            public List<ClusterMappingBlock> ClusterMapping;

            [TagStructure(Size = 0x4)]
            public class EncodedDoorPa
            {
                public int Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class ClusterDoorPortalEncodedPa
            {
                public int Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class AiDeafeningPa
            {
                public int Unknown;
            }

            [TagStructure(Size = 0x1)]
            public class ClusterDistance
            {
                public sbyte Unknown;
            }

            [TagStructure(Size = 0x8)]
            public class Bsp
            {
                public int Start;
                public int Count;
            }

            [TagStructure(Size = 0x8)]
            public class BspClusterListBlock
            {
                public int StartIndex;
                public int ClusterCount;
            }

            [TagStructure(Size = 0x2)]
            public class ClusterMappingBlock
            {
                public short Index;
            }
        }

        [TagStructure(Size = 0x24)]
        public class ScenarioZonesetGroup
        {
            public StringId Name;
            public int BspGroupIndex;
            public int ImportLoadedBsps;
            public uint LoadedBsps;
            public uint LoadedDesignerZonesets;
            public uint UnloadedDesignerZonesets;
            public uint LoadedCinematicZonesets;
            public int BspAtlasIndex;
            public int ScenarioBspAudibilityIndex;
        }

        [TagStructure(Size = 0x24)]
        public class ObjectName
        {
            [TagField(Length = 32)]
            public string Name;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public byte Padding; // FIXME: This technically isn't padding and object type is a short here!
            public short PlacementIndex;
        }

        [TagStructure(Size = 0xB8)]
        public class SceneryBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public PathfindingPolicyValue PathfindingPolicy;
            public LightmappingPolicyValue LightmappingPolicy;
            public List<PathfindingReference> PathfindingReferences;
            public short Unknown11;
            public short Unknown12;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown13;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown14;
            public short Unknown15;
            public short AttachedNameIndex;
            public uint Unknown16;
            public uint Unknown17;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown18;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum PathfindingPolicyValue : short
            {
                TagDefault,
                Dynamic,
                CutOut,
                Standard,
                None,
            }

            public enum LightmappingPolicyValue : short
            {
                TagDefault,
                Dynamic,
                PerVertex,
            }

            [TagStructure(Size = 0x4)]
            public class PathfindingReference
            {
                public short BspIndex;
                public short PathfindingObjectIndex;
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class SceneryPaletteBlock
        {
            public TagInstance Scenery;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x78)]
        public class Biped
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public float BodyVitalityPercentage;
            public uint Flags;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class BipedPaletteBlock
        {
            public TagInstance Biped;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0xAC)]
        public class Vehicle
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public float BodyVitalityPercentage;
            public uint Flags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown11;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown12;
            public short Unknown13;
            public short AttachedNameIndex;
            public uint Unknown14;
            public uint Unknown15;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown16;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class VehiclePaletteBlock
        {
            public TagInstance Vehicle;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x8C)]
        public class EquipmentBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public uint EquipmentFlags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown7;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown8;
            public short Unknown9;
            public short AttachedNameIndex;
            public uint Unknown10;
            public uint Unknown11;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown12;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class EquipmentPaletteBlock
        {
            public TagInstance Equipment;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0xAC)]
        public class Weapon
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short RoundsLeft;
            public short RoundsLoaded;
            public uint WeaponFlags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown11;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown12;
            public short Unknown13;
            public short AttachedNameIndex;
            public uint Unknown14;
            public uint Unknown15;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown16;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class WeaponPaletteBlock
        {
            public TagInstance Weapon;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x2C)]
        public class DeviceGroup
        {
            [TagField(Length = 32)]
            public string Name;
            public float InitialValue;
            public uint Flags;
            public short EditorFolderIndex;
            public short Unknown;
        }

        [TagStructure(Size = 0x8C)]
        public class Machine
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint MachineFlags;
            public List<PathfindingReference> PathfindingReferences;
            public PathfindingPolicyValue PathfindingPolicy;
            public short Unknown11;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            [TagStructure(Size = 0x4)]
            public class PathfindingReference
            {
                public short BspIndex;
                public short PathfindingObjectIndex;
            }

            public enum PathfindingPolicyValue : short
            {
                TagDefault,
                CutOut,
                Sectors,
                Discs,
                None,
            }
        }

        [TagStructure(Size = 0x30)]
        public class MachinePaletteBlock
        {
            public TagInstance Machine;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x7C)]
        public class Terminal
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint Unknown11;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class TerminalPaletteBlock
        {
            public TagInstance Terminal;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0xBC)]
        public class AlternateRealityDevice
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            [TagField(Length = 32)]
            public string TapScriptName;
            [TagField(Length = 32)]
            public string HoldScriptName;
            public short TapScriptIndex;
            public short HoldScriptIndex;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class AlternateRealityDevicePaletteBlock
        {
            public TagInstance ArgDevice;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x80)]
        public class Control
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint ControlFlags;
            public short Unknown11;
            public short Unknown12;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class ControlPaletteBlock
        {
            public TagInstance Control;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x70)]
        public class SoundSceneryBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public int VolumeType;
            public float Height;
            public float OverrideDistanceMin;
            public float OverrideDistanceMax;
            public Angle OverrideConeAngleMin;
            public Angle OverrideConeAngleMax;
            public float OverrideOuterConeGain;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class SoundSceneryPaletteBlock
        {
            public TagInstance SoundScenery;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x88)]
        public class Giant
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public float BodyVitalityPercentage;
            public uint Flags;
            public short Unknown11;
            public short Unknown12;
            public List<PathfindingReference> PathfindingReferences;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            [TagStructure(Size = 0x4)]
            public class PathfindingReference
            {
                public short BspIndex;
                public short PathfindingObjectIndex;
            }
        }

        [TagStructure(Size = 0x30)]
        public class GiantPaletteBlock
        {
            public TagInstance Giant;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x54)]
        public class EffectSceneryBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class EffectSceneryBlock2
        {
            public TagInstance EffectScenery;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x8C)]
        public class LightVolume
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public TypeValue2 Type2;
            public ushort Flags;
            public LightmapTypeValue LightmapType;
            public ushort LightmapFlags;
            public float LightmapHalfLife;
            public float LightmapLightScale;
            public float X;
            public float Y;
            public float Z;
            public float Width;
            public float HeightScale;
            public Angle FieldOfView;
            public float FalloffDistance;
            public float CutoffDistance;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum TypeValue2 : short
            {
                Sphere,
                Projective,
            }

            public enum LightmapTypeValue : short
            {
                UseLightTagSetting,
                DynamicOnly,
                DynamicWithLightmaps,
                LightmapsOnly,
            }
        }

        [TagStructure(Size = 0x30)]
        public class LightVolumesPaletteBlock
        {
            public TagInstance LightVolume;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x30)]
        public class SandboxObject
        {
            public TagInstance Object;
            public StringId Name;
            public int MaxAllowed;
            public float Cost;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [TagStructure(Size = 0xC)]
        public class SoftCeiling
        {
            public short Type;
            public short Unknown;
            public StringId Name;
            public short Unknown2;
            public short Unknown3;
        }

        [TagStructure(Size = 0x60)]
        public class PlayerStartingProfileBlock
        {
            [TagField(Length = 32)]
            public string Name;
            public float StartingHealthDamage;
            public float StartingShieldDamage;
            public TagInstance PrimaryWeapon;
            public short RoundsLoaded;
            public short RoundsTotal;
            public TagInstance SecondaryWeapon;
            public short RoundsLoaded2;
            public short RoundsTotal2;
            public uint Unknown;
            public uint Unknown2;
            public byte StartingFragGrenadeCount;
            public byte StartingPlasmaGrenadeCount;
            public byte StartingSpikeGrenadeCount;
            public byte StartingFirebombGrenadeCount;
            public short Unknown3;
            public short Unknown4;
        }

        [TagStructure(Size = 0x1C)]
        public class PlayerStartingLocation
        {
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle FacingY;
            public Angle FacingP;
            public short Unknown;
            public short Unknown2;
            public short EditorFolderIndex;
            public short Unknown3;
        }

        [TagStructure(Size = 0x7C)]
        public class TriggerVolume
        {
            public StringId Name;
            public short ObjectName;
            public short Unknown;
            public StringId NodeName;
            public short Unknown2;
            public short Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public float ExtentsX;
            public float ExtentsY;
            public float ExtentsZ;
            public uint Unknown10;
            public List<UnknownBlock> Unknown11;
            public List<UnknownBlock2> Unknown12;
            public uint Unknown13;
            public uint Unknown14;
            public uint Unknown15;
            public uint Unknown16;
            public uint Unknown17;
            public uint Unknown18;
            public uint Unknown19;
            public short KillVolume;
            public short EditorFolderIndex;

            [TagStructure(Size = 0x14)]
            public class UnknownBlock
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x50)]
            public class UnknownBlock2
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
            }
        }

        [TagStructure(Size = 0x14)]
        public class UnknownBlock
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [TagStructure(Size = 0x24)]
        public class Decal
        {
            public short PaletteIndex;
            public sbyte Yaw;
            public sbyte Pitch;
            public float I;
            public float J;
            public float K;
            public float W;
            public float X;
            public float Y;
            public float Z;
            public float Scale;
        }

        [TagStructure(Size = 0x10)]
        public class DecalPaletteBlock
        {
            public TagInstance Decal;
        }

        [TagStructure(Size = 0x10)]
        public class StylePaletteBlock
        {
            public TagInstance Style;
        }

        [TagStructure(Size = 0x28)]
        public class SquadGroup
        {
            [TagField(Length = 32)]
            public string Name;
            public short ParentIndex;
            public short ObjectiveIndex;
            public short Unknown;
            public short EditorFolderIndex;
        }

        [TagStructure(Size = 0x68)]
        public class Squad
        {
            [TagField(Length = 32)]
            public string Name;
            public uint Flags;
            public TeamValue Team;
            public short ParentSquadGroupIndex;
            public short ParentZone;
            public short ObjectiveIndex;
            public short ObjectiveRoleIndex;
            public short EditorFolderIndex;
            public List<GroupLocation> GroupLocations;
            public List<SingleLocation> SingleLocations;
            public StringId SquadTemplateName;
            [TagField(Flags = TagFieldFlags.Short)]
            public TagInstance SquadTemplate;
            public List<SquadABlock> SquadA;
            public List<SquadBBlock> SquadB;

            public enum TeamValue : short
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

            [TagStructure(Size = 0x6C)]
            public class GroupLocation
            {
                public short Unknown;
                public short Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public StringId Name;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public short ReferenceFrame;
                public short Unknown5;
                public Angle FacingI;
                public Angle FacingJ;
                public Angle FacingK;
                public StringId FormationType;
                public uint Unknown6;
                public short Unknown7;
                public short CommandScriptIndex;
                [TagField(Length = 32)]
                public string CommandScriptName;
                public StringId InitialState;
                public short Unknown8;
                public short Unknown9;
                public List<MultiStateBlock> MultiState;

                [TagStructure(Size = 0x38)]
                public class MultiStateBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public StringId State;
                    public uint Unknown5;
                    [TagField(Length = 32)]
                    public string CommandScriptName;
                    public short CommandScriptIndex;
                    public short Unknown6;
                }
            }

            [TagStructure(Size = 0x90)]
            public class SingleLocation
            {
                public short Unknown;
                public short Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public StringId Name;
                public short SquadMemberIndex;
                public short Unknown5;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public short ReferenceFrame;
                public short Unknown6;
                public Angle FacingI;
                public Angle FacingJ;
                public Angle FacingK;
                public ushort Flags;
                public short CharacterType;
                public short InitialPrimaryWeapon;
                public short InitialSecondaryWeapon;
                public short InitialEquipment;
                public short Vehicle;
                public SeatTypeValue SeatType;
                public InitialGrenadesValue InitialGrenades;
                public uint Unknown7;
                public StringId ActorVariant;
                public StringId VehicleVariant;
                public float InitialMovementDistance;
                public InitialMovementModeValue InitialMovementMode;
                public short EmitterVehicle;
                public short EmitterGiant;
                public short EmitterBiped;
                [TagField(Length = 32)]
                public string CommandScriptName;
                public short CommandScriptIndex;
                public short Unknown8;
                public StringId InitialState;
                public short Unknown9;
                public short Unknown10;
                public List<MultiStateBlock> MultiState;

                public enum SeatTypeValue : short
                {
                    Default,
                    SpawnInPassenger,
                    SpawnInGunner,
                    SpawnInDriver,
                    SpawnOutOfVehicle,
                    SpawnVehicleOnly = 6,
                    SpawnInPassenger2,
                }

                public enum InitialGrenadesValue : short
                {
                    None,
                    Frag,
                    Plasma,
                    Spike,
                    Fire,
                }

                public enum InitialMovementModeValue : short
                {
                    Default,
                    Climbing,
                    Flying,
                }

                [TagStructure(Size = 0x38)]
                public class MultiStateBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public StringId State;
                    public uint Unknown5;
                    [TagField(Length = 32)]
                    public string CommandScriptName;
                    public short CommandScriptIndex;
                    public short Unknown6;
                }
            }

            [TagStructure(Size = 0x84)]
            public class SquadABlock
            {
                public StringId Name;
                public ushort Difficulty;
                public short Unknown;
                public short MinimumRound;
                public short MaximumRound;
                public short Unknown2;
                public short Unknown3;
                public short Count;
                public short Unknown4;
                public List<Actor> Actors;
                public List<Weapon> Weapons;
                public List<SecondaryWeapon> SecondaryWeapons;
                public List<EquipmentBlock> Equipment;
                public short Unknown5;
                public short Vehicle;
                public StringId VehicleVariant;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public uint Unknown12;
                public uint Unknown13;
                public short Unknown14;
                public short Unknown15;
                public uint Unknown16;
                public short Unknown17;
                public short Unknown18;
                public uint Unknown19;
                public uint Unknown20;
                public uint Unknown21;

                [TagStructure(Size = 0x10)]
                public class Actor
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Character;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class Weapon
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon2;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class SecondaryWeapon
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class EquipmentBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Equipment;
                    public short Probability;
                }
            }

            [TagStructure(Size = 0x84)]
            public class SquadBBlock
            {
                public StringId Name;
                public ushort Difficulty;
                public short Unknown;
                public short MinimumRound;
                public short MaximumRound;
                public short Unknown2;
                public short Unknown3;
                public short Count;
                public short Unknown4;
                public List<Actor> Actors;
                public List<Weapon> Weapons;
                public List<SecondaryWeapon> SecondaryWeapons;
                public List<EquipmentBlock> Equipment;
                public short Unknown5;
                public short Vehicle;
                public StringId VehicleVariant;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public uint Unknown12;
                public uint Unknown13;
                public short Unknown14;
                public short Unknown15;
                public uint Unknown16;
                public short Unknown17;
                public short Unknown18;
                public uint Unknown19;
                public uint Unknown20;
                public uint Unknown21;

                [TagStructure(Size = 0x10)]
                public class Actor
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Character;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class Weapon
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon2;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class SecondaryWeapon
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class EquipmentBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Equipment;
                    public short Probability;
                }
            }
        }

        [TagStructure(Size = 0x3C)]
        public class Zone
        {
            [TagField(Length = 32)]
            public string Name;
            public int Unknown;
            public List<FiringPosition> FiringPositions;
            public List<Area> Areas;

            [TagStructure(Size = 0x28)]
            public class FiringPosition
            {
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public short ReferenceFrame;
                public short Unknown;
                public ushort Flags;
                public short Unknown2;
                public short AreaIndex;
                public short ClusterIndex;
                public short Unknown3;
                public short Unknown4;
                public Angle NormalY;
                public Angle NormalP;
                public uint Unknown5;
            }

            [TagStructure(Size = 0xA8)]
            public class Area
            {
                [TagField(Length = 32)]
                public string Name;
                public uint AreaFlags;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public int Unknown;
                public uint Unknown2;
                public short FiringPositionStartIndex;
                public short FiringPositionCount;
                public short Unknown3;
                public short Unknown4;
                public int Unknown5;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public short ManualReferenceFrame;
                public short Unknown12;
                public List<FlightHint> FlightHints;
                public List<UnknownBlock> Unknown13;
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

                [TagStructure(Size = 0x8)]
                public class FlightHint
                {
                    public short FlightHintIndex;
                    public short PoitIndex;
                    public uint Unknown;
                }

                [TagStructure(Size = 0x18)]
                public class UnknownBlock
                {
                    public float PositionX;
                    public float PositionY;
                    public float PositionZ;
                    public short Unknown;
                    public short Unknown2;
                    public Angle FacingY;
                    public Angle FacingP;
                }
            }
        }

        [TagStructure(Size = 0x2C)]
        public class UnknownBlock2
        {
            public StringId Unknown;
            public List<UnknownBlock> Unknown2;
            public List<UnknownBlock2_2> Unknown3;
            public List<UnknownBlock3> Unknown4;
            public uint Unknown5;

            [TagStructure(Size = 0x4)]
            public class UnknownBlock
            {
                public uint Unknown;
            }

            [TagStructure(Size = 0x14)]
            public class UnknownBlock2_2
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x10)]
            public class UnknownBlock3
            {
                public uint Unknown;
                public List<UnknownBlock> Unknown2;

                [TagStructure(Size = 0x14)]
                public class UnknownBlock
                {
                    public uint Unknown;
                    public uint Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public uint Unknown5;
                }
            }
        }

        [TagStructure(Size = 0x10)]
        public class CharacterPaletteBlock
        {
            public TagInstance Character;
        }

        [TagStructure(Size = 0x6C)]
        public class AiPathfindingDatum
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
            public List<UnknownBlock> Unknown22;
            public List<UnknownBlock2> Unknown23;

            [TagStructure(Size = 0x18)]
            public class UnknownBlock
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
                public uint Unknown6;
            }

            [TagStructure(Size = 0xC)]
            public class UnknownBlock2
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
            }
        }

        [TagStructure(Size = 0x34)]
        public class Script
        {
            [TagField(Length = 32)]
            public string ScriptName;
            public ScriptTypeValue ScriptType;
            public ReturnTypeValue ReturnType;
            public ushort RootExpressionSalt;
            public ushort RootExpressionIndex;
            public List<Parameter> Parameters;

            public enum ScriptTypeValue : short
            {
                Startup,
                Dormant,
                Continuous,
                Static,
                CommandScript,
                Stub,
            }

            public enum ReturnTypeValue : short
            {
                Unparsed,
                SpecialForm,
                FunctionName,
                Passthrough,
                Void,
                Boolean,
                Real,
                Short,
                Long,
                String,
                Script,
                StringId,
                UnitSeatMapping,
                TriggerVolume,
                CutsceneFlag,
                CutsceneCameraPoint,
                CutsceneTitle,
                CutsceneRecording,
                DeviceGroup,
                Ai,
                AiCommandList,
                AiCommandScript,
                AiBehavior,
                AiOrders,
                AiLine,
                StartingProfile,
                Conversation,
                ZoneSet,
                DesignerZone,
                PointReference,
                Style,
                ObjectList,
                Folder,
                Sound,
                Effect,
                Damage,
                LoopingSound,
                AnimationGraph,
                DamageEffect,
                ObjectDefinition,
                Bitmap,
                Shader,
                RenderModel,
                StructureDefinition,
                LightmapDefinition,
                CinematicDefinition,
                CinematicSceneDefinition,
                BinkDefinition,
                AnyTag,
                AnyTagNotResolving,
                GameDifficulty,
                Team,
                MpTeam,
                Controller,
                ButtonPreset,
                JoystickPreset,
                PlayerCharacterType,
                VoiceOutputSetting,
                VoiceMask,
                SubtitleSetting,
                ActorType,
                ModelState,
                Event,
                CharacterPhysics,
                PrimarySkull,
                SecondarySkull,
                Object,
                Unit,
                Vehicle,
                Weapon,
                Device,
                Scenery,
                EffectScenery,
                ObjectName,
                UnitName,
                VehicleName,
                WeaponName,
                DeviceName,
                SceneryName,
                EffectSceneryName,
                CinematicLightprobe,
                AnimationBudgetReference,
                LoopingSoundBudgetReference,
                SoundBudgetReference,
            }

            [TagStructure(Size = 0x24)]
            public class Parameter
            {
                [TagField(Length = 32)]
                public string Name;
                public TypeValue Type;
                public short Unknown;

                public enum TypeValue : short
                {
                    Unparsed,
                    SpecialForm,
                    FunctionName,
                    Passthrough,
                    Void,
                    Boolean,
                    Real,
                    Short,
                    Long,
                    String,
                    Script,
                    StringId,
                    UnitSeatMapping,
                    TriggerVolume,
                    CutsceneFlag,
                    CutsceneCameraPoint,
                    CutsceneTitle,
                    CutsceneRecording,
                    DeviceGroup,
                    Ai,
                    AiCommandList,
                    AiCommandScript,
                    AiBehavior,
                    AiOrders,
                    AiLine,
                    StartingProfile,
                    Conversation,
                    ZoneSet,
                    DesignerZone,
                    PointReference,
                    Style,
                    ObjectList,
                    Folder,
                    Sound,
                    Effect,
                    Damage,
                    LoopingSound,
                    AnimationGraph,
                    DamageEffect,
                    ObjectDefinition,
                    Bitmap,
                    Shader,
                    RenderModel,
                    StructureDefinition,
                    LightmapDefinition,
                    CinematicDefinition,
                    CinematicSceneDefinition,
                    BinkDefinition,
                    AnyTag,
                    AnyTagNotResolving,
                    GameDifficulty,
                    Team,
                    MpTeam,
                    Controller,
                    ButtonPreset,
                    JoystickPreset,
                    PlayerCharacterType,
                    VoiceOutputSetting,
                    VoiceMask,
                    SubtitleSetting,
                    ActorType,
                    ModelState,
                    Event,
                    CharacterPhysics,
                    PrimarySkull,
                    SecondarySkull,
                    Object,
                    Unit,
                    Vehicle,
                    Weapon,
                    Device,
                    Scenery,
                    EffectScenery,
                    ObjectName,
                    UnitName,
                    VehicleName,
                    WeaponName,
                    DeviceName,
                    SceneryName,
                    EffectSceneryName,
                    CinematicLightprobe,
                    AnimationBudgetReference,
                    LoopingSoundBudgetReference,
                    SoundBudgetReference,
                }
            }
        }

        [TagStructure(Size = 0x28)]
        public class Global
        {
            [TagField(Length = 32)]
            public string Name;
            public TypeValue Type;
            public short Unknown;
            public ushort InitializationExpressionSalt;
            public ushort InitializationExpressionIndex;

            public enum TypeValue : short
            {
                Unparsed,
                SpecialForm,
                FunctionName,
                Passthrough,
                Void,
                Boolean,
                Real,
                Short,
                Long,
                String,
                Script,
                StringId,
                UnitSeatMapping,
                TriggerVolume,
                CutsceneFlag,
                CutsceneCameraPoint,
                CutsceneTitle,
                CutsceneRecording,
                DeviceGroup,
                Ai,
                AiCommandList,
                AiCommandScript,
                AiBehavior,
                AiOrders,
                AiLine,
                StartingProfile,
                Conversation,
                ZoneSet,
                DesignerZone,
                PointReference,
                Style,
                ObjectList,
                Folder,
                Sound,
                Effect,
                Damage,
                LoopingSound,
                AnimationGraph,
                DamageEffect,
                ObjectDefinition,
                Bitmap,
                Shader,
                RenderModel,
                StructureDefinition,
                LightmapDefinition,
                CinematicDefinition,
                CinematicSceneDefinition,
                BinkDefinition,
                AnyTag,
                AnyTagNotResolving,
                GameDifficulty,
                Team,
                MpTeam,
                Controller,
                ButtonPreset,
                JoystickPreset,
                PlayerCharacterType,
                VoiceOutputSetting,
                VoiceMask,
                SubtitleSetting,
                ActorType,
                ModelState,
                Event,
                CharacterPhysics,
                PrimarySkull,
                SecondarySkull,
                Object,
                Unit,
                Vehicle,
                Weapon,
                Device,
                Scenery,
                EffectScenery,
                ObjectName,
                UnitName,
                VehicleName,
                WeaponName,
                DeviceName,
                SceneryName,
                EffectSceneryName,
                CinematicLightprobe,
                AnimationBudgetReference,
                LoopingSoundBudgetReference,
                SoundBudgetReference,
            }
        }

        [TagStructure(Size = 0x10)]
        public class ScriptReference
        {
            public TagInstance Reference;
        }

        [TagStructure(Size = 0x84)]
        public class ScriptingDatum
        {
            public List<PointSet> PointSets;
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

            [TagStructure(Size = 0x38)]
            public class PointSet
            {
                [TagField(Length = 32)]
                public string Name;
                public List<Point> Points;
                public short BspIndex;
                public short ManualReferenceFrame;
                public uint Flags;
                public short EditorFolderIndex;
                public short Unknown;

                [TagStructure(Size = 0x3C)]
                public class Point
                {
                    [TagField(Length = 32)]
                    public string Name;
                    public float PositionX;
                    public float PositionY;
                    public float PositionZ;
                    public short ReferenceFrame;
                    public short Unknown;
                    public int SurfaceIndex;
                    public Angle FacingDirectionY;
                    public Angle FacingDirectionP;
                }
            }
        }

        [TagStructure(Size = 0x20)]
        public class CutsceneFlag
        {
            public uint Unknown;
            public StringId Name;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle FacingY;
            public Angle FacingP;
            public short EditorFolderIndex;
            public short Unknown2;
        }

        [TagStructure(Size = 0x40)]
        public class CutsceneCameraPoint
        {
            public ushort Flags;
            public TypeValue Type;
            [TagField(Length = 32)]
            public string Name;
            public int Unknown;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle OrientationY;
            public Angle OrientationP;
            public Angle OrientationR;

            public enum TypeValue : short
            {
                Normal,
                IgnoreTargetOrientation,
                Dolly,
                IgnoreTargetUpdates,
            }
        }

        [TagStructure(Size = 0x28)]
        public class CutsceneTitle
        {
            public StringId Name;
            public short TextBoundsTop;
            public short TextBoundsLeft;
            public short TextBoundsBottom;
            public short TextBoundsRight;
            public HorizontalJustificationValue HorizontalJustification;
            public VerticalJustificationValue VerticalJustification;
            public short Font;
            public short Unknown;
            public byte TextColorA;
            public byte TextColorR;
            public byte TextColorG;
            public byte TextColorB;
            public byte ShadowColorA;
            public byte ShadowColorR;
            public byte ShadowColorG;
            public byte ShadowColorB;
            public float FadeInTime;
            public float Uptime;
            public float FadeOutTime;

            public enum HorizontalJustificationValue : short
            {
                Left,
                Right,
                Center,
            }

            public enum VerticalJustificationValue : short
            {
                Bottom,
                Top,
                Middle,
                Bottom2,
                Top2,
            }
        }

        [TagStructure(Size = 0x28)]
        public class ScenarioResource
        {
            public int Unknown;
            public List<ScriptSourceBlock> ScriptSource;
            public List<AiResource> AiResources;
            public List<Reference> References;

            [TagStructure(Size = 0x10)]
            public class ScriptSourceBlock
            {
                public TagInstance HsSourceFile;
            }

            [TagStructure(Size = 0x10)]
            public class AiResource
            {
                public TagInstance AiResource2;
            }

            [TagStructure(Size = 0x16C)]
            public class Reference
            {
                public TagInstance SceneryResource;
                public List<OtherSceneryBlock> OtherScenery;
                public TagInstance BipedsResource;
                public List<OtherBiped> OtherBipeds;
                public TagInstance VehiclesResource;
                public TagInstance EquipmentResource;
                public TagInstance WeaponsResource;
                public TagInstance SoundSceneryResource;
                public TagInstance LightsResource;
                public TagInstance DevicesResource;
                public List<OtherDevice> OtherDevices;
                public TagInstance EffectSceneryResource;
                public TagInstance DecalsResource;
                public List<OtherDecal> OtherDecals;
                public TagInstance CinematicsResource;
                public TagInstance TriggerVolumesResource;
                public TagInstance ClusterDataResource;
                public TagInstance CommentsResource;
                public TagInstance CreatureResource;
                public TagInstance StructureLightingResource;
                public TagInstance DecoratorsResource;
                public List<OtherDecorator> OtherDecorators;
                public TagInstance SkyReferencesResource;
                public TagInstance CubemapResource;

                [TagStructure(Size = 0x10)]
                public class OtherSceneryBlock
                {
                    public TagInstance SceneryResource;
                }

                [TagStructure(Size = 0x10)]
                public class OtherBiped
                {
                    public TagInstance BipedsResource;
                }

                [TagStructure(Size = 0x10)]
                public class OtherDevice
                {
                    public TagInstance DevicesResource;
                }

                [TagStructure(Size = 0x10)]
                public class OtherDecal
                {
                    public TagInstance DecalsResource;
                }

                [TagStructure(Size = 0x10)]
                public class OtherDecorator
                {
                    public TagInstance DecoratorsResource;
                }
            }
        }

        [TagStructure(Size = 0xC)]
        public class UnitSeatsMappingBlock
        {
            [TagField(Flags = TagFieldFlags.Short)]
            public TagInstance Unit;
            public uint Seats;
            public uint Seats2;
        }

        [TagStructure(Size = 0x2)]
        public class ScenarioKillTrigger
        {
            public short TriggerVolume;
        }

        [TagStructure(Size = 0x2)]
        public class ScenarioSafeTrigger
        {
            public short TriggerVolume;
        }

        [TagStructure(Size = 0x18)]
        public class ScriptExpression
        {
            public ushort Salt;
            public ushort Opcode;
            public ValueTypeValue ValueType;
            public short ExpressionType;
            public ushort NextExpressionSalt;
            public ushort NextExpressionIndex;
            public uint StringAddress;
            public sbyte Value03Msb;
            public sbyte Value02Byte;
            public sbyte Value01Byte;
            public sbyte Value00Lsb;
            public short LineNumber;
            public short Unknown;

            public enum ValueTypeValue : ushort
            {
                Invalid = 47802,
                Unparsed = 0,
                SpecialForm,
                FunctionName,
                Passthrough,
                Void,
                Boolean,
                Real,
                Short,
                Long,
                String,
                Script,
                StringId,
                UnitSeatMapping,
                TriggerVolume,
                CutsceneFlag,
                CutsceneCameraPoint,
                CutsceneTitle,
                CutsceneRecording,
                DeviceGroup,
                Ai,
                AiCommandList,
                AiCommandScript,
                AiBehavior,
                AiOrders,
                AiLine,
                StartingProfile,
                Conversation,
                ZoneSet,
                DesignerZone,
                PointReference,
                Style,
                ObjectList,
                Folder,
                Sound,
                Effect,
                Damage,
                LoopingSound,
                AnimationGraph,
                DamageEffect,
                ObjectDefinition,
                Bitmap,
                Shader,
                RenderModel,
                StructureDefinition,
                LightmapDefinition,
                CinematicDefinition,
                CinematicSceneDefinition,
                BinkDefinition,
                AnyTag,
                AnyTagNotResolving,
                GameDifficulty,
                Team,
                MpTeam,
                Controller,
                ButtonPreset,
                JoystickPreset,
                PlayerCharacterType,
                VoiceOutputSetting,
                VoiceMask,
                SubtitleSetting,
                ActorType,
                ModelState,
                Event,
                CharacterPhysics,
                PrimarySkull,
                SecondarySkull,
                Object,
                Unit,
                Vehicle,
                Weapon,
                Device,
                Scenery,
                EffectScenery,
                ObjectName,
                UnitName,
                VehicleName,
                WeaponName,
                DeviceName,
                SceneryName,
                EffectSceneryName,
                CinematicLightprobe,
                AnimationBudgetReference,
                LoopingSoundBudgetReference,
                SoundBudgetReference,
            }
        }

        [TagStructure(Size = 0x58)]
        public class BackgroundSoundEnvironmentPaletteBlock
        {
            public StringId Name;
            public TagInstance SoundEnvironment;
            public int Unknown;
            public float CutoffDistance;
            public float InterpolationSpeed;
            public TagInstance BackgroundSound;
            public TagInstance InsideClusterSound;
            public float CutoffDistance2;
            public uint ScaleFlags;
            public float InteriorScale;
            public float PortalScale;
            public float ExteriorScale;
            public float InterpolationSpeed2;
        }

        [TagStructure(Size = 0x78)]
        public class UnknownBlock3
        {
            [TagField(Length = 32)]
            public string Name;
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
        }

        [TagStructure(Size = 0x8)]
        public class FogBlock
        {
            public StringId Name;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x30)]
        public class CameraFxBlock
        {
            public StringId Name;
            public TagInstance CameraFx;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
        }

        [TagStructure(Size = 0x68, MaxVersion = EngineVersion.V10_1_449175_Live)]
        [TagStructure(Size = 0x74, MinVersion = EngineVersion.V11_1_498295_Live)]
        public class ScenarioClusterDatum
        {
            public TagInstance Bsp;
            public List<BackgroundSoundEnvironment> BackgroundSoundEnvironments;
            public List<UnknownBlock> Unknown;
            public List<UnknownBlock2> Unknown2;
            public int BspChecksum;
            public List<ClusterCentroid> ClusterCentroids;
            public List<UnknownBlock3> Unknown3;
            public List<FogBlock> Fog;
            public List<CameraEffect> CameraEffects;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public List<UnknownBlock4> Unknown4;

            [TagStructure(Size = 0x4)]
            public class BackgroundSoundEnvironment
            {
                public short BackgroundSoundEnvironmentIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock2
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0xC)]
            public class ClusterCentroid
            {
                public float CentroidX;
                public float CentroidY;
                public float CentroidZ;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock3
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x4)]
            public class FogBlock
            {
                public short FogIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class CameraEffect
            {
                public short CameraEffectIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock4
            {
                public short Unknown;
                public short Unknown2;
            }
        }

        [TagStructure(Size = 0x6C)]
        public class SpawnDatum
        {
            public float DynamicSpawnLowerHeight;
            public float DynamicSpawnUpperHeight;
            public float GameObjectResetHeight;
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
            public List<DynamicSpawnOverload> DynamicSpawnOverloads;
            public List<StaticRespawnZone> StaticRespawnZones;
            public List<StaticInitialSpawnZone> StaticInitialSpawnZones;

            [TagStructure(Size = 0x10)]
            public class DynamicSpawnOverload
            {
                public short OverloadType;
                public short Unknown;
                public float InnerRadius;
                public float OuterRadius;
                public float Weight;
            }

            [TagStructure(Size = 0x30)]
            public class StaticRespawnZone
            {
                public StringId Name;
                public uint RelevantTeams;
                public uint RelevantGames;
                public uint Flags;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public float LowerHeight;
                public float UpperHeight;
                public float InnerRadius;
                public float OuterRadius;
                public float Weight;
            }

            [TagStructure(Size = 0x30)]
            public class StaticInitialSpawnZone
            {
                public StringId Name;
                public uint RelevantTeams;
                public uint RelevantGames;
                public uint Flags;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public float LowerHeight;
                public float UpperHeight;
                public float InnerRadius;
                public float OuterRadius;
                public float Weight;
            }
        }

        [TagStructure(Size = 0xB4)]
        public class Crate
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(EngineVersion.V10_1_449175_Live)]
            public ObjectTypeValueOld ObjectTypeOld;
            [MinVersion(EngineVersion.V11_1_498295_Live)]
            public ObjectTypeValueNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public uint Unknown11;
            public List<UnknownBlock2> Unknown12;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown13;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown14;
            public short Unknown15;
            public short AttachedNameIndex;
            public uint Unknown16;
            public uint Unknown17;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown18;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock2
            {
                public uint Unknown;
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class CratePaletteBlock
        {
            public TagInstance Crate;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x10)]
        public class FlockPaletteBlock
        {
            public TagInstance Flock;
        }

        [TagStructure(Size = 0x48)]
        public class Flock
        {
            public StringId Name;
            public short FlockPaletteIndex;
            public short BspIndex;
            public short BoundingTriggerVolume;
            public ushort Flags;
            public float EcologyMargin;
            public List<Source> Sources;
            public List<Sink> Sinks;
            public float ProductionFrequencyMin;
            public float ProductionFrequencyMax;
            public float ScaleMin;
            public float ScaleMax;
            public uint Unknown;
            public uint Unknown2;
            public short CreaturePaletteIndex;
            public short BoidCountMin;
            public short BoidCountMax;
            public short Unknown3;

            [TagStructure(Size = 0x24)]
            public class Source
            {
                public int Unknown;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public Angle StartingY;
                public Angle StartingP;
                public float Radius;
                public float Weight;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public sbyte Unknown4;
                public sbyte Unknown5;
            }

            [TagStructure(Size = 0x10)]
            public class Sink
            {
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public float Radius;
            }
        }

        [TagStructure(Size = 0x30)]
        public class CreaturePaletteBlock
        {
            public TagInstance Creature;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x104)]
        public class EditorFolder
        {
            public int ParentFolder;
            [TagField(Length = 256)]
            public string Name;
        }

        [TagStructure(Size = 0x10)]
        public class MissionDialogueBlock
        {
            public TagInstance MissionDialogue;
        }

        [TagStructure(Size = 0x24)]
        public class Interpolator
        {
            public StringId Name;
            public StringId AcceleratorName;
            public StringId MultiplierName;
            public byte[] Function;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x4)]
        public class SimulationDefinitionTableBlock
        {
            [TagField(Flags = TagFieldFlags.Short)]
            public TagInstance Tag;
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock4
        {
            public short Unknown;
            public short Unknown2;
            public short Unknown3;
            public short Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            public short Unknown8;
        }

        [TagStructure(Size = 0x14)]
        public class AiObjective
        {
            public StringId Name;
            public short Zone;
            public short Unknown;
            public List<Role> Roles;

            [TagStructure(Size = 0xCC)]
            public class Role
            {
                public short Unknown;
                public short Unknown2;
                public short Unknown3;
                public short Unknown4;
                public short Unknown5;
                public short Unknown6;
                public uint Unknown7;
                [TagField(Length = 32)]
                public string CommandScriptName1;
                [TagField(Length = 32)]
                public string CommandScriptName2;
                [TagField(Length = 32)]
                public string CommandScriptName3;
                public short CommandScriptIndex1;
                public short CommandScriptIndex2;
                public short CommandScriptIndex3;
                public short Unknown8;
                public short Unknown9;
                public short Unknown10;
                public List<Unknown84Block> Unknown84;
                public StringId Task;
                public short HierarchyLevelFrom100;
                public short PreviousRole;
                public short NextRole;
                public short ParentRole;
                public List<Condition> Conditions;
                public short ScriptIndex;
                public short Unknown11;
                public short Unknown12;
                public FilterValue Filter;
                public short Min;
                public short Max;
                public short Bodies;
                public short Unknown13;
                public uint Unknown14;
                public List<UnknownBlock> Unknown15;
                public List<PointGeometryBlock> PointGeometry;

                [TagStructure(Size = 0x8)]
                public class Unknown84Block
                {
                    public uint Unknown;
                    public uint Unknown2;
                }

                [TagStructure(Size = 0x124)]
                public class Condition
                {
                    [TagField(Length = 32)]
                    public string Name;
                    [TagField(Length = 256)]
                    public string Condition2;
                    public short Unknown;
                    public short Unknown2;
                }

                public enum FilterValue : short
                {
                    None,
                    Leader,
                    Arbiter = 3,
                    Player,
                    Infantry = 7,
                    Flood = 16,
                    Sentinel,
                    Jackal = 21,
                    Grunt,
                    Marine = 24,
                    FloodCombat,
                    FloodCarrier,
                    Brute = 28,
                    Drone = 30,
                    FloodPureform,
                    Warthog = 34,
                    Wraith = 39,
                    Phantom,
                    BruteChopper = 44,
                }

                [TagStructure(Size = 0xA)]
                public class UnknownBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public short Unknown3;
                    public short Unknown4;
                    public short Unknown5;
                }

                [TagStructure(Size = 0x20)]
                public class PointGeometryBlock
                {
                    public float Point0X;
                    public float Point0Y;
                    public float Point0Z;
                    public short ReferenceFrame;
                    public short Unknown;
                    public float Point1X;
                    public float Point1Y;
                    public float Point1Z;
                    public short ReferenceFrame2;
                    public short Unknown2;
                }
            }
        }

        [TagStructure(Size = 0xBC)]
        public class DesignerZoneset
        {
            public StringId Name;
            public uint Unknown;
            public List<Biped> Bipeds;
            public List<Vehicle> Vehicles;
            public List<Weapon> Weapons;
            public List<EquipmentBlock> Equipment;
            public List<SceneryBlock> Scenery;
            public List<Machine> Machines;
            public List<Terminal> Terminals;
            public List<Control> Controls;
            public List<UnknownBlock> Unknown2;
            public List<Crate> Crates;
            public List<Creature> Creatures;
            public List<Giant> Giants;
            public List<UnknownBlock2> Unknown3;
            public List<Character> Characters;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;

            [TagStructure(Size = 0x2)]
            public class Biped
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Vehicle
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Weapon
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class EquipmentBlock
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class SceneryBlock
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Machine
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Terminal
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Control
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class UnknownBlock
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Crate
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Creature
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Giant
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class UnknownBlock2
            {
                public short PaletteIndex;
            }

            [TagStructure(Size = 0x2)]
            public class Character
            {
                public short PaletteIndex;
            }
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock5
        {
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x10)]
        public class Cinematic
        {
            public TagInstance Cinematic2;
        }

        [TagStructure(Size = 0x14)]
        public class CinematicLightingBlock
        {
            public StringId Name;
            public TagInstance CinematicLight;
        }

        [TagStructure(Size = 0x1C)]
        public class ScenarioMetagameBlock
        {
            public List<TimeMultiplier> TimeMultipliers;
            public float ParScore;
            public List<SurvivalBlock> Survival;

            [TagStructure(Size = 0x8)]
            public class TimeMultiplier
            {
                public float Time;
                public float Multiplier;
            }

            [TagStructure(Size = 0x8)]
            public class SurvivalBlock
            {
                public short InsertionIndex;
                public short Unknown;
                public float ParScore;
            }
        }

        [TagStructure(Size = 0x18)]
        public class UnknownBlock6
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock7
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public short Unknown4;
            public short Unknown5;
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock8
        {
            public TagInstance Unknown;
        }
    }
}
