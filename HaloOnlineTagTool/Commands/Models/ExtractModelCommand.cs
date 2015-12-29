using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Models
{
    class ExtractModelCommand : Command
    {
        private OpenTagCache Info { get; }
        private Model Definition { get; }

        public ExtractModelCommand(OpenTagCache info, Model model) : base(
            CommandFlags.Inherit,

            "extractmodel",
            "Extracts a render model from the current model definition.",

            "extractmodel <variant> <filetype> <filename>",

            "Extracts a variant of the render model to a file.\n" +
            "Use the \"listvariants\" command to list available variants.\n" +
            "If the model does not have any variants, just use \"default\"." +
            "\n" +
            "Supported file types: obj")
        {
            Info = info;
            Definition = model;
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
            if (Definition.RenderModel == null)
            {
                Console.WriteLine("The model does not have a render model associated with it.");
                return true;
            }
            var variant = Definition.Variants.FirstOrDefault(v => (Info.StringIds.GetString(v.Name) ?? v.Name.ToString()) == variantName);
            if (variant == null && Definition.Variants.Count > 0)
            {
                Console.WriteLine("Unable to find variant \"{0}\"", variantName);
                Console.WriteLine("Use \"listvariants\" to list available variants.");
                return true;
            }

            // Load resource caches
            Console.WriteLine("Loading resource caches...");
            var resourceManager = new ResourceDataManager();
            try
            {
                resourceManager.LoadCachesFromDirectory(Info.CacheFile.DirectoryName);
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
            using (var cacheStream = Info.CacheFile.OpenRead())
            {
                var renderModelContext = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, Definition.RenderModel);
                renderModel = Info.Deserializer.Deserialize<RenderModel>(renderModelContext);
            }
            if (renderModel.Geometry.Resource == null)
            {
                Console.WriteLine("Render model does not have a resource associated with it");
                return true;
            }
            
            // Deserialize the resource definition
            var resourceContext = new ResourceSerializationContext(renderModel.Geometry.Resource);
            var definition = Info.Deserializer.Deserialize<RenderGeometryResourceDefinition>(resourceContext);

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
                            var regionName = Info.StringIds.GetString(region.Name) ?? region.Name.ToString();
                            var permutationName = Info.StringIds.GetString(permutation.Name) ?? permutation.Name.ToString();
                            Console.WriteLine("Extracting {0} mesh(es) for {1}:{2}...", meshCount, regionName, permutationName);
                            for (var i = 0; i < meshCount; i++)
                            {
                                // Create a MeshReader for the mesh and pass it to the obj extractor
                                var meshReader = new MeshReader(Info.Version, renderModel.Geometry.Meshes[meshIndex + i], definition);
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
                            var meshReader = new MeshReader(Info.Version, mesh, definition);
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
