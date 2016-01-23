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

namespace HaloOnlineTagTool.Commands.Bitmaps
{
    class ImportCommand : Command
    {
        private readonly OpenTagCache _info;
        private readonly TagInstance _tag;
        private readonly Bitmap _bitmap;

        public ImportCommand(OpenTagCache info, TagInstance tag, Bitmap bitmap) : base(
            CommandFlags.None,

            "import",
            "Import an image from a DDS file",

            "import <image index> <path>",

            "The image index must be in hexadecimal.\n" +
            "No conversion will be done on the data in the DDS file.\n" +
            "The pixel format must be supported by the game.")
        {
            _info = info;
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
                resourceManager.LoadCachesFromDirectory(_info.CacheFile.DirectoryName);
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
                    injector.InjectDds(_info.Serializer, _info.Deserializer, _bitmap, imageIndex, imageStream);
                }
                using (var tagsStream = _info.OpenCacheReadWrite())
                {
                    var tagContext = new TagSerializationContext(tagsStream, _info.Cache, _info.StringIds, _tag);
                    _info.Serializer.Serialize(tagContext, _bitmap);
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
