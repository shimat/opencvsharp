namespace OpenCvSharp;

/// <summary>
/// Image warper factories base class. Instances of concrete subclasses are handed to
/// <see cref="Stitcher.SetWarper"/> to select the projection used by the stitching pipeline;
/// for standalone warping, use <see cref="PyRotationWarper"/> instead.
/// </summary>
public abstract class WarperCreator : CvObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="rawPtr"></param>
    /// <param name="release"></param>
    private protected WarperCreator(IntPtr rawPtr, Action<IntPtr> release) : base(rawPtr)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true, releaseAction: release));
    }
}
