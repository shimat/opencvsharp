using Xunit;

namespace OpenCvSharp.Tests.Features;

public class SimpleBlobDetectorTest : TestBase
{
    [Fact]
    public void GetBlobContoursWithCollectContoursEnabled()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Grayscale);
        var parameters = new SimpleBlobDetector.Params
        {
            CollectContours = true,
        };
        using var detector = SimpleBlobDetector.Create(parameters);

        var keypoints = detector.Detect(image);
        var contours = detector.GetBlobContours();

        Assert.NotEmpty(keypoints);
        Assert.NotEmpty(contours);
    }

    [Fact]
    public void GetBlobContoursWithCollectContoursDisabled()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var detector = SimpleBlobDetector.Create();

        detector.Detect(image);
        var contours = detector.GetBlobContours();

        Assert.Empty(contours);
    }
}
