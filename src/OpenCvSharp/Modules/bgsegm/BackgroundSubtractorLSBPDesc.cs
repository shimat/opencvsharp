using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// This is for calculation of the LSBP descriptors.
/// </summary>
public static class BackgroundSubtractorLSBPDesc
{
    /// <summary>
    /// Number of sample points the native LSBP algorithm always expects in lsbpSamplePoints.
    /// </summary>
    private const int RequiredSamplePointCount = 32;

    /// <summary>
    /// Calculates the local SVD values used internally by <see cref="ComputeFromLocalSVDValues"/>.
    /// </summary>
    /// <param name="localSVDValues">output local SVD values.</param>
    /// <param name="frame">input frame.</param>
    public static void CalcLocalSVDValues(OutputArray localSVDValues, Mat frame)
    {
        ArgumentNullException.ThrowIfNull(frame);

        NativeMethods.HandleException(
            NativeMethods.bgsegm_BackgroundSubtractorLSBPDesc_calcLocalSVDValues(localSVDValues.Proxy, frame.CvPtr));

        GC.KeepAlive(localSVDValues.Source);
        GC.KeepAlive(frame);
    }

    /// <summary>
    /// Computes the LSBP descriptor from precomputed local SVD values.
    /// </summary>
    /// <param name="desc">output descriptor.</param>
    /// <param name="localSVDValues">local SVD values, as computed by <see cref="CalcLocalSVDValues"/>.</param>
    /// <param name="lsbpSamplePoints">the 32 sample points used by the LSBP algorithm.</param>
    public static void ComputeFromLocalSVDValues(OutputArray desc, Mat localSVDValues, Point[] lsbpSamplePoints)
    {
        ArgumentNullException.ThrowIfNull(localSVDValues);
        ArgumentNullException.ThrowIfNull(lsbpSamplePoints);
        if (lsbpSamplePoints.Length != RequiredSamplePointCount)
            throw new ArgumentException($"lsbpSamplePoints must have exactly {RequiredSamplePointCount} elements.", nameof(lsbpSamplePoints));

        NativeMethods.HandleException(
            NativeMethods.bgsegm_BackgroundSubtractorLSBPDesc_computeFromLocalSVDValues(
                desc.Proxy, localSVDValues.CvPtr, lsbpSamplePoints));

        GC.KeepAlive(desc.Source);
        GC.KeepAlive(localSVDValues);
    }

    /// <summary>
    /// Computes the LSBP descriptor directly from a frame.
    /// </summary>
    /// <param name="desc">output descriptor.</param>
    /// <param name="frame">input frame.</param>
    /// <param name="lsbpSamplePoints">the 32 sample points used by the LSBP algorithm.</param>
    public static void Compute(OutputArray desc, Mat frame, Point[] lsbpSamplePoints)
    {
        ArgumentNullException.ThrowIfNull(frame);
        ArgumentNullException.ThrowIfNull(lsbpSamplePoints);
        if (lsbpSamplePoints.Length != RequiredSamplePointCount)
            throw new ArgumentException($"lsbpSamplePoints must have exactly {RequiredSamplePointCount} elements.", nameof(lsbpSamplePoints));

        NativeMethods.HandleException(
            NativeMethods.bgsegm_BackgroundSubtractorLSBPDesc_compute(desc.Proxy, frame.CvPtr, lsbpSamplePoints));

        GC.KeepAlive(desc.Source);
        GC.KeepAlive(frame);
    }
}
