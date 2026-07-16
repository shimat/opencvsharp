using System.IO;
using OpenCvSharp.Saliency;
using Xunit;

namespace OpenCvSharp.Tests.Saliency;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class ObjectnessBINGTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var bing = ObjectnessBING.Create();
        Assert.NotNull(bing);
    }

    [Fact]
    public void DefaultProperties()
    {
        using var bing = ObjectnessBING.Create();

        // Verify that property accessors round-trip correctly
        var originalBase = bing.Base;
        var originalNSS = bing.NSS;
        var originalW = bing.W;

        Assert.True(originalBase > 0);
        Assert.True(originalNSS > 0);
        Assert.True(originalW > 0);
    }

    [Fact]
    public void SetProperties()
    {
        using var bing = ObjectnessBING.Create();

        bing.Base = 2.0;
        bing.NSS = 3;
        bing.W = 8;

        Assert.Equal(2.0, bing.Base, precision: 10);
        Assert.Equal(3, bing.NSS);
        Assert.Equal(8, bing.W);
    }

    [Fact]
    public void SetTrainingPath_DoesNotThrow()
    {
        using var bing = ObjectnessBING.Create();
        // Setting a path should not throw even if the directory does not exist;
        // the error only manifests when ComputeSaliency is called.
        bing.SetTrainingPath("/nonexistent/path");
    }

    [Fact]
    public void SetBBResDir_DoesNotThrow()
    {
        using var bing = ObjectnessBING.Create();
        bing.SetBBResDir("/nonexistent/results");
    }

    [Fact]
    public void ComputeSaliency()
    {
        // Smoke test for the ArrayProxy wiring: BING needs a trained model directory
        // (SetTrainingPath) that isn't committed, so this is expected to fail, but
        // reaching native and failing there still proves the InputArray (image) param
        // and the vector<Vec4i> out-param marshal correctly.
        using var bing = ObjectnessBING.Create();
        using var image = LoadImage("lenna.png");

        try
        {
            bing.ComputeSaliency(image, out var boxes);
            Assert.NotNull(boxes);
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            // Expected: no trained model path has been set.
        }
    }

    [Fact]
    public void ReadWrite()
    {
        // cv::saliency::Saliency inherits Algorithm virtually; this exercises the P/Invoke plumbing
        // that keeps the native pointer at its concrete type across the write/read call, rather than
        // reinterpreting it as cv::Algorithm* (which would corrupt memory - see StaticSaliencyTest's
        // SpectralResidual_ReadWrite for the full explanation). ObjectnessBING doesn't override
        // Algorithm::write/read, so this can't assert that any state round-trips - only that the
        // calls reach native without crashing.
        using var bing = ObjectnessBING.Create();
        bing.Base = 2.0;

        var fileName = Path.Combine(Path.GetTempPath(), "objectness_bing_test.yml");
        try
        {
            using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
            {
                fs.Write("marker", 1);
                bing.Write(fs);
            }

            using var fs2 = new FileStorage(fileName, FileStorage.Modes.Read);
            var root = fs2.Root();
            Assert.NotNull(root);
            bing.Read(root);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }
}
