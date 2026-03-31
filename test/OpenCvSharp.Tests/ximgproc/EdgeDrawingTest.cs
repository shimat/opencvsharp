using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc;

public class EdgeDrawingTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var ed = EdgeDrawing.Create();
        Assert.NotNull(ed);
    }

    [Fact]
    public void CreateViaStaticMethod()
    {
        using var ed = CvXImgProc.CreateEdgeDrawing();
        Assert.NotNull(ed);
    }

    [Fact]
    public void DetectEdgesGrayscale()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        using var edgeImage = new Mat();
        ed.GetEdgeImage(edgeImage);

        Assert.False(edgeImage.Empty());
        Assert.Equal(MatType.CV_8UC1, edgeImage.Type());
        Assert.Equal(src.Rows, edgeImage.Rows);
        Assert.Equal(src.Cols, edgeImage.Cols);
    }

    [Fact]
    public void DetectEdgesColor()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Color);
        ed.DetectEdges(src);

        using var edgeImage = new Mat();
        ed.GetEdgeImage(edgeImage);

        Assert.False(edgeImage.Empty());
        Assert.Equal(MatType.CV_8UC1, edgeImage.Type());
    }

    [Fact]
    public void GetGradientImage()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        using var gradImage = new Mat();
        ed.GetGradientImage(gradImage);

        Assert.False(gradImage.Empty());
        Assert.Equal(MatType.CV_16UC1, gradImage.Type());
    }

    [Fact]
    public void GetSegments()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        var segments = ed.GetSegments();
        Assert.NotNull(segments);
        Assert.True(segments.Length > 0);
    }

    [Fact]
    public void DetectLines_OutputArray()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        using var lines = new Mat();
        ed.DetectLines(lines);

        Assert.False(lines.Empty());
        Assert.Equal(MatType.CV_32FC4, lines.Type());
    }

    [Fact]
    public void DetectLines_Vector()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        Vec4f[] lines = ed.DetectLines();
        Assert.NotNull(lines);
        Assert.True(lines.Length > 0);
    }

    [Fact]
    public void DetectEllipses_OutputArray()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        using var ellipses = new Mat();
        ed.DetectEllipses(ellipses);

        // Result may be empty depending on image content; just verify no exception is thrown.
        Assert.NotNull(ellipses);
    }

    [Fact]
    public void DetectEllipses_Vector()
    {
        using var ed = EdgeDrawing.Create();
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
        ed.DetectEdges(src);

        Vec6d[] ellipses = ed.DetectEllipses();
        Assert.NotNull(ellipses);
    }

    [Fact]
    public void DefaultParams()
    {
        var p = EdgeDrawingParams.Default();
        Assert.NotNull(p);
        Assert.False(p.PFmode);
        Assert.True(p.NFAValidation);
        Assert.Equal(1.0f, p.Sigma, precision: 5);
        Assert.Equal(20, p.GradientThresholdValue);
    }

    [Fact]
    public void GetSetParams()
    {
        using var ed = EdgeDrawing.Create();

        var p = ed.GetParams();

        // Verify default values match OpenCV documentation
        Assert.False(p.PFmode);
        Assert.True(p.NFAValidation);

        // Round-trip: modify and restore
        p.PFmode = true;
        p.Sigma = 2.5f;
        p.GradientThresholdValue = 30;
        ed.SetParams(p);

        var p2 = ed.GetParams();
        Assert.True(p2.PFmode);
        Assert.Equal(2.5f, p2.Sigma, precision: 5);
        Assert.Equal(30, p2.GradientThresholdValue);
    }
}
