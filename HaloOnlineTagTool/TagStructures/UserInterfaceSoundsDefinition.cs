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
	[TagStructure(Class = "uise", Size = 0x150)]
	public class UserInterfaceSoundsDefinition
	{
		public HaloTag Error;
		public HaloTag VerticalNavigation;
		public HaloTag HorizontalNavigation;
		public HaloTag AButton;
		public HaloTag BButton;
		public HaloTag XButton;
		public HaloTag YButton;
		public HaloTag StartButton;
		public HaloTag BackButton;
		public HaloTag LeftBumper;
		public HaloTag RightBumper;
		public HaloTag LeftTrigger;
		public HaloTag RightTrigger;
		public HaloTag TimerSound;
		public HaloTag TimerSoundZero;
		public HaloTag AltTimerSound;
		public HaloTag SecondAltTimerSound;
		public HaloTag MatchmakingAdvanceSound;
		public HaloTag RankUp;
		public HaloTag MatchmakingPartyUpSound;
		public List<AtlasSound> AtlasSounds;
		public uint Unknown;

		[TagStructure(Size = 0x14)]
		public class AtlasSound
		{
			public StringId Name;
			public HaloTag Sound;
		}
	}
}
