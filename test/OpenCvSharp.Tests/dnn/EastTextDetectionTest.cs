using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using OpenCvSharp.Dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    /// <summary>
    /// https://github.com/opencv/opencv/blob/master/samples/dnn/text_detection.cpp
    /// </summary>
    /// <see cref="https://gist.github.com/ludwo/c091ed6261d26654c8b71949d89f8142"/>
    /// <see cref="https://github.com/shimat/opencvsharp/issues/702"/>
    public class EastTextDetectionTest : TestBase
    {
        // https://github.com/opencv/opencv_extra/blob/322b475403899abc2411c4fbf68318afa77d3191/testdata/dnn/download_models.py#L302
        const string ModelUrl = "https://www.dropbox.com/s/r2ingd0l3zt8hxs/frozen_east_text_detection.tar.gz?dl=1"; 
        const string LocalRawModelPath = "_data/model/frozen_east_text_detection.tar.gz";
        const string LocalModelPath = "_data/model/frozen_east_text_detection.pb";

        private readonly object lockObj = new object();

        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Download model file
        /// </summary>
        /// <param name="testOutputHelper"></param>
        public EastTextDetectionTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
            
            testOutputHelper.WriteLine("Downloading EAST Model...");
            PrepareModel(new Uri(ModelUrl), LocalRawModelPath);
            testOutputHelper.WriteLine("Done");
            Assert.True(File.Exists(LocalRawModelPath), $"'{LocalRawModelPath}' not found");

            if (!File.Exists(LocalModelPath))
            {
                var modelDirectory = Path.GetDirectoryName(LocalRawModelPath)!;
                ExtractTarGz(LocalRawModelPath, modelDirectory);
            }

            var fileInfo = new FileInfo(LocalModelPath);
            Assert.True(fileInfo.Exists, $"'{LocalModelPath}' not found");
            Assert.True(fileInfo.Length > 90 * 1024 * 1024, $"Too small data ('{fileInfo.Length}' bytes)");
        }

        /// <summary>
        /// Download model file if it does not exist on local disk
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="fileName"></param>
        private void PrepareModel(Uri uri, string fileName)
        {
            lock (lockObj)
            {
                if (File.Exists(fileName)) 
                    return;

                int beforePercent = 0;
                var contents = DownloadBytes(uri, progress =>
                {
                    if (progress.ProgressPercentage == beforePercent)
                        return;
                    beforePercent = progress.ProgressPercentage;

                    testOutputHelper.WriteLine("[{0}] Download Progress: {1}/{2} ({3}%)",
                        nameof(EastTextDetectionTest),
                        progress.BytesReceived,
                        progress.TotalBytesToReceive,
                        progress.ProgressPercentage);
                });
                File.WriteAllBytes(fileName, contents);
            }
        }

        /// <summary>
        /// Simple full extract from a TGZ
        /// https://github.com/icsharpcode/SharpZipLib/wiki/GZip-and-Tar-Samples
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="dstFolder"></param>
        private static void ExtractTarGz(string inputFile, string dstFolder)
        {
            using var inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            using var gzipStream = new GZipInputStream(inputStream);
            using var tarArchive = TarArchive.CreateInputTarArchive(gzipStream, Encoding.UTF8);
            tarArchive.ExtractContents(dstFolder);
        }

        [ExplicitFact]
        public void Load()
        {
            Assert.True(File.Exists(LocalModelPath), $"'{LocalModelPath}' not found");

            using var net = CvDnn.ReadNet(LocalModelPath);
        }

        [ExplicitFact]
        public void NotSupportedUnicodeFileName()
        {
            Assert.True(File.Exists(LocalModelPath), $"'{LocalModelPath}' not found");

            var unicodeFileName = Path.Combine(Path.GetDirectoryName(LocalModelPath)!, "🤣🍀.pb");
            if (!File.Exists(unicodeFileName))
            {
                File.Copy(LocalModelPath, unicodeFileName, true);
            }

            // Check that ArgumentException(unicode unmappable char) does not occur.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var ex = Assert.Throws<OpenCVException>(() =>
                {
                    using var net = CvDnn.ReadNet(unicodeFileName);
                });
                Assert.StartsWith("FAILED: fs.is_open(). Can't open", ex.Message, StringComparison.InvariantCulture);
                Assert.Equal("cv::dnn::ReadProtoFromBinaryFile", ex.FuncName);
            }
            else
            {
                // No error
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
            using (Net net = CvDnn.ReadNet(Path.GetFullPath(LocalModelPath)))
            using (Mat img = new Mat(fileName))

            // Prepare input image
            using (var blob = CvDnn.BlobFromImage(img, 1.0, new Size(InputWidth, InputHeight), new Scalar(123.68, 116.78, 103.94), true, false))
            {
                // Forward Pass
                // Now that we have prepared the input, we will pass it through the network. There are two outputs of the network.
                // One specifies the geometry of the Text-box and the other specifies the confidence score of the detected box.
                // These are given by the layers :
                //   feature_fusion/concat_3
                //   feature_fusion/Conv_7/Sigmoid
                var outputBlobNames = new string[] { "feature_fusion/Conv_7/Sigmoid", "feature_fusion/concat_3" };
                var outputBlobs = outputBlobNames.Select(_ => new Mat()).ToArray();

                net.SetInput(blob);
                net.Forward(outputBlobs, outputBlobNames);
                Mat scores = outputBlobs[0];
                Mat geometry = outputBlobs[1];

                // Decode predicted bounding boxes (decode the positions of the text boxes along with their orientation)
                Decode(scores, geometry, ConfThreshold, out var boxes, out var confidences);

                // Apply non-maximum suppression procedure for filtering out the false positives and get the final predictions
                CvDnn.NMSBoxes(boxes, confidences, ConfThreshold, NmsThreshold, out var indices);

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

            if ((scores == null || scores.Dims != 4 || scores.Size(0) != 1 || scores.Size(1) != 1) ||
                (geometry == null || geometry.Dims != 4 || geometry.Size(0) != 1 || geometry.Size(1) != 5) ||
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
}
