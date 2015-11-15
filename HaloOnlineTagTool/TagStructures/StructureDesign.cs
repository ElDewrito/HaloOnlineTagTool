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
	[TagStructure(Class = "sddt", Size = 0x44)]
	public class StructureDesign
	{
		public int Unknown;
		public List<DesignMoppCode> DesignMoppCodes;
		public List<DesignShapes2Block> DesignShapes2;
		public List<WaterMoppCode> WaterMoppCodes;
		public List<WaterName> WaterNames;
		public List<UnderwaterDefinition> UnderwaterDefinitions;
		public uint Unknown2;

		[TagStructure(Size = 0x40)]
		public class DesignMoppCode
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public uint Unknown2;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float OffsetScale;
			public uint Unknown3;
			public int DataSize;
			public uint DataCapacity;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public sbyte Unknown7;
			public List<Datum> Data;
			public uint Unknown8;

			[TagStructure(Size = 0x1)]
			public class Datum
			{
				public byte DataByte;
			}
		}

		[TagStructure(Size = 0x14)]
		public class DesignShapes2Block
		{
			public StringId Name;
			public short Unknown;
			public short Unknown2;
			public List<Unknown2Block> Unknown2_2;

			[TagStructure(Size = 0x44)]
			public class Unknown2Block
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
			}
		}

		[TagStructure(Size = 0x40)]
		public class WaterMoppCode
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public uint Unknown2;
			public float OffsetX;
			public float OffsetY;
			public float OffsetZ;
			public float OffsetScale;
			public uint Unknown3;
			public int DataSize;
			public uint DataCapacity;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public sbyte Unknown7;
			public List<Datum> Data;
			public uint Unknown8;

			[TagStructure(Size = 0x1)]
			public class Datum
			{
				public byte DataByte;
			}
		}

		[TagStructure(Size = 0x4)]
		public class WaterName
		{
			public StringId Name;
		}

		[TagStructure(Size = 0x2C)]
		public class UnderwaterDefinition
		{
			public short WaterNameIndex;
			public short Unknown;
			public float FlowForceX;
			public float FlowForceY;
			public float FlowForceZ;
			public float FlowForceZ2;
			public List<UnknownBlock> Unknown2;
			public List<Triangle> Triangles;

			[TagStructure(Size = 0x10)]
			public class UnknownBlock
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
			}

			[TagStructure(Size = 0x24)]
			public class Triangle
			{
				public float _1X;
				public float _1Y;
				public float _1Z;
				public float _2X;
				public float _2Y;
				public float _2Z;
				public float _3X;
				public float _3Y;
				public float _3Z;
			}
		}
	}
}
