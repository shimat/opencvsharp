using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Core;

/// <summary>
/// Verifies the ref-struct InputArray/OutputArray design (issue #1976): implicit conversions from
/// Mat/UMat/MatExpr/Scalar/double/Vec are allocation-free, and the explicit Create(...) factory
/// methods behave the same as their implicit-conversion equivalents.
/// </summary>
public class InputArrayTest : TestBase
{
    private static Mat Float3x3(params float[] v)
    {
        var m = new Mat(3, 3, MatType.CV_32FC1);
        m.SetArray(v);
        return m;
    }

    [Fact]
    public void Transpose_IsAllocationFree()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        using var dst = new Mat();

        Cv2.Transpose(src, dst); // warmup

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.Transpose(src, dst);
        var after = GC.GetAllocatedBytesForCurrentThread();

        Assert.Equal(0, after - before);
    }

    [Fact]
    public void Add_MatPlusScalar_IsAllocationFree()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var s = new Scalar(10);
        using var dst = new Mat();

        Cv2.Add(src, s, dst); // warmup

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.Add(src, s, dst);
        var after = GC.GetAllocatedBytesForCurrentThread();

        Assert.Equal(0, after - before);
    }

    [Fact]
    public void Transpose_Vec_IsAllocationFree()
    {
        var v = new Vec3d(1, 2, 3);
        using var dst = new Mat();

        Cv2.Transpose(v, dst); // warmup

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.Transpose(v, dst);
        var after = GC.GetAllocatedBytesForCurrentThread();

        Assert.Equal(0, after - before);
    }

    [Fact]
    public void MinMax_InputArray_WriteThrough()
    {
        // Guards the migrated core_min1/core_max1 (InputArray,InputArray,OutputArray): the native
        // call must write dst element-wise, not silently pick a MatExpr-returning overload.
        using var a = Float3x3(1, 9, 3, 9, 5, 9, 7, 9, 2);
        using var b = Float3x3(9, 2, 9, 4, 9, 6, 9, 8, 9);

        using var mn = new Mat();
        Cv2.Min(a, b, mn);
        using var mx = new Mat();
        Cv2.Max(a, b, mx);

        using var expectedMin = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 2);
        using var expectedMax = Float3x3(9, 9, 9, 9, 9, 9, 9, 9, 9);
        ImageEquals(expectedMin, mn);
        ImageEquals(expectedMax, mx);
    }

    [Fact]
    public void Create_FromVec_MatchesImplicitConversion()
    {
        var v = new Vec3d(1, 2, 3);

        using var actual = new Mat();
        Cv2.Transpose(InputArray.Create(v), actual);

        using var expected = new Mat();
        Cv2.Transpose(v, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void Create_From2DArray_MatchesManuallyBuiltMat()
    {
        double[,] a =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };

        using var actual = new Mat();
        Cv2.Transpose(InputArray.Create(a), actual);

        using var src = Mat.FromPixelData(3, 3, MatType.CV_64FC1, a);
        using var expected = new Mat();
        Cv2.Transpose(src, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void Create_From1DArray_MatchesManuallyBuiltMat()
    {
        double[] a = [1, 2, 3, 4, 5, 6];

        using var actual = new Mat();
        Cv2.Transpose(InputArray.Create(a), actual);

        using var src = Mat.FromPixelData(6, 1, MatType.CV_64FC1, a);
        using var expected = new Mat();
        Cv2.Transpose(src, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void Create_FromMat_MatchesImplicitConversion()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);

        using var actual = new Mat();
        Cv2.Transpose(InputArray.Create(src), actual);

        using var expected = new Mat();
        Cv2.Transpose(src, expected);

        ImageEquals(expected, actual);
    }
}
