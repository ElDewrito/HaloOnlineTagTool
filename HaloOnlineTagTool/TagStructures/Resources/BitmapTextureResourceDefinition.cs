using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures.Resources
{
	/// <summary>
	/// Resource definition data for bitmap textures.
	/// </summary>
	[TagStructure(Size = 0xC)]
	public class BitmapTextureResourceDefinition
	{
		/// <summary>
		/// Gets or sets the texture object.
		/// </summary>
		[TagElement]
		public D3DObject<TextureDefinition> Texture { get; set; }

		/// <summary>
		/// Describes a texture.
		/// </summary>
		[TagStructure(Size = 0x40)]
		public class TextureDefinition
		{
			/// <summary>
			/// Gets or sets the reference to the texture data.
			/// </summary>
			[TagElement]
			public RawResourceDataReference Data { get; set; }

			[TagElement]
			public int Unused14 { get; set; }
			[TagElement]
			public int Unused18 { get; set; }
			[TagElement]
			public int Unused1C { get; set; }
			[TagElement]
			public int Unused20 { get; set; }
			[TagElement]
			public int Unused24 { get; set; }

			[TagElement]
			public short Width { get; set; }

			[TagElement]
			public short Height { get; set; }

			[TagElement]
			public sbyte Unknown2C { get; set; }
			[TagElement]
			public sbyte Unknown2D { get; set; }
			[TagElement]
			public sbyte Unknown2E { get; set; }

			[TagElement]
			public sbyte Unused2F { get; set; }

			/// <summary>
			/// Gets or sets the format of the texture.
			/// It's probably a member of the D3DFORMAT enum.
			/// Although the game doesn't actually use this, setting it is still recommended.
			/// </summary>
			[TagElement]
			public int FormatUnused { get; set; }

			[TagElement]
			public sbyte Unknown34 { get; set; }
			[TagElement]
			public sbyte Unknown35 { get; set; }
			[TagElement]
			public short Unknown36 { get; set; }

			[TagElement]
			public int Unused38 { get; set; }
			[TagElement]
			public int Unused3C { get; set; }
		}
	}
}
