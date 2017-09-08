using System;
using System.Collections.Generic;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.ML
{
    public class BoostTest : TestBase
    {
        [Fact]
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
            
            Assert.Equal(-1, detectedClass);
        }

        [Fact]
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

            int[] trainLabelsData = { +1, -1, +1, -1 };
            var trainLabels = new Mat(4, 1, MatType.CV_32S, trainLabelsData);

            const string fileName = "boost.yml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var model = Boost.Create())
            {
                model.MaxDepth = 1;
                model.UseSurrogates = false;
                model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

                model.Save(fileName);
            }

            Assert.True(File.Exists(fileName));

            string content = File.ReadAllText(fileName);
            //Console.WriteLine(content);

            // does not throw
            using (var model2 = Boost.Load(fileName)) { }
            using (var model2 = Boost.LoadFromString(content)) { }
        }
    }
}

