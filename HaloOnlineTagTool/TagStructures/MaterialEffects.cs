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
    [TagStructure(Name = "material_effects", Class = "foot", Size = 0xC)]
    public class MaterialEffects
    {
        public List<Effect> Effects;

        [TagStructure(Size = 0x24)]
        public class Effect
        {
            public List<OldMaterial> OldMaterials;
            public List<Sound> Sounds;
            public List<Effect2> Effects;

            [TagStructure(Size = 0x2C)]
            public class OldMaterial
            {
                public TagInstance Effect;
                public TagInstance Sound;
                public StringId MaterialName;
                public short GlobalMaterialIndex;
                public SweetenerModeValue SweetenerMode;
                public sbyte Unknown;
                public uint Unknown2;

                public enum SweetenerModeValue : sbyte
                {
                    SweetenerDefault,
                    SweetenerEnabled,
                    SweetenerDisabled,
                }
            }

            [TagStructure(Size = 0x2C)]
            public class Sound
            {
                public TagInstance Tag;
                public TagInstance SecondaryTag;
                public StringId MaterialName;
                public short GlobalMaterialIndex;
                public SweetenerModeValue SweetenerMode;
                public sbyte Unknown;
                public uint Unknown2;

                public enum SweetenerModeValue : sbyte
                {
                    SweetenerDefault,
                    SweetenerEnabled,
                    SweetenerDisabled,
                }
            }

            [TagStructure(Size = 0x2C)]
            public class Effect2
            {
                public TagInstance Tag;
                public TagInstance SecondaryTag;
                public StringId MaterialName;
                public short GlobalMaterialIndex;
                public SweetenerModeValue SweetenerMode;
                public sbyte Unknown;
                public uint Unknown2;

                public enum SweetenerModeValue : sbyte
                {
                    SweetenerDefault,
                    SweetenerEnabled,
                    SweetenerDisabled,
                }
            }
        }
    }
}
