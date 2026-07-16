using System.Diagnostics;
using OpenCvSharp.XImgProc;
using Xunit;

// ReSharper disable RedundantArgumentDefaultValue

namespace OpenCvSharp.Tests.XImgProc;

public class XImgProcTest : TestBase
{
    [Theory]
    [InlineData(LocalBinarizationMethods.Niblack)]
    [InlineData(LocalBinarizationMethods.Sauvola)]
    [InlineData(LocalBinarizationMethods.Wolf)]
    [InlineData(LocalBinarizationMethods.Nick)]
    public void Niblack(LocalBinarizationMethods method)
    {
        using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.XImgProc.NiblackThreshold(src, dst, 255, ThresholdTypes.Binary, 5, 0.5, method);
        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void Sauvola()
    {
        foreach (var r in new double[]{16, 32, 64, 128})
        {
            using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            Cv2.XImgProc.NiblackThreshold(
                src, dst,
                255,
                ThresholdTypes.Binary,
                5, 0.5,
                LocalBinarizationMethods.Sauvola,
                r);
            ShowImagesWhenDebugMode(($"r={r}", dst));
        }
    }

    [Fact]
    public void Thinning()
    {
        using var src = LoadImage("blob/shapes2.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.XImgProc.Thinning(src, dst, ThinningTypes.ZHANGSUEN);
        ShowImagesWhenDebugMode(src, dst);
    }

    [Fact]
    public void AnisotropicDiffusion()
    {
        using var src = LoadImage("blob/shapes2.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.AnisotropicDiffusion(src, dst, 1, 1, 1);
        ShowImagesWhenDebugMode(src, dst);
    }

    [Fact]
    public void WeightedMedianFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.XImgProc.WeightedMedianFilter(src, src, dst, 7);
        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void CovarianceEstimation()
    {
        const int windowSize = 7;
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.XImgProc.CovarianceEstimation(src, dst, windowSize, windowSize);
        // TODO
        Assert.Equal(windowSize * windowSize, dst.Rows);
        Assert.Equal(windowSize * windowSize, dst.Cols);
        Assert.Equal(MatType.CV_32FC2, dst.Type());
    }

    // brightedges.hpp

    [Fact]
    public void BrightEdges()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.BrightEdges(src, dst);
        ShowImagesWhenDebugMode(src, dst);
    }

    // color_match.hpp

    [Fact]
    public void ColorMatchTemplate()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var template = src[new Rect(200, 230, 150, 150)];
        using var dst = new Mat();

        Cv2.XImgProc.ColorMatchTemplate(src, template, dst);
        Assert.False(dst.Empty());
        Assert.Equal(MatType.CV_64FC1, dst.Type());
            
        Cv2.MinMaxLoc(dst, out var minVal, out var maxVal, out var minLoc, out var maxLoc);

        using var view = src.Clone();
        Cv2.Rectangle(view, maxLoc, new Point(maxLoc.X + template.Width, maxLoc.Y + template.Height), Scalar.Red, 3);
        ShowImagesWhenDebugMode(view, template);
    }

    // deriche_filter.hpp

    [Fact]
    public void GradientDeriche()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dstX = new Mat();
        using var dstY = new Mat();
        Cv2.XImgProc.GradientDericheX(src, dstX, 10.0, 10.0);
        Cv2.XImgProc.GradientDericheX(src, dstY, 10.0, 10.0);
        ShowImagesWhenDebugMode(src, dstX, dstY);
    }

    // edgepreserving_filter.hpp

