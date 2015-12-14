using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Common
{
    public struct Euler3 : IEquatable<Euler3>
    {
        public Angle Yaw { get; }

        public Angle Pitch { get; }

        public Angle Roll { get; }


        public Euler3(Angle yaw, Angle pitch, Angle roll)
        {
            Yaw = yaw;
            Pitch = pitch;
            Roll = roll;
        }

        public bool Equals(Euler3 other) =>
            Yaw.Equals(other.Yaw) &&
            Pitch.Equals(other.Pitch) &&
            Roll.Equals(other.Roll);

        public override bool Equals(object obj) =>
            obj is Euler3 ?
                Equals((Euler3)obj) :
            false;

        public static bool operator ==(Euler3 a, Euler3 b) =>
            a.Equals(b);

        public static bool operator !=(Euler3 a, Euler3 b) =>
            !a.Equals(b);

        public override int GetHashCode() =>
            13 * 17 + Yaw.GetHashCode()
               * 17 + Pitch.GetHashCode()
               * 17 + Roll.GetHashCode();

        public override string ToString() =>
            $"{{ Yaw: {Yaw}, Pitch: {Pitch}, Roll: {Roll} }}";
    }
}
