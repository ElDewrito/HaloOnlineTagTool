using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Bitmaps;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "bitm", MaxVersion = EngineVersion.V1_106708_cert_ms23, Size = 0xB8)]
	[TagStructure(Class = "bitm", Size = 0xAC)]
	public class Bitmap
	{
		public int Unknown0;
		public int Unknown4;
		public int Unknown8;
		public int UnknownC;
		public int Unknown10;
		public int Unknown14;
		public List<TagBlock0> Unknown18;
		public List<TagBlock1> Unknown24;
		public List<TagBlock2> Unknown30;
		public int Unknown3C;
		public int Unknown40;
		public int Unknown44;
		public int Unknown48;
		public int Unknown4C;
		public int Unknown50;
		public int Unknown54;
		public int Unknown58;
		public int Unknown5C;
		public int Unknown60;
		public List<TagBlock4> Unknown64;
		public List<Image> Images;
		public int Unknown7C;
		public int Unknown80;
		public int Unknown84;
		public int Unknown88;
		public int Unknown8C;
		public int Unknown90;
		public int Unknown94;
		public int Unknown98;
		public List<BitmapResource> Resources;
		public int UnknownA8;
		[MaxVersion(EngineVersion.V1_106708_cert_ms23)] // TODO: Figure out a better version and if these values are ever even used in 106708
		public int UnknownAC;
		[MaxVersion(EngineVersion.V1_106708_cert_ms23)]
		public int UnknownB0;
		[MaxVersion(EngineVersion.V1_106708_cert_ms23)]
		public int UnknownB4;

		[TagStructure(Size = 0x8)]
		public class TagBlock0
		{
			public int Unknown0;
			public int Unknown4;
		}

		[TagStructure(Size = 0x28)]
		public class TagBlock1
		{
			public int Unknown0;
			public int Unknown4;
			public int Unknown8;
			public int UnknownC;
			public int Unknown10;
			public int Unknown14;
			public int Unknown18;
			public int Unknown1C;
			public int Unknown20;
			public int Unknown24;
		}

		[TagStructure(Size = 0x40)]
		public class TagBlock2
		{
			public int Unknown0;
			public int Unknown4;
			public int Unknown8;
			public int UnknownC;
			public int Unknown10;
			public int Unknown14;
			public int Unknown18;
			public int Unknown1C;
			public int Unknown20;
			public int Unknown24;
			public int Unknown28;
			public int Unknown2C;
			public int Unknown30;
			public List<TagBlock3> Unknown34;

			[TagStructure(Size = 0x20)]
			public class TagBlock3
			{
				public int Unknown0;
				public int Unknown4;
				public int Unknown8;
				public int UnknownC;
				public int Unknown10;
				public int Unknown14;
				public int Unknown18;
				public int Unknown1C;
			}
		}

		[TagStructure(Size = 0x40)]
		public class TagBlock4
		{
			public int Unknown0;
			public int Unknown4;
			public int Unknown8;
			public int UnknownC;
			public int Unknown10;
			public int Unknown14;
			public int Unknown18;
			public int Unknown1C;
			public int Unknown20;
			public int Unknown24;
			public int Unknown28;
			public int Unknown2C;
			public int Unknown30;
			public List<TagBlock5> Unknown34;

			[TagStructure(Size = 0x20)]
			public class TagBlock5
			{
				public int Unknown0;
				public int Unknown4;
				public int Unknown8;
				public int UnknownC;
				public int Unknown10;
				public int Unknown14;
				public int Unknown18;
				public int Unknown1C;
			}
		}

		[TagStructure(Size = 0x30)]
		public class Image
		{
			public int Signature;
			public short Width;
			public short Height;
			public sbyte Depth;
			public sbyte Unknown9;
			public BitmapType Type;
			public sbyte UnusedB;
			public BitmapFormat Format;
			public sbyte UnusedD;
			public BitmapFlags Flags;
			public short OriginX;
			public short OriginY;
			public sbyte MipmapCount;
			public sbyte Unknown15;
			public sbyte Unknown16;
			public sbyte Unknown17;
			public int DataOffset;
			public int DataSize;
			public int Unknown20;
			public int Unknown24;
			public int Unknown28;
			public int Unknown2C;
		}

		[TagStructure(Size = 0x8)]
		public class BitmapResource
		{
			public ResourceReference Resource;
			public int Unknown4;
		}
	}
}
