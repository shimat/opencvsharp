#nullable enable
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.ImgCodecs
{
    public class ImgCodecsTest : TestBase
    {
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

        [Fact]
        public void ImReadUnicodeFileName()
        {
            // https://github.com/opencv/opencv/issues/4242

            const string fileName = "_data/image/imread♥♡😀😄.png";
            const string fileNameTemp = "_data/image/imread_test_image.png";

            // Check whether the path is valid
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Path.GetFullPath(fileName);

            {
                using var bitmap = new Bitmap(10, 10, PixelFormat.Format24bppRgb);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.Red);
                bitmap.Save(fileNameTemp, ImageFormat.Png);
            }

#if NET48
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.Move(fileNameTemp, fileName);
#else
            File.Move(fileNameTemp, fileName, true);
#endif
            Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

            using var image = Cv2.ImRead(fileName, ImreadModes.Color);
            Assert.NotNull(image);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Assert.True(image.Empty()); // TODO
            else 
                Assert.False(image.Empty());
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

            using (var bitmap = new Bitmap(fileName))
            {
                Assert.Equal(10, bitmap.Height);
                Assert.Equal(20, bitmap.Width);
            }
        }
        
        //[Fact(Skip = "no output")]
        [Fact]
        public void ImWriteUnicodeFileName()
        {
            // https://github.com/opencv/opencv/issues/4242

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return; // TODO 

            const string fileName = "_data/image/imwrite♥♡😀😄.png";
            
            // Check whether the path is valid
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Path.GetFullPath(fileName);

            using (var mat = new Mat(10, 20, MatType.CV_8UC3, Scalar.Blue))
            {
                Cv2.ImWrite(fileName, mat);
            }

            // TODO fail
            Assert.True(File.Exists(fileName), $"File '{fileName}' not found");

            const string asciiFileName = "_data/image/imwrite_unicode_test.png";
            File.Move(fileName, asciiFileName);
            using (var bitmap = new Bitmap(asciiFileName))
            {
                Assert.Equal(10, bitmap.Height);
                Assert.Equal(20, bitmap.Width);
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

            using var bitmap = new Bitmap("_data/image/lenna.png");
            using var stream = new MemoryStream();
            bitmap.Save(stream, imageFormat);
            var imageData = stream.ToArray();
            Assert.NotNull(imageData);

            using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
            Assert.NotNull(mat);
            Assert.False(mat.Empty());
            Assert.Equal(bitmap.Width, mat.Cols);
            Assert.Equal(bitmap.Height, mat.Rows);
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
    }
}