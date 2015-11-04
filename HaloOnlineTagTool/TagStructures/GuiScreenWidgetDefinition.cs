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
	[TagStructure(Class = "scn3", Size = 0xA8)]
	public class GuiScreenWidgetDefinition
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
		public HaloTag Strings;
		public HaloTag Parent;
		public StringId DefaultKeyLegendString;
		public List<DataSource> DataSources;
		public List<GroupWidget> GroupWidgets;
		public List<ButtonKeyLegend> ButtonKeyLegends;
		public HaloTag UiSounds;
		public string ScriptTitle;
		public short ScriptIndex;
		public short Unknown2;

		[TagStructure(Size = 0x10)]
		public class DataSource
		{
			public HaloTag DataSource2;
		}

		[TagStructure(Size = 0x6C)]
		public class GroupWidget
		{
			public HaloTag Parent;
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
			public HaloTag Animation;
			public List<ListWidget> ListWidgets;
			public List<TextWidget> TextWidgets;
			public List<BitmapWidget> BitmapWidgets;
			public List<ModelWidget> ModelWidgets;

			[TagStructure(Size = 0x80)]
			public class ListWidget
			{
				public HaloTag Parent;
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
				public HaloTag Animation;
				public StringId DataSourceName;
				public HaloTag Skin;
				public int Unknown2;
				public List<ListWidgetItem> ListWidgetItems;
				public HaloTag UpArrowBitmap;
				public HaloTag DownArrowBitmap;

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
					public HaloTag Animation;
					public StringId Target;
				}
			}

			[TagStructure(Size = 0x4C)]
			public class TextWidget
			{
				public HaloTag Parent;
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
			}

			[TagStructure(Size = 0x6C)]
			public class BitmapWidget
			{
				public HaloTag Parent;
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
				public HaloTag Bitmap;
				public HaloTag Unknown2;
				public BlendMethodValue BlendMethod;
				public short Unknown3;
				public short SpriteIndex;
				public short Unknown4;
				public StringId DataSourceName;
				public StringId SpriteDataSourceName;

				public enum BlendMethodValue : short
				{
					Standard,
					Unknown,
					Unknown2,
					Alpha,
					Overlay,
					Unknown3,
					LighterColor,
					Unknown4,
					Unknown5,
					Unknown6,
					InvertedAlpha,
					Unknown7,
					Unknown8,
					Unknown9,
				}
			}

			[TagStructure(Size = 0x94)]
			public class ModelWidget
			{
				public HaloTag Parent;
				public uint Flags;
				public StringId Name;
				public short Unknown;
				public short Unknown2;
				public short WidescreenYBoundsMin;
				public short WidescreenXBoundsMin;
				public short WidescreenYBoundsMax;
				public short WidescreenXBoundsMax;
				public short StandardYBoundsMin;
				public short StandardXBoundsMin;
				public short StandardYBoundsMax;
				public short StandardXBoundsMax;
				public HaloTag Animation;
				public List<UnknownBlock> Unknown3;
				public float Unknown4;
				public float Unknown5;
				public float Unknown6;
				public float Unknown7;
				public float Unknown8;
				public float Unknown9;
				public float Unknown10;
				public List<UnknownBlock2> Unknown11;
				public short Unknown12;
				public short Unknown13;
				public short Unknown14;
				public short Unknown15;
				public short Unknown16;
				public short Unknown17;
				public short Unknown18;
				public short Unknown19;
				public short Unknown20;
				public short Unknown21;
				public short Unknown22;
				public short Unknown23;
				public List<UnknownBlock3> Unknown24;

				[TagStructure(Size = 0xA0)]
				public class UnknownBlock
				{
					public StringId Biped;
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
					public List<UnknownBlock2> Unknown25;
					public float Unknown26;
					public float Unknown27;
					public Angle Unknown28;
					public float Unknown29;
					public Angle Unknown30;
					public float Unknown31;
					public float Unknown32;
					public HaloTag Unknown33;
					public float Unknown34;

					[TagStructure(Size = 0x14)]
					public class UnknownBlock2
					{
						public byte[] Unknown;
					}
				}

				[TagStructure(Size = 0x14)]
				public class UnknownBlock2
				{
					public byte[] Unknown;
				}

				[TagStructure(Size = 0x14)]
				public class UnknownBlock3
				{
					public StringId Unknown;
					public float Unknown2;
					public float Unknown3;
					public float Unknown4;
					public float Unknown5;
				}
			}
		}

		[TagStructure(Size = 0x10)]
		public class ButtonKeyLegend
		{
			public HaloTag Legend;
		}
	}
}
