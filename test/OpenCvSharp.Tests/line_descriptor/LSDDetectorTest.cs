using System;
using System.Diagnostics;
using OpenCvSharp.LineDescriptor;
using Xunit;

#if false

namespace OpenCvSharp.Tests.LineDescriptor
{
    // ReSharper disable once InconsistentNaming
    public class LSDDetectorTest
    {
        [Fact]
        public void New()
        {
            using var lsd = new LSDDetector();
            GC.KeepAlive(lsd);
        }

        [Fact]
        public void NewWithParam()
        {
            var lsdParam = new LSDParam();
            using var lsd = new LSDDetector(lsdParam);
            GC.KeepAlive(lsd);
        }

        [Fact]
        public void Detect()
        {
            using var src = new Mat("_data/image/building.jpg", ImreadModes.Color);
            using var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            using var lsd = new LSDDetector();
            var keyLines = lsd.Detect(gray, 2, 1);
            Assert.NotEmpty(keyLines);

            if (Debugger.IsAttached)
            {
                var random = new Random();

                foreach (var kl in keyLines)
                {
                    var color = new Scalar(random.Next(256), random.Next(256), random.Next(256));

                    Cv2.Line(src, (Point)kl.GetStartPoint(), (Point)kl.GetEndPoint(), color, 3);
                }

                Window.ShowImages(src);
            }
        }
    }
}
#endif
