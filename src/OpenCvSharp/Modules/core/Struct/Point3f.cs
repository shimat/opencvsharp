using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    // ReSharper disable once InconsistentNaming
    public struct Point3f : IEquatable<Point3f>
    {
        /// <summary>
        /// 
        /// </summary>
        public float X;

        /// <summary>
        /// 
        /// </summary>
        public float Y;

        /// <summary>
        /// 
        /// </summary>
        public float Z;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Cast

#pragma warning disable 1591

        public static explicit operator Point3i(Point3f self) => self.ToPoint3i();

        // ReSharper disable once InconsistentNaming
        public readonly Point3i ToPoint3i() => new ((int)X, (int)Y, (int)Z);

        public static implicit operator Point3f(Point3i point) => FromPoint3i(point);

        // ReSharper disable once InconsistentNaming
        public static Point3f FromPoint3i(Point3i point) => new (point.X, point.Y, point.Z);

        public static implicit operator Vec3f(Point3f self) => self.ToVec3f();

        // ReSharper disable once InconsistentNaming
        public readonly Vec3f ToVec3f() => new(X, Y, Z);

        public static implicit operator Point3f(Vec3f vec) => FromVec3f(vec);

        // ReSharper disable once InconsistentNaming
        public static Point3f FromVec3f(Vec3f vec) => new (vec.Item0, vec.Item1, vec.Item2);

#pragma warning restore 1591

        #endregion

        #region Operators

        #region == / !=

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the values of the X and Y properties of the two CvPoint objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Point3f lhs, Point3f rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint2D32f objects. The result specifies whether the values of the X or Y properties of the two CvPoint2D32f objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
        public static bool operator !=(Point3f lhs, Point3f rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -
        
        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point3f Plus() => this;

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point3f operator +(Point3f pt) => pt;

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point3f Negate() => new(-X, -Y, -Z);

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point3f operator -(Point3f pt) => pt.Negate();

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point3f Add(Point3f p) => new(X + p.X, Y + p.Y, Z + p.Z);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point3f operator +(Point3f p1, Point3f p2) => p1.Add(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point3f Subtract(Point3f p) => new(X - p.X, Y - p.Y, Z - p.Z);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point3f operator -(Point3f p1, Point3f p2) => p1.Subtract(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public readonly Point3f Multiply(double scale) 
            => new((float)(X * scale), (float)(Y * scale), (float)(Z * scale));

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Point3f operator *(Point3f pt, double scale) => pt.Multiply(scale);

        #endregion

        #endregion

        #region Override

        /// <inheritdoc />
        public readonly bool Equals(Point3f other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point3f other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
#else
            return HashCode.Combine(X, Y, Z);
#endif
        }

        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(x:{X} y:{Y} z:{Z})";
        }

        #endregion

    }
}