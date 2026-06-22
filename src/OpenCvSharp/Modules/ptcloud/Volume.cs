using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Custom volume (TSDF, HashTSDF or ColorTSDF) for point cloud integration and raycasting.
/// </summary>
public class Volume : CvObject
{
    #region Init and Disposal

    /// <summary>
    /// Constructor of custom volume.
    /// </summary>
    /// <param name="vtype">the volume type [TSDF, HashTSDF, ColorTSDF].</param>
    /// <param name="settings">the custom settings for volume. If null, a default VolumeSettings(TSDF) is used.</param>
    public Volume(VolumeType vtype = VolumeType.TSDF, VolumeSettings? settings = null)
    {
        VolumeSettings? ownedSettings = null;
        try
        {
            var s = settings;
            if (s is null)
            {
                ownedSettings = new VolumeSettings(VolumeType.TSDF);
                s = ownedSettings;
            }
            s.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ptcloud_Volume_new((int)vtype, s.CvPtr, out var p));
            if (p == IntPtr.Zero)
                throw new OpenCvSharpException($"Failed to create {nameof(Volume)}");
            InitSafeHandle(p);
            GC.KeepAlive(s);
        }
        finally
        {
            ownedSettings?.Dispose();
        }
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
            static h => NativeMethods.HandleException(NativeMethods.ptcloud_Volume_delete(h))));
    }

    #endregion

    #region Integrate

    /// <summary>
    /// Integrates the input data to the volume.
    /// </summary>
    /// <param name="frame">the object from which to take depth and image data.</param>
    /// <param name="pose">the pose of camera in global coordinates.</param>
    public void IntegrateFrame(OdometryFrame frame, InputArray pose)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        if (pose is null)
            throw new ArgumentNullException(nameof(pose));
        frame.ThrowIfDisposed();
        pose.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_integrateFrame(CvPtr, frame.CvPtr, pose.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(frame);
        GC.KeepAlive(pose);
    }

    /// <summary>
    /// Integrates the input data to the volume.
    /// </summary>
    /// <param name="depth">the depth image.</param>
    /// <param name="pose">the pose of camera in global coordinates.</param>
    public void Integrate(InputArray depth, InputArray pose)
    {
        ThrowIfDisposed();
        if (depth is null)
            throw new ArgumentNullException(nameof(depth));
        if (pose is null)
            throw new ArgumentNullException(nameof(pose));
        depth.ThrowIfDisposed();
        pose.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_integrate(CvPtr, depth.CvPtr, pose.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(depth);
        GC.KeepAlive(pose);
    }

    /// <summary>
    /// Integrates the input data to the volume (only for ColorTSDF).
    /// </summary>
    /// <param name="depth">the depth image.</param>
    /// <param name="image">the color image (only for ColorTSDF).</param>
    /// <param name="pose">the pose of camera in global coordinates.</param>
    public void IntegrateColor(InputArray depth, InputArray image, InputArray pose)
    {
        ThrowIfDisposed();
        if (depth is null)
            throw new ArgumentNullException(nameof(depth));
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (pose is null)
            throw new ArgumentNullException(nameof(pose));
        depth.ThrowIfDisposed();
        image.ThrowIfDisposed();
        pose.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_integrateColor(CvPtr, depth.CvPtr, image.CvPtr, pose.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(depth);
        GC.KeepAlive(image);
        GC.KeepAlive(pose);
    }

    #endregion

    #region Raycast

    /// <summary>
    /// Renders the volume contents into an image.
    /// </summary>
    /// <param name="cameraPose">the pose of camera in global coordinates.</param>
    /// <param name="points">image to store rendered points.</param>
    /// <param name="normals">image to store rendered normals corresponding to points.</param>
    public void Raycast(InputArray cameraPose, OutputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        if (cameraPose is null)
            throw new ArgumentNullException(nameof(cameraPose));
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        cameraPose.ThrowIfDisposed();
        points.ThrowIfNotReady();
        normals.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_raycast(CvPtr, cameraPose.CvPtr, points.CvPtr, normals.CvPtr));
        points.Fix();
        normals.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(cameraPose);
    }

    /// <summary>
    /// Renders the volume contents into an image, also outputting colors (only for ColorTSDF).
    /// </summary>
    /// <param name="cameraPose">the pose of camera in global coordinates.</param>
    /// <param name="points">image to store rendered points.</param>
    /// <param name="normals">image to store rendered normals corresponding to points.</param>
    /// <param name="colors">image to store rendered colors corresponding to points (only for ColorTSDF).</param>
    public void RaycastColor(InputArray cameraPose, OutputArray points, OutputArray normals, OutputArray colors)
    {
        ThrowIfDisposed();
        if (cameraPose is null)
            throw new ArgumentNullException(nameof(cameraPose));
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        if (colors is null)
            throw new ArgumentNullException(nameof(colors));
        cameraPose.ThrowIfDisposed();
        points.ThrowIfNotReady();
        normals.ThrowIfNotReady();
        colors.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_raycastColor(CvPtr, cameraPose.CvPtr, points.CvPtr, normals.CvPtr, colors.CvPtr));
        points.Fix();
        normals.Fix();
        colors.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(cameraPose);
    }

    /// <summary>
    /// Renders the volume contents into an image of the given size with the given intrinsics.
    /// </summary>
    /// <param name="cameraPose">the pose of camera in global coordinates.</param>
    /// <param name="height">the height of result image.</param>
    /// <param name="width">the width of result image.</param>
    /// <param name="K">camera raycast intrinsics.</param>
    /// <param name="points">image to store rendered points.</param>
    /// <param name="normals">image to store rendered normals corresponding to points.</param>
    public void RaycastEx(InputArray cameraPose, int height, int width, InputArray K, OutputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        if (cameraPose is null)
            throw new ArgumentNullException(nameof(cameraPose));
        if (K is null)
            throw new ArgumentNullException(nameof(K));
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        cameraPose.ThrowIfDisposed();
        K.ThrowIfDisposed();
        points.ThrowIfNotReady();
        normals.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_raycastEx(CvPtr, cameraPose.CvPtr, height, width, K.CvPtr, points.CvPtr, normals.CvPtr));
        points.Fix();
        normals.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(cameraPose);
        GC.KeepAlive(K);
    }

    /// <summary>
    /// Renders the volume contents into an image of the given size with the given intrinsics, also outputting colors (only for ColorTSDF).
    /// </summary>
    /// <param name="cameraPose">the pose of camera in global coordinates.</param>
    /// <param name="height">the height of result image.</param>
    /// <param name="width">the width of result image.</param>
    /// <param name="K">camera raycast intrinsics.</param>
    /// <param name="points">image to store rendered points.</param>
    /// <param name="normals">image to store rendered normals corresponding to points.</param>
    /// <param name="colors">image to store rendered colors corresponding to points (only for ColorTSDF).</param>
    public void RaycastExColor(InputArray cameraPose, int height, int width, InputArray K, OutputArray points, OutputArray normals, OutputArray colors)
    {
        ThrowIfDisposed();
        if (cameraPose is null)
            throw new ArgumentNullException(nameof(cameraPose));
        if (K is null)
            throw new ArgumentNullException(nameof(K));
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        if (colors is null)
            throw new ArgumentNullException(nameof(colors));
        cameraPose.ThrowIfDisposed();
        K.ThrowIfDisposed();
        points.ThrowIfNotReady();
        normals.ThrowIfNotReady();
        colors.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_raycastExColor(CvPtr, cameraPose.CvPtr, height, width, K.CvPtr, points.CvPtr, normals.CvPtr, colors.CvPtr));
        points.Fix();
        normals.Fix();
        colors.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(cameraPose);
        GC.KeepAlive(K);
    }

    #endregion

    #region Fetch

    /// <summary>
    /// Extracts the normals corresponding to the given existing points.
    /// </summary>
    /// <param name="points">the input existing points.</param>
    /// <param name="normals">the storage of normals (corresponding to input points).</param>
    public void FetchNormals(InputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        points.ThrowIfDisposed();
        normals.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_fetchNormals(CvPtr, points.CvPtr, normals.CvPtr));
        normals.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(points);
    }

    /// <summary>
    /// Extracts all points and corresponding normals from the volume.
    /// </summary>
    /// <param name="points">the storage of all points.</param>
    /// <param name="normals">the storage of all normals, corresponding to points.</param>
    public void FetchPointsNormals(OutputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        points.ThrowIfNotReady();
        normals.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_fetchPointsNormals(CvPtr, points.CvPtr, normals.CvPtr));
        points.Fix();
        normals.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Extracts all points, normals and colors from the volume (only for ColorTSDF).
    /// </summary>
    /// <param name="points">the storage of all points.</param>
    /// <param name="normals">the storage of all normals, corresponding to points.</param>
    /// <param name="colors">the storage of all colors, corresponding to points (only for ColorTSDF).</param>
    public void FetchPointsNormalsColors(OutputArray points, OutputArray normals, OutputArray colors)
    {
        ThrowIfDisposed();
        if (points is null)
            throw new ArgumentNullException(nameof(points));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        if (colors is null)
            throw new ArgumentNullException(nameof(colors));
        points.ThrowIfNotReady();
        normals.ThrowIfNotReady();
        colors.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_fetchPointsNormalsColors(CvPtr, points.CvPtr, normals.CvPtr, colors.CvPtr));
        points.Fix();
        normals.Fix();
        colors.Fix();
        GC.KeepAlive(this);
    }

    #endregion

    #region Misc

    /// <summary>
    /// Clears all data in volume.
    /// </summary>
    public void Reset()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_reset(CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns visible blocks in volume.
    /// </summary>
    public int GetVisibleBlocks()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_getVisibleBlocks(CvPtr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns number of volume units in volume.
    /// </summary>
    public long GetTotalVolumeUnits()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_getTotalVolumeUnits(CvPtr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Gets bounding box in volume coordinates with given precision.
    /// </summary>
    /// <param name="bb">6-float 1d array containing (min_x, min_y, min_z, max_x, max_y, max_z) in volume coordinates.</param>
    /// <param name="precision">bounding box calculation precision.</param>
    public void GetBoundingBox(OutputArray bb, VolumeBoundingBoxPrecision precision)
    {
        ThrowIfDisposed();
        if (bb is null)
            throw new ArgumentNullException(nameof(bb));
        bb.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_getBoundingBox(CvPtr, bb.CvPtr, (int)precision));
        bb.Fix();
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Enables or disables new volume unit allocation during integration (HashTSDF only).
    /// </summary>
    public void SetEnableGrowth(bool v)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_setEnableGrowth(CvPtr, v ? 1 : 0));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns whether new volume units are allocated during integration (HashTSDF only).
    /// </summary>
    public bool GetEnableGrowth()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Volume_getEnableGrowth(CvPtr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    #endregion
}
