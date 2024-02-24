namespace OpenCvSharp.Extensions;

/// <summary>
/// Various binarization methods (ATTENTION : The methods of this class is not implemented in OpenCV)
/// </summary>
[Obsolete("Use CvXImgProc.NiblackThreshold instead.")]
public static class Binarizer
{
    /// <summary>
    /// Binarizes by Niblack's method (This is faster but memory-hogging)
    /// </summary>
    /// <param name="src">Input image</param>
    /// <param name="dst">Output image</param>
    /// <param name="kernelSize">Window size</param>
    /// <param name="k">Adequate coefficient</param>
    public static void Niblack(Mat src, Mat dst, int kernelSize, double k)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        // グレースケールのみ
        if (src.Type() != MatType.CV_8UC1)
            throw new ArgumentException("src must be gray scale image");

        // サイズのチェック
        if (kernelSize < 3)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be 3 and above");
        if (kernelSize % 2 == 0)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be odd number");

        int borderSize = kernelSize / 2;
        int width = src.Width;
        int height = src.Height;
        dst.Create(src.Size(), src.Type());

        using (var tempMat = new Mat(height + (borderSize * 2), width + (borderSize * 2), src.Type()))
        using (var sumMat = new Mat())
        using (var sqSumMat = new Mat())
        {
            Cv2.CopyMakeBorder(src, tempMat, borderSize, borderSize, borderSize, borderSize, BorderTypes.Replicate, Scalar.All(0));
            Cv2.Integral(tempMat, sumMat, sqSumMat, MatType.CV_64FC1);

            using (var tSrcMat = new Mat<byte>(src))
            using (var tDstMat = new Mat<byte>(dst))
            using (var tSumMat = new Mat<double>(sumMat))
            using (var tSqSumMat = new Mat<double>(sqSumMat))
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

    /// <summary>
    /// Binarizes by Sauvola's method (This is faster but memory-hogging)
    /// </summary>
    /// <param name="src">Input image</param>
    /// <param name="dst">Output image</param>
    /// <param name="kernelSize">Window size</param>
    /// <param name="k">Adequate coefficient</param>
    /// <param name="r">Adequate coefficient</param>
    public static void Sauvola(Mat src, Mat dst, int kernelSize, double k, double r)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        // グレースケールのみ
        if (src.Type() != MatType.CV_8UC1)
            throw new ArgumentException("src must be gray scale image");

        // サイズのチェック
        if (kernelSize < 3)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be 3 and above");
        if (kernelSize % 2 == 0)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be odd number");
        if (Math.Abs(r) < 1e-9f)
            throw new ArgumentOutOfRangeException(nameof(r), "r == 0");

        int borderSize = kernelSize / 2;
        int width = src.Width;
        int height = src.Height;
        dst.Create(src.Size(), src.Type());

        using (var tempMat = new Mat(height + (borderSize * 2), width + (borderSize * 2), src.Type()))
        using (var sumMat = new Mat())
        using (var sqSumMat = new Mat())
        {
            Cv2.CopyMakeBorder(src, tempMat, borderSize, borderSize, borderSize, borderSize, BorderTypes.Replicate, Scalar.All(0));
            Cv2.Integral(tempMat, sumMat, sqSumMat, MatType.CV_64FC1);

            using (var tSrcMat = new Mat<byte>(src))
            using (var tDstMat = new Mat<byte>(dst))
            using (var tSumMat = new Mat<double>(sumMat))
            using (var tSqSumMat = new Mat<double>(sqSumMat))
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

    /// <summary>
    /// Binarizes by Bernsen's method
    /// </summary>
    /// <param name="src">Input image</param>
    /// <param name="dst">Output image</param>
    /// <param name="kernelSize">Window size</param>
    /// <param name="constrastMin">Adequate coefficient</param>
    /// <param name="bgThreshold">Adequate coefficient</param>
    public static void Bernsen(Mat src, Mat dst, int kernelSize, byte constrastMin, byte bgThreshold)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        // グレースケールのみ
        if (src.Type() != MatType.CV_8UC1)
            throw new ArgumentException("src must be gray scale image");

        // サイズのチェック
        if (kernelSize < 3)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be 3 and above");
        if (kernelSize % 2 == 0)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be odd number");

        int width = src.Width;
        int height = src.Height;
        dst.Create(src.Size(), src.Type());

        using (var tSrcMat = new Mat<byte>(src))
        using (var tDstMat = new Mat<byte>(dst))
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

    /// <summary>
    /// Binarizes by Nick's method
    /// </summary>
    /// <param name="src">Input image</param>
    /// <param name="dst">Output image</param>
    /// <param name="kernelSize">Window size</param>
    /// <param name="k">Adequate coefficient</param>
    public static void Nick(Mat src, Mat dst, int kernelSize, double k)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        // グレースケールのみ
        if (src.Type() != MatType.CV_8UC1)
            throw new ArgumentException("src must be gray scale image");

        // サイズのチェック
        if (kernelSize < 3)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be 3 and above");
        if (kernelSize % 2 == 0)
            throw new ArgumentOutOfRangeException(nameof(kernelSize), "size must be odd number");

        int borderSize = kernelSize / 2;
        int width = src.Width;
        int height = src.Height;
        dst.Create(src.Size(), src.Type());

        using (var tempMat = new Mat(height + (borderSize * 2), width + (borderSize * 2), src.Type()))
        using (var sumMat = new Mat())
        using (var sqSumMat = new Mat())
        {
            Cv2.CopyMakeBorder(src, tempMat, borderSize, borderSize, borderSize, borderSize, BorderTypes.Replicate, Scalar.All(0));
            Cv2.Integral(tempMat, sumMat, sqSumMat, MatType.CV_64FC1);

            using (var tSrcMat = new Mat<byte>(src))
            using (var tDstMat = new Mat<byte>(dst))
            using (var tSumMat = new Mat<double>(sumMat))
            using (var tSqSumMat = new Mat<double>(sqSumMat))
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

        using (var tImg = new Mat<byte>(img))
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
