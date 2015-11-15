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
	[TagStructure(Class = "wgtz", Size = 0x50, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "wgtz", Size = 0x60, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class UserInterfaceGlobalsDefinition
	{
		public HaloTag SharedUiGlobals;
		public HaloTag EditableSettings;
		public HaloTag MatchmakingHopperStrings;
		public List<ScreenWidget> ScreenWidgets;
		public HaloTag TextureRenderList;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public HaloTag SwearFilter; // TODO: Version number
		public uint Unknown;

		[TagStructure(Size = 0x10)]
		public class ScreenWidget
		{
			public HaloTag Widget;
		}
	}
}
