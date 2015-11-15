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
	[TagStructure(Class = "udlg", Size = 0x30)]
	public class Dialogue
	{
		public HaloTag GlobalDialogueInfo;
		public uint Flags;
		public List<Vocalization> Vocalizations;
		public StringId MissionDialogueDesignator;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;

		[TagStructure(Size = 0x18)]
		public class Vocalization
		{
			public ushort Flags;
			public short Unknown;
			public StringId Vocalization2;
			public HaloTag Sound;
		}
	}
}
