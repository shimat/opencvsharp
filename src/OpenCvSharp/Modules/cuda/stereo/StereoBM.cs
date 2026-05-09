#if ENABLED_CUDA
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class StereoBM : OpenCvSharp.Cuda.StereoMatcher
{
    protected StereoBM(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_StereoBM_delete(p)))
    {
    }

    /// <summary>
    /// Creates StereoBM object.
    /// </summary>
    /// <param name="numDisparities">The number of disparities. Must be a multiple of 16.</param>
    /// <param name="blockSize">The linear size of the blocks compared by the algorithm. Must be odd.</param>
    /// <returns></returns>
    public static StereoBM Create(int numDisparities = 64, int blockSize = 19)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createStereoBM(numDisparities, blockSize, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_StereoBM_get(smartPtr, out var rawPtr));

        return new StereoBM(smartPtr, rawPtr);
    }

    /// <summary>
    /// Computes disparity map for the specified stereo pair.
    /// </summary>
    /// <param name="left">Left 8-bit single-channel image.</param>
    /// <param name="right">Right image of the same size and the same type as the left one.</param>
    /// <param name="disparity">Output disparity map.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    public virtual void Compute(
        OpenCvSharp.Cuda.InputArray left,
        OpenCvSharp.Cuda.InputArray right,
        OpenCvSharp.Cuda.OutputArray disparity,
        OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (left == null) throw new ArgumentNullException(nameof(left));
        if (right == null) throw new ArgumentNullException(nameof(right));
        if (disparity == null) throw new ArgumentNullException(nameof(disparity));

        left.ThrowIfDisposed();
        right.ThrowIfDisposed();
        disparity.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_StereoBM_compute(
                RawPtr, left.CvPtr, right.CvPtr, disparity.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        disparity.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(left);
        GC.KeepAlive(right);
        GC.KeepAlive(stream);
    }
}
#endif
