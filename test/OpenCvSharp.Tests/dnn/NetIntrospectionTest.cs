using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Tests for the priority-C/D dnn Net introspection additions.
// Uses the committed MNIST TensorFlow model so the real-net tests run in CI.
public class NetIntrospectionTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static string MnistModelPath => Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetModelFormatReturnsTensorflow()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);
        Assert.Equal(ModelFormat.TF, net!.GetModelFormat());
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetLayerTypesAndCount()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        var types = net!.GetLayerTypes();
        Assert.NotEmpty(types);

        // For every reported layer type, the count must be at least 1.
        foreach (var t in types)
        {
            if (string.IsNullOrEmpty(t))
                continue;
            Assert.True(net.GetLayersCount(t!) >= 1, $"count for '{t}' should be >= 1");
        }
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetParamAndSetParamAreWired()
    {
        // The committed TF models do not expose weights via getParam (TF imports conv
        // weights as separate Const inputs rather than into Layer::blobs), so a real
        // round-trip cannot be demonstrated with the available test data. Verify instead
        // that both calls reach OpenCV and fail there (entry points wired correctly),
        // rather than failing with a P/Invoke error.
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        Assert.ThrowsAny<OpenCVException>(() => net!.GetParam(99999));

        using var blob = new Mat(1, 1, MatType.CV_32F, Scalar.All(0));
        Assert.ThrowsAny<OpenCVException>(() => net!.SetParam(99999, 0, blob));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void SetInputShapeRejectsUnknownInput()
    {
        // Verifies the call reaches OpenCV (which validates the input name) rather than
        // failing in the P/Invoke layer. A valid-input success path is model-specific and
        // not asserted here.
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);
        Assert.ThrowsAny<OpenCVException>(() => net!.SetInputShape("___no_such_input___", new[] { 1, 1, 1, 1 }));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void DumpToPbtxtIsWired()
    {
        // dumpToPbtxt requires the net's output blobs to be allocated. OpenCV frees
        // intermediate blobs after a forward pass, so a simple happy-path file write is
        // not reliably reachable from a unit test; verify instead that the call reaches
        // OpenCV (raises OpenCVException about the missing blobs) rather than failing in
        // the P/Invoke layer.
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        var path = Path.Combine(Path.GetTempPath(), $"opencvsharp_dump_{Guid.NewGuid():N}.pbtxt");
        try
        {
            Assert.ThrowsAny<OpenCVException>(() => net!.DumpToPbtxt(path));
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void EnableWinogradAndKVCacheDoNotThrow()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        net!.EnableWinograd(true);
        net.EnableWinograd(false);
        net.EnableKVCache();
        net.ResetKVCache();
        net.DisableKVCache();
        net.PrintPerfProfile();
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetAvailableTargetsContainsCpu()
    {
        var targets = CvDnn.GetAvailableTargets(Backend.OPENCV);
        Assert.Contains(Target.CPU, targets);
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetAvailableBackendsNotEmpty()
    {
        var backends = CvDnn.GetAvailableBackends();
        Assert.NotEmpty(backends);
        Assert.Contains(backends, p => p.Backend == Backend.OPENCV && p.Target == Target.CPU);
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void EnableModelDiagnosticsDoesNotThrow()
    {
        CvDnn.EnableModelDiagnostics(true);
        CvDnn.EnableModelDiagnostics(false);
    }
}
