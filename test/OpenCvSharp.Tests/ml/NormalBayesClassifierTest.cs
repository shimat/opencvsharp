using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.ML;

// ReSharper disable once InconsistentNaming
public class NormalBayesClassifierTest : TestBase
{
    [Fact]
    public void PredictProb()
    {
        float[,] trainFeaturesData =
        {
            {0, 0},
            {1, 1},
            {10, 10},
            {11, 11},
        };
        using var trainFeatures = Mat.FromPixelData(4, 2, MatType.CV_32F, trainFeaturesData);
        int[] trainLabelsData = [0, 0, 1, 1];
        using var trainLabels = Mat.FromPixelData(4, 1, MatType.CV_32S, trainLabelsData);

        using var model = NormalBayesClassifier.Create();
        model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

        float[,] testData = { { 10, 11 } };
        using var testFeature = Mat.FromPixelData(1, 2, MatType.CV_32F, testData);
        using var outputs = new Mat();
        using var outputProbs = new Mat();

        model.PredictProb(testFeature, outputs, outputProbs);

        Assert.False(outputs.Empty());
        Assert.False(outputProbs.Empty());
        Assert.Equal(1, outputs.At<int>(0));
    }
}
