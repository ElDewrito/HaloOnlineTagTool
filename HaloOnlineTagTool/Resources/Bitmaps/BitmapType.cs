using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Bitmaps
{
    /// <summary>
    /// Bitmap types.
    /// </summary>
    public enum BitmapType : byte
    {
        Texture2D, // IDirect3DDevice9::CreateTexture
        Texture3D, // IDirect3DDevice9::CreateVolumeTexture
        CubeMap    // IDirect3DDevice9::CreateCubeTexture
    }
}
