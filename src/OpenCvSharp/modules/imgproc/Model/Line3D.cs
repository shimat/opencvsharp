using System;

namespace OpenCvSharp
{

#if LANG_JP
    /// <summary>
    /// 3次元空間上の直線
    /// </summary>
#else
    /// <summary>
    /// A 3-dimensional line object
    /// </summary>
#endif
    public class Line3D
    {
        #region Properties
#if LANG_JP
        /// <summary>
        /// 直線に乗るように正規化された方向ベクトル (x成分)
        /// </summary>
#else
        /// <summary>
        /// The X component of the normalized vector collinear to the line
        /// </summary>
#endif
        public double Vx { get; set; }
#if LANG_JP
        /// <summary>
        /// 直線に乗るように正規化された方向ベクトル (y成分)
        /// </summary>
#else
        /// <summary>
        /// The Y component of the normalized vector collinear to the line
        /// </summary>
#endif
        public double Vy { get; set; }
#if LANG_JP
        /// <summary>
        /// 直線に乗るように正規化された方向ベクトル (z成分)
        /// </summary>
#else
        /// <summary>
        /// The Z component of the normalized vector collinear to the line
        /// </summary>
#endif
        public double Vz { get; set; }
#if LANG_JP
        /// <summary>
        /// 直線上の点のx座標
        /// </summary>
#else
        /// <summary>
        /// X-coordinate of some point on the line
        /// </summary>
#endif
        public double X1 { get; set; }
#if LANG_JP
        /// <summary>
        /// 直線上の点のy座標
        /// </summary>
#else
        /// <summary>
        /// Y-coordinate of some point on the line
        /// </summary>
#endif
        public double Y1 { get; set; }
#if LANG_JP
        /// <summary>
        /// 直線上の点のz座標
        /// </summary>
#else
        /// <summary>
        /// Z-coordinate of some point on the line
        /// </summary>
#endif
        public double Z1 { get; set; }
        #endregion

        #region Initialization
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="vx">直線に乗るように正規化された方向ベクトル (x成分)</param>
        /// <param name="vy">直線に乗るように正規化された方向ベクトル (y成分)</param>
        /// <param name="vz">直線に乗るように正規化された方向ベクトル (z成分)</param>
        /// <param name="x1">直線上の点のx座標</param>
        /// <param name="y1">直線上の点のy座標</param>
        /// <param name="z1">直線上の点のz座標</param>
#else
        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="vx">The X component of the normalized vector collinear to the line</param>
        /// <param name="vy">The Y component of the normalized vector collinear to the line</param>
        /// <param name="vz">The Z component of the normalized vector collinear to the line</param>
        /// <param name="x1">Z-coordinate of some point on the line</param>
        /// <param name="y1">Z-coordinate of some point on the line</param>
        /// <param name="z1">Z-coordinate of some point on the line</param>
#endif
        public Line3D(double vx, double vy, double vz, double x1, double y1, double z1)
        {
            Vx = vx;
            Vy = vy;
            Vz = vz;
            X1 = x1;
            Y1 = y1;
            Z1 = z1;
        }
#if LANG_JP
        /// <summary>
        /// cvFitLineの出力(float[6])から初期化
        /// </summary>
        /// <param name="line">cvFitLineの出力結果</param>
#else
        /// <summary>
        /// Initializes by cvFitLine output 
        /// </summary>
        /// <param name="line">The returned value from cvFitLine</param>param>
#endif
        public Line3D(float[] line)
            : this(line[0], line[1], line[2], line[3], line[4], line[5])
        {
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
#endif
        public Point3d PerpendicularFoot(Point3f point)
        {
            return PerpendicularFoot(point.X, point.Y, point.Z);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
#endif
        public Point3d PerpendicularFoot(Point3d point)
        {
            return PerpendicularFoot(point.X, point.Y, point.Z);
        }
#if LANG_JP
        /// <summary>
        /// 指定した点と直線の距離を返す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
#else
        /// <summary>
        /// Returns the distance between this line and the specified point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
#endif
        public Point3d PerpendicularFoot(double x, double y, double z)
        {
            double xa = X1;
            double ya = Y1;
            double za = Z1;
            double xb = X1 + Vx;
            double yb = Y1 + Vy;
            double zb = Z1 + Vz;

            double k = ((x - xa)*(xb - xa) + (y - ya)*(yb - ya) + (z - za)*(zb - za))/
                       (Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2) + Math.Pow(zb - za, 2));

            double hx = k*xb+(1-k)*xa;
            double hy = k*yb+(1-k)*ya;
            double hz = k*zb+(1-k)*za;
            return new Point3d(hx, hy, hz);
        }


#if LANG_JP
        /// <summary>
        /// 指定した点と直線の距離を返す
        /// </summary>
        /// <param name="point"></param>
#else
        /// <summary>
        /// Returns the distance between this line and the specified point
        /// </summary>
        /// <param name="point"></param>
#endif
        public double Distance(Point3f point)
        {
            return Distance(point.X, point.Y, point.Z);
        }
#if LANG_JP
        /// <summary>
        /// 指定した点と直線の距離を返す
        /// </summary>
        /// <param name="point"></param>
#else
        /// <summary>
        /// Returns the distance between this line and the specified point
        /// </summary>
        /// <param name="point"></param>
#endif
        public double Distance(Point3d point)
        {
            return Distance(point.X, point.Y, point.Z);
        }
#if LANG_JP
        /// <summary>
        /// 指定した点と直線の距離を返す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
#else
        /// <summary>
        /// Returns the distance between this line and the specified point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
#endif
        public double Distance(double x, double y, double z)
        {
            var p = new Point3d(x, y, z);
            var a = new Point3d(X1, Y1, Z1);
            var b = new Point3d(X1 + Vx, Y1 + Vy, Z1 + Vz);
            var ab = new Point3d { X = b.X - a.X, Y = b.Y - a.Y, Z = b.Z - a.Z };
            var ap = new Point3d { X = p.X - a.X, Y = p.Y - a.Y, Z = p.Z - a.Z };

            // AB, APを外積 -> 平行四辺形Dの面積
            double d = VectorLength(CrossProduct(ab, ap));
            // AB間の距離
            double l = VertexDistance(a, b);
            // 平行四辺形の高さ(垂線)
            double h = d / l;
            return h;
        }

        /// <summary>
        /// ベクトルの外積
        /// </summary>
        /// <param name="vl"></param>
        /// <param name="vr"></param>
        /// <returns></returns>
        private Point3d CrossProduct(Point3d vl, Point3d vr)
        {
            var ret = new Point3d
                {
                    X = (vl.Y*vr.Z) - (vl.Z*vr.Y), 
                    Y = (vl.Z*vr.X) - (vl.X*vr.Z), 
                    Z = (vl.X*vr.Y) - (vl.Y*vr.X)
                };
            return ret;
        }
        /// <summary>
        /// ベクトルの長さ(原点からの距離)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private double VectorLength(Point3d v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }
        /// <summary>
        /// 2点間(2ベクトル)の距離
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private double VertexDistance(Point3d p1, Point3d p2)
        {
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + 
                             (p2.Y - p1.Y) * (p2.Y - p1.Y) + 
                             (p2.Z - p1.Z) * (p2.Z - p1.Z));
        }
        #endregion
    }
}