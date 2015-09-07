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
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;
		private readonly StringIdCache _stringIds;

		public ModelTestCommand(TagCache cache, FileInfo fileInfo, StringIdCache stringIds) : base(
			CommandFlags.Inherit,

			"modeltest",
			"Model injection test",

			"modeltest <model file>",

			"Injects the model over the traffic cone.\n" +
			"The model must only have a single material and no nodes.")
		{
			_cache = cache;
			_fileInfo = fileInfo;
			_stringIds = stringIds;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1)
				return false;

			var builder = new RenderModelBuilder();

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

			// Add a material
			var material = builder.AddMaterial(new RenderModel.Material
			{
				RenderMethod = _cache.Tags[0x101F],
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

				if (model.MeshCount != 1)
				{
					Console.Error.WriteLine("Only models with one mesh are supported");
					return true;
				}

				Console.WriteLine("Assembling vertices...");

				// Build mesh data from the assimp data
				foreach (var mesh in model.Meshes)
				{
					builder.BeginMesh();

					// Build the vertex buffer
					var vertices = new List<RigidVertex>();
					for (var i = 0; i < mesh.VertexCount; i++)
					{
						var position = mesh.Vertices[i];
						var normal = mesh.Normals[i];
						var uv = mesh.TextureCoordinateChannels[0][i];
						var tangent = mesh.Tangents[i];
						var bitangent = mesh.BiTangents[i];
						vertices.Add(new RigidVertex
						{
							Position = new Vector3(position.X, position.Y, position.Z),
							Normal = new Vector3(normal.X, normal.Y, normal.Z),
							Texcoord = new Vector2(uv.X, uv.Y),
							Tangent = new Vector3(tangent.X, tangent.Y, tangent.Z),
							Binormal = new Vector3(bitangent.X, bitangent.Y, bitangent.Z),
						});
					}
					builder.BindRigidVertexBuffer(vertices, node);

					// Build the index buffer
					var indices = mesh.GetIndices();
					builder.BindIndexBuffer(indices.Select(i => (ushort)i), PrimitiveType.TriangleList);
					builder.DefinePart(material, 0, (ushort)indices.Length, (ushort)mesh.VertexCount);

					builder.EndMesh();
				}
			}

			builder.EndPermutation();
			builder.EndRegion();

			Console.WriteLine("Building Blam mesh data...");

			var resourceStream = new MemoryStream();
			var renderModel = builder.Build(resourceStream);

			Console.WriteLine("Writing resource data...");

			// Add a new resource for the model data
			var resources = new ResourceDataManager();
			resources.LoadCachesFromDirectory(_fileInfo.DirectoryName);
			resourceStream.Position = 0;
			resources.Add(renderModel.Resource, ResourceLocation.Resources, resourceStream);

			Console.WriteLine("Writing tag data...");

			using (var cacheStream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
			{
				// Correct the resource owner
				var tag = _cache.Tags[0x3317];
				renderModel.Resource.Owner = tag;

				var context = new TagSerializationContext(cacheStream, _cache, tag);
				TagSerializer.Serialize(context, renderModel);
			}
			Console.WriteLine("Model imported successfully!");
			return true;
		}
	}
}
