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
    public class BitmapDdsExtractor
    {
        private readonly ResourceDataManager _resourceManager;

        public BitmapDdsExtractor(ResourceDataManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void ExtractDds(TagDeserializer deserializer, Bitmap bitmap, int imageIndex, Stream outStream)
        {
            // TODO: Make sure 3D textures and cube maps work

            // Deserialize the resource definition and verify it
            var resource = bitmap.Resources[imageIndex];
            var resourceContext = new ResourceSerializationContext(resource.Resource);
            var definition = deserializer.Deserialize<BitmapTextureResourceDefinition>(resourceContext);
            if (definition.Texture == null || definition.Texture.Definition == null)
                throw new ArgumentException("Invalid bitmap definition");
            var dataReference = definition.Texture.Definition.Data;
            if (dataReference.Address.Type != ResourceAddressType.Resource)
                throw new InvalidOperationException("Invalid resource data address");

            var header = CreateDdsHeader(definition);
            var resourceDataStream = new MemoryStream();
            _resourceManager.Extract(resource.Resource, resourceDataStream);
            header.WriteTo(outStream);
            resourceDataStream.Position = dataReference.Address.Offset;
            StreamUtil.Copy(resourceDataStream, outStream, dataReference.Size);
        }

        private static DdsHeader CreateDdsHeader(BitmapTextureResourceDefinition definition)
        {
            var info = definition.Texture.Definition;
            var result = new DdsHeader
            {
                Width = (uint)info.Width,
                Height = (uint)info.Height,
                MipMapCount = (uint)info.Levels
            };
            BitmapDdsFormatDetection.SetUpHeaderForFormat(info.Format, result);
            switch (info.Type)
            {
                case BitmapType.CubeMap:
                    result.SurfaceComplexityFlags = DdsSurfaceComplexityFlags.Complex;
                    result.SurfaceInfoFlags = DdsSurfaceInfoFlags.CubeMap | DdsSurfaceInfoFlags.CubeMapNegativeX |
                                              DdsSurfaceInfoFlags.CubeMapNegativeY | DdsSurfaceInfoFlags.CubeMapNegativeZ |
                                              DdsSurfaceInfoFlags.CubeMapPositiveX | DdsSurfaceInfoFlags.CubeMapPositiveY |
                                              DdsSurfaceInfoFlags.CubeMapPositiveZ;
                    break;
                case BitmapType.Texture3D:
                    result.Depth = (uint)info.Depth;
                    result.SurfaceInfoFlags = DdsSurfaceInfoFlags.Volume;
                    break;
            }
            const string dew = "Doritos(TM) Dew(TM) it right!";
            Encoding.ASCII.GetBytes(dew, 0, dew.Length, result.Reserved, 0);
            return result;
        }    
    }
}
