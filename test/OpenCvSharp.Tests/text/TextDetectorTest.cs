using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Xunit;

namespace OpenCvSharp.Tests.Text
{
    public class TextDetectorTest : TestBase
    {
        private const string modelArch = "_data/text/textbox.prototxt";
        private const string modelWeights = "_data/model/TextBoxes_icdar13.caffemodel";
        private static readonly string modelWeightsUrl = string.Format("https://drive.google.com/uc?id={0}&export=download", "10rqbOxZphuwk0TaWCaixIhheIBnxoaxv"); 
        
        public TextDetectorTest()
        { 
            if (!File.Exists(modelWeights))
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
                using (var client = new HttpClient(handler))
                {
                    var data = client.GetByteArrayAsync(modelWeightsUrl).GetAwaiter().GetResult();
                    File.WriteAllBytes(modelWeights, data);
                }
            }
        }

        [Fact]
        public void Create()
        {
            Assert.True(File.Exists(modelArch), $"modelArch '{modelArch}' not found");
            Assert.True(File.Exists(modelWeights), $"modelWeights '{modelWeights}' not found");

            var modelWeightsFileInfo = new FileInfo(modelWeights);
            Assert.True(modelWeightsFileInfo.Length > 10_000_000, $"{Path.GetFullPath(modelWeights)}: {modelWeightsFileInfo.Length} bytes");

            using (var detector = TextDetectorCNN.Create(modelArch, modelWeights))
            {
                GC.KeepAlive(detector);
            }
        }

        [Fact(Skip = "Error at https://github.com/opencv/opencv_contrib/blob/1404ce97aeee43469193c6a9c10b0743fbedc4dc/modules/text/src/text_detectorCNN.cpp#L38")]
        public void Detect()
        {
            using (var detector = TextDetectorCNN.Create(modelArch, modelWeights))
            using (var image = Image("imageTextR.png", ImreadModes.Color))
            {
                detector.Detect(image, out var boxes, out var confidences);

                Assert.NotEmpty(boxes);
                Assert.NotEmpty(confidences);
                Assert.Equal(boxes.Length, confidences.Length);

                if (Debugger.IsAttached)
                {
                    foreach (var box in boxes)
                    {
                        image.Rectangle(box, Scalar.Red, 2);
                    }
                    Window.ShowImages(image);
                }
            }
        }
    }
}
