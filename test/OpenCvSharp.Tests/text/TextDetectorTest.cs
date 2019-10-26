using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Xunit;

namespace OpenCvSharp.Tests.Text
{
    public class TextDetectorTest : TestBase
    {
        private const string ModelArch = "_data/text/textbox.prototxt";
        private const string ModelWeights = "_data/model/TextBoxes_icdar13.caffemodel";
        private const string ModelWeightsUrl = "https://drive.google.com/uc?id=10rqbOxZphuwk0TaWCaixIhheIBnxoaxv&export=download";

        public TextDetectorTest()
        { 
            if (!File.Exists(ModelWeights))
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
                using (var client = new HttpClient(handler))
                {
                    var data = client.GetByteArrayAsync(ModelWeightsUrl).GetAwaiter().GetResult();
                    File.WriteAllBytes(ModelWeights, data);
                }
            }
        }

        [Fact]
        public void Create()
        {
            Assert.True(File.Exists(ModelArch), $"modelArch '{ModelArch}' not found");
            Assert.True(File.Exists(ModelWeights), $"modelWeights '{ModelWeights}' not found");

            var modelWeightsFileInfo = new FileInfo(ModelWeights);
            Assert.True(modelWeightsFileInfo.Length > 10_000_000, $"{Path.GetFullPath(ModelWeights)}: {modelWeightsFileInfo.Length} bytes");

            using (var detector = TextDetectorCNN.Create(ModelArch, ModelWeights))
            {
                GC.KeepAlive(detector);
            }
        }

        [Fact(Skip = "Error at https://github.com/opencv/opencv_contrib/blob/1404ce97aeee43469193c6a9c10b0743fbedc4dc/modules/text/src/text_detectorCNN.cpp#L38")]
        public void Detect()
        {
            using (var detector = TextDetectorCNN.Create(ModelArch, ModelWeights))
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
