using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The Base Class for Background/Foreground Segmentation.
/// The class is only used to define the common interface for
/// the whole family of background/foreground segmentation algorithms.
/// </summary>
public abstract class BackgroundSubtractor : Algorithm
{
    /// <inheritdoc />
    protected BackgroundSubtractor(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// the update operator that takes the next video frame and returns the current foreground mask as 8-bit binary image.
    /// </summary>
    /// <param name="image"></param>
    /// <param name="fgmask"></param>
    /// <param name="learningRate"></param>
    public virtual void Apply(InputArrayRef image, OutputArrayRef fgmask, double learningRate = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.video_BackgroundSubtractor_apply(Handle, image.Proxy, fgmask.Proxy, learningRate));
            
        GC.KeepAlive(image.Source);
        GC.KeepAlive(fgmask.Source);
    }

    /// <summary>
    /// computes a background image
    /// </summary>
    /// <param name="backgroundImage"></param>
    public virtual void GetBackgroundImage(OutputArrayRef backgroundImage)
    {
        NativeMethods.HandleException(
            NativeMethods.video_BackgroundSubtractor_getBackgroundImage(Handle, backgroundImage.Proxy));
        GC.KeepAlive(backgroundImage.Source);
    }
}
