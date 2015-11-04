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
	[TagStructure(Class = "sLdT", Size = 0x50)]
	public class ScenarioLightmap
	{
		public float Unknown;
		public List<LightmapDataReference> LightmapDataReferences;
		public List<UnknownBlock> Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public List<UnknownBlock2> Unknown6;
		public List<UnknownBlock3> Unknown7;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		public float Unknown11;

		[TagStructure(Size = 0x10)]
		public class LightmapDataReference
		{
			public HaloTag LightmapData;
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock
		{
			public HaloTag Unknown;
		}

		[TagStructure(Size = 0x50)]
		public class UnknownBlock2
		{
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
		}

		[TagStructure(Size = 0x2C)]
		public class UnknownBlock3
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public List<UnknownBlock> Unknown9;

			[TagStructure(Size = 0x54)]
			public class UnknownBlock
			{
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
			}
		}
	}
}
