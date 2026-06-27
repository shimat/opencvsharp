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
            NativeMethods.features_GFTTDetector_create(
                maxCorners, qualityLevel, minDistance,
                blockSize, useHarrisDetector ? 1 : 0, k, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new GFTTDetector(smartPtr, rawPtr);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="smartPtr"></param>
    /// <param name="rawPtr"></param>
    private GFTTDetector(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_GFTTDetector_delete(p)))
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
                NativeMethods.features_GFTTDetector_getMaxFeatures(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_GFTTDetector_setMaxFeatures(Handle, value));
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
                NativeMethods.features_GFTTDetector_getQualityLevel(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_GFTTDetector_setQualityLevel(Handle, value));
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
                NativeMethods.features_GFTTDetector_getMinDistance(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_GFTTDetector_setMinDistance(Handle, value));
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
                NativeMethods.features_GFTTDetector_getBlockSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_GFTTDetector_setBlockSize(Handle, value));
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
                NativeMethods.features_GFTTDetector_getHarrisDetector(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_GFTTDetector_setHarrisDetector(Handle, value ? 1 : 0));
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
                NativeMethods.features_GFTTDetector_getK(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_GFTTDetector_setK(Handle, value));
        }
    }
}
