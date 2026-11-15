using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

public class DnnOutputDepthTest : TestBase
{
    // Each ONNX graph has one Cast node converting an FP32 input to the declared output type.
    [Theory]
    [InlineData("CAg6SQoXCgF4EgF5IgRDYXN0KgkKAnRvGAqgAQISBHRlc3RaEwoBeBIOCgwIARIICgIIAQoCCARiEwoBeRIOCgwIChIICgIIAQoCCARCAhAS", MatType.CV_16F)]
    [InlineData("CAg6SQoXCgF4EgF5IgRDYXN0KgkKAnRvGBCgAQISBHRlc3RaEwoBeBIOCgwIARIICgIIAQoCCARiEwoBeRIOCgwIEBIICgIIAQoCCARCAhAS", MatType.CV_16BF)]
    public void ForwardPreservesDeclaredOutputDepth(string model, int depth)
    {
        using var network = Cv2.Dnn.ReadNetFromONNX(Convert.FromBase64String(model), EngineType.OpenCv);
        Assert.NotNull(network);
        using var input = Mat.FromArray(new float[,] { { -2, 0, 0.5f, 4 } });
        network.SetInput(input);
        using var output = network.Forward();
        Assert.Equal(depth, output.Type().Depth);

        using var decoded = new Mat();
        output.ConvertTo(decoded, MatType.CV_32F);
        Assert.Equal(0, Cv2.Norm(input, decoded, NormTypes.INF));
    }

    [Fact]
    public void ReserveKVCacheRequiresEnable()
    {
        using var network = Cv2.Dnn.ReadNetFromONNX(Path.Combine("_data", "wechat_qrcode", "sr.onnx"), EngineType.OpenCv);
        Assert.NotNull(network);
        Assert.ThrowsAny<OpenCVException>(() => network.ReserveKVCache(32));
        network.EnableKVCache();
        network.ReserveKVCache(32);
        network.ResetKVCache();
    }
}
