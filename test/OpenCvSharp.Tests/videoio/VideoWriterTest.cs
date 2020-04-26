using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.VideoIO
{ 
#if NETFRAMEWORK
    public class VideoWriterTest : TestBase
    {
        [Fact]
        public void WriteAndCapture()
        {
            using var image = Image("lenna.png");

            {
                using var writer = new VideoWriter("dummy1.avi", FourCC.MJPG, 10, image.Size());
                Assert.True(writer.IsOpened());
                writer.Write(image);
                writer.Write(image);
                writer.Write(image);
            }

            using var capture = new VideoCapture("dummy1.avi");
            Assert.True(capture.IsOpened());

            var backendName = capture.GetBackendName();
            Assert.True(backendName == "MSMF" || backendName == "CV_MJPEG", $"Unexpected VideoWriter backend: {backendName}");

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

            Assert.Equal(image.Size(), frame1.Size());
        }

        [Fact]
        public void GetSetOption()
        {
            using var writer = new VideoWriter("dummy2.avi", FourCC.MJPG, 10, new Size(640, 480));
            Assert.True(writer.IsOpened());

            writer.Set(VideoWriterProperties.Quality, 50);
            Assert.Equal(50, writer.Get(VideoWriterProperties.Quality), 3);
        }

        [Fact]
        public void X264()
        {
            using var writer = new VideoWriter();
            var success = writer.Open(
                "temp.mp4", 
                VideoCaptureAPIs.ANY,
                FourCC.X264, 
                15, 
                new Size(1920, 1440));
            Assert.True(success);
        }

        [Fact]
        public void XVID()
        {
            using var writer = new VideoWriter();
            var success = writer.Open(
                "temp.mp4", 
                VideoCaptureAPIs.ANY,
                FourCC.XVID, 
                15, 
                new Size(1920, 1440));
            Assert.True(success);
        }

        [Fact]
        public void DIVX()
        {
            using var writer = new VideoWriter();
            var success = writer.Open(
                "temp.mp4", 
                VideoCaptureAPIs.ANY,
                FourCC.DIVX, 
                15, 
                new Size(1920, 1440));
            Assert.True(success);
        }

        [Fact]
        public void MP4V()
        {
            using var writer = new VideoWriter();
            var success = writer.Open(
                "temp.mp4", 
                VideoCaptureAPIs.ANY,
                FourCC.MP4V, 
                15, 
                new Size(1920, 1440));
            Assert.True(success);
        }

        [Fact]
        public void WMV3()
        {
            using var writer = new VideoWriter();
            var success = writer.Open(
                "temp.mp4", 
                VideoCaptureAPIs.ANY,
                FourCC.WMV3, 
                15, 
                new Size(1920, 1440));
            Assert.True(success);
        }
    }
#endif
}
