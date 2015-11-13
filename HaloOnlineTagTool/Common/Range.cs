using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Common
{
	public struct Range<T> : IEquatable<Range<T>> where T : IComparable<T>
	{
		/// <summary>
		/// Gets the minimum value within the range.
		/// </summary>
		public readonly T Min;

		/// <summary>
		/// Gets the maximum value within the range.
		/// </summary>
		public readonly T Max;

		/// <summary>
		/// Creates a new range from a minimum and a maximum value.
		/// </summary>
		/// <param name="min">The minimum value of the range.</param>
		/// <param name="max">The maximum value of the range.</param>
		public Range(T min, T max)
		{
			Min = min;
			Max = max;
		}

		/// <summary>
		/// Determines whether the range contains a value.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns><c>true</c> if the value is inside the range.</returns>
		public bool Contains(T value)
		{
			return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
		public bool Equals(Range<T> other)
		{
			return Min.Equals(other.Min) && Max.Equals(other.Max);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Range<T>))
				return false;
			return Equals((Range<T>)obj);
		}

		public static bool operator ==(Range<T> lhs, Range<T> rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Range<T> lhs, Range<T> rhs)
		{
			return !(lhs == rhs);
		}

		public override string ToString()
		{
			return string.Format("[{0}, {1}]", Min, Max);
		}

		public override int GetHashCode()
		{
			var hash = 11;
			hash = hash * 13 + Min.GetHashCode();
			hash = hash * 13 + Max.GetHashCode();
			return hash;
		}
	}
}