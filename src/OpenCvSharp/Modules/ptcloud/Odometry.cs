using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Odometry algorithm that computes the rigid transformation between two frames.
/// </summary>
public class Odometry : CvObject
{
    #region Init and Disposal

    /// <summary>
    /// Creates an Odometry object with default settings.
    /// </summary>
    public Odometry()
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_new1(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(Odometry)}");
        InitSafeHandle(p);
    }

    /// <summary>
    /// Creates an Odometry object of the given type.
    /// </summary>
    /// <param name="otype">odometry type.</param>
    public Odometry(OdometryType otype)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_new2((int)otype, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(Odometry)}");
        InitSafeHandle(p);
    }

    /// <summary>
    /// Creates an Odometry object of the given type with custom settings.
    /// </summary>
    /// <param name="otype">odometry type.</param>
    /// <param name="settings">odometry settings.</param>
    /// <param name="algtype">odometry algorithm type.</param>
    public Odometry(OdometryType otype, OdometrySettings settings, OdometryAlgoType algtype)
    {
        ArgumentNullException.ThrowIfNull(settings);
        settings.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_new3((int)otype, settings.CvPtr, (int)algtype, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(Odometry)}");
        InitSafeHandle(p);
        GC.KeepAlive(settings);
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
            static h => NativeMethods.HandleException(NativeMethods.ptcloud_Odometry_delete(h))));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Prepares the frame for odometry calculation (as both src and dst frame).
    /// </summary>
    /// <param name="frame">frame to prepare.</param>
    public void PrepareFrame(OdometryFrame frame)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(frame);
        frame.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_prepareFrame(Handle, frame.CvPtr));
        GC.KeepAlive(frame);
    }

    /// <summary>
    /// Prepares the src and dst frames for odometry calculation.
    /// </summary>
    /// <param name="srcFrame">frame will be prepared as src frame ("original" image).</param>
    /// <param name="dstFrame">frame will be prepared as dst frame ("rotated" image).</param>
    public void PrepareFrames(OdometryFrame srcFrame, OdometryFrame dstFrame)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(srcFrame);
        ArgumentNullException.ThrowIfNull(dstFrame);
        srcFrame.ThrowIfDisposed();
        dstFrame.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_prepareFrames(Handle, srcFrame.CvPtr, dstFrame.CvPtr));
        GC.KeepAlive(srcFrame);
        GC.KeepAlive(dstFrame);
    }

    /// <summary>
    /// Computes the rigid transformation between two prepared frames so that Rt * src = dst.
    /// </summary>
    /// <param name="srcFrame">src frame ("original" image).</param>
    /// <param name="dstFrame">dst frame ("rotated" image).</param>
    /// <param name="Rt">Rigid transformation output (4x4).</param>
    /// <returns>true on success, false if failed to find the transformation.</returns>
    public bool Compute(OdometryFrame srcFrame, OdometryFrame dstFrame, OutputArray Rt)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(srcFrame);
        ArgumentNullException.ThrowIfNull(dstFrame);
        srcFrame.ThrowIfDisposed();
        dstFrame.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_compute_Frame(Handle, srcFrame.CvPtr, dstFrame.CvPtr, Rt.Proxy, out var ret));
        GC.KeepAlive(srcFrame);
        GC.KeepAlive(dstFrame);
        return ret != 0;
    }

    /// <summary>
    /// Computes the rigid transformation between two depth images so that Rt * src = dst.
    /// </summary>
    /// <param name="srcDepth">source depth ("original" image).</param>
    /// <param name="dstDepth">destination depth ("rotated" image).</param>
    /// <param name="Rt">Rigid transformation output (4x4).</param>
    /// <returns>true on success, false if failed to find the transformation.</returns>
    public bool Compute(InputArray srcDepth, InputArray dstDepth, OutputArray Rt)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_compute_Depth(Handle, srcDepth.Proxy, dstDepth.Proxy, Rt.Proxy, out var ret));
        GC.KeepAlive(srcDepth.Source);
        GC.KeepAlive(dstDepth.Source);
        return ret != 0;
    }

    /// <summary>
    /// Computes the rigid transformation between two RGB-D frames so that Rt * src = dst.
    /// </summary>
    /// <param name="srcDepth">source depth ("original" image).</param>
    /// <param name="srcRGB">source RGB.</param>
    /// <param name="dstDepth">destination depth ("rotated" image).</param>
    /// <param name="dstRGB">destination RGB.</param>
    /// <param name="Rt">Rigid transformation output (4x4).</param>
    /// <returns>true on success, false if failed to find the transformation.</returns>
    public bool Compute(InputArray srcDepth, InputArray srcRGB, InputArray dstDepth, InputArray dstRGB, OutputArray Rt)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_compute_DepthRGB(Handle, srcDepth.Proxy, srcRGB.Proxy, dstDepth.Proxy, dstRGB.Proxy, Rt.Proxy, out var ret));
        GC.KeepAlive(srcDepth.Source);
        GC.KeepAlive(srcRGB.Source);
        GC.KeepAlive(dstDepth.Source);
        GC.KeepAlive(dstRGB.Source);
        return ret != 0;
    }

    /// <summary>
    /// Returns the normals computer used by this odometry.
    /// </summary>
    public RgbdNormals GetNormalsComputer()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_Odometry_getNormalsComputer(Handle, out var p));
        return new RgbdNormals(p);
    }

    #endregion
}
