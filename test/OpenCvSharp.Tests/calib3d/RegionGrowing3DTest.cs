using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

public class RegionGrowing3DTest : TestBase
{
    private static readonly int[] SampleSeedIndices = { 0, 2, 4 };
    private static readonly float[] SampleCurvatures = { 0.01f, 0.02f, 0.03f };

    private static (Mat inputPts, Mat normals, Mat nnIdx) MakeFlatPatch()
    {
        var pts = new[]
        {
            new Point3f(0, 0, 0),
            new Point3f(1, 0, 0),
            new Point3f(0, 1, 0),
            new Point3f(1, 1, 0),
            new Point3f(0.5f, 0.5f, 0),
        };
        var inputPts = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC3, pts);

        var nnIdxData = new int[pts.Length, pts.Length];
        for (var i = 0; i < pts.Length; i++)
            for (var j = 0; j < pts.Length; j++)
                nnIdxData[i, j] = j;
        var nnIdx = Mat.FromArray(nnIdxData);

        var normals = new Mat();
        using var curvatures = new Mat();
        Cv2.NormalEstimate(normals, curvatures, inputPts, nnIdx);

        return (inputPts, normals, nnIdx);
    }

    [Fact]
    public void SegmentGroupsFlatPatchIntoOneRegion()
    {
        var (inputPts, normals, nnIdx) = MakeFlatPatch();
        using var _1 = inputPts;
        using var _2 = normals;
        using var _3 = nnIdx;

        using var rg = RegionGrowing3D.Create();
        using var labels = new Mat();

        var numRegions = rg.Segment(out var regionsIdx, labels, inputPts, normals, nnIdx);

        Assert.Equal(1, numRegions);
        Assert.Single(regionsIdx);
        Assert.Equal(inputPts.Rows, regionsIdx[0].Length);
        Assert.Equal(inputPts.Rows, labels.Rows);
    }

    [Fact]
    public void GetSetProperties()
    {
        using var rg = RegionGrowing3D.Create();

        rg.MinSize = 3;
        Assert.Equal(3, rg.MinSize);

        rg.MaxSize = 1000;
        Assert.Equal(1000, rg.MaxSize);

        rg.SmoothModeFlag = false;
        Assert.False(rg.SmoothModeFlag);
        rg.SmoothModeFlag = true;
        Assert.True(rg.SmoothModeFlag);

        rg.SmoothnessThreshold = 0.5;
        Assert.Equal(0.5, rg.SmoothnessThreshold, 6);

        rg.CurvatureThreshold = 0.1;
        Assert.Equal(0.1, rg.CurvatureThreshold, 6);

        rg.MaxNumberOfNeighbors = 10;
        Assert.Equal(10, rg.MaxNumberOfNeighbors);

        rg.NumberOfRegions = 5;
        Assert.Equal(5, rg.NumberOfRegions);

        rg.NeedSort = false;
        Assert.False(rg.NeedSort);
        rg.NeedSort = true;
        Assert.True(rg.NeedSort);
    }

    [Fact]
    public void SeedsAndCurvaturesRoundTrip()
    {
        using var rg = RegionGrowing3D.Create();

        using var seedsIn = Mat.FromArray(SampleSeedIndices);
        rg.SetSeeds(seedsIn);
        using var seedsOut = new Mat();
        rg.GetSeeds(seedsOut);
        Assert.Equal(seedsIn.Total(), seedsOut.Total());

        using var curvaturesIn = Mat.FromArray(SampleCurvatures);
        rg.SetCurvatures(curvaturesIn);
        using var curvaturesOut = new Mat();
        rg.GetCurvatures(curvaturesOut);
        Assert.Equal(curvaturesIn.Total(), curvaturesOut.Total());
    }
}
