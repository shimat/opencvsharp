using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2d : IEquatable<Point2d>
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
        public const int SizeOf = sizeof (double) + sizeof (double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region Cast

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static explicit operator Point(Point2d self)
        {
            return new Point((int) self.X, (int) self.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Point2d(Point point)
        {
            return new Point2d(point.X, point.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Vec2d(Point2d point)
        {
            return new Vec2d(point.X, point.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static implicit operator Point2d(Vec2d vec)
        {
            return new Point2d(vec.Item0, vec.Item1);
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
        public static bool operator ==(Point2d lhs, Point2d rhs)
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
        public static bool operator !=(Point2d lhs, Point2d rhs)
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
        public static Point2d operator +(Point2d pt)
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
        public static Point2d operator -(Point2d pt)
        {
            return new Point2d(-pt.X, -pt.Y);
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
        public static Point2d operator +(Point2d p1, Point2d p2)
        {
            return new Point2d(p1.X + p2.X, p1.Y + p2.Y);
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
        public static Point2d operator -(Point2d p1, Point2d p2)
        {
            return new Point2d(p1.X - p2.X, p1.Y - p2.Y);
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
        public static Point2d operator *(Point2d pt, double scale)
        {
            return new Point2d((float) (pt.X*scale), (float) (pt.Y*scale));
        }

        #endregion

        #endregion

        #region Override

        /// <inheritdoc />
        public readonly bool Equals(Point2d other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point2d other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
        
        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(x:{X} y:{Y})";
        }

        #endregion

        #region Methods

#if LANG_JP
    /// <summary>
    /// 2点間の距離を求める
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static double Distance(Point2d p1, Point2d p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

#if LANG_JP
    /// <summary>
    /// 2点間の距離を求める
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
#endif
        public readonly double DistanceTo(Point2d p)
        {
            return Distance(this, p);
        }

#if LANG_JP
    /// <summary>
    /// ベクトルの内積を求める
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static double DotProduct(Point2d p1, Point2d p2)
        {
            return p1.X*p2.X + p1.Y*p2.Y;
        }

#if LANG_JP
    /// <summary>
    /// ベクトルの内積を求める
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
#endif
        public readonly double DotProduct(Point2d p)
        {
            return DotProduct(this, p);
        }

#if LANG_JP
    /// <summary>
    /// ベクトルの外積を求める
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static double CrossProduct(Point2d p1, Point2d p2)
        {
            return p1.X*p2.Y - p2.X*p1.Y;
        }

#if LANG_JP
    /// <summary>
    /// ベクトルの外積を求める
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
#endif
        public readonly double CrossProduct(Point2d p)
        {
            return CrossProduct(this, p);
        }

        #endregion
    }
}
