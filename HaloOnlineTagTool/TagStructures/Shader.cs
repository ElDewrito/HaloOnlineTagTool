using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "rmsh", Size = 0x44)]
	public class Shader
	{
		[TagElement]
		public HaloTag ShaderBase { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown10 { get; set; }
		[TagElement]
        	public List<PredictedBitmaps> PredictedBitmap { get; set; }
		[TagElement]
        	public List<ShaderProperties> ShaderProperty { get; set; }
		[TagElement]
		public int Unknown34 { get; set; }
		[TagElement]
		public int Unknown38 { get; set; }
		[TagElement]
		public int Unknown3C { get; set; }
		[TagElement]
		public int Unknown40 { get; set; }

		[TagStructure(Size = 0x2)]
		public class TagBlock0
		{
			[TagElement]
			public short Unknown0 { get; set; }
		}

		[TagStructure(Size = 0x3C)]
        	public class PredictedBitmaps
		{
			[TagElement]
			public int Type { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public HaloTag Bitmap { get; set; }
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public int Unknown20 { get; set; }
			[TagElement]
			public int Unknown24 { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown30 { get; set; }

			[TagStructure(Size = 0x24)]
			public class TagBlock2
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
				[TagElement]
				public byte[] Unknown10 { get; set; }
			}
		}

		[TagStructure(Size = 0x84)]
        	public class ShaderProperties
		{
			[TagElement]
			public HaloTag Template { get; set; }
			[TagElement]
            		public List<ShaderMaps> ShaderMap { get; set; }
			[TagElement]
        		public List<TilingFalloffs> TilingFalloff { get; set; }
			[TagElement]
			public int Unknown28 { get; set; }
			[TagElement]
			public int Unknown2C { get; set; }
			[TagElement]
			public int Unknown30 { get; set; }
			[TagElement]
			public int Unknown34 { get; set; }
			[TagElement]
			public List<TagBlock6> Unknown38 { get; set; }
			[TagElement]
			public List<TagBlock7> Unknown44 { get; set; }
			[TagElement]
			public List<TagBlock8> Unknown50 { get; set; }
			[TagElement]
			public List<TagBlock9> Unknown5C { get; set; }
			[TagElement]
			public int Unknown68 { get; set; }
			[TagElement]
			public int Unknown6C { get; set; }
			[TagElement]
			public int Unknown70 { get; set; }
			[TagElement]
			public int Unknown74 { get; set; }
			[TagElement]
			public int Unknown78 { get; set; }
			[TagElement]
			public int Unknown7C { get; set; }
			[TagElement]
			public int Unknown80 { get; set; }

			[TagStructure(Size = 0x18)]
			public class ShaderMaps
			{
				[TagElement]
				public HaloTag BitmapCubeMapDetailMapOther { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
				[TagElement]
				public int TilingFalloffIndex { get; set; }
			}

			[TagStructure(Size = 0x10)]
			public class TilingFalloffs
			{
				[TagElement]
				public int UTilingRed { get; set; }
				[TagElement]
				public int VTilingGreen { get; set; }
				[TagElement]
				public int Blue { get; set; }
				[TagElement]
				public int Intensity { get; set; }
			}

			[TagStructure(Size = 0x2)]
			public class TagBlock6
			{
				[TagElement]
				public short Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x6)]
			public class TagBlock7
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public short Unknown4 { get; set; }
			}

			[TagStructure(Size = 0x4)]
			public class TagBlock8
			{
				[TagElement]
				public int Unknown0 { get; set; }
			}

			[TagStructure(Size = 0x24)]
			public class TagBlock9
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
				[TagElement]
				public byte[] Unknown10 { get; set; }
			}
		}
	}
}
