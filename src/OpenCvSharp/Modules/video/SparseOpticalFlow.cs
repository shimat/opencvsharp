using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base interface for sparse optical flow algorithms.
/// </summary>
public abstract class SparseOpticalFlow : Algorithm
{
    /// <inheritdoc />
    protected SparseOpticalFlow(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Wraps a native <c>cv::Ptr&lt;cv::SparseOpticalFlow&gt;</c> whose concrete derived type is opaque
    /// (e.g. returned by the optflow module's free-function <c>createOptFlow_SparseRLOF</c> factory)
    /// as a plain <see cref="SparseOpticalFlow"/> instance.
    /// </summary>
    internal static SparseOpticalFlow FromPtr(IntPtr smartPtr, IntPtr rawPtr) =>
        new OpaqueSparseOpticalFlow(smartPtr, rawPtr);

    private sealed class OpaqueSparseOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : SparseOpticalFlow(smartPtr, rawPtr,
            p => NativeMethods.HandleException(NativeMethods.video_Ptr_SparseOpticalFlow_delete(p)));

    /// <summary>
    /// Calculates a sparse optical flow.
    /// </summary>
    /// <param name="prevImg">First input image.</param>
    /// <param name="nextImg">Second input image of the same size and the same type as prevImg.</param>
    /// <param name="prevPts">Vector of 2D points for which the flow needs to be found.</param>
    /// <param name="nextPts">Output vector of 2D points containing the calculated new positions of input features in the second image.</param>
    /// <param name="status">Output status vector. Each element of the vector is set to 1 if the
    /// flow for the corresponding features has been found. Otherwise, it is set to 0.</param>
    /// <param name="err">Optional output vector that contains error response for each point (inverse confidence).</param>
    public virtual void Calc(
        InputArray prevImg, InputArray nextImg, InputArray prevPts, InputOutputArray nextPts,
        OutputArray status, OutputArray err = default)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.video_SparseOpticalFlow_calc(
                Handle, prevImg.Proxy, nextImg.Proxy, prevPts.Proxy, nextPts.Proxy, status.Proxy, err.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(prevImg.Source);
        GC.KeepAlive(nextImg.Source);
        GC.KeepAlive(prevPts.Source);
        GC.KeepAlive(nextPts.Source);
        GC.KeepAlive(status.Source);
        GC.KeepAlive(err.Source);
    }
}
