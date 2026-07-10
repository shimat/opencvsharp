using OpenCvSharp.Internal;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing TEBLID (Triplet-based Efficient Binary Local Image Descriptor),
/// an improvement over BEBLID that uses triplet loss, hard negative mining, and anchor swap.
/// </summary>
public class TEBLID : Feature2D
{
    /// <summary>
    ///
    /// </summary>
    private TEBLID(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_TEBLID_delete(p)))
    { }

    /// <summary>
    /// Creates the TEBLID descriptor.
    /// </summary>
    /// <param name="scaleFactor">Adjust the sampling window around detected keypoints:
    /// 1.00f should be the scale for ORB keypoints, 6.75f for SIFT detected keypoints,
    /// 6.25f (default) fits for KAZE/SURF detected keypoints,
    /// 5.00f should be the scale for AKAZE, MSD, AGAST, FAST, BRISK keypoints.</param>
    /// <param name="nBits">Determine the number of bits in the descriptor.</param>
    public static TEBLID Create(float scaleFactor, TeblidSize nBits = TeblidSize.Size256Bits)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_TEBLID_create(scaleFactor, (int)nBits, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_TEBLID_get(ptr, out var rawPtr));
        return new TEBLID(ptr, rawPtr);
    }
}
