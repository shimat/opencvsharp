using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base class for tonemapping algorithms - tools that are used to map HDR image to 8-bit range.
/// </summary>
public class Tonemap : Algorithm
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor used by Tonemap.Create
    /// </summary>
    private Tonemap()
    {
    }

    /// <summary>
    /// Constructor used by subclasses
    /// </summary>
    protected Tonemap(IntPtr ptr) : base(ptr)
    {
        this.ptrObj = null;
    }

    /// <summary>
    /// Creates simple linear mapper with gamma correction
    /// </summary>
    /// <param name="gamma">positive value for gamma correction.
    /// Gamma value of 1.0 implies no correction, gamma equal to 2.2f is suitable for most displays.
    /// Generally gamma &gt; 1 brightens the image and gamma &lt; 1 darkens it.</param>
    /// <returns></returns>
    public static Tonemap Create(float gamma = 1f)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_createTonemap(gamma, out var ptrObjPtr));

        var ptrObj = new Ptr(ptrObjPtr);
        var obj = new Tonemap
        {
            ptrObj = ptrObj,
        };
        obj.SetSafeHandle(new OpenCvPtrSafeHandle(ptrObj.Get(), ownsHandle: false, releaseAction: null));
        return obj;
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
    /// Tonemaps image
    /// </summary>
    /// <param name="src">source image - CV_32FC3 Mat (float 32 bits 3 channels)</param>
    /// <param name="dst">destination image - CV_32FC3 Mat with values in [0, 1] range</param>
    public virtual void Process(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.photo_Tonemap_process(ptr, src.CvPtr, dst.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        dst.Fix();
    }

    /// <summary>
    /// Gets or sets positive value for gamma correction. Gamma value of 1.0 implies no correction, gamma
    /// equal to 2.2f is suitable for most displays.
    /// Generally gamma &gt; 1 brightens the image and gamma &lt; 1 darkens it.
    /// </summary>
    public float Gamma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_Tonemap_getGamma(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.photo_Tonemap_setGamma(ptr, value));
            GC.KeepAlive(this);
        }
    }

    private sealed class Ptr(IntPtr ptr) : OpenCvSharp.Ptr(ptr, static h => NativeMethods.HandleException(NativeMethods.photo_Ptr_Tonemap_delete(h)))
    {
        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.photo_Ptr_Tonemap_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }
}
