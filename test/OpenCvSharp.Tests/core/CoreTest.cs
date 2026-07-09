using System.Diagnostics;
using Xunit;

#pragma warning disable CA5394 // Do not use insecure randomness
// ReSharper disable RedundantArgumentDefaultValue

namespace OpenCvSharp.Tests.Core;

public class CoreTest : TestBase
{
    private static readonly float[] KmeansSampleData = { 0f, 0.1f, 0.2f, 10f, 10.1f, 10.2f };
    private static readonly int[] UnsortedInts = { 3, 1, 4, 2 };

    [Fact]
    public void Add()
    {
        using var src1 = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var src2 = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var dst = new Mat();
        Cv2.Add(src1, src2, dst);

        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(2, dst.Rows);
        Assert.Equal(2, dst.Cols);

        Assert.Equal(2, dst.At<byte>(0, 0));
        Assert.Equal(4, dst.At<byte>(0, 1));
        Assert.Equal(6, dst.At<byte>(1, 0));
        Assert.Equal(8, dst.At<byte>(1, 1));
    }

    [Fact]
    public void AddScalar()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var dst = new Mat();
        Cv2.Add(new Scalar(10), src, dst);

        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(2, dst.Rows);
        Assert.Equal(2, dst.Cols);

        Assert.Equal(11, dst.At<byte>(0, 0));
        Assert.Equal(12, dst.At<byte>(0, 1));
        Assert.Equal(13, dst.At<byte>(1, 0));
        Assert.Equal(14, dst.At<byte>(1, 1));

        Cv2.Add(src, new Scalar(10), dst);
        Assert.Equal(11, dst.At<byte>(0, 0));
        Assert.Equal(12, dst.At<byte>(0, 1));
        Assert.Equal(13, dst.At<byte>(1, 0));
        Assert.Equal(14, dst.At<byte>(1, 1));

