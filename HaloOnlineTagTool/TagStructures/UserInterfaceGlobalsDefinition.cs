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
	[TagStructure(Class = "wgtz", Size = 0x50)]
	public class UserInterfaceGlobalsDefinition
	{
		public HaloTag SharedUiGlobals;
		public HaloTag EditableSettings;
		public HaloTag MatchmakingHopperStrings;
		public List<ScreenWidget> ScreenWidgets;
		public HaloTag TextureRenderList;
		public float Unknown;

		[TagStructure(Size = 0x10)]
		public class ScreenWidget
		{
			public HaloTag Widget;
		}
	}
}
