using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class SparseMatTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var sm = new SparseMat<double>(10, 20);
        Assert.Equal(2, sm.Dims());
        Assert.Equal(MatType.CV_64FC1, (MatType)sm.Type());
    }

    [Fact]
    public void Channels()
    {
        using var sm = new SparseMat<Vec4f>(10, 20);
        Assert.Equal(4, sm.Channels());
        Assert.Equal(MatType.CV_32FC4, (MatType)sm.Type());
    }

    [Fact]
    public void IndexerRoundTrip()
    {
        using var sm = new SparseMat<int>(10, 20);
        sm[3, 7] = 42;
        Assert.Equal(42, sm[3, 7]);
    }

    [Fact]
    public void ReadingAbsentElementDoesNotCreateIt()
    {
        using var sm = new SparseMat<int>(10, 20);
        Assert.Equal(0, sm[5, 5]);     // value semantics: returns default
        Assert.Equal(0, sm.NzCount()); // ...and does not insert a node
    }

    [Fact]
    public void TryGetValueAndContains()
    {
        using var sm = new SparseMat<int>(10, 20);
        sm[1, 2] = 7;

        Assert.True(sm.Contains([1, 2]));
        Assert.True(sm.TryGetValue([1, 2], out var v));
        Assert.Equal(7, v);

        Assert.False(sm.Contains([0, 0]));
        Assert.False(sm.TryGetValue([0, 0], out var v2));
        Assert.Equal(0, v2);
        // Probing [0,0] must not have created a node; only [1,2] is stored.
        Assert.Equal(1, sm.NzCount());
    }

    [Fact]
    public void Remove()
    {
        using var sm = new SparseMat<int>(10, 20);
        sm[1, 2] = 7;
        Assert.Equal(1, sm.NzCount());

        Assert.True(sm.Remove([1, 2]));
        Assert.Equal(0, sm.NzCount());
        Assert.False(sm.Remove([1, 2]));
    }

    [Fact]
    public void GetValueRefAccumulates()
    {
        using var sm = new SparseMat<int>(10, 20);
        for (var i = 0; i < 5; i++)
            sm.GetValueRef([3, 4])++;
        Assert.Equal(5, sm[3, 4]);
        Assert.Equal(1, sm.NzCount());
    }

    [Fact]
    public void EnumerateNonZero()
    {
        using var sm = new SparseMat<int>(10, 20);
        sm[1, 2] = 10;
        sm[5, 6] = 20;
        sm[1, 2] = 11; // overwrite, still one stored element

        var elements = sm.EnumerateNonZero().ToList();
        Assert.Equal(2, elements.Count);

        var map = elements.ToDictionary(e => (e.Index[0], e.Index[1]), e => e.Value);
        Assert.Equal(11, map[(1, 2)]);
        Assert.Equal(20, map[(5, 6)]);
    }

    [Fact]
    public void EnumerateNonZeroEmpty()
    {
        using var sm = new SparseMat<int>(10, 20);
        Assert.Empty(sm.EnumerateNonZero());
    }

    [Fact]
    public void FromMatAndToMat()
    {
        using var dense = new Mat(3, 3, MatType.CV_32SC1, Scalar.All(0));
        dense.Set(1, 1, 5);

        using var sm = SparseMat<int>.FromMat(dense);
        Assert.Equal(5, sm[1, 1]);

        using var back = sm.ToMat();
        Assert.Equal(5, back.Get<int>(1, 1));
        Assert.Equal(0, back.Get<int>(0, 0));
    }

    [Fact]
    public void FromMatTypeMismatchThrows()
    {
        using var dense = new Mat(3, 3, MatType.CV_8UC1, Scalar.All(0));
        Assert.Throws<OpenCvSharpException>(() => SparseMat<int>.FromMat(dense));
    }

    [Fact]
    public void AsTypedView()
    {
        using var dense = new Mat(3, 3, MatType.CV_32SC1, Scalar.All(0));
        using var erased = SparseMat.FromMat(dense);  // type-erased base

        using var typed = erased.As<int>();
        typed[2, 2] = 9;
        Assert.Equal(9, typed[2, 2]);

        Assert.Throws<OpenCvSharpException>(() => erased.As<float>());
    }

    [Fact]
    public void ToStringDescribesSparseMat()
    {
        using var sm = new SparseMat<byte>(10, 20);
        var s = sm.ToString();
        Assert.Contains("SparseMat", s, System.StringComparison.Ordinal);
        Assert.Contains("NzCount", s, System.StringComparison.Ordinal);
    }
}
