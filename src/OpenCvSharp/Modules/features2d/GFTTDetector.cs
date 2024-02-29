using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Good Features To Track Detector
/// </summary>
// ReSharper disable once IdentifierTypo
// ReSharper disable once InconsistentNaming
public class GFTTDetector : Feature2D
{
    private Ptr? ptrObj;
        
    // ReSharper disable once CommentTypo
    /// <summary>
    /// Construct GFTT processor
    /// </summary>
    /// <param name="maxCorners"></param>
    /// <param name="qualityLevel"></param>
    /// <param name="minDistance"></param>
    /// <param name="blockSize"></param>
    /// <param name="useHarrisDetector"></param>
    /// <param name="k"></param>
    public static GFTTDetector Create(
        int maxCorners = 1000, double qualityLevel = 0.01, double minDistance = 1,
        int blockSize = 3, bool useHarrisDetector = false, double k = 0.04)
    {
        NativeMethods.HandleException(
            NativeMethods.features2d_GFTTDetector_create(
                maxCorners, qualityLevel, minDistance,
                blockSize, useHarrisDetector ? 1 : 0, k, out var ptr));
        return new GFTTDetector(ptr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="p"></param>
    // ReSharper disable once IdentifierTypo
    protected GFTTDetector(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
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
    public int MaxFeatures
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_getMaxFeatures(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setMaxFeatures(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double QualityLevel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_getQualityLevel(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setQualityLevel(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public double MinDistance
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_getMinDistance(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setMinDistance(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public int BlockSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_getBlockSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setBlockSize(ptr, value));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public bool HarrisDetector
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_getHarrisDetector(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setHarrisDetector(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public double K
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_getK(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setK(ptr, value));
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
                NativeMethods.features2d_Ptr_GFTTDetector_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_Ptr_GFTTDetector_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
