using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Resources.Geometry
{
	/// <summary>
	/// Utility class for creating render models from scratch.
	/// </summary>
	public class RenderModelBuilder
	{
		private readonly EngineVersion _version;
		private readonly RenderModel _model = new RenderModel();
		private RenderModel.Region _currentRegion;
		private RenderModel.Region.Permutation _currentPermutation;
		private MeshData _currentMesh;
		private readonly List<MeshData> _meshes = new List<MeshData>();

		/// <summary>
		/// Initializes a new instance of the <see cref="RenderModelBuilder"/> class for a particular engine version.
		/// </summary>
		public RenderModelBuilder(EngineVersion version)
		{
			_version = version;
			_model.Regions = new List<RenderModel.Region>();
			_model.Nodes = new List<RenderModel.Node>();
			_model.RuntimeNodes = new List<RenderModel.RuntimeNode>();
			_model.Materials = new List<RenderModel.Material>();
			_model.Unknown1C = -1; // "Flair Starting Model Section Index" in Assembly
			_model.Geometry = new GeometryReference
			{
				Meshes = new List<Mesh>(),
				Unknown = 7 // TODO: Figure out what this does, if anything
			};
		}

		/// <summary>
		/// Adds a node to the model.
		/// </summary>
		/// <param name="node">The node to add.</param>
		/// <returns>The node index.</returns>
		public byte AddNode(RenderModel.Node node)
		{
			_model.Nodes.Add(node);
			
			// Generate runtime data
			_model.RuntimeNodes.Add(new RenderModel.RuntimeNode
			{
				Translation = node.DefaultTranslation,
				Rotation = node.DefaultRotation,
				Scale = node.DefaultScale,
			});

			return (byte)(_model.Nodes.Count - 1);
		}

		/// <summary>
		/// Adds a material to the model.
		/// </summary>
		/// <param name="material">The material.</param>
		/// <returns>The material index.</returns>
		public short AddMaterial(RenderModel.Material material)
		{
			_model.Materials.Add(material);
			return (short)(_model.Materials.Count - 1);
		}

		/// <summary>
		/// Begins building a new model region.
		/// </summary>
		/// <param name="name">The name stringID.</param>
		/// <exception cref="System.InvalidOperationException">Cannot begin a new region while another is active</exception>
		public void BeginRegion(StringId name)
		{
			if (_currentRegion != null)
				throw new InvalidOperationException("Cannot begin a new region while another is active");

			_currentRegion = new RenderModel.Region
			{
				Name = name,
				Permutations = new List<RenderModel.Region.Permutation>(),
			};
		}

		/// <summary>
		/// Finishes building the current region.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">
		/// Cannot end a region if nothing is active
		/// or
		/// Cannot end a region while a permutation is still active
		/// </exception>
		public void EndRegion()
		{
			if (_currentRegion == null)
				throw new InvalidOperationException("Cannot end a region if nothing is active");
			if (_currentPermutation != null)
				throw new InvalidOperationException("Cannot end a region while a permutation is still active");

			_model.Regions.Add(_currentRegion);
			_currentRegion = null;
		}

		/// <summary>
		/// Begins building a new model permutation in the current region.
		/// </summary>
		/// <param name="name">The name stringID.</param>
		/// <exception cref="System.InvalidOperationException">
		/// Cannot begin a new permutation if a region is not active
		/// or
		/// Cannot begin a new permutation while another is active
		/// </exception>
		public void BeginPermutation(StringId name)
		{
			if (_currentRegion == null)
				throw new InvalidOperationException("Cannot begin a new permutation if a region is not active");
			if (_currentPermutation != null)
				throw new InvalidOperationException("Cannot begin a new permutation while another is active");

			_currentPermutation = new RenderModel.Region.Permutation
			{
				Name = name,
				MeshIndex = (ushort)_meshes.Count,
			};
		}

		/// <summary>
		/// Finishes building the current permutation.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">
		/// Cannot end a permutation if nothing is active
		/// or
		/// Cannot end a permutation while a mesh is still active
		/// or
		/// Cannot end a permutation if no region is active
		/// </exception>
		public void EndPermutation()
		{
			if (_currentPermutation == null)
				throw new InvalidOperationException("Cannot end a permutation if nothing is active");
			if (_currentMesh != null)
				throw new InvalidOperationException("Cannot end a permutation while a mesh is still active");
			if (_currentRegion == null)
				throw new InvalidOperationException("Cannot end a permutation if no region is active");
			
			_currentRegion.Permutations.Add(_currentPermutation);
			_currentPermutation = null;
		}

		/// <summary>
		/// Begins building a new mesh in the current permutation.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">
		/// Cannot begin a new mesh if a permutation is not active
		/// or
		/// Cannot begin a new mesh while another is active
		/// </exception>
		public void BeginMesh()
		{
			if (_currentPermutation == null)
				throw new InvalidOperationException("Cannot begin a new mesh if a permutation is not active");
			if (_currentMesh != null)
				throw new InvalidOperationException("Cannot begin a new mesh while another is active");

			_currentMesh = new MeshData
			{
				Mesh = new Mesh
				{
					Parts = new List<Mesh.Part>(),
					SubParts = new List<Mesh.SubPart>(),
					VertexBuffers = new ushort[8] { 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF },
					IndexBuffers = new ushort[2] { 0xFFFF, 0xFFFF },
					Flags = MeshFlags.None,
					PrtType = PrtType.None,
				},
				VertexFormat = VertexBufferFormat.Invalid,
			};
		}

		/// <summary>
		/// Finishes building the current mesh.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">
		/// Cannot end a mesh if nothing is active
		/// or
		/// Cannot end a mesh if no permutation is active
		/// </exception>
		public void EndMesh()
		{
			if (_currentMesh == null)
				throw new InvalidOperationException("Cannot end a mesh if nothing is active");
			if (_currentPermutation == null)
				throw new InvalidOperationException("Cannot end a mesh if no permutation is active");

			_meshes.Add(_currentMesh);
			_model.Geometry.Meshes.Add(_currentMesh.Mesh);
			_currentPermutation.MeshCount++;
			_currentMesh = null;
		}

		/// <summary>
		/// Binds a rigid vertex buffer to the current mesh.
		/// </summary>
		/// <param name="vertices">The vertices to bind.</param>
		/// <param name="nodeIndex">The node to attach the vertices to.</param>
		/// <exception cref="System.InvalidOperationException">Cannot bind a rigid vertex buffer if no mesh is active</exception>
		public void BindRigidVertexBuffer(IEnumerable<RigidVertex> vertices, byte nodeIndex)
		{
			if (_currentMesh == null)
				throw new InvalidOperationException("Cannot bind a rigid vertex buffer if no mesh is active");

			_currentMesh.UnbindVertices();
			_currentMesh.RigidVertices = vertices.ToArray();
			_currentMesh.VertexFormat = VertexBufferFormat.Rigid;
			_currentMesh.Mesh.Type = VertexType.Rigid;
			_currentMesh.Mesh.RigidNodeIndex = nodeIndex;
		}

		/// <summary>
		/// Binds a skinned vertex buffer to the current mesh.
		/// </summary>
		/// <param name="vertices">The vertices to bind.</param>
		/// <exception cref="System.InvalidOperationException">Cannot bind a skinned vertex buffer if no mesh is active</exception>
		public void BindSkinnedVertexBuffer(IEnumerable<SkinnedVertex> vertices)
		{
			if (_currentMesh == null)
				throw new InvalidOperationException("Cannot bind a skinned vertex buffer if no mesh is active");

			_currentMesh.UnbindVertices();
			_currentMesh.SkinnedVertices = vertices.ToArray();
			_currentMesh.VertexFormat = VertexBufferFormat.Skinned;
			_currentMesh.Mesh.Type = VertexType.Skinned;
		}

		/// <summary>
		/// Binds an index buffer to the current mesh.
		/// </summary>
		/// <param name="indexes">The indexes to bind.</param>
		/// <param name="primitiveType">The primitive type to use.</param>
		/// <exception cref="System.InvalidOperationException">Cannot bind an index buffer if no mesh is active</exception>
		public void BindIndexBuffer(IEnumerable<ushort> indexes, PrimitiveType primitiveType)
		{
			if (_currentMesh == null)
				throw new InvalidOperationException("Cannot bind an index buffer if no mesh is active");

			_currentMesh.Indexes = indexes.ToArray();
			_currentMesh.Mesh.IndexBufferType = primitiveType;
		}

		/// <summary>
		/// Defines a part in the current mesh.
		/// </summary>
		/// <param name="materialIndex">Index of the material.</param>
		/// <param name="firstIndex">The first index.</param>
		/// <param name="indexCount">The index count.</param>
		/// <param name="vertexCount">The vertex count.</param>
		/// <exception cref="System.InvalidOperationException">Cannot define a part if no mesh is active</exception>
		public void DefinePart(short materialIndex, ushort firstIndex, ushort indexCount, ushort vertexCount)
		{
			if (_currentMesh == null)
				throw new InvalidOperationException("Cannot define a part if no mesh is active");

			var part = new Mesh.Part
			{
				MaterialIndex = materialIndex,
				Unknown2 = -1,
				FirstIndex = firstIndex,
				IndexCount = indexCount,
				FirstSubPartIndex = (short)_currentMesh.Mesh.SubParts.Count,
				SubPartCount = 1,
				// TODO: Unknown values here
				VertexCount = vertexCount,
			};

			// It doesn't seem like the game really ever uses subparts for
			// most models, but define one anyway
			var subPart = new Mesh.SubPart
			{
				FirstIndex = firstIndex,
				IndexCount = indexCount,
				PartIndex = (short)_currentMesh.Mesh.Parts.Count,
				VertexCount = vertexCount,
			};

			_currentMesh.Mesh.Parts.Add(part);
			_currentMesh.Mesh.SubParts.Add(subPart);
		}

		/// <summary>
		/// Builds a model tag and resource data.
		/// </summary>
		/// <param name="serializer">The tag serializer to use to serialize the model definition data.</param>
		/// <param name="resourceDataStream">The stream to write resource data to.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">Cannot build a model if a region is active</exception>
		public RenderModel Build(TagSerializer serializer, Stream resourceDataStream)
		{
			if (_currentRegion != null)
				throw new InvalidOperationException("Cannot build a model if a region is active");

			CompressVertices();
			BuildResourceData(serializer, resourceDataStream);
			return _model;
		}

		private void CompressVertices()
		{
			var compressionInfo = BuildCompressionInfo();
			var compressor = new VertexCompressor(compressionInfo);

			// TODO: Refactor how vertices work, this is just ugly

			foreach (var mesh in _meshes)
			{
				if (mesh.RigidVertices != null)
				{
					foreach (var v in mesh.RigidVertices)
					{
						v.Position = compressor.CompressPosition(v.Position);
						v.Texcoord = compressor.CompressUv(v.Texcoord);
					}
				}
				else if (mesh.SkinnedVertices != null)
				{
					foreach (var v in mesh.SkinnedVertices)
					{
						v.Position = compressor.CompressPosition(v.Position);
						v.Texcoord = compressor.CompressUv(v.Texcoord);
					}
				}
			}
		}

		private GeometryCompressionInfo BuildCompressionInfo()
		{
			var result = new GeometryCompressionInfo();
			foreach (var mesh in _meshes)
			{
				// TODO: Refactor how vertices work, this is just ugly

				IEnumerable<Vector4> positions = null;
				IEnumerable<Vector2> texCoords = null;
				if (mesh.RigidVertices != null)
				{
					positions = mesh.RigidVertices.Select(v => v.Position);
					texCoords = mesh.RigidVertices.Select(v => v.Texcoord);
				}
				else if (mesh.SkinnedVertices != null)
				{
					positions = mesh.SkinnedVertices.Select(v => v.Position);
					texCoords = mesh.SkinnedVertices.Select(v => v.Texcoord);
				}

				if (positions != null)
				{
					result.PositionMinX = Math.Min(result.PositionMinX, positions.Min(v => v.X));
					result.PositionMinY = Math.Min(result.PositionMinY, positions.Min(v => v.Y));
					result.PositionMinZ = Math.Min(result.PositionMinZ, positions.Min(v => v.Z));
					result.PositionMaxX = Math.Max(result.PositionMaxX, positions.Max(v => v.X));
					result.PositionMaxY = Math.Max(result.PositionMaxY, positions.Max(v => v.Y));
					result.PositionMaxZ = Math.Max(result.PositionMaxZ, positions.Max(v => v.Z));
				}
				if (texCoords != null)
				{
					result.TextureMinU = Math.Min(result.TextureMinU, texCoords.Min(v => v.X));
					result.TextureMinV = Math.Min(result.TextureMinV, texCoords.Min(v => v.Y));
					result.TextureMaxU = Math.Max(result.TextureMaxU, texCoords.Max(v => v.X));
					result.TextureMaxV = Math.Max(result.TextureMaxV, texCoords.Max(v => v.Y));
				}
			}
			_model.Geometry.Compression = new List<GeometryCompressionInfo> { result };
			return result;
		}

		private void BuildResourceData(TagSerializer serializer, Stream resourceDataStream)
		{
			var definition = new RenderGeometryResourceDefinition();
			definition.VertexBuffers = new List<D3DPointer<VertexBufferDefinition>>();
			definition.IndexBuffers = new List<D3DPointer<IndexBufferDefinition>>();
			foreach (var mesh in _meshes)
			{
				// Serialize the mesh's vertex buffer
				var vertexBufferStart = (int)resourceDataStream.Position;
				var vertexCount = SerializeVertexBuffer(mesh, resourceDataStream);
				var vertexBufferEnd = (int)resourceDataStream.Position;

				// Add a definition for it
				mesh.Mesh.VertexBuffers[0] = (ushort)definition.VertexBuffers.Count;
				definition.VertexBuffers.Add(new D3DPointer<VertexBufferDefinition>
				{
					Definition = new VertexBufferDefinition
					{
						Count = vertexCount,
						Format = mesh.VertexFormat,
						VertexSize = VertexSizes[mesh.VertexFormat],
						Data = new ResourceDataReference(vertexBufferEnd - vertexBufferStart, new ResourceAddress(ResourceAddressType.Resource, vertexBufferStart)),
					},
				});

				// Serialize the mesh's index buffer
				var indexBufferStart = vertexBufferEnd;
				SerializeIndexBuffer(mesh, resourceDataStream);
				var indexBufferEnd = (int)resourceDataStream.Position;

				// Add a definition for it
				mesh.Mesh.IndexBuffers[0] = (ushort)definition.IndexBuffers.Count;
				definition.IndexBuffers.Add(new D3DPointer<IndexBufferDefinition>
				{
					Definition = new IndexBufferDefinition
					{
						Type = mesh.Mesh.IndexBufferType,
						Data = new ResourceDataReference(indexBufferEnd - indexBufferStart, new ResourceAddress(ResourceAddressType.Resource, indexBufferStart)),
					},
				});
			}
			SerializeDefinitionData(serializer, definition);
		}

		private void SerializeDefinitionData(TagSerializer serializer, RenderGeometryResourceDefinition definition)
		{
			_model.Geometry.Resource = new ResourceReference
			{
				Type = 5, // FIXME: hax
				DefinitionFixups = new List<ResourceDefinitionFixup>(),
				D3DObjectFixups = new List<D3DObjectFixup>(),
				Unknown68 = 1,
			};
			var context = new ResourceSerializationContext(_model.Geometry.Resource);
			serializer.Serialize(context, definition);
		}

		private int SerializeVertexBuffer(MeshData mesh, Stream outStream)
		{
			var vertexStream = VertexStreamFactory.Create(_version, outStream);
			if (mesh.RigidVertices != null)
			{
				foreach (var v in mesh.RigidVertices)
					vertexStream.WriteRigidVertex(v);
				return mesh.RigidVertices.Length;
			}
			if (mesh.SkinnedVertices != null)
			{
				foreach (var v in mesh.SkinnedVertices)
					vertexStream.WriteSkinnedVertex(v);
				return mesh.SkinnedVertices.Length;
			}
			return 0;
		}

		private static void SerializeIndexBuffer(MeshData mesh, Stream outStream)
		{
			var indexStream = new IndexBufferStream(outStream, IndexBufferFormat.UInt16);
			foreach (var index in mesh.Indexes)
				indexStream.WriteIndex(index);
			StreamUtil.Align(outStream, 4);
		}

		private class MeshData
		{
			public Mesh Mesh { get; set; }

			public VertexBufferFormat VertexFormat { get; set; }

			public RigidVertex[] RigidVertices { get; set; }

			public SkinnedVertex[] SkinnedVertices { get; set; }

			public ushort[] Indexes { get; set; }

			public void UnbindVertices()
			{
				VertexFormat = VertexBufferFormat.Invalid;
				RigidVertices = null;
				SkinnedVertices = null;
			}
		}

		// Maps vertex buffer formats to their corresponding vertex sizes.
		private static readonly Dictionary<VertexBufferFormat, short> VertexSizes = new Dictionary<VertexBufferFormat, short>
		{
			{ VertexBufferFormat.Invalid, 0 },
			{ VertexBufferFormat.World, 0x38 },
			{ VertexBufferFormat.Rigid, 0x38 },
			{ VertexBufferFormat.Skinned, 0x40 },
			{ VertexBufferFormat.Unknown4, 0x8 },
			{ VertexBufferFormat.Unknown5, 0x4 },
			{ VertexBufferFormat.Unknown6, 0x14 },
			{ VertexBufferFormat.Unknown7, 0x14 },
			{ VertexBufferFormat.Unused8, 0 },
			{ VertexBufferFormat.AmbientPrt, 0x4 },
			{ VertexBufferFormat.LinearPrt, 0x4 },
			{ VertexBufferFormat.QuadraticPrt, 0x24 },
			{ VertexBufferFormat.UnknownC, 0x14 },
			{ VertexBufferFormat.UnknownD, 0x10 },
			{ VertexBufferFormat.UnknownE, 0xC },
			{ VertexBufferFormat.UnknownF, 0x18 },
			{ VertexBufferFormat.Unused10, 0 },
			{ VertexBufferFormat.Unused11, 0 },
			{ VertexBufferFormat.Unused12, 0 },
			{ VertexBufferFormat.Unused13, 0 },
			{ VertexBufferFormat.Unknown14, 0x8 },
			{ VertexBufferFormat.Unknown15, 0x4 },
			{ VertexBufferFormat.Unknown16, 0x4 },
			{ VertexBufferFormat.Unknown17, 0x4 },
			{ VertexBufferFormat.Unknown18, 0x20 },
			{ VertexBufferFormat.Unknown19, 0x20 },
			{ VertexBufferFormat.Unknown1A, 0xC },
			{ VertexBufferFormat.Unknown1B, 0x24 },
			{ VertexBufferFormat.Unknown1C, 0x80 },
			{ VertexBufferFormat.Unused1D, 0 },
		};
	}
}
