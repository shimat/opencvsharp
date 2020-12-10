using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.dnn
{
    public class TensorflowTest : TestBase
    {
        [Fact]
        public void LoadMnistTrainingDataFromFile_NetRecognizesAnImageOfA9Correctly()
        {
            var img_of_9 = Image(Path.Combine("Dnn","MNIST_9.png"), ImreadModes.Grayscale);
            
            var img9DataBlob = CvDnn.BlobFromImage(img_of_9, 1f / 255.0f);
            var modelPath = Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");
            var res = -1;

            using (var tfGraph = CvDnn.ReadNetFromTensorflow(modelPath))
            {
                tfGraph.SetInput(img9DataBlob);
               
                using (var prob = tfGraph.Forward())
                    res = GetResultClass(prob);
            }

            Assert.True(res == 9);
        }

        [Fact]
        public void LoadMnistTrainingDataFromStream_NetRecognizesAnImageOfA5Correctly()
        {
            var img_of_5 = Image(Path.Combine("Dnn", "MNIST_5.png"), ImreadModes.Grayscale);

            var img5DataBlob = CvDnn.BlobFromImage(img_of_5, 1f / 255.0f);
            var modelPath = Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");
            var res = -1;

            using (var stream = new FileStream(modelPath, FileMode.Open))
            {
                using (var tfGraph = CvDnn.ReadNetFromTensorflow(stream))
                {
                    tfGraph.SetInput(img5DataBlob);

                    using (var prob = tfGraph.Forward())
                        res = GetResultClass(prob);
                }
            }

            Assert.True(res == 5);
        }

        private static int GetResultClass(Mat prob)
        {
            var dims = prob.Dims;
            var imgCnt = prob.Size(0);
            var channels = prob.Size(1);
            Mat strip = prob.Reshape(1, channels);

            var minIdx = new[] {-1};
            var maxIdx = new[] { -1 };
            strip.MinMaxIdx(minIdx,maxIdx); 

            return maxIdx[0];
        }
    }
}
