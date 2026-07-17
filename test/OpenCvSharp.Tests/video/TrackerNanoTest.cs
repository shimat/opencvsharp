using Xunit;

namespace OpenCvSharp.Tests.Video;

public class TrackerNanoTest : TestBase
{
    // NanoTrack needs real .onnx model files that are not available in this repo. We can still
    // exercise the Params -> native char* marshaling path: TrackerNanoImpl's constructor eagerly
    // calls dnn::readNet() for each model path, so a bogus path reaches native code and surfaces as a
    // normal managed OpenCvSharpException rather than crashing the process (which is what a broken
    // string marshal would do instead).
    [Fact]
    public void CreateWithParamsThrowsWhenModelFilesAreMissing()
    {
        var parameters = new TrackerNano.Params
        {
            Backbone = "no_such_nano_backbone.onnx",
            Neckhead = "no_such_nano_neckhead.onnx",
            Backend = 0,
            Target = 0,
        };

        Assert.Throws<OpenCVException>(() => TrackerNano.Create(parameters));
    }

    [Fact(Skip = "requires a DNN model file not available in this repo")]
    public void InitAndUpdateRequireARealModel()
    {
    }
}
