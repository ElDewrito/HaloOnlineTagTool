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
    [TagStructure(Name = "render_method_definition", Class = "rmdf", Size = 0x5C)]
    public class RenderMethodDefinition
    {
        public TagInstance Unknown;
        public List<Method> Methods;
        public List<DrawMode> DrawModes;
        public List<UnknownBlock2> Unknown3;
        public TagInstance Unknown4;
        public TagInstance Unknown5;
        public uint Unknown6;
        public uint Unknown7;

        [TagStructure(Size = 0x18)]
        public class Method
        {
            public StringId Type;
            public List<ShaderOption> ShaderOptions;
            public StringId Unknown;
            public StringId Unknown2;

            [TagStructure(Size = 0x1C)]
            public class ShaderOption
            {
                public StringId Type;
                public TagInstance Option;
                public StringId Unknown;
                public StringId Unknown2;
            }
        }

        [TagStructure(Size = 0x10)]
        public class DrawMode
        {
            public uint Mode;
            public List<UnknownBlock2> Unknown2;

            [TagStructure(Size = 0x10)]
            public class UnknownBlock2
            {
                public uint Unknown;
                public List<UnknownBlock> Unknown2;

                [TagStructure(Size = 0x4)]
                public class UnknownBlock
                {
                    public uint Unknown;
                }
            }
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock2
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
        }
    }
}
