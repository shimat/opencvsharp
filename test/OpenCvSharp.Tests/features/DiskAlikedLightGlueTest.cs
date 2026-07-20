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
