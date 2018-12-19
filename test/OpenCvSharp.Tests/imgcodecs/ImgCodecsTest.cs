using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OpenCvSharp.Tests.ImgCodecs
{
    public class ImgCodecsTest : TestBase
    {
        [Theory]
        [InlineData("building.jpg")]
        [InlineData("lenna.png")]
        [InlineData("building_mask.bmp")]
        public void ImRead(string fileName)
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
        public void WriteMultiPagesTiff()
        {
            string[] files = {
                "multipage_p1.tif",
                "multipage_p2.tif",
            };

            Mat[] pages = null;
            Mat[] readPages = null;
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