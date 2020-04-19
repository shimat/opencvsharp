using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc
{
    public class SuperpixelLSCTest : TestBase
    {
        [Fact]
        public void New()
        {
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var lsc = SuperpixelLSC.Create(image);
        }

        [Fact]
        public void Simple()
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
    }
}
