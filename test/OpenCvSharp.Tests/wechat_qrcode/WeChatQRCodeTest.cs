using Xunit;

namespace OpenCvSharp.Tests.WeChatQRCode;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class WeChatQRCodeTest(ITestOutputHelper testOutputHelper) : TestBase
{
    private const string DetectorPrototxtPath = "_data/wechat_qrcode/detect.prototxt";
    private const string DetectorCaffeModelPath = "_data/wechat_qrcode/detect.caffemodel";
    private const string SuperResolutionPrototxtPath = "_data/wechat_qrcode/sr.prototxt";
    private const string SuperResolutionCaffeModelPath = "_data/wechat_qrcode/sr.caffemodel";

    private static readonly string[] ExpectedMultiQRTexts =
    [
        "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[]^_`{|}",
        "Helloこんにちは你好안녕하세요"
    ];

    /// <summary>
    /// Requires no model files. Verifies the no-arg constructor succeeds.
    /// </summary>
    [Fact]
    public void Constructor_Default_DoesNotThrow()
    {
        using var qr = new OpenCvSharp.WeChatQRCode();
    }

    /// <summary>
    /// Passing null for any string argument must throw ArgumentNullException.
    /// </summary>
    [Theory]
    [InlineData(null, "", "", "")]
    [InlineData("", null, "", "")]
    [InlineData("", "", null, "")]
    [InlineData("", "", "", null)]
    public void Constructor_NullArguments_ThrowsArgumentNullException(
        string? a, string? b, string? c, string? d)
    {
        Assert.Throws<ArgumentNullException>(() => new OpenCvSharp.WeChatQRCode(a!, b!, c!, d!));
    }

    /// <summary>
    /// DetectAndDecode must throw ArgumentNullException when inputImage is null.
    /// Does not require model files.
    /// </summary>
    [Fact]
    public void DetectAndDecode_NullInput_ThrowsArgumentNullException()
    {
        using var qr = new OpenCvSharp.WeChatQRCode();
        Assert.Throws<ArgumentNullException>(() => qr.DetectAndDecode(null!, out _));
    }

    /// <summary>
    /// Grayscale image containing 2 QR codes. Both must be decoded correctly.
    /// </summary>
    [Fact]
    public void DetectAndDecode_WithModels_MultiQR_ReturnsTexts()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var src = Cv2.ImRead("_data/image/qr_multi.png", ImreadModes.Grayscale);

        var texts = qr.DetectAndDecode(src, out _);

        Assert.Equal(2, texts.Length);
        foreach (var text in texts)
        {
            testOutputHelper.WriteLine(text);
            Assert.NotEmpty(text);
        }
        Assert.Equal(
            ExpectedMultiQRTexts.OrderBy(x => x),
            texts.OrderBy(x => x));
    }

    /// <summary>
    /// Point2f[][] overload must return one array of 4 corners per detected QR code.
    /// </summary>
    [Fact]
    public void DetectAndDecode_WithModels_Point2fOverload_Returns4CornersPerQR()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var src = Cv2.ImRead("_data/image/qr_multi.png", ImreadModes.Grayscale);

        var texts = qr.DetectAndDecode(src, out var points);

        Assert.Equal(2, texts.Length);
        Assert.Equal(2, points.Length);
        foreach (var corners in points)
        {
            Assert.Equal(4, corners.Length);
        }
    }

    /// <summary>
    /// Mat[] overload (DetectAndDecodeRaw) must return one non-empty Mat per detected QR code,
    /// with 4 rows (corners) and 2 columns (x, y).
    /// </summary>
    [Fact]
    public void DetectAndDecodeRaw_WithModels_MatOverload_ReturnsCorrectShape()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var src = Cv2.ImRead("_data/image/qr_multi.png", ImreadModes.Grayscale);

        var texts = qr.DetectAndDecodeRaw(src, out var bbox);

        Assert.Equal(2, texts.Length);
        Assert.Equal(2, bbox.Length);
        foreach (var mat in bbox)
        {
            Assert.False(mat.Empty());
            // each corner mat stores 4 (x,y) values → Total() * Channels() == 8
            Assert.Equal(8, (int)(mat.Total() * mat.Channels()));
        }
    }

    /// <summary>
    /// QR code containing single-byte (ASCII) characters must decode to the expected string.
    /// </summary>
    [Fact]
    public void DetectAndDecode_WithModels_SinglebyteLetters()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var src = Cv2.ImRead("_data/image/qr_singlebyte_letters.png", ImreadModes.Grayscale);

        var texts = qr.DetectAndDecode(src, out _);

        Assert.Single(texts);
        Assert.Equal(
            "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[]^_`{|}",
            texts[0]);
    }

    /// <summary>
    /// QR code containing multibyte (Unicode) characters must decode to the expected string.
    /// </summary>
    [Fact]
    public void DetectAndDecode_WithModels_MultibyteLetters()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var src = Cv2.ImRead("_data/image/qr_multibyte_letters.png", ImreadModes.Grayscale);

        var texts = qr.DetectAndDecode(src, out _);

        Assert.Single(texts);
        Assert.Equal("Helloこんにちは你好안녕하세요", texts[0]);
    }

    /// <summary>
    /// detectAndDecode accepts a color (BGR) image in addition to grayscale.
    /// The result must be identical to processing the grayscale version.
    /// </summary>
    [Fact]
    public void DetectAndDecode_WithModels_ColorBGRImage_DetectsQR()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var colorSrc = Cv2.ImRead("_data/image/qr_multi.png", ImreadModes.Color);

        var texts = qr.DetectAndDecode(colorSrc, out _);

        Assert.Equal(2, texts.Length);
        Assert.Equal(
            ExpectedMultiQRTexts.OrderBy(x => x),
            texts.OrderBy(x => x));
    }

    /// <summary>
    /// An image that contains no QR codes must yield empty result arrays.
    /// </summary>
    [Fact]
    public void DetectAndDecode_WithModels_NoQRCode_ReturnsEmpty()
    {
        SkipIfModelFilesNotFound();

        using var qr = CreateWithModels();
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);

        var texts = qr.DetectAndDecode(src, out var points);

        Assert.Empty(texts);
        Assert.Empty(points);
    }

    // -------------------------------------------------------------------------

    private static OpenCvSharp.WeChatQRCode CreateWithModels() =>
        new(DetectorPrototxtPath, DetectorCaffeModelPath,
            SuperResolutionPrototxtPath, SuperResolutionCaffeModelPath);

    private static void SkipIfModelFilesNotFound()
    {
        Assert.True(File.Exists(DetectorPrototxtPath),       $"Model file not found: '{DetectorPrototxtPath}'");
        Assert.True(File.Exists(DetectorCaffeModelPath),     $"Model file not found: '{DetectorCaffeModelPath}'");
        Assert.True(File.Exists(SuperResolutionPrototxtPath),    $"Model file not found: '{SuperResolutionPrototxtPath}'");
        Assert.True(File.Exists(SuperResolutionCaffeModelPath),  $"Model file not found: '{SuperResolutionCaffeModelPath}'");
    }
}
