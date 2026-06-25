using OpenCvSharp.Internal.Vectors;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable InconsistentNaming

/// <summary>
/// Unit tests for the generic <see cref="StdVector{T}"/> base and the
/// blittable-element StdVector&lt;T&gt; wrappers (construction, Size, ElemPtr, ToArray).
/// </summary>
public class StdVectorTest : TestBase
{
    [Fact]
    public void Byte_RoundTrip()
    {
        var data = new byte[] { 1, 2, 3, 255, 0 };
        using var vec = new StdVector<byte>(data);
        Assert.Equal(data.Length, vec.Size);
        Assert.NotEqual(IntPtr.Zero, vec.ElemPtr);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Int32_RoundTrip()
    {
        var data = new[] { -1, 0, 1, int.MaxValue, int.MinValue };
        using var vec = new StdVector<int>(data);
        Assert.Equal(data.Length, vec.Size);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Float_RoundTrip()
    {
        var data = new[] { 0f, 1.5f, -2.25f, 100f };
        using var vec = new StdVector<float>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Double_RoundTrip()
    {
        var data = new[] { 0.0, 1.5, -2.25, 1e10 };
        using var vec = new StdVector<double>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void SizeConstructor_AllocatesRequestedCount()
    {
        using var vec = new StdVector<int>((nuint)4);
        Assert.Equal(4, vec.Size);
        Assert.Equal(new[] { 0, 0, 0, 0 }, vec.ToArray());
    }

    [Fact]
    public void EmptyVector_ReturnsEmptyArray()
    {
        using var vec = new StdVector<float>();
        Assert.Equal(0, vec.Size);
        Assert.Empty(vec.ToArray());
    }

    [Fact]
    public void Point_RoundTrip()
    {
        var data = new[] { new Point(1, 2), new Point(-3, 4), new Point(5, -6) };
        using var vec = new StdVector<Point>(data);
        var dst = vec.ToArray();
        Assert.Equal(data.Length, dst.Length);
        Assert.Equal(data, dst);
    }

    [Fact]
    public void Point2f_RoundTrip()
    {
        var data = new[] { new Point2f(1.5f, 2.5f), new Point2f(-3.5f, 4.5f) };
        using var vec = new StdVector<Point2f>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Point3f_RoundTrip()
    {
        var data = new[] { new Point3f(1, 2, 3), new Point3f(-4, -5, -6) };
        using var vec = new StdVector<Point3f>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Rect_RoundTrip()
    {
        var data = new[] { new Rect(0, 0, 10, 20), new Rect(5, 5, 1, 1) };
        using var vec = new StdVector<Rect>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Rect2d_RoundTrip()
    {
        var data = new[] { new Rect2d(0.5, 1.5, 10, 20), new Rect2d(2, 3, 4, 5) };
        using var vec = new StdVector<Rect2d>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void RotatedRect_RoundTrip()
    {
        var data = new[]
        {
            new RotatedRect(new Point2f(10, 20), new Size2f(30, 40), 15f),
            new RotatedRect(new Point2f(1, 2), new Size2f(3, 4), -45f),
        };
        using var vec = new StdVector<RotatedRect>(data);
        var dst = vec.ToArray();
        Assert.Equal(data.Length, dst.Length);
        Assert.Equal(data[0].Center, dst[0].Center);
        Assert.Equal(data[0].Size, dst[0].Size);
        Assert.Equal(data[0].Angle, dst[0].Angle);
    }

    [Fact]
    public void KeyPoint_RoundTrip()
    {
        var data = new[]
        {
            new KeyPoint(1f, 2f, 3f, 10f, 0.5f, 1, 7),
            new KeyPoint(4f, 5f, 6f, 20f, 0.9f, 2, 8),
        };
        using var vec = new StdVector<KeyPoint>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void DMatch_RoundTrip()
    {
        var data = new[] { new DMatch(0, 1, 0.5f), new DMatch(2, 3, 1.5f) };
        using var vec = new StdVector<DMatch>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Vec4f_RoundTrip()
    {
        var data = new[] { new Vec4f(1, 2, 3, 4), new Vec4f(-5, -6, -7, -8) };
        using var vec = new StdVector<Vec4f>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void Vec4i_RoundTrip()
    {
        var data = new[] { new Vec4i(1, 2, 3, 4), new Vec4i(-5, -6, -7, -8) };
        using var vec = new StdVector<Vec4i>(data);
        Assert.Equal(data, vec.ToArray());
    }

    [Fact]
    public void ReinterpretToArray_SameSize_Succeeds()
    {
        var data = new[] { new Vec4f(1, 2, 3, 4) };
        using var vec = new StdVector<Vec4f>(data);
        // Vec4i has the same byte size (4 * 4 bytes) as Vec4f, so the reinterpret is allowed.
        var reinterpreted = vec.ToArray<Vec4i>();
        Assert.Single(reinterpreted);
    }

    [Fact]
    public void ReinterpretToArray_SizeMismatch_Throws()
    {
        var data = new[] { new Vec4f(1, 2, 3, 4) };
        using var vec = new StdVector<Vec4f>(data);
        // Vec2f (8 bytes) does not match Vec4f (16 bytes).
        Assert.Throws<OpenCvSharpException>(() => vec.ToArray<Vec2f>());
    }

    [Fact]
    public void Vec_New1Only_StartsEmpty()
    {
        using var v2 = new StdVector<Vec2f>();
        using var v3 = new StdVector<Vec3f>();
        using var v6f = new StdVector<Vec6f>();
        using var v6d = new StdVector<Vec6d>();
        using var p2d = new StdVector<Point2d>();
        Assert.Equal(0, v2.Size);
        Assert.Equal(0, v3.Size);
        Assert.Equal(0, v6f.Size);
        Assert.Equal(0, v6d.Size);
        Assert.Equal(0, p2d.Size);
        Assert.Empty(v2.ToArray());
    }
}
