using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// An EMD-L1 based histogram cost extractor.
/// </summary>
public class EMDL1HistogramCostExtractor : HistogramCostExtractor
{
    private EMDL1HistogramCostExtractor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(
            NativeMethods.shape_Ptr_HistogramCostExtractor_delete(p))) { }

    /// <summary>
    /// Creates an EMDL1HistogramCostExtractor.
    /// </summary>
    /// <param name="nDummies">Number of dummy histogram bins. Default: 25.</param>
    /// <param name="defaultCost">Default cost for dummy bins. Default: 0.2.</param>
    public static EMDL1HistogramCostExtractor Create(int nDummies = 25, float defaultCost = 0.2f)
    {
        NativeMethods.HandleException(
            NativeMethods.shape_createEMDL1HistogramCostExtractor(
                nDummies, defaultCost, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.shape_Ptr_HistogramCostExtractor_get(smartPtr, out var rawPtr));
        return new EMDL1HistogramCostExtractor(smartPtr, rawPtr);
    }
}