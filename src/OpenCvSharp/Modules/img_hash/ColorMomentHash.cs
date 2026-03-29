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
    private ColorMomentHash(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_ColorMomentHash_delete(p)))
    { }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static ColorMomentHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_ColorMomentHash_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_ColorMomentHash_get(smartPtr, out var rawPtr));
        return new ColorMomentHash(smartPtr, rawPtr);
    }

    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }
}
