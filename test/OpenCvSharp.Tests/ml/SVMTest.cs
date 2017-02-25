using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp;
using OpenCvSharp.ML;

namespace OpenCvSharp.Tests.ML
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class SVMTest : TestBase
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

            var model = SVM.Create();
            model.Type = SVM.Types.CSvc;
            model.KernelType = SVM.KernelTypes.Linear;
            model.TermCriteria = new TermCriteria(CriteriaType.MaxIter, 100, 1e-6);
            model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

            float[] testFeatureData = { 90, 90 };
            var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);
            
            var detectedClass = model.Predict(testFeature);
            
            Assert.AreEqual(-1, detectedClass);
        }
    }
}

