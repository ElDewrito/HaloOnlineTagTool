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
	[TagStructure(Class = "pmov", Size = 0x2C)]
	public class ParticlePhysics
	{
		public HaloTag Unknown;
		public uint Unknown2;
		public List<UnknownBlock> Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;

		[TagStructure(Size = 0x18)]
		public class UnknownBlock
		{
			public uint Unknown;
			public List<UnknownBlock2> Unknown2;
			public uint Unknown3;
			public uint Unknown4;

			[TagStructure(Size = 0x24)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public uint Unknown2;
				public byte[] Unknown3;
				public uint Unknown4;
				public uint Unknown5;
			}
		}
	}
}
