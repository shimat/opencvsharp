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
        CvXImgProc.NiblackThreshold(src, dst, 255, ThresholdTypes.Binary, 5, 0.5, method);
        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void Sauvola()
    {
        foreach (var r in new double[]{16, 32, 64, 128})
        {
            using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            CvXImgProc.NiblackThreshold(
                src, dst,
                255,
                ThresholdTypes.Binary,
                5, 0.5,
                LocalBinarizationMethods.Sauvola,
                r);
            ShowImagesWhenDebugMode([dst], [$"r={r}"]);
        }
    }

    [Fact]
    public void Thinning()
    {
        using var src = LoadImage("blob/shapes2.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        CvXImgProc.Thinning(src, dst, ThinningTypes.ZHANGSUEN);
        ShowImagesWhenDebugMode(src, dst);
    }

    [Fact]
    public void AnisotropicDiffusion()
    {
        using var src = LoadImage("blob/shapes2.png", ImreadModes.Color);
        using var dst = new Mat();
        CvXImgProc.AnisotropicDiffusion(src, dst, 1, 1, 1);
        ShowImagesWhenDebugMode(src, dst);
    }

    [Fact]
    public void WeightedMedianFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        CvXImgProc.WeightedMedianFilter(src, src, dst, 7);
        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void CovarianceEstimation()
    {
        const int windowSize = 7;
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        CvXImgProc.CovarianceEstimation(src, dst, windowSize, windowSize);
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
        CvXImgProc.BrightEdges(src, dst);
        ShowImagesWhenDebugMode(src, dst);
    }

    // color_match.hpp

    [Fact]
    public void ColorMatchTemplate()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var template = src[new Rect(200, 230, 150, 150)];
        using var dst = new Mat();

        CvXImgProc.ColorMatchTemplate(src, template, dst);
        Assert.False(dst.Empty());
        Assert.Equal(MatType.CV_64FC1, dst.Type());
            
        dst.MinMaxLoc(out var minVal, out var maxVal, out var minLoc, out var maxLoc);

        using var view = src.Clone();
        view.Rectangle(maxLoc, new Point(maxLoc.X + template.Width, maxLoc.Y + template.Height), Scalar.Red, 3);
        ShowImagesWhenDebugMode(view, template);
    }

    // deriche_filter.hpp

    [Fact]
    public void GradientDeriche()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dstX = new Mat();
        using var dstY = new Mat();
        CvXImgProc.GradientDericheX(src, dstX, 10.0, 10.0);
        CvXImgProc.GradientDericheX(src, dstY, 10.0, 10.0);
        ShowImagesWhenDebugMode(src, dstX, dstY);
    }

    // edgepreserving_filter.hpp

    [Fact]
    public void EdgePreservingFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        CvXImgProc.EdgePreservingFilter(src, dst, 7, 10.0);
        ShowImagesWhenDebugMode(src, dst);
    }

    // run_length_morphology.hpp
        
    [Fact]
    public void RLThreshold()
    {
        using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
        using var dst = new Mat();
            
        CvXImgProc.RL.Threshold(src, dst, 128, ThresholdTypes.Binary);
            
        Assert.False(dst.Empty());
        Assert.Equal(MatType.CV_32SC3, dst.Type());
    }
        
    [Fact]
    public void RLGetStructuringElement()
    {
        using var se = CvXImgProc.RL.GetStructuringElement(MorphShapes.Cross, new Size(3, 3));
            
        Assert.False(se.Empty());
        Assert.Equal(new Size(1, 4), se.Size());
        Assert.Equal(MatType.CV_32SC3, se.Type());
    }
        
    [Fact]
    public void RLDilateErode()
    {
        using var src = LoadImage("mandrill.png", ImreadModes.Grayscale);
        using var binary = new Mat();
        using var dilate = new Mat();
        using var erode = new Mat();
                        
        CvXImgProc.RL.Threshold(src, binary, 128, ThresholdTypes.Binary);

        using var se = CvXImgProc.RL.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));
        CvXImgProc.RL.Dilate(binary, dilate, se);
        CvXImgProc.RL.Erode(binary, erode, se);
            
        Assert.False(dilate.Empty());
        Assert.Equal(new Size(1, 1785), dilate.Size());
        Assert.Equal(MatType.CV_32SC3, dilate.Type());

        Assert.False(erode.Empty());
        Assert.Equal(new Size(1, 1799), erode.Size());
        Assert.Equal(MatType.CV_32SC3, erode.Type());
    }
        
    // peilin.hpp

    [Fact]
    public void PeiLinNormalization()
    {
        using var src = LoadImage("peilin_plane.png", ImreadModes.Grayscale);
        using var tMat = src.Clone();
        CvXImgProc.PeiLinNormalization(src, tMat); 
        var tArray = CvXImgProc.PeiLinNormalization(src);

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
}
