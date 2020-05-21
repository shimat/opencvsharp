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
        /// 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator Point3i(Point3f self)
        {
            return new Point3i((int)self.X, (int)self.Y, (int)self.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Point3f(Point3i point)
        {
            return new Point3f(point.X, point.Y, point.Z);
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Vec3f(Point3f point)
        {
            return new Vec3f(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static implicit operator Point3f(Vec3f vec)
        {
            return new Point3f(vec.Item0, vec.Item1, vec.Item2);
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
        public static bool operator ==(Point3f lhs, Point3f rhs)
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
        public static bool operator !=(Point3f lhs, Point3f rhs)
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
        public static Point3f operator +(Point3f pt)
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
        public static Point3f operator -(Point3f pt)
        {
            return new Point3f(-pt.X, -pt.Y, -pt.Z);
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
        public static Point3f operator +(Point3f p1, Point3f p2)
        {
            return new Point3f(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
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
        public static Point3f operator -(Point3f p1, Point3f p2)
        {
            return new Point3f(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
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
        public static Point3f operator *(Point3f pt, double scale)
        {
            return new Point3f((float) (pt.X*scale), (float) (pt.Y*scale), (float) (pt.Z*scale));
        }

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
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
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