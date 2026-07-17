using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// The Boosting tracker: a real-time object tracker based on a novel on-line version of the
/// AdaBoost algorithm. Mirrors <c>cv::legacy::TrackerBoosting</c>. There is no modern (non-legacy)
/// equivalent of this tracker.
/// </summary>
// ReSharper disable once InconsistentNaming
public class TrackerBoosting : LegacyTracker
{
    private TrackerBoosting(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerBoosting_delete(p)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public static TrackerBoosting Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerBoosting_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerBoosting_get(smartPtr, out var rawPtr));
        return new TrackerBoosting(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">BOOSTING parameters TrackerBoosting::Params</param>
    public static TrackerBoosting Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerBoosting_create2(ref parameters, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerBoosting_get(smartPtr, out var rawPtr));
        return new TrackerBoosting(smartPtr, rawPtr);
    }

#pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary>
    /// TrackerBoosting parameters. Layout matches <c>cv::legacy::TrackerBoosting::Params</c>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
        /// <summary>
        /// the number of classifiers to use in a OnlineBoosting algorithm
        /// </summary>
        public int NumClassifiers;

        /// <summary>
        /// search region parameters to use in a OnlineBoosting algorithm
        /// </summary>
        public float SamplerOverlap;

        /// <summary>
        /// search region parameters to use in a OnlineBoosting algorithm
        /// </summary>
        public float SamplerSearchFactor;

        /// <summary>
        /// the initial iterations
        /// </summary>
        public int IterationInit;

        /// <summary>
        /// # features
        /// </summary>
        public int FeatureSetNumFeatures;
    }
#pragma warning restore CA1051
}
