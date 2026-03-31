using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Good Features To Track Detector
/// </summary>
// ReSharper disable once IdentifierTypo
// ReSharper disable once InconsistentNaming
public class GFTTDetector : Feature2D
{
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
                blockSize, useHarrisDetector ? 1 : 0, k, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features2d_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new GFTTDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="smartPtr"></param>
    /// <param name="rawPtr"></param>
    private GFTTDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features2d_Ptr_GFTTDetector_delete(p)))
    {
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
                NativeMethods.features2d_GFTTDetector_getMaxFeatures(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setMaxFeatures(RawPtr, value));
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
                NativeMethods.features2d_GFTTDetector_getQualityLevel(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setQualityLevel(RawPtr, value));
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
                NativeMethods.features2d_GFTTDetector_getMinDistance(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setMinDistance(RawPtr, value));
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
                NativeMethods.features2d_GFTTDetector_getBlockSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setBlockSize(RawPtr, value));
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
                NativeMethods.features2d_GFTTDetector_getHarrisDetector(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setHarrisDetector(RawPtr, value ? 1 : 0));
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
                NativeMethods.features2d_GFTTDetector_getK(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features2d_GFTTDetector_setK(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
