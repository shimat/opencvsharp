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
            NativeMethods.ptcloud_OdometrySettings_setCameraMatrix(Handle, val.CvPtr));
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
            NativeMethods.ptcloud_OdometrySettings_getCameraMatrix(Handle, val.CvPtr));
        val.Fix();
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
            NativeMethods.ptcloud_OdometrySettings_setIterCounts(Handle, val.CvPtr));
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
            NativeMethods.ptcloud_OdometrySettings_getIterCounts(Handle, val.CvPtr));
        val.Fix();
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
            NativeMethods.ptcloud_OdometrySettings_setMinGradientMagnitudes(Handle, val.CvPtr));
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
            NativeMethods.ptcloud_OdometrySettings_getMinGradientMagnitudes(Handle, val.CvPtr));
        val.Fix();
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMinDepth(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMinDepth(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxDepth(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxDepth(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxDepthDiff(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxDepthDiff(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxPointsPart(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxPointsPart(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getSobelSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setSobelSize(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getSobelScale(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setSobelScale(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getNormalWinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setNormalWinSize(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getNormalDiffThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setNormalDiffThreshold(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getNormalMethod(Handle, out var ret));
            return (RgbdNormalsMethod)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setNormalMethod(Handle, (int)value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getAngleThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setAngleThreshold(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxTranslation(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxTranslation(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMaxRotation(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMaxRotation(Handle, value));
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
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_getMinGradientMagnitude(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.ptcloud_OdometrySettings_setMinGradientMagnitude(Handle, value));
        }
    }

    #endregion
}
