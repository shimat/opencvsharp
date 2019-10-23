using System.IO;
using System.Linq;
using OpenCvSharp.Dnn;
using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Dnn
{
    public class CaffeTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        // https://docs.opencv.org/3.3.0/d5/de7/tutorial_dnn_googlenet.html
        [Fact]
        public void LoadCaffeModel()
        {
            const string protoTxt = @"_data/text/bvlc_googlenet.prototxt";
            const string caffeModelUrl = "http://dl.caffe.berkeleyvision.org/bvlc_googlenet.caffemodel";
            const string caffeModel = "_data/model/bvlc_googlenet.caffemodel";
            const string synsetWords = @"_data/text/synset_words.txt";
            var classNames = File.ReadAllLines(synsetWords)
                .Select(line => line.Split(' ').Last())
                .ToArray();

            testOutputHelper.WriteLine("Downloading Caffe Model...");
            PrepareModel(caffeModelUrl, caffeModel);
            testOutputHelper.WriteLine("Done");

            using var net = CvDnn.ReadNetFromCaffe(protoTxt, caffeModel);
            //Console.WriteLine("Layer names: {0}", string.Join(", ", net.GetLayerNames()));
            Assert.Equal(1, net.GetLayerId(net.GetLayerNames()[0]));

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

        private static void PrepareModel(string url, string fileName)
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

        public CaffeTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
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
