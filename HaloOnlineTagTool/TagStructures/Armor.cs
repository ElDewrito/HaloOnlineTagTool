using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Name = "armor", Class = "armr", Size = 0x28, MinVersion = EngineVersion.V10_1_430475_Live)]
    public class Armor : GameObject
    {
        public TagInstance ParentModel;
        public TagInstance FirstPersonModel;
        public TagInstance ThirdPersonModel;
        public uint Unused1;
    }
}
