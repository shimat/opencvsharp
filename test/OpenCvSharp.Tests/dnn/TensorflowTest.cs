using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenCvSharp.Dnn;
using Xunit;

#pragma warning disable CA1707

namespace OpenCvSharp.Tests.Dnn;

public class TensorflowTest : TestBase
{
    [PlatformSpecificFact("Windows", "Linux")]
    // ReSharper disable once IdentifierTypo
    public void LoadMnistTrainingDataFromFile_NetRecognizesAnImageOfA9Correctly()
    {
        using var imgOf9 = Image(Path.Combine("Dnn","MNIST_9.png"), ImreadModes.Grayscale);
            
        var img9DataBlob = CvDnn.BlobFromImage(imgOf9, 1f / 255.0f);
        var modelPath = Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");
        var res = -1;

        using (var tfGraph = CvDnn.ReadNetFromTensorflow(modelPath))
        {
            Assert.NotNull(tfGraph);
            tfGraph!.SetInput(img9DataBlob);
               
            using (var prob = tfGraph.Forward())
                res = GetResultClass(prob);
        }

        Assert.Equal(9, res);
    }
    
    [PlatformSpecificFact("Windows", "Linux")]
    // ReSharper disable once IdentifierTypo
    public void LoadMnistTrainingDataFromStream_NetRecognizesAnImageOfA5Correctly()
    {
        using var imgOf5 = Image(Path.Combine("Dnn", "MNIST_5.png"), ImreadModes.Grayscale);

        var img5DataBlob = CvDnn.BlobFromImage(imgOf5, 1f / 255.0f);
        var modelPath = Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");
        var res = -1;

        using (var stream = new FileStream(modelPath, FileMode.Open))
        {
            using (var tfGraph = CvDnn.ReadNetFromTensorflow(stream))
            {
                Assert.NotNull(tfGraph);
                tfGraph!.SetInput(img5DataBlob);

                using (var prob = tfGraph.Forward())
                    res = GetResultClass(prob);
            }
        }

        Assert.Equal(5, res);
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
