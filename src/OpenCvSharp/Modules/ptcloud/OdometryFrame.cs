using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// An object that keeps per-frame data for Odometry algorithms.
/// </summary>
public class OdometryFrame : CvObject
{
    #region Init and Disposal

    /// <summary>
    /// Constructs a new OdometryFrame object. All non-empty images should have the same size.
    /// </summary>
    /// <param name="depth">A depth image.</param>
    /// <param name="image">An BGR or grayscale image (or null if it's not required for the used ICP algorithm).</param>
    /// <param name="mask">A user-provided mask of valid pixels, should be CV_8UC1.</param>
    /// <param name="normals">A user-provided normals to the depth surface, should be CV_32FC4.</param>
    public OdometryFrame(InputArray depth = default, InputArray image = default, InputArray mask = default, InputArray normals = default)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_new(
                depth.Proxy,
                image.Proxy,
                mask.Proxy,
                normals.Proxy,
                out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(OdometryFrame)}");
        InitSafeHandle(p);

        GC.KeepAlive(depth.Source);
        GC.KeepAlive(image.Source);
        GC.KeepAlive(mask.Source);
        GC.KeepAlive(normals.Source);
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
            static h => NativeMethods.HandleException(NativeMethods.ptcloud_OdometryFrame_delete(h))));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets the original user-provided BGR/Gray image.
    /// </summary>
    public void GetImage(OutputArray image)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getImage(Handle, image.Proxy));
    }

    /// <summary>
    /// Gets the gray image generated from the user-provided BGR/Gray image.
    /// </summary>
    public void GetGrayImage(OutputArray image)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getGrayImage(Handle, image.Proxy));
    }

    /// <summary>
    /// Gets the original user-provided depth image.
    /// </summary>
    public void GetDepth(OutputArray depth)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getDepth(Handle, depth.Proxy));
    }

    /// <summary>
    /// Gets the depth image generated for ICP algorithm needs.
    /// </summary>
    public void GetProcessedDepth(OutputArray depth)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getProcessedDepth(Handle, depth.Proxy));
    }

    /// <summary>
    /// Gets the valid pixels mask generated for the ICP calculations intersected with the user-provided mask.
    /// </summary>
    public void GetMask(OutputArray mask)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getMask(Handle, mask.Proxy));
    }

    /// <summary>
    /// Gets the normals image either generated for the ICP calculations or user-provided.
    /// </summary>
    public void GetNormals(OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getNormals(Handle, normals.Proxy));
    }

    /// <summary>
    /// Gets the amount of levels in pyramids, or 0 if no pyramids were prepared yet.
    /// </summary>
    public int GetPyramidLevels()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getPyramidLevels(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Gets the image generated for the ICP calculations from one of the pyramids specified by pyrType.
    /// </summary>
    /// <param name="img">Output image.</param>
    /// <param name="pyrType">Type of pyramid.</param>
    /// <param name="level">Level in the pyramid.</param>
    public void GetPyramidAt(OutputArray img, OdometryFramePyramidType pyrType, long level)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_OdometryFrame_getPyramidAt(Handle, img.Proxy, (int)pyrType, new IntPtr(level)));
    }

    #endregion
}
