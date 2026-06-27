using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Settings for a TSDF/HashTSDF/ColorTSDF Volume.
/// </summary>
public class VolumeSettings : CvObject
{
    #region Init and Disposal

    /// <summary>
    /// Constructor of settings for custom Volume type.
    /// </summary>
    /// <param name="volumeType">volume type.</param>
    public VolumeSettings(VolumeType volumeType = VolumeType.TSDF)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_new((int)volumeType, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(VolumeSettings)}");
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
            static h => NativeMethods.HandleException(NativeMethods.ptcloud_VolumeSettings_delete(h))));
    }

    #endregion

    #region Properties

    /// <summary>
    /// The width of the image for integration.
    /// </summary>
    public int IntegrateWidth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getIntegrateWidth(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setIntegrateWidth(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The height of the image for integration.
    /// </summary>
    public int IntegrateHeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getIntegrateHeight(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setIntegrateHeight(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The width of the raycasted image.
    /// </summary>
    public int RaycastWidth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getRaycastWidth(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setRaycastWidth(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The height of the raycasted image.
    /// </summary>
    public int RaycastHeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getRaycastHeight(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setRaycastHeight(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Depth factor, which is the number for depth scaling.
    /// </summary>
    public float DepthFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getDepthFactor(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setDepthFactor(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The size of voxel.
    /// </summary>
    public float VoxelSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getVoxelSize(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setVoxelSize(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// TSDF truncation distance.
    /// </summary>
    public float TsdfTruncateDistance
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getTsdfTruncateDistance(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setTsdfTruncateDistance(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Threshold for depth truncation in meters.
    /// </summary>
    public float MaxDepth
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getMaxDepth(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setMaxDepth(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Max number of frames to integrate per voxel.
    /// </summary>
    public int MaxWeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getMaxWeight(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setMaxWeight(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Length of single raycast step.
    /// </summary>
    public float RaycastStepFactor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_getRaycastStepFactor(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ptcloud_VolumeSettings_setRaycastStepFactor(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets volume pose.
    /// </summary>
    /// <param name="val">input value.</param>
    public void SetVolumePose(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_setVolumePose(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Gets volume pose.
    /// </summary>
    /// <param name="val">output value.</param>
    public void GetVolumePose(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_getVolumePose(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets resolution of voxel space.
    /// </summary>
    /// <param name="val">input value.</param>
    public void SetVolumeResolution(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_setVolumeResolution(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Gets resolution of voxel space.
    /// </summary>
    /// <param name="val">output value.</param>
    public void GetVolumeResolution(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_getVolumeResolution(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns 3 integers representing strides by x, y and z dimension.
    /// </summary>
    /// <param name="val">output value.</param>
    public void GetVolumeStrides(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_getVolumeStrides(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets intrinsics of camera for integrations.
    /// </summary>
    /// <param name="val">input value.</param>
    public void SetCameraIntegrateIntrinsics(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_setCameraIntegrateIntrinsics(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Returns intrinsics of camera for integrations.
    /// </summary>
    /// <param name="val">output value.</param>
    public void GetCameraIntegrateIntrinsics(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_getCameraIntegrateIntrinsics(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Sets camera intrinsics for raycast image.
    /// </summary>
    /// <param name="val">input value.</param>
    public void SetCameraRaycastIntrinsics(InputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_setCameraRaycastIntrinsics(CvPtr, val.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(val);
    }

    /// <summary>
    /// Returns camera intrinsics for raycast image.
    /// </summary>
    /// <param name="val">output value.</param>
    public void GetCameraRaycastIntrinsics(OutputArray val)
    {
        ThrowIfDisposed();
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        val.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_VolumeSettings_getCameraRaycastIntrinsics(CvPtr, val.CvPtr));
        val.Fix();
        GC.KeepAlive(this);
    }

    #endregion
}
