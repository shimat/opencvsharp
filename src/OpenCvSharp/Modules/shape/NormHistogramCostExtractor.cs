using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// A norm-based histogram cost extractor.
/// </summary>
public class NormHistogramCostExtractor : HistogramCostExtractor
{
    private NormHistogramCostExtractor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.shape_Ptr_HistogramCostExtractor_delete(p))) { }

    /// <summary>
    /// Creates a NormHistogramCostExtractor.
    /// </summary>
    /// <param name="flag">Distance norm type (e.g. DistanceTypes.L2).</param>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static NormHistogramCostExtractor Create(
        DistanceTypes flag = DistanceTypes.L2, int nDummies = 25, float defaultCost = 0.2f)
    {
        NativeMethods.HandleException(
            NativeMethods.shape_createNormHistogramCostExtractor(
                (int)flag, nDummies, defaultCost, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_HistogramCostExtractor_get(smartPtr, out var rawPtr));
        return new NormHistogramCostExtractor(smartPtr, rawPtr);
    }

    /// <summary>
    /// The norm flag used to compute distances between histograms.
    /// </summary>
    public DistanceTypes NormFlag
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_NormHistogramCostExtractor_getNormFlag(RawPtr, out var ret));
            GC.KeepAlive(this);
            return (DistanceTypes)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_NormHistogramCostExtractor_setNormFlag(RawPtr, (int)value));
            GC.KeepAlive(this);
        }
    }
}