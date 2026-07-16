using OpenCvSharp.Hfs;
using Xunit;

namespace OpenCvSharp.Tests.Hfs;

public class HfsSegmentTest : TestBase
{
    [Fact]
    public void PerformSegmentCpu()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var segment = HfsSegment.Create(src.Height, src.Width);

        using var result = segment.PerformSegmentCpu(src, ifDraw: true);

        Assert.False(result.Empty());
        Assert.Equal(src.Rows, result.Rows);
        Assert.Equal(src.Cols, result.Cols);
        Assert.Equal(src.Type(), result.Type());
    }

    [Fact]
    public void PerformSegmentCpuWithoutDraw()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var segment = HfsSegment.Create(src.Height, src.Width);

        using var result = segment.PerformSegmentCpu(src, ifDraw: false);

        Assert.False(result.Empty());
        Assert.Equal(src.Rows, result.Rows);
        Assert.Equal(src.Cols, result.Cols);
        Assert.Equal(MatType.CV_16UC1, result.Type());
    }

    [Fact]
    public void PerformSegmentGpuFallsBackToCpu()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var segment = HfsSegment.Create(src.Height, src.Width);

        using var result = segment.PerformSegmentGpu(src, ifDraw: true);

        Assert.False(result.Empty());
        Assert.Equal(src.Rows, result.Rows);
        Assert.Equal(src.Cols, result.Cols);
    }

    [Fact]
    public void Properties()
    {
        using var segment = HfsSegment.Create(100, 100);

        segment.SegEgbThresholdI = 0.1f;
        Assert.Equal(0.1f, segment.SegEgbThresholdI, precision: 5);

        segment.MinRegionSizeI = 50;
        Assert.Equal(50, segment.MinRegionSizeI);

        segment.SegEgbThresholdII = 0.2f;
        Assert.Equal(0.2f, segment.SegEgbThresholdII, precision: 5);

        segment.MinRegionSizeII = 150;
        Assert.Equal(150, segment.MinRegionSizeII);

        segment.SpatialWeight = 0.5f;
        Assert.Equal(0.5f, segment.SpatialWeight, precision: 5);

        segment.SlicSpixelSize = 10;
        Assert.Equal(10, segment.SlicSpixelSize);

        segment.NumSlicIter = 3;
        Assert.Equal(3, segment.NumSlicIter);
    }
}
