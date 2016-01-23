using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Name = "ai_mission_dialogue", Class = "mdlg", Size = 0xC)]
    public class AiMissionDialogue
    {
        public List<Line> Lines;

        [TagStructure(Size = 0x14)]
        public class Line
        {
            public StringId Name;
            public List<Variant> Variants;
            public StringId DefaultSoundEffect;

            [TagStructure(Size = 0x18)]
            public class Variant
            {
                public StringId Designation;
                public TagInstance Sound;
                public StringId SoundEffect;
            }
        }
    }
}
