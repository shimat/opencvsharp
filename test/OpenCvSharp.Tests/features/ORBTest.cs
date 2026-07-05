using Xunit;

namespace OpenCvSharp.Tests.Features;

// ReSharper disable once InconsistentNaming
public class ORBTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public ORBTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CreateAndDispose()
    {
        var surf = ORB.Create(400);
        surf.Dispose();
    }

    [Fact]
    public void Detect()
    {
        // This parameter should introduce same result of http://opencv.jp/wordpress/wp-content/uploads/lenna_SURF-150x150.png
        using var gray = LoadImage("lenna.png", 0);
        using var orb = ORB.Create(500);
        var keyPoints = orb.Detect(gray);

        testOutputHelper.WriteLine($"KeyPoint has {keyPoints.Length} items.");
    }

    [Fact]
    public void DetectAndCompute()
    {
        using (var gray = LoadImage("lenna.png", ImreadModes.Grayscale))
        using (var orb = ORB.Create(500))
        using (Mat descriptor = new Mat())
        {
            orb.DetectAndCompute(gray, default, out var keyPoints, descriptor);

            testOutputHelper.WriteLine($"keyPoints has {keyPoints.Length} items.");
            testOutputHelper.WriteLine($"descriptor has {descriptor.Rows} items.");
        }
    }

    [Fact]
    public void DetectMultipleImages()
    {
        using var gray1 = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var gray2 = LoadImage("building.jpg", ImreadModes.Grayscale);
        using var orb = ORB.Create(500);

        var keyPointsPerImage = orb.Detect(new[] { gray1, gray2 });

        // Regression test: the native imageVec used to be pre-sized *and* push_back'd,
        // doubling its length with leading empty Mats in front of the real images.
        Assert.Equal(2, keyPointsPerImage.Length);
        Assert.NotEmpty(keyPointsPerImage[0]);
        Assert.NotEmpty(keyPointsPerImage[1]);
    }

    [Fact]
    public void ComputeMultipleImages()
    {
        using var gray1 = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var gray2 = LoadImage("building.jpg", ImreadModes.Grayscale);
        using var orb = ORB.Create(500);
        var images = new[] { gray1, gray2 };

        var keyPoints = orb.Detect(images);
        using var descriptor1 = new Mat();
        using var descriptor2 = new Mat();
        var descriptors = new[] { descriptor1, descriptor2 };

        orb.Compute(images, ref keyPoints, descriptors);

        // Regression test: descriptorsVec had the same pre-size + push_back doubling bug.
        Assert.Equal(2, keyPoints.Length);
        Assert.True(descriptor1.Rows > 0);
        Assert.True(descriptor2.Rows > 0);
    }
}
