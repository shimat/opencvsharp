using Xunit;

namespace OpenCvSharp.Tests.ImgProc
{
    public class ImgCodecsTest : TestBase
    {
        [Theory]
        [InlineData("building.jpg")]
        [InlineData("lenna.png")]
        [InlineData("building_mask.bmp")]
        public void ImRead(string fileName)
        {
            using (var image = Image(fileName, ImreadModes.GrayScale))
            {
                Assert.False(image.Empty());
            }
        }
    }
}