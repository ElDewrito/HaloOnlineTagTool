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
	[TagStructure(Class = "prt3", Size = 0x1A0)]
	public class Particle
	{
		public uint Unknown;
		public List<UnknownBlock> Unknown2;
		public uint Unknown3;
		public byte[] Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public HaloTag BaseRenderMethod;
		public List<UnknownBlock2> Unknown10;
		public List<ImportDatum> ImportData;
		public List<ShaderProperty> ShaderProperties;
		public sbyte Unknown11;
		public sbyte Unknown12;
		public sbyte Unknown13;
		public sbyte Unknown14;
		public uint Unknown15;
		public int Unknown16;
		public sbyte Input;
		public sbyte InputRange;
		public OutputKindValue OutputKind;
		public sbyte Output;
		public byte[] Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public sbyte Input2;
		public sbyte InputRange2;
		public OutputKindValue2 OutputKind2;
		public sbyte Output2;
		public byte[] Unknown20;
		public uint Unknown21;
		public uint Unknown22;
		public sbyte Input3;
		public sbyte InputRange3;
		public OutputKindValue3 OutputKind3;
		public sbyte Output3;
		public byte[] Unknown23;
		public uint Unknown24;
		public uint Unknown25;
		public sbyte Input4;
		public sbyte InputRange4;
		public OutputKindValue4 OutputKind4;
		public sbyte Output4;
		public byte[] Unknown26;
		public uint Unknown27;
		public uint Unknown28;
		public uint Unknown29;
		public sbyte Input5;
		public sbyte InputRange5;
		public OutputKindValue5 OutputKind5;
		public sbyte Output5;
		public byte[] Unknown30;
		public uint Unknown31;
		public uint Unknown32;
		public sbyte Input6;
		public sbyte InputRange6;
		public OutputKindValue6 OutputKind6;
		public sbyte Output6;
		public byte[] Unknown33;
		public uint Unknown34;
		public uint Unknown35;
		public sbyte Input7;
		public sbyte InputRange7;
		public OutputKindValue7 OutputKind7;
		public sbyte Output7;
		public byte[] Unknown36;
		public uint Unknown37;
		public uint Unknown38;
		public HaloTag ParticleModel;
		public uint Unknown39;
		public uint Unknown40;
		public uint Unknown41;
		public List<UnknownBlock3> Unknown42;
		public List<UnknownBlock4> Unknown43;
		public uint Unknown44;
		public uint Unknown45;
		public uint Unknown46;

		[TagStructure(Size = 0x14)]
		public class UnknownBlock
		{
			public HaloTag Unknown;
			public uint Unknown2;
		}

		[TagStructure(Size = 0x2)]
		public class UnknownBlock2
		{
			public short Unknown;
		}

		[TagStructure(Size = 0x3C)]
		public class ImportDatum
		{
			public StringId MaterialType;
			public int Unknown;
			public HaloTag Bitmap;
			public uint Unknown2;
			public int Unknown3;
			public short Unknown4;
			public short Unknown5;
			public short Unknown6;
			public short Unknown7;
			public short Unknown8;
			public short Unknown9;
			public uint Unknown10;
			public List<Function> Functions;

			[TagStructure(Size = 0x24)]
			public class Function
			{
				public int Unknown;
				public StringId Name;
				public uint Unknown2;
				public uint Unknown3;
				public byte[] Function2;
			}
		}

		[TagStructure(Size = 0x84)]
		public class ShaderProperty
		{
			public HaloTag Template;
			public List<ShaderMap> ShaderMaps;
			public List<Argument> Arguments;
			public List<UnknownBlock> Unknown;
			public uint Unknown2;
			public List<UnknownBlock2> Unknown3;
			public List<UnknownBlock3> Unknown4;
			public List<UnknownBlock4> Unknown5;
			public List<Function> Functions;
			public int Unknown6;
			public int Unknown7;
			public uint Unknown8;
			public short Unknown9;
			public short Unknown10;
			public short Unknown11;
			public short Unknown12;
			public short Unknown13;
			public short Unknown14;
			public short Unknown15;
			public short Unknown16;

			[TagStructure(Size = 0x18)]
			public class ShaderMap
			{
				public HaloTag Bitmap;
				public sbyte Unknown;
				public sbyte BitmapIndex;
				public sbyte Unknown2;
				public byte BitmapFlags;
				public sbyte UnknownBitmapIndexEnable;
				public sbyte UvArgumentIndex;
				public sbyte Unknown3;
				public sbyte Unknown4;
			}

			[TagStructure(Size = 0x10)]
			public class Argument
			{
				public float Arg1;
				public float Arg2;
				public float Arg3;
				public float Arg4;
			}

			[TagStructure(Size = 0x4)]
			public class UnknownBlock
			{
				public uint Unknown;
			}

			[TagStructure(Size = 0x2)]
			public class UnknownBlock2
			{
				public short Unknown;
			}

			[TagStructure(Size = 0x6)]
			public class UnknownBlock3
			{
				public uint Unknown;
				public sbyte Unknown2;
				public sbyte Unknown3;
			}

			[TagStructure(Size = 0x4)]
			public class UnknownBlock4
			{
				public short Unknown;
				public short Unknown2;
			}

			[TagStructure(Size = 0x24)]
			public class Function
			{
				public int Unknown;
				public StringId Name;
				public uint Unknown2;
				public uint Unknown3;
				public byte[] Function2;
			}
		}

		public enum OutputKindValue : sbyte
		{
			None,
			Plus,
			Times,
		}

		public enum OutputKindValue2 : sbyte
		{
			None,
			Plus,
			Times,
		}

		public enum OutputKindValue3 : sbyte
		{
			None,
			Plus,
			Times,
		}

		public enum OutputKindValue4 : sbyte
		{
			None,
			Plus,
			Times,
		}

		public enum OutputKindValue5 : sbyte
		{
			None,
			Plus,
			Times,
		}

		public enum OutputKindValue6 : sbyte
		{
			None,
			Plus,
			Times,
		}

		public enum OutputKindValue7 : sbyte
		{
			None,
			Plus,
			Times,
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock3
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock4
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
		}
	}
}
