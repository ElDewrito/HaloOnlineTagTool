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
    [TagStructure(Name = "gfx_textures_list", Class = "gfxt", Size = 0x10)]
    public class GfxTexturesList
    {
        public List<Texture> Textures;
        public uint Unknown;

        [TagStructure(Size = 0x110)]
        public class Texture
        {
            [TagField(Length = 256)] public string FileName;
            public TagInstance Bitmap;
        }
    }
}
