using Xunit;

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace OpenCvSharp.Tests.Barcode;

public class BarcodeDetectorTest : TestBase
{
    // -----------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------

    /// <summary>
    /// Default constructor (no super-resolution model) must succeed.
    /// </summary>
    [Fact]
    public void Constructor_Default()
    {
        using var bd = new BarcodeDetector();
    }

    /// <summary>
    /// Explicit empty-string paths (equivalent to default constructor) must succeed.
    /// </summary>
    [Fact]
    public void Constructor_EmptyPaths()
    {
        using var bd = new BarcodeDetector("", "");
    }

    // -----------------------------------------------------------------------
    // Argument validation
    // -----------------------------------------------------------------------

    [Fact]
    public void DetectAndDecode_NullImage_ThrowsArgumentNullException()
    {
        using var bd = new BarcodeDetector();
        Assert.Throws<ArgumentNullException>(
            () => bd.DetectAndDecode(null!, out _, out _, out _));
    }

    [Fact]
    public void SetDetectorScales_NullArgument_ThrowsArgumentNullException()
    {
        using var bd = new BarcodeDetector();
        Assert.Throws<ArgumentNullException>(
            () => bd.SetDetectorScales(null!));
    }

    // -----------------------------------------------------------------------
    // Setters — smoke tests (must not throw)
    // -----------------------------------------------------------------------

    [Fact]
    public void SetDownsamplingThreshold_ValidValue()
    {
        using var bd = new BarcodeDetector();
        bd.SetDownsamplingThreshold(256);
    }

    [Fact]
    public void SetGradientThreshold_ValidValue()
    {
        using var bd = new BarcodeDetector();
        bd.SetGradientThreshold(128);
    }

    [Fact]
    public void SetDetectorScales_ValidSizes()
    {
        using var bd = new BarcodeDetector();
        bd.SetDetectorScales([0.01f, 0.03f, 0.06f, 0.08f]);
    }

    // -----------------------------------------------------------------------
    // DetectAndDecode — functional tests
    // -----------------------------------------------------------------------

    /// <summary>
    /// A plain white image contains no barcode.
    /// DetectAndDecode must return without crashing and produce empty output arrays.
    /// This test also serves as a regression check for issue #1863
    /// (crash with STATUS_STACK_BUFFER_OVERRUN on any call to DetectAndDecode).
    /// </summary>
    [Fact]
    public void DetectAndDecode_PlainImage_ReturnsEmpty()
    {
        using var bd = new BarcodeDetector();
        // Image must be > 40 x 40 to pass the internal checkBarInputImage guard.
        using var img = new Mat(100, 100, MatType.CV_8UC3, Scalar.White);

        bd.DetectAndDecode(img, out var points, out var results, out var types);

        Assert.Empty(points);
        Assert.Empty(results);
        Assert.Empty(types);
    }

    /// <summary>
    /// DetectAndDecode on an image that is smaller than the minimum required size
    /// (40 x 40) must return empty results rather than throw or crash.
    /// </summary>
    [Fact]
    public void DetectAndDecode_TooSmallImage_ReturnsEmpty()
    {
        using var bd = new BarcodeDetector();
        using var img = new Mat(30, 30, MatType.CV_8UC1, Scalar.Black);

        bd.DetectAndDecode(img, out var points, out var results, out var types);

        Assert.Empty(points);
        Assert.Empty(results);
        Assert.Empty(types);
    }

    /// <summary>
    /// DetectAndDecode must work correctly on a grayscale (single-channel) image.
    /// </summary>
    [Fact]
    public void DetectAndDecode_GrayscaleImage_ReturnsEmpty()
    {
        using var bd = new BarcodeDetector();
        using var img = new Mat(100, 100, MatType.CV_8UC1, new Scalar(128));

        bd.DetectAndDecode(img, out var points, out var results, out var types);

        Assert.Empty(points);
        Assert.Empty(results);
        Assert.Empty(types);
    }

    /// <summary>
    /// Simulates a barcode-like striped pattern. The detector should not crash
    /// even if it fails to decode the synthetic pattern.
    /// This is the core regression test for issue #1863.
    /// </summary>
    [Fact]
    public void DetectAndDecode_StripedPattern_DoesNotCrash()
    {
        using var bd = new BarcodeDetector();
        using var img = CreateStripedBarcodeImage(width: 300, height: 100);

        // Must not throw or crash — result (found or not) is secondary.
        bd.DetectAndDecode(img, out var points, out var results, out var types);

        Assert.Equal(results.Length * 4, points.Length);
        Assert.Equal(results.Length, types.Length);
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    /// <summary>
    /// Creates a synthetic image with alternating black/white vertical stripes,
    /// resembling a 1-D barcode, to exercise the detection code path.
    /// </summary>
    private static Mat CreateStripedBarcodeImage(int width, int height)
    {
        var img = new Mat(height, width, MatType.CV_8UC3, Scalar.White);
        // Draw ~30 alternating stripes of varying widths.
        var stripeWidths = new[] { 3, 5, 3, 8, 3, 5, 8, 3, 5, 3, 8, 5, 3, 3, 5 };
        int x = 20;
        bool black = true;
        foreach (int sw in stripeWidths)
        {
            if (black)
            {
                Cv2.Rectangle(img,
                    new Point(x, height / 4),
                    new Point(x + sw - 1, height * 3 / 4),
                    Scalar.Black, thickness: -1);
            }
            x += sw;
            black = !black;
            if (x >= width - 20)
                break;
        }
        return img;
    }
}
