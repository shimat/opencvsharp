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
            var descriptorMatcher = new BFMatcher();
            new BOWImgDescriptorExtractor(descriptorMatcher);
        }

        [Test]
        public void New2()
        {
            var descriptorExtractor = SURF.Create(100);
            var descriptorMatcher = new BFMatcher();
            new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher);
        }

        [Test]
        public void New3()
        {
            var descriptorExtractor = KAZE.Create();
            var descriptorMatcher = new BFMatcher();
            new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher);
        }

        [Test]
        public void New4()
        {
            var descriptorExtractor = SURF.Create(100);
            LinearIndexParams ip = new LinearIndexParams();
            SearchParams sp = new SearchParams();
            var descriptorMatcher = new FlannBasedMatcher(ip, sp);
            new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher);
        }

        [Test]
        public void New5()
        {
            var descriptorExtractor = KAZE.Create();
            LinearIndexParams ip = new LinearIndexParams();
            SearchParams sp = new SearchParams();
            var descriptorMatcher = new FlannBasedMatcher(ip, sp);
            new BOWImgDescriptorExtractor(descriptorExtractor, descriptorMatcher);
        }
    }
}

