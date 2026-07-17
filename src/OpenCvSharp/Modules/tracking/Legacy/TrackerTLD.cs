using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// The TLD (Tracking, learning and detection) tracker: explicitly decomposes the long-term
/// tracking task into tracking, learning and detection. Mirrors <c>cv::legacy::TrackerTLD</c>.
/// There is no modern (non-legacy) equivalent of this tracker.
/// </summary>
/// <remarks>
/// <c>cv::legacy::TrackerTLD::Params</c> carries no data members (default constructor only), so
/// there is no parameterized <see cref="Create()"/> overload here - just the default factory.
/// </remarks>
// ReSharper disable once InconsistentNaming
public class TrackerTLD : LegacyTracker
{
    private TrackerTLD(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerTLD_delete(p)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public static TrackerTLD Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_TrackerTLD_create1(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_TrackerTLD_get(smartPtr, out var rawPtr));
        return new TrackerTLD(smartPtr, rawPtr);
    }
}
