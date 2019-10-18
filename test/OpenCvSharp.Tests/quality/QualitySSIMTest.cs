using OpenCvSharp.Quality;
using Xunit;

namespace OpenCvSharp.Tests.Quality
{
    public class QualitySSIMTest : TestBase
    {
        [Fact]
        public void Compute()
        {
            using (var refImage = Image("lenna.png"))
            using (var targetImage = new Mat())
            using (var psnr = QualitySSIM.Create(refImage))
            {
                Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

                var value = psnr.Compute(targetImage);
                Assert.Equal(0.718649, value[0], 3);
                Assert.Equal(0.791417, value[1], 3);
                Assert.Equal(0.861893, value[2], 3);
            }
        }

        [Fact]
        public void StaticCompute()
        {
            using (var refImage = Image("lenna.png"))
            using (var targetImage = new Mat())
            {
                Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

                var value = QualitySSIM.Compute(refImage, targetImage, null);
                Assert.Equal(0.718649, value[0], 3);
                Assert.Equal(0.791417, value[1], 3);
                Assert.Equal(0.861893, value[2], 3);
            }
        }
    }
}