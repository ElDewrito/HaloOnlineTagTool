using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Common
{
	/// <summary>
	/// An angle value.
	/// </summary>
	public struct Angle : IEquatable<Angle>, IComparable<Angle>
	{
		/// <summary>
		/// The value used to convert between degrees and radians.
		/// </summary>
		public const float UnitConversion = (float)(180.0 / Math.PI);

		/// <summary>
		/// Gets the angle's value in radians.
		/// </summary>
		public readonly float Radians;

		/// <summary>
		/// Gets the angle's value in degrees.
		/// </summary>
		public float Degrees { get { return Radians * UnitConversion; } }

		/// <summary>
		/// Creates a new angle from radians.
		/// </summary>
		/// <param name="radians">The radians of the angle.</param>
		/// <returns>The angle that was created.</returns>
		public static Angle FromRadians(float radians)
		{
			return new Angle(radians);
		}

		/// <summary>
		/// Creates a new angle from degrees.
		/// </summary>
		/// <param name="degrees">The degrees of the angle.</param>
		/// <returns>The angle that was created.</returns>
		public static Angle FromDegrees(float degrees)
		{
			return new Angle(degrees / UnitConversion);
		}

		private Angle(float radians)
		{
			Radians = radians;
		}

		public bool Equals(Angle other)
		{
			return Radians == other.Radians;
		}

		public override string ToString()
		{
			return string.Format("{0}deg ({1}rad)", Degrees, Radians);
		}

		public override int GetHashCode()
		{
			return Radians.GetHashCode();
		}

		public int CompareTo(Angle other)
		{
			return Radians.CompareTo(other.Radians);
		}
	}
}