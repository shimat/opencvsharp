using Xunit;

namespace OpenCvSharp.Tests.Core;

public class CoreTensorTest : TestBase
{
    [Fact]
    public void ConcatAndSplitAlongAxisPreserveChannels()
    {
        using var first = new Mat([2, 1, 3], MatType.CV_8UC2, new Scalar(1, 2));
        using var second = new Mat([2, 2, 3], MatType.CV_8UC2, new Scalar(3, 4));
        using var concatenated = new Mat();
        Cv2.Concat([first, second], -2, concatenated);

        Assert.Equal([2, 3, 3], concatenated.Shape().ToArray());
        Assert.Equal(new Vec2b(1, 2), concatenated.At<Vec2b>(0, 0, 2));
        Assert.Equal(new Vec2b(3, 4), concatenated.At<Vec2b>(1, 2, 2));

        var parts = Cv2.Split(concatenated, -2, [1, 2]);
        try
        {
            Assert.Equal(2, parts.Length);
            Assert.Equal(first.Shape(), parts[0].Shape());
            Assert.Equal(second.Shape(), parts[1].Shape());
            Assert.Equal(0, Cv2.Norm(first, parts[0], NormTypes.INF));
            Assert.Equal(0, Cv2.Norm(second, parts[1], NormTypes.INF));
        }
        finally
        {
            foreach (var part in parts)
                part.Dispose();
        }
    }

    [Fact]
    public void SliceAndRepeatSupportNegativeStepsAndMultipleAxes()
    {
        using var src = Mat.FromPixelData([2, 2, 3], MatType.CV_32SC1, Enumerable.Range(1, 12).ToArray());
        using var slice = new Mat();
        Cv2.Slice(src, [1, 0, 2], [-1, 1, -1], [-1, 1, -2], slice);

        Assert.Equal([2, 1, 2], slice.Shape().ToArray());
        Assert.Equal(9, slice.At<int>(0, 0, 0));
        Assert.Equal(1, slice.At<int>(1, 0, 1));

        using var tiled = new Mat();
        Cv2.Repeat(slice, [1, 3, 2], tiled);
        Assert.Equal([2, 3, 4], tiled.Shape().ToArray());
        Assert.Equal(9, tiled.At<int>(0, 2, 2));
        Assert.Equal(1, tiled.At<int>(1, 2, 3));

        Cv2.Slice(src, [1], [2], [], slice);
        Assert.Equal([1, 2, 3], slice.Shape().ToArray());
        Assert.Equal(12, slice.At<int>(0, 1, 2));
    }

    [Fact]
    public void TransposePermutesAxesAndKeepsLegacyEntryPoint()
    {
        using var src = Mat.FromPixelData([2, 2, 3], MatType.CV_32SC1, Enumerable.Range(1, 12).ToArray());
        using var transposed = new Mat();
        using var restored = new Mat();
        Cv2.Transpose(src, [2, 0, 1], transposed);
        Assert.Equal([3, 2, 2], transposed.Shape().ToArray());
        Assert.Equal(11, transposed.At<int>(1, 1, 1));

        Cv2.TransposeND(transposed, [1, 2, 0], restored);
        Assert.Equal(src.Shape(), restored.Shape());
        Assert.Equal(0, Cv2.Norm(src, restored, NormTypes.INF));
    }

    [Fact]
    public void ShapeOperationsPreserveElements()
    {
        using var src = Mat.FromPixelData([1, 2, 1, 3], MatType.CV_32SC1, Enumerable.Range(1, 6).ToArray());
        using var reshaped = new Mat();
        Cv2.Squeeze(src, reshaped);
        Assert.Equal([2, 3], reshaped.Shape().ToArray());
        Assert.Equal(6, reshaped.At<int>(1, 2));

        Cv2.Unsqueeze(reshaped, reshaped, [0, -2]);
        Assert.Equal(src.Shape(), reshaped.Shape());

        Cv2.Flatten(src, reshaped);
        Assert.Equal([6], reshaped.Shape().ToArray());
        Assert.Equal(6, reshaped.At<int>(5));

        using var inferred = new Mat();
        Cv2.Reshape(src, inferred, [0, -1]);
        Assert.Equal([1, 6], inferred.Shape().ToArray());
        Assert.Equal(6, inferred.At<int>(0, 5));
    }

