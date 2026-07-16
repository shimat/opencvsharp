using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Main interface for all filters, that take sparse matches as an input and produce a dense
/// per-pixel matching (optical flow) as an output.
/// </summary>
public abstract class SparseMatchInterpolator : Algorithm
{
    /// <inheritdoc />
    protected SparseMatchInterpolator(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Interpolate input sparse matches.
    /// </summary>
    /// <param name="fromImage">first of the two matched images, 8-bit single-channel or three-channel.</param>
    /// <param name="fromPoints">points of the fromImage for which there are correspondences in the
    /// toImage (Point2f vector or Mat of depth CV_32F).</param>
    /// <param name="toImage">second of the two matched images, 8-bit single-channel or three-channel.</param>
    /// <param name="toPoints">points in the toImage corresponding to fromPoints (Point2f vector or Mat
    /// of depth CV_32F).</param>
    /// <param name="denseFlow">output dense matching (two-channel CV_32F image).</param>
    public virtual void Interpolate(
        InputArray fromImage, InputArray fromPoints, InputArray toImage, InputArray toPoints, OutputArray denseFlow)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_SparseMatchInterpolator_interpolate(
                Handle, fromImage.Proxy, fromPoints.Proxy, toImage.Proxy, toPoints.Proxy, denseFlow.Proxy));

        GC.KeepAlive(fromImage.Source);
        GC.KeepAlive(fromPoints.Source);
        GC.KeepAlive(toImage.Source);
        GC.KeepAlive(toPoints.Source);
        GC.KeepAlive(denseFlow.Source);
    }
}
