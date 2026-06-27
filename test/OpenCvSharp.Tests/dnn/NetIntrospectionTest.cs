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

    // The committed MNIST model takes a single 1x1x28x28 (NCHW) CV_32F blob,
    // matching the BlobFromImage output used by the TensorflowTest inference tests.
    private static readonly MatShape MnistInputShape = new(1, 1, 28, 28);

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetFLOPSReturnsPositive()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        var flops = net!.GetFLOPS([MnistInputShape], [MatType.CV_32F]);
        Assert.True(flops > 0, $"FLOPS should be positive but was {flops}");

        // The single-shape convenience overload must agree with the collection overload.
        Assert.Equal(flops, net.GetFLOPS(MnistInputShape, MatType.CV_32F));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetMemoryConsumptionTotalReturnsPositive()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        net!.GetMemoryConsumption([MnistInputShape], [MatType.CV_32F], out var weights, out var blobs);
        Assert.True(weights >= 0, $"weights should be non-negative but was {weights}");
        Assert.True(blobs > 0, $"blobs should be positive but was {blobs}");
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetMemoryConsumptionPerLayerReturnsParallelArrays()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        net!.GetMemoryConsumption([MnistInputShape], [MatType.CV_32F], out var layerIds, out var weights, out var blobs);
        Assert.NotEmpty(layerIds);
        Assert.Equal(layerIds.Length, weights.Length);
        Assert.Equal(layerIds.Length, blobs.Length);
        Assert.All(weights, w => Assert.True(w >= 0));
        Assert.All(blobs, b => Assert.True(b >= 0));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetLayerShapesReturnsShapesForOutputLayer()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        var outLayerId = net!.GetUnconnectedOutLayers()[0];
        net.GetLayerShapes([MnistInputShape], [MatType.CV_32F], outLayerId, out var inShapes, out var outShapes);

        Assert.NotEmpty(inShapes);
        Assert.NotEmpty(outShapes);
        // Every reported shape should carry at least one axis.
        Assert.All(outShapes, s => Assert.True(s.Dims > 0));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void GetLayersShapesIsConsistentAcrossLayers()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        net!.GetLayersShapes([MnistInputShape], [MatType.CV_32F], out var layerIds, out var inShapes, out var outShapes);

        Assert.NotEmpty(layerIds);
        Assert.Equal(layerIds.Length, inShapes.Length);
        Assert.Equal(layerIds.Length, outShapes.Length);

        // Per-layer GetLayerShapes must agree with the batched GetLayersShapes result.
        for (var i = 0; i < layerIds.Length; i++)
        {
            net.GetLayerShapes([MnistInputShape], [MatType.CV_32F], layerIds[i], out var inOne, out var outOne);
            Assert.Equal(inShapes[i].Length, inOne.Length);
            Assert.Equal(outShapes[i].Length, outOne.Length);
        }
    }
}
