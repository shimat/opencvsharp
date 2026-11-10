using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Tests for the OpenCV 5 DNN engine selection feature (EngineType) and the
// Backend/Target enum values that were re-synced with OpenCV 5.
public class EngineSelectionTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static string OnnxModelPath => Path.Combine("_data", "wechat_qrcode", "sr.onnx");

    [Fact]
    public void EngineTypeValuesMatchOpenCv()
    {
        // Must match cv::dnn::EngineType in modules/dnn/include/opencv2/dnn/dnn.hpp
        Assert.Equal(0, (int)EngineType.Auto);
        Assert.Equal(1, (int)EngineType.OpenCv);
        Assert.Equal(2, (int)EngineType.Ort);
    }

    [Fact]
    public void BackendValuesMatchOpenCv()
    {
        // Must match cv::dnn::Backend in OpenCV 5 (Halide removed, value 1 left as a gap).
        Assert.Equal(0, (int)Backend.DEFAULT);
        Assert.Equal(2, (int)Backend.INFERENCE_ENGINE);
        Assert.Equal(3, (int)Backend.OPENCV);
        Assert.Equal(4, (int)Backend.VKCOM);
        Assert.Equal(5, (int)Backend.CUDA);
        Assert.Equal(6, (int)Backend.WEBNN);
        Assert.Equal(7, (int)Backend.TIMVX);
        Assert.Equal(8, (int)Backend.CANN);
    }

    [Fact]
    public void TargetValuesMatchOpenCv()
    {
        // Must match cv::dnn::Target in OpenCV 5.
        Assert.Equal(0, (int)Target.CPU);
        Assert.Equal(8, (int)Target.HDDL);
        Assert.Equal(9, (int)Target.NPU);
        Assert.Equal(10, (int)Target.CPU_FP16);
    }

    [Theory(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    [InlineData(EngineType.Auto)]
    [InlineData(EngineType.OpenCv)]
    public void ReadNetFromOnnxWithOpenCvEngine(EngineType engine)
    {
        using var net = Cv2.Dnn.ReadNetFromONNX(OnnxModelPath, engine);
        Assert.NotNull(net);
        Assert.False(net.Empty());
    }
}
