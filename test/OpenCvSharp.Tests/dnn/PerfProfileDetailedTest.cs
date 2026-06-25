using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Test for the OpenCV 5 detailed Net.GetPerfProfileDetailed (string-based per-layer profile).
public class PerfProfileDetailedTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static string MnistModelPath => Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetPerfProfileDetailedIsWired()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        // Must reach OpenCV (the three string arrays come back with matching lengths) rather than
        // failing in the P/Invoke layer; an OpenCVException is acceptable if profiling is unavailable.
        var ex = Record.Exception(() =>
        {
            net!.GetPerfProfileDetailed(out var names, out var timems, out var counts);
            Assert.Equal(names.Length, timems.Length);
            Assert.Equal(names.Length, counts.Length);
        });
        Assert.True(ex is null or OpenCVException, ex?.ToString());
    }
}
