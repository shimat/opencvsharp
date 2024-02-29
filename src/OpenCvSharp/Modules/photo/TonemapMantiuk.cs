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
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    private TonemapMantiuk(IntPtr ptrObjPtr)
        : base(GetEntityPointer(ptrObjPtr, out var po))
    {
        ptrObj = po;
    }

    private static IntPtr GetEntityPointer(IntPtr ptrObjPtr, out Ptr ptrObj)
    {
        ptrObj = new Ptr(ptrObjPtr);
        return ptrObj.Get();
    }

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
            NativeMethods.photo_createTonemapMantiuk(gamma, scale, saturation, out var ptr));
        return new TonemapMantiuk(ptr);
    }

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
    /// Gets or sets contrast scale factor. HVS response is multiplied by this parameter, thus compressing
    /// dynamic range. Values from 0.6 to 0.9 produce best results.
    /// </summary>
    public float Scale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_getScale(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_setScale(ptr, value));
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
                NativeMethods.photo_TonemapMantiuk_getSaturation(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapMantiuk_setSaturation(ptr, value));
            GC.KeepAlive(this);
        }
    }
        
    private class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_TonemapMantiuk_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_TonemapMantiuk_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
