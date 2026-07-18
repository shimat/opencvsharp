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
    public virtual void Apply(InputArray image, OutputArray fgmask, double learningRate = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.video_BackgroundSubtractor_apply(Handle, image.Proxy, fgmask.Proxy, learningRate));

        GC.KeepAlive(image.Source);
        GC.KeepAlive(fgmask.Source);
    }

    /// <summary>
    /// Computes a foreground mask with known foreground mask input.
    /// This method has a default virtual implementation that throws a "not implemented" error in
    /// OpenCV. Foreground masking may not be supported by all background subtractors.
    /// </summary>
    /// <param name="image">Next video frame. Floating point frame will be used without scaling and should be in range [0,255].</param>
    /// <param name="knownForegroundMask">The mask for inputting already known foreground, allows model to ignore pixels.</param>
    /// <param name="fgmask">The output foreground mask as an 8-bit binary image.</param>
    /// <param name="learningRate"></param>
    public virtual void Apply(InputArray image, InputArray knownForegroundMask, OutputArray fgmask, double learningRate = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.video_BackgroundSubtractor_applyWithMask(Handle, image.Proxy, knownForegroundMask.Proxy, fgmask.Proxy, learningRate));

        GC.KeepAlive(image.Source);
        GC.KeepAlive(knownForegroundMask.Source);
        GC.KeepAlive(fgmask.Source);
    }

    /// <summary>
    /// computes a background image
    /// </summary>
    /// <param name="backgroundImage"></param>
    public virtual void GetBackgroundImage(OutputArray backgroundImage)
    {
        NativeMethods.HandleException(
            NativeMethods.video_BackgroundSubtractor_getBackgroundImage(Handle, backgroundImage.Proxy));
        GC.KeepAlive(backgroundImage.Source);
    }
}
