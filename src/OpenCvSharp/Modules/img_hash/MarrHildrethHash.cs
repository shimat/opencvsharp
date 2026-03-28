using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// Marr-Hildreth Operator Based Hash, slowest but more discriminative.
/// </summary>
public class MarrHildrethHash : ImgHashBase
{
    /// <summary>
    /// cv::Ptr&lt;T&gt;
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    private MarrHildrethHash(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_MarrHildrethHash_delete(p)))
    { }
    /// <summary>
    /// Create BlockMeanHash object
    /// </summary>
    /// <param name="alpha">int scale factor for marr wavelet (default=2).</param>
    /// <param name="scale">int level of scale factor (default = 1)</param>
    /// <returns></returns>
    public static MarrHildrethHash Create(float alpha = 2.0f, float scale = 1.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_MarrHildrethHash_create(alpha, scale, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.img_hash_Ptr_MarrHildrethHash_get(smartPtr, out var rawPtr));
        return new MarrHildrethHash(smartPtr, rawPtr);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="alpha">int scale factor for marr wavelet (default=2).</param>
    /// <param name="scale">int level of scale factor (default = 1)</param>
    public void SetKernelParam(float alpha = 2.0f, float scale = 1.0f)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.img_hash_MarrHildrethHash_setKernelParam(CvPtr, alpha, scale));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// int scale factor for marr wavelet (default=2).
    /// </summary>
    public float Alpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_getAlpha(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_getScale(CvPtr, out var scale));
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_setKernelParam(CvPtr, value, scale));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// int level of scale factor (default = 1)
    /// </summary>
    public float Scale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_getScale(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_getAlpha(CvPtr, out var alpha));
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_setKernelParam(CvPtr, alpha, value));
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
