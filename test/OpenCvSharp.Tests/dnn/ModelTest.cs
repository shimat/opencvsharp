using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Tests for the high-level dnn Model API.
//
// The end-to-end tests reuse the MNIST TensorFlow model and digit images that
// already ship in the repository (also used by TensorflowTest), so they run in
// CI without downloading anything. They prove the full pipeline really works:
// input preprocessing -> forward pass -> result decoding.
//
// The remaining lifecycle tests cover model types for which no committed model
// is available; they still verify that the native constructors, base setters
// and destructors are wired up correctly.
public class ModelTest : TestBase
{
    // The native dnn backend is only available on Windows or Linux builds here.
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static string MnistModelPath => Path.Combine("_data", "model", "MNISTTest_tensorflow.pb");

    [Theory(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    [InlineData("MNIST_5.png", 5)]
    [InlineData("MNIST_9.png", 9)]
    public void ClassificationModelRecognizesMnistDigit(string imageFileName, int expectedDigit)
    {
        using var image = LoadImage(Path.Combine("Dnn", imageFileName), ImreadModes.Grayscale);

        using var model = new ClassificationModel(MnistModelPath);
        // scale 1/255, input size = image size (the digit images already match the model input), grayscale.
        model.SetInputParams(1.0 / 255.0, image.Size());

        model.Classify(image, out var classId, out var conf);

        Assert.Equal(expectedDigit, classId);
        Assert.True(conf > 0, $"confidence should be positive but was {conf}");
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ModelPredictReturnsProbabilities()
    {
        using var image = LoadImage(Path.Combine("Dnn", "MNIST_9.png"), ImreadModes.Grayscale);

        using var model = new Model(MnistModelPath);
        model.SetInputParams(1.0 / 255.0, image.Size());

        var outputs = model.Predict(image);
        try
        {
            Assert.NotEmpty(outputs);

            // The single output blob holds the per-class scores; argmax must be 9.
            using var strip = outputs[0].Reshape(1, (int)outputs[0].Total());
            var minIdx = new[] { -1 };
            var maxIdx = new[] { -1 };
            strip.MinMaxIdx(minIdx, maxIdx);
            Assert.Equal(9, maxIdx[0]);
        }
        finally
        {
            foreach (var o in outputs)
                o.Dispose();
        }
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ModelFromNetSharesBaseSetters()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        Assert.NotNull(net);

        using var model = new Model(net!);
        model.SetInputSize(new Size(26, 26));
        model.SetInputSize(26, 26);
        model.SetInputMean(new Scalar(0));
        model.SetInputScale(new Scalar(1.0 / 255));
        model.SetInputCrop(false);
        model.SetInputSwapRB(false);
        model.SetInputParams(1.0 / 255.0, new Size(26, 26), new Scalar(0), false, false);
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ClassificationModelSoftmaxToggle()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        using var model = new ClassificationModel(net!);

        model.SetEnableSoftmaxPostProcessing(true);
        Assert.True(model.GetEnableSoftmaxPostProcessing());
        model.SetEnableSoftmaxPostProcessing(false);
        Assert.False(model.GetEnableSoftmaxPostProcessing());
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void DetectionModelLifecycle()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        using var model = new DetectionModel(net!);

        model.SetNmsAcrossClasses(true);
        Assert.True(model.GetNmsAcrossClasses());
        model.SetNmsAcrossClasses(false);
        Assert.False(model.GetNmsAcrossClasses());

        model.SetInputParams(1.0 / 255.0, new Size(26, 26));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void SegmentationModelLifecycle()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        using var model = new SegmentationModel(net!);
        model.SetInputParams(1.0 / 255.0, new Size(26, 26));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void KeypointsModelLifecycle()
    {
        using var net = CvDnn.ReadNetFromTensorflow(MnistModelPath);
        using var model = new KeypointsModel(net!);
        model.SetInputParams(1.0 / 255.0, new Size(26, 26));
    }
}
