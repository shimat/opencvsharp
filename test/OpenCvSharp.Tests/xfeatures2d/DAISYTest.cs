using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class DAISYTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var daisy = DAISY.Create();
        daisy.Dispose();
    }

    [Fact]
    public void ComputeViaFeature2D()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var daisy = DAISY.Create();
        using var orb = ORB.Create();

        var keypoints = orb.Detect(gray);
        daisy.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void ComputeDense()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var daisy = DAISY.Create();

        daisy.Compute(gray, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void ComputeRoi()
    {
        // OpenCV's DAISY_Impl::compute_descriptors (opencv_contrib xfeatures2d/src/daisy.cpp)
        // indexes the output buffer using absolute image coordinates (y*image.cols+x) even though
        // the buffer is only sized roi.width*roi.height rows. That overflows for any roi other
        // than the full image (x=0, y=0, width=image.cols, height=image.rows), so the native
        // bridge guards against it; use the full image here to satisfy that guard.
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var daisy = DAISY.Create();

        daisy.Compute(gray, new Rect(0, 0, gray.Cols, gray.Rows), descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void ComputeRoiWithPartialRoiThrows()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var daisy = DAISY.Create();

        Assert.Throws<OpenCVException>(() => daisy.Compute(gray, new Rect(0, 10, gray.Cols, 50), descriptors));
    }

    [Fact]
    public void GetDescriptor()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var daisy = DAISY.Create();

        daisy.Compute(gray, descriptors);
        var descriptor = daisy.GetDescriptor(100, 100, 0);

        Assert.Equal(daisy.DescriptorSize, descriptor.Length);
    }

    [Fact]
    public void GetUnnormalizedDescriptor()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var daisy = DAISY.Create();

        daisy.Compute(gray, descriptors);
        var descriptor = daisy.GetUnnormalizedDescriptor(100, 100, 0);

        Assert.Equal(daisy.DescriptorSize, descriptor.Length);
    }

    [Fact]
    public void Properties()
    {
        using var alg = DAISY.Create();

        alg.Radius = 10;
        Assert.Equal(10, alg.Radius, 3);

        alg.QRadius = 2;
        Assert.Equal(2, alg.QRadius);

        alg.QTheta = 4;
        Assert.Equal(4, alg.QTheta);

        alg.QHist = 4;
        Assert.Equal(4, alg.QHist);

        alg.Norm = DAISYNormalizationType.Sift;
        Assert.Equal(DAISYNormalizationType.Sift, alg.Norm);

        alg.Interpolation = false;
        Assert.False(alg.Interpolation);

        alg.UseOrientation = true;
        Assert.True(alg.UseOrientation);
    }

    [Fact]
    public void HProperty()
    {
        using var alg = DAISY.Create();

        using (var h = alg.H)
        {
            Assert.True(h.Empty());
        }

        using var identity = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat();
        alg.H = identity;

        using var h2 = alg.H;
        Assert.False(h2.Empty());
        Assert.Equal(new Size(3, 3), h2.Size());
    }
}
