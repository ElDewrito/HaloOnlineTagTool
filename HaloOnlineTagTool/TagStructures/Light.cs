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
	[TagStructure(Class = "ligh", Size = 0x94)]
	public class Light
	{
		public uint Flags;
		public TypeValue Type;
		public short Unknown;
		public float LightRange;
		public float NearWidth;
		public float HeightStretch;
		public Angle FieldOfView;
		public StringId FunctionName;
		public StringId FunctionName2;
		public short Unknown2;
		public short Unknown3;
		public float Unknown4;
		public byte[] Function;
		public StringId FunctionName3;
		public StringId FunctionName4;
		public short Unknown5;
		public short Unknown6;
		public float Unknown7;
		public byte[] Function2;
		public HaloTag GelMap;
		public float Unknown8;
		public float Unknown9;
		public float Unknown10;
		public float Unknown11;
		public sbyte Unknown12;
		public sbyte Unknown13;
		public sbyte Unknown14;
		public sbyte Unknown15;
		public HaloTag LensFlare;

		public enum TypeValue : short
		{
			Sphere,
			Projective,
		}
	}
}
