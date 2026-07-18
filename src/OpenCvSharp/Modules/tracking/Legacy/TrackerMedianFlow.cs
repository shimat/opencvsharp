using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// The Median Flow tracker. Suitable for very smooth and predictable movements when the object is
/// visible throughout the whole sequence. Mirrors <c>cv::legacy::TrackerMedianFlow</c>. There is no
/// modern (non-legacy) equivalent of this tracker.
/// </summary>
// ReSharper disable once InconsistentNaming
public class TrackerMedianFlow : LegacyTracker
{
    private TrackerMedianFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMedianFlow_delete(p)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public static TrackerMedianFlow Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerMedianFlow_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMedianFlow_get(smartPtr, out var rawPtr));
        return new TrackerMedianFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">Median Flow parameters TrackerMedianFlow::Params</param>
    public static TrackerMedianFlow Create(Params parameters)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerMedianFlow_create2(ref parameters, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMedianFlow_get(smartPtr, out var rawPtr));
        return new TrackerMedianFlow(smartPtr, rawPtr);
    }

#pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary>
    /// TrackerMedianFlow parameters. Layout matches <c>cv::legacy::TrackerMedianFlow::Params</c>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Params
    {
        /// <summary>
        /// square root of number of keypoints used; increase it to trade accurateness for speed
        /// </summary>
        public int PointsInGrid;

        /// <summary>
        /// window size parameter for Lucas-Kanade optical flow
        /// </summary>
        public Size WinSize;

        /// <summary>
        /// maximal pyramid level number for Lucas-Kanade optical flow
        /// </summary>
        public int MaxLevel;

        /// <summary>
        /// termination criteria for Lucas-Kanade optical flow
        /// </summary>
        public TermCriteria TermCriteria;

        /// <summary>
        /// window size around a point for normalized cross-correlation check
        /// </summary>
        public Size WinSizeNCC;

        /// <summary>
        /// criterion for losing the tracked object
        /// </summary>
        public double MaxMedianLengthOfDisplacementDifference;
    }
#pragma warning restore CA1051
}
