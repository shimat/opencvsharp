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

    private static string MnistModelPath => Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ReadNetFromTensorflowUnicodePath()
    {
        Assert.True(File.Exists(MnistModelPath), $"'{MnistModelPath}' not found");

        // Emoji cannot be represented in any ANSI code page, so this reliably exercises the Windows wide path.
        var unicodePath = Path.Combine("_data", "model", "mnist_😀🍀.pb");
        try
        {
            File.Copy(MnistModelPath, unicodePath, true);

            using var net = CvDnn.ReadNetFromTensorflow(unicodePath);
            Assert.NotNull(net);
            Assert.False(net!.Empty());
        }
        finally
        {
            if (File.Exists(unicodePath))
                File.Delete(unicodePath);
        }
    }
}
