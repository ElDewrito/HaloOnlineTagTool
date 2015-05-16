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
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public int Unknown4 { get; set; }
		[TagElement]
		public int Unknown8 { get; set; }
		[TagElement]
		public int UnknownC { get; set; }
		[TagElement]
		public int Unknown10 { get; set; }
		[TagElement]
		public int Unknown14 { get; set; }

		/// <summary>
		/// Gets or sets the vertex buffer definitions for the model data.
		/// </summary>
		[TagElement]
		public List<D3DPointer<VertexBufferDefinition>> VertexBuffers { get; set; }

		/// <summary>
		/// Gets or sets the index buffer definitions for the model data.
		/// </summary>
		[TagElement]
		public List<D3DPointer<IndexBufferDefinition>> IndexBuffers { get; set; }

		/// <summary>
		/// Defines a vertex buffer in model data.
		/// </summary>
		[TagStructure(Size = 0x20)]
		public class VertexBufferDefinition
		{
			/// <summary>
			/// Gets or sets the number of vertices in the buffer.
			/// </summary>
			[TagElement]
			public int Count { get; set; }

			/// <summary>
			/// Gets or sets the format of each vertex.
			/// </summary>
			[TagElement]
			public VertexFormat Format { get; set; }

			[TagElement]
			public byte Unused5 { get; set; }

			/// <summary>
			/// Gets or sets the size of each vertex in bytes.
			/// </summary>
			/// <remarks>
			/// This multiplied by <see cref="Count"/> should equal <see cref="TotalSize"/>.
			/// </remarks>
			[TagElement]
			public short VertexSize { get; set; }

			/// <summary>
			/// Gets or sets the reference to the the data for the vertex buffer.
			/// </summary>
			[TagElement]
			public ResourceDataReference Data { get; set; }

			[TagElement]
			public int Unused1C { get; set; }
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
			[TagElement]
			public PrimitiveType Type { get; set; }

			/// <summary>
			/// Gets or sets the reference to the data for the index buffer.
			/// </summary>
			[TagElement]
			public ResourceDataReference Data { get; set; }

			[TagElement]
			public int Unused18 { get; set; }
			[TagElement]
			public int Unused1C { get; set; }
		}
	}
}
