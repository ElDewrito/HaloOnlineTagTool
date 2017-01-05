using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources.Geometry
{
    [TagStructure(Size = 0x30)]
    public class CollisionBspResourceDefinition
    {
        public List<CollisionBsp> CollisionBsps;
        public int Unknown1;
        public int Unknown2;
        public int Unknown3;
        public List<Compression> Compressions;
        public int Unknown4;
        public int Unknown5;
        public int Unknown6;
        
        [TagStructure(Size = 0x5C)]
        public class CollisionBsp
        {
            public ResourceBlockReference<Bsp3DNode> Bsp3DNodes;
            public ResourceBlockReference<Plane> Planes;
            public ResourceBlockReference<Leaf> Leaves;
            public ResourceBlockReference<Bsp2DReference> Bsp2DReferences;
            public ResourceBlockReference<Bsp2DNode> Bsp2DNodes;
            public ResourceBlockReference<Surface> Surfaces;
            public ResourceBlockReference<Edge> Edges;
            public ResourceBlockReference<Vertex> Vertices;

            [TagStructure(Size = 0x8)]
            public class Bsp3DNode
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

            [Flags]
            public enum LeafFlags : byte
            {
                None = 0,
                ContainsDoubleSidedSurfaces = 1 << 0
            }

            [TagStructure(Size = 0x4)]
            public class Leaf
            {
                public LeafFlags Flags;
                public byte Unused;
                public short Bsp2DReferenceCount;
                public int FirstBsp2DReference;
            }

            [TagStructure(Size = 0x4)]
            public class Bsp2DReference
            {
                public short Plane;
                public short Bsp2DNode;
            }

            [TagStructure(Size = 0x10)]
            public class Bsp2DNode
            {
                public float PlaneI;
                public float PlaneJ;
                public float PlaneD;
                public short LeftChild;
                public short RightChild;
            }

            [TagStructure(Size = 0x8)]
            public class Surface
            {
                public short Plane;
                public short FirstEdge;
                public short Material;
                public short Unknown;
                public short BreakableSurface;
                public short Unknown2;
            }

            [TagStructure(Size = 0xc)]
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
                public Vector3 Position;
                public short FirstEdge;
                public short Sink;
            }
        }

        [TagStructure(Size = 0xC8)]
        public class Compression
        {
            public float X;
            public float Y;
            public float Z;
            public float W;
            public float R;
            public CollisionBsp CollisionBsp;
            public int Unknown13;
            public List<CollisionBsp> CollisionBsps;
            public List<CollisionMoppCode> CollisionMoppCodes;
            public int Unknown1;
            public int Unknown2;
            public int Unknown3;
            public int Unknown4;
            public int Unknown5;
            public int Unknown6;
            public int Unknown7;
            public int Unknown8;
            public int Unknown9;
            public short Index01;
            public short Index02;
            public int Unknown10;
            public List<CollisionMoppCode> CollisionMOPPCodes2;
            public int Unknown11;
        }

        [TagStructure(Size = 0x40)]
        public class CollisionMoppCode
        {
            public int Unknown1;
            public short Size;
            public short Count;
            public int Address;
            public int Unknown2;
            public Vector3 Offset;
            public float OffsetScale;
            public int Unknown3;
            public int DataSize;
            public uint DataCapacity;
            public sbyte Unknown4;
            public sbyte Unknown5;
            public sbyte Unknown6;
            public sbyte Unknown7;
            public int DatumCount;
            public ResourceAddress Data;
            public int Unknown8;
            public int Unknown9;
        }

        [TagStructure(Size = 0x8)]
        public class Unknown
        {
            public int Unknown1;
            public int Unknown2;
        }
    }
}
