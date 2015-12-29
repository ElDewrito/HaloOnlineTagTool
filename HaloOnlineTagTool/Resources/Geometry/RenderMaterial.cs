using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// A material describing how a mesh part should be rendered.
    /// </summary>
    [TagStructure(Size = 0x24, MaxVersion = EngineVersion.V11_1_571627_Live)]
    [TagStructure(Size = 0x30, MinVersion = EngineVersion.V12_1_700123_cert_ms30_oct19)]
    public class RenderMaterial
    {
        /// <summary>
        /// Gets or sets the render method tag to use to render the material.
        /// </summary>
        public TagInstance RenderMethod;

        [MinVersion(EngineVersion.V12_1_700123_cert_ms30_oct19)] public List<Skin> Skins;
        public List<Property> Properties;
        public int Unknown;
        public sbyte BreakableSurfaceIndex;
        public sbyte Unknown2;
        public sbyte Unknown3;
        public sbyte Unknown4;

        [TagStructure(Size = 0x14)]
        public class Skin
        {
            public StringId Name;
            public TagInstance RenderMethod;
        }

        [TagStructure(Size = 0xC)]
        public class Property
        {
            public int Type;
            public int IntValue;
            public float RealValue;
        }
    }
}
