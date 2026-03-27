using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// pHash: Slower than average_hash, but tolerant of minor modifications.
/// This algorithm can combat more variation than averageHash, for more details please refer to @cite lookslikeit
/// </summary>
// ReSharper disable once InconsistentNaming
public class PHash : ImgHashBase
{
    /// <summary>
    /// 
    /// </summary>
    protected PHash(IntPtr p)
    {
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_PHash_get(p, out var rawPtr));
        SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_PHash_delete(p))));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static PHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_PHash_create(out var p));
        return new PHash(p);
    }
        
    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />

    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }
}
