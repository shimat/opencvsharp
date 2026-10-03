using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.StructuredLight;

/// <summary>Generates sinusoidal structured-light patterns and computes their phase maps.</summary>
public sealed class SinusoidalPattern : StructuredLightPattern
{
    private SinusoidalPattern(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.structured_light_Ptr_SinusoidalPattern_delete(p)))
    {
    }

    /// <summary>Creates a sinusoidal pattern generator.</summary>
    public static SinusoidalPattern Create(SinusoidalPatternParams? parameters = null)
    {
        parameters ??= new SinusoidalPatternParams();
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(parameters.Width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(parameters.Height);
        ArgumentOutOfRangeException.ThrowIfLessThan(parameters.NumberOfPeriods, 3);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(parameters.NumberOfPeriods,
            parameters.Horizontal ? parameters.Height : parameters.Width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(parameters.PixelsBetweenMarkers);
        if (parameters.SetMarkers)
        {
            var period = (parameters.Horizontal ? parameters.Height : parameters.Width) / parameters.NumberOfPeriods;
            ArgumentOutOfRangeException.ThrowIfLessThan(period, 2);
            var rows = parameters.Horizontal ? parameters.Width : parameters.Height;
            var cols = parameters.Horizontal ? parameters.Height : parameters.Width;
            var markersPerRow = Math.Max(0, (rows - 10) / parameters.PixelsBetweenMarkers);
            if (markersPerRow > 0)
            {
                var n = parameters.NumberOfPeriods / 3;
                var lastRow = 10L + (long)(markersPerRow - 1) * parameters.PixelsBetweenMarkers +
                              (long)(n - 1) * (parameters.PixelsBetweenMarkers / n);
                var firstColumn = 3 * period / 4;
                var lastColumn = 3L * period / 4 + (long)(n - 1) * period +
                                 2L * period * n - 2 * period / 3;
                if (lastRow >= rows - 1 || firstColumn < 1 || lastColumn >= cols - 1)
                    throw new ArgumentOutOfRangeException(nameof(parameters),
                        "Marker centers must leave space for their four neighboring pixels.");
            }
        }
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_create(
            parameters.Width, parameters.Height, parameters.NumberOfPeriods,
            parameters.ShiftValue, (int) parameters.Method,
            parameters.PixelsBetweenMarkers, parameters.Horizontal ? 1 : 0,
            parameters.SetMarkers ? 1 : 0, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.structured_light_Ptr_SinusoidalPattern_get(
            smartPtr, out var rawPtr));
        return new SinusoidalPattern(smartPtr, rawPtr);
    }

    /// <summary>OpenCV 5.0.0 does not implement sinusoidal disparity decoding.</summary>
    public override bool Decode(IEnumerable<IEnumerable<Mat>> patternImages, OutputArray disparityMap,
        IEnumerable<Mat> blackImages, IEnumerable<Mat> whiteImages)
    {
        ThrowIfDisposed();
        throw new NotSupportedException("OpenCV 5.0.0 does not implement SinusoidalPattern.Decode.");
    }

    /// <summary>Computes a wrapped phase map from three CV_8UC1 patterns. The destination must be empty.</summary>
    public void ComputePhaseMap(IEnumerable<Mat> patternImages, OutputArray wrappedPhaseMap,
        OutputArray shadowMask = default, InputArray fundamental = default)
    {
        ThrowIfDisposed();
        RequireMat(wrappedPhaseMap.Proxy.Kind, nameof(wrappedPhaseMap));
        var images = PreparePatternImages(patternImages);
        var size = images[0].Size();
        if (Cv2.GetOptimalDFTSize(size.Width) != size.Width || Cv2.GetOptimalDFTSize(size.Height) != size.Height)
            throw new ArgumentException("Pattern image dimensions must be optimal DFT sizes for OpenCV 5.0.0.",
                nameof(patternImages));
        if (!((Mat)wrappedPhaseMap.Source!).Empty())
            throw new ArgumentException("The phase destination must be empty for OpenCV 5.0.0.",
                nameof(wrappedPhaseMap));
        using var temporaryMask = shadowMask.Proxy.Kind == (int)ArrayProxyKind.None ? new Mat() : null;
        var effectiveMask = temporaryMask is null ? shadowMask : OutputArray.Create(temporaryMask);
        RequireMat(effectiveMask.Proxy.Kind, nameof(shadowMask));
        using var input = new VectorOfMat(images);
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_computePhaseMap(
            Handle, input.CvPtr, wrappedPhaseMap.Proxy, effectiveMask.Proxy, fundamental.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(wrappedPhaseMap.Source);
        GC.KeepAlive(shadowMask.Source);
        GC.KeepAlive(fundamental.Source);
    }

    /// <summary>Unwraps a phase map to remove phase ambiguities.</summary>
    public void UnwrapPhaseMap(InputArray wrappedPhaseMap, OutputArray unwrappedPhaseMap,
        Size cameraSize, InputArray shadowMask = default)
    {
        ThrowIfDisposed();
        RequireMat(wrappedPhaseMap.Proxy.Kind, nameof(wrappedPhaseMap));
        RequireMat(unwrappedPhaseMap.Proxy.Kind, nameof(unwrappedPhaseMap));
        if (cameraSize.Width <= 0 || cameraSize.Height <= 0)
            throw new ArgumentOutOfRangeException(nameof(cameraSize));
        ValidateInputMat((Mat)wrappedPhaseMap.Source!, cameraSize, MatType.CV_32FC1,
            nameof(wrappedPhaseMap));
        ValidateOutputMat((Mat)unwrappedPhaseMap.Source!, cameraSize, MatType.CV_32FC1,
            nameof(unwrappedPhaseMap));
        if (shadowMask.Proxy.Kind != (int)ArrayProxyKind.None)
        {
            RequireMat(shadowMask.Proxy.Kind, nameof(shadowMask));
            ValidateInputMat((Mat)shadowMask.Source!, cameraSize, MatType.CV_8UC1, nameof(shadowMask));
        }
        using var temporaryMask = shadowMask.Proxy.Kind == (int)ArrayProxyKind.None
            ? new Mat(cameraSize, MatType.CV_8UC1, Scalar.All(255)) : null;
        var effectiveMask = temporaryMask is null ? shadowMask : (InputArray)temporaryMask;
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_unwrapPhaseMap(
            Handle, wrappedPhaseMap.Proxy, unwrappedPhaseMap.Proxy, cameraSize, effectiveMask.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(wrappedPhaseMap.Source);
        GC.KeepAlive(unwrappedPhaseMap.Source);
        GC.KeepAlive(shadowMask.Source);
    }

    /// <summary>OpenCV 5.0.0 does not implement projector-camera matching.</summary>
    public Mat[] FindProCamMatches(InputArray projectorPhase, InputArray cameraPhase)
    {
        ThrowIfDisposed();
        throw new NotSupportedException("OpenCV 5.0.0 does not implement SinusoidalPattern.FindProCamMatches.");
    }

    /// <summary>Computes the data modulation term from captured patterns.</summary>
    public void ComputeDataModulationTerm(IEnumerable<Mat> patternImages,
        OutputArray modulation, InputArray shadowMask)
    {
        ThrowIfDisposed();
        RequireMat(modulation.Proxy.Kind, nameof(modulation));
        RequireMat(shadowMask.Proxy.Kind, nameof(shadowMask));
        var images = PreparePatternImages(patternImages);
        var size = images[0].Size();
        if (size.Width < 4 || size.Height < 4)
            throw new ArgumentException("Pattern images must be at least 4 by 4 pixels.", nameof(patternImages));
        ValidateOutputMat((Mat)modulation.Source!, size, MatType.CV_8UC1, nameof(modulation));
        var mask = (Mat)shadowMask.Source!;
        if (!mask.Empty())
            ValidateInputMat(mask, size, MatType.CV_8UC1, nameof(shadowMask));
        using var input = new VectorOfMat(images);
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_computeDataModulationTerm(
            Handle, input.CvPtr, modulation.Proxy, shadowMask.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(modulation.Source);
        GC.KeepAlive(shadowMask.Source);
    }

    private static Mat[] PreparePatternImages(IEnumerable<Mat> patternImages)
    {
        ArgumentNullException.ThrowIfNull(patternImages);
        var images = patternImages.ToArray();
        if (images.Length != 3)
            throw new ArgumentException("Exactly three pattern images are required.", nameof(patternImages));
        foreach (var image in images)
        {
            ArgumentNullException.ThrowIfNull(image);
            image.ThrowIfDisposed();
        }
        var size = images[0].Size();
        var type = images[0].Type();
        if (size.Width <= 0 || size.Height <= 0 || type != MatType.CV_8UC1)
            throw new ArgumentException("Pattern images must be nonempty CV_8UC1 matrices.", nameof(patternImages));
        foreach (var image in images)
        {
            if (image.Size() != size || image.Type() != type)
                throw new ArgumentException("Pattern images must have the same size and type.", nameof(patternImages));
        }
        return images;
    }

    private static void RequireMat(int kind, string parameterName)
    {
        if (kind != (int)ArrayProxyKind.Mat)
            throw new ArgumentException("OpenCV 5.0.0 requires a Mat for this parameter.", parameterName);
    }

    private static void ValidateInputMat(Mat mat, Size size, MatType type, string parameterName)
    {
        if (mat.Empty() || mat.Size() != size || mat.Type() != type)
            throw new ArgumentException($"Expected a nonempty {type} Mat of size {size}.", parameterName);
    }

    private static void ValidateOutputMat(Mat mat, Size size, MatType type, string parameterName)
    {
        if (!mat.Empty())
            ValidateInputMat(mat, size, type, parameterName);
    }
}
