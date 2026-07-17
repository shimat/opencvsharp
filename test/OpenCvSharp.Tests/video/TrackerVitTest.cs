using Xunit;

namespace OpenCvSharp.Tests.Video;

// ReSharper disable once InconsistentNaming
public class TrackerVitTest : TestBase
{
    // VIT tracker needs a real .onnx model file that is not available in this repo. We can still
    // exercise the Params -> native char*/Scalar marshaling path: TrackerVitImpl's constructor
    // eagerly calls dnn::readNet() for the model path, so a bogus path reaches native code and
    // surfaces as a normal managed OpenCvSharpException rather than crashing the process (which is
    // what a broken marshal would do instead).
    [Fact]
    public void CreateWithParamsThrowsWhenModelFileIsMissing()
    {
        var parameters = new TrackerVit.Params
        {
            Net = "no_such_vit_model.onnx",
            Backend = 0,
            Target = 0,
            MeanValue = new Scalar(0.485, 0.456, 0.406),
            StdValue = new Scalar(0.229, 0.224, 0.225),
            TrackingScoreThreshold = 0.2f,
        };

        Assert.Throws<OpenCVException>(() => TrackerVit.Create(parameters));
    }

    [Fact(Skip = "requires a DNN model file not available in this repo")]
    public void InitAndUpdateRequireARealModel()
    {
    }

    [Fact]
    public void CreateThrowsWhenModelPathIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => TrackerVit.Create(new TrackerVit.Params()));
    }
}
