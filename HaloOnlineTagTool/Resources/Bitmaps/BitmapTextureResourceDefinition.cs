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
        public D3DPointer<BitmapDefinition> Texture;

        /// <summary>
        /// Describes a bitmap.
        /// </summary>
        [TagStructure(Size = 0x40)]
        public class BitmapDefinition
        {
            /// <summary>
            /// Gets or sets the reference to the bitmap data.
            /// </summary>
            public ResourceDataReference Data;

            public int Unused14;
            public int Unused18;
            public int Unused1C;
            public int Unused20;
            public int Unused24;

            /// <summary>
            /// Gets or sets the bitmap's width in pixels.
            /// </summary>
            public short Width;

            /// <summary>
            /// Gets or sets the bitmap's height in pixels.
            /// </summary>
            public short Height;

            /// <summary>
            /// Gets or sets the bitmap's depth.
            /// Only used for <see cref="BitmapType.Texture3D"/> textures.
            /// </summary>
            public sbyte Depth;

            /// <summary>
            /// Gets or sets the number of mip levels in the bitmap. (1 = full size only)
            /// </summary>
            public sbyte Levels;

            /// <summary>
            /// Gets or sets the bitmap's type.
            /// </summary>
            public BitmapType Type;

            public sbyte Unused2F;

            /// <summary>
            /// Gets or sets the format of the bitmap as a D3DFORMAT enum.
            /// Note that this is actually unused and the game reads the format from <see cref="Format"/>.
            /// Setting this value is still suggested however.
            /// </summary>
            public int D3DFormatUnused;

            /// <summary>
            /// Gets or sets the format of the bitmap data.
            /// </summary>
            public BitmapFormat Format;

            // Some sort of enum? No idea what this does but it IS used for something.
            public byte Unknown35;

            /// <summary>
            /// Gets or sets flags describing the bitmap.
            /// </summary>
            public BitmapFlags Flags;

            public int Unused38;
            public int Unused3C;
        }
    }
}
