using System;
using System.IO;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.VideoIO
{ 
#if NETFRAMEWORK
    public class VideoWriterTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        public VideoWriterTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void WriteAndCapture()
        {
            const string fileName = "dummy1.avi";
            try
            {
                using var image = Image("lenna.png");

                {
                    using var writer = new VideoWriter(fileName, VideoCaptureAPIs.OPENCV_MJPEG, FourCC.MJPG, 10, image.Size());
                    Assert.True(writer.IsOpened());
                    writer.Write(image);
                    writer.Write(image);
                    writer.Write(image);
                }

                using var capture = new VideoCapture(fileName);
                Assert.True(capture.IsOpened());

                var backendName = capture.GetBackendName();
                testOutputHelper.WriteLine($"[{nameof(WriteAndCapture)}] BackendName: {backendName}");
                Assert.True(backendName == "MSMF" || backendName == "CV_MJPEG" || backendName == "FFMPEG",
                    $"Unexpected VideoWriter backend: {backendName}");

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
            finally
            {
                DeleteFile(fileName);
            }
        }

        [Fact]
        public void GetSetOption()
        {
            const string fileName = "dummy2.avi";
            try
            {
                using var writer = new VideoWriter(fileName, VideoCaptureAPIs.OPENCV_MJPEG, FourCC.MJPG, 10, new Size(640, 480));
                Assert.True(writer.IsOpened());
                Assert.Equal("CV_MJPEG", writer.GetBackendName());

                Assert.True(writer.Set(VideoWriterProperties.Quality, 50), "VideoWriter.Set failed");
                Assert.Equal(50, writer.Get(VideoWriterProperties.Quality), 3);
            }
            finally
            {
                DeleteFile(fileName);
            }
        }
        
        [Fact]
        public void XVID()
        {
            const string fileName = "temp_XVID.mp4";
            try
            {
                using var writer = new VideoWriter();
                var success = writer.Open(
                    fileName,
                    VideoCaptureAPIs.ANY,
                    FourCC.XVID,
                    15,
                    new Size(1920, 1440));
                Assert.True(success);
            }
            finally
            {
                DeleteFile(fileName);
            }
        }

        [Fact]
        public void DIVX()
        {
            const string fileName = "temp_DIVX.mp4";
            try
            {
                using var writer = new VideoWriter();
                var success = writer.Open(
                    fileName,
                    VideoCaptureAPIs.ANY,
                    FourCC.DIVX,
                    15,
                    new Size(1920, 1440));
                Assert.True(success);
            }
            finally
            {
                DeleteFile(fileName);
            }
        }

        [Fact]
        public void MP4V()
        {
            const string fileName = "temp_MP4V.mp4";
            try
            {
                using var writer = new VideoWriter();
                var success = writer.Open(
                    fileName,
                    VideoCaptureAPIs.ANY,
                    FourCC.MP4V,
                    15,
                    new Size(1920, 1440));
                Assert.True(success);
            }
            finally
            {
                DeleteFile(fileName);
            }
        }

        [ExplicitFact] 
        public void WMV3()
        {
            const string fileName = "temp_WMV3.mp4";
            try
            {
                using var writer = new VideoWriter();
                var success = writer.Open(
                    fileName,
                    VideoCaptureAPIs.ANY,
                    FourCC.WMV3,
                    15,
                    new Size(1920, 1440));
                Assert.True(success);
            }
            finally
            {
                DeleteFile(fileName);
            }
        }

        [ExplicitFact]
        public void X264()
        {
            const string fileName = "temp_X264.mp4";
            try
            {
                using var writer = new VideoWriter();
                var success = writer.Open(
                    fileName,
                    VideoCaptureAPIs.ANY,
                    FourCC.X264,
                    15,
                    new Size(1920, 1440));
                Assert.True(success);
            }
            finally
            {
                DeleteFile(fileName);
            }
        }

        private void DeleteFile(string fileName, [CallerMemberName] string callerMemberName = "")
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (IOException ex)
            {
                testOutputHelper.WriteLine("[{0}]: {1}", callerMemberName, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                testOutputHelper.WriteLine("[{0}]: {1}", callerMemberName, ex);
            }
        }
    }
#endif
}
