using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.StructuredLight;

/// <summary>Generates and decodes sinusoidal structured-light patterns.</summary>
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
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(parameters.NumberOfPeriods);
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

    /// <summary>Computes a wrapped phase map from captured sinusoidal patterns.</summary>
    public void ComputePhaseMap(IEnumerable<Mat> patternImages, OutputArray wrappedPhaseMap,
        OutputArray shadowMask = default, InputArray fundamental = default)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(patternImages);
        var images = patternImages.ToArray();
        using var input = new VectorOfMat(images);
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_computePhaseMap(
            Handle, input.CvPtr, wrappedPhaseMap.Proxy, shadowMask.Proxy, fundamental.Proxy));
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
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_unwrapPhaseMap(
            Handle, wrappedPhaseMap.Proxy, unwrappedPhaseMap.Proxy, cameraSize, shadowMask.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(wrappedPhaseMap.Source);
        GC.KeepAlive(unwrappedPhaseMap.Source);
        GC.KeepAlive(shadowMask.Source);
    }

    /// <summary>Finds projector-camera correspondences from unwrapped phase maps.</summary>
    public Mat[] FindProCamMatches(InputArray projectorPhase, InputArray cameraPhase)
    {
        ThrowIfDisposed();
        using var matches = new VectorOfMat();
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_findProCamMatches(
            Handle, projectorPhase.Proxy, cameraPhase.Proxy, matches.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(projectorPhase.Source);
        GC.KeepAlive(cameraPhase.Source);
        return matches.ToArray();
    }

    /// <summary>Computes the data modulation term from captured patterns.</summary>
    public void ComputeDataModulationTerm(IEnumerable<Mat> patternImages,
        OutputArray modulation, InputArray shadowMask)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(patternImages);
        var images = patternImages.ToArray();
        using var input = new VectorOfMat(images);
        NativeMethods.HandleException(NativeMethods.structured_light_SinusoidalPattern_computeDataModulationTerm(
            Handle, input.CvPtr, modulation.Proxy, shadowMask.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(images);
        GC.KeepAlive(modulation.Source);
        GC.KeepAlive(shadowMask.Source);
    }
}
