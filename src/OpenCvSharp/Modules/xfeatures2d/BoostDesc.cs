using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing BoostDesc (Learning Image Descriptors with Boosting).
/// </summary>
public class BoostDesc : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private BoostDesc(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BoostDesc_delete(p)))
    { }

    /// <summary>
    /// Creates the BoostDesc descriptor.
    /// </summary>
    /// <param name="desc">Type of descriptor to use.</param>
    /// <param name="useScaleOrientation">Sample patterns using keypoints orientation.</param>
    /// <param name="scaleFactor">Adjust the sampling window of detected keypoints.</param>
    public static BoostDesc Create(
        BoostDescType desc = BoostDescType.Binboost256,
        bool useScaleOrientation = true, float scaleFactor = 6.25f)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_BoostDesc_create((int)desc, useScaleOrientation ? 1 : 0, scaleFactor, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BoostDesc_get(ptr, out var rawPtr));
        return new BoostDesc(ptr, rawPtr);
    }

    /// <summary>
    /// Sample patterns using keypoints orientation.
    /// </summary>
    public bool UseScaleOrientation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_BoostDesc_getUseScaleOrientation(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_BoostDesc_setUseScaleOrientation(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Adjust the sampling window of detected keypoints.
    /// </summary>
    public float ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_BoostDesc_getScaleFactor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_BoostDesc_setScaleFactor(Handle, value));
        }
    }
}
