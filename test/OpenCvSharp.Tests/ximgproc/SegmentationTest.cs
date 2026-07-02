using OpenCvSharp.XImgProc.Segmentation;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc;

public class SegmentationTest : TestBase
{
    [Fact]
    public void GraphSegmentationProcessImage()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var gs = GraphSegmentation.Create();
        using var dst = new Mat();

        gs.ProcessImage(src, dst);

        Assert.False(dst.Empty());
        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_32SC1, dst.Type());
    }

    [Fact]
    public void SelectiveSearchSetBaseImageAndAddImage()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var ss = SelectiveSearchSegmentation.Create();

        // Both go through the migrated setBaseImage/addImage proxies.
        ss.SetBaseImage(src);
        ss.AddImage(src);
    }

    [Fact]
    public void SelectiveSearchStrategySetImage()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);

        // Produce a region map with GraphSegmentation, then feed a colour strategy.
        using var gs = GraphSegmentation.Create();
        using var regions = new Mat();
        gs.ProcessImage(src, regions);

        Cv2.MinMaxLoc(regions, out _, out double maxVal);
        var numRegions = (int)maxVal + 1;
        using var sizes = new Mat(1, numRegions, MatType.CV_32SC1, Scalar.All(1));

        using var strategy = SelectiveSearchSegmentationStrategyColor.Create();
        strategy.SetImage(src, regions, sizes);

        using var multi = SelectiveSearchSegmentationStrategyMultiple.Create();
        multi.SetImage(src, regions, sizes);
    }
}
