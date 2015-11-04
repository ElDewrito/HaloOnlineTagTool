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
	[TagStructure(Class = "ant!", Size = 0x50)]
	public class Antenna
	{
		public StringId AttachmentMarkerName;
		public HaloTag Bitmaps;
		public HaloTag Physics;
		public float Unknown;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public List<Vertex> Vertices;
		public float Unknown8;

		[TagStructure(Size = 0x40)]
		public class Vertex
		{
			public Angle AngleY;
			public Angle AngleP;
			public float Length;
			public short SequenceIndex;
			public short Unknown;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
			public float LodColorA;
			public float LodColorR;
			public float LodColorG;
			public float LodColorB;
			public float Width;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
		}
	}
}
