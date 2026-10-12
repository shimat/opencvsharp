using OpenCvSharp.Bioinspired;
using Xunit;

namespace OpenCvSharp.Tests.Bioinspired;

public class BioinspiredTest : TestBase
{
    [Fact]
    public void FastToneMappingProducesAnImage()
    {
        using var input = CreateImage();
        using var mapper = RetinaFastToneMapping.Create(input.Size());
        mapper.Setup();
        using var output = new Mat();

        mapper.Apply(input, output);

        Assert.False(output.Empty());
        Assert.Equal(input.Size(), output.Size());
    }

    [Fact(Skip = "Isolating a native crash in the full Linux test suite")]
    public void RetinaProducesDetailAndMotionChannels()
    {
        using var input = CreateImage();
        using var retina = Retina.Create(input.Size());
        retina.Run(input);
        using var parvo = new Mat();
        using var magno = new Mat();

        retina.GetParvo(parvo);
        retina.GetMagno(magno);

        Assert.Equal(input.Size(), parvo.Size());
        Assert.Equal(input.Size(), magno.Size());
        retina.ClearBuffers();
    }

    [Fact(Skip = "Isolating a native crash in the full Linux test suite")]
    public void TransientAreasSegmentationProducesAnImage()
    {
        using var input = CreateImage();
        using var segmenter = TransientAreasSegmentation.Create(input.Size());
        segmenter.Run(input);
        using var output = new Mat();

        segmenter.GetSegmentationPicture(output);

        Assert.False(output.Empty());
        Assert.Equal(input.Size(), output.Size());
        segmenter.ClearBuffers();
    }

    private static Mat CreateImage()
    {
        var image = new Mat(new Size(64, 64), MatType.CV_8UC3);
        for (var row = 0; row < image.Rows; row++)
        for (var col = 0; col < image.Cols; col++)
            image.Set(row, col, new Vec3b((byte)(row * 4), (byte)(col * 4), (byte)((row + col) * 2)));
        return image;
    }
}
