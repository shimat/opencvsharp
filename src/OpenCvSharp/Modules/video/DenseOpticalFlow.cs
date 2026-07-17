using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base class for dense optical flow algorithms
/// </summary>
public abstract class DenseOpticalFlow : Algorithm
{
    /// <inheritdoc />
    protected DenseOpticalFlow(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Wraps a native <c>cv::Ptr&lt;cv::DenseOpticalFlow&gt;</c> whose concrete derived type is opaque
    /// (e.g. returned by one of the optflow module's free-function <c>createOptFlow_*</c> factories)
    /// as a plain <see cref="DenseOpticalFlow"/> instance.
    /// </summary>
    internal static DenseOpticalFlow FromPtr(IntPtr smartPtr, IntPtr rawPtr) =>
        new OpaqueDenseOpticalFlow(smartPtr, rawPtr);

    private sealed class OpaqueDenseOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : DenseOpticalFlow(smartPtr, rawPtr,
            p => NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_delete(p)));

    /// <summary>
    /// Calculates an optical flow.
    /// </summary>
    /// <param name="i0">first 8-bit single-channel input image.</param>
    /// <param name="i1">second input image of the same size and the same type as prev.</param>
    /// <param name="flow">computed flow image that has the same size as prev and type CV_32FC2.</param>
    public virtual void Calc(InputArray i0, InputArray i1, InputOutputArray flow)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.video_DenseOpticalFlow_calc(Handle, i0.Proxy, i1.Proxy, flow.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(i0.Source);
        GC.KeepAlive(i1.Source);
        GC.KeepAlive(flow.Source);
    }

    /// <summary>
    /// Releases all inner buffers.
    /// </summary>
    public virtual void CollectGarbage()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.video_DenseOpticalFlow_collectGarbage(Handle));
        GC.KeepAlive(this);
    }
}
