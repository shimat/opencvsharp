using OpenCvSharp.Quality;
using Xunit;

namespace OpenCvSharp.Tests.Quality
{
    public class QualityBRISQUETest : TestBase
    {
        // https://github.com/opencv/opencv_contrib/blob/master/modules/quality/samples/brisque_model_live.yml
        // https://github.com/opencv/opencv_contrib/blob/master/modules/quality/samples/brisque_range_live.yml
        private const string ModelFile = "_data/text/brisque_model_live.yml";
        private const string RangeFile = "_data/text/brisque_range_live.yml";

        [Fact]
        public void Compute()
        {
            using (var refImage = Image("lenna.png"))
            using (var targetImage = new Mat())
            using (var psnr = QualityBRISQUE.Create(ModelFile, RangeFile))
            {
                Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);
                
                var value = psnr.Compute(refImage);
                Assert.Equal(-4.974979, value[0], 2);
                Assert.Equal(0, value[1], 2);
                Assert.Equal(0, value[2], 2);

                value = psnr.Compute(targetImage);
                Assert.Equal(57.4, value[0], 1);
                Assert.Equal(0, value[1], 2);
                Assert.Equal(0, value[2], 2);
            }
        }

        [Fact]
        public void StaticCompute()
        {
            using (var refImage = Image("lenna.png"))
            using (var targetImage = new Mat())
            {
                Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

                var value = QualityBRISQUE.Compute(refImage, ModelFile, RangeFile);
                Assert.Equal(-4.974979, value[0], 2);
                Assert.Equal(0, value[1], 2);
                Assert.Equal(0, value[2], 2);

                value = QualityBRISQUE.Compute(targetImage, ModelFile, RangeFile);
                Assert.Equal(57.4, value[0], 1);
                Assert.Equal(0, value[1], 2);
                Assert.Equal(0, value[2], 2);
            }
        }
    }
}