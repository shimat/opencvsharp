using System.Linq;
using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class PCTSignaturesTest : TestBase
{
    [Fact]
    public void CreateDefaultAndDispose()
    {
        var alg = PCTSignatures.Create();
        alg.Dispose();
    }

    [Fact]
    public void CreateFromSamplingPointsAndSeedCount()
    {
        var points = PCTSignatures.GenerateInitPoints(200, PCTSignaturesPointDistribution.Regular);
        using var alg = PCTSignatures.Create(points, 20);

        Assert.NotEmpty(alg.GetSamplingPoints());
    }

    [Fact]
    public void CreateFromSamplingPointsAndSeedIndexes()
    {
        var points = PCTSignatures.GenerateInitPoints(200, PCTSignaturesPointDistribution.Uniform);
        var seedIndexes = Enumerable.Range(0, 20).ToArray();
        using var alg = PCTSignatures.Create(points, seedIndexes);

        Assert.Equal(seedIndexes.Length, alg.GetInitSeedIndexes().Length);
    }

    [Fact]
    public void GenerateInitPoints()
    {
        var points = PCTSignatures.GenerateInitPoints(100, PCTSignaturesPointDistribution.Uniform);

        Assert.Equal(100, points.Length);
        Assert.All(points, p =>
        {
            Assert.InRange(p.X, 0.0f, 1.0f);
            Assert.InRange(p.Y, 0.0f, 1.0f);
        });
    }

    [Fact]
    public void ComputeSignature()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Color);
        using var signature = new Mat();
        using var alg = PCTSignatures.Create(50, 10);

        alg.ComputeSignature(image, signature);

        Assert.False(signature.Empty());
    }

    [Fact]
    public void ComputeSignatures()
    {
        using var image1 = LoadImage("lenna.png", ImreadModes.Color);
        using var image2 = LoadImage("lenna.png", ImreadModes.Color);
        using var alg = PCTSignatures.Create(50, 10);

        var signatures = alg.ComputeSignatures([image1, image2]);

        Assert.Equal(2, signatures.Length);
        Assert.All(signatures, s => Assert.False(s.Empty()));
        foreach (var s in signatures)
            s.Dispose();
    }

    [Fact]
    public void DrawSignature()
    {
        using var image = LoadImage("lenna.png", ImreadModes.Color);
        using var signature = new Mat();
        using var result = new Mat();
        using var alg = PCTSignatures.Create(50, 10);

        alg.ComputeSignature(image, signature);
        PCTSignatures.DrawSignature(image, signature, result);

        Assert.False(result.Empty());
    }

    [Fact]
    public void SamplerProperties()
    {
        using var alg = PCTSignatures.Create(50, 10);

        // OpenCV's PCTSignatures_Impl::getSampleCount() (opencv_contrib
        // xfeatures2d/src/pct_signatures.cpp:132) is a copy-paste bug: it calls
        // mSampler->getGrayscaleBits() instead of returning the actual sample count, so it's
        // always identical to GrayscaleBits (default 4), never the value passed to Create().
        Assert.Equal(4, alg.SampleCount);

        alg.GrayscaleBits = 6;
        Assert.Equal(6, alg.GrayscaleBits);

        alg.WindowRadius = 4;
        Assert.Equal(4, alg.WindowRadius);

        alg.WeightX = 2.0f;
        Assert.Equal(2.0f, alg.WeightX, 3);

        alg.WeightY = 2.0f;
        Assert.Equal(2.0f, alg.WeightY, 3);

        alg.WeightL = 2.0f;
        Assert.Equal(2.0f, alg.WeightL, 3);

        alg.WeightA = 2.0f;
        Assert.Equal(2.0f, alg.WeightA, 3);

        alg.WeightB = 2.0f;
        Assert.Equal(2.0f, alg.WeightB, 3);

        alg.WeightContrast = 0.5f;
        Assert.Equal(0.5f, alg.WeightContrast, 3);

        alg.WeightEntropy = 0.5f;
        Assert.Equal(0.5f, alg.WeightEntropy, 3);
    }

    [Fact]
    public void SetWeightAndTranslation()
    {
        using var alg = PCTSignatures.Create(50, 10);

        alg.SetWeight(1, 3.0f);
        Assert.Equal(3.0f, alg.WeightX, 3);

        alg.SetWeights([1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f]);
        Assert.Equal(2f, alg.WeightX, 3);

        // Translation has no getter on the native side; just verify the calls don't throw.
        alg.SetTranslation(1, 0.1f);
        alg.SetTranslations([0f, 0.1f, 0.1f, 0f, 0f, 0f, 0f, 0f]);
    }

    [Fact]
    public void SetSamplingPoints()
    {
        var points = PCTSignatures.GenerateInitPoints(100, PCTSignaturesPointDistribution.Uniform);
        using var alg = PCTSignatures.Create(50, 10);

        alg.SetSamplingPoints(points);

        Assert.Equal(100, alg.GetSamplingPoints().Length);
    }

    [Fact]
    public void ClusterizerProperties()
    {
        using var alg = PCTSignatures.Create(50, 10);

        Assert.Equal(10, alg.InitSeedCount);

        alg.IterationCount = 5;
        Assert.Equal(5, alg.IterationCount);

        alg.MaxClustersCount = 10;
        Assert.Equal(10, alg.MaxClustersCount);

        alg.ClusterMinSize = 2;
        Assert.Equal(2, alg.ClusterMinSize);

        alg.JoiningDistance = 0.2f;
        Assert.Equal(0.2f, alg.JoiningDistance, 3);

        alg.DropThreshold = 0.1f;
        Assert.Equal(0.1f, alg.DropThreshold, 3);

        alg.DistanceFunction = PCTSignaturesDistanceFunction.L1;
        Assert.Equal(PCTSignaturesDistanceFunction.L1, alg.DistanceFunction);
    }

    [Fact]
    public void SetInitSeedIndexes()
    {
        using var alg = PCTSignatures.Create(50, 10);

        var indexes = Enumerable.Range(0, 15).ToArray();
        alg.SetInitSeedIndexes(indexes);

        Assert.Equal(indexes, alg.GetInitSeedIndexes());
    }
}
