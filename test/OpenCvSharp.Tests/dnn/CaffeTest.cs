using System;
using System.IO;
using System.Linq;
using OpenCvSharp.Dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    public class CaffeTest : TestBase
    {        
        private readonly object lockObj = new object();

        private readonly ITestOutputHelper testOutputHelper;

        public CaffeTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        // https://docs.opencv.org/3.3.0/d5/de7/tutorial_dnn_googlenet.html
        [Fact]
        public void LoadCaffeModel()
        {
            const string protoTxt = @"_data/text/bvlc_googlenet.prototxt";
            const string caffeModelUrl = "https://drive.google.com/uc?id=1RUsoiLiXrKBQu9ibwsMqR3n_UkhnZLRR"; //"http://dl.caffe.berkeleyvision.org/bvlc_googlenet.caffemodel";
            const string caffeModel = "_data/model/bvlc_googlenet.caffemodel";
            const string synsetWords = @"_data/text/synset_words.txt";
            var classNames = File.ReadAllLines(synsetWords)
                .Select(line => line.Split(' ').Last())
                .ToArray();

            testOutputHelper.WriteLine("Downloading Caffe Model...");
            PrepareModel(new Uri(caffeModelUrl), caffeModel);
            testOutputHelper.WriteLine("Done");

            using var net = CvDnn.ReadNetFromCaffe(protoTxt, caffeModel);
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
            Pause();

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
