using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Bitmaps;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Tags
{
    class ExtractBitmapsCommand : Command
    {
        private readonly OpenTagCache _info;

        public ExtractBitmapsCommand(OpenTagCache info) : base(
            CommandFlags.Inherit,

            "extractbitmaps",
            "Extract all bitmaps to a folder",

            "extractbitmaps <folder>",

            "Extract all bitmap tags and any subimages to the given folder.\n" +
            "If the folder does not exist, it will be created.")
        {
            _info = info;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            var outDir = args[0];
            Directory.CreateDirectory(outDir);

            Console.WriteLine("Loading resource caches...");
            var resourceManager = new ResourceDataManager();
            try
            {
                resourceManager.LoadCachesFromDirectory(_info.CacheFile.DirectoryName);
            }
            catch
            {
                Console.WriteLine("Unable to load the resource .dat files.");
                Console.WriteLine("Make sure that they all exist and are valid.");
                return true;
            }

            var extractor = new BitmapDdsExtractor(resourceManager);
            var count = 0;
            using (var tagsStream = _info.OpenCacheRead())
            {
                foreach (var tag in _info.Cache.Tags.FindAllInGroup("bitm"))
                {
                    Console.Write("Extracting ");
                    TagPrinter.PrintTagShort(tag);

                    try
                    {
                        var tagContext = new TagSerializationContext(tagsStream, _info.Cache, _info.StringIds, tag);
                        var bitmap = _info.Deserializer.Deserialize<TagStructures.Bitmap>(tagContext);
                        var ddsOutDir = outDir;
                        if (bitmap.Images.Count > 1)
                        {
                            ddsOutDir = Path.Combine(outDir, tag.Index.ToString("X8"));
                            Directory.CreateDirectory(ddsOutDir);
                        }
                        for (var i = 0; i < bitmap.Images.Count; i++)
                        {
                            var outPath = Path.Combine(ddsOutDir,
                                ((bitmap.Images.Count > 1) ? i.ToString() : tag.Index.ToString("X8")) + ".dds");
                            using (var outStream = File.Open(outPath, FileMode.Create, FileAccess.Write))
                            {
                                extractor.ExtractDds(_info.Deserializer, bitmap, i, outStream);
                            }
                        }
                        count++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: Failed to extract bitmap: " + ex.Message);
                    }
                }
            }
            Console.WriteLine("Extracted {0} bitmaps.", count);
            return true;
        }
    }
}
