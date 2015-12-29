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
    [TagStructure(Name = "rasterizer_globals", Class = "rasg", Size = 0xBC)]
    public class RasterizerGlobals
    {
        public List<DefaultBitmap> DefaultBitmaps;
        public List<DefaultRasterizerBitmap> DefaultRasterizerBitmaps;
        public TagInstance VertexShaderSimple;
        public TagInstance PixelShaderSimple;
        public List<DefaultShader> DefaultShaders;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public int Unknown4;
        public int Unknown5;
        public TagInstance ActiveCamoDistortion;
        public TagInstance DefaultPerformanceTemplate;
        public TagInstance DefaultShieldImpact;
        public TagInstance DefaultVisionMode;
        public int Unknown6;
        public float Unknown7;
        public float Unknown8;
        public float Unknown9;
        public float Unknown10;
        public float Unknown11;
        public float Unknown12;
        public uint Unknown13;
        public uint Unknown14;

        [TagStructure(Size = 0x14)]
        public class DefaultBitmap
        {
            public int Unknown;
            public TagInstance Bitmap;
        }

        [TagStructure(Size = 0x10)]
        public class DefaultRasterizerBitmap
        {
            public TagInstance Bitmap;
        }

        [TagStructure(Size = 0x20)]
        public class DefaultShader
        {
            public TagInstance VertexShader;
            public TagInstance PixelShader;
        }
    }
}
