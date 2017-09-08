using System;
using System.Collections.Generic;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.ML
{
    // ReSharper disable once InconsistentNaming
    public class SVMTest : TestBase
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

            using (var model = SVM.Create())
            {
                model.Type = SVM.Types.CSvc;
                model.KernelType = SVM.KernelTypes.Linear;
                model.TermCriteria = new TermCriteria(CriteriaType.MaxIter, 100, 1e-6);
                model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

                float[] testFeatureData = {90, 90};
                var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);

                var detectedClass = (int) model.Predict(testFeature);

                Assert.Equal(-1, detectedClass);
            }
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

            int[] trainLabelsData = {+1, -1, +1, -1};
            var trainLabels = new Mat(4, 1, MatType.CV_32S, trainLabelsData);

            const string fileName = "svm.yml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var model = SVM.Create())
            {
                model.Type = SVM.Types.CSvc;
                model.KernelType = SVM.KernelTypes.Linear;
                model.TermCriteria = new TermCriteria(CriteriaType.MaxIter, 100, 1e-6);
                model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

                model.Save(fileName);
            }

            Assert.True(File.Exists(fileName));

            string content = File.ReadAllText(fileName);
            //Console.WriteLine(content);

            //Assert.DoesNotThrow
            using (var model2 = SVM.Load(fileName))
            {
            }
            using (var model2 = SVM.LoadFromString(content))
            {
            }

            using (var fs = new FileStorage(fileName, FileStorage.Mode.Read))
            using (var model2 = SVM.Create())
            {
                var node = fs["opencv_ml_svm"];
                model2.Read(node);
            }
        }
    }
}
