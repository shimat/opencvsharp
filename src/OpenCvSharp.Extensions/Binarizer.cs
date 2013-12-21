/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace OpenCvSharp.Extensions
{
#if LANG_JP
    /// <summary>
    /// 様々な二値化手法を集めたクラス (OpenCVの関数ではなく, OpenCvSharpが独自に実装したものである. 出来は保証しない.)
    /// </summary>
#else
    /// <summary>
    /// Various binarization methods (ATTENTION : The methods of this class is not implemented in OpenCV)
    /// </summary>
#endif
    public static class Binarizer
    {
#if LANG_JP
        /// <summary>
        /// Niblackの手法による二値化処理を行う。
        /// </summary>
        /// <param name="imgSrc">入力画像</param>
        /// <param name="imgDst">出力画像</param>
        /// <param name="kernelSize">局所領域のサイズ</param>
        /// <param name="k">係数</param>
#else
        /// <summary>
        /// Binarizes by Niblack's method
        /// </summary>
        /// <param name="imgSrc">Input image</param>
        /// <param name="imgDst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
#endif
        public static void Niblack(IplImage imgSrc, IplImage imgDst, int kernelSize, double k)
        {
            if (imgSrc == null)
                throw new ArgumentNullException("src");
            if (imgDst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (imgSrc.NChannels != 1)
                throw new ArgumentException("src must be gray scale image");
            if (imgDst.NChannels != 1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            CvRect roi = imgSrc.ROI;
            int width = roi.Width;
            int height = roi.Height;
            if (width != imgDst.Width || height != imgDst.Height)
                throw new ArgumentException("src.Size == dst.Size");

            unsafe
            {
                byte* pSrc = imgSrc.ImageDataPtr;
                byte* pDst = imgDst.ImageDataPtr;
                int stepSrc = imgSrc.WidthStep;
                int stepDst = imgDst.WidthStep;
                //for (int y = 0; y < gray.Height; y++)
                MyParallel.For(0, height, delegate(int y)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double m, s;
                        MeanStddev(imgSrc, x + roi.X, y + roi.Y, kernelSize, out m, out s);
                        double threshold = m + k * s;
                        int offsetSrc = stepSrc * (y + roi.Y) + (x + roi.X);
                        int offsetDst = stepDst * y + x;
                        if (pSrc[offsetSrc] < threshold)
                            pDst[offsetDst] = 0;
                        else
                            pDst[offsetDst] = 255;
                    }
                }
                );
            }
        }

#if LANG_JP
        /// <summary>
        /// Niblackの手法による二値化処理を行う（高速だが、メモリを多く消費するバージョン）。
        /// </summary>
        /// <param name="imgSrc">入力画像</param>
        /// <param name="imgDst">出力画像</param>
        /// <param name="kernelSize">局所領域のサイズ</param>
        /// <param name="k">係数</param>
#else
        /// <summary>
        /// Binarizes by Niblack's method (This is faster but memory-hogging)
        /// </summary>
        /// <param name="imgSrc">Input image</param>
        /// <param name="imgDst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
#endif
        public static void NiblackFast(IplImage imgSrc, IplImage imgDst, int kernelSize, double k)
        {
            if (imgSrc == null)
                throw new ArgumentNullException("src");
            if (imgDst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (imgSrc.NChannels != 1)
                throw new ArgumentException("src must be gray scale image");
            if (imgDst.NChannels != 1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            int borderSize = kernelSize / 2;
            CvRect roi = imgSrc.ROI;
            int width = roi.Width;
            int height = roi.Height;
            if (width != imgDst.Width || height != imgDst.Height)
                throw new ArgumentException("src.Size == dst.Size");

            using (IplImage imgTemp = new IplImage(width + (borderSize * 2), height + (borderSize * 2), imgSrc.Depth, imgSrc.NChannels))
            using (IplImage imgSum = new IplImage(imgTemp.Width + 1, imgTemp.Height + 1, BitDepth.F64, 1))
            using (IplImage imgSqSum = new IplImage(imgTemp.Width + 1, imgTemp.Height + 1, BitDepth.F64, 1))
            {
                Cv.CopyMakeBorder(imgSrc, imgTemp, new CvPoint(borderSize, borderSize), BorderType.Replicate, CvScalar.ScalarAll(0));
                Cv.Integral(imgTemp, imgSum, imgSqSum);

                unsafe
                {
                    byte* pSrc = imgSrc.ImageDataPtr;
                    byte* pDst = imgDst.ImageDataPtr;
                    double* pSum = (double*)imgSum.ImageDataPtr;
                    double* pSqSum = (double*)imgSqSum.ImageDataPtr;
                    int stepSrc = imgSrc.WidthStep;
                    int stepDst = imgDst.WidthStep;
                    int stepSum = imgSum.WidthStep / sizeof(double);
                    int ylim = height + borderSize;
                    int xlim = width + borderSize;
                    int kernelPixels = kernelSize * kernelSize;
                    for (int y = borderSize; y < ylim; y++)
                    {
                        for (int x = borderSize; x < xlim; x++)
                        {
                            int x1 = x - borderSize;
                            int y1 = y - borderSize;
                            int x2 = x + borderSize + 1;
                            int y2 = y + borderSize + 1;
                            double sum = pSum[stepSum * y2 + x2] - pSum[stepSum * y2 + x1] - pSum[stepSum * y1 + x2] + pSum[stepSum * y1 + x1];
                            double sqsum = pSqSum[stepSum * y2 + x2] - pSqSum[stepSum * y2 + x1] - pSqSum[stepSum * y1 + x2] + pSqSum[stepSum * y1 + x1];
                            double mean = sum / kernelPixels;
                            double var = (sqsum / kernelPixels) - (mean * mean);
                            if (var < 0.0) var = 0.0;
                            double stddev = Math.Sqrt(var);

                            double threshold = mean + k * stddev;
                            int offsetSrc = stepSrc * (y + roi.Y - borderSize) + (x + roi.X - borderSize);
                            int offsetDst = stepDst * (y - borderSize) + (x - borderSize);
                            if (pSrc[offsetSrc] < threshold)
                                pDst[offsetDst] = 0;
                            else
                                pDst[offsetDst] = 255;
                        }
                    }
                }
            }
        }



#if LANG_JP
        /// <summary>
        /// Sauvolaの手法による二値化処理を行う。
        /// </summary>
        /// <param name="imgSrc">入力画像</param>
        /// <param name="imgDst">出力画像</param>
        /// <param name="kernelSize">局所領域のサイズ</param>
        /// <param name="k">係数</param>
        /// <param name="r">係数</param>
#else
        /// <summary>
        /// Binarizes by Sauvola's method
        /// </summary>
        /// <param name="imgSrc">Input image</param>
        /// <param name="imgDst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
        /// <param name="r">Adequate coefficient</param>
#endif
        public static void Sauvola(IplImage imgSrc, IplImage imgDst, int kernelSize, double k, double r)
        {
            if (imgSrc == null)
                throw new ArgumentNullException("src");
            if (imgDst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (imgSrc.NChannels != 1)
                throw new ArgumentException("src must be gray scale image");
            if (imgDst.NChannels != 1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            CvRect roi = imgSrc.ROI;
            int width = roi.Width;
            int height = roi.Height;

            if (width != imgDst.Width || height != imgDst.Height)
                throw new ArgumentException("src.Size == dst.Size");

            unsafe
            {
                byte* pSrc = imgSrc.ImageDataPtr;
                byte* pDst = imgDst.ImageDataPtr;
                int stepSrc = imgSrc.WidthStep;
                int stepDst = imgDst.WidthStep;
                //for (int y = 0; y < height; y++)
                MyParallel.For(0, height, delegate(int y)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double m, s;
                        MeanStddev(imgSrc, x + roi.X, y + roi.Y, kernelSize, out m, out s);
                        double threshold = m * (1 + k * (s / r - 1));

                        int offsetSrc = stepSrc * (y + roi.Y) + (x + roi.X);
                        int offsetDst = stepDst * y + x;
                        if (pSrc[offsetSrc] < threshold)
                            pDst[offsetDst] = 0;
                        else
                            pDst[offsetDst] = 255;
                    }
                }
                );
            }
            
        }


#if LANG_JP
        /// <summary>
        /// Sauvolaの手法による二値化処理を行う（高速だが、メモリを多く消費するバージョン）。
        /// </summary>
        /// <param name="imgSrc">入力画像</param>
        /// <param name="imgDst">出力画像</param>
        /// <param name="kernelSize">局所領域のサイズ</param>
        /// <param name="k">係数</param>
        /// <param name="r">係数</param>
#else
        /// <summary>
        /// Binarizes by Sauvola's method (This is faster but memory-hogging)
        /// </summary>
        /// <param name="imgSrc">Input image</param>
        /// <param name="imgDst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
        /// <param name="r">Adequate coefficient</param>
#endif
        public static void SauvolaFast(IplImage imgSrc, IplImage imgDst, int kernelSize, double k, double r)
        {
            if (imgSrc == null)
                throw new ArgumentNullException("src");
            if (imgDst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (imgSrc.NChannels != 1)
                throw new ArgumentException("src must be gray scale image");
            if (imgDst.NChannels != 1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");
            if (r == 0)
                throw new ArgumentOutOfRangeException("r", "r == 0");

            int borderSize = kernelSize / 2;
            CvRect roi = imgSrc.ROI;
            int width = roi.Width;
            int height = roi.Height;
            if (width != imgDst.Width || height != imgDst.Height)
                throw new ArgumentException("src.Size == dst.Size");

            using (IplImage imgTemp = new IplImage(width + (borderSize * 2), height + (borderSize * 2), imgSrc.Depth, imgSrc.NChannels))
            using (IplImage imgSum = new IplImage(imgTemp.Width + 1, imgTemp.Height + 1, BitDepth.F64, 1))
            using (IplImage imgSqSum = new IplImage(imgTemp.Width + 1, imgTemp.Height + 1, BitDepth.F64, 1))
            {
                Cv.CopyMakeBorder(imgSrc, imgTemp, new CvPoint(borderSize, borderSize), BorderType.Replicate, CvScalar.ScalarAll(0));
                Cv.Integral(imgTemp, imgSum, imgSqSum);

                unsafe
                {
                    byte* pSrc = imgSrc.ImageDataPtr;
                    byte* pDst = imgDst.ImageDataPtr;
                    byte* pTemp = imgTemp.ImageDataPtr;
                    double* pSum = (double*)imgSum.ImageDataPtr;
                    double* pSqSum = (double*)imgSqSum.ImageDataPtr;
                    int stepSrc = imgSrc.WidthStep;
                    int stepDst = imgDst.WidthStep;
                    int stepSum = imgSum.WidthStep / sizeof(double);
                    int ylim = height + borderSize;
                    int xlim = width + borderSize;
                    int kernelPixels = kernelSize * kernelSize;
                    for (int y = borderSize; y < ylim; y++)
                    {
                        for (int x = borderSize; x < xlim; x++)
                        {
                            int x1 = x - borderSize;
                            int y1 = y - borderSize;
                            int x2 = x + borderSize + 1;
                            int y2 = y + borderSize + 1;
                            double sum = pSum[stepSum * y2 + x2] - pSum[stepSum * y2 + x1] - pSum[stepSum * y1 + x2] + pSum[stepSum * y1 + x1];
                            double sqsum = pSqSum[stepSum * y2 + x2] - pSqSum[stepSum * y2 + x1] - pSqSum[stepSum * y1 + x2] + pSqSum[stepSum * y1 + x1];
                            double mean = sum / kernelPixels;
                            double var = (sqsum / kernelPixels) - (mean * mean);
                            if (var < 0.0) var = 0.0;
                            double stddev = Math.Sqrt(var);

                            double threshold = mean * (1 + k * (stddev / r - 1));
                            int offsetSrc = stepSrc * (y + roi.Y - borderSize) + (x + roi.X - borderSize);
                            int offsetDst = stepDst * (y - borderSize) + (x - borderSize);
                            if (pSrc[offsetSrc] < threshold)
                                pDst[offsetDst] = 0;
                            else
                                pDst[offsetDst] = 255;
                        }
                    }
                }
            }
        }


#if LANG_JP
        /// <summary>
        /// Bernsenの手法による二値化処理を行う。
        /// </summary>
        /// <param name="imgSrc">入力画像</param>
        /// <param name="imgDst">出力画像</param>
        /// <param name="kernelSize">局所領域のサイズ</param>
        /// <param name="constrastMin">この数値以下のコントラストの領域は背景領域とみなす</param>
        /// <param name="bgThreshold">背景領域と見なされた領域に適用する閾値（背景領域以外では、適応的に閾値を求める）</param>
#else
        /// <summary>
        /// Binarizes by Bernsen's method
        /// </summary>
        /// <param name="imgSrc">Input image</param>
        /// <param name="imgDst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="constrastMin">Adequate coefficient</param>
        /// <param name="bgThreshold">Adequate coefficient</param>
#endif
        public static void Bernsen(IplImage imgSrc, IplImage imgDst, int kernelSize, byte constrastMin, byte bgThreshold)
        {
            if (imgSrc == null)
                throw new ArgumentNullException("src");
            if (imgDst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (imgSrc.NChannels != 1)
                throw new ArgumentException("src must be gray scale image");
            if (imgDst.NChannels != 1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            CvRect roi = imgSrc.ROI;
            int width = roi.Width;
            int height = roi.Height;
            if (width != imgDst.Width || height != imgDst.Height)
                throw new ArgumentException("src.Size == dst.Size");

            unsafe
            {
                byte* pSrc = imgSrc.ImageDataPtr;
                byte* pDst = imgDst.ImageDataPtr;
                int widthStep = imgDst.WidthStep;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte min, max;
                        MinMax(imgSrc, x + roi.X, y + roi.Y, kernelSize, out min, out max);
                        int contrast = max - min;
                        byte threshold;
                        if (contrast < constrastMin)
                            threshold = bgThreshold;
                        else
                            threshold = (byte)((max + min) / 2);

                        int offset = (widthStep * y) + x;
                        if (pSrc[offset] <= threshold)
                            pDst[offset] = 0;
                        else
                            pDst[offset] = 255;
                    }
                }
            }

        }




        /// <summary>
        /// 注目画素の周辺画素の平均値と標準偏差を求める
        /// </summary>
        /// <param name="img">画像の画素データ</param>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="size">周辺画素の探索サイズ。奇数でなければならない</param>
        /// <param name="mean">出力される平均</param>
        /// <param name="stddev">出力される標準偏差</param>
        private static unsafe void MeanStddev(IplImage img, int x, int y, int size, out double mean, out double stddev)
        {
            int count = 0;
            int sum = 0;
            int sqsum = 0;
            byte* p = img.ImageDataPtr;
            int size2 = size / 2;
            int widthStep = img.WidthStep;
            int xs = Math.Max(x - size2, 0);
            int xe = Math.Min(x + size2, img.Width);
            int ys = Math.Max(y - size2, 0);
            int ye = Math.Min(y + size2, img.Height);
            byte v;

            for (int xx = xs; xx < xe; xx++)
            {
                for (int yy = ys; yy < ye; yy++)
                {
                    v = p[widthStep * yy + xx];
                    sum += v;
                    sqsum += v * v;
                    count++;
                }
            }
            mean = (double)sum / count;
            double var = ((double)sqsum / count) - (mean * mean);
            if (var < 0.0) var = 0.0;
            stddev = Math.Sqrt(var);
        }

        /// <summary>
        /// 注目画素の周辺画素の最大値と最小値を求める
        /// </summary>
        /// <param name="img">画像の画素データ</param>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="size">周辺画素の探索サイズ。奇数でなければならない</param>
        /// <param name="min">出力される最小値</param>
        /// <param name="max">出力される最大値</param>
        private static unsafe void MinMax(IplImage img, int x, int y, int size, out byte min, out byte max)
        {
            byte* p = img.ImageDataPtr;
            int size2 = size / 2;
            int widthStep = img.WidthStep;
            min = byte.MaxValue;
            max = byte.MinValue;
            int xs = Math.Max(x - size2, 0);
            int xe = Math.Min(x + size2, img.Width);
            int ys = Math.Max(y - size2, 0);
            int ye = Math.Min(y + size2, img.Height);

            for (int xx = xs; xx < xe; xx++)
            {
                for (int yy = ys; yy < ye; yy++)
                {
                    byte v = p[widthStep * yy + xx];
                    if (max < v)
                        max = v;
                    else if (min > v)
                        min = v;
                }
            }
        }
    }
}
