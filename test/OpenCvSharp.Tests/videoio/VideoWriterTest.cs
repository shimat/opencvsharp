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
                using var writer = new VideoWriter("dummy1.avi", FourCCValues.MJPG, 10, image.Size());
                Assert.True(writer.IsOpened());
                writer.Write(image);
                writer.Write(image);
                writer.Write(image);
            }

            using var capture = new VideoCapture("dummy1.avi");
            Assert.True(capture.IsOpened());
            Assert.Equal("MSMF", capture.GetBackendName());
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
            using var writer = new VideoWriter("dummy2.avi", FourCCValues.MJPG, 10, new Size(640, 480));
            Assert.True(writer.IsOpened());

            writer.Set(VideoWriterProperties.Quality, 50);
            Assert.Equal(50, writer.Get(VideoWriterProperties.Quality), 3);
        }
    }
#endif
}
