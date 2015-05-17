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
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public ExtractBitmapsCommand(TagCache cache, FileInfo fileInfo) : base(
			CommandFlags.Inherit,

			"extractbitmaps",
			"Extract all bitmaps to a folder",

			"extractbitmaps <folder>",

			"Extract all bitmap tags and any subimages to the given folder.\n" +
			"If the folder does not exist, it will be created.")
		{
			_cache = cache;
			_fileInfo = fileInfo;
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
				resourceManager.LoadCachesFromDirectory(_fileInfo.DirectoryName);
			}
			catch
			{
				Console.Error.WriteLine("Unable to load the resource .dat files.");
				Console.Error.WriteLine("Make sure that they all exist and are valid.");
				return true;
			}

			var extractor = new BitmapDdsExtractor(resourceManager);
			var count = 0;
			using (var tagsStream = _fileInfo.OpenRead())
			{
				foreach (var tag in _cache.Tags.FindAllByClass("bitm"))
				{
					Console.Write("Extracting ");
					TagPrinter.PrintTagShort(tag);

					try
					{
						var tagContext = new TagSerializationContext(tagsStream, _cache, tag);
						var bitmap = TagDeserializer.Deserialize<Bitmap>(tagContext);
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
								extractor.ExtractDds(bitmap.Resources[i], outStream);
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
