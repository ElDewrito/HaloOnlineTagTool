using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Name = "scenario_lightmap_bsp_data", Class = "Lbsp", Size = 0x1E4)]
    public class ScenarioLightmapBspData
    {
        public short Unknown;
        public short BspIndex;
        public int StructureChecksum;
        public float Shadows;
        public uint Unknown2;
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;
        public uint Unknown6;
        public float Midtones;
        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;
        public uint Unknown10;
        public uint Unknown11;
        public float Highlights;
        public uint Unknown12;
        public uint Unknown13;
        public uint Unknown14;
        public uint Unknown15;
        public uint Unknown16;
        public float TopDownWhites;
        public uint Unknown17;
        public uint Unknown18;
        public uint Unknown19;
        public uint Unknown20;
        public uint Unknown21;
        public float TopDownBlacks;
        public uint Unknown22;
        public uint Unknown23;
        public uint Unknown24;
        public uint Unknown25;
        public uint Unknown26;
        public uint Unknown27;
        public uint Unknown28;
        public uint Unknown29;
        public uint Unknown30;
        public uint Unknown31;
        public uint Unknown32;
        public uint Unknown33;
        public uint Unknown34;
        public uint Unknown35;
        public uint Unknown36;
        public uint Unknown37;
        public uint Unknown38;
        public uint Unknown39;
        public uint Unknown40;
        public uint Unknown41;
        public uint Unknown42;
        public uint Unknown43;
        public uint Unknown44;
        public uint Unknown45;
        public uint Unknown46;
        public uint Unknown47;
        public uint Unknown48;
        public uint Unknown49;
        public uint Unknown50;
        public TagInstance PrimaryMap;
        public TagInstance IntensityMap;
        public List<InstancedMesh> InstancedMeshes;
        public List<UnknownBlock> Unknown51;
        public List<InstancedGeometryBlock> InstancedGeometry;
        public List<UnknownBBlock> UnknownB;
        public GeometryReference Geometry;
        public List<UnknownBlock6> Unknown69;
        public List<UnknownBlock4> Unknown64;
        public List<UnknownBlock5> Unknown65;
        public uint Unknown66;
        public uint Unknown67;
        public uint Unknown68;

        [TagStructure(Size = 0x10)]
        public class InstancedMesh
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public int UnknownIndex;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock
        {
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x8)]
        public class InstancedGeometryBlock
        {
            public short Unknown;
            public short InstancedMeshIndex;
            public short UnknownBIndex;
            public short Unknown2;
        }

        [TagStructure(Size = 0x48)]
        public class UnknownBBlock
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
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
            public uint Unknown14;
            public uint Unknown15;
            public uint Unknown16;
            public uint Unknown17;
            public uint Unknown18;
        }

        [TagStructure(Size = 0x50)]
        public class UnknownBlock4
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
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
            public uint Unknown14;
            public uint Unknown15;
            public uint Unknown16;
            public uint Unknown17;
            public uint Unknown18;
            public uint Unknown19;
            public uint Unknown20;
        }

        [TagStructure(Size = 0x2C)]
        public class UnknownBlock5
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public List<UnknownBlock> Unknown9;

            [TagStructure(Size = 0x54)]
            public class UnknownBlock
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
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
                public uint Unknown14;
                public uint Unknown15;
                public uint Unknown16;
                public uint Unknown17;
                public uint Unknown18;
                public uint Unknown19;
                public uint Unknown20;
                public uint Unknown21;
            }
        }

        [TagStructure(Size = 0x5C)]
        public class UnknownBlock6
        {
            public int Unknown0;
            public int Unknown4;
            public int Unknown8;
            public int UnknownC;
            public int Unknown10;
            public int Unknown14;
            public int Unknown18;
            public int Unknown1c;
            public int Unknown20;
            public int Unknown24;
            public int Unknown28;
            public int Unknown2c;
            public int Unknown30;
            public int Unknown34;
            public int Unknown38;
            public int Unknown3c;
            public int Unknown40;
            public int Unknown44;
            public int Unknown48;
            public int Unknown4c;
            public int Unknown50;
            public int Unknown54;
            public int Unknown58;
        }
    }
}
