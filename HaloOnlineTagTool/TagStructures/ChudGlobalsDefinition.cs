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

		[TagStructure(Size = 0x2B0)]
		public class HudGlobal
		{
			public BipedValue Biped;
			public byte _0Alpha;
			public byte _0R;
			public byte _0G;
			public byte _0B;
			public byte _1Alpha;
			public byte _1R;
			public byte _1G;
			public byte _1B;
			public byte _2Alpha;
			public byte _2R;
			public byte _2G;
			public byte _2B;
			public byte _3Alpha;
			public byte _3R;
			public byte _3G;
			public byte _3B;
			public byte _4Alpha;
			public byte _4R;
			public byte _4G;
			public byte _4B;
			public byte _5Alpha;
			public byte _5R;
			public byte _5G;
			public byte _5B;
			public byte _6Alpha;
			public byte _6R;
			public byte _6G;
			public byte _6B;
			public byte _7Alpha;
			public byte _7R;
			public byte _7G;
			public byte _7B;
			public byte _8Alpha;
			public byte _8R;
			public byte _8G;
			public byte _8B;
			public byte _9Alpha;
			public byte _9R;
			public byte _9G;
			public byte _9B;
			public byte _10Alpha;
			public byte _10R;
			public byte _10G;
			public byte _10B;
			public byte _11Alpha;
			public byte _11R;
			public byte _11G;
			public byte _11B;
			public byte _12Alpha;
			public byte _12R;
			public byte _12G;
			public byte _12B;
			public byte _13Alpha;
			public byte _13R;
			public byte _13G;
			public byte _13B;
			public byte _14Alpha;
			public byte _14R;
			public byte _14G;
			public byte _14B;
			public byte _15Alpha;
			public byte _15R;
			public byte _15G;
			public byte _15B;
			public byte _16Alpha;
			public byte _16R;
			public byte _16G;
			public byte _16B;
			public byte _17Alpha;
			public byte _17R;
			public byte _17G;
			public byte _17B;
			public byte _18Alpha;
			public byte _18R;
			public byte _18G;
			public byte _18B;
			public byte _19Alpha;
			public byte _19R;
			public byte _19G;
			public byte _19B;
			public byte _20Alpha;
			public byte _20R;
			public byte _20G;
			public byte _20B;
			public byte _21Alpha;
			public byte _21R;
			public byte _21G;
			public byte _21B;
			public byte _22Alpha;
			public byte _22R;
			public byte _22G;
			public byte _22B;
			public byte _23Alpha;
			public byte _23R;
			public byte _23G;
			public byte _23B;
			public byte _24Alpha;
			public byte _24R;
			public byte _24G;
			public byte _24B;
			public byte _25Alpha;
			public byte _25R;
			public byte _25G;
			public byte _25B;
			public byte _26Alpha;
			public byte _26R;
			public byte _26G;
			public byte _26B;
			public byte _27Alpha;
			public byte _27R;
			public byte _27G;
			public byte _27B;
			public byte _28Alpha;
			public byte _28R;
			public byte _28G;
			public byte _28B;
			public byte _29Alpha;
			public byte _29R;
			public byte _29G;
			public byte _29B;
			public byte _30Alpha;
			public byte _30DefaultItemVersionR;
			public byte _30DefaultItemVersionG;
			public byte _30DefaultItemVersionB;
			public byte _31Alpha;
			public byte _31Version1ItemR;
			public byte _31Version1ItemG;
			public byte _31Version1ItemB;
			public byte _32Alpha;
			public byte _32Version2ItemR;
			public byte _32Version2ItemG;
			public byte _32Version2ItemB;
			public byte _33Alpha;
			public byte _33Version3ItemR;
			public byte _33Version3ItemG;
			public byte _33Version3ItemB;
			public byte _34Alpha;
			public byte _34Version4ItemR;
			public byte _34Version4ItemG;
			public byte _34Version4ItemB;
			public byte _35Alpha;
			public byte _35Version5ItemR;
			public byte _35Version5ItemG;
			public byte _35Version5ItemB;
			public byte _36Alpha;
			public byte _36Version6ItemR;
			public byte _36Version6ItemG;
			public byte _36Version6ItemB;
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

			[TagStructure(Size = 0x14)]
			public class HudSound
			{
				public uint LatchedTo;
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
