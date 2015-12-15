using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// A 3D mesh which can be rendered.
    /// </summary>
    [TagStructure(Size = 0x4C)]
    public class Mesh
    {
        /// <summary>
        /// Gets or sets the parts of the mesh, grouped by render method.
        /// </summary>
        public List<Part> Parts;

        /// <summary>
        /// Gets or sets the subparts of the mesh.
        /// Subparts can be toggled on and off for each part.
        /// </summary>
        public List<SubPart> SubParts;

        /// <summary>
        /// Gets or sets the vertex buffers to use for the mesh, as indexes into the
        /// vertex buffer array in the model's definition data. If an index is 0xFFFF,
        /// then the buffer is not set.
        /// </summary>
        [TagField(Count = 8)] public ushort[] VertexBuffers;

        /// <summary>
        /// Gets or sets the index buffers to use for the mesh, as an index into the
        /// index buffer array in the model's definition data. If an index is 0xFFFF,
        /// then the buffer is not set.
        /// </summary>
        [TagField(Count = 2)] public ushort[] IndexBuffers;

        /// <summary>
        /// Gets or sets flags describing the mesh.
        /// </summary>
        public MeshFlags Flags;

        /// <summary>
        /// Gets or sets the index of the node to associate the mesh with.
        /// Only applies to rigid meshes.
        /// </summary>
        public byte RigidNodeIndex;

        /// <summary>
        /// Gets or sets the type of each vertex in the mesh.
        /// </summary>
        public VertexType Type;

        /// <summary>
        /// Gets or sets the type of precomputed radiance transfer (PRT) that the mesh uses.
        /// </summary>
        public PrtType PrtType;

        public PrimitiveType IndexBufferType;

        public List<TagBlock20> Unknown34; // Instanced geometry
        public List<short> Unknown40; // Water

        /// <summary>
        /// Associates geometry with a specific material.
        /// </summary>
        [TagStructure(Size = 0x10)]
        public class Part
        {
            /// <summary>
            /// Gets or sets the index of the material.
            /// </summary>
            public short MaterialIndex;

            public short Unknown2;

            /// <summary>
            /// Gets or sets the index of the first vertex in the index buffer.
            /// </summary>
            public ushort FirstIndex;

            /// <summary>
            /// Gets or sets the number of indexes in the part.
            /// </summary>
            public ushort IndexCount;

            /// <summary>
            /// Gets or sets the index of the first subpart that makes up this part.
            /// </summary>
            public short FirstSubPartIndex;

            /// <summary>
            /// Gets or sets the number of subparts that make up this part.
            /// </summary>
            public short SubPartCount;
            
            public byte UnknownC; // enum
            public byte UnknownD; // flags

            /// <summary>
            /// Gets or sets the number of vertices that the part uses.
            /// </summary>
            public ushort VertexCount;
        }

        /// <summary>
        /// A subpart of a mesh which can be rendered selectively.
        /// </summary>
        [TagStructure(Size = 0x8)]
        public class SubPart
        {
            /// <summary>
            /// Gets or sets the index of the first vertex in the subpart.
            /// </summary>
            public ushort FirstIndex;

            /// <summary>
            /// Gets or sets the number of indexes in the subpart.
            /// </summary>
            public ushort IndexCount;

            /// <summary>
            /// Gets or sets the index of the part which this subpart belongs to.
            /// </summary>
            public short PartIndex;

            /// <summary>
            /// Gets or sets the number of vertices that the part uses.
            /// </summary>
            /// <remarks>
            /// Note that this actually seems to be unused. The value is pulled from
            /// the vertex buffer definition instead.
            /// </remarks>
            public ushort VertexCount;
        }

        [TagStructure(Size = 0x10)]
        public class TagBlock20
        {
            public int Unknown0;
            public List<short> Unknown4;
        }
    }
}
