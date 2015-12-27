using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Bitmaps
{
    /// <summary>
    /// Bitmap data formats.
    /// </summary>
    public enum BitmapFormat : byte
    {
        A8,            // 00 "alpha"
        Y8,            // 01 "intensity"
        AY8,           // 02 "combined alpha-intensity"
        A8Y8,          // 03 "separate alpha-intensity"
        Unused4,       // 04
        Unused5,       // 05
        R5G6B5,        // 06 "high-color"
        Unused7,       // 07
        A1R5G5B5,      // 08 "high-color with 1-bit alpha"
        A4R4G4B4,      // 09 "high-color with alpha"
        X8R8G8B8,      // 0A "true-color"
        A8R8G8B8,      // 0B "true-color with alpha"
        UnusedC,       // 0C
        UnusedD,       // 0D
        Dxt1,          // 0E "compressed with color-key transparency" ('DXT1')
        Dxt3,          // 0F "compressed with explicit alpha" ('DXT3')
        Dxt5,          // 10 "compressed with interpolated alpha" ('DXT5')
        A4R4G4B4Font,  // 11 "font format"
        Unused12,      // 12
        Unused13,      // 13
        Unused14,      // 14
        Unused15,      // 15
        V8U8,          // 16 "v8u8 signed 8-bit"
        Unused17,      // 17
        A32B32G32R32F, // 18 "32 bit float ABGR"
        A16B16G16R16F, // 19 "16 bit float ABGR"
        Q8W8V8U8,      // 1A "8 bit signed 4 channel"
        A2R10G10B10,   // 1B "30-bit color 2-bit alpha"
        A16B16G16R16,  // 1C "48-bit color 16-bit alpha"
        V16U16,        // 1D "v16u16 signed 16-bit"
        Unused1E,      // 1E
        Unused1F,      // 1F
        Unused20,      // 20
        Dxn,           // 21 "compressed normals: high quality" ('ATI2')
        Unused22,      // 22
        Unused23,      // 23
        Unused24,      // 24
        Unused25,      // 25
        Unused26,      // 26
        Unused27       // 27
    }
}
