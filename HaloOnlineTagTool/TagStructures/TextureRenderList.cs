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
	[TagStructure(Class = "trdf", Size = 0x48)]
	public class TextureRenderList
	{
		public List<Bitmap> Bitmaps;
		public List<Light> Lights;
		public List<Bink> Binks;
		public List<Mannequin> Mannequins;
		public List<Weapon> Weapons;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;

		[TagStructure(Size = 0x110)]
		public class Bitmap
		{
			public int Index;
			[TagField(Length = 256)] public string Filename;
			public int Unknown;
			public int Width;
			public int Height;
		}

		[TagStructure(Size = 0x1C)]
		public class Light
		{
			public List<UnknownBlock> Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;

			[TagStructure(Size = 0x28)]
			public class UnknownBlock
			{
				public float Unknown;
				public float Unknown2;
				public float Unknown3;
				public Angle Unknown4;
				public Angle Unknown5;
				public Angle Unknown6;
				public HaloTag Light;
			}
		}

		[TagStructure(Size = 0x30)]
		public class Bink
		{
			[TagField(Length = 32)] public string Name;
			public HaloTag Bink2;
		}

		[TagStructure(Size = 0x4C)]
		public class Mannequin
		{
			public int Unknown;
			public HaloTag Biped;
			public int Unknown2;
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
		}

		[TagStructure(Size = 0x64)]
		public class Weapon
		{
			[TagField(Length = 32)] public string Name;
			public HaloTag Weapon2;
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
		}
	}
}
