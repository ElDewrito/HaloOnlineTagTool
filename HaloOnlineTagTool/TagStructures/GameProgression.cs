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
    [TagStructure(Name = "game_progression", Class = "gpdt", Size = 0x44)]
    public class GameProgression
    {
        public List<UnknownBlock> Unknown;
        public List<UnknownBlock2> Unknown2;
        public List<UnknownBlock3> Unknown3;
        public List<UnknownBlock4> Unknown4;
        public List<UnknownBlock5> Unknown5;
        public uint Unknown6;
        public uint Unknown7;

        [TagStructure(Size = 0x4)]
        public class UnknownBlock
        {
            public StringId Unknown;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock2
        {
            public StringId Unknown;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock3
        {
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock4
        {
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x124)]
        public class UnknownBlock5
        {
            public StringId MapName;
            public int Unknown;
            public int Unknown2;
            public TagInstance Unknown3;
            public int MapId;
            public int Unknown4;
            [TagField(Length = 256)] public string MapScenarioPath;
        }
    }
}
