using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;


public class StereoBeliefPropagation : OpenCvSharp.Cuda.StereoMatcher
{
    protected StereoBeliefPropagation(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_delete(p)))
    {
    }

    /// <summary>
    /// Creates StereoBeliefPropagation object.
    /// </summary>
    /// <param name="ndisp">Number of disparities.</param>
    /// <param name="iters">Number of BP iterations on each level.</param>
    /// <param name="levels">Number of levels.</param>
    /// <param name="msgType">Type for messages. CV_16SC1 and CV_32FC1 types are supported.</param>
    /// <returns></returns>
    public static StereoBeliefPropagation Create(
        int ndisp = 64, int iters = 5, int levels = 5, MatType? msgType = null)
    {
        int type = msgType?.Value ?? (int)MatType.CV_32F;

        NativeMethods.HandleException(
            NativeMethods.cuda_createStereoBeliefPropagation(ndisp, iters, levels, type, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_StereoBeliefPropagation_get(smartPtr, out var rawPtr));

        return new StereoBeliefPropagation(smartPtr, rawPtr);
    }

    /// <summary>
    /// Finds the disparity for the specified data cost.
    /// </summary>
    public virtual void Compute(OpenCvSharp.Cuda.InputArray data, OpenCvSharp.Cuda.OutputArray disparity, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        if (disparity == null) throw new ArgumentNullException(nameof(disparity));
        data.ThrowIfDisposed();
        disparity.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_StereoBeliefPropagation_compute_data(RawPtr, data.CvPtr, disparity.CvPtr, stream?.CvPtr??IntPtr.Zero));

        disparity.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(data);
    }

    /// <summary>
    /// Uses a heuristic method to compute the recommended parameters for the specified image size.
    /// </summary>
    public static void EstimateRecommendedParams(int width, int height, out int ndisp, out int iters, out int levels)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_StereoBeliefPropagation_estimateRecommendedParams(width, height, out ndisp, out iters, out levels));
    }

    public float DataWeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getDataWeight(RawPtr, out float val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setDataWeight(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public double DiscSingleJump
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getDiscSingleJump(RawPtr, out double val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setDiscSingleJump(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public double MaxDataTerm
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getMaxDataTerm(RawPtr, out double val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setMaxDataTerm(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public double MaxDiscTerm
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getMaxDiscTerm(RawPtr, out double val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setMaxDiscTerm(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public MatType MsgType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getMsgType(RawPtr, out int val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setMsgType(RawPtr, value.Value));
            GC.KeepAlive(this);
        }
    }

    public int NumIters
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getNumIters(RawPtr, out int val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setNumIters(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    public int NumLevels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_getNumLevels(RawPtr, out int val));
            GC.KeepAlive(this);
            return val;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_StereoBeliefPropagation_setNumLevels(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
