using System;
using System.Runtime.InteropServices;
using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc
{
    public class SuperpixelTest : TestBase
    {
        [Fact]
        public void LscNew()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var lsc = SuperpixelLSC.Create(image);
            GC.KeepAlive(lsc);
        }

        [Fact]
        public void SlicNew()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var slic = SuperpixelSLIC.Create(image);
            GC.KeepAlive(slic);
        }

        [Fact]
        public void SeedsNew()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var seeds = SuperpixelSEEDS.Create(
                image.Width,
                image.Height, 
                image.Channels(), 
                image.Width * image.Height,
                3);
            GC.KeepAlive(seeds);
        }
        
        [Fact]
        public void LscSimple()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var lsc = SuperpixelLSC.Create(image);

            lsc.Iterate(10);

            var superpixels = lsc.GetNumberOfSuperpixels();
            Assert.True(superpixels > 0, $"GetNumberOfSuperpixels() => {superpixels}");

            using var labels = new Mat();
            lsc.GetLabels(labels);
            Assert.False(labels.Empty());
            Assert.Equal(image.Size(), labels.Size());
            Assert.Equal(MatType.CV_32SC1, labels.Type());

            using var labelContourMask1 = new Mat();
            using var labelContourMask2 = new Mat();
            lsc.GetLabelContourMask(labelContourMask1, true);
            lsc.GetLabelContourMask(labelContourMask2, false);
            Assert.False(labelContourMask1.Empty());
            Assert.False(labelContourMask2.Empty());

            lsc.EnforceLabelConnectivity();
        }

        [Fact]
        public void SlicSimple()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var slic = SuperpixelSLIC.Create(image);

            slic.Iterate(10);

            var superpixels = slic.GetNumberOfSuperpixels();
            Assert.True(superpixels > 0, $"GetNumberOfSuperpixels() => {superpixels}");

            using var labels = new Mat();
            slic.GetLabels(labels);
            Assert.False(labels.Empty());
            Assert.Equal(image.Size(), labels.Size());
            Assert.Equal(MatType.CV_32SC1, labels.Type());

            using var labelContourMask1 = new Mat();
            using var labelContourMask2 = new Mat();
            slic.GetLabelContourMask(labelContourMask1, true);
            slic.GetLabelContourMask(labelContourMask2, false);
            Assert.False(labelContourMask1.Empty());
            Assert.False(labelContourMask2.Empty());

            slic.EnforceLabelConnectivity();
        }

        // TODO
        // [ WARN:0] global /home/runner/work/opencvsharp/opencvsharp/opencv-4.3.0/modules/core/src/matrix_expressions.cpp (1334)
        // assign OpenCV/MatExpr: processing of multi-channel arrays might be changed in the future: https://github.com/opencv/opencv/issues/16739
        [PlatformSpecificFact("Windows")]
        public void SeedsSimple()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var seeds = SuperpixelSEEDS.Create(
                image.Width,
                image.Height,
                image.Channels(),
                image.Width * image.Height,
                3);

            seeds.Iterate(image, 10);

            var superpixels = seeds.GetNumberOfSuperpixels();
            Assert.True(superpixels > 0, $"GetNumberOfSuperpixels() => {superpixels}");

            using var labels = new Mat();
            seeds.GetLabels(labels);
            Assert.False(labels.Empty());
            Assert.Equal(image.Size(), labels.Size());
            Assert.Equal(MatType.CV_32SC1, labels.Type());

            using var labelContourMask1 = new Mat();
            using var labelContourMask2 = new Mat();
            seeds.GetLabelContourMask(labelContourMask1, true);
            seeds.GetLabelContourMask(labelContourMask2, false);
            Assert.False(labelContourMask1.Empty());
            Assert.False(labelContourMask2.Empty());
        }
    }
}
