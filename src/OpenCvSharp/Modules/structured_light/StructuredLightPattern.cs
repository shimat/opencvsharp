using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.StructuredLight;

/// <summary>
/// Abstract base class for generating and decoding structured-light patterns.
/// </summary>
public abstract class StructuredLightPattern : Algorithm
{
    /// <summary>
    /// Initializes a structured-light pattern wrapper.
    /// </summary>
    protected StructuredLightPattern(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release)
    {
    }

    /// <summary>
    /// Generates the pattern images to project.
    /// </summary>
    /// <returns>CV_8U images at projector resolution.</returns>
    public virtual Mat[] Generate()
    {
        ThrowIfDisposed();

        using var patternImages = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.structured_light_StructuredLightPattern_generate(
                Handle,
                patternImages.CvPtr,
                out var returnValue));

        GC.KeepAlive(this);
        if (returnValue == 0)
            throw new OpenCvSharpException("Structured-light pattern generation failed.");
        return patternImages.ToArray();
    }

    /// <summary>
    /// Decodes structured-light images captured by a stereo camera pair.
    /// </summary>
    /// <param name="patternImages">Two sets of captured pattern images, one set for each camera.</param>
    /// <param name="disparityMap">Output CV_64F disparity map.</param>
    /// <param name="blackImages">Black reference image for each camera.</param>
    /// <param name="whiteImages">White reference image for each camera.</param>
    /// <returns>True when decoding succeeds.</returns>
    public virtual bool Decode(
        IEnumerable<IEnumerable<Mat>> patternImages,
        OutputArray disparityMap,
        IEnumerable<Mat> blackImages,
        IEnumerable<Mat> whiteImages)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(patternImages);
        ArgumentNullException.ThrowIfNull(blackImages);
        ArgumentNullException.ThrowIfNull(whiteImages);

        var patterns = patternImages
            .Select(cameraImages => cameraImages?.ToArray() ??
                throw new ArgumentException("A camera image sequence is null.", nameof(patternImages)))
            .ToArray();
        if (patterns.Length != 2)
            throw new ArgumentException("Exactly two camera image sequences are required.", nameof(patternImages));
        if (patterns.Any(cameraImages => cameraImages.Length == 0))
            throw new ArgumentException("Camera image sequences must not be empty.", nameof(patternImages));
        if (patterns[0].Length != patterns[1].Length)
            throw new ArgumentException("Camera image sequences must have the same length.", nameof(patternImages));

        var blackImageArray = blackImages.ToArray();
        var whiteImageArray = whiteImages.ToArray();
        if (blackImageArray.Length != patterns.Length)
            throw new ArgumentException("One black reference image is required for each camera.", nameof(blackImages));
        if (whiteImageArray.Length != patterns.Length)
            throw new ArgumentException("One white reference image is required for each camera.", nameof(whiteImages));

        foreach (var image in patterns.SelectMany(static images => images)
                     .Concat(blackImageArray)
                     .Concat(whiteImageArray))
        {
            ArgumentNullException.ThrowIfNull(image);
            image.ThrowIfDisposed();
        }

        var patternPointers = patterns
            .Select(cameraImages => cameraImages.Select(static image => image.CvPtr).ToArray())
            .ToArray();
        using var patternAddresses = new ArrayAddress2<IntPtr>(patternPointers);
        using var blackImageVector = new VectorOfMat(blackImageArray);
        using var whiteImageVector = new VectorOfMat(whiteImageArray);

        NativeMethods.HandleException(
            NativeMethods.structured_light_StructuredLightPattern_decode(
                Handle,
                patternAddresses.GetPointer(),
                patternAddresses.GetDim2Lengths(),
                patternAddresses.GetDim1Length(),
                blackImageVector.CvPtr,
                whiteImageVector.CvPtr,
                disparityMap.Proxy,
                out var returnValue));

        GC.KeepAlive(this);
        GC.KeepAlive(patterns);
        GC.KeepAlive(blackImageArray);
        GC.KeepAlive(whiteImageArray);
        GC.KeepAlive(disparityMap.Source);
        return returnValue != 0;
    }
}
