#nullable enable
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

#pragma warning disable CA1031

namespace OpenCvSharp.Tests.ImgCodecs
{
    public class ImgCodecsTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        public ImgCodecsTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("building.jpg")]
        [InlineData("lenna.png")]
        [InlineData("building_mask.bmp")]
        public void ImReadSuccess(string fileName)
        {
            using (var image = Image(fileName, ImreadModes.Grayscale))
            {
                Assert.False(image.Empty());
            }
            using (var image = Image(fileName, ImreadModes.Color))
            {
                Assert.False(image.Empty());
            }
            using (var image = Image(fileName, ImreadModes.AnyColor | ImreadModes.AnyDepth))
            {
                Assert.False(image.Empty());
            }
        }

        [Fact]
        public void ImReadFailure()
        {
            using var image = Cv2.ImRead("not_exist.png", ImreadModes.Grayscale);
            Assert.NotNull(image);
            Assert.True(image.Empty());
        }
        
        [Fact]
        public void ImReadDoesNotSupportGif()
        {
            using var image = Cv2.ImRead("_data/image/empty.gif", ImreadModes.Grayscale);
            Assert.NotNull(image);
            Assert.True(image.Empty());
        }

        //[LinuxOnlyFact]
        [Fact]
        public void ImReadJapaneseFileName()
        {
            // https://github.com/opencv/opencv/issues/4242
            // TODO: Fails on AppVeyor (probably this test succeeds only on Japanese Windows)

            testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
            {
                testOutputHelper.WriteLine($"Skip {nameof(ImReadJapaneseFileName)}");
                return;
            }

            const string fileName = "_data/image/imread_にほんご日本語.png";

            // Create test data
            {
                using var bitmap = new Bitmap(10, 10, PixelFormat.Format24bppRgb);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.Red);
                bitmap.Save(fileName, ImageFormat.Png);
            }

            Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

            using var image = Cv2.ImRead(fileName, ImreadModes.Color);
            Assert.NotNull(image);
            Assert.False(image.Empty());
        }

        // TODO Windows not supported?
        // https://github.com/opencv/opencv/issues/4242
        //[PlatformSpecificFact("Linux")]
        [Fact]
        public void ImReadUnicodeFileName()
        {
            const string fileName = "_data/image/imread♥♡😀😄.png";

            CreateDummyImageFile(fileName);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // TODO
                // Cannot marshal: Encountered unmappable character.
                // at System.Runtime.InteropServices.Marshal.StringToAnsiString(String s, Byte * buffer, Int32 bufferLength, Boolean bestFit, Boolean throwOnUnmappableChar)
                Assert.Throws<ArgumentException>(() =>
                {
                    using var image = Cv2.ImRead(fileName, ImreadModes.Color);
                    //Assert.NotNull(image);
                    //Assert.False(image.Empty());
                });
            }
            else
            {
                using var image = Cv2.ImRead(fileName, ImreadModes.Color);
                Assert.NotNull(image);
                Assert.False(image.Empty());
            }
        }

        [Theory]
        [InlineData(".jpg")]
        [InlineData(".png")]
        [InlineData(".bmp")]
        [InlineData(".tif")]
        public void ImWrite(string ext)
        {
            string fileName = $"test_imwrite{ext}";

            using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
            {
                Cv2.ImWrite(fileName, mat);
            }

            using var bitmap = new Bitmap(fileName);
            Assert.Equal(10, bitmap.Height);
            Assert.Equal(20, bitmap.Width);
        }

        //[LinuxOnlyFact]
        [Fact]
        public void ImWriteJapaneseFileName()
        {
            // TODO: Fails on AppVeyor (probably this test succeeds only on Japanese Windows)
            testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
            {
                testOutputHelper.WriteLine($"Skip {nameof(ImWriteJapaneseFileName)}");
                return;
            }

            const string fileName = "_data/image/imwrite_にほんご日本語.png";

            using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
            {
                Cv2.ImWrite(fileName, mat);
            }

            Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

            using var bitmap = new Bitmap(fileName);
            Assert.Equal(10, bitmap.Height);
            Assert.Equal(20, bitmap.Width);
        }

        // TODO
        // https://github.com/opencv/opencv/issues/4242
        //[PlatformSpecificFact("Linux")]
        [Fact]
        public void ImWriteUnicodeFileName()
        {
            const string fileName = "_data/image/imwrite♥♡😀😄.png";

            // Check whether the path is valid
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Path.GetFullPath(fileName);

            using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // TODO
                    // Cannot marshal: Encountered unmappable character.
                    // at System.Runtime.InteropServices.Marshal.StringToAnsiString(String s, Byte * buffer, Int32 bufferLength, Boolean bestFit, Boolean throwOnUnmappableChar)
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Cv2.ImWrite(fileName, mat);
                    });
                    return;
                }
                else
                {
                    Cv2.ImWrite(fileName, mat);
                }
            }

            // TODO fail
            var file = new FileInfo(fileName);
            Assert.True(file.Exists, $"File '{fileName}' not found");
            Assert.True(file.Length > 0, $"File size of '{fileName}' == 0");

            const string asciiFileName = "_data/image/imwrite_unicode_test.png";
            File.Move(fileName, asciiFileName);
            using (var bitmap = new Bitmap(asciiFileName))
            {
                Assert.Equal(10, bitmap.Height);
                Assert.Equal(20, bitmap.Width);
            }
        }

        // TODO AccessViolationException
        //[PlatformSpecificTheory("Windows")]
        [Theory]
        [InlineData("foo.png")]
        [InlineData("bar.jpg")]
        [InlineData("baz.bmp")]
        public void HaveImageReader(string fileName)
        {
            var path = Path.Combine("_data", "image", "haveImageReader_" + fileName);

            try
            {
                // Create a file for test
                using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
                {
                    Cv2.ImWrite(path, mat);
                }
                Assert.True(File.Exists(path), $"File '{path}' not found");

                //Assert.True(Cv2.HaveImageReader(path));
            }
            finally
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    testOutputHelper.WriteLine(ex.ToString());
                }
            }
        }

        // TODO
        [Fact(Skip = "AccessViolationException")]
        //[PlatformSpecificFact("Windows")]
        public void HaveImageReaderJapanese()
        {
            testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
            {
                testOutputHelper.WriteLine($"Skip {nameof(ImWriteJapaneseFileName)}");
                return;
            }

            var path = Path.Combine("_data", "image", "haveImageReader_にほんご日本語.png");

            try
            {
                CreateDummyImageFile(path);
                Assert.True(Cv2.HaveImageReader(path));
            }
            finally
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    testOutputHelper.WriteLine(ex.ToString());
                }
            }
        }

        [PlatformSpecificFact("Windows")]
        public void HaveImageReaderUnicode()
        {
            var path = Path.Combine("_data", "image", "haveImageReader_♥♡😀😄.png");

            try
            {
                CreateDummyImageFile(path);

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // TODO
                    // Cannot marshal: Encountered unmappable character.
                    // at System.Runtime.InteropServices.Marshal.StringToAnsiString(String s, Byte * buffer, Int32 bufferLength, Boolean bestFit, Boolean throwOnUnmappableChar)
                    Assert.Throws<ArgumentException>(() => { Cv2.HaveImageReader(path); });
                }
                else
                {
                    Assert.True(Cv2.HaveImageReader(path));
                }
            }
            finally
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    testOutputHelper.WriteLine(ex.ToString());
                }
            }
        }

        // TODO
        //[PlatformSpecificTheory("Windows")]
        [Theory]
        [InlineData("foo.png")]
        [InlineData("bar.jpg")]
        [InlineData("baz.bmp")]
        public void HaveImageWriter(string fileName)
        {
            Assert.True(Cv2.HaveImageWriter(fileName));
        }

        // TODO
        [Fact(Skip = "AccessViolationException")]
        public void HaveImageWriterJapanese()
        {
            // TODO: Fails on AppVeyor (probably this test succeeds only on Japanese Windows)
            testOutputHelper.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture.Name}");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                Thread.CurrentThread.CurrentCulture.Name != "ja-JP")
            {
                testOutputHelper.WriteLine($"Skip {nameof(ImWriteJapaneseFileName)}");
                return;
            }

            // This file does not have to exist
            const string fileName = "にほんご日本語.png";

            Assert.True(Cv2.HaveImageWriter(fileName));
        }

        // TODO
        [PlatformSpecificFact("Windows")]
        public void HaveImageWriterUnicode()
        {
            // This file does not have to exist
            const string fileName = "♥♡😀😄.png";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // TODO
                // Cannot marshal: Encountered unmappable character.
                // at System.Runtime.InteropServices.Marshal.StringToAnsiString(String s, Byte * buffer, Int32 bufferLength, Boolean bestFit, Boolean throwOnUnmappableChar)
                Assert.Throws<ArgumentException>(() =>
                {
                    Cv2.HaveImageWriter(fileName);
                });
            }
            else
            {
                Assert.True(Cv2.HaveImageWriter(fileName));
            }
        }

        [Theory]
        [InlineData(".png")]
        [InlineData(".jpg")]
        [InlineData(".tif")]
        [InlineData(".bmp")]
        public void ImEncode(string ext)
        {
            using var mat = Image("lenna.png", ImreadModes.Grayscale);
            Assert.False(mat.Empty());

            Cv2.ImEncode(ext, mat, out var imageData);
            Assert.NotNull(imageData);

            // Can System.Drawing.Bitmap decode the imageData?
            using var stream = new MemoryStream(imageData);
            using var bitmap = new Bitmap(stream);
            Assert.Equal(mat.Rows, bitmap.Height);
            Assert.Equal(mat.Cols, bitmap.Width);
        }

        [Theory]
        [InlineData("Png")]
        [InlineData("Jpeg")]
        [InlineData("Tiff")]
        [InlineData("Bmp")]
        public void ImDecode(string imageFormatName)
        {
            var imageFormatProperty =
                typeof(ImageFormat).GetProperty(imageFormatName, BindingFlags.Public | BindingFlags.Static);
            Assert.NotNull(imageFormatProperty);
            var imageFormat = imageFormatProperty!.GetValue(null) as ImageFormat;
            Assert.NotNull(imageFormat);

            using var bitmap = new Bitmap("_data/image/mandrill.png");
            using var stream = new MemoryStream();
            bitmap.Save(stream, imageFormat);
            var imageData = stream.ToArray();
            Assert.NotNull(imageData);

            using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
            Assert.NotNull(mat);
            Assert.False(mat.Empty());
            Assert.Equal(bitmap.Width, mat.Cols);
            Assert.Equal(bitmap.Height, mat.Rows);

            ShowImagesWhenDebugMode(mat);
        }

        [Fact]
        public void ImDecodeSpan()
        {
            var imageBytes = File.ReadAllBytes("_data/image/mandrill.png");
            Assert.NotEmpty(imageBytes);

            // whole range
            {
                var span = imageBytes.AsSpan();
                using var mat = Cv2.ImDecode(span, ImreadModes.Color);
                Assert.NotNull(mat);
                Assert.False(mat.Empty());
                ShowImagesWhenDebugMode(mat);
            }

            // slice
            {
                var dummyBytes = Enumerable.Repeat((byte)123, 100).ToArray();
                var imageBytesWithDummy = dummyBytes.Concat(imageBytes).Concat(dummyBytes).ToArray();

#if NET48
                var span = imageBytesWithDummy.AsSpan(100, imageBytes.Length);
#else
                var span = imageBytesWithDummy.AsSpan()[100..^100];
#endif
                using var mat = Cv2.ImDecode(span, ImreadModes.Color);
                Assert.NotNull(mat);
                Assert.False(mat.Empty());
                ShowImagesWhenDebugMode(mat);
            }
        }

        [Fact]
        public void WriteMultiPagesTiff()
        {
            string[] files = {
                "multipage_p1.tif",
                "multipage_p2.tif",
            };

            Mat[]? pages = null;
            Mat[]? readPages = null;
            try
            {
                pages = files.Select(f => Image(f)).ToArray();

                Assert.True(Cv2.ImWrite("multi.tiff", pages), "imwrite failed");
                Assert.True(Cv2.ImReadMulti("multi.tiff", out readPages), "imreadmulti failed");
                Assert.NotEmpty(readPages);
                Assert.Equal(pages.Length, readPages.Length);

                for (int i = 0; i < pages.Length; i++)
                {
                    ImageEquals(pages[i], readPages[i]);
                }

            }
            finally
            {
                if (pages != null)
                    foreach (var page in pages)
                        page.Dispose();
                if (readPages != null)
                    foreach (var page in readPages)
                        page.Dispose();
            }
        }

        private static void CreateDummyImageFile(string path)
        {
            Path.GetFullPath(path);

            var tempFileName = Path.GetTempFileName();
            {
                using var bitmap = new Bitmap(10, 10, PixelFormat.Format24bppRgb);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.Red);
                // GDI+ does not support Unicode file name
                bitmap.Save(tempFileName, ImageFormat.Png);
            }

#if NET48
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Move(tempFileName, path);
#else
            File.Move(tempFileName, path, true);
#endif
            Assert.True(File.Exists(path), $"File '{path}' not found");
        }
    }
}