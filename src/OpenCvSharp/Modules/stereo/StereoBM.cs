using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Semi-Global Stereo Matching
/// </summary>
public class StereoBM : StereoMatcher
{
    #region Init and Disposal

    /// <summary>
    /// constructor
    /// </summary>
    private StereoBM(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoBM_delete(p)))
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numDisparities"></param>
    /// <param name="blockSize"></param>
    /// <returns></returns>
    public static StereoBM Create(int numDisparities = 0, int blockSize = 21)
    {
        NativeMethods.HandleException(
            NativeMethods.stereo_StereoBM_create(numDisparities, blockSize, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.stereo_Ptr_StereoBM_get(smartPtr, out var rawPtr));
        return new StereoBM(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int PreFilterType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getPreFilterType(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setPreFilterType(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int PreFilterSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getPreFilterSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setPreFilterSize(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int PreFilterCap
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getPreFilterCap(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setPreFilterCap(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int TextureThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getTextureThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setTextureThreshold(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int UniquenessRatio
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getUniquenessRatio(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setUniquenessRatio(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int SmallerBlockSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getSmallerBlockSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setSmallerBlockSize(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Rect ROI1
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getROI1(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setROI1(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Rect ROI2
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_getROI2(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.stereo_StereoBM_setROI2(Handle, value));
        }
    }

    #endregion

    }
