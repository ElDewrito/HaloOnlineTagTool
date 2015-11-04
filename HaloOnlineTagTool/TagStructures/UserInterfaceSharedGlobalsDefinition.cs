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
		public string UiEliteBipedName;
		public string UiEliteAiSquadName;
		public StringId UiEliteAiLocationName;
		public string UiOdst1BipedName;
		public string UiOdst1AiSquadName;
		public StringId UiOdst1AiLocationName;
		public string UiMickeyBipedName;
		public string UiMickeyAiSquadName;
		public StringId UiMickeyAiLocationName;
		public string UiRomeoBipedName;
		public string UiRomeoAiSquadName;
		public StringId UiRomeoAiLocationName;
		public string UiDutchBipedName;
		public string UiDutchAiSquadName;
		public StringId UiDutchAiLocationName;
		public string UiJohnsonBipedName;
		public string UiJohnsonAiSquadName;
		public StringId UiJohnsonAiLocationName;
		public string UiOdst2BipedName;
		public string UiOdst2AiSquadName;
		public StringId UiOdst2AiLocationName;
		public string UiOdst3BipedName;
		public string UiOdst3AiSquadName;
		public StringId UiOdst3AiLocationName;
		public string UiOdst4BipedName;
		public string UiOdst4AiSquadName;
		public StringId UiOdst4AiLocationName;
		public int SingleScrollSpeed;
		public int ScrollSpeedTransitionWaitTime;
		public int HeldScrollSpeed;
		public int AttractVideoIdleWait;
		public byte[] Unknown;
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
			public string AppearanceBipedName;
			public string AppearanceAiSquadName;
			public StringId AppearanceAiLocationName;
			public string RosterPlayer1BipedName;
			public string RosterPlayer1AiSquadName;
			public StringId RosterPlayer1AiLocationName;
			public string RosterPlayer2BipedName;
			public string RosterPlayer2AiSquadName;
			public StringId RosterPlayer2AiLocationName;
			public string RosterPlayer3BipedName;
			public string RosterPlayer3AiSquadName;
			public StringId RosterPlayer3AiLocationName;
			public string RosterPlayer4BipedName;
			public string RosterPlayer4AiSquadName;
			public StringId RosterPlayer4AiLocationName;
		}
	}
}
