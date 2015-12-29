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
    [TagStructure(Name = "breakable_surface", Class = "bsdt", Size = 0x60)]
    public class BreakableSurface
    {
        public float MaximumVitality;
        public TagInstance Effect;
        public TagInstance Sound;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public uint Unknown4;
        public TagInstance CrackBitmap;
        public TagInstance HoleBitmap;
        public uint Unknown5;
        public uint Unknown6;
        public uint Unknown7;
    }
}
