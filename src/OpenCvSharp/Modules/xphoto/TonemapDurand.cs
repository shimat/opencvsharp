using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.XPhoto;

/// <summary>
/// This algorithm decomposes image into two layers: base layer and detail layer using bilateral filter
/// and compresses contrast of the base layer thus preserving all the details.
///
/// This implementation uses regular bilateral filter from OpenCV.
///
/// Saturation enhancement is possible as in cv::TonemapDrago.
///
/// For more information see @cite DD02 .
/// </summary>
public sealed class TonemapDurand : Tonemap
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    private TonemapDurand(IntPtr ptrObjPtr)
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
    /// Creates TonemapDurand object
    /// </summary>
    /// <param name="gamma">positive value for gamma correction. Gamma value of 1.0 implies no correction, gamma
    /// equal to 2.2f is suitable for most displays.
    /// Generally gamma &gt; 1 brightens the image and gamma &lt; 1 darkens it.</param>
    /// <param name="contrast">resulting contrast on logarithmic scale, i. e. log(max / min), where max and min</param>
    /// <param name="saturation">positive saturation enhancement value. 1.0 preserves saturation, values greater 
    /// than 1 increase saturation and values less than 1 decrease it.</param>
    /// <param name="sigmaSpace">bilateral filter sigma in coordinate space</param>
    /// <param name="sigmaColor">bilateral filter sigma in color space</param>
    /// <returns></returns>
    public static TonemapDurand Create(
        float gamma = 1.0f, float contrast = 4.0f, float saturation = 1.0f, float sigmaSpace = 2.0f, float sigmaColor = 2.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.xphoto_createTonemapDurand(gamma, contrast, saturation, sigmaSpace, sigmaColor, out var ptr));
        return new TonemapDurand(ptr);
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
    /// Gets or sets positive saturation enhancement value. 1.0 preserves saturation, values greater 
    /// than 1 increase saturation and values less than 1 decrease it.
    /// </summary>
    public float Saturation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_getSaturation(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_setSaturation(ptr, value));
            GC.KeepAlive(this);
        }
    }
        
    /// <summary>
    /// Gets or sets resulting contrast on logarithmic scale, i. e. log(max / min), where max and min
    /// </summary>
    public float Contrast
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_getContrast(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_setContrast(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets bilateral filter sigma in coordinate space
    /// </summary>
    public float SigmaSpace
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_getSigmaSpace(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_setSigmaSpace(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Gets or sets bilateral filter sigma in color space
    /// </summary>
    public float SigmaColor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_getSigmaColor(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.xphoto_TonemapDurand_setSigmaColor(ptr, value));
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
                NativeMethods.xphoto_Ptr_TonemapDurand_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.xphoto_Ptr_TonemapDurand_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
