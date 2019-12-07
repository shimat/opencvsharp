using System.Diagnostics;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.VideoIO
{
    public class VideoCaptureTest : TestBase
    {/*
        [Fact]
        public void OpenImageSequence()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return;

            using var capture = new VideoCapture("_data/image/blob/shapes%d.png");
            using var image1 = new Mat("_data/image/blob/shapes1.png", ImreadModes.Color);
            using var image2 = new Mat("_data/image/blob/shapes2.png", ImreadModes.Color);
            using var image3 = new Mat("_data/image/blob/shapes3.png", ImreadModes.Color);

            Assert.True(capture.IsOpened());
            Assert.Equal("CV_IMAGES", capture.GetBackendName());
            Assert.Equal(3, capture.FrameCount);

            using var frame1 = new Mat();
            using var frame2 = new Mat();
            using var frame3 = new Mat();
            using var frame4 = new Mat();
            Assert.True(capture.Read(frame1));
            Assert.True(capture.Read(frame2));
            Assert.True(capture.Read(frame3));
            Assert.False(capture.Read(frame4));
            Assert.False(frame1.Empty());
            Assert.False(frame2.Empty());
            Assert.False(frame3.Empty());
            Assert.True(frame4.Empty());

            Cv2.CvtColor(frame1, frame1, ColorConversionCodes.BGRA2BGR);
            Cv2.CvtColor(frame2, frame2, ColorConversionCodes.BGRA2BGR);
            Cv2.CvtColor(frame3, frame3, ColorConversionCodes.BGRA2BGR);
            ImageEquals(image1, frame1);
            ImageEquals(image2, frame2);
            ImageEquals(image3, frame3);

            if (Debugger.IsAttached)
            {
                Window.ShowImages(frame1, frame2, frame3, frame4);
            }
        }

        [Fact]
        public void GetSetExceptionMode()
        {
            using var capture = new VideoCapture();

            capture.SetExceptionMode(false);
            Assert.False(capture.GetExceptionMode());

            capture.SetExceptionMode(true);
            Assert.True(capture.GetExceptionMode());
        }*/
    }
}
