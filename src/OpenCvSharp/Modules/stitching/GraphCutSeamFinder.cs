using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp.Detail;

/// <summary>
/// Minimum graph cut-based seam estimator.
/// </summary>
public class GraphCutSeamFinder : SeamFinder
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="costType"></param>
    /// <param name="terminalCost"></param>
    /// <param name="badRegionPenalty"></param>
    public GraphCutSeamFinder(
        SeamFinderCostFunction costType = SeamFinderCostFunction.ColorGrad,
        float terminalCost = 10000f,
        float badRegionPenalty = 1000f)
        : base(Create(costType, terminalCost, badRegionPenalty), static h =>
            NativeMethods.HandleException(NativeMethods.stitching_GraphCutSeamFinder_delete(h)))
    {
    }

    private static IntPtr Create(SeamFinderCostFunction costType, float terminalCost, float badRegionPenalty)
    {
        // GraphCutSeamFinder parses "COST_COLOR"/"COST_COLOR_GRAD" (its own GraphCutSeamFinderBase::CostType
        // enum names), unlike DpSeamFinder's "COLOR"/"COLOR_GRAD" - see opencv/modules/stitching/src/seam_finders.cpp.
        var nativeString = costType switch
        {
            SeamFinderCostFunction.Color => "COST_COLOR",
            SeamFinderCostFunction.ColorGrad => "COST_COLOR_GRAD",
            _ => throw new ArgumentOutOfRangeException(nameof(costType), costType, null),
        };
        NativeMethods.HandleException(
            NativeMethods.stitching_GraphCutSeamFinder_new(nativeString, terminalCost, badRegionPenalty, out var ptr));
        return ptr;
    }

    /// <inheritdoc />
    public override void Find(IEnumerable<Mat> src, IReadOnlyList<Point> corners, IEnumerable<Mat> masks)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(corners);
        ArgumentNullException.ThrowIfNull(masks);

        var srcArray = src.CastOrToArray();
        var cornersArray = corners as Point[] ?? [.. corners];
        var masksArray = masks.CastOrToArray();
        var srcPtrs = srcArray.Select(m => m.CvPtr).ToArray();
        var masksPtrs = masksArray.Select(m => m.CvPtr).ToArray();

        NativeMethods.HandleException(
            NativeMethods.stitching_GraphCutSeamFinder_find(
                Handle, srcPtrs, srcPtrs.Length, cornersArray, cornersArray.Length, masksPtrs, masksPtrs.Length));

        GC.KeepAlive(srcArray);
        GC.KeepAlive(masksArray);
    }
}
