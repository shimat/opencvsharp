using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class AffineFeature2DTest : TestBase
{
    [Fact]
    public void CreateWithSingleBackendAndDispose()
    {
        var orb = ORB.Create();
        var affine = AffineFeature2D.Create(orb);
        affine.Dispose();
        orb.Dispose();
    }

    [Fact]
    public void CreateWithSeparateDetectorAndExtractorAndDispose()
    {
        var detector = ORB.Create();
        var extractor = ORB.Create();
        var affine = AffineFeature2D.Create(detector, extractor);
        affine.Dispose();
        detector.Dispose();
        extractor.Dispose();
    }

    [Fact]
    public void DetectElliptic()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var orb = ORB.Create();
        using var affine = AffineFeature2D.Create(orb);

        var keypoints = affine.DetectElliptic(gray);

        Assert.NotEmpty(keypoints);
        Assert.All(keypoints, kp => Assert.True(kp.Axes.Width >= 0 && kp.Axes.Height >= 0));
    }

    [Fact]
    public void DetectAndComputeElliptic()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var sift = SIFT.Create(50);
        using var affine = AffineFeature2D.Create(sift);

        var keypoints = affine.DetectAndComputeElliptic(gray, default, descriptors);

        Assert.NotEmpty(keypoints);
        Assert.False(descriptors.Empty());
        Assert.Equal(keypoints.Length, descriptors.Rows);
    }

    [Fact]
    public void DetectAndComputeEllipticWithProvidedKeypoints()
    {
        // AffineFeature2D's calcAffineCovariantDescriptors (opencv_contrib xfeatures2d/src/
        // affine_feature2d.cpp) crashes with an assertion failure when wrapping ORB as the
        // descriptor extractor (a binary/CV_8U descriptor), so use SIFT here instead.
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors1 = new Mat();
        using var descriptors2 = new Mat();
        using var sift = SIFT.Create(50);
        using var affine = AffineFeature2D.Create(sift);

        var keypoints = affine.DetectAndComputeElliptic(gray, default, descriptors1);
        var keypoints2 = affine.DetectAndComputeElliptic(
            gray, default, descriptors2, useProvidedKeypoints: true, providedKeypoints: keypoints);

        Assert.Equal(keypoints.Length, keypoints2.Length);
        Assert.Equal(descriptors1.Rows, descriptors2.Rows);
    }
}
