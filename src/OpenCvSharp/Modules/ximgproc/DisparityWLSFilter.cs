using OpenCvSharp.Internal;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc;

/// <summary>
/// Disparity map filter based on Weighted Least Squares filter (in form of Fast Global Smoother that
/// is a lot faster than traditional Weighted Least Squares filter implementations) and optional use of
/// left-right-consistency-based confidence to refine the results in half-occlusions and uniform areas.
/// </summary>
public class DisparityWLSFilter : DisparityFilter
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private DisparityWLSFilter(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_DisparityWLSFilter_delete(p)))
    { }

    /// <summary>
    /// Convenience factory method that creates an instance of DisparityWLSFilter and sets up all the
    /// relevant filter parameters automatically based on the matcher instance. Currently supports only
    /// StereoBM and StereoSGBM.
    /// </summary>
    /// <param name="matcherLeft">stereo matcher instance that will be used with the filter.</param>
    /// <returns></returns>
    public static DisparityWLSFilter Create(StereoMatcher matcherLeft)
    {
        ArgumentNullException.ThrowIfNull(matcherLeft);
        matcherLeft.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_createDisparityWLSFilter(matcherLeft.SmartPtr, out var smartPtr));
        GC.KeepAlive(matcherLeft);

        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_DisparityWLSFilter_get(smartPtr, out var rawPtr));
        return new DisparityWLSFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// More generic factory method, creates an instance of DisparityWLSFilter and executes basic
    /// initialization routines. When using this method you will need to set up the ROI, matchers and
    /// other parameters by yourself.
    /// </summary>
    /// <param name="useConfidence">filtering with confidence requires two disparity maps (for the left and
    /// right views) and is approximately two times slower. However, quality is typically significantly
    /// better.</param>
    /// <returns></returns>
    public static DisparityWLSFilter CreateGeneric(bool useConfidence)
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createDisparityWLSFilterGeneric(useConfidence ? 1 : 0, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_DisparityWLSFilter_get(smartPtr, out var rawPtr));
        return new DisparityWLSFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Lambda is a parameter defining the amount of regularization during filtering. Larger values force
    /// filtered disparity map edges to adhere more to source image edges. Typical value is 8000.
    /// </summary>
    public double Lambda
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_getLambda(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_setLambda(Handle, value));
        }
    }

    /// <summary>
    /// SigmaColor is a parameter defining how sensitive the filtering process is to source image edges.
    /// Large values can lead to disparity leakage through low-contrast edges. Small values can make the
    /// filter too sensitive to noise and textures in the source image. Typical values range from 0.8 to 2.0.
    /// </summary>
    public double SigmaColor
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_getSigmaColor(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_setSigmaColor(Handle, value));
        }
    }

    /// <summary>
    /// LRCthresh is a threshold of disparity difference used in left-right-consistency check during
    /// confidence map computation. The default value of 24 (1.5 pixels) is virtually always good enough.
    /// </summary>
    public int LRCthresh
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_getLRCthresh(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_setLRCthresh(Handle, value));
        }
    }

    /// <summary>
    /// DepthDiscontinuityRadius is a parameter used in confidence computation. It defines the size of
    /// low-confidence regions around depth discontinuities.
    /// </summary>
    public int DepthDiscontinuityRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_getDepthDiscontinuityRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_DisparityWLSFilter_setDepthDiscontinuityRadius(Handle, value));
        }
    }

    /// <summary>
    /// Get the confidence map that was used in the last Filter call. It is a CV_32F one-channel image
    /// with values ranging from 0.0 (totally untrusted regions of the raw disparity map) to 255.0
    /// (regions containing correct disparity values with a high degree of confidence).
    /// </summary>
    /// <returns></returns>
    public Mat GetConfidenceMap()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_DisparityWLSFilter_getConfidenceMap(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Get the ROI used in the last Filter call.
    /// </summary>
    /// <returns></returns>
    public Rect GetROI()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_DisparityWLSFilter_getROI(Handle, out var ret));
        return ret;
    }
}
