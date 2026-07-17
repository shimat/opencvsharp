using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// Base class for the long-term multi-object trackers. Mirrors <c>cv::legacy::MultiTracker_Alt</c>.
/// </summary>
/// <remarks>
/// Unlike <see cref="MultiTracker"/>, <c>cv::legacy::MultiTracker_Alt</c> does not derive from
/// <c>cv::Algorithm</c> and has no <c>create()</c> factory - it is a plain, directly-constructed
/// C++ class with public fields, so this wrapper follows the direct-allocation
/// (<see cref="CvObject"/>-based) pattern instead of the <see cref="CvPtrObject"/>/<c>cv::Ptr</c>
/// factory pattern used elsewhere in this module.
/// </remarks>
public class MultiTrackerAlt : CvObject
{
    /// <summary>
    /// Constructor for Multitracker.
    /// </summary>
    public MultiTrackerAlt()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_Alt_new(out var p));
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Constructor for a subclass (<see cref="MultiTrackerTLD"/>) that has already allocated the
    /// native object via its own, distinct native constructor.
    /// </summary>
    /// <param name="ptr">Already-allocated native pointer.</param>
    private protected MultiTrackerAlt(IntPtr ptr)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_Alt_delete(CvPtr));
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// Add a new target to a tracking-list and initialize the tracker with a known bounding box
    /// that surrounded the target.
    /// </summary>
    /// <param name="image">The initial frame</param>
    /// <param name="boundingBox">The initial bounding box of target</param>
    /// <param name="trackerAlgorithm">Multi-tracker algorithm</param>
    /// <returns>True if new target initialization went successfully, false otherwise</returns>
    public bool AddTarget(Mat image, Rect2d boundingBox, LegacyTracker trackerAlgorithm)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(trackerAlgorithm);
        image.ThrowIfDisposed();
        trackerAlgorithm.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_Alt_addTarget(
                Handle, image.CvPtr, boundingBox, trackerAlgorithm.SmartPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);
        GC.KeepAlive(trackerAlgorithm);

        return ret != 0;
    }

    /// <summary>
    /// Update all trackers from the tracking-list, find a new most likely bounding boxes for the targets.
    /// </summary>
    /// <param name="image">The current frame</param>
    /// <returns>
    /// True means that all targets were located and false means that tracker couldn't locate one of
    /// the targets in the current frame. Note that the latter *does not* imply that tracker has
    /// failed - the target may indeed be missing from the frame (say, out of sight).
    /// </returns>
    public bool Update(Mat image)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_Alt_update(Handle, image.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);

        return ret != 0;
    }

    /// <summary>
    /// Current number of targets in tracking-list.
    /// </summary>
    public int TargetNum
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.tracking_legacy_MultiTracker_Alt_targetNum(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Bounding boxes list for Multi-Object-Tracker.
    /// </summary>
    public Rect2d[] BoundingBoxes
    {
        get
        {
            ThrowIfDisposed();
            using var result = new StdVector<Rect2d>();
            NativeMethods.HandleException(
                NativeMethods.tracking_legacy_MultiTracker_Alt_boundingBoxes(Handle, result.CvPtr));
            GC.KeepAlive(this);
            return result.ToArray();
        }
    }
}
