using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "mulg", Size = 0x18)]
	public class MultiplayerGlobals
	{
		[TagElement]
		public List<UniversalMultiplayerGlobals> UniversalGlobals { get; set; }

		// [runtime globals]
	}

	[TagStructure(Size = 0xD8)]
	public class UniversalMultiplayerGlobals
	{
		[TagElement(Offset = 0x20)]
		public List<ArmorSlot> HumanArmorSlots { get; set; }

		[TagElement(Offset = 0x2C)]
		public List<ArmorSlot> EliteArmorSlots { get; set; } 
	}

	[TagStructure(Size = 0x14)]
	public class ArmorSlot
	{
		[TagElement]
		public int NameStringId { get; set; }

		[TagElement]
		public int NameStringId2 { get; set; }

		[TagElement]
		public List<ArmorPiece> Pieces { get; set; } 
	}

	[TagStructure(Size = 0x30)]
	public class ArmorPiece
	{
		[TagElement]
		public int NameStringId { get; set; }

		[TagElement]
		public HaloTag Tag { get; set; }
	}
}
