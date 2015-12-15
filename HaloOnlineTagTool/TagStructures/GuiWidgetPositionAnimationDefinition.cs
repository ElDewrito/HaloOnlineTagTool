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
    [TagStructure(Name = "gui_widget_position_animation_definition", Class = "wpos", Size = 0x24)]
    public class GuiWidgetPositionAnimationDefinition
    {
        public uint AnimationFlags;
        public List<AnimationDefinitionBlock> AnimationDefinition;
        public byte[] Data;

        [TagStructure(Size = 0x1C)]
        public class AnimationDefinitionBlock
        {
            public uint Frame;
            public float XPosition;
            public float YPosition;
            public float ZPosition;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
        }
    }
}
