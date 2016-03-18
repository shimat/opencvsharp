using System;

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
        /// <param name="src">Input image</param>
        /// <param name="dst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
#endif
        public static void Niblack(Mat src, Mat dst, int kernelSize, double k)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (src.Type() != MatType.CV_8UC1)
                throw new ArgumentException("src must be gray scale image");
            if (dst.Type() != MatType.CV_8UC1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            int width = src.Width;
            int height = src.Height;
            dst.Create(src.Size(), src.Type());

            using (var tSrcMat = new MatOfByte(src))
            using (var tDstMat = new MatOfByte(dst))
            {
                var tSrc = tSrcMat.GetIndexer();
                var tDst = tDstMat.GetIndexer();

                //for (int y = 0; y < gray.Height; y++)
                MyParallel.For(0, height, delegate(int y)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double m, s;
                        MeanStddev(src, x, y, kernelSize, out m, out s);
                        double threshold = m + k * s;

                        if (tSrc[y, x] < threshold)
                            tDst[y, x] = 0;
                        else
                            tDst[y, x] = 255;
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
        /// <param name="src">Input image</param>
        /// <param name="dst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
#endif
        public static void NiblackFast(Mat src, Mat dst, int kernelSize, double k)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (src.Type() != MatType.CV_8UC1)
                throw new ArgumentException("src must be gray scale image");
            if (dst.Type() != MatType.CV_8UC1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            int borderSize = kernelSize / 2;
            int width = src.Width;
            int height = src.Height;
            dst.Create(src.Size(), src.Type());

            using (var tempMat = new Mat(height + (borderSize * 2), width + (borderSize * 2), src.Type()))
            using (var sumMat = new Mat(tempMat.Height + 1, tempMat.Width + 1, MatType.CV_64FC1, 1))
            using (var sqSumMat = new Mat(tempMat.Height + 1, tempMat.Width + 1, MatType.CV_64FC1, 1))
            {
                Cv2.CopyMakeBorder(src, tempMat, borderSize, borderSize, borderSize, borderSize, BorderTypes.Replicate, Scalar.All(0));
                Cv2.Integral(tempMat, sumMat, sqSumMat, MatType.CV_64FC1);

                using (var tSrcMat = new MatOfByte(src))
                using (var tDstMat = new MatOfByte(dst))
                using (var tSumMat = new MatOfDouble(sumMat))
                using (var tSqSumMat = new MatOfDouble(sqSumMat))
                {
                    var tSrc = tSrcMat.GetIndexer();
                    var tDst = tDstMat.GetIndexer();
                    var tSum = tSumMat.GetIndexer();
                    var tSqSum = tSqSumMat.GetIndexer();

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
                            double sum = tSum[y2, x2] - tSum[y2, x1] - tSum[y1, x2] + tSum[y1, x1];
                            double sqsum = tSqSum[y2, x2] - tSqSum[y2, x1] - tSqSum[y1, x2] + tSqSum[y1, x1];
                            double mean = sum / kernelPixels;
                            double var = (sqsum / kernelPixels) - (mean * mean);
                            if (var < 0.0) var = 0.0;
                            double stddev = Math.Sqrt(var);

                            double threshold = mean + k * stddev;
                            if (tSrc[y - borderSize, x - borderSize] < threshold)
                                tDst[y - borderSize, x - borderSize] = 0;
                            else
                                tDst[y - borderSize, x - borderSize] = 255;
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
        /// <param name="src">Input image</param>
        /// <param name="dst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
        /// <param name="r">Adequate coefficient</param>
#endif
        public static void Sauvola(Mat src, Mat dst, int kernelSize, double k, double r)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (src.Type() != MatType.CV_8UC1)
                throw new ArgumentException("src must be gray scale image");
            if (dst.Type() != MatType.CV_8UC1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            int width = src.Width;
            int height = src.Height;
            dst.Create(src.Size(), src.Type());

            using (var tSrcMat = new MatOfByte(src))
            using (var tDstMat = new MatOfByte(dst))
            {
                var tSrc = tSrcMat.GetIndexer();
                var tDst = tDstMat.GetIndexer();

                //for (int y = 0; y < height; y++)
                MyParallel.For(0, height, delegate(int y)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double m, s;
                        MeanStddev(src, x, y, kernelSize, out m, out s);
                        double threshold = m * (1 + k * (s / r - 1));

                        if (tSrc[y, x] < threshold)
                            tDst[y, x] = 0;
                        else
                            tDst[y, x] = 255;
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
        /// <param name="src">Input image</param>
        /// <param name="dst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
        /// <param name="r">Adequate coefficient</param>
#endif
        public static void SauvolaFast(Mat src, Mat dst, int kernelSize, double k, double r)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (src.Type() != MatType.CV_8UC1)
                throw new ArgumentException("src must be gray scale image");
            if (dst.Type() != MatType.CV_8UC1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");
            if (Math.Abs(r) < 1e-9f)
                throw new ArgumentOutOfRangeException("r", "r == 0");

            int borderSize = kernelSize / 2;
            int width = src.Width;
            int height = src.Height;
            dst.Create(src.Size(), src.Type());

            using (var tempMat = new Mat(height + (borderSize * 2), width + (borderSize * 2), src.Type()))
            using (var sumMat = new Mat(tempMat.Height + 1, tempMat.Width + 1, MatType.CV_64FC1, 1))
            using (var sqSumMat = new Mat(tempMat.Height + 1, tempMat.Width + 1, MatType.CV_64FC1, 1))
            {
                Cv2.CopyMakeBorder(src, tempMat, borderSize, borderSize, borderSize, borderSize, BorderTypes.Replicate, Scalar.All(0));
                Cv2.Integral(tempMat, sumMat, sqSumMat, MatType.CV_64FC1);

                using (var tSrcMat = new MatOfByte(src))
                using (var tDstMat = new MatOfByte(dst))
                using (var tSumMat = new MatOfDouble(sumMat))
                using (var tSqSumMat = new MatOfDouble(sqSumMat))
                {
                    var tSrc = tSrcMat.GetIndexer();
                    var tDst = tDstMat.GetIndexer();
                    var tSum = tSumMat.GetIndexer();
                    var tSqSum = tSqSumMat.GetIndexer();

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
                            double sum = tSum[y2, x2] - tSum[y2, x1] - tSum[y1, x2] + tSum[y1, x1];
                            double sqsum = tSqSum[y2, x2] - tSqSum[y2, x1] - tSqSum[y1, x2] + tSqSum[y1, x1];
                            double mean = sum / kernelPixels;
                            double var = (sqsum / kernelPixels) - (mean * mean);
                            if (var < 0.0) var = 0.0;
                            double stddev = Math.Sqrt(var);

                            double threshold = mean * (1 + k * (stddev / r - 1));
                            if (tSrc[y - borderSize, x - borderSize] < threshold)
                                tDst[y - borderSize, x - borderSize] = 0;
                            else
                                tDst[y - borderSize, x - borderSize] = 255;
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
        /// <param name="src">Input image</param>
        /// <param name="dst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="constrastMin">Adequate coefficient</param>
        /// <param name="bgThreshold">Adequate coefficient</param>
#endif
        public static void Bernsen(Mat src, Mat dst, int kernelSize, byte constrastMin, byte bgThreshold)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (src.Type() != MatType.CV_8UC1)
                throw new ArgumentException("src must be gray scale image");
            if (dst.Type() != MatType.CV_8UC1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            int width = src.Width;
            int height = src.Height;
            dst.Create(src.Size(), src.Type());

            using (var tSrcMat = new MatOfByte(src))
            using (var tDstMat = new MatOfByte(dst))
            {
                var tSrc = tSrcMat.GetIndexer();
                var tDst = tDstMat.GetIndexer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte min, max;
                        MinMax(src, x, y, kernelSize, out min, out max);

                        int contrast = max - min;
                        byte threshold;
                        if (contrast < constrastMin)
                            threshold = bgThreshold;
                        else
                            threshold = (byte)((max + min) / 2);

                        if (tSrc[y, x] <= threshold)
                            tDst[y, x] = 0;
                        else
                            tDst[y, x] = 255;
                    }
                }
            }

        }

#if LANG_JP
        /// <summary>
        /// Nickの手法による二値化処理を行う。
        /// </summary>
        /// <param name="imgSrc">入力画像</param>
        /// <param name="imgDst">出力画像</param>
        /// <param name="kernelSize">局所領域のサイズ</param>
        /// <param name="k">係数</param>
#else
        /// <summary>
        /// Binarizes by Nick's method
        /// </summary>
        /// <param name="src">Input image</param>
        /// <param name="dst">Output image</param>
        /// <param name="kernelSize">Window size</param>
        /// <param name="k">Adequate coefficient</param>
#endif
        public static void Nick(Mat src, Mat dst, int kernelSize, double k)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            // グレースケールのみ
            if (src.Type() != MatType.CV_8UC1)
                throw new ArgumentException("src must be gray scale image");
            if (dst.Type() != MatType.CV_8UC1)
                throw new ArgumentException("dst must be gray scale image");

            // サイズのチェック
            if (kernelSize < 3)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be 3 and above");
            if (kernelSize % 2 == 0)
                throw new ArgumentOutOfRangeException("kernelSize", "size must be odd number");

            int borderSize = kernelSize / 2;
            int width = src.Width;
            int height = src.Height;
            dst.Create(src.Size(), src.Type());

            using (var tempMat = new Mat(height + (borderSize * 2), width + (borderSize * 2), src.Type()))
            using (var sumMat = new Mat(tempMat.Height + 1, tempMat.Width + 1, MatType.CV_64FC1, 1))
            using (var sqSumMat = new Mat(tempMat.Height + 1, tempMat.Width + 1, MatType.CV_64FC1, 1))
            {
                Cv2.CopyMakeBorder(src, tempMat, borderSize, borderSize, borderSize, borderSize, BorderTypes.Replicate, Scalar.All(0));
                Cv2.Integral(tempMat, sumMat, sqSumMat, MatType.CV_64FC1);

                using (var tSrcMat = new MatOfByte(src))
                using (var tDstMat = new MatOfByte(dst))
                using (var tSumMat = new MatOfDouble(sumMat))
                using (var tSqSumMat = new MatOfDouble(sqSumMat))
                {
                    var tSrc = tSrcMat.GetIndexer();
                    var tDst = tDstMat.GetIndexer();
                    var tSum = tSumMat.GetIndexer();
                    var tSqSum = tSqSumMat.GetIndexer();

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
                            double sum = tSum[y2, x2] - tSum[y2, x1] - tSum[y1, x2] + tSum[y1, x1];
                            double sqsum = tSqSum[y2, x2] - tSqSum[y2, x1] - tSqSum[y1, x2] + tSqSum[y1, x1];
                            double mean = sum / kernelPixels;
                            double term = (sqsum - mean * mean) / kernelPixels;
                            if (term < 0.0) term = 0.0;
                            term = Math.Sqrt(term);

                            double threshold = mean + k * term;
                            if (tSrc[y - borderSize, x - borderSize] < threshold)
                                tDst[y - borderSize, x - borderSize] = 0;
                            else
                                tDst[y - borderSize, x - borderSize] = 255;
                        }
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
        private static void MeanStddev(Mat img, int x, int y, int size, out double mean, out double stddev)
        {
            int count = 0;
            int sum = 0;
            int sqsum = 0;
            int size2 = size / 2;
            int xs = Math.Max(x - size2, 0);
            int xe = Math.Min(x + size2, img.Width);
            int ys = Math.Max(y - size2, 0);
            int ye = Math.Min(y + size2, img.Height);
            byte v;

            using (var tImg = new MatOfByte(img))
            {
                var indexer = tImg.GetIndexer();
                for (int xx = xs; xx < xe; xx++)
                {
                    for (int yy = ys; yy < ye; yy++)
                    {
                        v = indexer[yy, xx];
                        sum += v;
                        sqsum += v*v;
                        count++;
                    }
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
        private static void MinMax(Mat img, int x, int y, int size, out byte min, out byte max)
        {
            int size2 = size / 2;
            min = byte.MaxValue;
            max = byte.MinValue;
            int xs = Math.Max(x - size2, 0);
            int xe = Math.Min(x + size2, img.Width);
            int ys = Math.Max(y - size2, 0);
            int ye = Math.Min(y + size2, img.Height);

            using (var tImg = new MatOfByte(img))
            {
                var indexer = tImg.GetIndexer();

                for (int xx = xs; xx < xe; xx++)
                {
                    for (int yy = ys; yy < ye; yy++)
                    {
                        byte v = indexer[yy, xx];
                        if (max < v)
                            max = v;
                        else if (min > v)
                            min = v;
                    }
                }
            }
        }
    }
}
