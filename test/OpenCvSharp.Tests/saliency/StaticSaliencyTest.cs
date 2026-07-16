using System.IO;
using OpenCvSharp.Saliency;
using Xunit;

namespace OpenCvSharp.Tests.Saliency;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class StaticSaliencyTest : TestBase
{
    [Fact]
    public void SpectralResidual_CreateAndDispose()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();
        Assert.NotNull(saliency);
    }

    [Fact]
    public void SpectralResidual_ComputeSaliency()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();

        var result = saliency.ComputeSaliency(src, saliencyMap);

        Assert.True(result);
        Assert.False(saliencyMap.Empty());
        Assert.Equal(MatType.CV_32FC1, saliencyMap.Type());
        Assert.Equal(src.Rows, saliencyMap.Rows);
        Assert.Equal(src.Cols, saliencyMap.Cols);
    }

    [Fact]
    public void SpectralResidual_ComputeBinaryMap()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();
        using var binaryMap = new Mat();

        saliency.ComputeSaliency(src, saliencyMap);
        var result = saliency.ComputeBinaryMap(saliencyMap, binaryMap);

        Assert.True(result);
        Assert.False(binaryMap.Empty());
        Assert.Equal(src.Rows, binaryMap.Rows);
        Assert.Equal(src.Cols, binaryMap.Cols);
    }

    [Fact]
    public void SpectralResidual_ImageWidthHeight()
    {
        using var saliency = StaticSaliencySpectralResidual.Create();

        saliency.ImageWidth = 256;
        saliency.ImageHeight = 256;

        Assert.Equal(256, saliency.ImageWidth);
        Assert.Equal(256, saliency.ImageHeight);
    }

    [Fact]
    public void SpectralResidual_ReadWrite()
    {
        // StaticSaliencySpectralResidual::write/read are empty stubs upstream (params (de)serialization
        // is commented out in opencv_contrib), so this only exercises the P/Invoke plumbing - in
        // particular that it survives cv::saliency::Saliency's virtual inheritance from cv::Algorithm -
        // rather than asserting any round-tripped content.
        using var saliency = StaticSaliencySpectralResidual.Create();
        saliency.ImageWidth = 128;
        saliency.ImageHeight = 96;

        var fileName = Path.Combine(Path.GetTempPath(), "static_saliency_spectral_residual_test.yml");
        try
        {
            using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
            {
                fs.Write("marker", 1);
                saliency.Write(fs);
            }

            using var fs2 = new FileStorage(fileName, FileStorage.Modes.Read);
            var root = fs2.Root();
            Assert.NotNull(root);
            saliency.Read(root);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }

    [Fact]
    public void FineGrained_CreateAndDispose()
    {
        using var saliency = StaticSaliencyFineGrained.Create();
        Assert.NotNull(saliency);
    }

    [Fact]
    public void FineGrained_ComputeSaliency()
    {
        using var saliency = StaticSaliencyFineGrained.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();

        var result = saliency.ComputeSaliency(src, saliencyMap);

        Assert.True(result);
        Assert.False(saliencyMap.Empty());
        Assert.Equal(src.Rows, saliencyMap.Rows);
        Assert.Equal(src.Cols, saliencyMap.Cols);
    }

    [Fact]
    public void FineGrained_ComputeBinaryMap()
    {
        using var saliency = StaticSaliencyFineGrained.Create();
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var saliencyMap = new Mat();
        using var binaryMap = new Mat();

        saliency.ComputeSaliency(src, saliencyMap);
        var result = saliency.ComputeBinaryMap(saliencyMap, binaryMap);

        Assert.True(result);
        Assert.False(binaryMap.Empty());
        Assert.Equal(src.Rows, binaryMap.Rows);
        Assert.Equal(src.Cols, binaryMap.Cols);
    }

    [Fact]
    public void FineGrained_ReadWrite()
    {
        // cv::saliency::Saliency inherits Algorithm virtually; this exercises the P/Invoke plumbing
        // that keeps the native pointer at its concrete type across the write/read call, rather than
        // reinterpreting it as cv::Algorithm* (which would corrupt memory - see SpectralResidual_ReadWrite above).
        using var saliency = StaticSaliencyFineGrained.Create();

        var fileName = Path.Combine(Path.GetTempPath(), "static_saliency_fine_grained_test.yml");
        try
        {
            using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
            {
                fs.Write("marker", 1);
                saliency.Write(fs);
            }

            using var fs2 = new FileStorage(fileName, FileStorage.Modes.Read);
            var root = fs2.Root();
            Assert.NotNull(root);
            saliency.Read(root);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }
}
