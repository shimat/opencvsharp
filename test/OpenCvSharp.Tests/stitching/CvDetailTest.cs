using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching
{
    public class CvDetailTest: TestBase
    {
        //[Fact] // TODO mac test fails
        [PlatformSpecificFact("Windows", "Linux")]
        public void ComputeImageFeaturesTest()
        {
            using var featuresFinder = AKAZE.Create();
            using var image = Image("abbey_road.jpg", ImreadModes.Grayscale);

            using var features = CvDetail.ComputeImageFeatures(featuresFinder, image);
            Assert.NotNull(features);
            Assert.NotEqual(0, features.ImgIdx);
            Assert.Equal(image.Size(), features.ImgSize);
            Assert.NotEmpty(features.Keypoints);
            Assert.NotNull(features.Descriptors);
            Assert.False(features.Descriptors.Empty());
        }

        [Fact]
        public void BestOf2NearestMatcherTest()
        {
            using var featuresFinder = AKAZE.Create();
            using var image1 = Image("tsukuba_left.png", ImreadModes.Grayscale);
            using var image2 = Image("tsukuba_right.png", ImreadModes.Grayscale);

            using var features1 = CvDetail.ComputeImageFeatures(featuresFinder, image1);
            using var features2 = CvDetail.ComputeImageFeatures(featuresFinder, image2);

            using var matcher = new BestOf2NearestMatcher();
            using var matchesInfo = matcher.Apply(features1, features2);
            Assert.NotEmpty(matchesInfo.Matches);
            Assert.NotEmpty(matchesInfo.InliersMask);
            Assert.False(matchesInfo.H.Empty());
            Assert.True(matchesInfo.Confidence > 0);
        }

        [Fact]
        public void AffineBestOf2NearestMatcherTest()
        {
            using var featuresFinder = AKAZE.Create();
            using var image1 = Image("tsukuba_left.png", ImreadModes.Grayscale);
            using var image2 = Image("tsukuba_right.png", ImreadModes.Grayscale);

            using var features1 = CvDetail.ComputeImageFeatures(featuresFinder, image1);
            using var features2 = CvDetail.ComputeImageFeatures(featuresFinder, image2);

            using var matcher = new AffineBestOf2NearestMatcher();
            using var matchesInfo = matcher.Apply(features1, features2);
            Assert.NotEmpty(matchesInfo.Matches);
            Assert.NotEmpty(matchesInfo.InliersMask);
            Assert.False(matchesInfo.H.Empty());
            Assert.True(matchesInfo.Confidence > 0);
        }
    }
}
