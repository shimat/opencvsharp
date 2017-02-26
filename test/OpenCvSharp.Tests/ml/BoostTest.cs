using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp;
using OpenCvSharp.ML;

namespace OpenCvSharp.Tests.ML
{
    [TestFixture]
    public class BoostTest : TestBase
    {
        [Test]
        public void RunTest()
        {
            float[,] trainFeaturesData =
            {
                 {0, 0},
                 {0, 100},
                 {100, 0},
                 {100, 100},
            };
            var trainFeatures = new Mat(4, 2, MatType.CV_32F, trainFeaturesData);

            int[] trainLabelsData = { +1, -1, +1, -1 };
            var trainLabels = new Mat(4, 1, MatType.CV_32S, trainLabelsData);

            var model = Boost.Create();
            model.MaxDepth = 1;
            model.UseSurrogates = false;
            model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

            float[] testFeatureData = { 90, 90 };
            var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);
            
            var detectedClass = (int)model.Predict(testFeature);
            
            Assert.AreEqual(-1, detectedClass);
        }
    }
}

