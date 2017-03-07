using System;
using System.Collections.Generic;
using System.IO;
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

            using (var model = SVM.Create())
            {
                model.Type = SVM.Types.CSvc;
                model.KernelType = SVM.KernelTypes.Linear;
                model.TermCriteria = new TermCriteria(CriteriaType.MaxIter, 100, 1e-6);
                model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);

                float[] testFeatureData = {90, 90};
                var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);

                var detectedClass = (int) model.Predict(testFeature);

                Assert.AreEqual(-1, detectedClass);
            }
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

            int[] trainLabelsData = { +1, -1, +1, -1 };
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

            FileAssert.Exists(fileName);

            string content = File.ReadAllText(fileName);
            //Console.WriteLine(content);

            Assert.DoesNotThrow(() =>
            {
                using (var model2 = SVM.Load(fileName)) { }
            });
            Assert.DoesNotThrow(() =>
            {
                using (var model2 = SVM.LoadFromString(content)) { }
            });
            
            Assert.DoesNotThrow(() =>
            {
                using (var fs = new FileStorage(fileName, FileStorage.Mode.Read))
                using (var model2 = SVM.Create())
                {
                    var node = fs["opencv_ml_svm"];
                    model2.Read(node);
                }
            });
        }
    }
}
