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

    // Tesseract expects the parent directory of "tessdata" (not tessdata itself).
    // Use an absolute path so native code does not depend on the current working directory.
    private static string TessDataParent =>
        Path.Combine(AppContext.BaseDirectory, "_data") + Path.DirectorySeparatorChar;

    [Fact]
    public void Create()
    {
        using (var tesseract = OCRTesseract.Create(TessDataParent))
        {
            GC.KeepAlive(tesseract);
        }
    }

    [Fact]
    public void Run()
    {
        var engTrainedDataPath = Path.Combine(TessDataParent, "tessdata", "eng.traineddata");
        Assert.True(File.Exists(engTrainedDataPath), $"Missing tessdata file: {engTrainedDataPath}");

        using (var image = LoadImage("alphabet.png"))
        using (var tesseract = OCRTesseract.Create(TessDataParent, "eng"))
        {
            tesseract.Run(image,
                out var outputText, out var componentRects, out var componentTexts, out var componentConfidences);

            testOutputHelper.WriteLine(outputText);
            Assert.NotEmpty(outputText);
        }
    }
}
