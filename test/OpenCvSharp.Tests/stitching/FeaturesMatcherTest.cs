using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class FeaturesMatcherTest : TestBase
{
    [Fact]
    public void BestOf2NearestRangeMatcherApply()
    {
        using var source = LoadImage("lenna.png", ImreadModes.Grayscale);
        var images = new[]
        {
            source[new Rect(0, 0, 200, 200)].Clone(),
            source[new Rect(100, 100, 200, 200)].Clone(),
            source[new Rect(200, 0, 200, 200)].Clone(),
        };
        try
        {
            using var orb = ORB.Create(500);
            var features = Cv2.Detail.ComputeImageFeatures(orb, images);
            try
            {
                using var matcher = new BestOf2NearestRangeMatcher(rangeWidth: 1);
                var matches = matcher.Apply(features);
                Assert.Equal(images.Length * images.Length, matches.Length);
                foreach (var m in matches)
                    m.Dispose();
            }
            finally
            {
                foreach (var f in features)
                    f.Dispose();
            }
        }
        finally
        {
            foreach (var image in images)
                image.Dispose();
        }
    }

    [Fact]
    public void ApplyMultipleImageFeatures()
    {
        using var source = LoadImage("lenna.png", ImreadModes.Grayscale);
        var images = new[]
        {
            source[new Rect(0, 0, 200, 200)].Clone(),
            source[new Rect(100, 100, 200, 200)].Clone(),
            source[new Rect(200, 0, 200, 200)].Clone(),
        };
        try
        {
            using var orb = ORB.Create(500);
            var features = Cv2.Detail.ComputeImageFeatures(orb, images);
            try
            {
                using var matcher = new BestOf2NearestMatcher();
                var matches = matcher.Apply(features);

                // Regression test: featuresVec used to be pre-sized *and* push_back'd, doubling
                // its length with leading empty ImageFeatures entries in front of the real ones.
                // That made the matcher build a pairwise-matches matrix for 2*images.Length images
                // instead of images.Length (self-pairs are left as -1/-1 sentinels by OpenCV, so
                // the result is the full square matrix, not just off-diagonal pairs).
                Assert.Equal(images.Length * images.Length, matches.Length);
                foreach (var m in matches)
                {
                    Assert.InRange(m.SrcImgIdx, -1, images.Length - 1);
                    Assert.InRange(m.DstImgIdx, -1, images.Length - 1);
                }

                foreach (var m in matches)
                    m.Dispose();
            }
            finally
            {
                foreach (var f in features)
                    f.Dispose();
            }
        }
        finally
        {
            foreach (var image in images)
                image.Dispose();
        }
    }
}
