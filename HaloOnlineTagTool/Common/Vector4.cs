using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Common
{
	/// <summary>
	/// A 4D vector.
	/// </summary>
	public struct Vector4 : IEquatable<Vector4>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector4"/> struct.
		/// </summary>
		/// <param name="x">The X component.</param>
		/// <param name="y">The Y component.</param>
		/// <param name="z">The Z component.</param>
		/// <param name="w">The W component.</param>
		public Vector4(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector4"/> struct from an array of components.
		/// </summary>
		/// <param name="components">The components. Must contain at least four elements.</param>
		public Vector4(float[] components)
		{
			X = components[0];
			Y = components[1];
			Z = components[2];
			W = components[3];
		}

		/// <summary>
		/// Gets the X component of the vector.
		/// </summary>
		public readonly float X;

		/// <summary>
		/// Gets the Y component of the vector.
		/// </summary>
		public readonly float Y;

		/// <summary>
		/// Gets the Z component of the vector.
		/// </summary>
		public readonly float Z;

		/// <summary>
		/// Gets the W component of the vector.
		/// </summary>
		public readonly float W;

		/// <summary>
		/// Gets an array containing the vector's components.
		/// </summary>
		/// <returns>An array containing the vector's components.</returns>
		public float[] ToArray()
		{
			return new[] { X, Y, Z, W };
		}

		/// <summary>
		/// Computes the squared length of the vector.
		/// </summary>
		/// <returns>The squared length of the vector.</returns>
		public float LengthSquared()
		{
			return X * X + Y * Y + Z * Z + W * W;
		}

		/// <summary>
		/// Computes the length of the vector.
		/// </summary>
		/// <returns>The length of the vector.</returns>
		public float Length()
		{
			return (float)Math.Sqrt(LengthSquared());
		}

		/// <summary>
		/// Computes the normalization of the vector.
		/// </summary>
		/// <returns>The normalized vector.</returns>
		public Vector4 Normalize()
		{
			return this / Length();
		}

		/// <summary>
		/// Computes the dot product of two vectors.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns>The dot product.</returns>
		public static float Dot(Vector4 lhs, Vector4 rhs)
		{
			return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z + lhs.W * rhs.W;
		}

		/// <summary>
		/// Computes the squared distance between two vectors.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns>The squared distance.</returns>
		public static float DistanceSquared(Vector4 lhs, Vector4 rhs)
		{
			var xDelta = lhs.X - rhs.X;
			var yDelta = lhs.Y - rhs.Y;
			var zDelta = lhs.Z - rhs.Z;
			var wDelta = lhs.W - rhs.W;
			return xDelta * xDelta + yDelta * yDelta + zDelta * zDelta + wDelta * wDelta;
		}

		/// <summary>
		/// Computes the distance between two vectors.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns>The distance.</returns>
		public static float Distance(Vector4 lhs, Vector4 rhs)
		{
			return (float)Math.Sqrt(DistanceSquared(lhs, rhs));
		}

		/// <summary>
		/// Implements the unary + operator.
		/// </summary>
		/// <param name="vec">The vector.</param>
		/// <returns>The vector.</returns>
		public static Vector4 operator+(Vector4 vec)
		{
			return vec;
		}

		/// <summary>
		/// Negates the components of a vector.
		/// </summary>
		/// <param name="vec">The vector.</param>
		/// <returns>The vector with all of its components negated.</returns>
		public static Vector4 operator-(Vector4 vec)
		{
			return new Vector4(-vec.X, -vec.Y, -vec.Z, -vec.W);
		}

		/// <summary>
		/// Adds the components of two vectors.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns>The sum of the two vectors.</returns>
		public static Vector4 operator+(Vector4 lhs, Vector4 rhs)
		{
			return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
		}

		/// <summary>
		/// Subtracts the components of two vectors.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns>The difference of the two vectors.</returns>
		public static Vector4 operator-(Vector4 lhs, Vector4 rhs)
		{
			return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
		}

		/// <summary>
		/// Multiplies the components of the vector by a scalar.
		/// </summary>
		/// <param name="vec">The vector.</param>
		/// <param name="scale">The scalar.</param>
		/// <returns>The scaled vector.</returns>
		public static Vector4 operator*(Vector4 vec, float scale)
		{
			return new Vector4(vec.X * scale, vec.Y * scale, vec.Z * scale, vec.W * scale);
		}

		/// <summary>
		/// Multiplies the components of the vector by a scalar.
		/// </summary>
		/// <param name="scale">The scalar.</param>
		/// <param name="vec">The vector.</param>
		/// <returns>The scaled vector.</returns>
		public static Vector4 operator*(float scale, Vector4 vec)
		{
			return vec * scale;
		}

		/// <summary>
		/// Components the component-wise multiplication (Hadamard product) of
		/// two vectors.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns>The component-wise multiplication.</returns>
		public static Vector4 operator*(Vector4 lhs, Vector4 rhs)
		{
			return new Vector4(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z, lhs.W * rhs.W);
		}

		/// <summary>
		/// Divides the components of the vector by a scalar.
		/// </summary>
		/// <param name="vec">The vector.</param>
		/// <param name="divisor">The scalar.</param>
		/// <returns>The scaled vector.</returns>
		public static Vector4 operator/(Vector4 vec, float divisor)
		{
			return new Vector4(vec.X / divisor, vec.Y / divisor, vec.Z / divisor, vec.W / divisor);
		}

		/// <summary>
		/// Compares two vectors for equality.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns><c>true</c> if the two vectors are equal.</returns>
		public static bool operator==(Vector4 lhs, Vector4 rhs)
		{
			return lhs.Equals(rhs);
		}

		/// <summary>
		/// Compares two vectors for inequality.
		/// </summary>
		/// <param name="lhs">The left-hand vector.</param>
		/// <param name="rhs">The right-hand vector.</param>
		/// <returns><c>true</c> if the two vectors are not equal.</returns>
		public static bool operator!=(Vector4 lhs, Vector4 rhs)
		{
			return !(lhs == rhs);
		}

		public bool Equals(Vector4 other)
		{
			return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
		}

		public override bool Equals(object other)
		{
			if (!(other is Vector4))
				return false;
			return Equals((Vector4)other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var result = 13;
				result = result * 17 + X.GetHashCode();
				result = result * 17 + Y.GetHashCode();
				result = result * 17 + Z.GetHashCode();
				result = result * 17 + W.GetHashCode();
				return result;
			}
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}", X, Y, Z, W);
		}
	}
}
