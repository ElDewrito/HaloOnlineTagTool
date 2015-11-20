using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "sbsp", Size = 0x3AC, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "sbsp", Size = 0x3B8, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class ScenarioStructureBsp
	{
		public int BspChecksum;
		public int Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public List<CollisionMaterial> CollisionMaterials;
		public List<UnknownRaw3rdBlock> UnknownRaw3rd;
		public float WorldBoundsXMin;
		public float WorldBoundsXMax;
		public float WorldBoundsYMin;
		public float WorldBoundsYMax;
		public float WorldBoundsZMin;
		public float WorldBoundsZMax;
		public uint Unknown10;
		public uint Unknown11;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public uint Unknown16;
		public uint Unknown17;
		public uint Unknown18;
		public List<ClusterPortal> ClusterPortals;
		public List<UnknownBlock> Unknown19;
		public List<FogBlock> Fog;
		public List<CameraEffect> CameraEffects;
		public uint Unknown20;
		public uint Unknown21;
		public uint Unknown22;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown92;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown93;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public uint Unknown94;
		public List<DetailObject> DetailObjects;
		public List<Cluster> Clusters;
		public List<Material> Materials;
		public List<SkyOwnerClusterBlock> SkyOwnerCluster;
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
		public List<BackgroundSoundEnvironmentPaletteBlock> BackgroundSoundEnvironmentPalette;
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
		public uint Unknown45;
		public List<Marker> Markers;
		public List<Light> Lights;
		public List<UnknownBlock2> Unknown46;
		public List<RuntimeDecal> RuntimeDecals;
		public List<EnvironmentObjectPaletteBlock> EnvironmentObjectPalette;
		public List<EnvironmentObject> EnvironmentObjects;
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
		public List<InstancedGeometryInstance> InstancedGeometryInstances;
		public List<Decorator> Decorators;
		public GeometryReference Geometry;
		public List<UnknownSoundClustersABlock> UnknownSoundClustersA;
		public List<UnknownSoundClustersBBlock> UnknownSoundClustersB;
		public List<UnknownSoundClustersCBlock> UnknownSoundClustersC;
		public List<TransparentPlane> TransparentPlanes;
		public uint Unknown66;
		public uint Unknown67;
		public uint Unknown68;
		public List<CollisionMoppCode> CollisionMoppCodes;
		public uint Unknown69;
		public float CollisionWorldBoundsXMin;
		public float CollisionWorldBoundsYMin;
		public float CollisionWorldBoundsZMin;
		public float CollisionWorldBoundsXMax;
		public float CollisionWorldBoundsYMax;
		public float CollisionWorldBoundsZMax;
		public List<BreakableSurfaceMoppCode> BreakableSurfaceMoppCodes;
		public List<BreakableSurfaceKeyTableBlock> BreakableSurfaceKeyTable;
		public uint Unknown70;
		public uint Unknown71;
		public uint Unknown72;
		public uint Unknown73;
		public uint Unknown74;
		public uint Unknown75;
		public GeometryReference Geometry2;
		public uint Unknown85;
		public uint Unknown86;
		public List<LeafSystem> LeafSystems;
		public uint Unknown87;
		public ResourceReference Resource3;
		public int UselessPading;
		public ResourceReference Resource4;
		public int UselessPadding3;
		public int Unknown88;
		public uint Unknown89;
		public uint Unknown90;
		public uint Unknown91;

		[TagStructure(Size = 0x18)]
		public class CollisionMaterial
		{
			public HaloTag Shader;
			public short GlobalMaterialIndex;
			public short ConveyorSurfaceIndex;
			public short SeamIndex;
			public short Unknown;
		}

		[TagStructure(Size = 0x1)]
		public class UnknownRaw3rdBlock
		{
			public sbyte Unknown;
		}

		[TagStructure(Size = 0x28)]
		public class ClusterPortal
		{
			public short BackCluster;
			public short FrontCluster;
			public int PlaneIndex;
			public float CentroidX;
			public float CentroidY;
			public float CentroidZ;
			public float BoundingRadius;
			public uint Flags;
			public List<Vertex> Vertices;

			[TagStructure(Size = 0xC)]
			public class Vertex
			{
				public float X;
				public float Y;
				public float Z;
			}
		}

		[TagStructure(Size = 0x78)]
		public class UnknownBlock
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
		}

		[TagStructure(Size = 0x8)]
		public class FogBlock
		{
			public StringId Name;
			public short Unknown;
			public short Unknown2;
		}

		[TagStructure(Size = 0x30)]
		public class CameraEffect
		{
			public StringId Name;
			public HaloTag Effect;
			public sbyte Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
		}

		[TagStructure(Size = 0x34)]
		public class DetailObject
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public List<UnknownBlock> Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;

			[TagStructure(Size = 0x20)]
			public class UnknownBlock
			{
				public List<UnknownBlock2> Unknown;
				public byte[] Unknown2;

				[TagStructure(Size = 0x10)]
				public class UnknownBlock2
				{
					public uint Unknown;
					public uint Unknown2;
					public uint Unknown3;
					public uint Unknown4;
				}
			}
		}

		[TagStructure(Size = 0xDC, MaxVersion = EngineVersion.V10_1_449175_Live)]
		[TagStructure(Size = 0xE0, MinVersion = EngineVersion.V11_1_498295_Live)]
		public class Cluster
		{
			public float BoundsXMin;
			public float BoundsXMax;
			public float BoundsYMin;
			public float BoundsYMax;
			public float BoundsZMin;
			public float BoundsZMax;
			public sbyte Unknown;
			public sbyte ScenarioSkyIndex;
			public sbyte CameraEffectIndex;
			public sbyte Unknown2;
			public short BackgroundSoundEnvironmentIndex;
			public short SoundClustersAIndex;
			public short Unknown3;
			public short Unknown4;
			public short Unknown5;
			public short Unknown6;
			public short Unknown7;
			public short RuntimeDecalStartIndex;
			public short RuntimeDecalEntryCount;
			[MinVersion(EngineVersion.V11_1_498295_Live)] public short Unknown26;
			[MinVersion(EngineVersion.V11_1_498295_Live)] public short Unknown27;
			public short Flags;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public List<Portal> Portals;
			public int Unknown11;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public HaloTag Bsp;
			public int ClusterIndex;
			public int Unknown15;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown16;
			public uint Unknown17;
			public uint Unknown18;
			public uint Unknown19;
			public List<CollisionMoppCode> CollisionMoppCodes;
			public short MeshIndex;
			public short Unknown20;
			public List<Seam> Seams;
			public List<DecoratorGrid> DecoratorGrids;
			public uint Unknown21;
			public uint Unknown22;
			public uint Unknown23;
			public List<UnknownBlock> Unknown24;
			public List<UnknownBlock2> Unknown25;

			[TagStructure(Size = 0x2)]
			public class Portal
			{
				public short PortalIndex;
			}

			[TagStructure(Size = 0x40)]
			public class CollisionMoppCode
			{
				public int Unknown;
				public short Size;
				public short Count;
				public int Offset;
				public uint Unknown2;
				public float OffsetX;
				public float OffsetY;
				public float OffsetZ;
				public float OffsetScale;
				public uint Unknown3;
				public int DataSize;
				public uint DataCapacity;
				public sbyte Unknown4;
				public sbyte Unknown5;
				public sbyte Unknown6;
				public sbyte Unknown7;
				public List<Datum> Data;
				public uint Unknown8;

				[TagStructure(Size = 0x1)]
				public class Datum
				{
					public byte DataByte;
				}
			}

			[TagStructure(Size = 0x1)]
			public class Seam
			{
				public sbyte SeamIndex;
			}

			[TagStructure(Size = 0x30)]
			public class DecoratorGrid
			{
				public short Amount;
				public sbyte DecoratorIndex;
				public sbyte DecoratorIndexScattering;
				public int Unknown;
				public float PositionX;
				public float PositionY;
				public float PositionZ;
				public float Radius;
				public float GridSizeX;
				public float GridSizeY;
				public float GridSizeZ;
				public float BoundingSphereX;
				public float BoundingSphereY;
				public float BoundingSphereZ;
			}

			[TagStructure(Size = 0x4)]
			public class UnknownBlock
			{
				public short Unknown;
				public short Unknown2;
			}

			[TagStructure(Size = 0x10)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public short Unknown4;
				public short Unknown5;
			}
		}

		[TagStructure(Size = 0x24)]
		public class Material
		{
			public HaloTag Shader;
			public List<Property> Properties;
			public int Unknown;
			public sbyte BreakableSurfaceIndex;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;

			[TagStructure(Size = 0xC)]
			public class Property
			{
				public int Type;
				public int IntValue;
				public float RealValue;
			}
		}

		[TagStructure(Size = 0x2)]
		public class SkyOwnerClusterBlock
		{
			public short ClusterOwner;
		}

		[TagStructure(Size = 0x58)]
		public class BackgroundSoundEnvironmentPaletteBlock
		{
			public StringId Name;
			public HaloTag SoundEnvironment;
			public uint Unknown;
			public float CutoffDistance;
			public float InterpolationSpeed;
			public HaloTag BackgroundSound;
			public HaloTag InsideClusterSound;
			public float CutoffDistance2;
			public uint ScaleFlags;
			public float InteriorScale;
			public float PortalScale;
			public float ExteriorScale;
			public float InterpolationSpeed2;
		}

		[TagStructure(Size = 0x3C)]
		public class Marker
		{
			[TagField(Length = 32)] public string Name;
			public float RotationI;
			public float RotationJ;
			public float RotationK;
			public float RotationW;
			public float PositionX;
			public float PositionY;
			public float PositionZ;
		}

		[TagStructure(Size = 0x10)]
		public class Light
		{
			public HaloTag Light2;
		}

		[TagStructure(Size = 0x2)]
		public class UnknownBlock2
		{
			public short Unknown;
		}

		[TagStructure(Size = 0x24)]
		public class RuntimeDecal
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

		[TagStructure(Size = 0x24)]
		public class EnvironmentObjectPaletteBlock
		{
			public HaloTag Definition;
			public HaloTag Model;
			public uint ObjectType;
		}

		[TagStructure(Size = 0x6C)]
		public class EnvironmentObject
		{
			[TagField(Length = 32)] public string Name;
			public float RotationI;
			public float RotationJ;
			public float RotationK;
			public float RotationW;
			public float PositionX;
			public float PositionY;
			public float PositionZ;
			public float Scale;
			public short PaletteIndex;
			public short Unknown;
			public int UniqueId;
			[TagField(Length = 32)] public string ScenarioObjectName;
			public uint Unknown2;
		}

		[TagStructure(Size = 0x74)]
		public class InstancedGeometryInstance
		{
			public float Scale;
			public float ForwardI;
			public float ForwardJ;
			public float ForwardK;
			public float LeftI;
			public float LeftJ;
			public float LeftK;
			public float UpI;
			public float UpJ;
			public float UpK;
			public float PositionX;
			public float PositionY;
			public float PositionZ;
			public short MeshIndex;
			public ushort Flags;
			public short UnknownYoIndex;
			public short Unknown;
			public uint Unknown2;
			public float BoundingSphereX;
			public float BoundingSphereY;
			public float BoundingSphereZ;
			public float BoundingSphereRadius1;
			public float BoundingSphereRadius2;
			public StringId Name;
			public short PathfindingPolicy;
			public short LightmappingPolicy;
			public uint Unknown3;
			public List<CollisionDefinition> CollisionDefinitions;
			public short Unknown4;
			public short Unknown5;
			public short Unknown6;
			public short Unknown7;

			[TagStructure(Size = 0x80)]
			public class CollisionDefinition
			{
				public int Unknown;
				public short Size;
				public short Count;
				public int Offset;
				public int Unknown2;
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
				public int Unknown15;
				public uint Unknown16;
				public uint UnknownPossiblyNewValue;
				public sbyte BspIndex;
				public sbyte Unknown17;
				public short InstancedGeometryIndex;
				public uint Unknown18;
				public uint Unknown19;
				public uint Unknown20;
				public uint Unknown21;
				public uint Unknown22;
				public short Size2;
				public short Count2;
				public int Offset2;
				public int Unknown23;
				public uint Unknown24;
				public uint Unknown25;
				public uint Unknown26;
				public uint Unknown27;
			}
		}

		[TagStructure(Size = 0x10)]
		public class Decorator
		{
			public HaloTag Decorator2;
		}

		[TagStructure(Size = 0x1C)]
		public class UnknownSoundClustersABlock
		{
			public short BackgroundSoundEnvironmentIndex;
			public short Unknown;
			public List<PortalDesignator> PortalDesignators;
			public List<InteriorClusterIndex> InteriorClusterIndices;

			[TagStructure(Size = 0x2)]
			public class PortalDesignator
			{
				public short PortalDesignator2;
			}

			[TagStructure(Size = 0x2)]
			public class InteriorClusterIndex
			{
				public short InteriorClusterIndex2;
			}
		}

		[TagStructure(Size = 0x1C)]
		public class UnknownSoundClustersBBlock
		{
			public short BackgroundSoundEnvironmentIndex;
			public short Unknown;
			public List<PortalDesignator> PortalDesignators;
			public List<InteriorClusterIndex> InteriorClusterIndices;

			[TagStructure(Size = 0x2)]
			public class PortalDesignator
			{
				public short PortalDesignator2;
			}

			[TagStructure(Size = 0x2)]
			public class InteriorClusterIndex
			{
				public short InteriorClusterIndex2;
			}
		}

		[TagStructure(Size = 0x1C)]
		public class UnknownSoundClustersCBlock
		{
			public short BackgroundSoundEnvironmentIndex;
			public short Unknown;
			public List<PortalDesignator> PortalDesignators;
			public List<InteriorClusterIndex> InteriorClusterIndices;

			[TagStructure(Size = 0x2)]
			public class PortalDesignator
			{
				public short PortalDesignator2;
			}

			[TagStructure(Size = 0x2)]
			public class InteriorClusterIndex
			{
				public short InteriorClusterIndex2;
			}
		}

		[TagStructure(Size = 0x14)]
		public class TransparentPlane
		{
			public short MeshIndex;
			public short PartIndex;
			public float PlaneI;
			public float PlaneJ;
			public float PlaneK;
			public float PlaneD;
		}

		[TagStructure(Size = 0x40)]
		public class CollisionMoppCode
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public uint Unknown2;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float OffsetScale;
			public uint Unknown3;
			public int DataSize;
			public uint DataCapacity;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public sbyte Unknown7;
			public List<Datum> Data;
			public uint Unknown8;

			[TagStructure(Size = 0x1)]
			public class Datum
			{
				public byte DataByte;
			}
		}

		[TagStructure(Size = 0x40)]
		public class BreakableSurfaceMoppCode
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public uint Unknown2;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float OffsetScale;
			public uint Unknown3;
			public int DataSize;
			public uint DataCapacity;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public sbyte Unknown7;
			public List<Datum> Data;
			public uint Unknown8;

			[TagStructure(Size = 0x1)]
			public class Datum
			{
				public byte DataByte;
			}
		}

		[TagStructure(Size = 0x20)]
		public class BreakableSurfaceKeyTableBlock
		{
			public short InstancedGeometryIndex;
			public sbyte BreakableSurfaceIndex;
			public byte BreakableSurfaceSubIndex;
			public int SeedSurfaceIndex;
			public float X0;
			public float X1;
			public float Y0;
			public float Y1;
			public float Z0;
			public float Z1;
		}

		[TagStructure(Size = 0x14)]
		public class LeafSystem
		{
			public short Unknown;
			public short Unknown2;
			public HaloTag LeafSystem2;
		}
	}
}
