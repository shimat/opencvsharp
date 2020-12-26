using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching
{
    public class CvDetailTest: TestBase
    {
        [ExplicitFact] // TODO mac test fails
        public void ComputeImageFeatures()
        {
            using var featuresFinder = AKAZE.Create();
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
