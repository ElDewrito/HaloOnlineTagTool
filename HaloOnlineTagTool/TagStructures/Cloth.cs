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
	[TagStructure(Class = "clwd", Size = 0x94)]
	public class Cloth
	{
		public uint Flags;
		public StringId MarkerAttachmentName;
		public StringId SecondMarkerAttachmentName;
		public HaloTag Shader;
		public short GridXDimension;
		public short GridYDimension;
		public float GridSpacingX;
		public float GridSpacingY;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public IntegrationTypeValue IntegrationType;
		public short NumberIterations;
		public float Weight;
		public float Drag;
		public float WindScale;
		public float WindFlappinessScale;
		public float LongestRod;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public List<Vertex> Vertices;
		public List<Index> Indices;
		public uint Unknown10;
		public uint Unknown11;
		public uint Unknown12;
		public List<Link> Links;

		public enum IntegrationTypeValue : short
		{
			Verlet,
		}

		[TagStructure(Size = 0x14)]
		public class Vertex
		{
			public float InitialPositionX;
			public float InitialPositionY;
			public float InitialPositionZ;
			public float UvI;
			public float UvJ;
		}

		[TagStructure(Size = 0x2)]
		public class Index
		{
			public short Index2;
		}

		[TagStructure(Size = 0x8)]
		public class Link
		{
			public short Index1;
			public short Index2;
			public float DefaultDistance;
		}
	}
}
