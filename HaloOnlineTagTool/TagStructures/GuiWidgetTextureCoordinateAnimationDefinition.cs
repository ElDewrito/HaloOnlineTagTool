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
	[TagStructure(Class = "wtuv", Size = 0x2C)]
	public class GuiWidgetTextureCoordinateAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Data;
		public uint Unknown;
		public uint Unknown2;

		[TagStructure(Size = 0x18)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public float CoordinateX;
			public float CoordinateY;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
