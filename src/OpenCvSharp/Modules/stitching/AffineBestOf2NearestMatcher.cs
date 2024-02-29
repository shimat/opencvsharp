using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Features matcher similar to cv::detail::BestOf2NearestMatcher which
/// finds two best matches for each feature and leaves the best one only if the
/// ratio between descriptor distances is greater than the threshold match_conf.
///
/// Unlike cv::detail::BestOf2NearestMatcher this matcher uses affine
/// transformation (affine transformation estimate will be placed in matches_info).
/// </summary>
public class AffineBestOf2NearestMatcher : BestOf2NearestMatcher
{
    /// <summary>
    /// Constructs a "best of 2 nearest" matcher that expects affine transformation between images
    /// </summary>
    /// <param name="fullAffine">whether to use full affine transformation with 6 degress of freedom
    /// or reduced transformation with 4 degrees of freedom using only rotation, translation and
    /// uniform scaling</param>
    /// <param name="tryUseGpu">Should try to use GPU or not</param>
    /// <param name="matchConf">Match distances ration threshold</param>
    /// <param name="numMatchesThresh1">Minimum number of matches required for the 2D affine transform
    /// estimation used in the inliers classification step</param>
    public AffineBestOf2NearestMatcher(
        bool fullAffine = false, 
        bool tryUseGpu = false, 
        float matchConf = 0.3f, 
        int numMatchesThresh1 = 6)
        : base(Create(fullAffine, tryUseGpu, matchConf, numMatchesThresh1))
    {
    }
        
    private static IntPtr Create(
        bool fullAffine,
        bool tryUseGpu,
        float matchConf,
        int numMatchesThresh1)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_AffineBestOf2NearestMatcher_new(
                fullAffine ? 1 : 0,
                tryUseGpu ? 1 : 0,
                matchConf,
                numMatchesThresh1,
                out var ptr));
        return ptr;
    }

    /// <summary>
    /// releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        if (ptr != IntPtr.Zero)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_AffineBestOf2NearestMatcher_delete(ptr));
            ptr = IntPtr.Zero;
        }
    }
}
