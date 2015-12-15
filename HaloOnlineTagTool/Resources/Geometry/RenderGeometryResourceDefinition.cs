using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// Resource definition data for renderable geometry.
    /// </summary>
    [TagStructure(Size = 0x30)]
    public class RenderGeometryResourceDefinition
    {
        public int Unknown0;
        public int Unknown4;
        public int Unknown8;
        public int UnknownC;
        public int Unknown10;
        public int Unknown14;

        /// <summary>
        /// Gets or sets the vertex buffer definitions for the model data.
        /// </summary>
        public List<D3DPointer<VertexBufferDefinition>> VertexBuffers;

        /// <summary>
        /// Gets or sets the index buffer definitions for the model data.
        /// </summary>
        public List<D3DPointer<IndexBufferDefinition>> IndexBuffers;
    }

    /// <summary>
    /// Defines a vertex buffer in model data.
    /// </summary>
    [TagStructure(Size = 0x20)]
    public class VertexBufferDefinition
    {
        /// <summary>
        /// Gets or sets the number of vertices in the buffer.
        /// </summary>
        public int Count;

        /// <summary>
        /// Gets or sets the format of each vertex.
        /// </summary>
        public VertexBufferFormat Format;

        /// <summary>
        /// Gets or sets the size of each vertex in bytes.
        /// </summary>
        /// <remarks>
        /// This multiplied by <see cref="Count"/> should equal the total buffer size.
        /// </remarks>
        public short VertexSize;

        /// <summary>
        /// Gets or sets the reference to the the data for the vertex buffer.
        /// </summary>
        public ResourceDataReference Data;

        public int Unused1C;
    }

    /// <summary>
    /// Defines an index buffer in model data.
    /// </summary>
    [TagStructure(Size = 0x20)]
    public class IndexBufferDefinition
    {
        /// <summary>
        /// Gets or sets the primitive type to use for the index buffer.
        /// </summary>
        public PrimitiveType Type;

        /// <summary>
        /// Gets or sets the reference to the data for the index buffer.
        /// </summary>
        public ResourceDataReference Data;

        public int Unused18;
        public int Unused1C;
    }
}
