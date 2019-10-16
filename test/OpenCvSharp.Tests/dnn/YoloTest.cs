using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenCvSharp.Dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    [Xunit.Collection(nameof(YoloTest))]
    public class YoloTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        // https://github.com/opencv/opencv/blob/24bed38c2b2c71d35f2e92aa66648f8485a70892/samples/dnn/yolo_object_detection.cpp
        [Fact]
        public void LoadYoloV2Model()
        {
            RunGC();

            const string cfgFile = @"yolov2.cfg";
            const string cfgFileUrl = "https://raw.githubusercontent.com/pjreddie/darknet/master/cfg/yolov2.cfg";
            const string darknetModel = "yolov2.weights";
            const string darknetModelUrl = "https://pjreddie.com/media/files/yolov2.weights";

            testOutputHelper.WriteLine("Downloading YoloV2 Model...");
            PrepareFile(cfgFileUrl, cfgFile);
            PrepareFile(darknetModelUrl, darknetModel);
            testOutputHelper.WriteLine("Done");

            RunGC();

            using var net = CvDnn.ReadNetFromDarknet(cfgFile, darknetModel);
            Assert.False(net.Empty());

            // Convert Mat to batch of images
            using var img = Image(@"space_shuttle.jpg");
            using var inputBlob = CvDnn.BlobFromImage(img, 1, new Size(224, 224), new Scalar(104, 117, 123));
            // Set input blob
            net.SetInput(inputBlob, "data");

            // Make forward pass
            using var detectionMat = net.Forward("detection_out");
            // TODO
            GC.KeepAlive(detectionMat);
        }

        // https://github.com/opencv/opencv/blob/24bed38c2b2c71d35f2e92aa66648f8485a70892/samples/dnn/yolo_object_detection.cpp
        [Fact]
        public void LoadYoloV3Model()
        {
            RunGC();

            const string cfgFile = @"yolov3.cfg";
            const string cfgFileUrl = "https://raw.githubusercontent.com/pjreddie/darknet/master/cfg/yolov3.cfg";
            const string darknetModel = "yolov3.weights";
            const string darknetModelUrl = "https://pjreddie.com/media/files/yolov3.weights";

            testOutputHelper.WriteLine("Downloading YoloV3 Model...");
            PrepareFile(cfgFileUrl, cfgFile);
            PrepareFile(darknetModelUrl, darknetModel);
            testOutputHelper.WriteLine("Done");

            RunGC();

            using (var net = CvDnn.ReadNetFromDarknet(cfgFile, darknetModel))
            using (var img = Image(@"space_shuttle.jpg"))
            {
                Assert.False(net.Empty());

                var outNames = net.GetUnconnectedOutLayersNames();
                Assert.NotEmpty(outNames);
                testOutputHelper.WriteLine("UnconnectedOutLayersNames: {0}", string.Join(",", outNames));

                // Convert Mat to batch of images
                using (var inputBlob = CvDnn.BlobFromImage(img, 1, new Size(224, 224), new Scalar(104, 117, 123)))
                {
                    // Set input blob
                    net.SetInput(inputBlob, "data");

                    // Make forward pass
                    using (var detection82 = net.Forward("yolo_82"))
                    using (var detection94 = net.Forward("yolo_94"))
                    using (var detection106 = net.Forward("yolo_106"))
                    {
                        // TODO
                        Assert.False(detection82.Empty());
                        Assert.False(detection94.Empty());
                        Assert.False(detection106.Empty());
                    }

                    Mat[] outs = outNames.Select(_ => new Mat()).ToArray();
                    net.Forward(outs, outNames);

                    foreach (var m in outs)
                    {
                        Assert.False(m.Empty());
                        m.Dispose();
                    }
                }
            }
        }

        private static void PrepareFile(string url, string fileName)
        {
            lock (lockObj)
            {
                if (!File.Exists(fileName))
                {
                    var contents = DownloadBytes(url);
                    File.WriteAllBytes(fileName, contents);
                }
            }
        }
        private static readonly object lockObj = new object();

        public YoloTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        private static void RunGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
