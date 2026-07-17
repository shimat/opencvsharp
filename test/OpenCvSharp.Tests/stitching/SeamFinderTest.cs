using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class SeamFinderTest : TestBase
{
    private static (Mat, Mat) MakeImageAndMask(Scalar color)
    {
        var image = new Mat(new Size(60, 60), MatType.CV_32FC3, color);
        var mask = new Mat(new Size(60, 60), MatType.CV_8UC1, Scalar.All(255));
        return (image, mask);
    }

    private static void RunFind(SeamFinder finder)
    {
        var (image1, mask1) = MakeImageAndMask(Scalar.All(50));
        var (image2, mask2) = MakeImageAndMask(Scalar.All(200));
        try
        {
            finder.Find([image1, image2], [new Point(0, 0), new Point(30, 0)], [mask1, mask2]);
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
    [InlineData(SeamFinderType.No)]
    [InlineData(SeamFinderType.VoronoiSeam)]
    [InlineData(SeamFinderType.DpSeam)]
    public void CreateDefaultFind(SeamFinderType type)
    {
        using var finder = SeamFinder.CreateDefault(type);
        RunFind(finder);
    }

    [Fact]
    public void NoSeamFinderFind()
    {
        using var finder = new NoSeamFinder();
        RunFind(finder);
    }

    [Fact]
    public void VoronoiSeamFinderFind()
    {
        using var finder = new VoronoiSeamFinder();
        RunFind(finder);
    }

    [Fact]
    public void DpSeamFinderFind()
    {
        using var finder = new DpSeamFinder(SeamFinderCostFunction.ColorGrad);
        finder.SetCostFunction(SeamFinderCostFunction.Color);
        RunFind(finder);
    }

    [Fact]
    public void GraphCutSeamFinderFind()
    {
        using var finder = new GraphCutSeamFinder(SeamFinderCostFunction.Color);
        RunFind(finder);
    }
}
