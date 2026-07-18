using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// The MIL algorithm trains a classifier in an online manner to separate the object from the
/// background. Multiple Instance Learning avoids the drift problem for a robust tracking.
/// Mirrors <c>cv::legacy::TrackerMIL</c> (as opposed to the modern, video-module
/// <see cref="OpenCvSharp.TrackerMIL"/>).
/// </summary>
// ReSharper disable once InconsistentNaming
public class TrackerMIL : LegacyTracker
{
    private TrackerMIL(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMIL_delete(p)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public static TrackerMIL Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerMIL_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMIL_get(smartPtr, out var rawPtr));
        return new TrackerMIL(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">MIL parameters TrackerMIL::Params</param>
    public static TrackerMIL Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerMIL_create2(ref parameters, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMIL_get(smartPtr, out var rawPtr));
        return new TrackerMIL(smartPtr, rawPtr);
    }

#pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary>
    /// TrackerMIL parameters. Layout matches <c>cv::legacy::TrackerMIL::Params</c>
    /// (which just re-exposes <c>cv::TrackerMIL::Params</c>).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
        /// <summary>
        /// radius for gathering positive instances during init
        /// </summary>
        public float SamplerInitInRadius;

        /// <summary>
        /// # negative samples to use during init
        /// </summary>
        public int SamplerInitMaxNegNum;

        /// <summary>
        /// size of search window
        /// </summary>
        public float SamplerSearchWinSize;

        /// <summary>
        /// radius for gathering positive instances during tracking
        /// </summary>
        public float SamplerTrackInRadius;

        /// <summary>
        /// # positive samples to use during tracking
        /// </summary>
        public int SamplerTrackMaxPosNum;

        /// <summary>
        /// # negative samples to use during tracking
        /// </summary>
        public int SamplerTrackMaxNegNum;

        /// <summary>
        /// # features
        /// </summary>
        public int FeatureSetNumFeatures;
    }
#pragma warning restore CA1051
}
