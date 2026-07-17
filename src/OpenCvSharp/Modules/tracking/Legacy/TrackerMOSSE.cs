using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// The MOSSE (Minimum Output Sum of Squared Error) tracker. Mirrors <c>cv::legacy::TrackerMOSSE</c>.
/// There is no modern (non-legacy) equivalent of this tracker.
/// </summary>
/// <remarks>
/// This tracker works with grayscale images; if passed BGR ones, they get converted internally.
/// <c>cv::legacy::TrackerMOSSE::create()</c> takes no arguments, so there is no <c>Params</c> type.
/// </remarks>
// ReSharper disable once InconsistentNaming
public class TrackerMOSSE : LegacyTracker
{
    private TrackerMOSSE(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMOSSE_delete(p)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public static TrackerMOSSE Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerMOSSE_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerMOSSE_get(smartPtr, out var rawPtr));
        return new TrackerMOSSE(smartPtr, rawPtr);
    }
}
