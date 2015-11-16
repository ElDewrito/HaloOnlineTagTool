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
	[TagStructure(Class = "colo", Size = 0x10)]
	public class ColorTable
	{
		public List<ColorTableBlock> ColorTable2;
		public uint Unknown;

		[TagStructure(Size = 0x30)]
		public class ColorTableBlock
		{
			[TagField(Length = 32)] public string String;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
		}
	}
}
