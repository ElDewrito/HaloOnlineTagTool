using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures.Resources
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
		public List<D3DObject<VertexBufferDefinition>> VertexBuffers { get; set; }

		/// <summary>
		/// Gets or sets the index buffer definitions for the model data.
		/// </summary>
		[TagElement]
		public List<D3DObject<IndexBufferDefinition>> IndexBuffers { get; set; }

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
			public RawResourceDataReference Data { get; set; }

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
			public RawResourceDataReference Data { get; set; }

			[TagElement]
			public int Unused18 { get; set; }
			[TagElement]
			public int Unused1C { get; set; }
		}

		/// <summary>
		/// Vertex formats.
		/// </summary>
		public enum VertexFormat : byte
		{
			World,               // s_world_vertex
			Rigid,               // s_rigid_vertex
			Skinned,             // s_skinned_vertex
			ParticleModel,       // s_particle_model_vertex
			FlatWorld,           // s_flat_world_vertex
			FlatRigid,           // s_flat_rigid_vertex
			FlatSkinned,         // s_flat_skinned_vertex
			Screen,              // s_screen_vertex
			Debug,               // s_debug_vertex
			Transparent,         // s_transparent_vertex
			Particle,            // s_particle_vertex
			Contrail,            // s_contrail_vertex
			LightVolume,         // s_light_volume_vertex
			ChudSimple,          // s_chud_vertex_simple
			ChudFancy,           // s_chud_vertex_fancy
			Decorator,           // s_decorator_vertex
			TinyPosition,        // s_tiny_position_vertex
			PatchyFog,           // s_patchy_fog_vertex
			Water,               // s_water_vertex
			Ripple,              // s_ripple_vertex
			Implicit,            // s_implicit_vertex
			Beam,                // s_beam_vertex
			SkinnedDualQuatBlend // s_dual_quat_vertex
		}

		/// <summary>
		/// Model primitive types. Corresponds to the D3DPRIMITIVETYPE enum.
		/// </summary>
		public enum PrimitiveType : int
		{
			Invalid,
			PointList,
			LineList,
			LineStrip,
			TriangleList,
			TriangleStrip,
			TriangleFan
		}
	}
}
