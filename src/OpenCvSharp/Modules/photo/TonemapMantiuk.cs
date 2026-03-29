using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// This algorithm transforms image to contrast using gradients on all levels of gaussian pyramid,
/// transforms contrast values to HVS response and scales the response. After this the image is
/// reconstructed from new contrast values.
///
/// For more information see @cite MM06.
/// </summary>
public sealed class TonemapMantiuk : Tonemap
{
    private TonemapMantiuk(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.photo_Ptr_TonemapMantiuk_delete(p)))
    { }

    /// <summary>
    /// Creates TonemapMantiuk object
    /// </summary>
    /// <param name="gamma">positive value for gamma correction. Gamma value of 1.0 implies no correction, gamma
    /// equal to 2.2f is suitable for most displays.
    /// Generally gamma &gt; 1 brightens the image and gamma &lt; 1 darkens it.</param>
    /// <param name="scale">contrast scale factor. HVS response is multiplied by this parameter, thus compressing
    /// dynamic range. Values from 0.6 to 0.9 produce best results.</param>
    /// <param name="saturation"></param>
    /// <returns></returns>
    public static TonemapMantiuk Create(float gamma = 1.0f, float scale = 0.7f, float saturation = 1.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createTonemapMantiuk(gamma, scale, saturation, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.photo_Ptr_TonemapMantiuk_get(smartPtr, out var rawPtr));
        return new TonemapMantiuk(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gets or sets contrast scale factor. HVS response is multiplied by this parameter, thus compressing
    /// dynamic range. Values from 0.6 to 0.9 produce best results.
    /// </summary>
    public float Scale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_getScale(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_setScale(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets positive saturation enhancement value. 1.0 preserves saturation, values greater 
    /// than 1 increase saturation and values less than 1 decrease it.
    /// </summary>
    public float Saturation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_getSaturation(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_setSaturation(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
