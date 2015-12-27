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
    [TagStructure(Name = "particle_physics", Class = "pmov", Size = 0x2C)]
    public class ParticlePhysics
    {
        public TagInstance Template;
        public uint Flags;
        public List<Movement> Movements;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;

        [TagStructure(Size = 0x18)]
        public class Movement
        {
            public TypeValue Type;
            public short Unknown;
            public List<Parameter> Parameters;
            public short Unknown2;
            public short Unknown3;
            public int Unknown4;

            public enum TypeValue : short
            {
                Physics,
                Collider,
                Swarm,
                Wind,
            }

            [TagStructure(Size = 0x24)]
            public class Parameter
            {
                public int ParameterId;
                public short Unknown;
                public short Unknown2;
                public byte[] Function;
                public float Unknown3;
                public byte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
                public sbyte Unknown7;
            }
        }
    }
}
