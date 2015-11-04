using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "gfxt", Size = 0x10)]
	public class GfxTexturesList
	{
		public List<Texture> Textures;
		public float Unknown;

		[TagStructure(Size = 0x110)]
		public class Texture
		{
			public string FileName;
			public HaloTag Bitmap;
		}
	}
}
