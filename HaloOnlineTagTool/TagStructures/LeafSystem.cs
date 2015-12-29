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
    [TagStructure(Name = "leaf_system", Class = "lswd", Size = 0x58)]
    public class LeafSystem
    {
        public uint Unknown;
        public uint Unknown2;
        public TagInstance Unknown3;
        public uint Unknown4;
        public uint RespawnTime;
        public uint Unknown5;
        public uint Unknown6;
        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;
        public uint Unknown10;
        public uint Unknown11;
        public uint Unknown12;
        public uint Unknown13;
        public uint Unknown14;
        public uint Unknown15;
        public List<Unknown0Block> Unknown0;

        [TagStructure(Size = 0x3C)]
        public class Unknown0Block
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint ScaleMin;
            public uint ScaleMax;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;
            public uint Unknown12;
            public uint Unknown13;
        }
    }
}
