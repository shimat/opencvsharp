using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp.Flann;
using OpenCvSharp.XFeatures2D;

namespace OpenCvSharp.Tests.Features2D
{
    [TestFixture]
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
        public void New2()
        {
            using (var descriptorExtractor = SURF.Create(100))
            using (var descriptorMatcher = new BFMatcher())
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
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
            LinearIndexParams ip = new LinearIndexParams();
            SearchParams sp = new SearchParams();
            using (var descriptorExtractor = SURF.Create(100))
            using (var descriptorMatcher = new FlannBasedMatcher(ip, sp))
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
        }

        [Test]
        public void New5()
        {
            LinearIndexParams ip = new LinearIndexParams();
            SearchParams sp = new SearchParams();
            using (var descriptorExtractor = KAZE.Create())
            using (var descriptorMatcher = new FlannBasedMatcher(ip, sp))
            using (new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher)) { }
        }
    }
}

