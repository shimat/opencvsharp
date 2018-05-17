using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn
{
    public class CaffeTest : TestBase
    {
        // https://docs.opencv.org/3.3.0/d5/de7/tutorial_dnn_googlenet.html
        [Fact]
        public async Task LoadCaffeModel()
        {
            const string protoTxt = @"_data\text\bvlc_googlenet.prototxt";
            const string caffeModel = "bvlc_googlenet.caffemodel";
            const string synsetWords = @"_data\text\synset_words.txt";
            var classNames = File.ReadAllLines(synsetWords)
                .Select(line => line.Split(' ').Last())
                .ToArray();

            Console.Write("Downloading Caffe Model...");
            await PrepareModel(caffeModel);
            Console.WriteLine(" Done");

            using (var net = CvDnn.ReadNetFromCaffe(protoTxt, caffeModel))
            using (var img = Image(@"space_shuttle.jpg"))
            {
                //Console.WriteLine("Layer names: {0}", string.Join(", ", net.GetLayerNames()));
                Assert.Equal(1, net.GetLayerId(net.GetLayerNames()[0]));

                // Convert Mat to batch of images
                using (var inputBlob = CvDnn.BlobFromImage(img, 1, new Size(224, 224), new Scalar(104, 117, 123)))
                {
                    net.SetInput(inputBlob, "data");
                    using (var prob = net.Forward("prob"))
                    {
                        // find the best class
                        GetMaxClass(prob, out int classId, out double classProb);
                        Console.WriteLine("Best class: #{0} '{1}'", classId, classNames[classId]);
                        Console.WriteLine("Probability: {0:P2}", classProb);
                        Pause();

                        Assert.Equal(812, classId);
                    }
                }
            }
        }

        private static async Task PrepareModel(string fileName)
        {
            if (!File.Exists(fileName))
            { 
                var contents = await DownloadBytes("http://dl.caffe.berkeleyvision.org/bvlc_googlenet.caffemodel");
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
            using (var probMat = probBlob.Reshape(1, 1))
            {
                Cv2.MinMaxLoc(probMat, out _, out classProb, out _, out var classNumber);
                classId = classNumber.X;
            }
        }
    }
}
