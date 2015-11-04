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
	[TagStructure(Class = "cntl", Size = 0xC)]
	public class ContrailSystem
	{
		public List<ContrailSystemBlock> ContrailSystem2;

		[TagStructure(Size = 0x26C)]
		public class ContrailSystemBlock
		{
			public StringId Name;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public sbyte Input;
			public sbyte InputRange;
			public OutputKindValue OutputKind;
			public sbyte Output;
			public byte[] Unknown9;
			public float Unknown10;
			public float Unknown11;
			public sbyte Input2;
			public sbyte InputRange2;
			public OutputKindValue2 OutputKind2;
			public sbyte Output2;
			public byte[] Unknown12;
			public float Lifetime;
			public float Unknown13;
			public sbyte Input3;
			public sbyte InputRange3;
			public OutputKindValue3 OutputKind3;
			public sbyte Output3;
			public byte[] Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public float Unknown18;
			public float Unknown19;
			public float Unknown20;
			public float Unknown21;
			public float Unknown22;
			public sbyte Input4;
			public sbyte InputRange4;
			public OutputKindValue4 OutputKind4;
			public sbyte Output4;
			public byte[] Unknown23;
			public float Unknown24;
			public float Unknown25;
			public sbyte Input5;
			public sbyte InputRange5;
			public OutputKindValue5 OutputKind5;
			public sbyte Output5;
			public byte[] Unknown26;
			public float Unknown27;
			public float Unknown28;
			public float Unknown29;
			public float Unknown30;
			public float Unknown31;
			public float Unknown32;
			public sbyte Input6;
			public sbyte InputRange6;
			public OutputKindValue6 OutputKind6;
			public sbyte Output6;
			public byte[] Unknown33;
			public float Unknown34;
			public float Unknown35;
			public sbyte Input7;
			public sbyte InputRange7;
			public OutputKindValue7 OutputKind7;
			public sbyte Output7;
			public byte[] Unknown36;
			public float Unknown37;
			public float Unknown38;
			public float Unknown39;
			public HaloTag BaseRenderMethod;
			public List<UnknownBlock> Unknown40;
			public List<ImportDatum> ImportData;
			public List<ShaderProperty> ShaderProperties;
			public sbyte Unknown41;
			public sbyte Unknown42;
			public sbyte Unknown43;
			public sbyte Unknown44;
			public float Unknown45;
			public int Unknown46;
			public float TileY;
			public float TileX;
			public float ScrollSpeedY;
			public float ScrollSpeedX;
			public sbyte Input8;
			public sbyte InputRange8;
			public OutputKindValue8 OutputKind8;
			public sbyte Output8;
			public byte[] Unknown47;
			public float Unknown48;
			public float Unknown49;
			public sbyte Input9;
			public sbyte InputRange9;
			public OutputKindValue9 OutputKind9;
			public sbyte Output9;
			public byte[] Unknown50;
			public float Unknown51;
			public float Unknown52;
			public sbyte Input10;
			public sbyte InputRange10;
			public OutputKindValue10 OutputKind10;
			public sbyte Output10;
			public byte[] Unknown53;
			public float Unknown54;
			public float Unknown55;
			public sbyte Input11;
			public sbyte InputRange11;
			public OutputKindValue11 OutputKind11;
			public sbyte Output11;
			public byte[] Unknown56;
			public float Unknown57;
			public float Unknown58;
			public sbyte Input12;
			public sbyte InputRange12;
			public OutputKindValue12 OutputKind12;
			public sbyte Output12;
			public byte[] Unknown59;
			public float Unknown60;
			public float Unknown61;
			public sbyte Input13;
			public sbyte InputRange13;
			public OutputKindValue13 OutputKind13;
			public sbyte Output13;
			public byte[] Unknown62;
			public float Unknown63;
			public float Unknown64;
			public float Unknown65;
			public float Unknown66;
			public List<UnknownBlock2> Unknown67;
			public List<CompiledFunction> CompiledFunctions;
			public List<CompiledColorFunction> CompiledColorFunctions;

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

			[TagStructure(Size = 0x2)]
			public class UnknownBlock
			{
				public short Unknown;
			}

			[TagStructure(Size = 0x3C)]
			public class ImportDatum
			{
				public StringId MaterialType;
				public int Unknown;
				public HaloTag Bitmap;
				public float Unknown2;
				public int Unknown3;
				public short Unknown4;
				public short Unknown5;
				public short Unknown6;
				public short Unknown7;
				public short Unknown8;
				public short Unknown9;
				public float Unknown10;
				public List<Function> Functions;

				[TagStructure(Size = 0x24)]
				public class Function
				{
					public int Unknown;
					public StringId Name;
					public float Unknown2;
					public float Unknown3;
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
				public float Unknown2;
				public List<UnknownBlock2> Unknown3;
				public List<UnknownBlock3> Unknown4;
				public List<UnknownBlock4> Unknown5;
				public List<Function> Functions;
				public int Unknown6;
				public int Unknown7;
				public float Unknown8;
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
					public float Unknown;
				}

				[TagStructure(Size = 0x2)]
				public class UnknownBlock2
				{
					public short Unknown;
				}

				[TagStructure(Size = 0x6)]
				public class UnknownBlock3
				{
					public float Unknown;
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
					public float Unknown2;
					public float Unknown3;
					public byte[] Function2;
				}
			}

			public enum OutputKindValue8 : sbyte
			{
				None,
				Plus,
				Times,
			}

			public enum OutputKindValue9 : sbyte
			{
				None,
				Plus,
				Times,
			}

			public enum OutputKindValue10 : sbyte
			{
				None,
				Plus,
				Times,
			}

			public enum OutputKindValue11 : sbyte
			{
				None,
				Plus,
				Times,
			}

			public enum OutputKindValue12 : sbyte
			{
				None,
				Plus,
				Times,
			}

			public enum OutputKindValue13 : sbyte
			{
				None,
				Plus,
				Times,
			}

			[TagStructure(Size = 0x10)]
			public class UnknownBlock2
			{
				public float Unknown;
				public float Unknown2;
				public float Unknown3;
				public float Unknown4;
			}

			[TagStructure(Size = 0x40)]
			public class CompiledFunction
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
			}

			[TagStructure(Size = 0x10)]
			public class CompiledColorFunction
			{
				public float Red;
				public float Green;
				public float Blue;
				public float Magnitude;
			}
		}
	}
}
