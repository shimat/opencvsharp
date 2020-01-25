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
    public struct Point : IEquatable<Point>
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = (int) x;
            Y = (int) y;
        }

        #region Cast

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Vec2i(Point point)
        {
            return new Vec2i(point.X, point.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static implicit operator Point(Vec2i vec)
        {
            return new Point(vec.Item0, vec.Item1);
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
        /// Compares two Point objects. The result specifies whether the values of the X and Y properties of the two Point objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(Point lhs, Point rhs)
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
        /// Compares two Point objects. The result specifies whether the values of the X or Y properties of the two Point objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
#endif
        public static bool operator !=(Point lhs, Point rhs)
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
        public static Point operator +(Point pt)
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
        public static Point operator -(Point pt)
        {
            return new Point(-pt.X, -pt.Y);
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
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
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
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
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
        public static Point operator *(Point pt, double scale)
        {
            return new Point((int) (pt.X*scale), (int) (pt.Y*scale));
        }

        #endregion

        #endregion

        #region Override
        
        /// <inheritdoc />
        public readonly bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
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
        public static double Distance(Point p1, Point p2)
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
        public readonly double DistanceTo(Point p)
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
        public static double DotProduct(Point p1, Point p2)
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
        public readonly double DotProduct(Point p)
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
        public static double CrossProduct(Point p1, Point p2)
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
        public readonly double CrossProduct(Point p)
        {
            return CrossProduct(this, p);
        }

        #endregion
    }
}