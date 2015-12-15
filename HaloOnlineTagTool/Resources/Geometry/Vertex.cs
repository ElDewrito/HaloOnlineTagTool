using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;

namespace HaloOnlineTagTool.Resources.Geometry
{
    public class WorldVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
    }

    public class RigidVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
    }

    public class SkinnedVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public class ParticleModelVertex
    {
        public Vector3 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
    }

    public class FlatWorldVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
    }

    public class FlatRigidVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
    }

    public class FlatSkinnedVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public class ScreenVertex
    {
        public Vector2 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public uint Color { get; set; }
    }

    public class DebugVertex
    {
        public Vector3 Position { get; set; }
        public uint Color { get; set; }
    }

    public class TransparentVertex
    {
        public Vector3 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public uint Color { get; set; }
    }

    public class ParticleVertex
    {
    }

    public class ContrailVertex
    {
        public Vector4 Position { get; set; }
        public Vector4 Position2 { get; set; }
        public Vector4 Position3 { get; set; }
        public Vector4 Texcoord { get; set; }
        public Vector4 Texcoord2 { get; set; }
        public Vector2 Texcoord3 { get; set; }
        public uint Color { get; set; }
        public uint Color2 { get; set; }
        public Vector4 Position4 { get; set; }
    }

    public class LightVolumeVertex
    {
        public short[] Texcoord { get; set; }
    }

    public class ChudVertexSimple
    {
        public Vector2 Position { get; set; }
        public Vector2 Texcoord { get; set; }
    }

    public class ChudVertexFancy
    {
        public Vector3 Position { get; set; }
        public uint Color { get; set; }
        public Vector2 Texcoord { get; set; }
    }

    public class DecoratorVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector4 Normal { get; set; }
        /*public short[] Texcoord2 { get; set; }
        public Vector4 Texcoord3 { get; set; }
        public Vector4 Texcoord4 { get; set; }*/
    }

    public class TinyPositionVertex
    {
        public Vector4 Position { get; set; }
    }

    public class PatchyFogVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
    }

    public class WaterVertex
    {
        public Vector4 Position { get; set; }
        public Vector4 Position2 { get; set; }
        public Vector4 Position3 { get; set; }
        public Vector4 Position4 { get; set; }
        public Vector4 Position5 { get; set; }
        public Vector4 Position6 { get; set; }
        public Vector4 Position7 { get; set; }
        public Vector4 Position8 { get; set; }
        public Vector4 Texcoord { get; set; }
        public Vector3 Texcoord2 { get; set; }
        public Vector4 Normal { get; set; }
        public Vector4 Normal2 { get; set; }
        public Vector4 Normal3 { get; set; }
        public Vector4 Normal4 { get; set; }
        public Vector2 Normal5 { get; set; }
        public Vector3 Texcoord3 { get; set; }
    }

    public class RippleVertex
    {
        public Vector4 Position { get; set; }
        public Vector4 Texcoord { get; set; }
        public Vector4 Texcoord2 { get; set; }
        public Vector4 Texcoord3 { get; set; }
        public Vector4 Texcoord4 { get; set; }
        public Vector4 Texcoord5 { get; set; }
        public Vector4 Color { get; set; }
        public Vector4 Color2 { get; set; }
        public short[] Texcoord6 { get; set; }
    }

    public class ImplicitVertex
    {
        public Vector3 Position { get; set; }
        public Vector2 Texcoord { get; set; }
    }

    public class BeamVertex
    {
        public Vector4 Position { get; set; }
        public Vector4 Texcoord { get; set; }
        public Vector4 Texcoord2 { get; set; }
        public uint Color { get; set; }
        public Vector3 Position2 { get; set; }
        public short[] Texcoord3 { get; set; }
    }

    public class DualQuatVertex
    {
        public Vector4 Position { get; set; }
        public Vector2 Texcoord { get; set; }
        public Vector3 Normal { get; set; }
        public Vector4 Tangent { get; set; }
        public Vector3 Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public class StaticPerVertexColorData
    {
        public Vector3 Color { get; set; }
    }

    public class StaticPerPixelData
    {
        public Vector2 Texcoord { get; set; }
    }

    public class StaticPerVertexData
    {
        public Vector4 Texcoord { get; set; }
        public Vector4 Texcoord2 { get; set; }
        public Vector4 Texcoord3 { get; set; }
        public Vector4 Texcoord4 { get; set; }
        public Vector4 Texcoord5 { get; set; }
    }

    public class AmbientPrtData
    {
        public float Brightness { get; set; }
    }

    public class LinearPrtData
    {
        public Vector4 BlendWeight { get; set; }
    }

    public class QuadraticPrtData
    {
        public Vector3 BlendWeight { get; set; }
        public Vector3 BlendWeight2 { get; set; }
        public Vector3 BlendWeight3 { get; set; }
    }
}
