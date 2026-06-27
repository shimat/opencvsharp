using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class SparseMatTest : TestBase
{
    [Fact]
    public void GetSetRoundTrip()
    {
        using var sm = new SparseMat([10, 20], MatType.CV_32SC1);
        sm.Set(3, 7, 42);
        Assert.Equal(42, sm.Get<int>(3, 7));
    }

    [Fact]
    public void EnumerateNonZero()
    {
        using var sm = new SparseMat([10, 20], MatType.CV_32SC1);
        sm.Ref<int>()[1, 2] = 10;
        sm.Ref<int>()[5, 6] = 20;
        sm.Ref<int>()[1, 2] = 11; // overwrite, still one stored element

        var elements = sm.EnumerateNonZero<int>().ToList();
        Assert.Equal(2, elements.Count);

        var map = elements.ToDictionary(e => (e.Index[0], e.Index[1]), e => e.Value);
        Assert.Equal(11, map[(1, 2)]);
        Assert.Equal(20, map[(5, 6)]);
    }

    [Fact]
    public void EnumerateNonZeroEmpty()
    {
        using var sm = new SparseMat([10, 20], MatType.CV_32SC1);
        Assert.Empty(sm.EnumerateNonZero<int>());
    }

    [Fact]
    public void EnumerateNonZeroTypeMismatchThrows()
    {
        using var sm = new SparseMat([10, 20], MatType.CV_32SC1);
        sm.Ref<int>()[0, 0] = 1;
        Assert.Throws<OpenCvSharpException>(() => sm.EnumerateNonZero<byte>().ToList());
    }

    [Fact]
    public void ToStringDescribesSparseMat()
    {
        using var sm = new SparseMat([10, 20], MatType.CV_8UC1);
        var s = sm.ToString();
        Assert.Contains("SparseMat", s, System.StringComparison.Ordinal);
        Assert.Contains("NzCount", s, System.StringComparison.Ordinal);
    }

    [Fact]
    public void CreateAndDispose()
    {
        using (var sm = new SparseMat([10, 20], MatType.CV_64FC1))
        {
            GC.KeepAlive(sm);
        }
    }

    [Fact]
    public void Dims()
    {
        using (var sm = new SparseMat([10, 20], MatType.CV_16SC1))
        {
            Assert.Equal(2, sm.Dims());
        }
    }

    [Fact]
    public void Channels()
    {
        using (var sm = new SparseMat([10, 20], MatType.CV_32FC4))
        {
            Assert.Equal(4, sm.Channels());
        }
        using (var sm = new SparseMat([10, 20], MatType.CV_16SC2))
        {
            Assert.Equal(2, sm.Channels());
        }
    }

    [Fact]
    public void ConvertToMat()
    {
        using (var sm = new SparseMat([10, 20], MatType.CV_8UC1))
        using (var m = new Mat())
        {
            sm.ConvertTo(m, MatType.CV_8UC1);
            Assert.Equal(10, m.Rows);
            Assert.Equal(20, m.Cols);
        }
    }
}
