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
	[TagStructure(Class = "mdl3", Size = 0x90)]
	public class GuiModelWidgetDefinition
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
		public List<Biped> Bipeds;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public List<UnknownBlock> Unknown9;
		public float Unknown10;
		public float Unknown11;
		public float Unknown12;
		public float Unknown13;
		public float Unknown14;
		public float Unknown15;
		public List<UnknownBlock2> Unknown16;
		public float Unknown17;
		public float Unknown18;
		public float Unknown19;

		[TagStructure(Size = 0xA0)]
		public class Biped
		{
			public StringId Biped2;
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
			public List<UnknownBlock> Unknown25;
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
			public class UnknownBlock
			{
				public byte[] Unknown;
			}
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock
		{
			public byte[] Unknown;
		}

		[TagStructure(Size = 0x14)]
		public class UnknownBlock2
		{
			public StringId Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
		}
	}
}
