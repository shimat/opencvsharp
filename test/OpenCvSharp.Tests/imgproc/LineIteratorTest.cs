using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

public class LineIteratorTest : TestBase
{
    [Fact]
    public void CountProperty()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);

        using var mat = Mat.Zeros(10, 10, MatType.CV_8UC1);
        using var lineIterator = new LineIterator(mat, p1, p2);

        // The native iterator is created eagerly, so Count is valid immediately.
        Assert.Equal(10, lineIterator.Count);
    }

    [Fact]
    public void Reenumerable()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);

        using var mat = new Mat(10, 10, MatType.CV_8UC1, new Scalar(2));
        using var lineIterator = new LineIterator(mat, p1, p2);

        // Each enumeration uses its own native iterator, so iterating twice
        // yields the same pixels.
        var first = lineIterator.AsValues<byte>().ToArray();
        var second = lineIterator.AsValues<byte>().ToArray();
        Assert.Equal(10, first.Length);
        Assert.Equal(first, second);
    }

    [Fact]
    public void AsValuesAfterEnumeration()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);

        using var mat = new Mat(10, 10, MatType.CV_8UC3, new Scalar(1, 2, 3));
        using var lineIterator = new LineIterator(mat, p1, p2);

        // AsValues dereferences each pixel while the image is alive, so the
        // returned values stay valid once materialized.
        var values = lineIterator.AsValues<Vec3b>().ToArray();
        Assert.Equal(10, values.Length);
        Assert.All(values, v => Assert.Equal(new Vec3b(1, 2, 3), v));
    }

    [Fact]
    public void CountPixels()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);

        using (var mat = Mat.Zeros(10, 10, MatType.CV_8UC1))
        using (var lineIterator = new LineIterator(mat, p1, p2))
        {
#pragma warning disable CA1829 
            var count = lineIterator.Count();
#pragma warning restore CA1829 
            Assert.Equal(10, count);
        }
    }

    [Fact]
    public void SumPixelsByte()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);

        using var mat = new Mat(10, 10, MatType.CV_8UC1, new Scalar(2));
        using var lineIterator = new LineIterator(mat, p1, p2);
        var sum = lineIterator.Sum(pixel => pixel.GetValue<byte>());
        Assert.Equal(10 * 2, sum);
    }

    [Fact]
    public void SumPixelsVec3b()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);

        using var mat = new Mat(10, 10, MatType.CV_8UC3, new Scalar(1, 2, 3));
        using var lineIterator = new LineIterator(mat, p1, p2);
        int b = 0, g = 0, r = 0;
        foreach (var pixel in lineIterator)
        {
            var value = pixel.GetValue<Vec3b>();
            (b, g, r) = (b + value.Item0, g + value.Item1, r + value.Item2);
        }
        Assert.Equal(10, b);
        Assert.Equal(20, g);
        Assert.Equal(30, r);
    }
}
