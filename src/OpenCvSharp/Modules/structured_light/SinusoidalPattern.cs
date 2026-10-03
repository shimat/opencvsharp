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

    /// <summary>Computes a wrapped phase map from captured sinusoidal patterns.</summary>
    public void ComputePhaseMap(IEnumerable<Mat> patternImages, OutputArray wrappedPhaseMap,
        OutputArray shadowMask = default, InputArray fundamental = default)
    {
        ThrowIfDisposed();
        RequireMat(wrappedPhaseMap.Proxy.Kind, nameof(wrappedPhaseMap));
        var images = PreparePatternImages(patternImages, allowFloat: false);
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
        if (shadowMask.Proxy.Kind != (int)ArrayProxyKind.None)
            RequireMat(shadowMask.Proxy.Kind, nameof(shadowMask));
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_unwrapPhaseMap(
            Handle, wrappedPhaseMap.Proxy, unwrappedPhaseMap.Proxy, cameraSize, shadowMask.Proxy));
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
        var images = PreparePatternImages(patternImages, allowFloat: true);
        using var input = new VectorOfMat(images);
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_computeDataModulationTerm(
            Handle, input.CvPtr, modulation.Proxy, shadowMask.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(modulation.Source);
        GC.KeepAlive(shadowMask.Source);
    }

    private static Mat[] PreparePatternImages(IEnumerable<Mat> patternImages, bool allowFloat)
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
        if (size.Width <= 0 || size.Height <= 0 ||
            (type != MatType.CV_8UC1 && (!allowFloat || type != MatType.CV_32FC1)))
            throw new ArgumentException("Pattern images must be nonempty CV_8UC1 or CV_32FC1 matrices.", nameof(patternImages));
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
}
