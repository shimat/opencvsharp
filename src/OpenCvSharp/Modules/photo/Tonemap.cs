using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base class for tonemapping algorithms - tools that are used to map HDR image to 8-bit range.
/// </summary>
public class Tonemap : Algorithm
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tonemap"/> class.
    /// </summary>
    protected Tonemap()
    {
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
            NativeMethods.photo_createTonemap(gamma, out var p));
        var obj = new Tonemap();
        obj.SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.photo_Ptr_Tonemap_delete(p))));
        return obj;
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

    }
