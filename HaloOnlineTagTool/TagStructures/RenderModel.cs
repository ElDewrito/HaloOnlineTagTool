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
	[TagStructure(Class = "mode", Size = 0x1D0)]
	public class RenderModel
	{
		[TagElement]
		public int Name { get; set; }
		[TagElement]
		public ushort Flags { get; set; }
		[TagElement]
		public short Unknown6 { get; set; }
		[TagElement]
		public int Checksum { get; set; }
		[TagElement]
		public List<Region> Regions { get; set; }
		[TagElement]
		public int Unknown18 { get; set; }
		[TagElement]
		public int Unknown1C { get; set; }
		[TagElement]
		public List<Flair> Flairs { get; set; }
		[TagElement]
		public int Unknown2C { get; set; }
		[TagElement]
		public List<Node> Nodes { get; set; }
		[TagElement]
		public List<MarkerGroup> MarkerGroups { get; set; }
		[TagElement]
		public List<Material> Materials { get; set; }
		[TagElement]
		public int Unknown54 { get; set; }
		[TagElement]
		public int Unknown58 { get; set; }
		[TagElement]
		public int Unknown5C { get; set; }
		[TagElement]
		public int Unknown60 { get; set; }
		[TagElement]
		public int Unknown64 { get; set; }
		[TagElement]
		public List<Mesh> Meshes { get; set; }
		[TagElement]
		public List<BoundingBox> BoundingBoxes { get; set; }
		[TagElement]
		public List<TagBlock11> Unknown80 { get; set; }
		[TagElement]
		public List<TagBlock12> Unknown8C { get; set; }
		[TagElement]
		public int Unknown98 { get; set; }
		[TagElement]
		public int Unknown9C { get; set; }
		[TagElement]
		public int UnknownA0 { get; set; }
		[TagElement]
		public int UnknownA4 { get; set; }
		[TagElement]
		public int UnknownA8 { get; set; }
		[TagElement]
		public int UnknownAC { get; set; }
		[TagElement]
		public List<TagBlock13> UnknownB0 { get; set; }
		[TagElement]
		public List<TagBlock15> UnknownBC { get; set; }
		[TagElement]
		public int UnknownC8 { get; set; }
		[TagElement]
		public int UnknownCC { get; set; }
		[TagElement]
		public int UnknownD0 { get; set; }
		[TagElement]
		public int UnknownD4 { get; set; }
		[TagElement]
		public int UnknownD8 { get; set; }
		[TagElement]
		public int UnknownDC { get; set; }
		[TagElement]
		public ResourceReference Resource { get; set; }
		[TagElement]
		public int UnknownE4 { get; set; }
		[TagElement]
		public List<TagBlock17> UnknownE8 { get; set; }
		[TagElement]
		public int UnknownF4 { get; set; }
		[TagElement]
		public int UnknownF8 { get; set; }
		[TagElement]
		public int UnknownFC { get; set; }
		[TagElement]
		public int Unknown100 { get; set; }
		[TagElement]
		public int Unknown104 { get; set; }
		[TagElement]
		public int Unknown108 { get; set; }
		[TagElement]
		public int Unknown10C { get; set; }
		[TagElement]
		public int Unknown110 { get; set; }
		[TagElement]
		public int Unknown114 { get; set; }
		[TagElement]
		public int Unknown118 { get; set; }
		[TagElement]
		public int Unknown11C { get; set; }
		[TagElement]
		public int Unknown120 { get; set; }
		[TagElement]
		public int Unknown124 { get; set; }
		[TagElement]
		public int Unknown128 { get; set; }
		[TagElement]
		public int Unknown12C { get; set; }
		[TagElement]
		public int Unknown130 { get; set; }
		[TagElement]
		public int Unknown134 { get; set; }
		[TagElement]
		public int Unknown138 { get; set; }
		[TagElement]
		public int Unknown13C { get; set; }
		[TagElement]
		public int Unknown140 { get; set; }
		[TagElement]
		public int Unknown144 { get; set; }
		[TagElement]
		public int Unknown148 { get; set; }
		[TagElement]
		public int Unknown14C { get; set; }
		[TagElement]
		public int Unknown150 { get; set; }
		[TagElement]
		public int Unknown154 { get; set; }
		[TagElement]
		public int Unknown158 { get; set; }
		[TagElement]
		public int Unknown15C { get; set; }
		[TagElement]
		public int Unknown160 { get; set; }
		[TagElement]
		public int Unknown164 { get; set; }
		[TagElement]
		public int Unknown168 { get; set; }
		[TagElement]
		public int Unknown16C { get; set; }
		[TagElement]
		public int Unknown170 { get; set; }
		[TagElement]
		public int Unknown174 { get; set; }
		[TagElement]
		public int Unknown178 { get; set; }
		[TagElement]
		public int Unknown17C { get; set; }
		[TagElement]
		public int Unknown180 { get; set; }
		[TagElement]
		public int Unknown184 { get; set; }
		[TagElement]
		public int Unknown188 { get; set; }
		[TagElement]
		public int Unknown18C { get; set; }
		[TagElement]
		public int Unknown190 { get; set; }
		[TagElement]
		public int Unknown194 { get; set; }
		[TagElement]
		public int Unknown198 { get; set; }
		[TagElement]
		public int Unknown19C { get; set; }
		[TagElement]
		public int Unknown1A0 { get; set; }
		[TagElement]
		public int Unknown1A4 { get; set; }
		[TagElement]
		public int Unknown1A8 { get; set; }
		[TagElement]
		public int Unknown1AC { get; set; }
		[TagElement]
		public int Unknown1B0 { get; set; }
		[TagElement]
		public List<TagBlock18> Unknown1B4 { get; set; }
		[TagElement]
		public List<TagBlock19> Unknown1C0 { get; set; }
		[TagElement]
		public int Unknown1CC { get; set; }

		/// <summary>
		/// A region of a model.
		/// </summary>
		[TagStructure(Size = 0x10)]
		public class Region
		{
			/// <summary>
			/// Gets or sets the name of the region as a stringID.
			/// </summary>
			[TagElement]
			public int Name { get; set; }

			/// <summary>
			/// Gets or sets the permutations belonging to the region.
			/// </summary>
			[TagElement]
			public List<Permutation> Permutations { get; set; }

			/// <summary>
			/// A permutation of a region, associating a specific mesh with it.
			/// </summary>
			[TagStructure(Size = 0x18)]
			public class Permutation
			{
				/// <summary>
				/// Gets or sets the name of the permutation as a stringID.
				/// </summary>
				[TagElement]
				public int Name { get; set; }

				/// <summary>
				/// Gets or sets the index of the first mesh belonging to the permutation.
				/// </summary>
				[TagElement]
				public ushort MeshIndex { get; set; }

				/// <summary>
				/// Gets or sets the number of meshes belonging to the permutation.
				/// </summary>
				[TagElement]
				public ushort MeshCount { get; set; }

				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
			}
		}

		[TagStructure(Size = 0x3C)]
		public class Flair
		{
			[TagElement]
			public int Name { get; set; }
			[TagElement]
			public ushort Flags { get; set; }
			[TagElement]
			public short NodeIndex { get; set; }
			[TagElement]
			public float DefaultScale { get; set; }
			[TagElement]
			public Vector3 InverseForward { get; set; }
			[TagElement]
			public Vector3 InverseLeft { get; set; }
			[TagElement]
			public Vector3 InverseUp { get; set; }
			[TagElement]
			public Vector3 InversePosition { get; set; }
		}

		[TagStructure(Size = 0x60)]
		public class Node
		{
			[TagElement]
			public int Name { get; set; }
			[TagElement]
			public short ParentNode { get; set; }
			[TagElement]
			public short FirstChildNode { get; set; }
			[TagElement]
			public short NextSiblingNode { get; set; }
			[TagElement]
			public short ImportNode { get; set; }
			[TagElement]
			public Vector3 DefaultTranslation { get; set; }
			[TagElement]
			public Vector4 DefaultRotation { get; set; }
			[TagElement]
			public float DefaultScale { get; set; }
			[TagElement]
			public Vector3 InverseForward { get; set; }
			[TagElement]
			public Vector3 InverseLeft { get; set; }
			[TagElement]
			public Vector3 InverseUp { get; set; }
			[TagElement]
			public Vector3 InversePosition { get; set; }
			[TagElement]
			public float DistanceFromParent { get; set; }
		}

		[TagStructure(Size = 0x10)]
		public class MarkerGroup
		{
			[TagElement]
			public int Name { get; set; }
			[TagElement]
			public List<Marker> Markers { get; set; }

			[TagStructure(Size = 0x24)]
			public class Marker
			{
				[TagElement]
				public sbyte RegionIndex { get; set; }
				[TagElement]
				public sbyte PermutationIndex { get; set; }
				[TagElement]
				public sbyte NodeIndex { get; set; }
				[TagElement]
				public sbyte Unknown3 { get; set; }
				[TagElement]
				public Vector3 Translation { get; set; }
				[TagElement]
				public Vector4 Rotation { get; set; }
				[TagElement]
				public float Scale { get; set; }
			}
		}

		/// <summary>
		/// A material describing how a mesh part should be rendered.
		/// </summary>
		[TagStructure(Size = 0x24)]
		public class Material
		{
			/// <summary>
			/// Gets or sets the render method tag to use to render the material.
			/// </summary>
			[TagElement]
			public HaloTag RenderMethod { get; set; }

			[TagElement]
			public int Unknown10 { get; set; }
			[TagElement]
			public int Unknown14 { get; set; }
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public sbyte BreakableSurfaceIndex { get; set; }
			[TagElement]
			public sbyte Unknown21 { get; set; }
			[TagElement]
			public sbyte Unknown22 { get; set; }
			[TagElement]
			public sbyte Unknown23 { get; set; }
		}

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

		[TagStructure(Size = 0x2C)]
		public class BoundingBox
		{
			[TagElement]
			public short Unknown0 { get; set; }
			[TagElement]
			public short Unknown2 { get; set; }
			[TagElement]
			public float PositionMinX { get; set; }
			[TagElement]
			public float PositionMaxX { get; set; }
			[TagElement]
			public float PositionMinY { get; set; }
			[TagElement]
			public float PositionMaxY { get; set; }
			[TagElement]
			public float PositionMinZ { get; set; }
			[TagElement]
			public float PositionMaxZ { get; set; }
			[TagElement]
			public float TextureMinU { get; set; }
			[TagElement]
			public float TextureMaxU { get; set; }
			[TagElement]
			public float TextureMinV { get; set; }
			[TagElement]
			public float TextureMaxV { get; set; }
		}

		[TagStructure(Size = 0x30)]
		public class TagBlock11
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
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public int Unknown20 { get; set; }
			[TagElement]
			public int Unknown24 { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
		}

		[TagStructure(Size = 0x18)]
		public class TagBlock12
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public byte[] Unknown4 { get; set; }
		}

		[TagStructure(Size = 0x10)] // TODO: Check this size, it's 0xC in H3
		public class TagBlock13
		{
			[TagElement]
			public List<TagBlock14> Unknown0 { get; set; }
			[TagElement]
			public int UnknownC { get; set; }

			[TagStructure(Size = 0x4)]
			public class TagBlock14
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}
		}

		[TagStructure(Size = 0xC)]
		public class TagBlock15
		{
			[TagElement]
			public List<TagBlock16> Unknown0 { get; set; }

			[TagStructure(Size = 0x30)]
			public class TagBlock16
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
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public int Unknown2C { get; set; }
			}
		}

		[TagStructure(Size = 0x1C)]
		public class TagBlock17
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
			[TagElement]
			public int Unknown18 { get; set; }
		}

		[TagStructure(Size = 0x150)]
		public class TagBlock18
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
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public int Unknown20 { get; set; }
			[TagElement]
			public int Unknown24 { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
			[TagElement]
			public int Unknown30 { get; set; }
			[TagElement]
			public int Unknown34 { get; set; }
			[TagElement]
			public int Unknown38 { get; set; }
			[TagElement]
			public int Unknown3C { get; set; }
			[TagElement]
			public int Unknown40 { get; set; }
			[TagElement]
			public int Unknown44 { get; set; }
			[TagElement]
			public int Unknown48 { get; set; }
			[TagElement]
			public int Unknown4C { get; set; }
			[TagElement]
			public int Unknown50 { get; set; }
			[TagElement]
			public int Unknown54 { get; set; }
			[TagElement]
			public int Unknown58 { get; set; }
			[TagElement]
			public int Unknown5C { get; set; }
			[TagElement]
			public int Unknown60 { get; set; }
			[TagElement]
			public int Unknown64 { get; set; }
			[TagElement]
			public int Unknown68 { get; set; }
			[TagElement]
			public int Unknown6C { get; set; }
			[TagElement]
			public int Unknown70 { get; set; }
			[TagElement]
			public int Unknown74 { get; set; }
			[TagElement]
			public int Unknown78 { get; set; }
			[TagElement]
			public int Unknown7C { get; set; }
			[TagElement]
			public int Unknown80 { get; set; }
			[TagElement]
			public int Unknown84 { get; set; }
			[TagElement]
			public int Unknown88 { get; set; }
			[TagElement]
			public int Unknown8C { get; set; }
			[TagElement]
			public int Unknown90 { get; set; }
			[TagElement]
			public int Unknown94 { get; set; }
			[TagElement]
			public int Unknown98 { get; set; }
			[TagElement]
			public int Unknown9C { get; set; }
			[TagElement]
			public int UnknownA0 { get; set; }
			[TagElement]
			public int UnknownA4 { get; set; }
			[TagElement]
			public int UnknownA8 { get; set; }
			[TagElement]
			public int UnknownAC { get; set; }
			[TagElement]
			public int UnknownB0 { get; set; }
			[TagElement]
			public int UnknownB4 { get; set; }
			[TagElement]
			public int UnknownB8 { get; set; }
			[TagElement]
			public int UnknownBC { get; set; }
			[TagElement]
			public int UnknownC0 { get; set; }
			[TagElement]
			public int UnknownC4 { get; set; }
			[TagElement]
			public int UnknownC8 { get; set; }
			[TagElement]
			public int UnknownCC { get; set; }
			[TagElement]
			public int UnknownD0 { get; set; }
			[TagElement]
			public int UnknownD4 { get; set; }
			[TagElement]
			public int UnknownD8 { get; set; }
			[TagElement]
			public int UnknownDC { get; set; }
			[TagElement]
			public int UnknownE0 { get; set; }
			[TagElement]
			public int UnknownE4 { get; set; }
			[TagElement]
			public int UnknownE8 { get; set; }
			[TagElement]
			public int UnknownEC { get; set; }
			[TagElement]
			public int UnknownF0 { get; set; }
			[TagElement]
			public int UnknownF4 { get; set; }
			[TagElement]
			public int UnknownF8 { get; set; }
			[TagElement]
			public int UnknownFC { get; set; }
			[TagElement]
			public int Unknown100 { get; set; }
			[TagElement]
			public int Unknown104 { get; set; }
			[TagElement]
			public int Unknown108 { get; set; }
			[TagElement]
			public int Unknown10C { get; set; }
			[TagElement]
			public int Unknown110 { get; set; }
			[TagElement]
			public int Unknown114 { get; set; }
			[TagElement]
			public int Unknown118 { get; set; }
			[TagElement]
			public int Unknown11C { get; set; }
			[TagElement]
			public int Unknown120 { get; set; }
			[TagElement]
			public int Unknown124 { get; set; }
			[TagElement]
			public int Unknown128 { get; set; }
			[TagElement]
			public int Unknown12C { get; set; }
			[TagElement]
			public int Unknown130 { get; set; }
			[TagElement]
			public int Unknown134 { get; set; }
			[TagElement]
			public int Unknown138 { get; set; }
			[TagElement]
			public int Unknown13C { get; set; }
			[TagElement]
			public int Unknown140 { get; set; }
			[TagElement]
			public int Unknown144 { get; set; }
			[TagElement]
			public int Unknown148 { get; set; }
			[TagElement]
			public int Unknown14C { get; set; }
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock19
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
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
		}
	}
}
