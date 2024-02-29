using System.Diagnostics;
using System.Net.Http;
using Xunit;

namespace OpenCvSharp.Tests.Text;

public class TextDetectorTest : TestBase
{
    private const string ModelArch = "_data/text/textbox.prototxt";
    private const string ModelWeights = "_data/model/TextBoxes_icdar13.caffemodel";
    private const string ModelWeightsUrl = "https://drive.google.com/uc?id=10rqbOxZphuwk0TaWCaixIhheIBnxoaxv&export=download";

    public TextDetectorTest()
    { 
        if (!File.Exists(ModelWeights))
        {
            using var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            using var client = new HttpClient(handler);
            var data = client.GetByteArrayAsync(new Uri(ModelWeightsUrl)).GetAwaiter().GetResult();
            File.WriteAllBytes(ModelWeights, data);
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

    [Fact]
    public void Detect()
    {
        using var detector = TextDetectorCNN.Create(ModelArch, ModelWeights);
        using var image = LoadImage("imageTextR.png", ImreadModes.Color);
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
