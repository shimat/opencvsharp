using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;


public class GeneralizedHoughBallard : OpenCvSharp.Cuda.GeneralizedHough
{
    /// <summary>
    /// cv::Ptr&lt;T&gt; object
    /// </summary>
    /// <summary>
    /// 
    /// </summary>
    private GeneralizedHoughBallard(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_delete(p)))
    { }

    /// <summary>
    /// Creates a predefined GeneralizedHoughBallard object
    /// </summary>
    /// <returns></returns>
    public static GeneralizedHoughBallard Create()
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createGeneralizedHoughBallard(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_get(smartPtr, out var rawPtr));
        return new GeneralizedHoughBallard(smartPtr, rawPtr);
    }

    /// <summary>
    /// R-Table levels.
    /// </summary>
    /// <returns></returns>
    public int Levels
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_getLevels(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_setLevels(RawPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The accumulator threshold for the template centers at the detection stage. 
    /// The smaller it is, the more false positions may be detected.
    /// </summary>
    /// <returns></returns>
    public int VotesThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_getVotesThreshold(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_setVotesThreshold(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}
