using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing the KAZE keypoint detector and descriptor extractor
/// </summary>
// ReSharper disable once InconsistentNaming
public class KAZE : Feature2D
{
    private Ptr? ptrObj;

    /// <summary>
    /// Constructor
    /// </summary>
    protected KAZE(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// The KAZE constructor
    /// </summary>
    /// <param name="extended">Set to enable extraction of extended (128-byte) descriptor.</param>
    /// <param name="upright">Set to enable use of upright descriptors (non rotation-invariant).</param>
    /// <param name="threshold">Detector response threshold to accept point</param>
    /// <param name="nOctaves">Maximum octave evolution of the image</param>
    /// <param name="nOctaveLayers">Default number of sublevels per scale level</param>
    /// <param name="diffusivity">Diffusivity type. DIFF_PM_G1, DIFF_PM_G2, DIFF_WEICKERT or DIFF_CHARBONNIER</param>
    public static KAZE Create(
        bool extended = false, bool upright = false, float threshold = 0.001f,
        int nOctaves = 4, int nOctaveLayers = 4, KAZEDiffusivityType diffusivity = KAZEDiffusivityType.DiffPmG2)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_KAZE_create(
                extended ? 1 : 0, upright ? 1 : 0, threshold,
                nOctaves, nOctaveLayers, (int) diffusivity, out var ptr));
        return new KAZE(ptr);
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
    /// 
    /// </summary>
    public KAZEDiffusivityType Diffusivity
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getDiffusivity(ptr, out var ret));
            GC.KeepAlive(this);
            return (KAZEDiffusivityType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setDiffusivity(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool Extended
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getExtended(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setExtended(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public int NOctaveLayers
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getNOctaveLayers(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setNOctaveLayers(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public int NOctaves
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getNOctaves(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setNOctaves(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public double Threshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setThreshold(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public bool Upright
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_getUpright(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_KAZE_setUpright(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_KAZE_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_KAZE_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
