using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.ML;

// ReSharper disable once InconsistentNaming
public class SVMSGDTest : TestBase
{
    [Fact]
    public void RunTest()
    {
        float[,] trainFeaturesData =
        {
            {0, 0},
            {0, 100},
            {100, 0},
            {100, 100},
        };
        using var trainFeatures = Mat.FromPixelData(4, 2, MatType.CV_32F, trainFeaturesData);

        // SVMSGD requires float (CV_32FC1) responses, unlike SVM/RTrees which accept CV_32S labels.
        float[] trainLabelsData = [1, -1, 1, -1];
        using var trainLabels = Mat.FromPixelData(4, 1, MatType.CV_32F, trainLabelsData);

        using var model = SVMSGD.Create();
        model.SetOptimalParameters();
        model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

        Assert.True(model.IsTrained());
        Assert.False(model.GetWeights().Empty());
    }

    [Fact]
    public void SaveLoadTest()
    {
        float[,] trainFeaturesData =
        {
            {0, 0},
            {0, 100},
            {100, 0},
            {100, 100},
        };
        using var trainFeatures = Mat.FromPixelData(4, 2, MatType.CV_32F, trainFeaturesData);

        // SVMSGD requires float (CV_32FC1) responses, unlike SVM/RTrees which accept CV_32S labels.
        float[] trainLabelsData = [1, -1, 1, -1];
        using var trainLabels = Mat.FromPixelData(4, 1, MatType.CV_32F, trainLabelsData);

        const string fileName = "svmsgd.yml";
        if (File.Exists(fileName))
            File.Delete(fileName);

        using (var model = SVMSGD.Create())
        {
            model.SetOptimalParameters();
            model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);
            model.Save(fileName);
        }

        Assert.True(File.Exists(fileName));

        var content = File.ReadAllText(fileName);

        using (var model2 = SVMSGD.Load(fileName))
        {
            GC.KeepAlive(model2);
        }
        using (var model2 = SVMSGD.LoadFromString(content))
        {
            GC.KeepAlive(model2);
        }
    }
}
