using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.ObjDetect;

// ReSharper disable InconsistentNaming
public class FaceDetectorYNTest : TestBase
{
    // YuNet face detection model from OpenCV Zoo
    // https://github.com/opencv/opencv_zoo/tree/main/models/face_detection_yunet
    private const string ModelUrl =
        "https://github.com/opencv/opencv_zoo/raw/main/models/face_detection_yunet/face_detection_yunet_2023mar.onnx";

    private const string ModelPath = "_data/model/face_detection_yunet_2023mar.onnx";

    static FaceDetectorYNTest()
    {
        if (!File.Exists(ModelPath))
        {
            var contents = FileDownloader.DownloadData(new Uri(ModelUrl));
            File.WriteAllBytes(ModelPath, contents);
        }
    }

    [Fact]
    public void Create()
    {
        using var detector = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(320, 320));

        Assert.NotNull(detector);
    }

    [Fact]
    public void CreateWithParameters()
    {
        using var detector = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(640, 480),
            scoreThreshold: 0.8f,
            nmsThreshold: 0.4f,
            topK: 3000,
            backendId: Backend.DEFAULT,
            targetId: Target.CPU);

        Assert.NotNull(detector);
    }

    [Fact]
    public void Dispose_Twice()
    {
        var detector = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(320, 320));

        detector.Dispose();
        detector.Dispose(); // Should not throw
    }

    [Fact]
    public void Detect_Lenna()
    {
        using var image = LoadImage("lenna.png");
        Assert.False(image.Empty());

        using var detector = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(image.Cols, image.Rows),
            scoreThreshold: 0.9f,
            nmsThreshold: 0.3f,
            topK: 5000);

        using var faces = new Mat();
        int result = detector.Detect(image, faces);

        // Lenna image should contain at least one face
        Assert.Equal(1, result);
        Assert.False(faces.Empty());

        // Each row in faces is a detected face:
        // [x, y, w, h, x_re, y_re, x_le, y_le, x_nt, y_nt, x_rcm, y_rcm, x_lcm, y_lcm, score]
        // 14 landmarks + 1 score = 15 columns
        Assert.True(faces.Rows > 0, "Expected at least one detected face");
        Assert.Equal(15, faces.Cols);

        // Verify the confidence score (last column) is reasonable
        var score = faces.At<float>(0, 14);
        Assert.True(score > 0.5f, $"Face confidence score {score} is unexpectedly low");

        ShowImagesWhenDebugMode(image);
    }

    [Fact]
    public void Detect_NoFace()
    {
        // Create a blank image with no face
        using var image = new Mat(320, 320, MatType.CV_8UC3, Scalar.All(128));

        using var detector = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(320, 320),
            scoreThreshold: 0.9f);

        using var faces = new Mat();
        detector.Detect(image, faces);

        // Blank image should have no detected faces
        Assert.True(faces.Empty() || faces.Rows == 0,
            $"Expected no faces but got {faces.Rows} detection(s)");
    }

    [Fact]
    public void Detect_MultipleCalls()
    {
        using var image = LoadImage("lenna.png");
        using var detector = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(image.Cols, image.Rows));

        // Verify that calling Detect multiple times produces consistent results
        using var faces1 = new Mat();
        using var faces2 = new Mat();

        int result1 = detector.Detect(image, faces1);
        int result2 = detector.Detect(image, faces2);

        Assert.Equal(result1, result2);
        Assert.Equal(faces1.Rows, faces2.Rows);
        Assert.Equal(faces1.Cols, faces2.Cols);
    }

    [Fact]
    public void Detect_DifferentThresholds()
    {
        using var image = LoadImage("lenna.png");

        // With high threshold
        using var detectorHigh = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(image.Cols, image.Rows),
            scoreThreshold: 0.99f);

        using var facesHigh = new Mat();
        detectorHigh.Detect(image, facesHigh);

        // With low threshold
        using var detectorLow = new FaceDetectorYN(
            ModelPath,
            config: "",
            inputSize: new Size(image.Cols, image.Rows),
            scoreThreshold: 0.1f);

        using var facesLow = new Mat();
        detectorLow.Detect(image, facesLow);

        // Lower threshold should yield >= detections than higher threshold
        int highCount = facesHigh.Empty() ? 0 : facesHigh.Rows;
        int lowCount = facesLow.Empty() ? 0 : facesLow.Rows;
        Assert.True(lowCount >= highCount,
            $"Low threshold detections ({lowCount}) should be >= high threshold detections ({highCount})");
    }
}
