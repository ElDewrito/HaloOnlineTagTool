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
    [TagStructure(Name = "gui_widget_rotation_animation_definition", Class = "wrot", Size = 0x2C)]
    public class GuiWidgetRotationAnimationDefinition
    {
        public uint AnimationFlags;
        public List<AnimationDefinitionBlock> AnimationDefinition;
        public byte[] Date;
        public uint Unknown;
        public uint Unknown2;

        [TagStructure(Size = 0x20)]
        public class AnimationDefinitionBlock
        {
            public uint Frame;
            public AnchorValue Anchor;
            public short Unknown;
            public float CustomAnchorX;
            public float CustomAnchorY;
            public float RotationAmount;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;

            public enum AnchorValue : short
            {
                Custom,
                Center,
                TopCenter,
                BottomCenter,
                LeftCenter,
                RightCenter,
                TopLeft,
                TopRight,
                BottomRight,
                BottomLeft,
            }
        }
    }
}
