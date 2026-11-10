using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

#pragma warning disable CA1707

namespace OpenCvSharp.Tests.Dnn;

public class OnnxTest : TestBase
{
    // Platform check for conditional test execution
    public static bool IsWindowsOrLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    // ReSharper disable once IdentifierTypo
    public void LoadMnistTrainingDataFromFile_NetRecognizesAnImageOfA9Correctly()
    {
        using var imgOf9 = LoadImage(Path.Combine("Dnn", "MNIST_9.png"), ImreadModes.Grayscale);
            
        using var img9DataBlob = Cv2.Dnn.BlobFromImage(imgOf9, 1.0 / 255.0, new Size(28, 28));
        var modelPath = Path.Combine("_data", "model", "mnist-8.onnx");
        var res = -1;

        using (var net = Cv2.Dnn.ReadNetFromONNX(modelPath))
        {
            Assert.NotNull(net);
            net!.SetInput(img9DataBlob);
               
            using (var prob = net.Forward())
                res = GetResultClass(prob);
        }

        Assert.Equal(9, res);
    }
    
    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    // ReSharper disable once IdentifierTypo
    public void LoadMnistTrainingDataFromStream_NetRecognizesAnImageOfA5Correctly()
    {
        using var imgOf5 = LoadImage(Path.Combine("Dnn", "MNIST_5.png"), ImreadModes.Grayscale);

        using var img5DataBlob = Cv2.Dnn.BlobFromImage(imgOf5, 1.0 / 255.0, new Size(28, 28));
        var modelPath = Path.Combine("_data", "model", "mnist-8.onnx");
        var res = -1;

        using (var stream = new FileStream(modelPath, FileMode.Open))
        {
            using (var net = Cv2.Dnn.ReadNetFromONNX(stream))
            {
                Assert.NotNull(net);
                net!.SetInput(img5DataBlob);

                using (var prob = net.Forward())
                    res = GetResultClass(prob);
            }
        }

        Assert.Equal(5, res);
    }

    private static int GetResultClass(Mat prob)
    {
        var channels = prob.Size(1);
        using Mat strip = prob.Reshape(1, channels);

        var minIdx = new[] {-1};
        var maxIdx = new[] { -1 };
        Cv2.MinMaxIdx(strip, minIdx, maxIdx);

        return maxIdx[0];
    }
}
