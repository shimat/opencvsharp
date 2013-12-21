using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

#pragma warning disable 1591

namespace OpenCvSharp.Extensions
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public static class CvExtensions
    {
        #region HoughLinesProbabilisticEx
#if LANG_JP
        /// <summary>
        /// 検出する線分の角度を指定できる確率的ハフ変換
        /// </summary>
        /// <param name="img">入力画像</param>
        /// <param name="rho">距離解像度（1ピクセル当たりの単位）</param>
        /// <param name="theta">角度解像度（ラジアン単位）</param>
        /// <param name="threshold">閾値パラメータ．対応する投票数がthresholdより大きい場合のみ，抽出された線が返される．</param>
        /// <param name="minLineLength">最小の線の長さ</param>
        /// <param name="maxLineGap">同一線上に存在する線分として扱う，二つの線分の最大の間隔．</param>
        /// <param name="thetaMin">検出する線分の角度の範囲の最小値 [0 &lt;= θ &lt;= π]</param>
        /// <param name="thetaMax">検出する線分の角度の範囲の最大値 [0 &lt;= θ &lt;= π]</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rho"></param>
        /// <param name="theta"></param>
        /// <param name="threshold"></param>
        /// <param name="minLineLength"></param>
        /// <param name="maxLineGap"></param>
        /// <param name="thetaMin"></param>
        /// <param name="thetaMax"></param>
        /// <returns></returns>
#endif
        public static CvLineSegmentPoint[] HoughLinesProbabilisticEx(this CvArr img, double rho, double theta, int threshold, double minLineLength, double maxLineGap, 
            double thetaMin = 0, double thetaMax = Cv.PI)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (img.ElemType != MatrixType.U8C1)
                throw new ArgumentException("The source matrix must be 8-bit, single-channel image.");
            if (rho <= 0)
                throw new ArgumentOutOfRangeException("rho");
            if (theta <= 0)
                throw new ArgumentOutOfRangeException("theta");
            if (threshold <= 0)
                throw new ArgumentOutOfRangeException("threshold");
            if (minLineLength <= 0)
                throw new ArgumentOutOfRangeException("minLineLength");
            if (thetaMax < thetaMin)
                throw new ArgumentException();
            if (thetaMax > Cv.PI)
                throw new ArgumentOutOfRangeException("thetaMax", "thetaMax <= pi");
            if (thetaMin < 0)
                throw new ArgumentOutOfRangeException("thetaMin", "thetaMin >= 0");

            unsafe
            {
                // 画像パラメータの収集
                byte* data;
                int width;
                int height;
                int step;

                if (img is IplImage)
                {
                    IplImage obj = (IplImage)img;
                    data = obj.ImageDataPtr;
                    width = obj.Width;
                    height = obj.Height;
                    step = obj.WidthStep;
                }
                else if (img is CvMat)
                {
                    CvMat obj = (CvMat)img;
                    data = obj.DataByte;
                    width = obj.Width;
                    height = obj.Height;
                    step = obj.Step;
                }
                else
                {
                    throw new NotImplementedException("The source matrix of this method must be IplImage or CvMat.");
                }

                // sin, cosのLUTを作っておく
                double numAngleAll = Cv.PI / theta;
                int angleMin = (int)Math.Round(numAngleAll * (thetaMin / Cv.PI)); //(int)Math.Round(thetaMin * 180 / Cv.PI);
                int angleMax = (int)Math.Round(numAngleAll * (thetaMax / Cv.PI)); 
                int numAngle = angleMax - angleMin;
                int numRho = (int)Math.Round(((width + height) * 2 + 1) / rho);
                double[] sin = new double[angleMax];  // 大きめに作成。angleMinより手前の要素は使わない
                double[] cos = new double[angleMax]; 
                {
                    double rad = thetaMin;
                    double irho = 1 / rho;
                    for (int t = angleMin; t < angleMax; t++, rad += theta)
                    {
                        sin[t] = Math.Sin(rad * irho);
                        cos[t] = Math.Cos(rad * irho);
                    }
                }

                // 1. 非0の点を収集
                CvPoint[] points = new CvPoint[Cv.CountNonZero(img)];
                bool[] mask = new bool[width * height];
                int i = 0;
                for (int y = 0; y < height; y++)
                {
                    byte* p = data + y * step;
                    int offset = y * width;
                    for (int x = 0; x < width; x++)
                    {
                        if (p[x] != 0)
                        {
                            mask[offset + x] = true;
                            points[i++] = new CvPoint(x, y);
                        }
                        else
                        {
                            mask[offset + x] = false;
                        }
                    }
                }

                // ランダムな順に並び変え
                Shuffle(points);

                // 2. 画素をランダムに選択し処理
                int[] accum = new int[numAngle * numRho];
                List<CvLineSegmentPoint> result = new List<CvLineSegmentPoint>();
                for (int count = 0; count < points.Length; count++)
                {
                    CvPoint pt = points[count];

                    // 画素データが更新されているのは除外
                    if (!mask[pt.Y * width + pt.X])
                        continue;

                    // 2.1 [θ,ρ]空間で投票し、投票値が最大値となるθを求める
                    int maxR = threshold - 1;
                    int maxT = 0;
                    fixed (int* paccum = accum)
                    {
                        int* adata = paccum;
                        for (int t = angleMin; t < angleMax; t++, adata += numRho)
                        {
                            int r = (int)Math.Round(pt.X * cos[t] + pt.Y * sin[t]);
                            r += (numRho - 1) / 2;
                            int val = ++adata[r];
                            if (maxR < val)
                            {
                                maxR = val;
                                maxT = t;
                            }
                        }
                    }

                    if (maxR < threshold)
                        continue;

                    // 2.2 追尾用の増分値 (dx0,dy0) の設定
                    double a = -sin[maxT];
                    double b = cos[maxT];
                    int x0 = pt.X;
                    int y0 = pt.Y;
                    int dx0, dy0;
                    bool xflag;
                    const int Shift = 16;
                    if (Math.Abs(a) > Math.Abs(b))
                    {
                        xflag = true;
                        dx0 = a > 0 ? 1 : -1;
                        dy0 = (int)Math.Round(b * (1 << Shift) / Math.Abs(a));
                        y0 = (y0 << Shift) + (1 << (Shift - 1));
                    }
                    else
                    {
                        xflag = false;
                        dy0 = b > 0 ? 1 : -1;
                        dx0 = (int)Math.Round(a * (1 << Shift) / Math.Abs(b));
                        x0 = (x0 << Shift) + (1 << (Shift - 1));
                    }

                    // 2.3 線分画素を両端方向に追尾し、線分を抽出
                    CvPoint[] lineEnd = { new CvPoint(), new CvPoint() };
                    for (int k = 0; k < 2; k++)
                    {
                        int gap = 0;
                        int x = x0, y = y0, dx = dx0, dy = dy0;

                        if (k > 0)
                        {
                            dx = -dx;
                            dy = -dy;
                        }

                        // walk along the line using fixed-point arithmetics,
                        // stop at the image border or in case of too big gap
                        for (; ; x += dx, y += dy)
                        {
                            int x1, y1;

                            if (xflag)
                            {
                                x1 = x;
                                y1 = y >> Shift;
                            }
                            else
                            {
                                x1 = x >> Shift;
                                y1 = y;
                            }

                            if (x1 < 0 || x1 >= width || y1 < 0 || y1 >= height)
                                break;

                            // for each non-zero point:
                            //    update line end,
                            //    clear the mask element
                            //    reset the gap
                            if (mask[y1 * width + x1])
                            {
                                gap = 0;
                                lineEnd[k].X = x1;
                                lineEnd[k].Y = y1;
                            }
                            else if (++gap > maxLineGap)
                                break;
                        }
                    }

                    // lineLengthより長いものを線分候補とする
                    bool goodLine = Math.Abs(lineEnd[1].X - lineEnd[0].X) >= minLineLength ||
                                    Math.Abs(lineEnd[1].Y - lineEnd[0].Y) >= minLineLength;

                    // 2.4 追尾した画素を削除し、次回以降は処理されないようにする
                    //if (processOnce)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            int x = x0, y = y0, dx = dx0, dy = dy0;

                            if (k > 0)
                            {
                                dx = -dx;
                                dy = -dy;
                            }

                            // walk along the line using fixed-point arithmetics,
                            // stop at the image border or in case of too big gap
                            for (; ; x += dx, y += dy)
                            {
                                int x1, y1;

                                if (xflag)
                                {
                                    x1 = x;
                                    y1 = y >> Shift;
                                }
                                else
                                {
                                    x1 = x >> Shift;
                                    y1 = y;
                                }

                                // for each non-zero point:
                                //    update line end,
                                //    clear the mask element
                                //    reset the gap
                                if (mask[y1 * width + x1])
                                {
                                    if (goodLine)
                                    {
                                        fixed (int* paccum = accum)
                                        {
                                            int* adata = paccum;
                                            for (int t = angleMin; t < angleMax; t++, adata += numRho)
                                            {
                                                int r = (int)Math.Round(x1 * cos[t] + y1 * sin[t]);
                                                r += (numRho - 1) / 2;
                                                adata[r]--;
                                            }
                                        }
                                    }
                                    mask[y1 * width + x1] = false;
                                }

                                if (y1 == lineEnd[k].Y && x1 == lineEnd[k].X)
                                    break;
                            }
                        }
                    }

                    if (goodLine)
                    {
                        result.Add(new CvLineSegmentPoint(lineEnd[0], lineEnd[1]));
                    }
                }

                return result.ToArray();
            }
        }

        private static void Shuffle<T>(IList<T> list)
        {
            Random rand = new Random();
            for (int i = list.Count; i > 1; i--)
            {
                int j = rand.Next(i);
                Swap(list, j, i - 1);
            }
        }
        private static void Swap<T>(IList<T> list, int i1, int i2)
        {
            T temp = list[i1];
            list[i1] = list[i2];
            list[i2] = temp;
        }
        #endregion
    }
}
