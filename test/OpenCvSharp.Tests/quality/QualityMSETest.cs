using OpenCvSharp.Quality;
using Xunit;

namespace OpenCvSharp.Tests.Quality
{
    public class QualityMSETest : TestBase
    {
        [Fact]
        public void Compute()
        {
            using (var refImage = Image("lenna.png"))
            using (var targetImage = new Mat())
            using (var psnr = QualityMSE.Create(refImage))
            {
                Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

                var value = psnr.Compute(targetImage);
                Assert.Equal(85.455929, value[0], 6);
                Assert.Equal(99.077258, value[1], 6);
                Assert.Equal(53.734322, value[2], 6);
            }
        }

        [Fact]
        public void StaticCompute()
        {
            using (var refImage = Image("lenna.png"))
            using (var targetImage = new Mat())
            {
                Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

                var value = QualityMSE.Compute(refImage, targetImage, null);
                Assert.Equal(85.455929, value[0], 6);
                Assert.Equal(99.077258, value[1], 6);
                Assert.Equal(53.734322, value[2], 6);
            }
        }
    }
}