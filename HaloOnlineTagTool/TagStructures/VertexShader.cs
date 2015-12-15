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
    [TagStructure(Name = "vertex_shader", Class = "vtsh", Size = 0x20)]
    public class VertexShader
    {
        public uint Unknown;
        public List<UnknownBlock> Unknown2;
        public uint Unknown3;
        public List<VertexShader2> VertexShaders;

        [TagStructure(Size = 0xC)]
        public class UnknownBlock
        {
            public List<DrawMode> DrawModes;

            [TagStructure(Size = 0x2)]
            public class DrawMode
            {
                public short Unknown;
            }
        }

        [TagStructure(Size = 0x50)]
        public class VertexShader2
        {
            public byte[] Unknown;
            public byte[] Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public List<UnknownBlock> Unknown7;
            public uint Unknown8;
            public uint Unknown9;
            public uint VertexShader;

            [TagStructure(Size = 0x8)]
            public class UnknownBlock
            {
                public StringId Unknown;
                public uint Unknown2;
            }
        }
    }
}
