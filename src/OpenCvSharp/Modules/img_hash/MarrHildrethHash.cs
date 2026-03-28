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
    protected MarrHildrethHash(IntPtr p)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.img_hash_Ptr_MarrHildrethHash_delete(p))));
    }

    /// <summary>
    /// Create BlockMeanHash object
    /// </summary>
    /// <param name="alpha">int scale factor for marr wavelet (default=2).</param>
    /// <param name="scale">int level of scale factor (default = 1)</param>
    /// <returns></returns>
    public static MarrHildrethHash Create(float alpha = 2.0f, float scale = 1.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.img_hash_MarrHildrethHash_create(alpha, scale, out var p));
        return new MarrHildrethHash(p);
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
            NativeMethods.img_hash_MarrHildrethHash_setKernelParam(ptr, alpha, scale));
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
                NativeMethods.img_hash_MarrHildrethHash_getAlpha(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_getScale(ptr, out var scale));
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_setKernelParam(ptr, value, scale));
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
                NativeMethods.img_hash_MarrHildrethHash_getScale(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_getAlpha(ptr, out var alpha));
            NativeMethods.HandleException(
                NativeMethods.img_hash_MarrHildrethHash_setKernelParam(ptr, alpha, value));
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
