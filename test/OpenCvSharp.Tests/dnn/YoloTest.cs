using System;
using System.IO;
using System.Linq;
using OpenCvSharp.Dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    [Collection(nameof(YoloTest))]
    public class YoloTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;
        
        public YoloTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        // https://github.com/opencv/opencv/blob/24bed38c2b2c71d35f2e92aa66648f8485a70892/samples/dnn/yolo_object_detection.cpp
        [ExplicitFact]
        public void LoadYoloV2Model()
        {
            RunGC();

            const string cfgFile = @"_data/model/yolov2.cfg";
            const string cfgFileUrl = "https://raw.githubusercontent.com/pjreddie/darknet/master/cfg/yolov2.cfg";
            const string darknetModel = "_data/model/yolov2.weights";
            const string darknetModelUrl = "https://pjreddie.com/media/files/yolov2.weights";

            testOutputHelper.WriteLine("Downloading YoloV2 Model...");
            PrepareFile(new Uri(cfgFileUrl), cfgFile);
            PrepareFile(new Uri(darknetModelUrl), darknetModel);
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
        [ExplicitFact]
        public void LoadYoloV3Model()
        {
            RunGC();

            const string cfgFile = @"_data/model/yolov3.cfg";
            const string cfgFileUrl = "https://raw.githubusercontent.com/pjreddie/darknet/master/cfg/yolov3.cfg";
            const string darknetModel = "_data/model/yolov3.weights";
            const string darknetModelUrl = "https://pjreddie.com/media/files/yolov3.weights";

            testOutputHelper.WriteLine("Downloading YoloV3 Model...");
            PrepareFile(new Uri(cfgFileUrl), cfgFile);
            PrepareFile(new Uri(darknetModelUrl), darknetModel);
            testOutputHelper.WriteLine("Done");

            RunGC();

            using (var net = CvDnn.ReadNetFromDarknet(cfgFile, darknetModel))
            using (var img = Image(@"space_shuttle.jpg"))
            {
                Assert.False(net.Empty());

                var outNames = net.GetUnconnectedOutLayersNames();
                Assert.NotEmpty(outNames);
                Assert.DoesNotContain(outNames, elem => elem == null);
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
                    net.Forward(outs, outNames!);

                    foreach (var m in outs)
                    {
                        Assert.False(m.Empty());
                        m.Dispose();
                    }
                }
            }
        }

        private void PrepareFile(Uri uri, string fileName)
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
                        fileName,
                        progress.BytesReceived,
                        progress.TotalBytesToReceive,
                        progress.ProgressPercentage);
                });
                File.WriteAllBytes(fileName, contents);
            }
        }
        private readonly object lockObj = new object();
        
        private static void RunGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
