using OpenCvSharp.Detail;
using OpenCvSharp.Features2D;
using Xunit;

namespace OpenCvSharp.Tests.Stitching
{
    public class CvDetailTest: TestBase
    {
        [Fact]
        public void ComputeImageFeatures()
        {
            using var featuresFinder = SIFT.Create();
            using var image = Image("abbey_road.jpg", ImreadModes.Grayscale);

            CvDetail.ComputeImageFeatures(featuresFinder, image, out var features);
            using (features)
            {
                Assert.NotNull(features);
                Assert.NotEqual(0, features.ImgIdx);
                Assert.Equal(image.Size(), features.ImgSize);
                Assert.NotEmpty(features.Keypoints);
                Assert.NotNull(features.Descriptors);
                Assert.False(features.Descriptors.Empty());
            }
        }
    }
}
