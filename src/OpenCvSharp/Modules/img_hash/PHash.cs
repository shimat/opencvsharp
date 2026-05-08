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
    private PHash(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_PHash_delete(p)))
    { }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static PHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_PHash_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_PHash_get(smartPtr, out var rawPtr));
        return new PHash(smartPtr, rawPtr);
    }
        
    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />

    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }
}
