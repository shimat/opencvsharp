using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// Multi-object tracker for TLD (Tracking, learning and detection). Mirrors
/// <c>cv::legacy::MultiTrackerTLD</c>, which adds a single optimized update method on top of
/// <c>cv::legacy::MultiTracker_Alt</c> (<see cref="MultiTrackerAlt"/>).
/// </summary>
/// <remarks>
/// Every target added via <see cref="MultiTrackerAlt.AddTarget"/> must be a <see cref="TrackerTLD"/>
/// instance: <see cref="UpdateOpt"/>'s native implementation <c>static_cast</c>s each tracked object
/// to the TLD implementation type without checking it, so passing any other <see cref="LegacyTracker"/>
/// subclass is undefined behavior (in practice, a crash) rather than a catchable error. This mirrors
/// the upstream C++ API's own documented pairing (<c>@sa Tracker, MultiTracker, TrackerTLD</c>) -
/// use the type-agnostic <see cref="MultiTracker"/> or <see cref="MultiTrackerAlt"/> instead if you
/// need to mix tracker algorithms.
/// </remarks>
public sealed class MultiTrackerTLD : MultiTrackerAlt
{
    /// <summary>
    /// Constructor for Multitracker-TLD.
    /// </summary>
    public MultiTrackerTLD()
        : base(NewTLD())
    {
    }

    private static IntPtr NewTLD()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTrackerTLD_new(out var p));
        return p;
    }

    /// <summary>
    /// Deletes through <c>tracking_legacy_MultiTrackerTLD_delete</c> (this object's own static
    /// type) rather than the inherited <see cref="MultiTrackerAlt"/> delete: see
    /// <see cref="MultiTrackerAlt.DeleteNative"/> for why.
    /// </summary>
    private protected override void DeleteNative(IntPtr obj)
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTrackerTLD_delete(obj));
    }

    /// <summary>
    /// Update all trackers from the tracking-list, finding new most likely bounding boxes for the
    /// targets using an optimized update method that speeds up calculations specifically for
    /// multi-object TLD. The only limitation is that all target bounding boxes should have
    /// approximately the same aspect ratio. Speed boost is around 20%.
    /// </summary>
    /// <param name="image">The current frame.</param>
    /// <returns>
    /// True means that all targets were located and false means that tracker couldn't locate one of
    /// the targets in the current frame. Note that the latter *does not* imply that tracker has
    /// failed - the target may indeed be missing from the frame (say, out of sight).
    /// </returns>
    public bool UpdateOpt(Mat image)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTrackerTLD_updateOpt(Handle, image.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);

        return ret != 0;
    }
}
