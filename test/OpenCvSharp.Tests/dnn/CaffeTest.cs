using System;
using System.IO;
using System.Linq;
using OpenCvSharp.Dnn;
using OpenCvSharp.Tests.dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    public class CaffeTest : TestBase, IClassFixture<DnnDataFixture>
    {
        private readonly object lockObj = new object();

        private readonly ITestOutputHelper testOutputHelper;
        private readonly CaffeData caffe;

        public CaffeTest(ITestOutputHelper testOutputHelper, DnnDataFixture fixture)
        {
            if (fixture == null)
                throw new ArgumentNullException(nameof(fixture));
            this.testOutputHelper = testOutputHelper;
            caffe = fixture.Caffe.Value;
        }

        // https://docs.opencv.org/3.3.0/d5/de7/tutorial_dnn_googlenet.html
        [ExplicitFact]
        public void LoadCaffeModel()
        {
            var net = caffe.Net;
            var classNames = caffe.ClassNames;

            //Console.WriteLine("Layer names: {0}", string.Join(", ", net.GetLayerNames()));
            var layerName = net.GetLayerNames()[0];
            Assert.NotNull(layerName);
            Assert.Equal(1, net.GetLayerId(layerName!));

            // Convert Mat to batch of images
            using var img = Image(@"space_shuttle.jpg");
            using var inputBlob = CvDnn.BlobFromImage(img, 1, new Size(224, 224), new Scalar(104, 117, 123));
            net.SetInput(inputBlob, "data");
            using var prob = net.Forward("prob");
            // find the best class
            GetMaxClass(prob, out int classId, out double classProb);
            testOutputHelper.WriteLine("Best class: #{0} '{1}'", classId, classNames[classId]);
            testOutputHelper.WriteLine("Probability: {0:P2}", classProb);
            //Pause();

            Assert.Equal(812, classId);
        }

        /// <summary>
        /// Download model file
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
                        fileName,
                        progress.BytesReceived,
                        progress.TotalBytesToReceive,
                        progress.ProgressPercentage);
                });
                File.WriteAllBytes(fileName, contents);
            }
        }

        /// <summary>
        /// Find best class for the blob (i. e. class with maximal probability)
        /// </summary>
        /// <param name="probBlob"></param>
        /// <param name="classId"></param>
        /// <param name="classProb"></param>
        private static void GetMaxClass(Mat probBlob, out int classId, out double classProb)
        {
            // reshape the blob to 1x1000 matrix
            using var probMat = probBlob.Reshape(1, 1);
            Cv2.MinMaxLoc(probMat, out _, out classProb, out _, out var classNumber);
            classId = classNumber.X;
        }
    }
}
