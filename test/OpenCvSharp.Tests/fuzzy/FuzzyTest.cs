using Xunit;

namespace OpenCvSharp.Tests.Fuzzy;

public class FuzzyTest : TestBase
{
    [Fact]
    public void KernelOverloadsProduceTheSameLinearKernel()
    {
        using var predefined = new Mat();
        Cv2.Fuzzy.CreateKernel(FuzzyFunction.Linear, 2, predefined, 1);

        using var horizontal = new Mat(1, 5, MatType.CV_32FC1);
        using var vertical = new Mat(5, 1, MatType.CV_32FC1);
        var values = new[] { 0f, 0.5f, 1f, 0.5f, 0f };
        for (var i = 0; i < values.Length; i++)
        {
            horizontal.Set(0, i, values[i]);
            vertical.Set(i, 0, values[i]);
        }

        using var custom = new Mat();
        Cv2.Fuzzy.CreateKernel(horizontal, vertical, custom, 1);

        Assert.Equal(new Size(5, 5), predefined.Size());
        ImageEquals(predefined, custom);
    }

    [Fact]
    public void FilteringAndTransformsProduceFloatImages()
    {
        using var image = new Mat(new Size(32, 32), MatType.CV_8UC1, new Scalar(80));
        using var kernel = new Mat();
        Cv2.Fuzzy.CreateKernel(FuzzyFunction.Linear, 2, kernel, 1);
        using var output = new Mat();

        Cv2.Fuzzy.Filter(image, kernel, output);
        Assert.Equal(image.Size(), output.Size());
        Assert.Equal(MatType.CV_32FC1, output.Type());

        Cv2.Fuzzy.Ft02DProcess(image, kernel, output);
        Assert.Equal(image.Size(), output.Size());
        Cv2.Fuzzy.Ft12DProcess(image, kernel, output);
        Assert.Equal(image.Size(), output.Size());
    }

    [Fact]
    public void InpaintingAndFastLinearTransformsProduceColorImages()
    {
        using var image = new Mat(new Size(32, 32), MatType.CV_8UC3, new Scalar(40, 60, 80));
        using var mask = new Mat(image.Size(), MatType.CV_8UC1, new Scalar(1));
        mask.Set(16, 16, (byte)0);
        image.Set(16, 16, new Vec3b(0, 0, 0));
        using var output = new Mat();

        Cv2.Fuzzy.Inpaint(image, mask, output, 2);
        Assert.Equal(image.Size(), output.Size());
        Assert.Equal(MatType.CV_32FC3, output.Type());

        Cv2.Fuzzy.Ft02DFastLinearProcess(image, 2, output);
        Assert.Equal(image.Size(), output.Size());
        Cv2.Fuzzy.Ft02DFastLinearProcessFloat(image, 2, output);
        Assert.Equal(image.Size(), output.Size());
    }
}
