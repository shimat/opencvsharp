using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// Adaptive logarithmic mapping is a fast global tonemapping algorithm that scales the image in logarithmic domain.
///
/// Since it's a global operator the same function is applied to all the pixels, it is controlled by the bias parameter.
/// Optional saturation enhancement is possible as described in @cite FL02. For more information see @cite DM03.
/// </summary>
public sealed class TonemapDrago : Tonemap
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    private TonemapDrago(IntPtr ptrObjPtr)
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
    /// Creates TonemapDrago object
    /// </summary>
    /// <param name="gamma">positive value for gamma correction. Gamma value of 1.0 implies no correction, gamma
    /// equal to 2.2f is suitable for most displays.
    /// Generally gamma &gt; 1 brightens the image and gamma &lt; 1 darkens it.</param>
    /// <param name="saturation">positive saturation enhancement value. 1.0 preserves saturation, values greater 
    /// than 1 increase saturation and values less than 1 decrease it.</param>
    /// <param name="bias">value for bias function in [0, 1] range. Values from 0.7 to 0.9 usually give best 
    /// results, default value is 0.85.</param>
    /// <returns></returns>
    public static TonemapDrago Create(float gamma = 1.0f, float saturation = 1.0f, float bias = 0.85f)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createTonemapDrago(gamma, saturation, bias, out var ptr));
        return new TonemapDrago(ptr);
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
                NativeMethods.photo_TonemapDrago_getSaturation(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapDrago_setSaturation(ptr, value));
            GC.KeepAlive(this);
        }
    }
        
    /// <summary>
    /// Gets or sets value for bias function in [0, 1] range. Values from 0.7 to 0.9 usually give best 
    /// results, default value is 0.85.
    /// </summary>
    public float Bias
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapDrago_getBias(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_TonemapDrago_setBias(ptr, value));
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
                NativeMethods.photo_Ptr_TonemapDrago_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_TonemapDrago_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
