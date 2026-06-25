using Xunit;

namespace OpenCvSharp.Tests.Core;

// Tests for the OpenCV 5 MatShape value type and its Mat integration.
public class MatShapeTest : TestBase
{
    [Fact]
    public void NdShapeBasics()
    {
        var shape = new MatShape(2, 3, 4);
        Assert.Equal(3, shape.Dims);
        Assert.False(shape.IsEmpty);
        Assert.False(shape.IsScalar);
        Assert.Equal(24, shape.Total);
        Assert.Equal(2, shape[0]);
        Assert.Equal(3, shape[1]);
        Assert.Equal(4, shape[2]);
        Assert.Equal(new[] { 2, 3, 4 }, shape.ToArray());
    }

    [Fact]
    public void ScalarShape()
    {
        var shape = MatShape.Scalar();
        Assert.Equal(0, shape.Dims);
        Assert.True(shape.IsScalar);
        Assert.False(shape.IsEmpty);
        Assert.Equal(1, shape.Total);
    }

    [Fact]
    public void EmptyShape()
    {
        var shape = MatShape.Empty;
        Assert.Equal(0, shape.Dims);
        Assert.True(shape.IsEmpty);
        Assert.False(shape.IsScalar);
        Assert.Equal(0, shape.Total);
        Assert.Equal(default(MatShape), shape);
    }

    [Fact]
    public void ImplicitFromIntArray()
    {
        MatShape shape = new[] { 5, 6 };
        Assert.Equal(2, shape.Dims);
        Assert.Equal(5, shape[0]);
        Assert.Equal(6, shape[1]);

        MatShape empty = (int[]?)null;
        Assert.True(empty.IsEmpty);
    }

    [Fact]
    public void Equality()
    {
        Assert.Equal(new MatShape(2, 3), new MatShape(2, 3));
        Assert.NotEqual(new MatShape(2, 3), new MatShape(3, 2));
        Assert.NotEqual(new MatShape(new[] { 2, 3 }, DataLayout.NCHW), new MatShape(new[] { 2, 3 }, DataLayout.NHWC));
    }

    [Fact]
    public void LayoutAndChannels()
    {
        var shape = new MatShape(new[] { 1, 8, 16, 16 }, DataLayout.NCHW, 8);
        Assert.Equal(DataLayout.NCHW, shape.Layout);
        Assert.Equal(8, shape.Channels);
    }

    [Fact]
    public void MatShapeGetter()
    {
        using var mat = new Mat(3, 4, MatType.CV_8UC1);
        var shape = mat.Shape();
        Assert.Equal(2, shape.Dims);
        Assert.Equal(3, shape[0]);
        Assert.Equal(4, shape[1]);
    }

    [Fact]
    public void ConstructFromShapeRoundTrip()
    {
        using var mat = new Mat(new MatShape(2, 3, 4), MatType.CV_32FC1);
        Assert.Equal(3, mat.Dims);

        var shape = mat.Shape();
        Assert.Equal(new[] { 2, 3, 4 }, shape.ToArray());
    }

    [Fact]
    public void ConstructFromShapeWithScalar()
    {
        using var mat = new Mat(new MatShape(2, 2), MatType.CV_8UC1, Scalar.All(7));
        Assert.Equal(7, mat.At<byte>(0, 0));
        Assert.Equal(7, mat.At<byte>(1, 1));
    }

    [Fact]
    public void ReshapeWithMatShape()
    {
        using var mat = new Mat(new MatShape(4, 6), MatType.CV_8UC1);
        using var reshaped = mat.Reshape(0, new MatShape(2, 3, 4));
        Assert.Equal(3, reshaped.Dims);
        Assert.Equal(new[] { 2, 3, 4 }, reshaped.Shape().ToArray());
    }

    [Fact]
    public void ZerosAndOnesWithMatShape()
    {
        using var zeros = Mat.Zeros(new MatShape(2, 3), MatType.CV_8UC1).ToMat();
        Assert.Equal(0, zeros.At<byte>(0, 0));
        Assert.Equal(new[] { 2, 3 }, zeros.Shape().ToArray());

        using var ones = Mat.Ones(new MatShape(2, 3), MatType.CV_8UC1).ToMat();
        Assert.Equal(1, ones.At<byte>(0, 0));
    }
}
