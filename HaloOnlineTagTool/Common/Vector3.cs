using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Common
{
    /// <summary>
    /// A 3D vector.
    /// </summary>
    public struct Vector3 : IEquatable<Vector3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct from a 2D vector and a Z component.
        /// </summary>
        /// <param name="xy">The vector to obtain the X and Y components from.</param>
        /// <param name="z">The Z component.</param>
        public Vector3(Vector2 xy, float z)
        {
            X = xy.X;
            Y = xy.Y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> struct from an array of components.
        /// </summary>
        /// <param name="components">The components. Must contain at least three elements.</param>
        public Vector3(float[] components)
        {
            X = components[0];
            Y = components[1];
            Z = components[2];
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
        /// Gets the X and Y components of the vector as a 2D vector.
        /// </summary>
        public Vector2 XY { get { return new Vector2(X, Y); } }

        /// <summary>
        /// Gets an array containing the vector's components.
        /// </summary>
        /// <returns>An array containing the vector's components.</returns>
        public float[] ToArray()
        {
            return new[] { X, Y, Z };
        }

        /// <summary>
        /// Computes the squared length of the vector.
        /// </summary>
        /// <returns>The squared length of the vector.</returns>
        public float LengthSquared()
        {
            return X * X + Y * Y + Z * Z;
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
        public Vector3 Normalize()
        {
            return this / Length();
        }

        /// <summary>
        /// Computes the dot product of two vectors.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns>The dot product.</returns>
        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
        }

        /// <summary>
        /// Computes the cross product of two vectors.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns>The cross product.</returns>
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            var x = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            var y = lhs.Z * rhs.X - lhs.X * rhs.Z;
            var z = lhs.X * rhs.Y - lhs.Y * rhs.X;
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Computes the squared distance between two vectors.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns>The squared distance.</returns>
        public static float DistanceSquared(Vector3 lhs, Vector3 rhs)
        {
            var xDelta = lhs.X - rhs.X;
            var yDelta = lhs.Y - rhs.Y;
            var zDelta = lhs.Z - rhs.Z;
            return xDelta * xDelta + yDelta * yDelta + zDelta * zDelta;
        }

        /// <summary>
        /// Computes the distance between two vectors.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns>The distance.</returns>
        public static float Distance(Vector3 lhs, Vector3 rhs)
        {
            return (float)Math.Sqrt(DistanceSquared(lhs, rhs));
        }

        /// <summary>
        /// Implements the unary + operator.
        /// </summary>
        /// <param name="vec">The vector.</param>
        /// <returns>The vector.</returns>
        public static Vector3 operator +(Vector3 vec)
        {
            return vec;
        }

        /// <summary>
        /// Negates the components of a vector.
        /// </summary>
        /// <param name="vec">The vector.</param>
        /// <returns>The vector with all of its components negated.</returns>
        public static Vector3 operator -(Vector3 vec)
        {
            return new Vector3(-vec.X, -vec.Y, -vec.Z);
        }

        /// <summary>
        /// Adds the components of two vectors.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        /// <summary>
        /// Subtracts the components of two vectors.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns>The difference of the two vectors.</returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        /// <summary>
        /// Multiplies the components of the vector by a scalar.
        /// </summary>
        /// <param name="vec">The vector.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector3 operator *(Vector3 vec, float scale)
        {
            return new Vector3(vec.X * scale, vec.Y * scale, vec.Z * scale);
        }

        /// <summary>
        /// Multiplies the components of the vector by a scalar.
        /// </summary>
        /// <param name="scale">The scalar.</param>
        /// <param name="vec">The vector.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector3 operator *(float scale, Vector3 vec)
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
        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
        }

        /// <summary>
        /// Divides the components of the vector by a scalar.
        /// </summary>
        /// <param name="vec">The vector.</param>
        /// <param name="divisor">The scalar.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector3 operator /(Vector3 vec, float divisor)
        {
            return new Vector3(vec.X / divisor, vec.Y / divisor, vec.Z / divisor);
        }

        /// <summary>
        /// Compares two vectors for equality.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns><c>true</c> if the two vectors are equal.</returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs) =>
            lhs.Equals(rhs);

        /// <summary>
        /// Compares two vectors for inequality.
        /// </summary>
        /// <param name="lhs">The left-hand vector.</param>
        /// <param name="rhs">The right-hand vector.</param>
        /// <returns><c>true</c> if the two vectors are not equal.</returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs) =>
            !lhs.Equals(rhs);

        public bool Equals(Vector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object other)
        {
            if (!(other is Vector3))
                return false;
            return Equals((Vector3)other);
        }

        public override int GetHashCode() =>
            13 * 17 + X.GetHashCode()
               * 17 + Y.GetHashCode()
               * 17 + Z.GetHashCode();

        public override string ToString() =>
            $"{{ X: {X}, Y: {Y}, Z: {Z} }}";
    }
}
