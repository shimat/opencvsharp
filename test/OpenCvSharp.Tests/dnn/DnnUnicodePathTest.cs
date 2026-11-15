using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// dnn model files with non-ANSI (UTF-8) paths must load on every platform. On Windows the native side
// reads such paths via a wide stream + the in-memory buffer overload (OpenCV's narrow fopen cannot
// open them; opencv #4242).
public class DnnUnicodePathTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static string MnistModelPath => Path.Combine("_data", "model", "mnist-8.onnx");

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ReadNetFromONNXUnicodePath()
    {
        Assert.True(File.Exists(MnistModelPath), $"'{MnistModelPath}' not found");

        // Emoji cannot be represented in any ANSI code page, so this reliably exercises the Windows wide path.
        var unicodePath = Path.Combine("_data", "model", "mnist_😀🍀.onnx");
        try
        {
            File.Copy(MnistModelPath, unicodePath, true);

            using var net = Cv2.Dnn.ReadNetFromONNX(unicodePath);
            Assert.NotNull(net);
            Assert.False(net!.Empty());
        }
        finally
        {
            if (File.Exists(unicodePath))
                File.Delete(unicodePath);
        }
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ReadNetUnicodePath()
    {
        // Generic ReadNet infers the ONNX from the file extension; on Windows the
        // non-representable path is read via wide + the framework-explicit buffer overload.
        Assert.True(File.Exists(MnistModelPath), $"'{MnistModelPath}' not found");

        var unicodePath = Path.Combine("_data", "model", "mnist_readnet_😀🍀.onnx");
        try
        {
            File.Copy(MnistModelPath, unicodePath, true);

            using var net = Cv2.Dnn.ReadNet(unicodePath);
            Assert.NotNull(net);
            Assert.False(net!.Empty());
        }
        finally
        {
            if (File.Exists(unicodePath))
                File.Delete(unicodePath);
        }
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void DetectionModelUnicodePath()
    {
        var modelPath = Path.Combine("_data", "wechat_qrcode", "detect.onnx");
        var unicodePath = Path.Combine("_data", "model", "detector_😀🍀.onnx");
        try
        {
            File.Copy(modelPath, unicodePath, true);

            using var model = new DetectionModel(unicodePath);
            Assert.NotNull(model);
        }
        finally
        {
            if (File.Exists(unicodePath))
                File.Delete(unicodePath);
        }
    }
}
