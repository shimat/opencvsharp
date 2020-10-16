using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text
{
    public class DetectTextSWTTest : TestBase
    {
        [Fact]
        public void Test()
        {
            using var src = new Mat("_data/image/imageText.png");
            using var draw = new Mat();

            var rects = CvText.DetectTextSWT(src, true, draw);
            Assert.NotEmpty(rects);

            ShowImagesWhenDebugMode(src, draw);
        }
    }
}
