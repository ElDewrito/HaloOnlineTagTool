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
	[TagStructure(Class = "coll", Size = 0x44)]
	public class CollisionModel
	{
		public int CollisionModelChecksum;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Flags;
		public List<Material> Materials;
		public List<Region> Regions;
		public List<PathfindingSphere> PathfindingSpheres;
		public List<Node> Nodes;

		[TagStructure(Size = 0x8)]
		public class Material
		{
			public StringId Name;
			public uint UnknownFlags;
		}

		[TagStructure(Size = 0x10)]
		public class Region
		{
			public StringId Name;
			public List<Permutation> Permutations;

			[TagStructure(Size = 0x28)]
			public class Permutation
			{
				public StringId Name;
				public List<Bsp> Bsps;
				public List<BspPhysic> BspPhysics;
				public List<BspMoppCode> BspMoppCodes;

				[TagStructure(Size = 0x64)]
				public class Bsp
				{
					public short NodeIndex;
					public short Unknown;
					public List<Bsp3dNode> Bsp3dNodes;
					public List<Plane> Planes;
					public List<Leaf> Leaves;
					public List<Bsp2dReference> Bsp2dReferences;
					public List<Bsp2dNode> Bsp2dNodes;
					public List<Surface> Surfaces;
					public List<Edge> Edges;
					public List<Vertex> Vertices;

					[TagStructure(Size = 0x8)]
					public class Bsp3dNode
					{
						public byte Unknown;
						public short SecondChild;
						public byte Unknown2;
						public short FirstChild;
						public short Plane;
					}

					[TagStructure(Size = 0x10)]
					public class Plane
					{
						public float PlaneI;
						public float PlaneJ;
						public float PlaneK;
						public float PlaneD;
					}

					[TagStructure(Size = 0x8)]
					public class Leaf
					{
						public short Flags;
						public short Bsp2dReferenceCount;
						public short Unknown;
						public short FirstBsp2dReference;
					}

					[TagStructure(Size = 0x4)]
					public class Bsp2dReference
					{
						public short Plane;
						public short Bsp2dNode;
					}

					[TagStructure(Size = 0x10)]
					public class Bsp2dNode
					{
						public float PlaneI;
						public float PlaneJ;
						public float PlaneD;
						public short LeftChild;
						public short RightChild;
					}

					[TagStructure(Size = 0xC)]
					public class Surface
					{
						public short Plane;
						public short FirstEdge;
						public short Material;
						public short Unknown;
						public short BreakableSurface;
						public short Unknown2;
					}

					[TagStructure(Size = 0xC)]
					public class Edge
					{
						public short StartVertex;
						public short EndVertex;
						public short ForwardEdge;
						public short ReverseEdge;
						public short LeftSurface;
						public short RightSurface;
					}

					[TagStructure(Size = 0x10)]
					public class Vertex
					{
						public float PointX;
						public float PointY;
						public float PointZ;
						public short FirstEdge;
						public short Unknown;
					}
				}

				[TagStructure(Size = 0x70)]
				public class BspPhysic
				{
					public uint Unknown;
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
					[TagField(Flags = TagFieldFlags.Short)] public HaloTag Model;
					public uint Unknown15;
					public uint Unknown16;
					public short Unknown17;
					public short Unknown18;
					public uint Unknown19;
					public uint Unknown20;
					public uint Unknown21;
					public uint Unknown22;
					public uint Unknown23;
					public short Size2;
					public short Count2;
					public int Offset2;
					public int Unknown24;
				}

				[TagStructure(Size = 0x40)]
				public class BspMoppCode
				{
					public int Size;
					public int Count;
					public int Offset;
					public uint Unknown;
					public float OffsetX;
					public float OffsetY;
					public float OffsetZ;
					public float OffsetScale;
					public uint Unknown2;
					public int DataSize;
					public uint DataCapacity;
					public sbyte Unknown3;
					public sbyte Unknown4;
					public sbyte Unknown5;
					public sbyte Unknown6;
					public List<Datum> Data;
					public uint Unknown7;

					[TagStructure(Size = 0x1)]
					public class Datum
					{
						public byte DataByte;
					}
				}
			}
		}

		[TagStructure(Size = 0x14)]
		public class PathfindingSphere
		{
			public short Node;
			public ushort Flags;
			public float CenterX;
			public float CenterY;
			public float CenterZ;
			public float Radius;
		}

		[TagStructure(Size = 0xC)]
		public class Node
		{
			public StringId Name;
			public short Unknown;
			public short ParentNode;
			public short NextSiblingNode;
			public short FirstChildNode;
		}
	}
}
