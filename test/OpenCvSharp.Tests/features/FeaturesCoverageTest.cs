using Xunit;

namespace OpenCvSharp.Tests.Features;

// ArrayProxy migration coverage (issue #1976): tests for migrated feature methods
// that previously lacked coverage.
public class FeaturesCoverageTest : TestBase
{
    [Fact]
    // ReSharper disable once InconsistentNaming
    public void FAST()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Grayscale);
        var keypoints = Cv2.FAST(image, 50, nonmaxSupression: true);

        Assert.NotEmpty(keypoints);
    }

    [Fact]
    public void DrawKeypoints()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Grayscale);
        var keypoints = Cv2.FAST(image, 50);
        using var outImage = new Mat();
        Cv2.DrawKeypoints(image, keypoints, outImage);

        Assert.Equal(image.Size(), outImage.Size());
        Assert.False(outImage.Empty());
    }

    [Fact]
    public void MserDetectRegions()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var mser = MSER.Create();
        mser.DetectRegions(image, out var msers, out var bboxes);

        Assert.NotEmpty(msers);
        Assert.Equal(msers.Length, bboxes.Length);
    }
}
