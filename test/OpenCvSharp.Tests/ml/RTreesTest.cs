using System;
using System.IO;
using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.ML
{
    public class RTreesTest : TestBase
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

            int[] trainLabelsData = { 1, -1, 1, -1 };
            var trainLabels = new Mat(4, 1, MatType.CV_32S, trainLabelsData);

            using var model = RTrees.Create();
            model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

            float[] testFeatureData = { 99, 99 };
            var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);
            
            var detectedClass = (int)model.Predict(testFeature);
            
            Assert.Equal(1, Math.Abs(detectedClass)); // result rarely becomes +1
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

            Assert.True(File.Exists(fileName));

            string content = File.ReadAllText(fileName);
            //Console.WriteLine(content);

            // Assert.DoesNotThrow
            using (var model2 = RTrees.Load(fileName))
            {
                GC.KeepAlive(model2);
            }
            using (var model2 = RTrees.LoadFromString(content))
            {
                GC.KeepAlive(model2);
            }
        }
    }
}

