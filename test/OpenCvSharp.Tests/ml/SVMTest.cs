using System;
using System.IO;
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
                model.TermCriteria = new TermCriteria(CriteriaTypes.MaxIter, 100, 1e-6);
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
                model.TermCriteria = new TermCriteria(CriteriaTypes.MaxIter, 100, 1e-6);
                model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

                model.Save(fileName);
            }

            Assert.True(File.Exists(fileName));

            string content = File.ReadAllText(fileName);

            //Assert.DoesNotThrow
            using (var model2 = SVM.Load(fileName))
            {
                GC.KeepAlive(model2);
            }
            using (var model2 = SVM.LoadFromString(content))
            {
                GC.KeepAlive(model2);
            }

            using (var fs = new FileStorage(fileName, FileStorage.Modes.Read))
            using (var model2 = SVM.Create())
            {
                var node = fs["opencv_ml_svm"];
                Assert.NotNull(node);
#pragma warning disable CS8604 
                model2.Read(node);
#pragma warning restore CS8604 
            }
        }
    }
}
