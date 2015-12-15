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
            var resource = bitmap.Resources[imageIndex].Resource;
            var newResource = (resource == null);
            ResourceSerializationContext resourceContext;
            BitmapTextureResourceDefinition definition;
            if (newResource)
            {
                // Create a new resource reference
                resource = new ResourceReference
                {
                    DefinitionFixups = new List<ResourceDefinitionFixup>(),
                    D3DObjectFixups = new List<D3DObjectFixup>(),
                    Type = 1, // TODO: Map out this type enum instead of using numbers
                    Unknown68 = 1
                };
                bitmap.Resources[imageIndex].Resource = resource;
                resourceContext = new ResourceSerializationContext(resource);
                definition = new BitmapTextureResourceDefinition
                {
                    Texture = new D3DPointer<BitmapTextureResourceDefinition.BitmapDefinition>
                    {
                        Definition = new BitmapTextureResourceDefinition.BitmapDefinition()
                    }
                };
            }
            else
            {
                // Deserialize the old definition
                resourceContext = new ResourceSerializationContext(resource);
                definition = deserializer.Deserialize<BitmapTextureResourceDefinition>(resourceContext);
            }
            if (definition.Texture == null || definition.Texture.Definition == null)
                throw new ArgumentException("Invalid bitmap definition");
            var texture = definition.Texture.Definition;
            var imageData = bitmap.Images[imageIndex];

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
            switch (texture.Format)
            {
                case BitmapFormat.Dxt1:
                case BitmapFormat.Dxt3:
                case BitmapFormat.Dxt5:
                case BitmapFormat.Dxn:
                    texture.Flags = BitmapFlags.Compressed;
                    break;
                default:
                    texture.Flags = BitmapFlags.None;
                    break;
            }
            if ((texture.Width & (texture.Width - 1)) == 0 && (texture.Height & (texture.Height - 1)) == 0)
                texture.Flags |= BitmapFlags.PowerOfTwoDimensions;

            // If creating a new image, then add a new resource, otherwise replace the existing one
            if (newResource)
                _resourceManager.Add(resource, ResourceLocation.Textures, ddsStream);
            else
                _resourceManager.Replace(resource, ddsStream);

            // Serialize the new resource definition
            serializer.Serialize(resourceContext, definition);

            // Modify the image data in the bitmap tag to match the definition
            imageData.Width = texture.Width;
            imageData.Height = texture.Height;
            imageData.Depth = texture.Depth;
            imageData.Type = texture.Type;
            imageData.Format = texture.Format;
            imageData.Flags = texture.Flags;
            imageData.MipmapCount = (sbyte)(texture.Levels - 1);
            imageData.DataOffset = texture.Data.Address.Offset;
            imageData.DataSize = texture.Data.Size;
            imageData.Unknown15 = texture.Unknown35;
        }
    }
}
