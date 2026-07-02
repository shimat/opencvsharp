using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Core;

/// <summary>
/// PROTOTYPE proof for the ref-struct InputArray/OutputArray redesign: one function
/// (<see cref="Cv2.TransposeRef"/>) wired through the handle+kind proxy path. Verifies numeric
/// correctness against the existing class-based path and, crucially, that repeated calls allocate
/// nothing on the managed heap (the implicit-conversion temporaries live on the stack and the
/// native _InputArray is built extern-side).
/// </summary>
public class InputArrayRefTest : TestBase
{
    private static Mat Float3x3(params float[] v)
    {
        var m = new Mat(3, 3, MatType.CV_32FC1);
        m.SetArray(v);
        return m;
    }

    [Fact]
    public void TransposeRef_MatchesClassBasedTranspose()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);

        using var actual = new Mat();
        Cv2.TransposeRef(src, actual);   // Mat -> InputArrayRef/OutputArrayRef (ref struct)

        using var expected = new Mat();
        Cv2.Transpose(src, expected);    // existing class-based InputArray/OutputArray path

        ImageEquals(expected, actual);
    }

    [Fact]
    public void TransposeRef_IsAllocationFree()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        using var dst = new Mat();

        // Warm up JIT / one-time setup.
        Cv2.TransposeRef(src, dst);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.TransposeRef(src, dst);
        var after = GC.GetAllocatedBytesForCurrentThread();

        Assert.Equal(0, after - before);
    }

    [Fact]
    public void AddRef_MatPlusMat_Matches()
    {
        using var a = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        using var b = Float3x3(9, 8, 7, 6, 5, 4, 3, 2, 1);

        using var actual = new Mat();
        Cv2.AddRef(a, b, actual);

        using var expected = new Mat();
        Cv2.Add(a, b, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void AddRef_MatPlusScalar_Matches()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var s = new Scalar(10);

        using var actual = new Mat();
        Cv2.AddRef(src, s, actual);   // InputArrayRef(Scalar) — scalar travels inline

        using var expected = new Mat();
        Cv2.Add(src, s, expected);    // class path (Scalar -> InputArray)

        ImageEquals(expected, actual);
    }

    [Fact]
    public void AddRef_MatPlusDouble_Matches()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);

        using var actual = new Mat();
        Cv2.AddRef(src, 5.0, actual); // InputArrayRef(double)

        using var expected = new Mat();
        Cv2.Add(src, new Scalar(5.0), expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void AddRef_MatPlusScalar_IsAllocationFree()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var s = new Scalar(10);
        using var dst = new Mat();

        Cv2.AddRef(src, s, dst); // warmup

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.AddRef(src, s, dst);
        var after = GC.GetAllocatedBytesForCurrentThread();

        Assert.Equal(0, after - before);
    }

    [Fact]
    public void AddRef_MatPlusMatExpr_Matches()
    {
        using var a = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        using var b = Float3x3(9, 8, 7, 6, 5, 4, 3, 2, 1);

        using var actual = new Mat();
        Cv2.AddRef(a, a + b, actual);   // (a + b) is a MatExpr -> InputArrayRef(MatExpr)

        using var expected = new Mat();
        Cv2.Add(a, a + b, expected);    // class path (MatExpr -> InputArray)

        ImageEquals(expected, actual);
    }

    [Fact]
    public void TransposeRef_Vec_Matches()
    {
        var v = new Vec3d(1, 2, 3);

        using var actual = new Mat();
        Cv2.TransposeRef(v, actual);   // Vec3d -> InputArrayRef(Vec), travels inline

        using var expected = new Mat();
        Cv2.Transpose(v, expected);    // Vec3d -> class InputArray(Vec)

        ImageEquals(expected, actual);
    }

    [Fact]
    public void TransposeRef_Vec_IsAllocationFree()
    {
        var v = new Vec3d(1, 2, 3);
        using var dst = new Mat();

        Cv2.TransposeRef(v, dst); // warmup

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.TransposeRef(v, dst);
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
    public void CompleteSymmRef_Matches()
    {
        using var actual = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        Cv2.CompleteSymmRef(actual);    // InputOutputArrayRef (in-place)

        using var expected = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        Cv2.CompleteSymm(expected);     // class InputOutputArray path

        ImageEquals(expected, actual);
    }

    [Fact]
    public void CompleteSymmRef_IsAllocationFree()
    {
        using var m = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);

        Cv2.CompleteSymmRef(m); // warmup

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 1000; i++)
            Cv2.CompleteSymmRef(m);
        var after = GC.GetAllocatedBytesForCurrentThread();

        Assert.Equal(0, after - before);
    }

    [Fact]
    public void Create_FromVec_MatchesClassBased()
    {
        var v = new Vec3d(1, 2, 3);

        using var actual = new Mat();
        Cv2.TransposeRef(InputArrayRef.Create(v), actual);

        using var expected = new Mat();
        using var classInputArray = InputArray.Create(v);
        Cv2.Transpose(classInputArray, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void Create_From2DArray_MatchesClassBased()
    {
        double[,] a =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };

        using var actual = new Mat();
        Cv2.TransposeRef(InputArrayRef.Create(a), actual);

        using var expected = new Mat();
        using var classInputArray = InputArray.Create(a);
        Cv2.Transpose(classInputArray, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void Create_From1DArray_MatchesClassBased()
    {
        double[] a = [1, 2, 3, 4, 5, 6];

        using var actual = new Mat();
        Cv2.TransposeRef(InputArrayRef.Create(a), actual);

        using var expected = new Mat();
        using var classInputArray = InputArray.Create(a);
        Cv2.Transpose(classInputArray, expected);

        ImageEquals(expected, actual);
    }

    [Fact]
    public void Create_FromMat_MatchesImplicitConversion()
    {
        using var src = Float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);

        using var actual = new Mat();
        Cv2.TransposeRef(InputArrayRef.Create(src), actual);

        using var expected = new Mat();
        Cv2.TransposeRef(src, expected);

        ImageEquals(expected, actual);
    }
}