        var inputArray = InputArray.Create(10.0);
        Cv2.Add(src, inputArray, dst);
        Assert.Equal(11, dst.At<byte>(0, 0));
        Assert.Equal(12, dst.At<byte>(0, 1));
        Assert.Equal(13, dst.At<byte>(1, 0));
        Assert.Equal(14, dst.At<byte>(1, 1));
    }

    [Fact]
    public void Subtract()
    {
        using Mat image = LoadImage("lenna.png");
        using Mat dst1 = new ();
        using Mat dst2 = new Scalar(255) - image;
        Cv2.Subtract(new Scalar(255), image, dst1);

        ShowImagesWhenDebugMode(image, dst1, dst2);

        ImageEquals(dst1, dst2);
    }

    [Fact]
    public void SubtractScalar()
    {
        using var src = Mat.FromPixelData(3, 1, MatType.CV_16SC1, new short[]{1, 2, 3});
        using var dst = new Mat();
        Cv2.Subtract(src, 1, dst);
        Assert.Equal(0, dst.Get<short>(0));
        Assert.Equal(1, dst.Get<short>(1));
        Assert.Equal(2, dst.Get<short>(2));

        Cv2.Subtract(1, src, dst);
        Assert.Equal(0, dst.Get<short>(0));
        Assert.Equal(-1, dst.Get<short>(1));
        Assert.Equal(-2, dst.Get<short>(2));
    }

    [Fact]
    public void ScalarOperations()
    {
        var values = new[] { -1f };
        using var mat = Mat.FromPixelData(1, 1, MatType.CV_32FC1, values);
        Assert.Equal(values[0], mat.Get<float>(0, 0));

        Cv2.Subtract(mat, 1, mat);
        Assert.Equal(-2, mat.Get<float>(0, 0));

        Cv2.Multiply(mat, 2.0, mat);
        Assert.Equal(-4, mat.Get<float>(0, 0));

        Cv2.Divide(mat, 2.0, mat);
        Assert.Equal(-2, mat.Get<float>(0, 0));

        Cv2.Add(mat, 1, mat);
        Assert.Equal(-1, mat.Get<float>(0, 0));
    }

    [Fact]
    public void MatExprSubtractWithScalar()
    {
        // MatExpr - Scalar
        using (var src = Mat.FromPixelData(3, 1, MatType.CV_16SC1, new short[] { 1, 2, 3 }))
        {
            using Mat dst = src - new Scalar(1);
            Assert.Equal(0, dst.Get<short>(0));
            Assert.Equal(1, dst.Get<short>(1));
            Assert.Equal(2, dst.Get<short>(2));
        }

        // Scalar - Mat
        using (var src = Mat.FromPixelData(3, 1, MatType.CV_16SC1, new short[] { 1, 2, 3 }))
        {
            using Mat dst = new Scalar(1) - src;
            Assert.Equal(0, dst.Get<short>(0));
            Assert.Equal(-1, dst.Get<short>(1));
            Assert.Equal(-2, dst.Get<short>(2));
        }
    }

    [Fact]
    public void Sum()
    {
        using Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1);
        Scalar sum = Cv2.Sum(ones);
        Assert.Equal(100, (int)sum.Val0);
    }

    [Fact]
    public void Divide()
    {
        using var mat1 = Mat.FromPixelData(3, 1, MatType.CV_8UC1, new byte[] { 64, 128, 192 });
        using var mat2 = Mat.FromPixelData(3, 1, MatType.CV_8UC1, new byte[] { 2, 4, 8 });
        using var dst = new Mat();
        // default
        Cv2.Divide(mat1, mat2, dst, 1, -1);
        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(3, dst.Total());
        Assert.Equal(32, dst.Get<byte>(0));
        Assert.Equal(32, dst.Get<byte>(1));
        Assert.Equal(24, dst.Get<byte>(2));

        // scale
        Cv2.Divide(mat1, mat2, dst, 2, -1);
        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(3, dst.Total());
        Assert.Equal(64, dst.Get<byte>(0));
        Assert.Equal(64, dst.Get<byte>(1));
        Assert.Equal(48, dst.Get<byte>(2));

        // scale & dtype
        Cv2.Divide(mat1, mat2, dst, 2, MatType.CV_32SC1);
        Assert.Equal(MatType.CV_32SC1, dst.Type());
        Assert.Equal(3, dst.Total());
        Assert.Equal(64, dst.Get<int>(0));
        Assert.Equal(64, dst.Get<int>(1));
        Assert.Equal(48, dst.Get<int>(2));
    }

    [Fact]
    public void BorderInterpolate()
    {
        Assert.Equal(3, Cv2.BorderInterpolate(3, 10, BorderTypes.Reflect));
        Assert.Equal(3, Cv2.BorderInterpolate(3, 10, BorderTypes.Replicate));
        Assert.Equal(3, Cv2.BorderInterpolate(3, 10, BorderTypes.Constant));

        Assert.Equal(2, Cv2.BorderInterpolate(-3, 10, BorderTypes.Reflect));
        Assert.Equal(0, Cv2.BorderInterpolate(-3, 10, BorderTypes.Replicate));
        Assert.Equal(-1, Cv2.BorderInterpolate(-3, 10, BorderTypes.Constant));

        Assert.Equal(6, Cv2.BorderInterpolate(13, 10, BorderTypes.Reflect));
        Assert.Equal(9, Cv2.BorderInterpolate(13, 10, BorderTypes.Replicate));
        Assert.Equal(-1, Cv2.BorderInterpolate(13, 10, BorderTypes.Constant));
    }

    [Fact]
    public void CopyMakeBorder()
    {
        using var src = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));
        using var dst = new Mat();
        const int top = 1, bottom = 2, left = 3, right = 4;
        Cv2.CopyMakeBorder(src, dst, top, bottom, left, right, BorderTypes.Constant, Scalar.All(255));

        using var expected = new Mat(src.Rows + top + bottom, src.Cols + left + right, src.Type(), Scalar.All(0));
        Cv2.Rectangle(expected, new Point(0, 0), new Point(expected.Cols, top - 1), Scalar.All(255), -1);
        Cv2.Rectangle(expected, new Point(0, expected.Rows - bottom), new Point(expected.Cols, expected.Rows), Scalar.All(255), -1);
        Cv2.Rectangle(expected, new Point(0, 0), new Point(left - 1, expected.Rows), Scalar.All(255), -1);
        Cv2.Rectangle(expected, new Point(expected.Cols - right, 0), new Point(expected.Cols, expected.Rows), Scalar.All(255), -1);

        if (Debugger.IsAttached)
        {
            Window.ShowImages(dst, expected);
        }

        ImageEquals(dst, expected);
    }
        
    [Fact]
    // ReSharper disable once InconsistentNaming
    public void PSNR()
    {
        using var img1 = LoadImage("lenna.png");
        using var img2 = new Mat();
        Cv2.GaussianBlur(img1, img2, new Size(5, 5), 10);

        var psnr = Cv2.PSNR(img1, img2);

        Assert.Equal(29, psnr, 0);
    }

    [Fact]
    public void MinMaxLoc()
    {
        using Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1);
        ones.Set(1, 2, 0);
        ones.Set(3, 4, 2);

        Cv2.MinMaxLoc(ones, out var minVal, out var maxVal, out var minLoc, out var maxLoc);

        Assert.Equal(0, minVal);
        Assert.Equal(2, maxVal);
        Assert.Equal(new Point(2, 1), minLoc);
        Assert.Equal(new Point(4, 3), maxLoc);
    }

    [Fact]
    public void MinMaxIdx()
    {
        using Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1);
        ones.Set(1, 2, 0);
        ones.Set(3, 4, 2);

        int[] minIdx = new int[2];
        int[] maxIdx = new int[2];
        Cv2.MinMaxIdx(ones, out var minVal, out var maxVal, minIdx, maxIdx);

        Assert.Equal(0, minVal);
        Assert.Equal(2, maxVal);
        Assert.Equal([1, 2], minIdx);
        Assert.Equal([3, 4], maxIdx);
    }

    [Fact]
    public void MergeAndSplit()
    {
        using var img = LoadImage("lenna.png");

        Mat[]? planes = null; 
        try
        {
            Cv2.Split(img, out planes);
            Assert.Equal(3, planes.Length);

            using var dst = new Mat();
            Cv2.Merge(planes, dst);

            ImageEquals(img, dst);
        }
        finally
        {
            if (planes is not null)
            {
                foreach (var plane in planes)
                {
                    plane.Dispose();
                }
            }
        }
    }

    [Fact]
    public void Compare()
    {
        var bytes = new byte[] { 1, 2, 3, 4, 5, 6 };
        using var src = Mat.FromPixelData(bytes.Length, 1, MatType.CV_8UC1, bytes);
        using var dst = new Mat();

        Cv2.Compare(src, 3, dst, CmpTypes.LE);
        Assert.Equal(255, dst.Get<byte>(0));
        Assert.Equal(255, dst.Get<byte>(1));
        Assert.Equal(255, dst.Get<byte>(2));
        Assert.Equal(0, dst.Get<byte>(3));
        Assert.Equal(0, dst.Get<byte>(4));
        Assert.Equal(0, dst.Get<byte>(5));
    }

    [Fact]
    public void Rotate()
    {
        using var src = LoadImage("lenna.png");

        using var img90 = new Mat();
        Cv2.Rotate(src, img90, RotateFlags.Rotate90Clockwise);
        Assert.Equal(src.Width, img90.Height);
        Assert.Equal(src.Height, img90.Width);

        using var img180 = new Mat();
        Cv2.Rotate(src, img180, RotateFlags.Rotate180);
        Assert.Equal(src.Width, img180.Width);
        Assert.Equal(src.Height, img180.Height);
            
        Cv2.Rotate(img90, img90, RotateFlags.Rotate90Clockwise);
        ImageEquals(img90, img180);
    }

    [Fact]
    public void Concat()
    {
        using var src = LoadImage("lenna.png");
        using var hconcat = new Mat();
        using var vconcat = new Mat();

        Cv2.HConcat([src, src, src], hconcat);
        Cv2.VConcat([src, src, src], vconcat);

        Assert.Equal(src.Cols * 3, hconcat.Cols);
        Assert.Equal(src.Rows, hconcat.Rows);

        Assert.Equal(src.Cols, vconcat.Cols);
        Assert.Equal(src.Rows * 3, vconcat.Rows);
    }

    [Fact]
    public void Bitwise()
    {
        const int count = 256;
        var random = new Random(0);
        var array1 = Enumerable.Range(0, count).Select(i => (byte)i).OrderBy(_ => random.Next()).ToArray();
        var array2 = Enumerable.Range(0, count).Select(i => (byte)i).OrderBy(_ => random.Next()).ToArray();

        using var mat1 = Mat.FromPixelData(count, 1, MatType.CV_8UC1, array1);
        using var mat2 = Mat.FromPixelData(count, 1, MatType.CV_8UC1, array2);
        using var and = new Mat();
        using var or = new Mat();
        using var xor = new Mat();
        using var not = new Mat();
        Cv2.BitwiseAnd(mat1, mat2, and);
        Cv2.BitwiseOr(mat1, mat2, or);
        Cv2.BitwiseXor(mat1, mat2, xor);
        Cv2.BitwiseNot(mat1, not);

        for (int i = 0; i < count; i++)
        {
            Assert.Equal((byte)(array1[i] & array2[i]), and.Get<byte>(i));
            Assert.Equal((byte)(array1[i] | array2[i]), or.Get<byte>(i));
            Assert.Equal((byte)(array1[i] ^ array2[i]), xor.Get<byte>(i));
            Assert.Equal((byte)(~array1[i]), not.Get<byte>(i));
        }
    }

    [Fact]
    public void CopyTo()
    {
        using var src = LoadImage("lenna.png");
        var dst = new Mat();

        Cv2.CopyTo(src, dst);
        ImageEquals(src, dst);
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void SolveLP()
    {
        // https://qiita.com/peisuke/items/4cbc0d0bf388492ad2a5

        using var a = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new double[] { 3, 1, 2 });
        using var b = Mat.FromPixelData(3, 4, MatType.CV_64FC1, new double[] { 1, 1, 3, 30, 2, 2, 5, 24, 4, 1, 2, 36 });
        using var z = new Mat();
        Cv2.SolveLP(a, b, z);

        Assert.Equal(MatType.CV_64FC1, z.Type());
        Assert.Equal(3, z.Total());
        Assert.Equal(8, z.Get<double>(0));
        Assert.Equal(4, z.Get<double>(1));
        Assert.Equal(0, z.Get<double>(2));
    }

    [Fact]
    public void Partition()
    {
        var array = new[] {1, 3, 8, 8, 1, 3, 3, };

        int nClasses = Cv2.Partition(array, out var labels, (a, b) => a == b);

        Assert.Equal(3, nClasses);
        Assert.Equal([0, 1, 2, 2, 0, 1, 1], labels);
    }

    [Fact]
    public void Norm()
    {
        using var mat = new Mat(3, 1, MatType.CV_8UC1);
        mat.Set(0, (byte)10);
        mat.Set(1, (byte)20);
        mat.Set(2, (byte)30);
        var norm = Cv2.Norm(mat, NormTypes.L1);
        Assert.Equal(60, norm);
    }

    [Fact]
    public void NormVecb()
    {
        var vec = new Vec3b(10, 20, 30);
        var ia = InputArray.Create(vec);
        var norm = Cv2.Norm(ia, NormTypes.L1);
        Assert.Equal(60, norm);
    }

    [Fact]
    public void NormVeci()
    {
        var vec = new Vec4i(10000, 20000, 30000, 40000);
        var norm = Cv2.Norm(vec, NormTypes.L1);
        Assert.Equal(100000, norm);
    }

    [Fact]
    public void NormVecd()
    {
        var vec = new Vec2d(1.1111, 2.2222);
        var norm = Cv2.Norm(vec, NormTypes.L1);
        Assert.Equal(3.3333, norm, 9);
    }

    [Fact]
    public void ReduceArgMax()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 1, 4 });
        using var dst = new Mat();

        Cv2.ReduceArgMax(src, dst, axis: 0, lastIndex: true);

        Assert.Equal(MatType.CV_32SC1, dst.Type());
        Assert.Equal(1, dst.Rows);
        Assert.Equal(2, dst.Cols);

        Assert.Equal(1, dst.At<int>(0, 0)); // max along 1st column [1; 1], taking the last occurence
        Assert.Equal(1, dst.At<int>(0, 1)); // max along 2nd column [2; 4]
    }

    [Fact]
    public void ReduceArgMin()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 2, 1, 4, 4 });
        using var dst = new Mat();

        Cv2.ReduceArgMin(src, dst, axis: 1, lastIndex: false);

        Assert.Equal(MatType.CV_32SC1, dst.Type());
        Assert.Equal(2, dst.Rows);
        Assert.Equal(1, dst.Cols);

        Assert.Equal(1, dst.At<int>(0, 0)); // min along 1st row [2, 1]
        Assert.Equal(0, dst.At<int>(1, 0)); // min along 2nd row [4, 4], taking the first occurence
    }

    // --- ArrayProxy migration coverage (issue #1976): one test per migrated Cv2 method ---

    [Fact]
    public void AddWeighted()
    {
        using var src1 = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 10, 20, 30, 40 });
        using var src2 = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 2, 4, 6, 8 });
        using var dst = new Mat();
        Cv2.AddWeighted(src1, 0.5, src2, 0.5, 1.0, dst);

        Assert.Equal(7, dst.At<byte>(0, 0));
        Assert.Equal(13, dst.At<byte>(0, 1));
        Assert.Equal(19, dst.At<byte>(1, 0));
        Assert.Equal(25, dst.At<byte>(1, 1));
    }

    [Fact]
    public void BatchDistance()
    {
        using var src1 = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 0, 0 });
        using var src2 = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 3, 4 });
        using var dist = new Mat();
        using var nidx = new Mat();
        // k must be > 0 when nidx is provided; ask for the single nearest neighbour
        Cv2.BatchDistance(src1, src2, dist, (int)MatType.CV_32F, nidx, NormTypes.L2, k: 1);

        Assert.Equal(5.0, dist.At<float>(0, 0), 3);
    }

    [Fact]
    public void CalcCovarMatrix()
    {
        using var s0 = Mat.FromPixelData(1, 2, MatType.CV_64FC1, new double[] { 1, 2 });
        using var s1 = Mat.FromPixelData(1, 2, MatType.CV_64FC1, new double[] { 3, 4 });
        using var covar = new Mat();
        using var mean = new Mat();
        Cv2.CalcCovarMatrix(new[] { s0, s1 }, covar, mean, CovarFlags.Normal, MatType.CV_64F);

        Assert.Equal(2, covar.Rows);
        Assert.Equal(2, covar.Cols);
        Assert.Equal(2.0, mean.At<double>(0, 0), 6);
        Assert.Equal(3.0, mean.At<double>(0, 1), 6);
    }

    [Fact]
    public void CartToPolar()
    {
        using var x = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 3 });
        using var y = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 4 });
        using var mag = new Mat();
        using var ang = new Mat();
        Cv2.CartToPolar(x, y, mag, ang);

        Assert.Equal(5.0, mag.At<float>(0, 0), 3);
    }

    [Fact]
    public void CheckRange()
    {
        using var ok = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        Assert.True(Cv2.CheckRange(ok));

        using var bad = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, float.NaN, 3, 4 });
        Assert.False(Cv2.CheckRange(bad));
    }

    [Fact]
    public void ConvertScaleAbs()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { -1, 2, -3, 4 });
        using var dst = new Mat();
        Cv2.ConvertScaleAbs(src, dst, 2.0, 0.0);

        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(2, dst.At<byte>(0, 0));
        Assert.Equal(4, dst.At<byte>(0, 1));
        Assert.Equal(6, dst.At<byte>(1, 0));
        Assert.Equal(8, dst.At<byte>(1, 1));
    }

    [Fact]
    public void Dct()
    {
        using var src = Mat.FromPixelData(4, 1, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        using var freq = new Mat();
        using var restored = new Mat();
        Cv2.Dct(src, freq);
        Cv2.Dct(freq, restored, DctFlags.Inverse);

        for (var i = 0; i < 4; i++)
            Assert.Equal(src.At<float>(i, 0), restored.At<float>(i, 0), 3);
    }

    [Fact]
    public void Dft()
    {
        using var src = Mat.FromPixelData(8, 1, MatType.CV_32FC1, new float[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        using var freq = new Mat();
        using var restored = new Mat();
        Cv2.Dft(src, freq);
        Cv2.Idft(freq, restored, DftFlags.Scale | DftFlags.RealOutput);

        for (var i = 0; i < 8; i++)
            Assert.Equal(src.At<float>(i, 0), restored.At<float>(i, 0), 3);
    }

    [Fact]
    public void Eigen()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 2, 0, 0, 3 });
        using var values = new Mat();
        using var vectors = new Mat();
        Assert.True(Cv2.Eigen(src, values, vectors));

        Assert.Equal(3.0, values.At<float>(0, 0), 3);
        Assert.Equal(2.0, values.At<float>(1, 0), 3);
    }

    [Fact]
    public void EigenNonSymmetric()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 2, 0, 0, 3 });
        using var values = new Mat();
        using var vectors = new Mat();
        Cv2.EigenNonSymmetric(src, values, vectors);

        Assert.Equal(2, values.Total());
    }

    [Fact]
    public void Exp()
    {
        using var src = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 0, 1 });
        using var dst = new Mat();
        Cv2.Exp(src, dst);

        Assert.Equal(1.0, dst.At<float>(0, 0), 3);
        Assert.Equal(Math.E, dst.At<float>(0, 1), 3);
    }

    [Fact]
    public void ExtractChannel()
    {
        using var src = Mat.FromPixelData(1, 1, MatType.CV_8UC3, new byte[] { 10, 20, 30 });
        using var dst = new Mat();
        Cv2.ExtractChannel(src, dst, 1);

        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(20, dst.At<byte>(0, 0));
    }

    [Fact]
    public void HasNonZero()
    {
        using var zeros = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 0, 0, 0, 0 });
        Assert.False(Cv2.HasNonZero(zeros));

        using var withNonZero = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 0, 1, 0, 0 });
        Assert.True(Cv2.HasNonZero(withNonZero));
    }

    [Fact]
    public void FindNonZero()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 0, 1, 0, 1 });
        using var idx = new Mat();
        Cv2.FindNonZero(src, idx);

        Assert.Equal(2, idx.Total()); // two non-zero elements
    }

    [Fact]
    public void Flip()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var dst = new Mat();
        Cv2.Flip(src, dst, FlipMode.X);

        Assert.Equal(3, dst.At<byte>(0, 0));
        Assert.Equal(4, dst.At<byte>(0, 1));
        Assert.Equal(1, dst.At<byte>(1, 0));
        Assert.Equal(2, dst.At<byte>(1, 1));
    }

    [Fact]
    public void FlipND()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var dst = new Mat();
        Cv2.FlipND(src, dst, 0);

        Assert.Equal(3, dst.At<byte>(0, 0));
        Assert.Equal(4, dst.At<byte>(0, 1));
        Assert.Equal(1, dst.At<byte>(1, 0));
        Assert.Equal(2, dst.At<byte>(1, 1));
    }

    [Fact]
    public void Broadcast()
    {
        using var src = Mat.FromPixelData(1, 3, MatType.CV_32FC1, new float[] { 1, 2, 3 });
        int[] shapeData = [3, 3];
        using var shape = Mat.FromPixelData(1, 2, MatType.CV_32SC1, shapeData);
        using var dst = new Mat();
        Cv2.Broadcast(src, shape, dst);

        Assert.Equal(new Size(3, 3), dst.Size());
        Assert.Equal(1.0f, dst.At<float>(2, 0), 3);
        Assert.Equal(3.0f, dst.At<float>(2, 2), 3);
    }

    [Fact]
    public void InsertChannel()
    {
        using var dst = Mat.FromPixelData(1, 1, MatType.CV_8UC3, new byte[] { 0, 0, 0 });
        using var src = Mat.FromPixelData(1, 1, MatType.CV_8UC1, new byte[] { 50 });
        Cv2.InsertChannel(src, dst, 1);

        var v = dst.At<Vec3b>(0, 0);
        Assert.Equal(0, v.Item0);
        Assert.Equal(50, v.Item1);
        Assert.Equal(0, v.Item2);
    }

    [Fact]
    public void Kmeans()
    {
        using var data = Mat.FromPixelData(6, 1, MatType.CV_32FC1, KmeansSampleData);
        using var labels = new Mat();
        using var centers = new Mat();
        var criteria = new TermCriteria(CriteriaTypes.MaxIter | CriteriaTypes.Eps, 10, 1.0);
        Cv2.Kmeans(data, 2, labels, criteria, 3, KMeansFlags.PpCenters, centers);

        Assert.Equal(6, labels.Rows);
        Assert.NotEqual(labels.At<int>(0, 0), labels.At<int>(5, 0));
    }

    [Fact]
    public void LUT()
    {
        using var src = Mat.FromPixelData(1, 4, MatType.CV_8UC1, new byte[] { 0, 1, 2, 3 });
        var lutData = new byte[256];
        for (var i = 0; i < 256; i++)
            lutData[i] = (byte)Math.Min(255, i * 10);
        using var lut = Mat.FromPixelData(1, 256, MatType.CV_8UC1, lutData);
        using var dst = new Mat();
        Cv2.LUT(src, lut, dst);

        Assert.Equal(0, dst.At<byte>(0, 0));
        Assert.Equal(10, dst.At<byte>(0, 1));
        Assert.Equal(20, dst.At<byte>(0, 2));
        Assert.Equal(30, dst.At<byte>(0, 3));
    }

    [Fact]
    public void Log()
    {
        using var src = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 1f, (float)Math.E });
        using var dst = new Mat();
        Cv2.Log(src, dst);

        Assert.Equal(0.0, dst.At<float>(0, 0), 3);
        Assert.Equal(1.0, dst.At<float>(0, 1), 3);
    }

    [Fact]
    public void Magnitude()
    {
        using var x = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 3 });
        using var y = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 4 });
        using var mag = new Mat();
        Cv2.Magnitude(x, y, mag);

        Assert.Equal(5.0, mag.At<float>(0, 0), 3);
    }

    [Fact]
    public void Mahalanobis()
    {
        using var v1 = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 0, 0 });
        using var v2 = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 3, 4 });
        using var icovar = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 0, 0, 1 });
        var d = Cv2.Mahalanobis(v1, v2, icovar);

        Assert.Equal(5.0, d, 3);
    }

    [Fact]
    public void Mean()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 2, 4, 6, 8 });
        var mean = Cv2.Mean(src);

        Assert.Equal(5.0, mean.Val0, 6);
    }

    [Fact]
    public void MeanStdDev()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 2, 4, 6, 8 });
        using var mean = new Mat();
        using var stddev = new Mat();
        Cv2.MeanStdDev(src, mean, stddev);

        Assert.Equal(5.0, mean.At<double>(0, 0), 6);
        Assert.Equal(Math.Sqrt(5.0), stddev.At<double>(0, 0), 6);
    }

    [Fact]
    public void MulSpectrums()
    {
        using var a = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 2, 0 });
        using var b = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 3, 0 });
        using var c = new Mat();
        Cv2.MulSpectrums(a, b, c, DftFlags.None);

        var v = c.At<Vec2f>(0, 0);
        Assert.Equal(6.0, v.Item0, 3);
        Assert.Equal(0.0, v.Item1, 3);
    }

    [Fact]
    public void MulTransposed()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        using var dst = new Mat();
        Cv2.MulTransposed(src, dst, true);

        // A^T * A = [[10,14],[14,20]]
        Assert.Equal(10.0, dst.At<float>(0, 0), 3);
        Assert.Equal(14.0, dst.At<float>(0, 1), 3);
        Assert.Equal(14.0, dst.At<float>(1, 0), 3);
        Assert.Equal(20.0, dst.At<float>(1, 1), 3);
    }

    [Fact]
    public void PCACompute()
    {
        using var data = Mat.FromPixelData(3, 2, MatType.CV_32FC1, new float[] { 0, 0, 1, 1, 2, 2 });
        using var mean = new Mat();
        using var eigenvectors = new Mat();
        Cv2.PCACompute(data, mean, eigenvectors, 1);

        Assert.Equal(1, eigenvectors.Rows);
        Assert.Equal(2, eigenvectors.Cols);
    }

    [Fact]
    public void PCAComputeVar()
    {
        using var data = Mat.FromPixelData(3, 2, MatType.CV_32FC1, new float[] { 0, 0, 1, 1, 2, 2 });
        using var mean = new Mat();
        using var eigenvectors = new Mat();
        Cv2.PCAComputeVar(data, mean, eigenvectors, 0.95);

        Assert.True(eigenvectors.Rows >= 1);
        Assert.Equal(2, eigenvectors.Cols);
    }

    [Fact]
    public void PCAProjectAndBackProject()
    {
        using var data = Mat.FromPixelData(3, 2, MatType.CV_32FC1, new float[] { 0, 0, 1, 1, 2, 2 });
        using var mean = new Mat();
        using var eigenvectors = new Mat();
        Cv2.PCACompute(data, mean, eigenvectors, 1);

        using var projected = new Mat();
        Cv2.PCAProject(data, mean, eigenvectors, projected);
        Assert.Equal(3, projected.Rows);

        using var restored = new Mat();
        Cv2.PCABackProject(projected, mean, eigenvectors, restored);
        Assert.Equal(data.Rows, restored.Rows);
        Assert.Equal(data.Cols, restored.Cols);
    }

    [Fact]
    public void PatchNaNs()
    {
        using var a = Mat.FromPixelData(1, 4, MatType.CV_32FC1, new float[] { 1, float.NaN, 3, 4 });
        Cv2.PatchNaNs(a, 0.0);

        Assert.Equal(0.0, a.At<float>(0, 1), 3);
        Assert.Equal(1.0, a.At<float>(0, 0), 3);
    }

    [Fact]
    public void FiniteMask()
    {
        using var src = Mat.FromPixelData(1, 3, MatType.CV_32FC1, new[] { 1.0f, float.NaN, float.PositiveInfinity });
        using var mask = new Mat();
        Cv2.FiniteMask(src, mask);

        Assert.Equal(255, mask.At<byte>(0, 0));
        Assert.Equal(0, mask.At<byte>(0, 1));
        Assert.Equal(0, mask.At<byte>(0, 2));
    }

    [Fact]
    public void TransposeND()
    {
        using var src = Mat.FromPixelData(2, 3, MatType.CV_32FC1, new float[] { 1, 2, 3, 4, 5, 6 });
        using var dst = new Mat();
        Cv2.TransposeND(src, [1, 0], dst);

        Assert.Equal(new Size(2, 3), dst.Size());
        Assert.Equal(1.0f, dst.At<float>(0, 0), 3);
        Assert.Equal(4.0f, dst.At<float>(0, 1), 3);
    }

    [Fact]
    public void UseIPP()
    {
        var original = Cv2.UseIPP();
        try
        {
            Cv2.SetUseIPP(false);
            Assert.False(Cv2.UseIPP());
            Cv2.SetUseIPP(true);
            Assert.True(Cv2.UseIPP());
        }
        finally
        {
            Cv2.SetUseIPP(original);
        }
    }

    [Fact]
    public void GetIppVersion()
    {
        Assert.NotNull(Cv2.GetIppVersion());
    }

    [Fact]
    public void UseIppNotExact()
    {
        var original = Cv2.UseIppNotExact();
        try
        {
            Cv2.SetUseIppNotExact(!original);
            Assert.Equal(!original, Cv2.UseIppNotExact());
        }
        finally
        {
            Cv2.SetUseIppNotExact(original);
        }
    }

    [Fact]
    public void PerspectiveTransform()
    {
        using var src = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 2, 3 });
        using var m = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 });
        using var dst = new Mat();
        Cv2.PerspectiveTransform(src, dst, m);

        var v = dst.At<Vec2f>(0, 0);
        Assert.Equal(2.0, v.Item0, 3);
        Assert.Equal(3.0, v.Item1, 3);
    }

    [Fact]
    public void Phase()
    {
        using var x = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 1 });
        using var y = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 1 });
        using var angle = new Mat();
        Cv2.Phase(x, y, angle, angleInDegrees: true);

        Assert.Equal(45.0, angle.At<float>(0, 0), 1); // single-precision phase, ~44.99 deg
    }

    [Fact]
    public void PolarToCart()
    {
        using var mag = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 5 });
        using var angle = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new float[] { 0 });
        using var x = new Mat();
        using var y = new Mat();
        Cv2.PolarToCart(mag, angle, x, y);

        Assert.Equal(5.0, x.At<float>(0, 0), 3);
        Assert.Equal(0.0, y.At<float>(0, 0), 3);
    }

    [Fact]
    public void Pow()
    {
        using var src = Mat.FromPixelData(1, 2, MatType.CV_32FC1, new float[] { 2, 3 });
        using var dst = new Mat();
        Cv2.Pow(src, 2.0, dst);

        Assert.Equal(4.0, dst.At<float>(0, 0), 3);
        Assert.Equal(9.0, dst.At<float>(0, 1), 3);
    }

    [Fact]
    public void RandShuffle()
    {
        using var dst = Mat.FromPixelData(1, 10, MatType.CV_32FC1, new float[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        Cv2.RandShuffle(dst, 1.0);

        // shuffling is a permutation, so the sum is invariant
        Assert.Equal(45.0, Cv2.Sum(dst).Val0, 3);
    }

    [Fact]
    public void Reduce()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        using var dst = new Mat();
        Cv2.Reduce(src, dst, ReduceDimension.Row, ReduceTypes.Sum, (int)MatType.CV_32F);

        // reduce to a single row: column sums [1+3, 2+4]
        Assert.Equal(4.0, dst.At<float>(0, 0), 3);
        Assert.Equal(6.0, dst.At<float>(0, 1), 3);
    }

    [Fact]
    public void SVDecompAndBackSubst()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 2, 0, 0, 3 });
        using var w = new Mat();
        using var u = new Mat();
        using var vt = new Mat();
        Cv2.SVDecomp(src, w, u, vt);

        Assert.Equal(3.0, w.At<float>(0, 0), 3);
        Assert.Equal(2.0, w.At<float>(1, 0), 3);

        // solve src * x = rhs through the decomposition; rhs = [2, 3] -> x = [1, 1]
        using var rhs = Mat.FromPixelData(2, 1, MatType.CV_32FC1, new float[] { 2, 3 });
        using var dst = new Mat();
        Cv2.SVBackSubst(w, u, vt, rhs, dst);

        Assert.Equal(1.0, dst.At<float>(0, 0), 3);
        Assert.Equal(1.0, dst.At<float>(1, 0), 3);
    }

    [Fact]
    public void ScaleAdd()
    {
        using var src1 = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        using var src2 = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 1, 1, 1 });
        using var dst = new Mat();
        Cv2.ScaleAdd(src1, 2.0, src2, dst);

        Assert.Equal(3.0, dst.At<float>(0, 0), 3);
        Assert.Equal(5.0, dst.At<float>(0, 1), 3);
        Assert.Equal(7.0, dst.At<float>(1, 0), 3);
        Assert.Equal(9.0, dst.At<float>(1, 1), 3);
    }

    [Fact]
    public void SetIdentity()
    {
        using var mtx = new Mat(3, 3, MatType.CV_32FC1, Scalar.All(0));
        Cv2.SetIdentity(mtx, new Scalar(1));

        Assert.Equal(1.0, mtx.At<float>(0, 0), 3);
        Assert.Equal(1.0, mtx.At<float>(1, 1), 3);
        Assert.Equal(0.0, mtx.At<float>(0, 1), 3);
    }

    [Fact]
    public void SolveCubic()
    {
        // x^3 - 6x^2 + 11x - 6 = (x-1)(x-2)(x-3)
        using var coeffs = Mat.FromPixelData(1, 4, MatType.CV_64FC1, new double[] { 1, -6, 11, -6 });
        using var roots = new Mat();
        var n = Cv2.SolveCubic(coeffs, roots);

        Assert.Equal(3, n);
    }

    [Fact]
    public void SolvePoly()
    {
        // x^2 - 1 = 0 -> roots +-1; coeffs are c0 + c1*x + c2*x^2
        using var coeffs = Mat.FromPixelData(1, 3, MatType.CV_64FC1, new double[] { -1, 0, 1 });
        using var roots = new Mat();
        Cv2.SolvePoly(coeffs, roots);

        Assert.Equal(2, roots.Total());
    }

    [Fact]
    public void Sort()
    {
        using var src = Mat.FromPixelData(1, 4, MatType.CV_32SC1, UnsortedInts);
        using var dst = new Mat();
        Cv2.Sort(src, dst, SortFlags.EveryRow | SortFlags.Ascending);

        Assert.Equal(1, dst.At<int>(0, 0));
        Assert.Equal(2, dst.At<int>(0, 1));
        Assert.Equal(3, dst.At<int>(0, 2));
        Assert.Equal(4, dst.At<int>(0, 3));
    }

    [Fact]
    public void SortIdx()
    {
        using var src = Mat.FromPixelData(1, 4, MatType.CV_32SC1, UnsortedInts);
        using var dst = new Mat();
        Cv2.SortIdx(src, dst, SortFlags.EveryRow | SortFlags.Ascending);

        // ascending order maps to source indices 1(=1), 3(=2), 0(=3), 2(=4)
        Assert.Equal(1, dst.At<int>(0, 0));
        Assert.Equal(3, dst.At<int>(0, 1));
        Assert.Equal(0, dst.At<int>(0, 2));
        Assert.Equal(2, dst.At<int>(0, 3));
    }

    [Fact]
    public void Trace()
    {
        using var mtx = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        var tr = Cv2.Trace(mtx);

        Assert.Equal(5.0, tr.Val0, 3);
    }

    [Fact]
    public void Transform()
    {
        using var src = Mat.FromPixelData(1, 1, MatType.CV_32FC2, new float[] { 2, 3 });
        using var m = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 1, 0, 0, 1 });
        using var dst = new Mat();
        Cv2.Transform(src, dst, m);

        var v = dst.At<Vec2f>(0, 0);
        Assert.Equal(2.0, v.Item0, 3);
        Assert.Equal(3.0, v.Item1, 3);
    }
}
