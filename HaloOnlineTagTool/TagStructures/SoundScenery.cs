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
	[TagStructure(Class = "ssce", Size = 0x1C)]
	public class SoundScenery : GameObject
	{
		public float DistanceMin;
		public float DistanceMax;
		public Angle ConeAngleMin;
		public Angle ConeAngleMax;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
	}
}
