using OpenCvSharp.ML;
using Xunit;

#pragma warning disable CA5394 // Do not use insecure randomness

namespace OpenCvSharp.Tests.ML;

public class EMTest : TestBase
{
    [Fact]
    public void TestEMCreate()
    {
        using var em = EM.Create();
        var name = em.GetDefaultName();
        Assert.Equal("opencv_ml_em", name);
    }

    // Two well-separated gaussian blobs, 2 columns (features), CV_32F.
    private static Mat CreateTwoClusterSamples()
    {
        var rng = new Random(0);
        var data = new float[40, 2];
        for (int i = 0; i < 20; i++)
        {
            data[i, 0] = (float)(rng.NextDouble() - 0.5);
            data[i, 1] = (float)(rng.NextDouble() - 0.5);
            data[i + 20, 0] = (float)(10 + rng.NextDouble() - 0.5);
            data[i + 20, 1] = (float)(10 + rng.NextDouble() - 0.5);
        }
        return Mat.FromPixelData(40, 2, MatType.CV_32F, data);
    }

    [Fact]
    public void TrainEMAndPredict2()
    {
        using var samples = CreateTwoClusterSamples();
        using var em = EM.Create();
        em.ClustersNumber = 2;

        using var logLikelihoods = new Mat();
        using var labels = new Mat();
        using var probs = new Mat();
        var ok = em.TrainEM(samples, logLikelihoods, labels, probs);

        Assert.True(ok);
        Assert.Equal(40, labels.Rows);
        Assert.Equal(40, probs.Rows);
        Assert.Equal(2, probs.Cols);

        using var sample = samples.Row(0);
        using var sampleProbs = new Mat();
        var result = em.Predict2(sample, sampleProbs);
        Assert.Equal(2, sampleProbs.Cols);
        Assert.InRange(result.Item1, 0, 1); // predicted cluster index
    }

    [Fact]
    public void TrainE()
    {
        using var samples = CreateTwoClusterSamples();
        using var em = EM.Create();
        em.ClustersNumber = 2;

        // Initial means: one per cluster.
        var means0Data = new float[,] { { 0, 0 }, { 10, 10 } };
        using var means0 = Mat.FromPixelData(2, 2, MatType.CV_32F, means0Data);

        using var labels = new Mat();
        var ok = em.TrainE(samples, means0, default, default, default, labels);
        Assert.True(ok);
        Assert.Equal(40, labels.Rows);
    }

    [Fact]
    public void TrainM()
    {
        using var samples = CreateTwoClusterSamples();
        using var em = EM.Create();
        em.ClustersNumber = 2;

        // Initial posterior probabilities: hard assignment by known cluster.
        var probs0Data = new float[40, 2];
        for (int i = 0; i < 40; i++)
        {
            probs0Data[i, 0] = i < 20 ? 1f : 0f;
            probs0Data[i, 1] = i < 20 ? 0f : 1f;
        }
        using var probs0 = Mat.FromPixelData(40, 2, MatType.CV_32F, probs0Data);

        using var labels = new Mat();
        var ok = em.TrainM(samples, probs0, default, labels);
        Assert.True(ok);
        Assert.Equal(40, labels.Rows);
    }
}
