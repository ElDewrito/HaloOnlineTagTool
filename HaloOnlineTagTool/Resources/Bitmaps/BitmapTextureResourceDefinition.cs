using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources.Bitmaps
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
		public D3DPointer<BitmapDefinition> Texture { get; set; }

		/// <summary>
		/// Describes a bitmap.
		/// </summary>
		[TagStructure(Size = 0x40)]
		public class BitmapDefinition
		{
			/// <summary>
			/// Gets or sets the reference to the bitmap data.
			/// </summary>
			[TagElement]
			public ResourceDataReference Data { get; set; }

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

			/// <summary>
			/// Gets or sets the bitmap's width in pixels.
			/// </summary>
			[TagElement]
			public short Width { get; set; }

			/// <summary>
			/// Gets or sets the bitmap's height in pixels.
			/// </summary>
			[TagElement]
			public short Height { get; set; }

			/// <summary>
			/// Gets or sets the bitmap's depth.
			/// Only used for <see cref="BitmapType.Texture3D"/> textures.
			/// </summary>
			[TagElement]
			public sbyte Depth { get; set; }

			/// <summary>
			/// Gets or sets the number of mip levels in the bitmap. (1 = full size only)
			/// </summary>
			[TagElement]
			public sbyte Levels { get; set; }

			/// <summary>
			/// Gets or sets the bitmap's type.
			/// </summary>
			[TagElement]
			public BitmapType Type { get; set; }

			[TagElement]
			public sbyte Unused2F { get; set; }

			/// <summary>
			/// Gets or sets the format of the bitmap as a D3DFORMAT enum.
			/// Note that this is actually unused and the game reads the format from <see cref="Format"/>.
			/// Setting this value is still suggested however.
			/// </summary>
			[TagElement]
			public int D3DFormatUnused { get; set; }

			/// <summary>
			/// Gets or sets the format of the bitmap data.
			/// </summary>
			[TagElement]
			public BitmapFormat Format { get; set; }

			// Some sort of enum? No idea what this does but it IS used for something.
			[TagElement]
			public byte Unknown35 { get; set; }

			/// <summary>
			/// Gets or sets flags describing the bitmap.
			/// </summary>
			[TagElement]
			public BitmapFlags Flags { get; set; }

			[TagElement]
			public int Unused38 { get; set; }
			[TagElement]
			public int Unused3C { get; set; }
		}
	}
}