    [Fact]
    public void ReduceSupportsMultipleAxesAndAllAxes()
    {
        using var src = Mat.FromPixelData([2, 2, 3], MatType.CV_32SC1, Enumerable.Range(1, 12).ToArray());
        using var dst = new Mat();
        Cv2.Reduce(src, dst, new ReduceParams(ReduceTypes.Prod, [0, -1], dtype: MatType.CV_64F));
        Assert.Equal([1, 2, 1], dst.Shape().ToArray());
        Assert.Equal(MatType.CV_64FC1, dst.Type());
        Assert.Equal(3024, dst.At<double>(0, 0, 0));
        Assert.Equal(158400, dst.At<double>(0, 1, 0));

        Cv2.Reduce(src, dst, new ReduceParams(keepDims: false));
        Assert.True(dst.Shape().IsScalar);
        Assert.Equal(1, dst.Total());
    }

    [Fact]
    public void AddBroadcastsThroughExistingApi()
    {
        using var src = Mat.FromPixelData([2, 1, 3], MatType.CV_32FC1, new[] { 1f, 2f, 3f, 4f, 5f, 6f });
        using var bias = Mat.FromPixelData([1, 2, 1], MatType.CV_32FC1, new[] { 10f, 20f });
        using var dst = new Mat();
        Cv2.Add(src, bias, dst);

        Assert.Equal([2, 2, 3], dst.Shape().ToArray());
        Assert.Equal(11f, dst.At<float>(0, 0, 0));
        Assert.Equal(26f, dst.At<float>(1, 1, 2));
    }

    [Fact]
    public void TExprBroadcastsAndReturnsMultipleResults()
    {
        using var src = Mat.FromArray(new float[,] { { 2, 4 }, { 6, 8 } });
        using var bias = Mat.FromArray(new float[,] { { 1, 2 } });
        var outputs = Cv2.TExpr("t = {0} * 2; (t + {1}, t - {1})", [src, bias]);
        try
        {
            Assert.Equal(2, outputs.Length);
            Assert.Equal(5f, outputs[0].At<float>(0, 0));
            Assert.Equal(18f, outputs[0].At<float>(1, 1));
            Assert.Equal(3f, outputs[1].At<float>(0, 0));
            Assert.Equal(14f, outputs[1].At<float>(1, 1));
        }
        finally
        {
            foreach (var output in outputs)
                output.Dispose();
        }
    }

    [Theory]
    [InlineData(MatType.CV_8F_E4M3FN, 13, "CV_8F_E4M3FNC1")]
    [InlineData(MatType.CV_8F_E4M3FNUZ, 14, "CV_8F_E4M3FNUZC1")]
    public void Fp8ConversionAndFileStorageRoundTrip(int depth, int expectedDepth, string name)
    {
        using var src = Mat.FromArray(-2f, -0.5f, 0f, 1f, 3f);
        using var fp8 = new Mat();
        src.ConvertTo(fp8, depth);
        Assert.Equal(expectedDepth, fp8.Type().Depth);
        Assert.Equal(name, fp8.Type().ToString());
        Assert.Equal(1, fp8.ElemSize());
        Assert.False(fp8.Type().IsInteger);

        using var writer = new FileStorage(".yml", FileStorage.Modes.Write | FileStorage.Modes.Memory);
        writer.Write("values", fp8);
        var yaml = writer.ReleaseAndGetString();
        using var reader = new FileStorage(yaml, FileStorage.Modes.Read | FileStorage.Modes.Memory);
        using var node = reader["values"];
        Assert.NotNull(node);
        using var decoded = node.ReadMat();
        Assert.Equal(fp8.Type(), decoded.Type());

        using var restored = new Mat();
        decoded.ConvertTo(restored, MatType.CV_32F);
        Assert.Equal(0, Cv2.Norm(src, restored, NormTypes.INF));
    }
}
