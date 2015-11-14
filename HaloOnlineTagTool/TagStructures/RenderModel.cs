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
	[TagStructure(Class = "mode", Size = 0x1D0)]
	public class RenderModel
	{
		public StringId Name;
		public ushort Flags;
		public short Unknown6;
		public int Checksum;
		public List<Region> Regions;
		public int Unknown18;
		public int Unknown1C;
		public List<Flair> Flairs;
		public int Unknown2C;
		public List<Node> Nodes;
		public List<MarkerGroup> MarkerGroups;
		public List<Material> Materials;
		public int Unknown54;
		public int Unknown58;
		public int Unknown5C;
		public int Unknown60;
		public GeometryReference Geometry;
		public List<TagBlock17> UnknownE8;
		public int UnknownF4;
		public int UnknownF8;
		public int UnknownFC;
		public int Unknown100;
		public int Unknown104;
		public int Unknown108;
		public int Unknown10C;
		public int Unknown110;
		public int Unknown114;
		public int Unknown118;
		public int Unknown11C;
		public int Unknown120;
		public int Unknown124;
		public int Unknown128;
		public int Unknown12C;
		public int Unknown130;
		public int Unknown134;
		public int Unknown138;
		public int Unknown13C;
		public int Unknown140;
		public int Unknown144;
		public int Unknown148;
		public int Unknown14C;
		public int Unknown150;
		public int Unknown154;
		public int Unknown158;
		public int Unknown15C;
		public int Unknown160;
		public int Unknown164;
		public int Unknown168;
		public int Unknown16C;
		public int Unknown170;
		public int Unknown174;
		public int Unknown178;
		public int Unknown17C;
		public int Unknown180;
		public int Unknown184;
		public int Unknown188;
		public int Unknown18C;
		public int Unknown190;
		public int Unknown194;
		public int Unknown198;
		public int Unknown19C;
		public int Unknown1A0;
		public int Unknown1A4;
		public int Unknown1A8;
		public int Unknown1AC;
		public int Unknown1B0;
		public List<TagBlock18> Unknown1B4;
		public List<RuntimeNode> RuntimeNodes;
		public int Unknown1CC;

		/// <summary>
		/// A region of a model.
		/// </summary>
		[TagStructure(Size = 0x10)]
		public class Region
		{
			/// <summary>
			/// Gets or sets the name of the region as a stringID.
			/// </summary>
			public StringId Name;

			/// <summary>
			/// Gets or sets the permutations belonging to the region.
			/// </summary>
			public List<Permutation> Permutations;

			/// <summary>
			/// A permutation of a region, associating a specific mesh with it.
			/// </summary>
			[TagStructure(Size = 0x18)]
			public class Permutation
			{
				/// <summary>
				/// Gets or sets the name of the permutation as a stringID.
				/// </summary>
				public StringId Name;

				/// <summary>
				/// Gets or sets the index of the first mesh belonging to the permutation.
				/// </summary>
				public ushort MeshIndex;

				/// <summary>
				/// Gets or sets the number of meshes belonging to the permutation.
				/// </summary>
				public ushort MeshCount;

				public int Unknown8;
				public int UnknownC;
				public int Unknown10;
				public int Unknown14;
			}
		}

		[TagStructure(Size = 0x3C)]
		public class Flair
		{
			public StringId Name;
			public ushort Flags;
			public short NodeIndex;
			public float DefaultScale;
			public Vector3 InverseForward;
			public Vector3 InverseLeft;
			public Vector3 InverseUp;
			public Vector3 InversePosition;
		}

		[TagStructure(Size = 0x60)]
		public class Node
		{
			public StringId Name;
			public short ParentNode;
			public short FirstChildNode;
			public short NextSiblingNode;
			public short ImportNode;
			public Vector3 DefaultTranslation;
			public Vector4 DefaultRotation;
			public float DefaultScale;
			public Vector3 InverseForward;
			public Vector3 InverseLeft;
			public Vector3 InverseUp;
			public Vector3 InversePosition;
			public float DistanceFromParent;
		}

		[TagStructure(Size = 0x10)]
		public class MarkerGroup
		{
			public StringId Name;
			public List<Marker> Markers;

			[TagStructure(Size = 0x24)]
			public class Marker
			{
				public sbyte RegionIndex;
				public sbyte PermutationIndex;
				public sbyte NodeIndex;
				public sbyte Unknown3;
				public Vector3 Translation;
				public Vector4 Rotation;
				public float Scale;
			}
		}

		/// <summary>
		/// A material describing how a mesh part should be rendered.
		/// </summary>
		[TagStructure(Size = 0x24)]
		public class Material
		{
			/// <summary>
			/// Gets or sets the render method tag to use to render the material.
			/// </summary>
			public HaloTag RenderMethod;

			public int Unknown10;
			public int Unknown14;
			public int Unknown18;
			public int Unknown1C;
			public sbyte BreakableSurfaceIndex;
			public sbyte Unknown21;
			public sbyte Unknown22;
			public sbyte Unknown23;
		}

		[TagStructure(Size = 0x1C)]
		public class TagBlock17
		{
			public int Unknown0;
			public int Unknown4;
			public int Unknown8;
			public int UnknownC;
			public int Unknown10;
			public int Unknown14;
			public int Unknown18;
		}

		[TagStructure(Size = 0x150)]
		public class TagBlock18
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
			public int Unknown34;
			public int Unknown38;
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
			public int Unknown64;
			public int Unknown68;
			public int Unknown6C;
			public int Unknown70;
			public int Unknown74;
			public int Unknown78;
			public int Unknown7C;
			public int Unknown80;
			public int Unknown84;
			public int Unknown88;
			public int Unknown8C;
			public int Unknown90;
			public int Unknown94;
			public int Unknown98;
			public int Unknown9C;
			public int UnknownA0;
			public int UnknownA4;
			public int UnknownA8;
			public int UnknownAC;
			public int UnknownB0;
			public int UnknownB4;
			public int UnknownB8;
			public int UnknownBC;
			public int UnknownC0;
			public int UnknownC4;
			public int UnknownC8;
			public int UnknownCC;
			public int UnknownD0;
			public int UnknownD4;
			public int UnknownD8;
			public int UnknownDC;
			public int UnknownE0;
			public int UnknownE4;
			public int UnknownE8;
			public int UnknownEC;
			public int UnknownF0;
			public int UnknownF4;
			public int UnknownF8;
			public int UnknownFC;
			public int Unknown100;
			public int Unknown104;
			public int Unknown108;
			public int Unknown10C;
			public int Unknown110;
			public int Unknown114;
			public int Unknown118;
			public int Unknown11C;
			public int Unknown120;
			public int Unknown124;
			public int Unknown128;
			public int Unknown12C;
			public int Unknown130;
			public int Unknown134;
			public int Unknown138;
			public int Unknown13C;
			public int Unknown140;
			public int Unknown144;
			public int Unknown148;
			public int Unknown14C;
		}

		[TagStructure(Size = 0x20)]
		public class RuntimeNode
		{
			public Vector4 Rotation;
			public Vector3 Translation;
			public float Scale;
		}
	}
}
