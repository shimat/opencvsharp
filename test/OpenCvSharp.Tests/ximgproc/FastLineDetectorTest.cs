using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc
{
    public class FastLineDetectorTest : TestBase
    {
        [Fact]
        public void New1()
        {
            var fld = FastLineDetector.Create();
            fld.Dispose();
        }

        [Fact]
        public void New2()
        {
            var fld = CvXImgProc.CreateFastLineDetector();
            fld.Dispose();
        }

        [Fact]
        public void DetectUsingOutputArray()
        {
            using var fld = FastLineDetector.Create();
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var lines = new Mat();
            fld.Detect(image, lines);
            Assert.False(lines.Empty());
            Assert.Equal(MatType.CV_32FC4, lines.Type());
            Assert.True(lines.Rows > 0);
        }

        [Fact]
        public void DetectUsingVector()
        {
            using var fld = FastLineDetector.Create();
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            Vec4f[] lines = fld.Detect(image);
            Assert.NotNull(lines);
            Assert.True(lines.Length > 0);
        }

        [Fact]
        public void DrawSegmentsUsingInputArray()
        {
            using var fld = FastLineDetector.Create();
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var view = image.Clone();
            using var lines = new Mat();
            fld.Detect(image, lines);
            fld.DrawSegments(view, lines, true);
            ShowImagesWhenDebugMode(view);
        }

        [Fact]
        public void DrawSegmentsUsingVector()
        {
            using var fld = FastLineDetector.Create();
            using var image = Image("building.jpg", ImreadModes.Grayscale);
            using var view = image.Clone();
            Vec4f[] lines = fld.Detect(image);
            fld.DrawSegments(view, lines, true);
            ShowImagesWhenDebugMode(view);
        }
    }
}

