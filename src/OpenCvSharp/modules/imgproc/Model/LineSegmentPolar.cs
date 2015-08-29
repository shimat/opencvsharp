using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvHoughLines2で得られる、極座標系で表現される線分
    /// </summary>
#else
    /// <summary>
    /// Polar line segment retrieved from cvHoughLines2
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct LineSegmentPolar : IEquatable<LineSegmentPolar>
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// 線分の長さ
        /// </summary>
#else
        /// <summary>
        /// Length of the line
        /// </summary>
#endif
        public float Rho;
#if LANG_JP
        /// <summary>
        /// 線分の角度(ラジアン)
        /// </summary>
#else
        /// <summary>
        /// Angle of the line (radian)
        /// </summary>
#endif
        public float Theta;
        #endregion

        #region Init
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="rho">線分の長さ</param>
        /// <param name="theta">線分の角度(ラジアン)</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rho">Length of the line</param>
        /// <param name="theta">Angle of the line (radian)</param>
#endif
        public LineSegmentPolar(float rho, float theta)
        {
            this.Rho = rho;
            this.Theta = theta;
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
        public bool Equals(LineSegmentPolar obj)
        {
            return (this.Rho == obj.Rho && this.Theta == obj.Theta);
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
        public static bool operator ==(LineSegmentPolar lhs, LineSegmentPolar rhs)
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
        public static bool operator !=(LineSegmentPolar lhs, LineSegmentPolar rhs)
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
            return Rho.GetHashCode() + Theta.GetHashCode();
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
            return string.Format("CvLineSegmentPolar (Rho:{0} Theta:{1})", Rho, Theta);
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// 2直線の交点を求める
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
        public static Point? LineIntersection(LineSegmentPolar line1, LineSegmentPolar line2)
        {
            var seg1 = line1.ToSegmentPoint(5000);
            var seg2 = line2.ToSegmentPoint(5000);
            return LineSegmentPoint.LineIntersection(seg1, seg2);
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
        public Point? LineIntersection(LineSegmentPolar line)
        {
            return LineIntersection(this, line);
        }

        /// <summary>
        /// CvLineSegmentPointに変換する
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public LineSegmentPoint ToSegmentPoint(double scale)
        {
            double cos = Math.Cos(Theta);
            double sin = Math.Sin(Theta);
            double x0 = cos * Rho;
            double y0 = sin * Rho;
            var p1 = new Point { X = (int)Math.Round(x0 + scale * -sin), Y = (int)Math.Round(y0 + scale * cos) };
            var p2 = new Point { X = (int)Math.Round(x0 - scale * -sin), Y = (int)Math.Round(y0 - scale * cos) };
            return new LineSegmentPoint(p1, p2);
        }
        /// <summary>
        /// 指定したx座標を両端とするような線分に変換する
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public LineSegmentPoint ToSegmentPointX(int x1, int x2)
        {
            if (x1 > x2)
                throw new ArgumentOutOfRangeException();

            int? y1 = YPosOfLine(x1);
            int? y2 = YPosOfLine(x2);
            if (!y1.HasValue || !y2.HasValue)
                throw new Exception();

            var p1 = new Point(x1, y1.Value);
            var p2 = new Point(x2, y2.Value);
            return new LineSegmentPoint(p1, p2);
        }
        /// <summary>
        /// 指定したy座標を両端とするような線分に変換する
        /// </summary>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public LineSegmentPoint ToSegmentPointY(int y1, int y2)
        {
            if (y1 > y2)
                throw new ArgumentOutOfRangeException();

            int? x1 = XPosOfLine(y1);
            int? x2 = XPosOfLine(y2);
            if (!x1.HasValue || !x2.HasValue)
                throw new Exception();

            var p1 = new Point(x1.Value, y1);
            var p2 = new Point(x2.Value, y2);
            return new LineSegmentPoint(p1, p2);
        }

        /// <summary>
        /// 指定したy座標を通るときのx座標を求める
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int? XPosOfLine(int y)
        {
            var axis = new LineSegmentPolar(y, (float)(Math.PI / 2));     // 垂線90度 = x軸に平行       
            Point? node = LineIntersection(axis);
            if (node.HasValue)
                return node.Value.X;
            else
                return null;
        }
        /// <summary>
        /// 指定したx座標を通るときのy座標を求める
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int? YPosOfLine(int x)
        {
            var axis = new LineSegmentPolar(x, (float)0);     // 垂線0度 = y軸に平行       
            Point? node = LineIntersection(axis);
            if (node.HasValue)
                return node.Value.Y;
            else
                return null;
        }
        #endregion
    }
}
