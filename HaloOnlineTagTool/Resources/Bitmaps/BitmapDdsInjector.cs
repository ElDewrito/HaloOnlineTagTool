using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Resources.Bitmaps
{
	public class BitmapDdsInjector
	{
		private readonly ResourceDataManager _resourceManager;

		public BitmapDdsInjector(ResourceDataManager resourceManager)
		{
			_resourceManager = resourceManager;
		}

		public void InjectDds(TagSerializer serializer, TagDeserializer deserializer, Bitmap bitmap, int imageIndex, Stream ddsStream)
		{
			// Deserialize the old definition
			var resourceContext = new ResourceSerializationContext(bitmap.Resources[imageIndex].Resource);
			var definition = deserializer.Deserialize<BitmapTextureResourceDefinition>(resourceContext);
			if (definition.Texture == null || definition.Texture.Definition == null)
				throw new ArgumentException("Invalid bitmap definition");
			var texture = definition.Texture.Definition;

			// Read the DDS header and modify the definition to match
			var dds = DdsHeader.Read(ddsStream);
			var dataSize = (int)(ddsStream.Length - ddsStream.Position);
			texture.Data = new ResourceDataReference(dataSize, new ResourceAddress(ResourceAddressType.Resource, 0));
			texture.Width = (short)dds.Width;
			texture.Height = (short)dds.Height;
			texture.Depth = (sbyte)Math.Max(1, dds.Depth);
			texture.Levels = (sbyte)Math.Max(1, dds.MipMapCount);
			texture.Type = BitmapDdsFormatDetection.DetectType(dds);
			texture.D3DFormatUnused = (int)((dds.D3D10Format != DxgiFormat.Bc5UNorm) ? dds.FourCc : DdsFourCc.FromString("ATI2"));
			texture.Format = BitmapDdsFormatDetection.DetectFormat(dds);

			// Set flags based on the format
			switch (definition.Texture.Definition.Format)
			{
				case BitmapFormat.Dxt1:
				case BitmapFormat.Dxt3:
				case BitmapFormat.Dxt5:
				case BitmapFormat.Dxn:
					definition.Texture.Definition.Flags = BitmapFlags.Compressed;
					break;
				default:
					definition.Texture.Definition.Flags = BitmapFlags.None;
					break;
			}

			// Inject the resource data
			_resourceManager.Replace(bitmap.Resources[imageIndex].Resource, ddsStream);

			// Serialize the new resource definition
			serializer.Serialize(resourceContext, definition);

			// Modify the image data in the bitmap tag to match the definition
			var imageData = bitmap.Images[imageIndex];
			imageData.Width = texture.Width;
			imageData.Height = texture.Height;
			imageData.Depth = texture.Depth;
			imageData.Type = texture.Type;
			imageData.Format = texture.Format;
			imageData.Flags = texture.Flags;
			imageData.MipmapCount = (sbyte)(texture.Levels - 1);
			imageData.DataOffset = texture.Data.Address.Offset;
			imageData.DataSize = texture.Data.Size;
		}
	}
}
