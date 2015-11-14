using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Hlmt
{
	class HlmtExtractModeCommand : Command
	{
		private readonly OpenTagCache _info;
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;
		private readonly StringIdCache _stringIds;
		private readonly Model _model;

		public HlmtExtractModeCommand(OpenTagCache info, Model model) : base(
			CommandFlags.Inherit,

			"extractmode",
			"Extract the render model",

			"extractmode <variant> <filetype> <filename>",

			"Extracts a variant of the render model to a file.\n" +
			"Use the \"listvariants\" command to list available variants.\n" +
			"If the model does not have any variants, just use \"default\"." +
			"\n" +
			"Supported file types: obj")
		{
			_info = info;
			_cache = info.Cache;
			_fileInfo = info.CacheFile;
			_stringIds = info.StringIds;
			_model = model;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 3)
				return false;
			var variantName = args[0];
			var fileType = args[1];
			var fileName = args[2];
			if (fileType != "obj")
				return false;

			// Find the variant to extract
			if (_model.RenderModel == null)
			{
				Console.Error.WriteLine("The model does not have a render model associated with it.");
				return true;
			}
			var variant = _model.Variants.FirstOrDefault(v => (_stringIds.GetString(v.Name) ?? v.Name.ToString()) == variantName);
			if (variant == null && _model.Variants.Count > 0)
			{
				Console.Error.WriteLine("Unable to find variant \"{0}\"", variantName);
				Console.Error.WriteLine("Use \"listvariants\" to list available variants.");
				return true;
			}

			// Load resource caches
			Console.WriteLine("Loading resource caches...");
			var resourceManager = new ResourceDataManager();
			try
			{
				resourceManager.LoadCachesFromDirectory(_fileInfo.DirectoryName);
			}
			catch
			{
				Console.WriteLine("Unable to load the resource .dat files.");
				Console.WriteLine("Make sure that they all exist and are valid.");
				return true;
			}

			// Deserialize the render model tag
			Console.WriteLine("Reading model data...");
			RenderModel renderModel;
			using (var cacheStream = _fileInfo.OpenRead())
			{
				var renderModelContext = new TagSerializationContext(cacheStream, _cache, _model.RenderModel);
				renderModel = _info.Deserializer.Deserialize<RenderModel>(renderModelContext);
			}
			if (renderModel.Geometry.Resource == null)
			{
				Console.Error.WriteLine("Render model does not have a resource associated with it");
				return true;
			}
			
			// Deserialize the resource definition
			var resourceContext = new ResourceSerializationContext(renderModel.Geometry.Resource);
			var definition = _info.Deserializer.Deserialize<RenderGeometryResourceDefinition>(resourceContext);

			using (var resourceStream = new MemoryStream())
			{
				// Extract the resource data
				resourceManager.Extract(renderModel.Geometry.Resource, resourceStream);
				using (var objFile = new StreamWriter(File.Open(fileName, FileMode.Create, FileAccess.Write)))
				{
					var objExtractor = new ObjExtractor(objFile);
					var vertexCompressor = new VertexCompressor(renderModel.Geometry.Compression[0]); // Create a (de)compressor from the first compression block
					if (variant != null)
					{
						// Extract each region in the variant
						foreach (var region in variant.Regions)
						{
							// Get the corresonding region in the render model tag
							if (region.RenderModelRegionIndex >= renderModel.Regions.Count)
								continue;
							var renderModelRegion = renderModel.Regions[region.RenderModelRegionIndex];

							// Get the corresponding permutation in the render model tag
							// (Just extract the first permutation for now)
							if (region.Permutations.Count == 0)
								continue;
							var permutation = region.Permutations[0];
							if (permutation.RenderModelPermutationIndex >= renderModelRegion.Permutations.Count)
								continue;
							var renderModelPermutation = renderModelRegion.Permutations[permutation.RenderModelPermutationIndex];

							// Extract each mesh in the permutation
							var meshIndex = renderModelPermutation.MeshIndex;
							var meshCount = renderModelPermutation.MeshCount;
							var regionName = _stringIds.GetString(region.Name) ?? region.Name.ToString();
							var permutationName = _stringIds.GetString(permutation.Name) ?? permutation.Name.ToString();
							Console.WriteLine("Extracting {0} mesh(es) for {1}:{2}...", meshCount, regionName, permutationName);
							for (var i = 0; i < meshCount; i++)
							{
								// Create a MeshReader for the mesh and pass it to the obj extractor
								var meshReader = new MeshReader(_info.Version, renderModel.Geometry.Meshes[meshIndex + i], definition);
								objExtractor.ExtractMesh(meshReader, vertexCompressor, resourceStream);
							}
						}
					}
					else
					{
						// No variant - just extract every mesh
						Console.WriteLine("Extracting {0} mesh(es)...", renderModel.Geometry.Meshes.Count);
						foreach (var mesh in renderModel.Geometry.Meshes)
						{
							// Create a MeshReader for the mesh and pass it to the obj extractor
							var meshReader = new MeshReader(_info.Version, mesh, definition);
							objExtractor.ExtractMesh(meshReader, vertexCompressor, resourceStream);
						}
					}
					objExtractor.Finish();
				}
			}
			Console.WriteLine("Done!");
			return true;
		}
	}
}
