using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.StructuredLight;

/// <summary>
/// Gray-code structured-light pattern generator and decoder.
/// </summary>
public sealed class GrayCodePattern : StructuredLightPattern
{
    private GrayCodePattern(IntPtr smartPtr, IntPtr rawPtr)
        : base(
            smartPtr,
            rawPtr,
            static p => NativeMethods.HandleException(
                NativeMethods.structured_light_Ptr_GrayCodePattern_delete(p)))
    {
    }

    /// <summary>
    /// Creates a Gray-code pattern for a projector resolution.
    /// </summary>
    /// <param name="width">Projector width.</param>
    /// <param name="height">Projector height.</param>
    public static GrayCodePattern Create(int width = 1024, int height = 768)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);

        NativeMethods.HandleException(
            NativeMethods.structured_light_GrayCodePattern_create(
                width,
                height,
                out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.structured_light_Ptr_GrayCodePattern_get(
                smartPtr,
                out var rawPtr));
        return new GrayCodePattern(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gets the number of Gray-code images required for projection and decoding.
    /// </summary>
    public int GetNumberOfPatternImages()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.structured_light_GrayCodePattern_getNumberOfPatternImages(
                Handle,
                out var returnValue));
        GC.KeepAlive(this);
        return returnValue;
    }

    /// <summary>
    /// Sets the minimum brightness difference between a pattern and its inverse.
    /// </summary>
    public void SetWhiteThreshold(int value)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 255);

        NativeMethods.HandleException(
            NativeMethods.structured_light_GrayCodePattern_setWhiteThreshold(
                Handle,
                value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets the minimum brightness difference between white and black reference images.
    /// </summary>
    public void SetBlackThreshold(int value)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 255);

        NativeMethods.HandleException(
            NativeMethods.structured_light_GrayCodePattern_setBlackThreshold(
                Handle,
                value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Generates black and white images used to compute shadow masks.
    /// </summary>
    public void GetImagesForShadowMasks(
        OutputArray blackImage,
        OutputArray whiteImage)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.structured_light_GrayCodePattern_getImagesForShadowMasks(
                Handle,
                blackImage.Proxy,
                whiteImage.Proxy));

        GC.KeepAlive(this);
        GC.KeepAlive(blackImage.Source);
        GC.KeepAlive(whiteImage.Source);
    }

    /// <summary>
    /// Decodes the projector coordinate corresponding to a camera pixel.
    /// </summary>
    /// <param name="patternImages">Captured Gray-code pattern sequence.</param>
    /// <param name="x">Camera pixel x coordinate.</param>
    /// <param name="y">Camera pixel y coordinate.</param>
    /// <param name="projectorPixel">Decoded projector coordinate.</param>
    /// <returns>True when the coordinate is decoded successfully.</returns>
    public bool TryGetProjectorPixel(
        IEnumerable<Mat> patternImages,
        int x,
        int y,
        out Point projectorPixel)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(patternImages);
        ArgumentOutOfRangeException.ThrowIfNegative(x);
        ArgumentOutOfRangeException.ThrowIfNegative(y);

        var patternImageArray = patternImages.ToArray();
        if (patternImageArray.Length != GetNumberOfPatternImages())
            throw new ArgumentException(
                "The image sequence length does not match the Gray-code pattern.",
                nameof(patternImages));
        foreach (var image in patternImageArray)
        {
            ArgumentNullException.ThrowIfNull(image);
            image.ThrowIfDisposed();
        }

        using var patternImageVector = new VectorOfMat(patternImageArray);
        NativeMethods.HandleException(
            NativeMethods.structured_light_GrayCodePattern_getProjectorPixel(
                Handle,
                patternImageVector.CvPtr,
                x,
                y,
                out projectorPixel,
                out var returnValue));

        GC.KeepAlive(this);
        GC.KeepAlive(patternImageArray);
        return returnValue != 0;
    }
}
