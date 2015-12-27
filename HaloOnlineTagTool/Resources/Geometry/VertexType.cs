using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
    /// <summary>
    /// Vertex types.
    /// </summary>
    public enum VertexType : byte
    {
        World,
        Rigid,
        Skinned,
        ParticleModel,
        FlatWorld,
        FlatRigid,
        FlatSkinned,
        Screen,
        Debug,
        Transparent,
        Particle,
        Contrail,
        LightVolume,
        SimpleChud,
        FancyChud,
        Decorator,
        TinyPosition,
        PatchyFog,
        Water,
        Ripple,
        Implicit,
        Beam,
        DualQuat
    }
}
