using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <summary>
/// Free functions from <c>cv::legacy::</c> that don't belong to a single class.
/// </summary>
public static class LegacyTrackingApi
{
    /// <summary>
    /// Upgrades a <see cref="LegacyTracker"/> (<c>cv::legacy::Tracker</c>) to the modern,
    /// video-module <see cref="OpenCvSharp.Tracker"/> API. Mirrors <c>cv::legacy::upgradeTrackingAPI</c>.
    /// </summary>
    /// <param name="legacyTracker">The legacy tracker to upgrade.</param>
    /// <returns>A modern <see cref="OpenCvSharp.Tracker"/> wrapping the same underlying algorithm.</returns>
    public static Tracker Upgrade(LegacyTracker legacyTracker)
    {
        ArgumentNullException.ThrowIfNull(legacyTracker);
        legacyTracker.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_upgradeTrackingAPI(legacyTracker.SmartPtr, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_UpgradedTracker_get(smartPtr, out var rawPtr));
        GC.KeepAlive(legacyTracker);

        return new UpgradedTracker(smartPtr, rawPtr);
    }
}

/// <summary>
/// Minimal concrete <see cref="OpenCvSharp.Tracker"/> wrapping a <c>cv::Ptr&lt;cv::Tracker&gt;</c>
/// produced by <see cref="LegacyTrackingApi.Upgrade"/>. <see cref="OpenCvSharp.Tracker"/> has no
/// public constructor that wraps an arbitrary, already-existing native pointer, so this small
/// concrete subclass exists solely to provide one.
/// </summary>
internal sealed class UpgradedTracker : Tracker
{
    internal UpgradedTracker(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_UpgradedTracker_delete(p)))
    {
    }
}
