using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Ballard, D.H. (1981). Generalizing the Hough transform to detect arbitrary shapes. 
/// Pattern Recognition 13 (2): 111-122.
/// Detects position only without traslation and rotation
/// </summary>
public class GeneralizedHoughBallard : GeneralizedHough
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
            NativeMethods.imgproc_createGeneralizedHoughBallard(out var smartPtr));
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
                NativeMethods.imgproc_GeneralizedHoughBallard_getLevels(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_setLevels(CvPtr, value));
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
                NativeMethods.imgproc_GeneralizedHoughBallard_getVotesThreshold(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_setVotesThreshold(CvPtr, value));
            GC.KeepAlive(this);
        }
    }
}
