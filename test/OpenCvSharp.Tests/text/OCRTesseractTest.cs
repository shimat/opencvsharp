using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable
public class OCRTesseractTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public OCRTesseractTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    // Use absolute path so that the native Tesseract code resolves it correctly
    // regardless of the working directory at the time of the native call.
    private static string TessData =>
        Path.Combine(AppContext.BaseDirectory, "_data", "tessdata") + Path.DirectorySeparatorChar;

    [Fact]
    public void Create()
    {
        using (var tesseract = OCRTesseract.Create(TessData))
        {
            GC.KeepAlive(tesseract);
        }
    }

    [Fact]
    public void Run()
    {
        using (var image = LoadImage("alphabet.png"))
        using (var tesseract = OCRTesseract.Create(TessData, "eng"))
        {
            tesseract.Run(image,
                out var outputText, out var componentRects, out var componentTexts, out var componentConfidences);

            testOutputHelper.WriteLine(outputText);
            Assert.NotEmpty(outputText);
        }
    }
}
