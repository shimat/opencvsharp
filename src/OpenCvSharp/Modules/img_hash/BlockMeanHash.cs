using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Image hash based on block mean.
/// </summary>
public class BlockMeanHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    private BlockMeanHash(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_BlockMeanHash_delete(p)))
    { }
    /// <summary>
    /// Create BlockMeanHash object
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static BlockMeanHash Create(BlockMeanHashMode mode = BlockMeanHashMode.Mode0)
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_BlockMeanHash_create((int)mode, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_BlockMeanHash_get(smartPtr, out var rawPtr));
        return new BlockMeanHash(smartPtr, rawPtr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mode"></param>
    public void SetMode(BlockMeanHashMode mode)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.img_hash_BlockMeanHash_setMode(CvPtr, (int)mode));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public double[] GetMean()
    {
        ThrowIfDisposed();
        using var meanVec = new VectorOfDouble();
        NativeMethods.HandleException(
            NativeMethods.img_hash_BlockMeanHash_getMean(CvPtr, meanVec.CvPtr));
        GC.KeepAlive(this);
        return meanVec.ToArray();
    }
        
    /*
    /// <inheritdoc />
    /// <summary>
    /// Computes block mean hash of the input image
    /// </summary>
    /// <param name="inputArr">input image want to compute hash value, type should be CV_8UC4, CV_8UC3 or CV_8UC1.</param>
    /// <param name="outputArr">Hash value of input, it will contain 16 hex decimal number, return type is CV_8U</param>
    /// <returns></returns>
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }*/
}
