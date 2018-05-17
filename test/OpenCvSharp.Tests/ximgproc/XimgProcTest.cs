using System;
using System.Collections.Generic;
using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc
{
    public class XImgProcTest : TestBase
    {
        [Fact]
        public void Niblack()
        {
            using (var src = Image("lenna.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                CvXImgProc.NiblackThreshold(src, dst, 255, ThresholdTypes.Binary, 5, 0.5);
                ShowImagesWhenDebugMode(dst);
            }
        }

        [Fact]
        public void Thinning()
        {
            using (var src = Image("blob/shapes2.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                CvXImgProc.Thinning(src, dst, ThinningTypes.ZHANGSUEN);
                ShowImagesWhenDebugMode(src, dst);
            }
        }

        [Fact]
        public void AnisotropicDiffusion()
        {
            using (var src = Image("blob/shapes2.png", ImreadModes.Color))
            using (var dst = new Mat())
            {
                CvXImgProc.AnisotropicDiffusion(src, dst, 1, 1, 1);
                ShowImagesWhenDebugMode(src, dst);
            }
        }

        [Fact]
        public void WeightedMedianFilter()
        {
            using (var src = Image("lenna.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                CvXImgProc.WeightedMedianFilter(src, src, dst, 7);
                ShowImagesWhenDebugMode(dst);
            }
        }

        [Fact]
        public void CovarianceEstimation()
        {
            const int windowSize = 7;
            using (var src = Image("lenna.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                CvXImgProc.CovarianceEstimation(src, dst, windowSize, windowSize);
                // TODO
                Assert.Equal(windowSize * windowSize, dst.Rows);
                Assert.Equal(windowSize * windowSize, dst.Cols);
                Assert.Equal(MatType.CV_32FC2, dst.Type());
            }
        }
    }
}

