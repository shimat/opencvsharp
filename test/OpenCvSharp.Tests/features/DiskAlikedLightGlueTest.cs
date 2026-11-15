using Xunit;

namespace OpenCvSharp.Tests.Features;

// DISK / ALIKED / LightGlueMatcher require ONNX model files that are not committed to the repo.
// These tests verify that the P/Invoke entry points are wired correctly: loading a non-existent
// model must reach OpenCV and raise an OpenCVException (not fail in the P/Invoke layer).
public class DiskAlikedLightGlueTest : TestBase
{
    private static string MissingModel => Path.Combine(Path.GetTempPath(), $"__no_such_model_{Guid.NewGuid():N}.onnx");

    [Fact]
    public void DiskCreateWithMissingModelThrows()
    {
        Assert.ThrowsAny<OpenCVException>(() => DISK.Create(MissingModel));
    }

    [Fact]
    public void DiskCreateFromMemoryWithGarbageThrows()
    {
        var garbage = new byte[] { 1, 2, 3, 4 };
        Assert.ThrowsAny<OpenCVException>(() => DISK.CreateFromMemory(garbage));
    }

    [Fact]
    public void AlikedCreateWithMissingModelThrows()
    {
        Assert.ThrowsAny<OpenCVException>(() => ALIKED.Create(MissingModel));
    }

    [Fact]
    public void AlikedCreateFromMemoryWithGarbageThrows()
    {
        var garbage = new byte[] { 1, 2, 3, 4 };
        Assert.ThrowsAny<OpenCVException>(() => ALIKED.CreateFromMemory(garbage));
    }

    [Fact]
    public void LightGlueCreateWithMissingModelThrows()
    {
        Assert.ThrowsAny<OpenCVException>(() => LightGlueMatcher.Create(MissingModel));
    }

    [Fact]
    public void LightGlueCreateFromMemoryWithGarbageThrows()
    {
        var garbage = new byte[] { 1, 2, 3, 4 };
        Assert.ThrowsAny<OpenCVException>(() => LightGlueMatcher.CreateFromMemory(garbage));
    }

    [Fact]
    public void LightGlueDiskMatcherSupportsChangingNormalization()
    {
        // Construction only needs a valid ONNX graph. No feature matching is performed.
        var model = File.ReadAllBytes(Path.Combine("_data", "wechat_qrcode", "sr.onnx"));
        using var matcher = LightGlueMatcher.CreateFromMemory(model, type: LightGlueType.Disk);
        Assert.Equal(LightGlueNormalization.Model, matcher.KeypointNormalization);
        matcher.KeypointNormalization = LightGlueNormalization.MaxSide;
        Assert.Equal(LightGlueNormalization.MaxSide, matcher.KeypointNormalization);
    }

    [Fact]
    public void XFeatConfigurationRoundTrips()
    {
        // Three identity outputs use the names required by XFeat. This graph tests construction and options.
        var model = Convert.FromBase64String(
            "CAg6/gEKGwoBeBIMb3V0cHV0X2ZlYXRzIghJZGVudGl0eQofCgF4EhBvdXRwdXRfa2V5cG9pbnRzIghJZGVudGl0eQodCgF4Eg5vdXRwdXRfaGVhdG1hcCIISWRlbnRpdHkSBHRlc3RaGwoBeBIWChQIARIQCgIIAQoCCAEKAggICgIICGImCgxvdXRwdXRfZmVhdHMSFgoUCAESEAoCCAEKAggBCgIICAoCCAhiKgoQb3V0cHV0X2tleXBvaW50cxIWChQIARIQCgIIAQoCCAEKAggICgIICGIoCg5vdXRwdXRfaGVhdG1hcBIWChQIARIQCgIIAQoCCAEKAggICgIICEICEBI=");
        using var detector = XFeat.CreateFromMemory(model, maxKeypoints: 120, inputSize: new Size(80, 64));
        Assert.Equal(120, detector.MaxKeypoints);
        Assert.Equal(0.5f, detector.ScoreThreshold);
        Assert.Equal(new Size(80, 64), detector.InputSize);

        detector.MaxKeypoints = 40;
        detector.ScoreThreshold = 0.25f;
        detector.InputSize = new Size(64, 48);
        Assert.Equal(40, detector.MaxKeypoints);
        Assert.Equal(0.25f, detector.ScoreThreshold);
        Assert.Equal(new Size(64, 48), detector.InputSize);
    }

    [Fact]
    public void XFeatCreateWithMissingModelThrows()
    {
        Assert.ThrowsAny<OpenCVException>(() => XFeat.Create(MissingModel));
    }

    // On Windows, Create(path) marshals the path through the ANSI code page, which cannot
    // represent arbitrary Unicode. A non-ASCII path that actually exists on disk must be routed
    // through the buffer overload instead, so garbage file contents reach OpenCV's parser and
    // raise an OpenCVException, rather than a .NET IO exception from a mis-marshaled path.
    private static string WriteGarbageModel(string prefix)
    {
        var path = Path.Combine(Path.GetTempPath(), $"__{prefix}_é日本語_{Guid.NewGuid():N}.onnx");
        File.WriteAllBytes(path, [1, 2, 3, 4]);
        return path;
    }

    [Fact]
    public void DiskCreateWithNonAsciiPathReachesNativeParser()
    {
        var path = WriteGarbageModel("disk");
        try
        {
            Assert.ThrowsAny<OpenCVException>(() => DISK.Create(path));
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void AlikedCreateWithNonAsciiPathReachesNativeParser()
    {
        var path = WriteGarbageModel("aliked");
        try
        {
            Assert.ThrowsAny<OpenCVException>(() => ALIKED.Create(path));
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void LightGlueCreateWithNonAsciiPathReachesNativeParser()
    {
        var path = WriteGarbageModel("lightglue");
        try
        {
            Assert.ThrowsAny<OpenCVException>(() => LightGlueMatcher.Create(path));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
