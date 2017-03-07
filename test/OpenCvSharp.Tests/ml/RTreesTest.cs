using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OpenCvSharp;
using OpenCvSharp.ML;

namespace OpenCvSharp.Tests.ML
{
    [TestFixture]
    public class RTreesTest : TestBase
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

            int[] trainLabelsData = { 1, -1, 1, -1 };
            var trainLabels = new Mat(4, 1, MatType.CV_32S, trainLabelsData);

            var model = RTrees.Create();
            model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

            float[] testFeatureData = { 90, 90 };
            var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);
            
            var detectedClass = (int)model.Predict(testFeature);
            
            Assert.AreEqual(-1, detectedClass);
        }

        [Test]
        public void SaveLoadTest()
        {
            float[,] trainFeaturesData =
            {
                 {0, 0},
                 {0, 100},
                 {100, 0},
                 {100, 100},
            };
            var trainFeatures = new Mat(4, 2, MatType.CV_32F, trainFeaturesData);

            int[] trainLabelsData = { 1, -1, 1, -1 };
            var trainLabels = new Mat(4, 1, MatType.CV_32S, trainLabelsData);

            const string fileName = "rtrees.yml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var model = RTrees.Create())
            {
                model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

                model.Save(fileName);
            }

            FileAssert.Exists(fileName);

            string content = File.ReadAllText(fileName);
            //Console.WriteLine(content);

            Assert.DoesNotThrow(() =>
            {
                using (var model2 = RTrees.Load(fileName)) { }
            });
            Assert.DoesNotThrow(() =>
            {
                using (var model2 = RTrees.LoadFromString(content)) { }
            });
        }
    }
}

