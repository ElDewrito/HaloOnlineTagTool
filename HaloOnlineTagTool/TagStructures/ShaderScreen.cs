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
    [TagStructure(Name = "shader_screen", Class = "rmss", Size = 0x14)]
    public class ShaderScreen : RenderMethod
    {
        public uint Unknown8;
        public uint Unknown9;
        public uint Unknown10;
        public uint Unknown11;
        public uint Unknown12;
    }
}
