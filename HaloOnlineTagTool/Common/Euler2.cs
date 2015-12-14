using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Common
{
    public struct Euler2 : IEquatable<Euler2>
    {
        public Angle Yaw { get; }

        public Angle Pitch { get; }

        public Euler2(Angle yaw, Angle pitch)
        {
            Yaw = yaw;
            Pitch = pitch;
        }

        public bool Equals(Euler2 other) =>
            Yaw.Equals(other.Yaw) &&
            Pitch.Equals(other.Pitch);

        public override bool Equals(object obj) =>
            obj is Euler2 ?
                Equals((Euler2)obj) :
            false;

        public static bool operator ==(Euler2 a, Euler2 b) =>
            a.Equals(b);

        public static bool operator !=(Euler2 a, Euler2 b) =>
            !a.Equals(b);

        public override int GetHashCode() =>
            13 * 17 + Yaw.GetHashCode()
               * 17 + Pitch.GetHashCode();

        public override string ToString() =>
            $"{{ Yaw: {Yaw}, Pitch: {Pitch} }}";
    }
}
