using System;
using OpenCvSharp.ML;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.ML
{
    public class ANN_MLPTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        public ANN_MLPTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

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
            using var trainFeatures = new Mat(4, 2, MatType.CV_32F, trainFeaturesData);

            float[] trainLabelsData = { 1, 0, 1, 0 };
            using var trainLabels = new Mat(4, 1, MatType.CV_32F, trainLabelsData);

            using var model = ANN_MLP.Create();
            model.SetActivationFunction(ANN_MLP.ActivationFunctions.SigmoidSym, 0.1, 0.1);
            model.SetTrainMethod(ANN_MLP.TrainingMethods.BackProp, 0.1, 0.1);
            //model.TermCriteria = new TermCriteria(CriteriaType.MaxIter | CriteriaType.Eps, 10000, 0.0001);

            using var layerSize = new Mat(3, 1, MatType.CV_32SC1);
            layerSize.Set<int>(0, 2);
            layerSize.Set<int>(1, 10);
            layerSize.Set<int>(2, 1);
            model.SetLayerSizes(layerSize);

            bool trainSuccess = model.Train(trainFeatures, SampleTypes.RowSample, trainLabels);
            Assert.True(trainSuccess);
            Assert.True(model.IsTrained());

            float[] testFeatureData = { 0, 0 };
            using var testFeature = new Mat(1, 2, MatType.CV_32F, testFeatureData);

            using var result = new Mat();
            var detectedClass = model.Predict(testFeature, result);

            // TODO
            //Assert.Equal(-1, detectedClass);
        }
    }
}

