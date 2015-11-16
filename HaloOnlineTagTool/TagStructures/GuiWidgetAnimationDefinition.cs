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
	[TagStructure(Class = "wgan", Size = 0x80)]
	public class GuiWidgetAnimationDefinition
	{
		public uint Unknown;
		public uint Unknown2;
		public HaloTag WidgetColor;
		public HaloTag WidgetPosition;
		public HaloTag WidgetRotation;
		public HaloTag WidgetScale;
		public HaloTag WidgetTextureCoordinate;
		public HaloTag WidgetSprite;
		public HaloTag WidgetFont;
		public uint Unknown3;
		public uint Unknown4;
	}
}
