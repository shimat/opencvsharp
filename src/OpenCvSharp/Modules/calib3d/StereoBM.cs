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
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.calib3d_Ptr_StereoBM_delete(p)))
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
            NativeMethods.calib3d_StereoBM_create(numDisparities, blockSize, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.calib3d_Ptr_StereoBM_get(smartPtr, out var rawPtr));
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
                NativeMethods.calib3d_StereoBM_getPreFilterType(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setPreFilterType(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getPreFilterSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setPreFilterSize(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getPreFilterCap(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setPreFilterCap(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getTextureThreshold(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setTextureThreshold(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getUniquenessRatio(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setUniquenessRatio(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getSmallerBlockSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setSmallerBlockSize(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getROI1(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setROI1(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.calib3d_StereoBM_getROI2(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setROI2(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    }
