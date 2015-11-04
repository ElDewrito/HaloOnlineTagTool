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
	[TagStructure(Class = "pdm!", Size = 0x3C)]
	public class PodiumSettings
	{
		public float Unknown;
		public float Unknown2;
		public float Unknown3;
		public Angle Unknown4;
		public Angle Unknown5;
		public float Unknown6;
		public Angle Unknown7;
		public int Unknown8;
		public HaloTag Unknown9;
		public List<UnknownBlock> Unknown10;

		[TagStructure(Size = 0x2C)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public Angle Unknown4;
			public float Unknown5;
			public float Unknown6;
			public int Unknown7;
			public HaloTag Effect;
		}
	}
}
