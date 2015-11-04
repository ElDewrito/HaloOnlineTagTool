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
	[TagStructure(Class = "sbsp", Size = 0x3AC)]
	public class ScenarioStructureBsp
	{
		public int BspChecksum;
		public int Unknown;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public List<CollisionMaterial> CollisionMaterials;
		public List<UnknownRaw3rdBlock> UnknownRaw3rd;
		public float WorldBoundsXMin;
		public float WorldBoundsXMax;
		public float WorldBoundsYMin;
		public float WorldBoundsYMax;
		public float WorldBoundsZMin;
		public float WorldBoundsZMax;
		public float Unknown10;
		public float Unknown11;
		public float Unknown12;
		public float Unknown13;
		public float Unknown14;
		public float Unknown15;
		public float Unknown16;
		public float Unknown17;
		public float Unknown18;
		public List<ClusterPortal> ClusterPortals;
		public List<UnknownBlock> Unknown19;
		public List<FogBlock> Fog;
		public List<CameraEffect> CameraEffects;
		public float Unknown20;
		public float Unknown21;
		public float Unknown22;
		public List<DetailObject> DetailObjects;
		public List<Cluster> Clusters;
		public List<Material> Materials;
		public List<SkyOwnerClusterBlock> SkyOwnerCluster;
		public float Unknown23;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;
		public float Unknown27;
		public float Unknown28;
		public float Unknown29;
		public float Unknown30;
		public float Unknown31;
		public float Unknown32;
		public float Unknown33;
		public float Unknown34;
		public List<BackgroundSoundEnvironmentPaletteBlock> BackgroundSoundEnvironmentPalette;
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
		public List<Marker> Markers;
		public List<Light> Lights;
		public List<UnknownBlock2> Unknown46;
		public List<RuntimeDecal> RuntimeDecals;
		public List<EnvironmentObjectPaletteBlock> EnvironmentObjectPalette;
		public List<EnvironmentObject> EnvironmentObjects;
		public float Unknown47;
		public float Unknown48;
		public float Unknown49;
		public float Unknown50;
		public float Unknown51;
		public float Unknown52;
		public float Unknown53;
		public float Unknown54;
		public float Unknown55;
		public float Unknown56;
		public List<InstancedGeometryInstance> InstancedGeometryInstances;
		public List<Decorator> Decorators;
		public int Unknown57;
		public List<CompressionInfoBlock> CompressionInfo;
		public List<UnknownNodeyBlock> UnknownNodey;
		public List<UnknownNodeyBlock2> UnknownNodey2;
		public List<UnknownBlock3> Unknown58;
		public float Unknown59;
		public float Unknown60;
		public float Unknown61;
		public List<UnknownSection> UnknownSections;
		public List<NodeMap> NodeMaps;
		public List<UnknownBlock4> Unknown62;
		public float Unknown63;
		public float Unknown64;
		public float Unknown65;
		public List<UnknownYoBlock> UnknownYo;
		public ResourceReference Resource1;
		public int UselessPadding;
		public List<UnknownSoundClustersABlock> UnknownSoundClustersA;
		public List<UnknownSoundClustersBBlock> UnknownSoundClustersB;
		public List<UnknownSoundClustersCBlock> UnknownSoundClustersC;
		public List<TransparentPlane> TransparentPlanes;
		public float Unknown66;
		public float Unknown67;
		public float Unknown68;
		public List<CollisionMoppCode> CollisionMoppCodes;
		public float Unknown69;
		public float CollisionWorldBoundsXMin;
		public float CollisionWorldBoundsYMin;
		public float CollisionWorldBoundsZMin;
		public float CollisionWorldBoundsXMax;
		public float CollisionWorldBoundsYMax;
		public float CollisionWorldBoundsZMax;
		public List<BreakableSurfaceMoppCode> BreakableSurfaceMoppCodes;
		public List<BreakableSurfaceKeyTableBlock> BreakableSurfaceKeyTable;
		public float Unknown70;
		public float Unknown71;
		public float Unknown72;
		public float Unknown73;
		public float Unknown74;
		public float Unknown75;
		public int Unknown76;
		public List<Section> Sections;
		public List<CompressionInfoBlock2> CompressionInfo2;
		public List<UnknownNodeyPossiblyPositionalDataNodesBlock> UnknownNodeyPossiblyPositionalDataNodes;
		public List<UnknownBlock5> Unknown77;
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
		public float Unknown88;
		public float Unknown89;
		public float Unknown90;
		public float Unknown91;
		public float Unknown92;
		public float Unknown93;
		public float Unknown94;
		public float Unknown95;
		public ResourceReference Resource2;
		public int UselessPadding2;
		public float Unknown96;
		public float Unknown97;
		public List<LeafSystem> LeafSystems;
		public float Unknown98;
		public ResourceReference Resource3;
		public int UselessPading;
		public ResourceReference Resource4;
		public int UselessPadding3;
		public int Unknown99;
		public float Unknown100;
		public float Unknown101;
		public float Unknown102;

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
			public float Unknown20;
			public float Unknown21;
			public float Unknown22;
			public float Unknown23;
			public float Unknown24;
			public float Unknown25;
			public float Unknown26;
			public float Unknown27;
			public float Unknown28;
			public float Unknown29;
			public float Unknown30;
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
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
		}

		[TagStructure(Size = 0x34)]
		public class DetailObject
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public List<UnknownBlock> Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;

			[TagStructure(Size = 0x20)]
			public class UnknownBlock
			{
				public List<UnknownBlock2> Unknown;
				public byte[] Unknown2;

				[TagStructure(Size = 0x10)]
				public class UnknownBlock2
				{
					public float Unknown;
					public float Unknown2;
					public float Unknown3;
					public float Unknown4;
				}
			}
		}

		[TagStructure(Size = 0xDC)]
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
			public short Flags;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public List<Portal> Portals;
			public int Unknown11;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown12;
			public float Unknown13;
			public float Unknown14;
			public HaloTag Bsp;
			public int ClusterIndex;
			public int Unknown15;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown16;
			public float Unknown17;
			public float Unknown18;
			public float Unknown19;
			public List<CollisionMoppCode> CollisionMoppCodes;
			public short ModelSectionIndex;
			public short Unknown20;
			public List<Seam> Seams;
			public List<DecoratorGrid> DecoratorGrids;
			public float Unknown21;
			public float Unknown22;
			public float Unknown23;
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
				public float Unknown2;
				public float OffsetX;
				public float OffsetY;
				public float OffsetZ;
				public float OffsetScale;
				public float Unknown3;
				public int DataSize;
				public uint DataCapacity;
				public sbyte Unknown4;
				public sbyte Unknown5;
				public sbyte Unknown6;
				public sbyte Unknown7;
				public List<Datum> Data;
				public float Unknown8;

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
				public float Unknown;
				public float Unknown2;
				public float Unknown3;
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
				public short IntValue;
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
			public float Unknown;
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
			public string Name;
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
			public string Name;
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
			public string ScenarioObjectName;
			public float Unknown2;
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
			public short ModelSectionIndex;
			public ushort Flags;
			public short UnknownYoIndex;
			public short Unknown;
			public float Unknown2;
			public float BoundingSphereX;
			public float BoundingSphereY;
			public float BoundingSphereZ;
			public float BoundingSphereRadius1;
			public float BoundingSphereRadius2;
			public StringId Name;
			public short PathfindingPolicy;
			public short LightmappingPolicy;
			public float Unknown3;
			public List<CollisionDefinition> CollisionDefinitions;
			public short Unknown4;
			public short Unknown5;
			public short Unknown6;
			public short Unknown7;
			public float Unknown8;

			[TagStructure(Size = 0x80)]
			public class CollisionDefinition
			{
				public int Unknown;
				public short Size;
				public short Count;
				public int Offset;
				public int Unknown2;
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
				public int Unknown15;
				public float Unknown16;
				public float UnknownPossiblyNewValue;
				public sbyte BspIndex;
				public sbyte Unknown17;
				public short InstancedGeometryIndex;
				public float Unknown18;
				public float Unknown19;
				public float Unknown20;
				public float Unknown21;
				public float Unknown22;
				public float Unknown23;
				public short Size2;
				public short Count2;
				public int Offset2;
				public int Unknown24;
				public float Unknown25;
				public float Unknown26;
				public float Unknown27;
				public float Unknown28;
			}
		}

		[TagStructure(Size = 0x10)]
		public class Decorator
		{
			public HaloTag Decorator2;
		}

		[TagStructure(Size = 0x2C)]
		public class CompressionInfoBlock
		{
			public short Unknown;
			public short Unknown2;
			public float PositionBoundsXMin;
			public float PositionBoundsXMax;
			public float PositionBoundsYMin;
			public float PositionBoundsYMax;
			public float PositionBoundsZMin;
			public float PositionBoundsZMax;
			public float TexcoordBoundsXMin;
			public float TexcoordBoundsXMax;
			public float TexcoordBoundsYMin;
			public float TexcoordBoundsYMax;
		}

		[TagStructure(Size = 0x30)]
		public class UnknownNodeyBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public sbyte NodeIndex;
			public sbyte NodeIndex2;
			public sbyte NodeIndex3;
			public sbyte NodeIndex4;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
		}

		[TagStructure(Size = 0x30)]
		public class UnknownNodeyBlock2
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public sbyte NodeIndex;
			public sbyte NodeIndex2;
			public sbyte NodeIndex3;
			public sbyte NodeIndex4;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
		}

		[TagStructure(Size = 0x18)]
		public class UnknownBlock3
		{
			public short Unknown;
			public short Unknown2;
			public byte[] Unknown3;
		}

		[TagStructure(Size = 0x20)]
		public class UnknownSection
		{
			public byte[] Unknown;
			public List<UnknownBlock> Unknown2;

			[TagStructure(Size = 0x2)]
			public class UnknownBlock
			{
				public short Unknown;
			}
		}

		[TagStructure(Size = 0xC)]
		public class NodeMap
		{
			public List<UnknownBlock> Unknown;

			[TagStructure(Size = 0x1)]
			public class UnknownBlock
			{
				public byte NodeIndex;
			}
		}

		[TagStructure(Size = 0xC)]
		public class UnknownBlock4
		{
			public List<UnknownBlock> Unknown;

			[TagStructure(Size = 0x30)]
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
			}
		}

		[TagStructure(Size = 0x10)]
		public class UnknownYoBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public short UnknownIndex;
			public short Unknown4;
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
			public short ModelSectionIndex;
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
			public float Unknown2;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float OffsetScale;
			public float Unknown3;
			public int DataSize;
			public uint DataCapacity;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public sbyte Unknown7;
			public List<Datum> Data;
			public float Unknown8;

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
			public float Unknown2;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float OffsetScale;
			public float Unknown3;
			public int DataSize;
			public uint DataCapacity;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public sbyte Unknown7;
			public List<Datum> Data;
			public float Unknown8;

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

		[TagStructure(Size = 0x4C)]
		public class Section
		{
			public List<Submesh> Submeshes;
			public List<VertexGroup> VertexGroups;
			public short ValidMeshIndex;
			public short ValidWorldMeshIndex;
			public short ValidTransparent3MeshIndex;
			public short ValidOpaqueMeshIndex;
			public int RawId;
			public short ValidWaterMeshIndex1;
			public short ValidWaterMeshIndex2;
			public short ValidSectionIndex;
			public short ValidWaterSectionIndex;
			public sbyte TransparentNodesPerVertex;
			public sbyte RigidNode;
			public MeshTypeValue MeshType;
			public sbyte OpaqueMaxNodesVertex;
			public sbyte Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public List<InstancedGeometryIndex> InstancedGeometryIndices;
			public List<UnknownWaterBlock> UnknownWater;

			[TagStructure(Size = 0x10)]
			public class Submesh
			{
				public short MaterialIndex;
				public short UnknownNodeyIndex;
				public short IndexBufferStart;
				public short IndexBufferCount;
				public short VertexGroupIndex;
				public short VertexGroupCount;
				public sbyte UnknownEnum;
				public byte Flags;
				public short VertexBufferCount;
			}

			[TagStructure(Size = 0x8)]
			public class VertexGroup
			{
				public short IndexBufferStart;
				public short IndexBufferCount;
				public short ParentSubmeshIndex;
				public short VertexBufferCount;
			}

			public enum MeshTypeValue : sbyte
			{
				World,
				Rigid,
				Skinned,
				ParticleModel,
				FlatWorld,
				FlatRigid,
				FlatSkinned,
				Screen,
				Debug,
				Transparent,
				Particle,
				Contrail,
				LightVolume,
				ChudSimple,
				ChudFancy,
				Decorator,
				TinyPosition,
				PatchyFog,
				Water,
				Ripple,
				Implicit,
				Beam,
			}

			[TagStructure(Size = 0x10)]
			public class InstancedGeometryIndex
			{
				public short InstancedGeometrySectionIndex1;
				public short InstancedGeometrySectionIndex2;
				public List<InstancedGeometrySectionContent> InstancedGeometrySectionContents;

				[TagStructure(Size = 0x2)]
				public class InstancedGeometrySectionContent
				{
					public short InstancedGeometryIndex;
				}
			}

			[TagStructure(Size = 0x2)]
			public class UnknownWaterBlock
			{
				public short Unknown;
			}
		}

		[TagStructure(Size = 0x2C)]
		public class CompressionInfoBlock2
		{
			public short Unknown;
			public short Unknown2;
			public float PositionBoundsXMin;
			public float PositionBoundsXMax;
			public float PositionBoundsYMin;
			public float PositionBoundsYMax;
			public float PositionBoundsZMin;
			public float PositionBoundsZMax;
			public float TexcoordBoundsXMin;
			public float TexcoordBoundsXMax;
			public float TexcoordBoundsYMin;
			public float TexcoordBoundsYMax;
		}

		[TagStructure(Size = 0x30)]
		public class UnknownNodeyPossiblyPositionalDataNodesBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public sbyte NodeIndex;
			public sbyte NodeIndex2;
			public sbyte NodeIndex3;
			public sbyte NodeIndex4;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
		}

		[TagStructure(Size = 0x18)]
		public class UnknownBlock5
		{
			public short Unknown;
			public short Unknown2;
			public byte[] Unknown3;
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
