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
    [TagStructure(Name = "ai_globals", Class = "aigl", Size = 0x10)]
    public class AiGlobals
    {
        public List<UnknownBlock> Unknown;
        public uint Unknown2;

        [TagStructure(Size = 0x144)]
        public class UnknownBlock
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public float DangerBroadlyFacing;
            public float DangerShootingNear;
            public float DangerShootingAt;
            public float DangerExtremelyClose;
            public float DangerShieldDamage;
            public float DangerExtendedShieldDamage;
            public float DangerBodyDamage;
            public float DangerExtendedBodyDamage;
            public TagInstance GlobalDialogue;
            public StringId DefaultMissionDialogueSoundEffect;
            public float JumpDown;
            public float JumpStep;
            public float JumpCrouch;
            public float JumpStand;
            public float JumpStorey;
            public float JumpTower;
            public float MaxJumpDownHeightDown;
            public float MaxJumpDownHeightStep;
            public float MaxJumpDownHeightCrouch;
            public float MaxJumpDownHeightStand;
            public float MaxJumpDownHeightStorey;
            public float MaxJumpDownHeightTower;
            public float HoistStepMin;
            public float HoistStepMax;
            public float HoistCrouchMin;
            public float HoistCrouchMax;
            public float HoistStandMin;
            public float HoistStandMax;
            public float VaultStepMin;
            public float VaultStepMax;
            public float VaultCrouchMin;
            public float VaultCrouchMax;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public List<GravemindProperty> GravemindProperties;
            public float ScaryTargetThreshold;
            public float ScaryWeaponThreshold;
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
            public List<Style> Styles;
            public List<Formation> Formations;
            public List<SquadTemplate> SquadTemplates;
            public uint Unknown19;
            public uint Unknown20;
            public uint Unknown21;
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

            [TagStructure(Size = 0xC)]
            public class GravemindProperty
            {
                public float MinimumRetreatTime;
                public float IdealRetreatTime;
                public float MaximumRetreatTime;
            }

            [TagStructure(Size = 0x10)]
            public class Style
            {
                public TagInstance Style2;
            }

            [TagStructure(Size = 0x10)]
            public class Formation
            {
                public TagInstance Formations;
            }

            [TagStructure(Size = 0x10)]
            public class SquadTemplate
            {
                public TagInstance SquadTemplate2;
            }
        }
    }
}
