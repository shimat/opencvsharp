using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// A chi-squared based histogram cost extractor.
/// </summary>
public class ChiHistogramCostExtractor : HistogramCostExtractor
{
    private ChiHistogramCostExtractor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.shape_Ptr_HistogramCostExtractor_delete(p))) { }

    /// <summary>
    /// Creates a ChiHistogramCostExtractor.
    /// </summary>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static ChiHistogramCostExtractor Create(int nDummies = 25, float defaultCost = 0.2f)
    {
        NativeMethods.HandleException(
            NativeMethods.shape_createChiHistogramCostExtractor(
                nDummies, defaultCost, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_HistogramCostExtractor_get(smartPtr, out var rawPtr));
        return new ChiHistogramCostExtractor(smartPtr, rawPtr);
    }
}