using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Image hash based on color moments.
/// </summary>
public class ColorMomentHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    protected ColorMomentHash(IntPtr p)
    {
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_ColorMomentHash_get(p, out var rawPtr));
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_ColorMomentHash_delete(p))));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static ColorMomentHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_ColorMomentHash_create(out var p));
        return new ColorMomentHash(p);
    }

    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }
}
