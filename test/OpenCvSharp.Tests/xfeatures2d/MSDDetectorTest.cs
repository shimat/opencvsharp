using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class MSDDetectorTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var msd = MSDDetector.Create();
        msd.Dispose();
    }

    [Fact]
    public void Detect()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var msd = MSDDetector.Create();

        var keypoints = msd.Detect(gray);

        Assert.NotEmpty(keypoints);
    }

    [Fact]
    public void Properties()
    {
        using var alg = MSDDetector.Create();

        alg.PatchRadius = 4;
        Assert.Equal(4, alg.PatchRadius);

        alg.SearchAreaRadius = 6;
        Assert.Equal(6, alg.SearchAreaRadius);

        alg.NmsRadius = 4;
        Assert.Equal(4, alg.NmsRadius);

        alg.NmsScaleRadius = 1;
        Assert.Equal(1, alg.NmsScaleRadius);

        alg.ThSaliency = 200.0f;
        Assert.Equal(200.0f, alg.ThSaliency, 3);

        alg.KNN = 5;
        Assert.Equal(5, alg.KNN);

        alg.ScaleFactor = 1.5f;
        Assert.Equal(1.5f, alg.ScaleFactor, 3);

        alg.NScales = 3;
        Assert.Equal(3, alg.NScales);

        alg.ComputeOrientation = true;
        Assert.True(alg.ComputeOrientation);
    }
}
