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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Vec3i(Point3i point)
        {
            return new Vec3i(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static implicit operator Point3i(Vec3i vec)
        {
            return new Point3i(vec.Item0, vec.Item1, vec.Item2);
        }

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
        public static Point3i operator +(Point3i pt)
        {
            return pt;
        }

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
            return new Point3i(-pt.X, -pt.Y, -pt.Z);
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
        public static Point3i operator +(Point3i p1, Point3i p2)
        {
            return new Point3i(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
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
            return new Point3i(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
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
            return new Point3i((int) (pt.X*scale), (int) (pt.Y*scale), (int) (pt.Z*scale));
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
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }

        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(x:{X} y:{Y} z:{Z})";
        }

        #endregion

    }
}
