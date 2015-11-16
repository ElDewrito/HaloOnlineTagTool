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
	[TagStructure(Class = "wigl", Size = 0x3D0)]
	public class UserInterfaceSharedGlobalsDefinition
	{
		public short IncTextUpdatePeriod;
		public short IncTextBlockCharacter;
		public float NearClipPlaneDistance;
		public float ProjectionPlaneDistance;
		public float FarClipPlaneDistance;
		public HaloTag GlobalStrings;
		public HaloTag DamageTypeStrings;
		public HaloTag UnknownStrings;
		public HaloTag MainMenuMusic;
		public int MusicFadeTime;
		public float ColorA;
		public float ColorR;
		public float ColorG;
		public float ColorB;
		public float TextStrokeColorA;
		public float TextStrokeColorR;
		public float TextStrokeColorG;
		public float TextStrokeColorB;
		public List<TextColor> TextColors;
		public List<PlayerColor> PlayerColors;
		public HaloTag UiSounds;
		public List<Alert> Alerts;
		public List<Dialog> Dialogs;
		public List<GlobalDataSource> GlobalDataSources;
		public float WidescreenBitmapScaleX;
		public float WidescreenBitmapScaleY;
		public float StandardBitmapScaleX;
		public float StandardBitmapScaleY;
		public float MenuBlurX;
		public float MenuBlurY;
		public List<UiWidgetBiped> UiWidgetBipeds;
		public StringId UnknownPlayer1;
		public StringId UnknownPlayer2;
		public StringId UnknownPlayer3;
		public StringId UnknownPlayer4;
		[TagField(Length = 32)] public string UiEliteBipedName;
		[TagField(Length = 32)] public string UiEliteAiSquadName;
		public StringId UiEliteAiLocationName;
		[TagField(Length = 32)] public string UiOdst1BipedName;
		[TagField(Length = 32)] public string UiOdst1AiSquadName;
		public StringId UiOdst1AiLocationName;
		[TagField(Length = 32)] public string UiMickeyBipedName;
		[TagField(Length = 32)] public string UiMickeyAiSquadName;
		public StringId UiMickeyAiLocationName;
		[TagField(Length = 32)] public string UiRomeoBipedName;
		[TagField(Length = 32)] public string UiRomeoAiSquadName;
		public StringId UiRomeoAiLocationName;
		[TagField(Length = 32)] public string UiDutchBipedName;
		[TagField(Length = 32)] public string UiDutchAiSquadName;
		public StringId UiDutchAiLocationName;
		[TagField(Length = 32)] public string UiJohnsonBipedName;
		[TagField(Length = 32)] public string UiJohnsonAiSquadName;
		public StringId UiJohnsonAiLocationName;
		[TagField(Length = 32)] public string UiOdst2BipedName;
		[TagField(Length = 32)] public string UiOdst2AiSquadName;
		public StringId UiOdst2AiLocationName;
		[TagField(Length = 32)] public string UiOdst3BipedName;
		[TagField(Length = 32)] public string UiOdst3AiSquadName;
		public StringId UiOdst3AiLocationName;
		[TagField(Length = 32)] public string UiOdst4BipedName;
		[TagField(Length = 32)] public string UiOdst4AiSquadName;
		public StringId UiOdst4AiLocationName;
		public int SingleScrollSpeed;
		public int ScrollSpeedTransitionWaitTime;
		public int HeldScrollSpeed;
		public int AttractVideoIdleWait;
		public byte[] Unknown;
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
		public uint Unknown22;

		[TagStructure(Size = 0x14)]
		public class TextColor
		{
			public StringId Name;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
		}

		[TagStructure(Size = 0x30)]
		public class PlayerColor
		{
			public List<PlayerTextColorBlock> PlayerTextColor;
			public List<TeamTextColorBlock> TeamTextColor;
			public List<PlayerUiColorBlock> PlayerUiColor;
			public List<TeamUiColorBlock> TeamUiColor;

			[TagStructure(Size = 0x10)]
			public class PlayerTextColorBlock
			{
				public float ColorA;
				public float ColorR;
				public float ColorG;
				public float ColorB;
			}

			[TagStructure(Size = 0x10)]
			public class TeamTextColorBlock
			{
				public float ColorA;
				public float ColorR;
				public float ColorG;
				public float ColorB;
			}

			[TagStructure(Size = 0x10)]
			public class PlayerUiColorBlock
			{
				public float ColorA;
				public float ColorR;
				public float ColorG;
				public float ColorB;
			}

			[TagStructure(Size = 0x10)]
			public class TeamUiColorBlock
			{
				public float ColorA;
				public float ColorR;
				public float ColorG;
				public float ColorB;
			}
		}

		[TagStructure(Size = 0x10)]
		public class Alert
		{
			public StringId Name;
			public byte Flags;
			public sbyte Unknown;
			public IconValue Icon;
			public sbyte Unknown2;
			public StringId Title;
			public StringId Body;

			public enum IconValue : sbyte
			{
				None,
				Download,
				Pause,
				Upload,
				Checkbox,
			}
		}

		[TagStructure(Size = 0x28)]
		public class Dialog
		{
			public StringId Name;
			public short Unknown;
			public short Unknown2;
			public StringId Title;
			public StringId Body;
			public StringId Option1;
			public StringId Option2;
			public StringId Option3;
			public StringId Option4;
			public StringId KeyLegend;
			public DefaultOptionValue DefaultOption;
			public short Unknown3;

			public enum DefaultOptionValue : short
			{
				Option1,
				Option2,
				Option3,
				Option4,
			}
		}

		[TagStructure(Size = 0x10)]
		public class GlobalDataSource
		{
			public HaloTag DataSource;
		}

		[TagStructure(Size = 0x154)]
		public class UiWidgetBiped
		{
			[TagField(Length = 32)] public string AppearanceBipedName;
			[TagField(Length = 32)] public string AppearanceAiSquadName;
			public StringId AppearanceAiLocationName;
			[TagField(Length = 32)] public string RosterPlayer1BipedName;
			[TagField(Length = 32)] public string RosterPlayer1AiSquadName;
			public StringId RosterPlayer1AiLocationName;
			[TagField(Length = 32)] public string RosterPlayer2BipedName;
			[TagField(Length = 32)] public string RosterPlayer2AiSquadName;
			public StringId RosterPlayer2AiLocationName;
			[TagField(Length = 32)] public string RosterPlayer3BipedName;
			[TagField(Length = 32)] public string RosterPlayer3AiSquadName;
			public StringId RosterPlayer3AiLocationName;
			[TagField(Length = 32)] public string RosterPlayer4BipedName;
			[TagField(Length = 32)] public string RosterPlayer4AiSquadName;
			public StringId RosterPlayer4AiLocationName;
		}
	}
}
