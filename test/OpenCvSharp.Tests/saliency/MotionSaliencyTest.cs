using OpenCvSharp.Saliency;
using Xunit;

namespace OpenCvSharp.Tests.Saliency;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class MotionSaliencyTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var saliency = MotionSaliencyBinWangApr2014.Create();
        Assert.NotNull(saliency);
    }

    [Fact]
    public void SetImagesizeAndInit()
    {
        using var saliency = MotionSaliencyBinWangApr2014.Create();
        saliency.SetImagesize(320, 240);

        Assert.Equal(320, saliency.ImageWidth);
        Assert.Equal(240, saliency.ImageHeight);

        var initialized = saliency.Init();
        Assert.True(initialized);
    }

    [Fact]
    public void ImageWidthHeightProperty()
    {
        using var saliency = MotionSaliencyBinWangApr2014.Create();

        saliency.ImageWidth = 640;
        saliency.ImageHeight = 480;

        Assert.Equal(640, saliency.ImageWidth);
        Assert.Equal(480, saliency.ImageHeight);
    }

    [Fact]
    public void ComputeSaliency()
    {
        const int width = 320;
        const int height = 240;

        using var saliency = MotionSaliencyBinWangApr2014.Create();
        saliency.SetImagesize(width, height);
        saliency.Init();

        using var frame1 = new Mat(height, width, MatType.CV_8UC1, Scalar.All(0));
        using var frame2 = new Mat(height, width, MatType.CV_8UC1, Scalar.All(128));
        using var saliencyMap = new Mat();

        // Feed first frame to warm up the background model
        saliency.ComputeSaliency(frame1, saliencyMap);

        // Second frame should produce a saliency map
        using var saliencyMap2 = new Mat();
        var result = saliency.ComputeSaliency(frame2, saliencyMap2);

        Assert.True(result);
        Assert.False(saliencyMap2.Empty());
        Assert.Equal(height, saliencyMap2.Rows);
        Assert.Equal(width, saliencyMap2.Cols);
    }
}