    [Fact]
    public void EdgePreservingFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.EdgePreservingFilter(src, dst, 7, 10.0);
        ShowImagesWhenDebugMode(src, dst);
    }

    // run_length_morphology.hpp
        
    [Fact]
    public void RLThreshold()
    {
        using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
        using var dst = new Mat();
            
        Cv2.XImgProc.RL.Threshold(src, dst, 128, ThresholdTypes.Binary);
            
        Assert.False(dst.Empty());
        Assert.Equal(MatType.CV_32SC3, dst.Type());
    }
        
    [Fact]
    public void RLGetStructuringElement()
    {
        using var se = Cv2.XImgProc.RL.GetStructuringElement(MorphShapes.Cross, new Size(3, 3));
            
        Assert.False(se.Empty());
        // OpenCV 5 returns the run-length structuring element as a 1xN row vector
        // instead of the Nx1 column vector OpenCV 4 produced.
        Assert.Equal(new Size(4, 1), se.Size());
        Assert.Equal(MatType.CV_32SC3, se.Type());
    }
        
    [Fact]
    public void RLDilateErode()
    {
        using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
        using var binary = new Mat();
        using var dilate = new Mat();
        using var erode = new Mat();
                        
        Cv2.XImgProc.RL.Threshold(src, binary, 128, ThresholdTypes.Binary);

        using var se = Cv2.XImgProc.RL.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));
        Cv2.XImgProc.RL.Dilate(binary, dilate, se);
        Cv2.XImgProc.RL.Erode(binary, erode, se);
            
        // OpenCV 5 returns the run-length encoded result as a 1xN row vector
        // instead of the Nx1 column vector OpenCV 4 produced.
        Assert.False(dilate.Empty());
        Assert.Equal(new Size(1785, 1), dilate.Size());
        Assert.Equal(MatType.CV_32SC3, dilate.Type());

        Assert.False(erode.Empty());
        Assert.Equal(new Size(1799, 1), erode.Size());
        Assert.Equal(MatType.CV_32SC3, erode.Type());
    }
        
    // deriche / paillou

    [Fact]
    public void GradientDericheY()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.GradientDericheY(src, dst, 10.0, 10.0);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void GradientPaillou()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dstX = new Mat();
        using var dstY = new Mat();
        Cv2.XImgProc.GradientPaillouX(src, dstX, 10.0, 10.0);
        Cv2.XImgProc.GradientPaillouY(src, dstY, 10.0, 10.0);
        Assert.False(dstX.Empty());
        Assert.False(dstY.Empty());
    }

    // color_match.hpp (quaternion)

    [Fact]
    public void QuaternionImageOps()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var qimg = new Mat();
        Cv2.XImgProc.CreateQuaternionImage(src, qimg);
        Assert.False(qimg.Empty());
        Assert.Equal(src.Size(), qimg.Size());

        using var qconj = new Mat();
        Cv2.XImgProc.QConj(qimg, qconj);
        Assert.Equal(qimg.Size(), qconj.Size());

        using var qunit = new Mat();
        Cv2.XImgProc.QUnitary(qimg, qunit);
        Assert.Equal(qimg.Size(), qunit.Size());

        using var qmul = new Mat();
        Cv2.XImgProc.QMultiply(qimg, qconj, qmul);
        Assert.Equal(qimg.Size(), qmul.Size());

        using var qdft = new Mat();
        Cv2.XImgProc.QDft(qimg, qdft, DftFlags.None, true);
        Assert.False(qdft.Empty());
    }

    // edge-aware filters

    [Fact]
    public void DTFilterStatic()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.DTFilter(src, src, dst, 10.0, 25.0);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void GuidedFilterStatic()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.GuidedFilter(src, src, dst, 5, 100.0);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void AMFilterStatic()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.AMFilter(src, src, dst, 16.0, 0.2);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void JointBilateralFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.JointBilateralFilter(src, src, dst, 7, 25.0, 7.0);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void BilateralTextureFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.BilateralTextureFilter(src, dst);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void RollingGuidanceFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.RollingGuidanceFilter(src, dst);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void FastGlobalSmootherFilterStatic()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.FastGlobalSmootherFilter(src, src, dst, 100.0, 5.0);
        Assert.False(dst.Empty());
    }

    [Fact]
    public void FastBilateralSolverFilterStatic()
    {
        using var guide = LoadImage("lenna.png", ImreadModes.Color);
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var confidence = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All(255));
        using var dst = new Mat();
        try
        {
            Cv2.XImgProc.FastBilateralSolverFilter(guide, src, confidence, dst);
            Assert.False(dst.Empty());
        }
        catch (OpenCVException ex) when (ex.Message.Contains("EIGEN", StringComparison.Ordinal))
        {
            // OpenCV built without EIGEN: the P/Invoke proxy wiring still reached
            // native (the feature guard throws), which is what this test verifies.
        }
    }

    [Fact]
    public void L0Smooth()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.XImgProc.L0Smooth(src, dst);
        Assert.False(dst.Empty());
    }

    // run_length_morphology.hpp (extra coverage)

    [Fact]
    public void RLMorphologyEx()
    {
        using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
        using var binary = new Mat();
        using var dst = new Mat();
        Cv2.XImgProc.RL.Threshold(src, binary, 128, ThresholdTypes.Binary);
        using var se = Cv2.XImgProc.RL.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));

        Cv2.XImgProc.RL.MorphologyEx(binary, dst, MorphTypes.Open, se);

        Assert.False(dst.Empty());
        Assert.Equal(MatType.CV_32SC3, dst.Type());
    }

    [Fact]
    public void RLIsRLMorphologyPossible()
    {
        using var se = Cv2.XImgProc.RL.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));
        Assert.True(Cv2.XImgProc.RL.IsRLMorphologyPossible(se));
    }

    [Fact]
    public void RLPaintAndCreateRLEImage()
    {
        // Build an RL image from explicit runs, then paint it onto a canvas.
        var runs = new[] { new Point3i(0, 4, 2), new Point3i(0, 4, 3) };
        using var rle = new Mat();
        Cv2.XImgProc.RL.CreateRLEImage(runs, rle, new Size(10, 10));
        Assert.False(rle.Empty());

        using var canvas = Mat.ZerosMat(10, 10, MatType.CV_8UC1);
        Cv2.XImgProc.RL.Paint(canvas, rle, Scalar.All(255));
        Assert.True(Cv2.CountNonZero(canvas) > 0);
    }

    // peilin.hpp

    [Fact]
    public void PeiLinNormalization()
    {
        using var src = LoadImage("peilin_plane.png", ImreadModes.Grayscale);
        using var tMat = src.Clone();
        Cv2.XImgProc.PeiLinNormalization(src, tMat); 
        var tArray = Cv2.XImgProc.PeiLinNormalization(src);

        Assert.Equal(MatType.CV_64FC1, tMat.Type());
        Assert.Equal(2, tMat.Rows);
        Assert.Equal(3, tMat.Cols);
        Assert.Equal(2, tArray.GetLength(0));
        Assert.Equal(3, tArray.GetLength(1));

        for (int r = 0; r < 2; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                Assert.Equal(tArray[r, c], tMat.At<double>(r, c));
            }
        }

        if (Debugger.IsAttached)
        {
            using var warped = new Mat();
            Cv2.WarpAffine(src, warped, tMat, src.Size());
            Window.ShowImages(src, warped);
        }
    }

    // find_ellipses.hpp

    [Fact]
    public void FindEllipses()
    {
        // Neither lenna.png nor mandrill.png contains ellipses strong enough to pass the default
        // thresholds, so this only proves the InputArray/OutputArray params marshal correctly and
        // the call reaches native without throwing - not that any ellipse is actually found.
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var ellipses = new Mat();
        Cv2.XImgProc.FindEllipses(src, ellipses);
        Assert.NotNull(ellipses);
    }

    // radon_transform.hpp

    [Fact]
    public void RadonTransform()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.XImgProc.RadonTransform(src, dst);
        Assert.False(dst.Empty());
    }

    // scansegment.hpp

    [Fact]
    public void ScanSegment()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var lab = new Mat();
        Cv2.CvtColor(src, lab, ColorConversionCodes.BGR2Lab);

        using var scanSegment = Cv2.XImgProc.CreateScanSegment(src.Width, src.Height, numSuperpixels: 400);
        scanSegment.Iterate(lab);

        Assert.True(scanSegment.GetNumberOfSuperpixels() > 0);

        using var labels = new Mat();
        scanSegment.GetLabels(labels);
        Assert.False(labels.Empty());

        using var mask = new Mat();
        scanSegment.GetLabelContourMask(mask);
        Assert.False(mask.Empty());
    }

    // fourier_descriptors.hpp

    [Fact]
    public void ContourFitting()
    {
        using var contourFitting = Cv2.XImgProc.CreateContourFitting();
        Assert.Equal(1024, contourFitting.CtrSize);
        Assert.Equal(16, contourFitting.FDSize);

        var src = CirclePoints(new Point2f(32, 32), 20, 16);
        var dst = CirclePoints(new Point2f(40, 40), 24, 16);
        using var srcMat = Mat.FromArray(src);
        using var dstMat = Mat.FromArray(dst);
        using var alphaPhiST = new Mat();

        contourFitting.EstimateTransformation(srcMat, dstMat, alphaPhiST, out var dist);
        Assert.False(alphaPhiST.Empty());
        Assert.True(dist >= 0);
    }

    [Fact]
    public void FourierDescriptorAndContourSampling()
    {
        var pts = CirclePoints(new Point2f(32, 32), 20, 16);
        using var contour = Mat.FromArray(pts);

        using var sampled = new Mat();
        Cv2.XImgProc.ContourSampling(contour, sampled, 32);
        Assert.False(sampled.Empty());

        using var fd = new Mat();
        Cv2.XImgProc.FourierDescriptor(sampled, fd);
        Assert.False(fd.Empty());

        using var t = Mat.Eye(1, 5, MatType.CV_64FC1).ToMat();
        using var transformed = new Mat();
        Cv2.XImgProc.TransformFD(sampled, t, transformed, fdContour: false);
        Assert.False(transformed.Empty());
    }

    // disparity_filter.hpp

    [Fact]
    public void DisparityWLSFilter()
    {
        using var left = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var right = left.Clone();

        using var matcherLeft = StereoBM.Create(numDisparities: 16, blockSize: 15);
        using var matcherRight = Cv2.XImgProc.CreateRightMatcher(matcherLeft);
        using var wls = Cv2.XImgProc.CreateDisparityWLSFilter(matcherLeft);

        using var leftDisp = new Mat();
        using var rightDisp = new Mat();
        matcherLeft.Compute(left, right, leftDisp);
        matcherRight.Compute(right, left, rightDisp);

        using var filteredDisp = new Mat();
        wls.Filter(leftDisp, left, filteredDisp, rightDisp);
        Assert.False(filteredDisp.Empty());

        using var vis = new Mat();
        Cv2.XImgProc.GetDisparityVis(filteredDisp, vis);
        Assert.False(vis.Empty());

        Assert.True(wls.Lambda > 0);
        Assert.True(wls.SigmaColor > 0);
    }

    // sparse_match_interpolator.hpp

    [Fact]
    public void EdgeAwareInterpolator()
    {
        using var interpolator = Cv2.XImgProc.CreateEdgeAwareInterpolator();
        Assert.True(interpolator.K > 0);

        interpolator.K = 64;
        Assert.Equal(64, interpolator.K);

        using var fromImage = LoadImage("lenna.png", ImreadModes.Color);
        using var toImage = fromImage.Clone();
        var fromPts = new[] { new Point2f(10, 10), new Point2f(50, 50), new Point2f(100, 100) };
        var toPts = new[] { new Point2f(11, 11), new Point2f(51, 51), new Point2f(101, 101) };
        using var fromPtsMat = Mat.FromArray(fromPts);
        using var toPtsMat = Mat.FromArray(toPts);
        using var denseFlow = new Mat();

        interpolator.Interpolate(fromImage, fromPtsMat, toImage, toPtsMat, denseFlow);
        Assert.False(denseFlow.Empty());
    }

    [Fact]
    public void RICInterpolator()
    {
        using var interpolator = Cv2.XImgProc.CreateRICInterpolator();
        Assert.True(interpolator.K > 0);

        interpolator.K = 16;
        Assert.Equal(16, interpolator.K);

        using var fromImage = LoadImage("lenna.png", ImreadModes.Color);
        using var toImage = fromImage.Clone();
        var fromPts = new[] { new Point2f(10, 10), new Point2f(50, 50), new Point2f(100, 100) };
        var toPts = new[] { new Point2f(11, 11), new Point2f(51, 51), new Point2f(101, 101) };
        using var fromPtsMat = Mat.FromArray(fromPts);
        using var toPtsMat = Mat.FromArray(toPts);
        using var denseFlow = new Mat();

        interpolator.Interpolate(fromImage, fromPtsMat, toImage, toPtsMat, denseFlow);
        Assert.False(denseFlow.Empty());
    }

    // ---- helpers ----

    private static Point2f[] CirclePoints(Point2f center, float radius, int count)
    {
        var pts = new Point2f[count];
        for (int i = 0; i < count; i++)
        {
            double angle = 2 * Math.PI * i / count;
            pts[i] = new Point2f(
                center.X + (float)(radius * Math.Cos(angle)),
                center.Y + (float)(radius * Math.Sin(angle)));
        }
        return pts;
    }
}
