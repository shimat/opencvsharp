using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 始点と変化量であらわされる、2次元の直線を表すオブジェクト
    /// </summary>
#else
    /// <summary>
    /// 2-dimentional line vector
    /// </summary>
#endif
    public class Line2D
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
        #endregion

        #region Init
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="vx">直線に乗るように正規化された方向ベクトル (x成分)</param>
        /// <param name="vy">直線に乗るように正規化された方向ベクトル (y成分)</param>
        /// <param name="x1">直線上の点のx座標</param>
        /// <param name="y1">直線上の点のy座標</param>
#else
        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="vx">The X component of the normalized vector collinear to the line</param>
        /// <param name="vy">The Y component of the normalized vector collinear to the line</param>
        /// <param name="x1">Z-coordinate of some point on the line</param>
        /// <param name="y1">Z-coordinate of some point on the line</param>
#endif
        public Line2D(double vx, double vy, double x1, double y1)
        {
            Vx = vx;
            Vy = vy;
            X1 = x1;
            Y1 = y1;
        }
#if LANG_JP
        /// <summary>
        /// cvFitLineの出力(float[4])から初期化
        /// </summary>
        /// <param name="line">cvFitLineの出力結果</param>
#else
        /// <summary>
        /// Initializes by cvFitLine output 
        /// </summary>
        /// <param name="line">The returned value from cvFitLine</param>param>
#endif
        public Line2D(float[] line)
            : this(line[0], line[1], line[2], line[3])
        {
        }
        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetVectorRadian()
        {
            return Math.Atan2(Vy, Vx);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetVectorAngle()
        {
            return GetVectorRadian() * 180 / Math.PI;
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
        public double Distance(Point point)
        {
            return Distance(point.X, point.Y);
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
        public double Distance(Point2f point)
        {
            return Distance(point.X, point.Y);
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
        public double Distance(Point2d point)
        {
            return Distance(point.X, point.Y);
        }
#if LANG_JP
        /// <summary>
        /// 指定した点と直線の距離を返す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
#else
        /// <summary>
        /// Returns the distance between this line and the specified point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
#endif
        public double Distance(double x, double y)
        {
            // 公式で
            double m = Vy / Vx;
            double n = Y1 - m * X1; 
            return Math.Abs(y - m * x - n) / Math.Sqrt(1 + m * m);
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズに直線を合わせて、その端点を返す (描画用途)
        /// </summary>
        /// <param name="width">合わせこむサイズの幅</param>
        /// <param name="height">合わせこむサイズの高さ</param>
        /// <param name="pt1">端点1つ目</param>
        /// <param name="pt2">端点2つ目</param>
#else
        /// <summary>
        /// Fits this line to the specified size (for drawing)
        /// </summary>
        /// <param name="width">Width of fit size</param>
        /// <param name="height">Height of fit size</param>
        /// <param name="pt1">1st edge point of fitted line</param>
        /// <param name="pt2">2nd edge point of fitted line</param>
#endif
        public void FitSize(int width, int height, out Point pt1, out Point pt2)
        {
            double t = (width + height);
            pt1 = new Point
                {
                    X = (int)Math.Round(X1 - Vx*t),
                    Y = (int)Math.Round(Y1 - Vy * t)
                };
            pt2 = new Point
                {
                    X = (int)Math.Round(X1 + Vx * t),
                    Y = (int)Math.Round(Y1 + Vy * t)
                };
        }
        #endregion
    }
}