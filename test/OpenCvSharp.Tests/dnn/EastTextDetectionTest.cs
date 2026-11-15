using System.Security.Cryptography;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

/// <summary>
/// https://github.com/opencv/opencv/blob/master/samples/dnn/text_detection.cpp
/// </summary>
/// <see cref="https://gist.github.com/ludwo/c091ed6261d26654c8b71949d89f8142"/>
/// <see cref="https://github.com/shimat/opencvsharp/issues/702"/>
public class EastTextDetectionTest : TestBase
{
    private const string ModelUrl = "https://huggingface.co/opencv/opencv_contribution/resolve/53892e2f90a148cb1126768a6adc8aa138745bfa/east_text_detection/east_text_detection_2026jul.onnx";
    private const string ModelSha256 = "63F96881E90B81F3F0E7FD79DC705EAD31276DA70D3C7DCA008CA28D3554883A";
    private const string LocalModelPath = "_data/model/east_text_detection_2026jul.onnx";
    private static readonly object ModelLock = new();

    internal static string PrepareModel()
    {
        lock (ModelLock)
        {
            if (!File.Exists(LocalModelPath))
            {
                var contents = FileDownloader.DownloadData(new Uri(ModelUrl));
                Assert.Equal(ModelSha256, Convert.ToHexString(SHA256.HashData(contents)));
                File.WriteAllBytes(LocalModelPath, contents);
            }
        }

        return LocalModelPath;
    }

    [ExplicitFact]
    public void Load()
    {
        using var net = Cv2.Dnn.ReadNet(PrepareModel());
        Assert.False(net.Empty());
    }

    [ExplicitFact]
    public void LoadFromUnicodeFileName()
    {
        var modelPath = PrepareModel();
        var unicodeFileName = Path.Combine(Path.GetDirectoryName(modelPath)!, "🤣🍀.onnx");
        File.Copy(modelPath, unicodeFileName, true);
        try
        {
            using var net = Cv2.Dnn.ReadNet(unicodeFileName);
            Assert.False(net.Empty());
        }
        finally
        {
            File.Delete(unicodeFileName);
        }
    }

    /// <summary>
    /// detect text from image.
    /// </summary>
    /// <see cref="https://github.com/opencv/opencv/blob/master/samples/dnn/text_detection.cpp"/>
    /// <param name="fileName">Name of the image file.</param>
    /// <returns>Scanned text.</returns>
    [ExplicitTheory]
    [InlineData("_data/image/abbey_road.jpg")]
    public void DetectAllText(string fileName)
    {
        const int InputWidth = 320;
        const int InputHeight = 320;
        const float ConfThreshold = 0.5f;
        const float NmsThreshold = 0.4f;

        // Load network.
        using (Net net = Cv2.Dnn.ReadNet(PrepareModel()))
        using (Mat img = new Mat(fileName))

            // Prepare input image
        using (var blob = Cv2.Dnn.BlobFromImage(img, 1.0, new Size(InputWidth, InputHeight), new Scalar(123.68, 116.78, 103.94), true, false))
        {
            var outputBlobNames = new[] { "feature_fusion/Conv_7/Sigmoid:0", "feature_fusion/concat_3:0" };
            using var scores = new Mat();
            using var geometry = new Mat();

            net.SetInput(blob);
            net.Forward(new[] { scores, geometry }, outputBlobNames);

            // Decode predicted bounding boxes (decode the positions of the text boxes along with their orientation)
            Decode(scores, geometry, ConfThreshold, out var boxes, out var confidences);

            // Apply non-maximum suppression procedure for filtering out the false positives and get the final predictions
            Cv2.Dnn.NMSBoxes(boxes, confidences, ConfThreshold, NmsThreshold, out var indices);

            // Render detections.
            Point2f ratio = new Point2f((float)img.Cols / InputWidth, (float)img.Rows / InputHeight);
            for (var i = 0; i < indices.Length; ++i)
            {
                RotatedRect box = boxes[indices[i]];

                Point2f[] vertices = box.Points();

                for (int j = 0; j < 4; ++j)
                {
                    vertices[j].X *= ratio.X;
                    vertices[j].Y *= ratio.Y;
                }

                for (int j = 0; j < 4; ++j)
                {
                    Cv2.Line(img, (int)vertices[j].X, (int)vertices[j].Y, (int)vertices[(j + 1) % 4].X, (int)vertices[(j + 1) % 4].Y, new Scalar(0, 255, 0), 3);
                }
            }

            ShowImagesWhenDebugMode(img);        
        }
    }

    private static unsafe void Decode(Mat scores, Mat geometry, float confThreshold, out IList<RotatedRect> boxes, out IList<float> confidences)
    {
        boxes = new List<RotatedRect>();
        confidences = new List<float>();

        if ((scores is null || scores.Dims != 4 || scores.Size(0) != 1 || scores.Size(1) != 1) ||
            (geometry is null || geometry.Dims != 4 || geometry.Size(0) != 1 || geometry.Size(1) != 5) ||
            (scores.Size(2) != geometry.Size(2) || scores.Size(3) != geometry.Size(3)))
        {
            return;
        }

        int height = scores.Size(2);
        int width = scores.Size(3);

        for (int y = 0; y < height; ++y)
        {
            var scoresData = new ReadOnlySpan<float>((void*)scores.Ptr(0, 0, y), height);
            var x0Data = new ReadOnlySpan<float>((void*)geometry.Ptr(0, 0, y), height);
            var x1Data = new ReadOnlySpan<float>((void*)geometry.Ptr(0, 1, y), height);
            var x2Data = new ReadOnlySpan<float>((void*)geometry.Ptr(0, 2, y), height);
            var x3Data = new ReadOnlySpan<float>((void*)geometry.Ptr(0, 3, y), height);
            var anglesData = new ReadOnlySpan<float>((void*)geometry.Ptr(0, 4, y), height);

            for (int x = 0; x < width; ++x)
            {
                var score = scoresData[x];
                if (score >= confThreshold)
                {
                    float offsetX = x * 4.0f;
                    float offsetY = y * 4.0f;
                    float angle = anglesData[x];
                    float cosA = (float)Math.Cos(angle);
                    float sinA = (float)Math.Sin(angle);
                    float x0 = x0Data[x];
                    float x1 = x1Data[x];
                    float x2 = x2Data[x];
                    float x3 = x3Data[x];
                    float h = x0 + x2;
                    float w = x1 + x3;
                    Point2f offset = new Point2f(offsetX + (cosA * x1) + (sinA * x2), offsetY - (sinA * x1) + (cosA * x2));
                    Point2f p1 = new Point2f((-sinA * h) + offset.X, (-cosA * h) + offset.Y);
                    Point2f p3 = new Point2f((-cosA * w) + offset.X, (sinA * w) + offset.Y);
                    RotatedRect r = new RotatedRect(new Point2f(0.5f * (p1.X + p3.X), 0.5f * (p1.Y + p3.Y)), new Size2f(w, h), (float)(-angle * 180.0f / Math.PI));
                    boxes.Add(r);
                    confidences.Add(score);
                }
            }
        }
    }
}
