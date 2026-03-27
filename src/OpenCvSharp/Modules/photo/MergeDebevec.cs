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
    private MergeDebevec(IntPtr p)
    {
        var rawPtr = NativeMethods.photo_Ptr_MergeDebevec_get(p);
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
            releaseAction: _ => NativeMethods.photo_Ptr_MergeDebevec_delete(p)));
    }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static MergeDebevec Create()
    {
        var ptr = NativeMethods.photo_createMergeDebevec();
        return new MergeDebevec(ptr);
    }

    }
