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
	[TagStructure(Class = "aigl", Size = 0x10)]
	public class AiGlobals
	{
		public List<UnknownBlock> Unknown;
		public float Unknown2;

		[TagStructure(Size = 0x144)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float DangerBroadlyFacing;
			public float DangerShootingNear;
			public float DangerShootingAt;
			public float DangerExtremelyClose;
			public float DangerShieldDamage;
			public float DangerExtendedShieldDamage;
			public float DangerBodyDamage;
			public float DangerExtendedBodyDamage;
			public HaloTag GlobalDialogue;
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
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public List<GravemindProperty> GravemindProperties;
			public float ScaryTargetThreshold;
			public float ScaryWeaponThreshold;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public float Unknown18;
			public List<Style> Styles;
			public List<Formation> Formations;
			public List<SquadTemplate> SquadTemplates;
			public float Unknown19;
			public float Unknown20;
			public float Unknown21;
			public float Unknown22;
			public float Unknown23;
			public float Unknown24;
			public float Unknown25;
			public float Unknown26;
			public float Unknown27;
			public float Unknown28;
			public float Unknown29;
			public float Unknown30;
			public float Unknown31;
			public float Unknown32;

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
				public HaloTag Style2;
			}

			[TagStructure(Size = 0x10)]
			public class Formation
			{
				public HaloTag Formations;
			}

			[TagStructure(Size = 0x10)]
			public class SquadTemplate
			{
				public HaloTag SquadTemplate2;
			}
		}
	}
}
