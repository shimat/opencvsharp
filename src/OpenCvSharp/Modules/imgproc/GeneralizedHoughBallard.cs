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
    private Ptr? ptrObj;

    /// <summary>
    /// 
    /// </summary>
    private GeneralizedHoughBallard(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates a predefined GeneralizedHoughBallard object
    /// </summary>
    /// <returns></returns>
    public static GeneralizedHoughBallard Create()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_createGeneralizedHoughBallard(out var ptr));
        return new GeneralizedHoughBallard(ptr);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
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
                NativeMethods.imgproc_GeneralizedHoughBallard_getLevels(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_setLevels(ptr, value));
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
                NativeMethods.imgproc_GeneralizedHoughBallard_getVotesThreshold(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_GeneralizedHoughBallard_setVotesThreshold(ptr, value));
            GC.KeepAlive(this);
        }
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
