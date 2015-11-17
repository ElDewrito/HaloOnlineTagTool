using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Bitmaps;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Tags
{
	class ImportBitmapCommand : Command
	{
		private readonly OpenTagCache _info;

		public ImportBitmapCommand(OpenTagCache info) : base(
			CommandFlags.Inherit,

			"importbitmap",
			"Create a new bitmap tag from a DDS file",

			"importbitmap <dds file>",

			"The DDS file will be imported into textures.dat as a new resource.\n" +
			"Make sure to add the new bitmap tag as a dependency if you edit a shader!")
		{
			_info = info;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1)
				return false;
			var imagePath = args[0];

			Console.WriteLine("Loading textures.dat...");
			var resourceManager = new ResourceDataManager();
			resourceManager.LoadCacheFromDirectory(_info.CacheFile.DirectoryName, ResourceLocation.Textures);

			Console.WriteLine("Importing image...");
			var bitmap = new Bitmap
			{
				Flags = Bitmap.RuntimeFlags.UseResource,
				Sequences = new List<Bitmap.Sequence>
				{
					new Bitmap.Sequence
					{
						FirstBitmapIndex = 0,
						BitmapCount = 1
					}
				},
				Images = new List<Bitmap.Image>
				{
					new Bitmap.Image
					{
						Signature = new MagicNumber("bitm").Value,
						Unknown28 = -1,
					}
				},
				Resources = new List<Bitmap.BitmapResource>
				{
					new Bitmap.BitmapResource()
				}
			};
			using (var imageStream = File.OpenRead(imagePath))
			{
				var injector = new BitmapDdsInjector(resourceManager);
				injector.InjectDds(_info.Serializer, _info.Deserializer, bitmap, 0, imageStream);
			}

			Console.WriteLine("Creating a new tag...");
			HaloTag tag;
			using (var tagsStream = _info.OpenCacheReadWrite())
			{
				var tagContext = new TagSerializationContext(tagsStream, _info.Cache);
				_info.Serializer.Serialize(tagContext, bitmap);
				tag = tagContext.Tag;
			}

			Console.WriteLine();
			Console.WriteLine("All done! The new bitmap tag is:");
			TagPrinter.PrintTagShort(tag);
			return true;
		}
	}
}
