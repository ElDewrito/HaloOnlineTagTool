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
	[TagStructure(Class = "txt3", Size = 0x40)]
	public class GuiTextWidgetDefinition
	{
		public uint Flags;
		public StringId Name;
		public short Unknown;
		public short Layer;
		public short WidescreenYBoundsMin;
		public short WidescreenXBoundsMin;
		public short WidescreenYBoundsMax;
		public short WidescreenXBoundsMax;
		public short StandardYBoundsMin;
		public short StandardXBoundsMin;
		public short StandardYBoundsMax;
		public short StandardXBoundsMax;
		public HaloTag Animation;
		public StringId DataSourceName;
		public StringId TextString;
		public StringId TextColor;
		public short TextFont;
		public short Unknown2;
		public uint Unknown3;
	}
}
