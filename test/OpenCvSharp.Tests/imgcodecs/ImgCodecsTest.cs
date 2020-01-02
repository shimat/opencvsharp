#nullable enable
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public void GifNotSupportedByImRead()
        {
            using var image = Cv2.ImRead("_data/image/empty.gif", ImreadModes.Grayscale);
            Assert.NotNull(image);
            Assert.True(image.Empty());
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
            using var bitmap = new System.Drawing.Bitmap(stream);
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

            using var bitmap = new System.Drawing.Bitmap("_data/image/lenna.png");
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