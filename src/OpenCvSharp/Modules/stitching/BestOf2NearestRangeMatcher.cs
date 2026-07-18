using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Features matcher similar to cv::detail::BestOf2NearestMatcher which finds two best matches for each
/// feature and leaves the best one only if the ratio between descriptor distances is greater than the
/// threshold match_conf.
///
/// Unlike cv::detail::BestOf2NearestMatcher, this matcher only matches images that are no more than
/// range_width apart in the source sequence.
/// </summary>
public class BestOf2NearestRangeMatcher : BestOf2NearestMatcher
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="rangeWidth">Number of images from each side in the sequence that are to be matched</param>
    /// <param name="tryUseGpu">Should try to use GPU or not</param>
    /// <param name="matchConf">Match distances ration threshold</param>
    /// <param name="numMatchesThresh1">Minimum number of matches required for the 2D projective transform
    /// estimation used in the inliers classification step</param>
    /// <param name="numMatchesThresh2">Minimum number of matches required for the 2D projective transform
    /// re-estimation on inliers</param>
    public BestOf2NearestRangeMatcher(
        int rangeWidth = 5,
        bool tryUseGpu = false,
        float matchConf = 0.3f,
        int numMatchesThresh1 = 6,
        int numMatchesThresh2 = 6)
        : base(Create(rangeWidth, tryUseGpu, matchConf, numMatchesThresh1, numMatchesThresh2))
    {
        InitSafeHandle(CvPtr);
    }

    private static IntPtr Create(
        int rangeWidth,
        bool tryUseGpu,
        float matchConf,
        int numMatchesThresh1,
        int numMatchesThresh2)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_BestOf2NearestRangeMatcher_new(
                rangeWidth,
                tryUseGpu ? 1 : 0,
                matchConf,
                numMatchesThresh1,
                numMatchesThresh2,
                out var ptr));
        return ptr;
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.stitching_BestOf2NearestRangeMatcher_delete(h))));
    }
}
