using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The resulting HDR image is calculated as weighted average of the exposures considering exposure
/// values and camera response.
///
/// For more information see @cite DM97 .
/// </summary>
public sealed class MergeDebevec : MergeExposures
{
    /// <summary>
    /// Creates instance by MergeDebevec*
    /// </summary>
    private MergeDebevec(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.photo_Ptr_MergeDebevec_delete(p)))
    { }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static MergeDebevec Create()
    {
        NativeMethods.HandleException(NativeMethods.photo_createMergeDebevec(out var ptr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_MergeDebevec_get(ptr, out var rawPtr));
        return new MergeDebevec(ptr, rawPtr);
    }
}
