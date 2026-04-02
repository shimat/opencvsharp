using OpenCvSharp.Saliency;
using Xunit;

namespace OpenCvSharp.Tests.Saliency;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class StaticSaliencyTest : TestBase
{
    [Fact]
    public void SpectralResidual_CreateAndDispose()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();
        Assert.NotNull(saliency);
    }

    [Fact]
    public void SpectralResidual_ComputeSaliency()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();

        var result = saliency.ComputeSaliency(src, saliencyMap);

        Assert.True(result);
        Assert.False(saliencyMap.Empty());
        Assert.Equal(MatType.CV_32FC1, saliencyMap.Type());
        Assert.Equal(src.Rows, saliencyMap.Rows);
        Assert.Equal(src.Cols, saliencyMap.Cols);
    }

    [Fact]
    public void SpectralResidual_ComputeBinaryMap()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();
        using var binaryMap = new Mat();

        saliency.ComputeSaliency(src, saliencyMap);
        var result = saliency.ComputeBinaryMap(saliencyMap, binaryMap);

        Assert.True(result);
        Assert.False(binaryMap.Empty());
        Assert.Equal(src.Rows, binaryMap.Rows);
        Assert.Equal(src.Cols, binaryMap.Cols);
    }

    [Fact]
    public void SpectralResidual_ImageWidthHeight()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();

        saliency.ImageWidth = 256;
        saliency.ImageHeight = 256;

        Assert.Equal(256, saliency.ImageWidth);
        Assert.Equal(256, saliency.ImageHeight);
    }

    [Fact]
    public void FineGrained_CreateAndDispose()
    {
        using var saliency = StaticSaliencyFineGrained.Create();
        Assert.NotNull(saliency);
    }

    [Fact]
    public void FineGrained_ComputeSaliency()
    {
        using var saliency = StaticSaliencyFineGrained.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();

        var result = saliency.ComputeSaliency(src, saliencyMap);

        Assert.True(result);
        Assert.False(saliencyMap.Empty());
        Assert.Equal(src.Rows, saliencyMap.Rows);
        Assert.Equal(src.Cols, saliencyMap.Cols);
    }

    [Fact]
    public void FineGrained_ComputeBinaryMap()
    {
        using var saliency = StaticSaliencyFineGrained.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();
        using var binaryMap = new Mat();

        saliency.ComputeSaliency(src, saliencyMap);
        var result = saliency.ComputeBinaryMap(saliencyMap, binaryMap);

        Assert.True(result);
        Assert.False(binaryMap.Empty());
        Assert.Equal(src.Rows, binaryMap.Rows);
        Assert.Equal(src.Cols, binaryMap.Cols);
    }
}
