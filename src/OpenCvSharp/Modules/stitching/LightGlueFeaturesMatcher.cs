using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Features matcher that adapts <see cref="OpenCvSharp.LightGlueMatcher"/> (a DNN-based descriptor matcher)
/// to the stitching pipeline's <see cref="FeaturesMatcher"/> interface.
/// Requires OpenCV built with the dnn module; otherwise the underlying LightGlueMatcher throws at runtime.
/// </summary>
// ReSharper disable once InconsistentNaming
public class LightGlueFeaturesMatcher : FeaturesMatcher
{
    /// <summary>
    /// Constructs a LightGlue features matcher.
    /// </summary>
    /// <param name="lgMatcher">LightGlueMatcher instance for DNN-based matching</param>
    /// <param name="numMatchesThresh1">Minimum number of matches required for the 2D projective transform
    /// estimation used in the inliers classification step</param>
    /// <param name="numMatchesThresh2">Minimum number of matches required for the 2D projective transform
    /// re-estimation on inliers</param>
    /// <param name="matchesConfidenceThresh">Matching confidence threshold to take the match into account</param>
    public LightGlueFeaturesMatcher(
        LightGlueMatcher lgMatcher,
        int numMatchesThresh1 = 6,
        int numMatchesThresh2 = 6,
        double matchesConfidenceThresh = 3.0)
        : base(Create(lgMatcher, numMatchesThresh1, numMatchesThresh2, matchesConfidenceThresh))
    {
        InitSafeHandle(CvPtr);
        GC.KeepAlive(lgMatcher);
    }

    private static IntPtr Create(
        LightGlueMatcher lgMatcher,
        int numMatchesThresh1,
        int numMatchesThresh2,
        double matchesConfidenceThresh)
    {
        ArgumentNullException.ThrowIfNull(lgMatcher);

        NativeMethods.HandleException(
            NativeMethods.stitching_LightGlueFeaturesMatcher_new(
                lgMatcher.SmartPtr,
                numMatchesThresh1,
                numMatchesThresh2,
                matchesConfidenceThresh,
                out var ptr));
        return ptr;
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.stitching_LightGlueFeaturesMatcher_delete(h))));
    }

    /// <summary>
    /// Sets the LightGlue confidence threshold for filtering matches.
    /// </summary>
    public void SetScoreThreshold(float thresh)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_LightGlueFeaturesMatcher_setScoreThreshold(Handle, thresh));
    }
}
