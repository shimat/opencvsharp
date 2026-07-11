using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing BEBLID (Boosted Efficient Binary Local Image Descriptor),
/// a binary descriptor learned with boosting.
/// </summary>
public class BEBLID : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private BEBLID(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BEBLID_delete(p)))
    { }

    /// <summary>
    /// Creates the BEBLID descriptor.
    /// </summary>
    /// <param name="scaleFactor">Adjust the sampling window around detected keypoints:
    /// 1.00f should be the scale for ORB keypoints, 6.75f for SIFT detected keypoints,
    /// 6.25f (default) fits for KAZE/SURF detected keypoints,
    /// 5.00f should be the scale for AKAZE, MSD, AGAST, FAST, BRISK keypoints.</param>
    /// <param name="nBits">Determine the number of bits in the descriptor.</param>
    public static BEBLID Create(float scaleFactor, BeblidSize nBits = BeblidSize.Size512Bits)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_BEBLID_create(scaleFactor, (int)nBits, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_BEBLID_get(ptr, out var rawPtr));
        return new BEBLID(ptr, rawPtr);
    }

    /// <summary>
    /// Adjust the sampling window around detected keypoints.
    /// </summary>
    public float ScaleFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_BEBLID_getScaleFactor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xfeatures2d_BEBLID_setScaleFactor(Handle, value));
        }
    }
}
