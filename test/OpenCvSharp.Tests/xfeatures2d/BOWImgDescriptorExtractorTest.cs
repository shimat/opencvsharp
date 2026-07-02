using System.Globalization;
using OpenCvSharp.Flann;
using OpenCvSharp.XFeatures2D;
using Xunit;

// ReSharper disable RedundantArgumentDefaultValue

namespace OpenCvSharp.Tests.XFeatures2D;

public class BOWImgDescriptorExtractorTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public BOWImgDescriptorExtractorTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void New1()
    {
        using (var descriptorMatcher = new BFMatcher())
        using (new BOWImgDescriptorExtractor(descriptorMatcher)) { }
    }

    [Fact]
    public void New2BF()
    {
        using (var descriptorExtractor = SURF.Create(100))
        using (var descriptorMatcher = new BFMatcher())
        {
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
        }
    }

    [Fact]
    public void New2Flann()
    {
        using (var descriptorExtractor = SURF.Create(100))
        using (var descriptorMatcher = new FlannBasedMatcher())
        {
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
        }
    }

    [Fact]
    public void New3()
    {
        using (var descriptorExtractor = KAZE.Create())
        using (var descriptorMatcher = new BFMatcher())
        using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
    }

    [Fact]
    public void New4()
    {
        using (var ip = new LinearIndexParams())
        using (var sp = new SearchParams())
        using (var descriptorExtractor = SURF.Create(100))
        using (var descriptorMatcher = new FlannBasedMatcher(ip, sp)) 
        using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
    }

    [Fact]
    public void New5()
    {
        using var ip = new LinearIndexParams();
        using var sp = new SearchParams();
        using (var descriptorExtractor = KAZE.Create())
        using (var descriptorMatcher = new FlannBasedMatcher(ip, sp))
        using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
    }

    [Fact]
    public void RunTest()
    {
        using var descriptorExtractor = SIFT.Create(500);
        using var descriptorMatcher = new BFMatcher();
        using var img = LoadImage("lenna.png");
        KeyPoint[] keypoints;
        Mat dictionary;
        var tc = new TermCriteria(CriteriaTypes.MaxIter, 100, 0.001d);
        using (var bowTrainer = new BOWKMeansTrainer(200, tc, 1, KMeansFlags.PpCenters))
        {
            var descriptors = new Mat();
            descriptorExtractor.DetectAndCompute(img, null, out keypoints, descriptors);

            using var featuresUnclustered = new Mat();
            featuresUnclustered.PushBack(descriptors);
            featuresUnclustered.ConvertTo(featuresUnclustered, MatType.CV_32F);
            dictionary = bowTrainer.Cluster(featuresUnclustered);
        }

        using (var bowDe = new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher))
        {
            bowDe.SetVocabulary(dictionary);

            try
            {
                using var rawDescriptors = new Mat();
                descriptorExtractor.Compute(img, ref keypoints, rawDescriptors);
                rawDescriptors.ConvertTo(rawDescriptors, MatType.CV_32F);

                using var imgDescriptor1 = new Mat();
                bowDe.Compute(img, ref keypoints, imgDescriptor1, out var arr);
                testOutputHelper.WriteLine(arr.Length.ToString(CultureInfo.InvariantCulture));
                testOutputHelper.WriteLine(arr[0].Length.ToString(CultureInfo.InvariantCulture));

                // Compute(InputArray keypointDescriptors, ...) overload: matches raw
                // descriptors against the vocabulary directly, without a source image.
                // Must use the raw (128-dim) descriptors here, not imgDescriptor1
                // (the 200-dim BOW histogram), since the vocabulary column count must match.
                using var imgDescriptor2 = new Mat();
                bowDe.Compute(rawDescriptors, imgDescriptor2, out var arr2);
                Assert.False(imgDescriptor2.Empty());
                Assert.NotEmpty(arr2);
            }
            catch (OpenCVException ex)
            {
                testOutputHelper.WriteLine(ex.FileName);
                testOutputHelper.WriteLine(ex.FuncName);
                testOutputHelper.WriteLine(ex.Line.ToString(CultureInfo.InvariantCulture));
                throw;
            }
        }

        dictionary.Dispose();
    }
}
