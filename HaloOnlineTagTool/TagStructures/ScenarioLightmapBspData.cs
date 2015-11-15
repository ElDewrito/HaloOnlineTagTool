using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "Lbsp", Size = 0x1E4, MaxVersion = EngineVersion.V10_1_449175_Live)]
	[TagStructure(Class = "Lbsp", Size = 0x1E8, MinVersion = EngineVersion.V11_1_498295_Live)]
	public class ScenarioLightmapBspData
	{
		public short Unknown;
		public short BspIndex;
		public int StructureChecksum;
		public float Shadows;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Midtones;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		public float Unknown11;
		public float Highlights;
		public float Unknown12;
		public float Unknown13;
		public float Unknown14;
		public float Unknown15;
		public float Unknown16;
		public float TopDownWhites;
		public float Unknown17;
		public float Unknown18;
		public float Unknown19;
		public float Unknown20;
		public float Unknown21;
		public float TopDownBlacks;
		public float Unknown22;
		public float Unknown23;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;
		public float Unknown27;
		public float Unknown28;
		public float Unknown29;
		public float Unknown30;
		public float Unknown31;
		public float Unknown32;
		public float Unknown33;
		public float Unknown34;
		public float Unknown35;
		public float Unknown36;
		public float Unknown37;
		public float Unknown38;
		public float Unknown39;
		public float Unknown40;
		public float Unknown41;
		public float Unknown42;
		public float Unknown43;
		public float Unknown44;
		public float Unknown45;
		public float Unknown46;
		public float Unknown47;
		public float Unknown48;
		public float Unknown49;
		public float Unknown50;
		public HaloTag PrimaryMap;
		public HaloTag IntensityMap;
		public List<InstancedMesh> InstancedMeshes;
		public List<UnknownBlock> Unknown51;
		public List<InstancedGeometryBlock> InstancedGeometry;
		public List<UnknownBBlock> UnknownB;
		public GeometryReference Geometry;
		public float Unknown61;
		public float Unknown62;
		public float Unknown63;
		public List<UnknownBlock4> Unknown64;
		public List<UnknownBlock5> Unknown65;
		public float Unknown66;
		public float Unknown67;
		public float Unknown68;
		[MinVersion(EngineVersion.V11_1_498295_Live)] public float Unknown69; // TODO: Version number

		[TagStructure(Size = 0x10)]
		public class InstancedMesh
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public int UnknownIndex;
		}

		[TagStructure(Size = 0x4)]
		public class UnknownBlock
		{
			public short Unknown;
			public short Unknown2;
		}

		[TagStructure(Size = 0x8)]
		public class InstancedGeometryBlock
		{
			public short Unknown;
			public short InstancedMeshIndex;
			public short UnknownBIndex;
			public short Unknown2;
		}

		[TagStructure(Size = 0x48)]
		public class UnknownBBlock
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

		[TagStructure(Size = 0x50)]
		public class UnknownBlock4
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
		public class UnknownBlock5
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
