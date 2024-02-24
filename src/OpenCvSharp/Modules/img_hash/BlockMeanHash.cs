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
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    protected BlockMeanHash(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Create BlockMeanHash object
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static BlockMeanHash Create(BlockMeanHashMode mode = BlockMeanHashMode.Mode0)
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_BlockMeanHash_create((int)mode, out var p));
        return new BlockMeanHash(p);
    }
        
    /// <inheritdoc />
    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mode"></param>
    public void SetMode(BlockMeanHashMode mode)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.img_hash_BlockMeanHash_setMode(ptr, (int)mode));
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
            NativeMethods.img_hash_BlockMeanHash_getMean(ptr, meanVec.CvPtr));
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

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_BlockMeanHash_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.img_hash_Ptr_BlockMeanHash_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
