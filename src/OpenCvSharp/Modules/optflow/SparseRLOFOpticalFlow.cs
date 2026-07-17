using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Class used for calculating sparse optical flow and feature tracking with robust local optical flow (RLOF) algorithms.
/// </summary>
public class SparseRLOFOpticalFlow : SparseOpticalFlow
{
    private SparseRLOFOpticalFlow(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.optflow_Ptr_SparseRLOFOpticalFlow_delete(p)))
    {
    }

    /// <summary>
    /// Creates an instance of SparseRLOFOpticalFlow.
    /// </summary>
    /// <param name="rlofParam">See <see cref="RLOFOpticalFlowParameter"/>. Uses the algorithm's defaults when null.</param>
    /// <param name="forwardBackwardThreshold">See <see cref="ForwardBackward"/>.</param>
    /// <returns></returns>
    public static SparseRLOFOpticalFlow Create(
        RLOFOpticalFlowParameter? rlofParam = null,
        float forwardBackwardThreshold = 1.0f)
    {
        rlofParam?.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.optflow_SparseRLOFOpticalFlow_create(
                rlofParam?.SmartPtr ?? IntPtr.Zero, forwardBackwardThreshold, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.optflow_Ptr_SparseRLOFOpticalFlow_get(smartPtr, out var rawPtr));
        GC.KeepAlive(rlofParam);
        return new SparseRLOFOpticalFlow(smartPtr, rawPtr);
    }

    /// <summary>
    /// Configuration of the RLOF algorithm.
    /// </summary>
    public RLOFOpticalFlowParameter RLOFOpticalFlowParameter
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.optflow_SparseRLOFOpticalFlow_getRLOFOpticalFlowParameter(Handle, out var smartPtr));
            NativeMethods.HandleException(
                NativeMethods.optflow_Ptr_RLOFOpticalFlowParameter_get(smartPtr, out var rawPtr));
            return RLOFOpticalFlowParameter.FromPtr(smartPtr, rawPtr);
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);
            value.ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.optflow_SparseRLOFOpticalFlow_setRLOFOpticalFlowParameter(Handle, value.SmartPtr));
            GC.KeepAlive(value);
        }
    }

    /// <summary>
    /// Threshold for the forward backward confidence check.
    /// </summary>
    public float ForwardBackward
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_SparseRLOFOpticalFlow_getForwardBackward(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.optflow_SparseRLOFOpticalFlow_setForwardBackward(Handle, value));
        }
    }
}
