using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// PCAFlow algorithm.
/// </summary>
public class OpticalFlowPCAFlow : DenseOpticalFlow
{
    private OpticalFlowPCAFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.optflow_Ptr_OpticalFlowPCAFlow_delete(p)))
    {
    }

    /// <summary>
    /// Creates an instance of the PCAFlow algorithm.
    /// </summary>
    /// <param name="prior">Learned prior, or null to use no prior.</param>
    /// <param name="basisSize">Number of basis vectors.</param>
    /// <param name="sparseRate">Controls density of sparse matches. Range: (0 .. 0.1).</param>
    /// <param name="retainedCornersFraction">Retained corners fraction. Range: [0 .. 1].</param>
    /// <param name="occlusionsThreshold">Occlusion threshold.</param>
    /// <param name="dampingFactor">Regularization term for solving least-squares. Not related to the prior regularization.</param>
    /// <param name="claheClip">Clip parameter for CLAHE.</param>
    /// <returns></returns>
    public static OpticalFlowPCAFlow Create(
        PCAPrior? prior = null,
        Size? basisSize = null,
        float sparseRate = 0.024f,
        float retainedCornersFraction = 0.2f,
        float occlusionsThreshold = 0.0003f,
        float dampingFactor = 0.00002f,
        float claheClip = 14f)
    {
        prior?.ThrowIfDisposed();
        var actualBasisSize = basisSize ?? new Size(18, 14);

        NativeMethods.HandleException(
            NativeMethods.optflow_OpticalFlowPCAFlow_new(
                prior?.SmartPtr ?? IntPtr.Zero,
                actualBasisSize.Width, actualBasisSize.Height,
                sparseRate, retainedCornersFraction, occlusionsThreshold, dampingFactor, claheClip,
                out var smartPtr));
        NativeMethods.HandleException(NativeMethods.optflow_Ptr_OpticalFlowPCAFlow_get(smartPtr, out var rawPtr));
        GC.KeepAlive(prior);
        return new OpticalFlowPCAFlow(smartPtr, rawPtr);
    }
}
