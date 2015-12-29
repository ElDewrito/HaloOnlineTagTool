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
    [TagStructure(Name = "render_method_template", Class = "rmt2", Size = 0x84)]
    public class RenderMethodTemplate
    {
        public TagInstance VertexShader;
        public TagInstance PixelShader;
        public uint DrawModeBitmask;
        public List<DrawMode> DrawModes; // Entries in here correspond to an enum in the EXE
        public List<UnknownBlock2> Unknown3;
        public List<ArgumentMapping> ArgumentMappings;
        public List<Argument> Arguments;
        public List<UnknownBlock4> Unknown5;
        public List<UnknownBlock5> Unknown6;
        public List<ShaderMap> ShaderMaps;
        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;

        [TagStructure(Size = 0x2)]
        public class DrawMode
        {
            // rmt2 uses these pointers in both this block and UnknownBlock2.
            public ushort UnknownBlock2Pointer;
        }

        [TagStructure(Size = 0x1C)]
        public class UnknownBlock2
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
        }

        /// <summary>
        /// Binds an argument in the render method tag to a pixel shader constant.
        /// </summary>
        [TagStructure(Size = 0x4)]
        public class ArgumentMapping
        {
            /// <summary>
            /// The GPU register to bind the argument to.
            /// </summary>
            public ushort RegisterIndex;

            /// <summary>
            /// The index of the argument in one of the blocks in the render method tag.
            /// The block used depends on the argument type.
            /// </summary>
            public byte ArgumentIndex;

            public byte Unknown;
        }

        [TagStructure(Size = 0x4)]
        public class Argument
        {
            public StringId Name;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock4
        {
            public StringId Unknown;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock5
        {
            public StringId Unknown;
        }

        [TagStructure(Size = 0x4)]
        public class ShaderMap
        {
            public StringId Name;
        }
    }
}
