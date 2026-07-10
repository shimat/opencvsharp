using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class PCTSignaturesSQFDTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var sqfd = PCTSignaturesSQFD.Create();
        sqfd.Dispose();
    }

    [Fact]
    public void ComputeQuadraticFormDistance()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Color);
        using var signature = new Mat();
        using var signatures = PCTSignatures.Create(50, 10);
        signatures.ComputeSignature(image, signature);

        using var sqfd = PCTSignaturesSQFD.Create();
        var distance = sqfd.ComputeQuadraticFormDistance(signature, signature);

        Assert.Equal(0.0f, distance, 3);
    }

    [Fact]
    public void ComputeQuadraticFormDistances()
    {
        // OpenCV's Parallel_computeSQFDs::operator() (opencv_contrib xfeatures2d/src/
        // pct_signatures_sqfd.cpp:141) does mImageSignatures[i].empty() where mImageSignatures
        // is a `const std::vector<Mat>*` (pointer to the whole vector) rather than
        // (*mImageSignatures)[i], so for i>0 it's undefined behavior (pointer arithmetic past a
        // single vector-sized block, read back as a std::vector<Mat>). It only happens to behave
        // for a single-element vector, so that's all this wrapper can safely exercise.
        using var image = LoadImage("lenna.png", ImreadModes.Color);
        using var signature = new Mat();
        using var signatures = PCTSignatures.Create(50, 10);
        signatures.ComputeSignature(image, signature);

        using var sqfd = PCTSignaturesSQFD.Create();
        var distances = sqfd.ComputeQuadraticFormDistances(signature, [signature]);

        Assert.Single(distances);
        Assert.Equal(0.0f, distances[0], 3);
    }
}
