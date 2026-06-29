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
}
