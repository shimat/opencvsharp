using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Settings for the Odometry algorithm.
/// </summary>
public class OdometrySettings : CvObject
{
    #region Init and Disposal

    /// <summary>
    /// Creates default odometry settings.
    /// </summary>
    public OdometrySettings()
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_new(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(OdometrySettings)}");
        InitSafeHandle(p);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    public void Release()
    {
        Dispose();
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_delete(h))));
    }

    #endregion

    #region Array properties

    /// <summary>
    /// Sets the camera matrix.
    /// </summary>
    public void SetCameraMatrix(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_setCameraMatrix(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Gets the camera matrix.
    /// </summary>
    public void GetCameraMatrix(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_getCameraMatrix(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets the iteration counts.
    /// </summary>
    public void SetIterCounts(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_setIterCounts(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Gets the iteration counts.
    /// </summary>
    public void GetIterCounts(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_getIterCounts(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets the minimum gradient magnitudes.
    /// </summary>
    public void SetMinGradientMagnitudes(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_setMinGradientMagnitudes(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Gets the minimum gradient magnitudes.
    /// </summary>
    public void GetMinGradientMagnitudes(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometrySettings_getMinGradientMagnitudes(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    #endregion

    #region Scalar properties

    /// <summary>
    /// Minimum depth.
    /// </summary>
    public float MinDepth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMinDepth(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMinDepth(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximum depth.
    /// </summary>
    public float MaxDepth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxDepth(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxDepth(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximum depth difference.
    /// </summary>
    public float MaxDepthDiff
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxDepthDiff(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxDepthDiff(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximum part of points to use.
    /// </summary>
    public float MaxPointsPart
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxPointsPart(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxPointsPart(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Sobel kernel size.
    /// </summary>
    public int SobelSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getSobelSize(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setSobelSize(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Sobel scale.
    /// </summary>
    public double SobelScale
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getSobelScale(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setSobelScale(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Normal computation window size.
    /// </summary>
    public int NormalWinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getNormalWinSize(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setNormalWinSize(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Normal difference threshold.
    /// </summary>
    public float NormalDiffThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getNormalDiffThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setNormalDiffThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Method used to compute normals.
    /// </summary>
    public RgbdNormalsMethod NormalMethod
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getNormalMethod(CvPtr, out var ret));
            GC.KeepAlive(this);
            return (RgbdNormalsMethod)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setNormalMethod(CvPtr, (int)value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Angle threshold.
    /// </summary>
    public float AngleThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getAngleThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setAngleThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximum translation.
    /// </summary>
    public float MaxTranslation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxTranslation(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxTranslation(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximum rotation.
    /// </summary>
    public float MaxRotation
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxRotation(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxRotation(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Minimum gradient magnitude.
    /// </summary>
    public float MinGradientMagnitude
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMinGradientMagnitude(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMinGradientMagnitude(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion
}
