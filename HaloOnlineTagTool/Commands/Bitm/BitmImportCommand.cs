using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Bitmaps;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Bitm
{
	class BitmImportCommand : Command
	{
		private readonly FileInfo _fileInfo;
		private readonly TagCache _cache;
		private readonly HaloTag _tag;
		private readonly Bitmap _bitmap;

		public BitmImportCommand(FileInfo fileInfo, TagCache cache, HaloTag tag, Bitmap bitmap) : base(
			CommandFlags.None,

			"import",
			"Import an image from a DDS file",

			"import <image index> <path>",

			"The image index must be in hexadecimal.\n" +
			"No conversion will be done on the data in the DDS file.\n" +
			"The pixel format must be supported by the game.")
		{
			_fileInfo = fileInfo;
			_cache = cache;
			_tag = tag;
			_bitmap = bitmap;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 2)
				return false;
			int imageIndex;
			if (!int.TryParse(args[0], NumberStyles.HexNumber, null, out imageIndex))
				return false;
			if (imageIndex < 0 || imageIndex >= _bitmap.Images.Count)
			{
				Console.Error.WriteLine("Invalid image index.");
				return true;
			}
			var imagePath = args[1];

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
			Console.WriteLine("Importing image data...");
			try
			{
				using (var imageStream = File.OpenRead(imagePath))
				{
					var injector = new BitmapDdsInjector(resourceManager);
					injector.InjectDds(_bitmap, imageIndex, imageStream);
				}
				using (var tagsStream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				{
					var tagContext = new TagSerializationContext(tagsStream, _cache, _tag);
					TagSerializer.Serialize(tagContext, _bitmap);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Importing image data failed: " + ex.Message);
				return true;
			}
			Console.WriteLine("Done!");
			return true;
		}
	}
}
