using OpenCvSharp.XImgProc;
using Xunit;

// ReSharper disable RedundantArgumentDefaultValue

namespace OpenCvSharp.Tests.XImgProc
{
    public class XImgProcTest : TestBase
    {
        [Theory]
        [InlineData(LocalBinarizationMethods.Niblack)]
        [InlineData(LocalBinarizationMethods.Sauvola)]
        [InlineData(LocalBinarizationMethods.Wolf)]
        [InlineData(LocalBinarizationMethods.Nick)]
        public void Niblack(LocalBinarizationMethods method)
        {
            using var src = Image("lenna.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            CvXImgProc.NiblackThreshold(src, dst, 255, ThresholdTypes.Binary, 5, 0.5, method);
            ShowImagesWhenDebugMode(dst);
        }

        [Fact]
        public void Thinning()
        {
            using var src = Image("blob/shapes2.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            CvXImgProc.Thinning(src, dst, ThinningTypes.ZHANGSUEN);
            ShowImagesWhenDebugMode(src, dst);
        }

        [Fact]
        public void AnisotropicDiffusion()
        {
            using var src = Image("blob/shapes2.png", ImreadModes.Color);
            using var dst = new Mat();
            CvXImgProc.AnisotropicDiffusion(src, dst, 1, 1, 1);
            ShowImagesWhenDebugMode(src, dst);
        }

        [Fact]
        public void WeightedMedianFilter()
        {
            using var src = Image("lenna.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            CvXImgProc.WeightedMedianFilter(src, src, dst, 7);
            ShowImagesWhenDebugMode(dst);
        }

        [Fact]
        public void CovarianceEstimation()
        {
            const int windowSize = 7;
            using var src = Image("lenna.png", ImreadModes.Grayscale);
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
            using var src = Image("lenna.png", ImreadModes.Color);
            using var dst = new Mat();
            CvXImgProc.BrightEdges(src, dst);
            ShowImagesWhenDebugMode(src, dst);
        }

        // color_match.hpp

        [Fact]
        public void ColorMatchTemplate()
        {
            using var src = Image("lenna.png", ImreadModes.Color);
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
    }
}
