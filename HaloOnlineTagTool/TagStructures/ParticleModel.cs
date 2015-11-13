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
	[TagStructure(Class = "pmdf", Size = 0x90)]
	public class ParticleModel
	{
		public int Unknown;
		public List<Mesh> Meshes;
		public List<CompressionInfoBlock> CompressionInfo;
		public List<UnknownNodeyBlock> UnknownNodey;
		public List<UnknownBlock> Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public List<UnknownMesh> UnknownMeshes;
		public List<NodeMap> NodeMaps;
		public List<UnknownBlock2> Unknown6;
		public float Unknown7;
		public float Unknown8;
		public float Unknown9;
		public List<UnknownYoBlock> UnknownYo;
		public ResourceReference Resource;
		public int UselessPadding;
		public List<UnknownBlock3> Unknown10;

		[TagStructure(Size = 0x2C)]
		public class CompressionInfoBlock
		{
			public short Unknown;
			public short Unknown2;
			public float PositionBoundsXMin;
			public float PositionBoundsXMax;
			public float PositionBoundsYMin;
			public float PositionBoundsYMax;
			public float PositionBoundsZMin;
			public float PositionBoundsZMax;
			public float TexcoordBoundsXMin;
			public float TexcoordBoundsXMax;
			public float TexcoordBoundsYMin;
			public float TexcoordBoundsYMax;
		}

		[TagStructure(Size = 0x30)]
		public class UnknownNodeyBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public sbyte NodeIndex;
			public sbyte NodeIndex2;
			public sbyte NodeIndex3;
			public sbyte NodeIndex4;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
		}

		[TagStructure(Size = 0x18)]
		public class UnknownBlock
		{
			public short Unknown;
			public short Unknown2;
			public byte[] Unknown3;
		}

		[TagStructure(Size = 0x20)]
		public class UnknownMesh
		{
			public byte[] Unknown;
			public List<UnknownBlock> Unknown2;

			[TagStructure(Size = 0x2)]
			public class UnknownBlock
			{
				public short Unknown;
			}
		}

		[TagStructure(Size = 0xC)]
		public class NodeMap
		{
			public List<UnknownBlock> Unknown;

			[TagStructure(Size = 0x1)]
			public class UnknownBlock
			{
				public byte NodeIndex;
			}
		}

		[TagStructure(Size = 0xC)]
		public class UnknownBlock2
		{
			public List<UnknownBlock> Unknown;

			[TagStructure(Size = 0x30)]
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
			}
		}

		[TagStructure(Size = 0x10)]
		public class UnknownYoBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public short UnknownIndex;
			public short Unknown4;
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock3
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
		}
	}
}
