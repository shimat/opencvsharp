using System.Diagnostics;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.VideoIO;
    public class VideoCaptureTest : TestBase
    {
        // Platform check for conditional test execution
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        // True only when a real V4L2 device is present (e.g. /dev/video0)
        public static bool HasV4L2Device => IsLinux && Directory.EnumerateFiles("/dev", "video*").Any();

        // Backend used for the custom-stream (IStreamReader/Stream) VideoCapture tests below.
        // FFMPEG's custom-stream support (VideoCapture(Ptr<IStreamReader>, ...)) is flaky on the
        // Windows CI runners' prebuilt FFmpeg plugin DLL (createCapture(stream, ...) reports not
        // opened there, while it works locally and on Linux/macOS); MSMF is stream-capable on
        // Windows and avoids that CI-only failure.
        private static VideoCaptureAPIs StreamCaptureApi => IsWindows ? VideoCaptureAPIs.MSMF : VideoCaptureAPIs.FFMPEG;

        [Fact]
        public void ReadImageSequence()
        {
            using var capture = new VideoCapture("_data/image/blob/shapes%d.png", VideoCaptureAPIs.IMAGES);
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
        public void GrabAndRetrieveImageSequence()
        {
            using var capture = new VideoCapture("_data/image/blob/shapes%d.png", VideoCaptureAPIs.IMAGES);
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
            Assert.True(capture.Grab());
            Assert.True(capture.Retrieve(frame1));
            Assert.True(capture.Grab());
            Assert.True(capture.Retrieve(frame2));
            Assert.True(capture.Grab());
            Assert.True(capture.Retrieve(frame3));
            Assert.False(capture.Grab());
            Assert.False(capture.Retrieve(frame4));

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
        }

        [Fact(Skip = "Only runs on Windows", SkipUnless = nameof(IsWindows))]
        public void WaitAnyWindows()
        {
            using var capture = new VideoCapture("_data/image/blob/shapes%d.png");
            Assert.True(capture.IsOpened());

            var ex = Assert.Throws<OpenCVException>(() =>
            {
                var result = VideoCapture.WaitAny([capture], out var readyIndex, 0);
            });
            Assert.Equal("VideoCapture::waitAny() is supported by V4L backend only", ex.ErrMsg);
        }

        [Fact(Skip = "Requires a V4L2 device (/dev/video*)", SkipUnless = nameof(HasV4L2Device))]
        public void WaitAnyLinux()
        {
            using var capture = new VideoCapture("_data/image/blob/shapes%d.png", VideoCaptureAPIs.V4L2);
            Assert.True(capture.IsOpened());

            var result = VideoCapture.WaitAny([capture], out var readyIndex, 0);
            Assert.True(result);
            var expected = new[] { 0 };
            Assert.Equal(expected, readyIndex);

            Assert.True(capture.IsOpened());
            Assert.True(capture.Grab());
        }

        private static byte[] CreateSampleVideoBytes()
        {
            // OPENCV_MJPEG is a built-in codec (no external plugin DLL required), so this is stable
            // across all CI platforms, unlike relying on an FFmpeg-specific fourcc/container combination.
            const string fileName = "temp_stream_source.avi";
            try
            {
                using var image = LoadImage("lenna.png");
                using (var writer = new VideoWriter(fileName, VideoCaptureAPIs.OPENCV_MJPEG, FourCC.MJPG, 10, image.Size()))
                {
                    Assert.True(writer.IsOpened());
                    Assert.True(writer.Write(image));
                    Assert.True(writer.Write(image));
                    Assert.True(writer.Write(image));
                }
                return File.ReadAllBytes(fileName);
            }
            finally
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
        }

        [Fact]
        public void OpenFromStream()
        {
            using var stream = new MemoryStream(CreateSampleVideoBytes());
            using var capture = new VideoCapture(stream, StreamCaptureApi, Array.Empty<int>());

            Assert.True(capture.IsOpened());
            Assert.Equal(3, capture.FrameCount);

            using var frame = new Mat();
            Assert.True(capture.Read(frame));
            Assert.False(frame.Empty());
        }

        [Fact]
        public void OpenNonAsciiPathViaFileStream()
        {
            // On Windows, the narrow-string VideoCapture(string) constructor can fail to open a path
            // containing characters that aren't representable in the process's ANSI code page, even
            // though the file exists. Wrapping the path in a FileStream (which uses Unicode file APIs)
            // works around that without buffering the whole file into memory.
            var dir = Path.Combine(Path.GetTempPath(), "非ASCIIパステスト");
            Directory.CreateDirectory(dir);
            var fileName = Path.Combine(dir, "動画.avi");
            try
            {
                File.WriteAllBytes(fileName, CreateSampleVideoBytes());

                using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using var capture = new VideoCapture(stream, StreamCaptureApi, Array.Empty<int>());

                Assert.True(capture.IsOpened());
                using var frame = new Mat();
                Assert.True(capture.Read(frame));
                Assert.False(frame.Empty());
            }
            finally
            {
                try { Directory.Delete(dir, true); } catch (IOException) { /* best-effort cleanup */ }
            }
        }

        [Fact]
        public void OpenMethodFromStream()
        {
            using var stream = new MemoryStream(CreateSampleVideoBytes());
            using var capture = new VideoCapture();
            capture.SetExceptionMode(true);
            var opened = capture.Open(stream, StreamCaptureApi, Array.Empty<int>());

            Assert.True(opened);
            Assert.True(capture.IsOpened());
            Assert.Equal(3, capture.FrameCount);
        }

        private sealed class CountingStreamReader(Stream inner) : IStreamReader
        {
            public int ReadCount { get; private set; }

            public long Read(Span<byte> buffer)
            {
                ReadCount++;
                return inner.Read(buffer);
            }

            public long Seek(long offset, SeekOrigin origin) => inner.Seek(offset, origin);
        }

        [Fact]
        public void OpenFromCustomStreamReader()
        {
            using var stream = new MemoryStream(CreateSampleVideoBytes());
            var reader = new CountingStreamReader(stream);
            using var capture = new VideoCapture(reader, StreamCaptureApi, Array.Empty<int>());

            Assert.True(capture.IsOpened());
            using var frame = new Mat();
            Assert.True(capture.Read(frame));
            Assert.False(frame.Empty());
            Assert.True(reader.ReadCount > 0);
        }
    }
