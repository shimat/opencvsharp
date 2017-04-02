using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp.Flann;
using OpenCvSharp.XFeatures2D;

namespace OpenCvSharp.Tests.Features2d
{
    [TestFixture]
    //[Ignore("")]
    public class BOWImgDescriptorExtractorTest : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [Test]
        public void New1()
        {
            using (var descriptorMatcher = new BFMatcher())
            using (new BOWImgDescriptorExtractor(descriptorMatcher)) { }
        }

        [Test]
        public void New2BF()
        {
            using (var descriptorExtractor = SURF.Create(100))
            using (var descriptorMatcher = new BFMatcher())
            {
                using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
                using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
            }
        }

        [Test]
        public void New2Flann()
        {
            using (var descriptorExtractor = SURF.Create(100))
            using (var descriptorMatcher = new FlannBasedMatcher())
            {
                using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
                using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
            }
        }

        [Test]
        public void New3()
        {
            using (var descriptorExtractor = KAZE.Create())
            using (var descriptorMatcher = new BFMatcher())
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
        }

        [Test]
        public void New4()
        {
            using (LinearIndexParams ip = new LinearIndexParams())
            using (SearchParams sp = new SearchParams())
            using (var descriptorExtractor = SURF.Create(100))
            using (var descriptorMatcher = new FlannBasedMatcher(ip, sp)) { }
            //using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }

            //GC.KeepAlive(ip);
            //GC.KeepAlive(sp);
        }

        [Test]
        [Ignore("")]
        public void New5()
        {
            LinearIndexParams ip = new LinearIndexParams();
            SearchParams sp = new SearchParams();
            using (var descriptorExtractor = KAZE.Create())
            using (var descriptorMatcher = new FlannBasedMatcher(ip, sp))
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
        }

        [Test]
        [Ignore("")]
        public void RunTest()
        {
            LinearIndexParams ip = new LinearIndexParams();
            SearchParams sp = new SearchParams();
            using (var descriptorExtractor = SIFT.Create(500))
            //using (var descriptorMatcher = new FlannBasedMatcher(ip, sp))
            using (var descriptorMatcher = new BFMatcher())
            using (var img = Image("lenna.png"))
            {
                KeyPoint[] keypoints;
                Mat dictionary;
                var tc = new TermCriteria(CriteriaType.MaxIter, 100, 0.001d);
                using (var bowTrainer = new BOWKMeansTrainer(200, tc, 1, KMeansFlags.PpCenters))
                {
                    var descriptors = new Mat();
                    descriptorExtractor.DetectAndCompute(img, null, out keypoints, descriptors);

                    Mat featuresUnclustered = new Mat();
                    featuresUnclustered.PushBack(descriptors);
                    featuresUnclustered.ConvertTo(featuresUnclustered, MatType.CV_32F);
                    dictionary = bowTrainer.Cluster(featuresUnclustered);
                }

                using (var bowDE = new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher))
                {
                    bowDE.SetVocabulary(dictionary);

                    try
                    {
                        int[][] arr;
                        Mat descriptors = new Mat();
                        descriptorExtractor.Compute(img, ref keypoints, descriptors);
                        descriptors.ConvertTo(descriptors, MatType.CV_32F);
                        bowDE.Compute(descriptors, ref keypoints, descriptors, out arr);
                        Console.WriteLine(arr.Length);
                        Console.WriteLine(arr[0].Length);
                    }
                    catch (OpenCVException ex)
                    {
                        Console.WriteLine(ex.FileName);
                        Console.WriteLine(ex.FuncName);
                        Console.WriteLine(ex.Line);
                        throw;
                    }
                }
            }
        }
    }
}

