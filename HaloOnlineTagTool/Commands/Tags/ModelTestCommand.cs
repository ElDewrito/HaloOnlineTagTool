using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assimp;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;
using PrimitiveType = HaloOnlineTagTool.Resources.Geometry.PrimitiveType;

namespace HaloOnlineTagTool.Commands.Tags
{
	class ModelTestCommand : Command
	{
		private readonly OpenTagCache _info;
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;
		private readonly StringIdCache _stringIds;

		public ModelTestCommand(OpenTagCache info) : base(
			CommandFlags.Inherit,

			"modeltest",
			"Model injection test",

			"modeltest <model file>",

			"Injects the model over the traffic cone.\n" +
			"The model must only have a single material and no nodes.")
		{
			_info = info;
			_cache = info.Cache;
			_fileInfo = info.CacheFile;
			_stringIds = info.StringIds;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1)
				return false;

			var builder = new RenderModelBuilder(_info.Version);

			// Add a root node
			var node = builder.AddNode(new RenderModel.Node
			{
				Name = _stringIds.GetStringId("street_cone"),
				ParentNode = -1,
				FirstChildNode = -1,
				NextSiblingNode = -1,
				DefaultRotation = new Vector4(0, 0, 0, -1),
				DefaultScale = 1,
				InverseForward = new Vector3(1, 0, 0),
				InverseLeft = new Vector3(0, 1, 0),
				InverseUp = new Vector3(0, 0, 1),
			});

			// Begin building the default region and permutation
			builder.BeginRegion(_stringIds.GetStringId("default"));
			builder.BeginPermutation(_stringIds.GetStringId("default"));

			using (var importer = new AssimpContext())
			{
				Scene model;
				using (var logStream = new LogStream((msg, userData) => Console.WriteLine(msg)))
				{
					logStream.Attach();
					model = importer.ImportFile(args[0],
						PostProcessSteps.CalculateTangentSpace |
						PostProcessSteps.GenerateNormals |
						PostProcessSteps.JoinIdenticalVertices |
						PostProcessSteps.SortByPrimitiveType |
						PostProcessSteps.PreTransformVertices |
						PostProcessSteps.Triangulate);
					logStream.Detach();
				}

				Console.WriteLine("Assembling vertices...");

				// Build a multipart mesh from the model data,
				// with each model mesh mapping to a part of one large mesh and having its own material
				builder.BeginMesh();
				ushort partStartVertex = 0;
				ushort partStartIndex = 0;
				var vertices = new List<RigidVertex>();
				var indices = new List<ushort>();
				foreach (var mesh in model.Meshes)
				{
					for (var i = 0; i < mesh.VertexCount; i++)
					{
						var position = mesh.Vertices[i];
						var normal = mesh.Normals[i];
						var uv = mesh.TextureCoordinateChannels[0][i];
						var tangent = mesh.Tangents[i];
						var bitangent = mesh.BiTangents[i];
						vertices.Add(new RigidVertex
						{
							Position = new Vector4(position.X, position.Y, position.Z, 1),
							Normal = new Vector3(normal.X, normal.Y, normal.Z),
							Texcoord = new Vector2(uv.X, uv.Y),
							Tangent = new Vector4(tangent.X, tangent.Y, tangent.Z, 1),
							Binormal = new Vector3(bitangent.X, bitangent.Y, bitangent.Z),
						});
					}

					// Build the index buffer
					var meshIndices = mesh.GetIndices();
					indices.AddRange(meshIndices.Select(i => (ushort)(i + partStartVertex)));

					// Define a material and part for this mesh
					var material = builder.AddMaterial(new RenderModel.Material
					{
						RenderMethod = _cache.Tags[0x101F],
					});
					builder.DefinePart(material, partStartIndex, (ushort)meshIndices.Length, (ushort)mesh.VertexCount);

					// Move to the next part
					partStartVertex += (ushort)mesh.VertexCount;
					partStartIndex += (ushort)meshIndices.Length;
				}

				// Bind the vertex and index buffers
				builder.BindRigidVertexBuffer(vertices, node);
				builder.BindIndexBuffer(indices, PrimitiveType.TriangleList);
				builder.EndMesh();
			}

			builder.EndPermutation();
			builder.EndRegion();

			Console.WriteLine("Building Blam mesh data...");

			var resourceStream = new MemoryStream();
			var renderModel = builder.Build(_info.Serializer, resourceStream);

			Console.WriteLine("Writing resource data...");

			// Add a new resource for the model data
			var resources = new ResourceDataManager();
			resources.LoadCachesFromDirectory(_fileInfo.DirectoryName);
			resourceStream.Position = 0;
			resources.Add(renderModel.Geometry.Resource, ResourceLocation.Resources, resourceStream);

			Console.WriteLine("Writing tag data...");

			using (var cacheStream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
			{
				var tag = _cache.Tags[0x3317];
				var context = new TagSerializationContext(cacheStream, _cache, tag);
				_info.Serializer.Serialize(context, renderModel);
			}
			Console.WriteLine("Model imported successfully!");
			return true;
		}
	}
}
