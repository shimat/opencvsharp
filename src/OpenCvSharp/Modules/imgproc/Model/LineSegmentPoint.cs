using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvHoughLines2で得られる、両端の点で表現される線分
    /// </summary>
#else
    /// <summary>
    /// Line segment structure retrieved from cvHoughLines2
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct LineSegmentPoint : IEquatable<LineSegmentPoint>
    {
        #region Fields

#if LANG_JP
    /// <summary>
    /// 1つ目の点
    /// </summary>
#else
        /// <summary>
        /// 1st Point
        /// </summary>
#endif
        public Point P1;

#if LANG_JP
    /// <summary>
    /// 2つ目の点
    /// </summary>
#else
        /// <summary>
        /// 2nd Point
        /// </summary>
#endif
        public Point P2;

        #endregion

        #region Init

#if LANG_JP
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="p1">1つ目の点</param>
    /// <param name="p2">2つ目の点</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p1">1st Point</param>
        /// <param name="p2">2nd Point</param>
#endif
        public LineSegmentPoint(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        #endregion

        #region Operators

#if LANG_JP
    /// <summary>
    /// 指定したオブジェクトと等しければtrueを返す 
    /// </summary>
    /// <param name="obj">比較するオブジェクト</param>
    /// <returns>型が同じで、メンバの値が等しければtrue</returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public bool Equals(LineSegmentPoint obj)
        {
            return (this.P1 == obj.P1 && this.P2 == obj.P2);
        }

#if LANG_JP
    /// <summary>
    /// == 演算子のオーバーロード
    /// </summary>
    /// <param name="lhs">左辺値</param>
    /// <param name="rhs">右辺値</param>
    /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(LineSegmentPoint lhs, LineSegmentPoint rhs)
        {
            return lhs.Equals(rhs);
        }

#if LANG_JP
    /// <summary>
    /// != 演算子のオーバーロード
    /// </summary>
    /// <param name="lhs">左辺値</param>
    /// <param name="rhs">右辺値</param>
    /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
#endif
        public static bool operator !=(LineSegmentPoint lhs, LineSegmentPoint rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region Overrided methods

#if LANG_JP
    /// <summary>
    /// Equalsのオーバーライド
    /// </summary>
    /// <param name="obj">比較するオブジェクト</param>
    /// <returns></returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

#if LANG_JP
    /// <summary>
    /// GetHashCodeのオーバーライド
    /// </summary>
    /// <returns>このオブジェクトのハッシュ値を指定する整数値。</returns>
#else
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
#endif
        public override int GetHashCode()
        {
            return P1.GetHashCode() + P2.GetHashCode();
        }

#if LANG_JP
    /// <summary>
    /// 文字列形式を返す 
    /// </summary>
    /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
        public override string ToString()
        {
            return string.Format("CvLineSegmentPoint (P1:{0} P2:{1})", P1, P2);
        }

        #endregion

        #region Methods

        #region Line and Line

#if LANG_JP
    /// <summary>
    /// 2直線の交点を求める (線分としてではなく直線として)
    /// </summary>
    /// <param name="line1"></param>
    /// <param name="line2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates a intersection of the specified two lines
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
#endif
        public static Point? LineIntersection(LineSegmentPoint line1, LineSegmentPoint line2)
        {
            int x1 = line1.P1.X;
            int y1 = line1.P1.Y;
            int f1 = line1.P2.X - line1.P1.X;
            int g1 = line1.P2.Y - line1.P1.Y;
            int x2 = line2.P1.X;
            int y2 = line2.P1.Y;
            int f2 = line2.P2.X - line2.P1.X;
            int g2 = line2.P2.Y - line2.P1.Y;

            double det = f2*g1 - f1*g2;
            if (det == 0)
            {
                return null;
            }

            int dx = x2 - x1;
            int dy = y2 - y1;
            double t1 = (f2*dy - g2*dx)/det;
            double t2 = (f1*dy - g1*dx)/det;

            return new Point
            {
                X = (int) Math.Round(x1 + (f1*t1)),
                Y = (int) Math.Round(y1 + (g1*t1))
            };
        }

#if LANG_JP
    /// <summary>
    /// 2直線の交点を求める (線分としてではなく直線として)
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates a intersection of the specified two lines
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
#endif
        public Point? LineIntersection(LineSegmentPoint line)
        {
            return LineIntersection(this, line);
        }

        #endregion

        #region Segment and Segment

#if LANG_JP
    /// <summary>
    /// 線分同士の交点を求める
    /// </summary>
    /// <param name="seg1"></param>
    /// <param name="seg2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates a intersection of the specified two segments
        /// </summary>
        /// <param name="seg1"></param>
        /// <param name="seg2"></param>
        /// <returns></returns>
#endif
        public static Point? SegmentIntersection(LineSegmentPoint seg1, LineSegmentPoint seg2)
        {
            if (IntersectedSegments(seg1, seg2))
                return LineIntersection(seg1, seg2);
            else
                return null;
        }

#if LANG_JP
    /// <summary>
    /// 線分同士の交点を求める
    /// </summary>
    /// <param name="seg"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates a intersection of the specified two segments
        /// </summary>
        /// <param name="seg"></param>
        /// <returns></returns>
#endif
        public Point? SegmentIntersection(LineSegmentPoint seg)
        {
            return SegmentIntersection(this, seg);
        }

#if LANG_JP
    /// <summary>
    /// 2つの線分が交差しているかどうかを返す
    /// </summary>
    /// <param name="seg1"></param>
    /// <param name="seg2"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns a boolean value indicating whether the specified two segments intersect.
        /// </summary>
        /// <param name="seg1"></param>
        /// <param name="seg2"></param>
        /// <returns></returns>
#endif
        public static bool IntersectedSegments(LineSegmentPoint seg1, LineSegmentPoint seg2)
        {
            Point p1 = seg1.P1;
            Point p2 = seg1.P2;
            Point p3 = seg2.P1;
            Point p4 = seg2.P2;

            checked
            {
                if (p1.X >= p2.X)
                {
                    if ((p1.X < p3.X && p1.X < p4.X) || (p2.X > p3.X && p2.X > p4.X))
                        return false;
                }
                else
                {
                    if ((p2.X < p3.X && p2.X < p4.X) || (p1.X > p3.X && p1.X > p4.X))
                        return false;
                }
                if (p1.Y >= p2.Y)
                {
                    if ((p1.Y < p3.Y && p1.Y < p4.Y) || (p2.Y > p3.Y && p2.Y > p4.Y))
                        return false;
                }
                else
                {
                    if ((p2.Y < p3.Y && p2.Y < p4.Y) || (p1.Y > p3.Y && p1.Y > p4.Y))
                        return false;
                }

                if (((long) (p1.X - p2.X)*(p3.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p3.X))*
                    ((long) (p1.X - p2.X)*(p4.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p4.X)) > 0)
                    return false;
                if (((long) (p3.X - p4.X)*(p1.Y - p3.Y) + (long) (p3.Y - p4.Y)*(p3.X - p1.X))*
                    ((long) (p3.X - p4.X)*(p2.Y - p3.Y) + (long) (p3.Y - p4.Y)*(p3.X - p2.X)) > 0)
                    return false;
            }
            return true;
        }

#if LANG_JP
    /// <summary>
    /// 2つの線分が交差しているかどうかを返す
    /// </summary>
    /// <param name="seg"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns a boolean value indicating whether the specified two segments intersect.
        /// </summary>
        /// <param name="seg"></param>
        /// <returns></returns>
#endif
        public bool IntersectedSegments(LineSegmentPoint seg)
        {
            return IntersectedSegments(this, seg);
        }

        #endregion

        #region Line and Segment

#if LANG_JP
    /// <summary>
    /// 直線と線分が交差しているかを調べる
    /// </summary>
    /// <param name="line">線分</param>
    /// <param name="seg">直線</param>
    /// <returns></returns>
#else
        /// <summary>
        /// Returns a boolean value indicating whether a line and a segment intersect.
        /// </summary>
        /// <param name="line">Line</param>
        /// <param name="seg">Segment</param>
        /// <returns></returns>
#endif
        public static bool IntersectedLineAndSegment(LineSegmentPoint line, LineSegmentPoint seg)
        {
            Point p1 = line.P1;
            Point p2 = line.P2;
            Point p3 = seg.P1;
            Point p4 = seg.P2;
            if (((long) (p1.X - p2.X)*(p3.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p3.X))*
                ((long) (p1.X - p2.X)*(p4.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p4.X)) > 0)
            {
                return false;
            }
            return true;
        }

#if LANG_JP
    /// <summary>
    /// 直線と線分の交点を求める
    /// </summary>
    /// <param name="line"></param>
    /// <param name="seg"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// Calculates a intersection of a line and a segment
        /// </summary>
        /// <param name="line"></param>
        /// <param name="seg"></param>
        /// <returns></returns>
#endif
        public static Point? LineAndSegmentIntersection(LineSegmentPoint line, LineSegmentPoint seg)
        {
            if (IntersectedLineAndSegment(line, seg))
                return LineIntersection(line, seg);
            else
                return null;
        }

        #endregion

#if LANG_JP
    /// <summary>
    /// 2点間の距離を求める
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
#endif
        public double Length(LineSegmentPoint s)
        {
            return P1.DistanceTo(P2);
        }

#if LANG_JP
    /// <summary>
    /// この CvLineSegmentPoint を指定の量だけ平行移動する 
    /// </summary>
    /// <param name="x">x 座標のオフセット量</param>
    /// <param name="y">y 座標のオフセット量</param>
    /// <returns></returns>
#else
        /// <summary>
        /// Translates the Point by the specified amount. 
        /// </summary>
        /// <param name="x">The amount to offset the x-coordinate. </param>
        /// <param name="y">The amount to offset the y-coordinate. </param>
        /// <returns></returns>
#endif
        public void Offset(int x, int y)
        {
            P1.X += x;
            P1.Y += y;
            P2.X += x;
            P2.Y += y;
        }

#if LANG_JP
    /// <summary>
    /// この CvLineSegmentPoint を指定の量だけ平行移動する 
    /// </summary>
    /// <param name="p">オフセットに使用する CvPoint</param>
    /// <returns></returns>
#else
        /// <summary>
        /// Translates the Point by the specified amount. 
        /// </summary>
        /// <param name="p">The Point used offset this CvPoint.</param>
        /// <returns></returns>
#endif
        public void Offset(Point p)
        {
            Offset(p.X, p.Y);
        }

        #endregion
    }
}
