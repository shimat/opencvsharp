using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.ML;

public class TrainDataTest : TestBase
{
    private static (Mat samples, Mat responses) MakeSampleSet()
    {
        float[,] trainFeaturesData =
        {
            {0, 0},
            {0, 100},
            {100, 0},
            {100, 100},
        };
        var trainFeatures = Mat.FromPixelData(4, 2, MatType.CV_32F, trainFeaturesData);

        int[] trainLabelsData = [+1, -1, +1, -1];
        var trainLabels = Mat.FromPixelData(4, 1, MatType.CV_32S, trainLabelsData);

        return (trainFeatures, trainLabels);
    }

    [Fact]
    public void CreateAndBasicAccessors()
    {
        var (samples, responses) = MakeSampleSet();

        using var data = TrainData.Create(samples, SampleTypes.RowSample, responses);

        Assert.Equal(SampleTypes.RowSample, data.GetLayout());
        Assert.Equal(4, data.GetNSamples());
        Assert.Equal(2, data.GetNVars());
        Assert.False(data.GetSamples().Empty());
        Assert.False(data.GetResponses().Empty());
        Assert.False(data.GetTrainSamples().Empty());
    }

    [Fact]
    public void TrainTestSplit()
    {
        var (samples, responses) = MakeSampleSet();

        using var data = TrainData.Create(samples, SampleTypes.RowSample, responses);
        data.SetTrainTestSplit(2, shuffle: false);

        Assert.Equal(2, data.GetNTrainSamples());
        Assert.Equal(2, data.GetNTestSamples());
        Assert.False(data.GetTestSamples().Empty());
    }

    [Fact]
    public void TrainViaStatModel()
    {
        var (samples, responses) = MakeSampleSet();

        using var data = TrainData.Create(samples, SampleTypes.RowSample, responses);
        using var model = SVM.Create();
        model.Type = SVM.Types.CSvc;
        model.KernelType = SVM.KernelTypes.Linear;
        model.TermCriteria = new TermCriteria(CriteriaTypes.MaxIter, 100, 1e-6);

        var trained = model.Train(data);
        Assert.True(trained);
        Assert.True(model.IsTrained());

        using var resp = new Mat();
        var error = model.CalcError(data, test: false, resp);
        Assert.False(double.IsNaN(error));
    }
}
