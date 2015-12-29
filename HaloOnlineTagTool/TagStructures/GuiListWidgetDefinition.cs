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
    [TagStructure(Name = "gui_list_widget_definition", Class = "lst3", Size = 0x70)]
    public class GuiListWidgetDefinition
    {
        public uint Flags;
        public StringId Name;
        public short Unknown;
        public short Layer;
        public short WidescreenYOffset;
        public short WidescreenXOffset;
        public short WidescreenYUnknown;
        public short WidescreenXUnknown;
        public short StandardYOffset;
        public short StandardXOffset;
        public short StandardYUnknown;
        public short StandardXUnknown;
        public TagInstance Animation;
        public StringId DataSourceName;
        public TagInstance Skin;
        public int RowCount;
        public List<ListWidgetItem> ListWidgetItems;
        public TagInstance UpArrowBitmap;
        public TagInstance DownArrowBitmap;

        [TagStructure(Size = 0x30)]
        public class ListWidgetItem
        {
            public uint Flags;
            public StringId Name;
            public short Unknown;
            public short Layer;
            public short WidescreenYOffset;
            public short WidescreenXOffset;
            public short WidescreenYUnknown;
            public short WidescreenXUnknown;
            public short StandardYOffset;
            public short StandardXOffset;
            public short StandardYUnknown;
            public short StandardXUnknown;
            public TagInstance Animation;
            public StringId Target;
        }
    }
}
