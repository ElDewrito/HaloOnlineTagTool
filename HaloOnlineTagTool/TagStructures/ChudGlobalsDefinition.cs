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
	[TagStructure(Class = "chgd", Size = 0x2C0)]
	public class ChudGlobalsDefinition
	{
		public List<HudGlobal> HudGlobals;
		public List<HudShader> HudShaders;
		public List<UnknownBlock> Unknown;
		public List<UnknownBlock2> Unknown2;
		public List<PlayerTrainingDatum> PlayerTrainingData;
		public HaloTag StartMenuEmblems;
		public HaloTag CampaignMedals;
		public HaloTag CampaignMedalHudAnimation;
		public short Unknown3;
		public short Unknown4;
		public float CampaignMedalScale;
		public float CampaignMedalSpacing;
		public float CampaignMedalOffsetX;
		public float CampaignMedalOffsetY;
		public float MetagameScoreboardTopY;
		public float MetagameScoreboardSpacing;
		public HaloTag UnitDamageGrid;
		public float MicroTextureTileAmount;
		public float MediumSensorBlipScale;
		public float SmallSensorBlipScale;
		public float LargeSensorBlipScale;
		public float SensorBlipGlowAmount;
		public float SensorBlipGlowRadius;
		public float SensorBlipGlowOpacity;
		public HaloTag MotionSensorBlip;
		public HaloTag BirthdayPartyEffect;
		public HaloTag CampaignFloodMask;
		public HaloTag CampaignFloodMaskTile;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		public float Unknown11;
		public float Unknown12;
		public float Unknown13;
		public float Unknownundefined;
		public float Unknown14;
		public float Unknown15;
		public float Unknown16;
		public float Unknown17;
		public float Unknown18;
		public float Unknown19;
		public float Unknown20;
		public float Unknown21;
		public float Unknown22;
		public float Unknown23;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;
		public byte[] Unknown27;
		public float Unknown28;
		public float Unknown29;
		public float Unknown30;
		public float Unknown31;
		public float Unknown32;
		public float Unknown33;
		public float Unknown34;
		public float Unknown35;
		public float Unknown36;
		public float Unknown37;
		public float Unknown38;
		public float Unknown39;
		public float Unknown40;
		public float Unknown41;
		public float Unknown42;
		public float Unknown43;
		public byte[] Unknown44;
		public float Unknown45;
		public float Unknown46;
		public float Unknown47;
		public HaloTag Unknown48;
		public float Unknown49;
		public byte[] Unknown50;
		public byte[] Unknown51;
		public byte[] Unknown52;
		public byte[] Unknown53;
		public byte[] Unknown54;
		public float Unknown55;
		public byte[] Unknown56;
		public byte[] Unknown57;
		public byte[] Unknown58;
		public byte[] Unknown59;
		public byte[] Unknown60;
		public HaloTag Unknown61;
		public float Unknown62;
		public float Unknown63;
		public float Unknown64;

		[TagStructure(Size = 0x4)]
		public class RgbaColor
		{
			public byte R;
			public byte G;
			public byte B;
			public byte A;
		}

		[TagStructure(Size = 0x2B0)]
		public class HudGlobal
		{
			public BipedValue Biped;
			[TagField(Count = 37)] public RgbaColor[] Colors;
			public List<HudAttribute> HudAttributes;
			public List<HudSound> HudSounds;
			public HaloTag Unknown;
			public HaloTag FragGrenadeSwapSound;
			public HaloTag PlasmaGrenadeSwapSound;
			public HaloTag SpikeGrenadeSwapSound;
			public HaloTag FirebombGrenadeSwapSound;
			public HaloTag DamageMicrotexture;
			public HaloTag DamageNoise;
			public HaloTag DirectionalArrow;
			public HaloTag Unknown2;
			public HaloTag Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public HaloTag Waypoints;
			public HaloTag Unknown10;
			public HaloTag ScoreboardHud;
			public HaloTag MetagameScoreboardHud;
			public HaloTag SurvivalHud;
			public HaloTag MetagameScoreboardHud2;
			public HaloTag TheaterHud;
			public HaloTag ForgeHud;
			public HaloTag HudStrings;
			public HaloTag Medals;
			public List<MultiplayerMedal> MultiplayerMedals;
			public HaloTag MedalHudAnimation;
			public HaloTag MedalHudAnimation2;
			public HaloTag CortanaChannel;
			public HaloTag Unknown11;
			public HaloTag Unknown12;
			public HaloTag Unknown13;
			public HaloTag Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float GrenadeScematicsSpacing;
			public float EquipmentScematicOffsetY;
			public float DualEquipmentScematicOffsetY;
			public float Unknown17;
			public float Unknown18;
			public float ScoreboardLeaderOffsetY;
			public float Unknown19;
			public float WaypointScale;
			public float Unknown20;

			public enum BipedValue : int
			{
				Spartan,
				Elite,
				Monitor,
			}

			[TagStructure(Size = 0xE8)]
			public class HudAttribute
			{
				public uint ResolutionFlags;
				public Angle WarpAngle;
				public float WarpAmount;
				public float WarpDirection;
				public uint ResolutionWidth;
				public uint ResolutionHeight;
				public float MotionSensorOffsetX;
				public float MotionSensorOffsetY;
				public float MotionSensorRadius;
				public float MotionSensorScale;
				public float HorizontalScale;
				public float VerticalScale;
				public float HorizontalStretch;
				public float VerticalStretch;
				public HaloTag Unknown;
				public HaloTag Unknown2;
				public HaloTag FirstPersonDamageBorder;
				public HaloTag ThirdPersonDamageBorder;
				public float Unknown3;
				public float Unknown4;
				public float Unknown5;
				public float Unknown6;
				public float Unknown7;
				public float Unknown8;
				public float Unknown9;
				public float StateCenterOffsetY;
				public float Unknown10;
				public float Unknown11;
				public float Unknown12;
				public float Unknown13;
				public float Unknown14;
				public float Unknown15;
				public float Unknown16;
				public float Unknown17;
				public float NotificationScale;
				public float NotificationLineSpacing;
				public float Unknown18;
				public float Unknown19;
				public float NotificationOffsetY;
				public float Unknown20;
				public float Unknown21;
				public float Unknown22;
				public float Unknown23;
				public float Unknown24;
				public float Unknown25;
				public float Unknown26;
			}

			[TagStructure(Size = 0x14, MaxVersion = EngineVersion.V10_1_449175_Live)]
			[TagStructure(Size = 0x18, MinVersion = EngineVersion.V11_1_498295_Live)]
			public class HudSound
			{
				public uint LatchedTo;
				[MinVersion(EngineVersion.V11_1_498295_Live)] public uint LatchedTo2;
				public float Scale;
				public List<UnknownBlock> Unknown;

				[TagStructure(Size = 0x14)]
				public class UnknownBlock
				{
					public BipedValue Biped;
					public HaloTag Sound;

					public enum BipedValue : int
					{
						Spartan,
						Elite,
						Monitor,
					}
				}
			}

			[TagStructure(Size = 0x4)]
			public class MultiplayerMedal
			{
				public StringId Medal;
			}
		}

		[TagStructure(Size = 0x20)]
		public class HudShader
		{
			public HaloTag VertexShader;
			public HaloTag PixelShader;
		}

		[TagStructure(Size = 0x40)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock2
		{
			public float Unknown;
			public List<UnknownBlock> Unknown2;

			[TagStructure(Size = 0xE4)]
			public class UnknownBlock
			{
				public float Unknown;
				public float Unknown2;
				public float Unknown3;
				public float Unknown4;
				public float Unknown5;
				public float Unknown6;
				public float Unknown7;
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
				public float Unknown19;
				public float Unknown20;
				public float Unknown21;
				public float Unknown22;
				public float Unknown23;
				public float Unknown24;
				public float Unknown25;
				public HaloTag Sound;
				public float Unknown26;
				public float Unknown27;
				public float Unknown28;
				public float Unknown29;
				public float Unknown30;
				public float Unknown31;
				public float Unknown32;
				public float Unknown33;
				public float Unknown34;
				public float Unknown35;
				public float Unknown36;
				public float Unknown37;
				public float Unknown38;
				public float Unknown39;
				public float Unknown40;
				public float Unknown41;
				public float Unknown42;
				public float Unknown43;
				public float Unknown44;
				public float Unknown45;
				public float Unknown46;
				public float Unknown47;
				public float Unknown48;
				public float Unknown49;
				public HaloTag Sound2;
			}
		}

		[TagStructure(Size = 0x14)]
		public class PlayerTrainingDatum
		{
			public StringId DisplayString;
			public short MaxDisplayTime;
			public short DisplayCount;
			public short DisappearDelay;
			public short RedisplayDelay;
			public float DisplayDelay;
			public ushort Flags;
			public short Unknown;
		}
	}
}
