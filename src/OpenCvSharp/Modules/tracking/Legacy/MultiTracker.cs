using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Tracking.Legacy;

/// <inheritdoc />
/// <summary>
/// Tracks multiple objects using the specified <see cref="LegacyTracker"/> algorithm for each one.
/// This is a naive implementation: tracked objects are processed independently, with no
/// optimization across them. Mirrors <c>cv::legacy::MultiTracker</c>.
/// </summary>
public class MultiTracker : Algorithm
{
    private MultiTracker(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_MultiTracker_delete(p)))
    {
    }

    /// <summary>
    /// Returns a pointer to a new instance of MultiTracker.
    /// </summary>
    public static MultiTracker Create()
    {
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.tracking_legacy_Ptr_MultiTracker_get(smartPtr, out var rawPtr));
        return new MultiTracker(smartPtr, rawPtr);
    }

    /// <summary>
    /// Add a new object to be tracked.
    /// </summary>
    /// <param name="newTracker">tracking algorithm to be used</param>
    /// <param name="image">input image</param>
    /// <param name="boundingBox">a rectangle represents ROI of the tracked object</param>
    public bool Add(LegacyTracker newTracker, Mat image, Rect2d boundingBox)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(newTracker);
        ArgumentNullException.ThrowIfNull(image);
        newTracker.ThrowIfDisposed();
        image.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_add(RawPtr, newTracker.SmartPtr, image.CvPtr, boundingBox, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(newTracker);
        GC.KeepAlive(image);

        return ret != 0;
    }

    /// <summary>
    /// Update the current tracking status. The result will be saved in the internal storage.
    /// </summary>
    /// <param name="image">input image</param>
    public bool Update(Mat image)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(image);
        image.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_update(RawPtr, image.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);

        return ret != 0;
    }

    /// <summary>
    /// Returns the storage for the tracked objects, each object corresponds to one tracker algorithm.
    /// </summary>
    public Rect2d[] GetObjects()
    {
        ThrowIfDisposed();

        using var result = new StdVector<Rect2d>();
        NativeMethods.HandleException(
            NativeMethods.tracking_legacy_MultiTracker_getObjects(RawPtr, result.CvPtr));
        GC.KeepAlive(this);

        return result.ToArray();
    }
}
