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
		[TagElement]
		public List<Part> Parts { get; set; }

		/// <summary>
		/// Gets or sets the subparts of the mesh.
		/// Subparts can be toggled on and off for each part.
		/// </summary>
		[TagElement]
		public List<SubPart> SubParts { get; set; }

		/// <summary>
		/// Gets or sets the vertex buffers to use for the mesh, as indexes into the
		/// vertex buffer array in the model's definition data. If an index is 0xFF,
		/// then the buffer is not set.
		/// </summary>
		[TagElement(Count = 8)]
		public ushort[] VertexBuffers { get; set; }

		/// <summary>
		/// Gets or sets the index buffers to use for the mesh, as an index into the
		/// index buffer array in the model's definition data. If an index is 0xFF,
		/// then the buffer is not set.
		/// </summary>
		[TagElement(Count = 2)]
		public ushort[] IndexBuffers { get; set; }

		/// <summary>
		/// Gets or sets flags describing the mesh.
		/// </summary>
		[TagElement]
		public MeshFlags Flags { get; set; }

		/// <summary>
		/// Gets or sets the index of the node to associate the mesh with.
		/// Only applies to rigid meshes.
		/// </summary>
		[TagElement]
		public byte RigidNodeIndex { get; set; }

		/// <summary>
		/// Gets or sets the type of each vertex in the mesh.
		/// </summary>
		[TagElement]
		public VertexType Type { get; set; }

		/// <summary>
		/// Gets or sets the type of precomputed radiance transfer (PRT) that the mesh uses.
		/// </summary>
		[TagElement]
		public PrtType PrtType { get; set; }

		[TagElement]
		public PrimitiveType IndexBufferType { get; set; }

		[TagElement]
		public List<TagBlock20> Unknown34 { get; set; } // Instanced geometry
		[TagElement]
		public List<TagBlock22> Unknown40 { get; set; } // Water

		/// <summary>
		/// Associates geometry with a specific material.
		/// </summary>
		[TagStructure(Size = 0x10)]
		public class Part
		{
			/// <summary>
			/// Gets or sets the index of the material.
			/// </summary>
			[TagElement]
			public short MaterialIndex { get; set; }

			[TagElement]
			public short Unknown2 { get; set; }

			/// <summary>
			/// Gets or sets the index of the first vertex in the index buffer.
			/// </summary>
			[TagElement]
			public ushort FirstIndex { get; set; }

			/// <summary>
			/// Gets or sets the number of indexes in the part.
			/// </summary>
			[TagElement]
			public ushort IndexCount { get; set; }

			/// <summary>
			/// Gets or sets the index of the first subpart that makes up this part.
			/// </summary>
			[TagElement]
			public short FirstSubPartIndex { get; set; }

			/// <summary>
			/// Gets or sets the number of subparts that make up this part.
			/// </summary>
			[TagElement]
			public short SubPartCount { get; set; }

			[TagElement]
			public byte UnknownC { get; set; } // enum
			[TagElement]
			public byte UnknownD { get; set; } // flags

			/// <summary>
			/// Gets or sets the number of vertices that the part uses.
			/// </summary>
			/// <remarks>
			/// Note that this actually seems to be unused. The value is pulled from
			/// the vertex buffer definition instead.
			/// </remarks>
			[TagElement]
			public ushort VertexCount { get; set; }
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
			[TagElement]
			public short FirstIndex { get; set; }

			/// <summary>
			/// Gets or sets the number of indexes in the subpart.
			/// </summary>
			[TagElement]
			public short IndexCount { get; set; }

			/// <summary>
			/// Gets or sets the index of the part which this subpart belongs to.
			/// </summary>
			[TagElement]
			public short PartIndex { get; set; }

			/// <summary>
			/// Gets or sets the number of vertices that the part uses.
			/// </summary>
			/// <remarks>
			/// Note that this actually seems to be unused. The value is pulled from
			/// the vertex buffer definition instead.
			/// </remarks>
			[TagElement]
			public short VertexCount { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class TagBlock20
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public List<TagBlock21> Unknown4 { get; set; }

			[TagStructure(Size = 0x2)]
			public class TagBlock21
			{
				[TagElement]
				public short Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0x4)]
		public class TagBlock22
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}
	}
}
