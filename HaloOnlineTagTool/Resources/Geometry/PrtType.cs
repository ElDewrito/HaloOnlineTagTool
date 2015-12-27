using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// Precomputed radiance transfer (PRT) types.
    /// </summary>
    public enum PrtType : byte
    {
        None,
        Ambient,
        Linear,
        Quadratic
    }
}
