using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class BlenderTest : TestBase
{
    private static (Mat image, Mat mask) MakeImageAndMask()
    {
        var image = new Mat(new Size(60, 60), MatType.CV_16SC3, Scalar.All(128));
        var mask = new Mat(new Size(60, 60), MatType.CV_8UC1, Scalar.All(255));
        return (image, mask);
    }

    private static void RunBlend(Blender blender)
    {
        var (image1, mask1) = MakeImageAndMask();
        var (image2, mask2) = MakeImageAndMask();
        using var dst = new Mat();
        using var dstMask = new Mat();
        try
        {
            blender.Prepare([new Point(0, 0), new Point(30, 0)], [image1.Size(), image2.Size()]);
            blender.Feed(image1, mask1, new Point(0, 0));
            blender.Feed(image2, mask2, new Point(30, 0));
            blender.Blend(dst, dstMask);
            Assert.False(dst.Empty());
        }
        finally
        {
            image1.Dispose();
            mask1.Dispose();
            image2.Dispose();
            mask2.Dispose();
        }
    }

    [Theory]
    [InlineData(BlenderType.No)]
    [InlineData(BlenderType.Feather)]
    [InlineData(BlenderType.MultiBand)]
    public void CreateDefaultBlend(BlenderType type)
    {
        using var blender = Blender.CreateDefault(type);
        RunBlend(blender);
    }

    [Fact]
    public void FeatherBlenderProperties()
    {
        using var blender = new FeatherBlender(0.05f);
        Assert.Equal(0.05f, blender.Sharpness, 3);
        blender.Sharpness = 0.1f;
        Assert.Equal(0.1f, blender.Sharpness, 3);
        RunBlend(blender);
    }

    [Fact]
    public void MultiBandBlenderProperties()
    {
        using var blender = new MultiBandBlender(numBands: 3);
        Assert.Equal(3, blender.NumBands);
        RunBlend(blender);
    }

    [Fact]
    public void LaplacePyrRoundTrip()
    {
        using var img = new Mat(new Size(64, 64), MatType.CV_32FC3, Scalar.All(100));
        var pyr = Cv2.Detail.CreateLaplacePyr(img, 3);
        try
        {
            Assert.NotEmpty(pyr);
            using var restored = Cv2.Detail.RestoreImageFromLaplacePyr(pyr);
            Assert.False(restored.Empty());
        }
        finally
        {
            foreach (var p in pyr)
                p.Dispose();
        }
    }
}
