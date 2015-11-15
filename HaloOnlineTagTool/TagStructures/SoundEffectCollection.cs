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
		public uint Unknown2;

		[TagStructure(Size = 0x4C)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public List<UnknownBlock2> Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public List<UnknownBlock3> Unknown15;

			[TagStructure(Size = 0x48)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;
				public uint Unknown10;
				public uint Unknown11;
				public uint Unknown12;
				public uint Unknown13;
				public uint Unknown14;
				public uint Unknown15;
				public uint Unknown16;
				public uint Unknown17;
				public uint Unknown18;
			}

			[TagStructure(Size = 0x48)]
			public class UnknownBlock3
			{
				public HaloTag Unknown;
				public List<UnknownBlock> Unknown2;
				public List<UnknownBlock2> Unknown3;
				public uint Unknown4;
				public uint Unknown5;
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;
				public uint Unknown10;
				public uint Unknown11;

				[TagStructure(Size = 0x18)]
				public class UnknownBlock
				{
					public HaloTag Unknown;
					public uint Unknown2;
					public uint Unknown3;
				}

				[TagStructure(Size = 0x10)]
				public class UnknownBlock2
				{
					public uint Unknown;
					public List<UnknownBlock> Unknown2;

					[TagStructure(Size = 0x2C)]
					public class UnknownBlock
					{
						public uint Unknown;
						public uint Unknown2;
						public uint Unknown3;
						public uint Unknown4;
						public uint Unknown5;
						public uint Unknown6;
						public byte[] Unknown7;
					}
				}
			}
		}
	}
}
