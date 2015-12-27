using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// Mesh flags.
    /// </summary>
    [Flags]
    public enum MeshFlags : byte
    {
        None = 0,

        /// <summary>
        /// Indicates that the mesh has vertex colors instead of PRT data.
        /// </summary>
        VertexColors = 1 << 0,

        Unknown1 = 1 << 1,
        Unknown2 = 1 << 2,
        Unknown3 = 1 << 3,
        Unknown4 = 1 << 4,
        Unknown5 = 1 << 5,
        Unknown6 = 1 << 6,
        Unknown7 = 1 << 7
    }
}
