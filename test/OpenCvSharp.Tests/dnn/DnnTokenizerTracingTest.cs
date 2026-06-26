using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Tests for the OpenCV 5 DNN additions: Tokenizer and the Net tracing/profiling/finalizeNet/
// registerOutput methods.
public class DnnTokenizerTracingTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static string MnistModelPath => Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");

    [Theory(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    [InlineData(TracingMode.None)]
    [InlineData(TracingMode.All)]
    [InlineData(TracingMode.Op)]
    public void TracingModeRoundTrip(TracingMode mode)
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);
        net!.TracingMode = mode;
        Assert.Equal(mode, net.TracingMode);
    }

    [Theory(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    [InlineData(ProfilingMode.None)]
    [InlineData(ProfilingMode.Summary)]
    [InlineData(ProfilingMode.Detailed)]
    public void ProfilingModeRoundTrip(ProfilingMode mode)
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);
        net!.ProfilingMode = mode;
        Assert.Equal(mode, net.ProfilingMode);
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void FinalizeNetIsWired()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        // finalizeNet is a new-engine operation; for a classic-engine net it may succeed or raise
        // an OpenCVException. Either way it must reach OpenCV (not fail in the P/Invoke layer).
        var ex = Record.Exception(() => net!.FinalizeNet());
        Assert.True(ex is null or OpenCVException, ex?.ToString());
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void RegisterOutputIsWired()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        var ex = Record.Exception(() => net!.RegisterOutput("___out___", 0, 0));
        Assert.True(ex is null or OpenCVException, ex?.ToString());
    }

    [Fact]
    public void TokenizerLoadWithMissingModelThrows()
    {
        var missing = Path.Combine(Path.GetTempPath(), $"__no_tokenizer_{Guid.NewGuid():N}") + Path.DirectorySeparatorChar;
        Assert.ThrowsAny<OpenCVException>(() => Tokenizer.Load(missing));
    }
}
