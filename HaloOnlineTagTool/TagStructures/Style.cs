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
    [TagStructure(Name = "style", Class = "styl", Size = 0x5C)]
    public class Style
    {
        [TagField(Length = 32)] public string Name;
        public CombatStatusDecayOptionsValue CombatStatusDecayOptions;
        public short Unknown;
        public uint StyleControl;
        public uint Behaviors1;
        public uint Behaviors2;
        public uint Behaviors3;
        public uint Behaviors4;
        public uint Behaviors5;
        public uint Behaviors6;
        public uint Behaviors7;
        public List<SpecialMovementBlock> SpecialMovement;
        public List<BehaviorListBlock> BehaviorList;

        public enum CombatStatusDecayOptionsValue : short
        {
            LatchAtIdle,
            LatchAtAlert,
            LatchAtCombat,
        }

        [TagStructure(Size = 0x4)]
        public class SpecialMovementBlock
        {
            public uint SpecialMovement1;
        }

        [TagStructure(Size = 0x20)]
        public class BehaviorListBlock
        {
            [TagField(Length = 32)] public string BehaviorName;
        }
    }
}
