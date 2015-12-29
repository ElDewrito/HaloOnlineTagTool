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
    [TagStructure(Name = "user_interface_globals_definition", Class = "wgtz", Size = 0x50, MaxVersion = EngineVersion.V10_1_449175_Live)]
    [TagStructure(Name = "user_interface_globals_definition", Class = "wgtz", Size = 0x60, MinVersion = EngineVersion.V11_1_498295_Live)]
    public class UserInterfaceGlobalsDefinition
    {
        public TagInstance SharedUiGlobals;
        public TagInstance EditableSettings;
        public TagInstance MatchmakingHopperStrings;
        public List<ScreenWidget> ScreenWidgets;
        public TagInstance TextureRenderList;
        [MinVersion(EngineVersion.V11_1_498295_Live)] public TagInstance SwearFilter; // TODO: Version number
        public uint Unknown;

        [TagStructure(Size = 0x10)]
        public class ScreenWidget
        {
            public TagInstance Widget;
        }
    }
}
