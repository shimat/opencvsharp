#if ENABLED_CUDA
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class NvidiaHWOpticalFlow: Algorithm
{
    protected NvidiaHWOpticalFlow(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
          : base(smartPtr, rawPtr, release)
    {
    }

    /// <summary>
    /// Calculates Optical Flow using NVIDIA Optical Flow SDK.
    /// </summary>
    /// <param name="inputImage">Input image.</param>
    /// <param name="referenceImage">Reference image.</param>
    /// <param name="flow">Computed flow.</param>
    /// <param name="stream">Stream for the asynchronous version.</param>
    /// <param name="hint">Optional flow hint.</param>
    /// <param name="cost">Optional flow cost.</param>
    public virtual void Calc(
        OpenCvSharp.Cuda.InputArray inputImage,
        OpenCvSharp.Cuda.InputArray referenceImage,
        OpenCvSharp.Cuda.OutputArray flow,
        OpenCvSharp.Cuda.Stream? stream = null,
        OpenCvSharp.Cuda.InputArray? hint = null,
        OpenCvSharp.Cuda.OutputArray? cost = null)
    {
        if (inputImage == null) throw new ArgumentNullException(nameof(inputImage));
        if (referenceImage == null) throw new ArgumentNullException(nameof(referenceImage));
        if (flow == null) throw new ArgumentNullException(nameof(flow));

        inputImage.ThrowIfDisposed();
        referenceImage.ThrowIfDisposed();
        flow.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_NvidiaHWOpticalFlow_calc(
                RawPtr, inputImage.CvPtr, referenceImage.CvPtr, flow.CvPtr,
                stream?.CvPtr ?? IntPtr.Zero, hint?.CvPtr ?? IntPtr.Zero, cost?.CvPtr ?? IntPtr.Zero));

        flow.Fix();
        cost?.Fix();

        GC.KeepAlive(this);
        GC.KeepAlive(inputImage);
        GC.KeepAlive(referenceImage);
        if (hint != null) GC.KeepAlive(hint);
    }

    /// <summary>
    /// Releases all buffers, contexts and device pointers.
    /// </summary>
    public void CollectGarbage()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.cuda_NvidiaHWOpticalFlow_collectGarbage(RawPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns grid size of output buffer as per the hardware's capability.
    /// </summary>
    public int GridSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_NvidiaHWOpticalFlow_getGridSize(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }
}
#endif
