using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Image hash based on Radon transform.
/// </summary>
public class RadialVarianceHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    private RadialVarianceHash(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_RadialVarianceHash_delete(p)))
    { }
    /// <summary>
    /// Create BlockMeanHash object
    /// </summary>
    /// <param name="sigma">Gaussian kernel standard deviation</param>
    /// <param name="numOfAngleLine">The number of angles to consider</param>
    /// <returns></returns>
    public static RadialVarianceHash Create(double sigma = 1, int numOfAngleLine = 180)
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_RadialVarianceHash_create(sigma, numOfAngleLine, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_RadialVarianceHash_get(smartPtr, out var rawPtr));
        return new RadialVarianceHash(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gaussian kernel standard deviation
    /// </summary>
    public double Sigma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_getSigma(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_setSigma(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The number of angles to consider
    /// </summary>
    public int NumOfAngleLine
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_getNumOfAngleLine(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_RadialVarianceHash_setNumOfAngleLine(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
        
    // ReSharper disable once RedundantOverriddenMember
    /// <inheritdoc />
    public override void Compute(InputArray inputArr, OutputArray outputArr)
    {
        base.Compute(inputArr, outputArr);
    }
}
