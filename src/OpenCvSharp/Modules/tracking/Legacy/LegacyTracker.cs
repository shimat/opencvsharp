using OpenCvSharp.Internal;

namespace OpenCvSharp.Tracking.Legacy;

/// <summary>
/// Base abstract class for the long-term tracker, mirroring <c>cv::legacy::Tracker</c>.
/// </summary>
/// <remarks>
/// This is a distinct type from <see cref="OpenCvSharp.Tracker"/> (the modern, video-module tracker
/// base): <c>cv::legacy::Tracker::init</c>/<c>update</c> return <see langword="bool"/> (not
/// <see langword="void"/>) and operate on <see cref="Rect2d"/> (not <see cref="Rect"/>), so the two
/// hierarchies cannot share a common managed base class.
/// </remarks>
public abstract class LegacyTracker : Algorithm
{
    /// <inheritdoc />
    protected LegacyTracker(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> releaseSmartPtr)
        : base(smartPtr, rawPtr, releaseSmartPtr)
    {
    }

    /// <summary>
    /// Initialize the tracker with a known bounding box that surrounded the target.
    /// </summary>
    /// <param name="image">The initial frame</param>
    /// <param name="boundingBox">The initial bounding box</param>
    /// <returns>True if initialization went successfully, false otherwise</returns>
    public bool Init(Mat image, Rect2d boundingBox)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_Tracker_init(RawPtr, image.CvPtr, boundingBox, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);

        return ret != 0;
    }

    /// <summary>
    /// Update the tracker, find the new most likely bounding box for the target.
    /// </summary>
    /// <param name="image">The current frame</param>
    /// <param name="boundingBox">
    /// The bounding box that represents the new target location, if true was returned, not modified otherwise
    /// </param>
    /// <returns>
    /// True means that target was located and false means that tracker cannot locate target in the
    /// current frame. Note that the latter *does not* imply that tracker has failed - the target may
    /// indeed be missing from the frame (say, out of sight).
    /// </returns>
    public bool Update(Mat image, ref Rect2d boundingBox)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_Tracker_update(RawPtr, image.CvPtr, ref boundingBox, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);

        return ret != 0;
    }
}
