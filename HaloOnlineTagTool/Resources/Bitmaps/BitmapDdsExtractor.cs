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

		public void ExtractDds(Bitmap.BitmapResource resource, Stream outStream)
		{
			// TODO: Make sure 3D textures and cube maps work

			// Deserialize the resource definition and verify it
			var resourceContext = new ResourceSerializationContext(resource.Resource);
			var definition = TagDeserializer.Deserialize<BitmapTextureResourceDefinition>(resourceContext);
			if (definition.Texture == null || definition.Texture.Buffer == null)
				throw new ArgumentException("Invalid bitmap definition");
			var dataReference = definition.Texture.Buffer.Data;
			if (dataReference.Address.Type != ResourceAddressType.Resource)
				throw new InvalidOperationException("Invalid resource data address");

			var header = CreateDdsHeader(definition);
			var resourceDataStream = new MemoryStream();
			_resourceManager.Extract(resource.Resource, resourceDataStream);
			header.WriteTo(outStream);
			resourceDataStream.Position = dataReference.Address.Offset;
			StreamUtil.Copy(resourceDataStream, outStream, dataReference.Size);
		}

		private DdsHeader CreateDdsHeader(BitmapTextureResourceDefinition definition)
		{
			// Make sure a format definition exists for the bitmap format
			var info = definition.Texture.Buffer;
			BitmapFormatDefinition formatDefinition;
			if (!FormatDefinitions.TryGetValue(info.Format, out formatDefinition))
				throw new InvalidOperationException("Unsupported bitmap format: " + info.Format);

			var result = new DdsHeader
			{
				Width = (uint)info.Width,
				Height = (uint)info.Height,
				FormatType = formatDefinition.FormatType,
				BitsPerPixel = formatDefinition.BitsPerPixel,
				RBitMask = formatDefinition.RBitMask,
				GBitMask = formatDefinition.GBitMask,
				BBitMask = formatDefinition.BBitMask,
				ABitMask = formatDefinition.ABitMask,
				FourCc = formatDefinition.FourCc,
				D3D10Format = formatDefinition.D3D10Format,
				MipMapCount = (uint)info.Levels
			};
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

		private class BitmapFormatDefinition
		{
			public DdsFormatType FormatType { get; set; }

			public uint BitsPerPixel { get; set; }

			public uint RBitMask { get; set; }

			public uint GBitMask { get; set; }

			public uint BBitMask { get; set; }

			public uint ABitMask { get; set; }

			public uint FourCc { get; set; }

			public DxgiFormat D3D10Format { get; set; }
		}

		private static readonly Dictionary<BitmapFormat, BitmapFormatDefinition> FormatDefinitions = new Dictionary
			<BitmapFormat, BitmapFormatDefinition>()
		{
			{ BitmapFormat.A8,            new BitmapFormatDefinition { FormatType = DdsFormatType.Alpha, BitsPerPixel = 8, ABitMask = 0xFF } },
			{ BitmapFormat.Y8,            new BitmapFormatDefinition { FormatType = DdsFormatType.Luminance, BitsPerPixel = 8, RBitMask = 0xFF } },
			{ BitmapFormat.AY8,           new BitmapFormatDefinition { FormatType = DdsFormatType.Alpha, BitsPerPixel = 8, ABitMask = 0xFF } },
			{ BitmapFormat.A8Y8,          new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 16, ABitMask = 0xFF00, RBitMask = 0x00FF } },
			{ BitmapFormat.R5G6B5,        new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 16, RBitMask = 0xF800, GBitMask = 0x07E0, BBitMask = 0x001F } },
			{ BitmapFormat.A1R5G5B5,      new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 16, ABitMask = 0x8000, RBitMask = 0x7C00, GBitMask = 0x03E0, BBitMask = 0x001F } },
			{ BitmapFormat.A4R4G4B4,      new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 16, ABitMask = 0xF000, RBitMask = 0x0F00, GBitMask = 0x00F0, BBitMask = 0x000F } },
			{ BitmapFormat.X8R8G8B8,      new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 32, RBitMask = 0x00FF0000, GBitMask = 0x0000FF00, BBitMask = 0x000000FF } },
			{ BitmapFormat.A8R8G8B8,      new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 32, ABitMask = 0xFF000000, RBitMask = 0x00FF0000, GBitMask = 0x0000FF00, BBitMask = 0x000000FF } },
			{ BitmapFormat.Dxt1,          new BitmapFormatDefinition { FormatType = DdsFormatType.Other, FourCc = DdsFourCc.FromString("DXT1") } },
			{ BitmapFormat.Dxt3,          new BitmapFormatDefinition { FormatType = DdsFormatType.Other, FourCc = DdsFourCc.FromString("DXT3") } },
			{ BitmapFormat.Dxt5,          new BitmapFormatDefinition { FormatType = DdsFormatType.Other, FourCc = DdsFourCc.FromString("DXT5") } },
			{ BitmapFormat.A4R4G4B4Font,  new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 16, ABitMask = 0xF000, RBitMask = 0x0F00, GBitMask = 0x00F0, BBitMask = 0x000F } },

			// TODO: Double-check these
			{ BitmapFormat.V8U8,          new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.R8G8UNorm } },
			{ BitmapFormat.A32B32G32R32F, new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.R32G32B32A32Float } },
			{ BitmapFormat.A16B16G16R16F, new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.R32G32B32A32Float } },
			{ BitmapFormat.Q8W8V8U8,      new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.R8G8B8A8UNorm } },
			{ BitmapFormat.A2R10G10B10,   new BitmapFormatDefinition { FormatType = DdsFormatType.Rgb, BitsPerPixel = 32, ABitMask = 0xC0000000, RBitMask = 0x3FF00000, GBitMask = 0x000FFC00, BBitMask = 0x000003FF } },
			{ BitmapFormat.A16B16G16R16,  new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.R16G16B16A16UNorm } },
			{ BitmapFormat.V16U16,        new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.R16G16UNorm } },
			{ BitmapFormat.Dxn,           new BitmapFormatDefinition { FormatType = DdsFormatType.Other, D3D10Format = DxgiFormat.Bc5UNorm } }
		};
	}
}
