using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Computes average hash value of the input image.
/// This is a fast image hashing algorithm, but only work on simple case. For more details, 
/// please refer to @cite lookslikeit
/// </summary>
public class AverageHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    protected AverageHash(IntPtr p)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_AverageHash_delete(p))));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static AverageHash Create()
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_AverageHash_create(out var p));
        return new AverageHash(p);
    }

    /*
    /// <inheritdoc />
    /// <param name="inputArr">input image want to compute hash value, type should be CV_8UC4, CV_8UC3 or CV_8UC1.</param>
    /// <param name="outputArr">Hash value of input, it will contain 16 hex decimal number, return type is CV_8U</param>
    /// <returns></returns>
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }*/
}
