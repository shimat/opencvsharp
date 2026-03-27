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
    protected StereoBM(IntPtr ptr)
        : base(ptr)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
            releaseAction: h => NativeMethods.HandleException(NativeMethods.calib3d_Ptr_StereoBM_delete(h))));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numDisparities"></param>
    /// <param name="blockSize"></param>
    /// <returns></returns>
    public static StereoBM Create(int numDisparities = 0, int blockSize = 21)
    {
        NativeMethods.HandleException(
            NativeMethods.calib3d_StereoBM_create(numDisparities, blockSize, out var ptrObj));
        return new StereoBM(ptrObj);
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
                NativeMethods.calib3d_StereoBM_getPreFilterType(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setPreFilterType(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getPreFilterSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setPreFilterSize(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getPreFilterCap(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setPreFilterCap(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getTextureThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setTextureThreshold(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getUniquenessRatio(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setUniquenessRatio(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getSmallerBlockSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setSmallerBlockSize(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getROI1(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setROI1(ptr, value));
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
                NativeMethods.calib3d_StereoBM_getROI2(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.calib3d_StereoBM_setROI2(ptr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    }
