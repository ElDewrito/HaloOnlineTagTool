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
	[TagStructure(Class = "sfx+", Size = 0x10)]
	public class SoundEffectCollection
	{
		public List<UnknownBlock> Unknown;
		public float Unknown2;

		[TagStructure(Size = 0x4C)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public List<UnknownBlock2> Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public List<UnknownBlock3> Unknown15;

			[TagStructure(Size = 0x48)]
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
			}

			[TagStructure(Size = 0x48)]
			public class UnknownBlock3
			{
				public HaloTag Unknown;
				public List<UnknownBlock> Unknown2;
				public List<UnknownBlock2> Unknown3;
				public float Unknown4;
				public float Unknown5;
				public float Unknown6;
				public float Unknown7;
				public float Unknown8;
				public float Unknown9;
				public float Unknown10;
				public float Unknown11;

				[TagStructure(Size = 0x18)]
				public class UnknownBlock
				{
					public HaloTag Unknown;
					public float Unknown2;
					public float Unknown3;
				}

				[TagStructure(Size = 0x10)]
				public class UnknownBlock2
				{
					public float Unknown;
					public List<UnknownBlock> Unknown2;

					[TagStructure(Size = 0x2C)]
					public class UnknownBlock
					{
						public float Unknown;
						public float Unknown2;
						public float Unknown3;
						public float Unknown4;
						public float Unknown5;
						public float Unknown6;
						public byte[] Unknown7;
					}
				}
			}
		}
	}
}
