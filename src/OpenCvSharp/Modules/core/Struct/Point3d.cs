using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point3d : IEquatable<Point3d>
    {
        /// <summary>
        /// 
        /// </summary>
        public double X;

        /// <summary>
        /// 
        /// </summary>
        public double Y;

        /// <summary>
        /// 
        /// </summary>
        public double Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Cast

#pragma warning disable 1591

        public static explicit operator Point3i(Point3d self) => self.ToPoint3i();

        // ReSharper disable once InconsistentNaming
        public readonly Point3i ToPoint3i() => new((int)X, (int)Y, (int)Z);

        public static implicit operator Point3d(Point3i point) => FromPoint3i(point);

        // ReSharper disable once InconsistentNaming
        public static Point3d FromPoint3i(Point3i point) => new(point.X, point.Y, point.Z);

        public static implicit operator Vec3d(Point3d self) => self.ToVec3d();

        // ReSharper disable once InconsistentNaming
        public readonly Vec3d ToVec3d() => new(X, Y, Z);

        public static implicit operator Point3d(Vec3d vec) => FromVec3d(vec);

        // ReSharper disable once InconsistentNaming
        public static Point3d FromVec3d(Vec3d vec) => new(vec.Item0, vec.Item1, vec.Item2);

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
        public static bool operator ==(Point3d lhs, Point3d rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint2D32f objects. The result specifies whether the values of the X or Y properties of the two CvPoint2D32f objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
        public static bool operator !=(Point3d lhs, Point3d rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point3d operator +(Point3d pt) => pt;

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point3d Plus() => this;

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point3d operator -(Point3d pt) => pt.Negate();

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point3d Negate() => new(-X, -Y, -Z);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point3d operator +(Point3d p1, Point3d p2) => p1.Add(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point3d Add(Point3d p) => new(X + p.X, Y + p.Y, Z + p.Z);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point3d operator -(Point3d p1, Point3d p2) => p1.Subtract(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point3d Subtract(Point3d p) => new(X - p.X, Y - p.Y, Z - p.Z);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Point3d operator *(Point3d pt, double scale) => pt.Multiply(scale);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public readonly Point3d Multiply(double scale) => new(X * scale, Y * scale, Z * scale);

        #endregion

        #endregion

        #region Override

        /// <inheritdoc />
        public readonly bool Equals(Point3d other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point3d other && Equals(other);
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
