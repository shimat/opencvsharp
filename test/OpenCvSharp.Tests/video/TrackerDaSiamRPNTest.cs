using Xunit;

namespace OpenCvSharp.Tests.Video;

// ReSharper disable once InconsistentNaming
public class TrackerDaSiamRPNTest : TestBase
{
    // DaSiamRPN needs real .onnx model files that are not available in this repo. We can still
    // exercise the Params -> native char* marshaling path: TrackerDaSiamRPNImpl's constructor eagerly
    // calls dnn::readNet() for each model path, so a bogus path reaches native code and surfaces as a
    // normal managed OpenCvSharpException rather than crashing the process (which is what a broken
    // string marshal would do instead).
    [Fact]
    public void CreateWithParamsThrowsWhenModelFilesAreMissing()
    {
        var parameters = new TrackerDaSiamRPN.Params
        {
            Model = "no_such_dasiamrpn_model.onnx",
            KernelCls1 = "no_such_dasiamrpn_kernel_cls1.onnx",
            KernelR1 = "no_such_dasiamrpn_kernel_r1.onnx",
            Backend = 0,
            Target = 0,
        };

        Assert.Throws<OpenCVException>(() => TrackerDaSiamRPN.Create(parameters));
    }

    [Fact(Skip = "requires a DNN model file not available in this repo")]
    public void InitAndUpdateRequireARealModel()
    {
    }
}
