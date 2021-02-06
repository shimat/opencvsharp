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
    // ReSharper disable once InconsistentNaming
    public struct Point3i : IEquatable<Point3i>
    {
        /// <summary>
        /// 
        /// </summary>
        public int X;

        /// <summary>
        /// 
        /// </summary>
        public int Y;

        /// <summary>
        /// 
        /// </summary>
        public int Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Cast

#pragma warning disable 1591

        public static implicit operator Vec3i(Point3i point) => point.ToVec3i();

        // ReSharper disable once InconsistentNaming
        public Vec3i ToVec3i() => new(X, Y, Z);

        public static implicit operator Point3i(Vec3i vec) => FromVec3i(vec);

        // ReSharper disable once InconsistentNaming
        public static Point3i FromVec3i(Vec3i vec) => new(vec.Item0, vec.Item1, vec.Item2);

#pragma warning restore 1591

        #endregion

        #region Operators

        #region == / !=

#if LANG_JP
    /// <summary>
    /// == 演算子のオーバーロード。x,y座標値が等しければtrueを返す 
    /// </summary>
    /// <param name="lhs">左辺値</param>
    /// <param name="rhs">右辺値</param>
    /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the values of the X and Y properties of the two CvPoint objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(Point3i lhs, Point3i rhs)
        {
            return lhs.Equals(rhs);
        }

#if LANG_JP
    /// <summary>
    /// != 演算子のオーバーロード。x,y座標値が等しくなければtrueを返す 
    /// </summary>
    /// <param name="lhs">左辺値</param>
    /// <param name="rhs">右辺値</param>
    /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint2D32f objects. The result specifies whether the values of the X or Y properties of the two CvPoint2D32f objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
#endif
        public static bool operator !=(Point3i lhs, Point3i rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -

#if LANG_JP
    /// <summary>
    /// 単項プラス演算子
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
#endif
        public static Point3i operator +(Point3i pt) => pt;

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <returns></returns>
        public Point3i Plus() => this;

#if LANG_JP
    /// <summary>
    /// 単項マイナス演算子
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
#endif
        public static Point3i operator -(Point3i pt)
        {
            return pt.Negate();
        }

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <returns></returns>
        public Point3i Negate() => new (-X, -Y, -Z);

#if LANG_JP
    /// <summary>
    /// あるオフセットで点を移動させる
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static Point3i operator +(Point3i p1, Point3i p2)
        {
            return p1.Add(p2);
        }

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point3i Add(Point3i p)
        {
            return new (X + p.X, Y + p.Y, Z + p.Z);
        }

#if LANG_JP
    /// <summary>
    /// あるオフセットで点を移動させる
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static Point3i operator -(Point3i p1, Point3i p2)
        {
            return p1.Subtract(p2);
        }

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point3i Subtract(Point3i p)
        {
            return new (X - p.X, Y - p.Y, Z - p.Z);
        }

#if LANG_JP
    /// <summary>
    /// あるオフセットで点を移動させる
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
#endif
        public static Point3i operator *(Point3i pt, double scale)
        {
            return pt.Multiply(scale);
        }

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public Point3i Multiply(double scale)
        {
            return new ((int)(X * scale), (int)(Y * scale), (int)(Z * scale));
        }

        #endregion

        #endregion

        #region Override

        /// <inheritdoc />
        public readonly bool Equals(Point3i other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point3i other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
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
