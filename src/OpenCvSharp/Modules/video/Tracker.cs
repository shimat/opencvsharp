using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base abstract class for the long-term tracker
/// </summary>
public abstract class Tracker : Algorithm
{
    internal Ptr? PtrObj { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ptrObj"></param>
    protected Tracker(Ptr ptrObj)
    {
        PtrObj = ptrObj ?? throw new ArgumentNullException(nameof(ptrObj));
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        PtrObj?.Dispose();
        PtrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// Initialize the tracker with a know bounding box that surrounding the target
    /// </summary>
    /// <param name="image">The initial frame</param>
    /// <param name="boundingBox">The initial bounding box</param>
    /// <returns></returns>
    public void Init(Mat image, Rect boundingBox)
    {
        ThrowIfDisposed();

        if (image is null)
            throw new ArgumentNullException(nameof(image));

        image.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.video_Tracker_init(ptr, image.CvPtr, boundingBox));
        GC.KeepAlive(this);
        GC.KeepAlive(image);
    }

    /// <summary>
    /// Update the tracker, find the new most likely bounding box for the target
    /// </summary>
    /// <param name="image">The current frame</param>
    /// <param name="boundingBox">The bounding box that represent the new target location, if true was returned, not modified otherwise</param>
    /// <returns>True means that target was located and false means that tracker cannot locate target in 
    /// current frame.Note, that latter *does not* imply that tracker has failed, maybe target is indeed 
    /// missing from the frame (say, out of sight)</returns>
    public bool Update(Mat image, ref Rect boundingBox)
    {
        ThrowIfDisposed();

        if (image is null)
            throw new ArgumentNullException(nameof(image));

        image.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.video_Tracker_update(ptr, image.CvPtr, ref boundingBox, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(image);

        return ret != 0;
    }
}
