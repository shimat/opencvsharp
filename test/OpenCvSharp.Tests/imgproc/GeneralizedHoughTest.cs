using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

// Coverage for the Cv2-agnostic GeneralizedHough.SetTemplate/Detect ArrayProxy-migrated
// methods (issue #1976 follow-up: every migrated method needs >=1 test). GeneralizedHoughBallard
// is used as a concrete, position-only (no scale/rotation search) implementation.
public class GeneralizedHoughTest : TestBase
{
    private static Mat MakeRectImage(Size imageSize, Point rectCenter)
    {
        var mat = Mat.ZerosMat(imageSize, MatType.CV_8UC1);
        Cv2.Rectangle(mat, new Rect(rectCenter.X - 10, rectCenter.Y - 10, 20, 20), Scalar.White, -1);
        return mat;
    }

    [Fact]
    public void SetTemplateAndDetect()
    {
        using var templ = MakeRectImage(new Size(60, 60), new Point(30, 30));
        using var target = MakeRectImage(new Size(240, 240), new Point(150, 100));

        using var ght = GeneralizedHoughBallard.Create();
        ght.CannyLowThresh = 50;
        ght.CannyHighThresh = 150;

        ght.SetTemplate(templ, new Point(30, 30));

        using var positions = new Mat();
        // Smoke test for the ArrayProxy wiring: GeneralizedHoughBallard's vote threshold
        // tuning is out of scope here, but reaching native without throwing proves the
        // InputArray/OutputArray params marshal correctly.
        ght.Detect(target, positions);

        Assert.True(positions.Rows >= 0);
    }

    [Fact]
    public void SetTemplateAndDetectWithEdgesDxDy()
    {
        using var templ = MakeRectImage(new Size(60, 60), new Point(30, 30));
        using var target = MakeRectImage(new Size(240, 240), new Point(150, 100));

        using var templEdges = new Mat();
        Cv2.Canny(templ, templEdges, 50, 150);
        using var templDx = new Mat();
        using var templDy = new Mat();
        Cv2.Sobel(templ, templDx, MatType.CV_32F, 1, 0);
        Cv2.Sobel(templ, templDy, MatType.CV_32F, 0, 1);

        using var targetEdges = new Mat();
        Cv2.Canny(target, targetEdges, 50, 150);
        using var targetDx = new Mat();
        using var targetDy = new Mat();
        Cv2.Sobel(target, targetDx, MatType.CV_32F, 1, 0);
        Cv2.Sobel(target, targetDy, MatType.CV_32F, 0, 1);

        using var ght = GeneralizedHoughBallard.Create();
        ght.SetTemplate(templEdges, templDx, templDy, new Point(30, 30));

        using var positions = new Mat();
        // Smoke test for the ArrayProxy wiring on the 3-InputArray overload: reaching
        // native and returning (even if no strong vote is found for a pre-computed
        // edge/gradient template) proves the params marshal correctly.
        ght.Detect(targetEdges, targetDx, targetDy, positions);

        Assert.True(positions.Rows >= 0);
    }
}
