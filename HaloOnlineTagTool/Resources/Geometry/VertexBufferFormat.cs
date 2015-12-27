﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// Vertex buffer formats.
    /// </summary>
    public enum VertexBufferFormat : short
    {
        Invalid,
        World,                // Size = 0x38
        Rigid,                // Size = 0x38
        Skinned,              // Size = 0x40
        StaticPerPixel,       // Size = 0x8
        Unknown5,             // Size = 0x4
        StaticPerVertex,      // Size = 0x14
        Unknown7,             // Size = 0x14
        Unused8,              // Invalid
        AmbientPrt,           // Size = 0x4
        LinearPrt,            // Size = 0x4
        QuadraticPrt,         // Size = 0x24
        UnknownC,             // Size = 0x14
        UnknownD,             // Size = 0x10
        StaticPerVertexColor, // Size = 0xC
        UnknownF,             // Size = 0x18
        Unused10,             // Invalid
        Unused11,             // Invalid
        Unused12,             // Invalid
        Unused13,             // Invalid
        Unknown14,            // Size = 0x8
        Unknown15,            // Size = 0x4
        Unknown16,            // Size = 0x4
        Unknown17,            // Size = 0x4
        Decorator,            // Size = 0x20
        Unknown19,            // Size = 0x20
        Unknown1A,            // Size = 0xC
        Unknown1B,            // Size = 0x24
        Unknown1C,            // Size = 0x80
        Unused1D,             // Invalid
        World2                // Size = 0x38 (1.235640+ only)
    }
}
