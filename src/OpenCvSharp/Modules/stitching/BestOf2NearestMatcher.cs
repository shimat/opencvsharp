using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Features matcher which finds two best matches for each feature and leaves the best one only if the
/// ratio between descriptor distances is greater than the threshold match_conf
/// </summary>
public class BestOf2NearestMatcher : FeaturesMatcher
{
    /// <summary>
    /// Constructs a "best of 2 nearest" matcher.
    /// </summary>
    /// <param name="tryUseGpu">Should try to use GPU or not</param>
    /// <param name="matchConf">Match distances ration threshold</param>
    /// <param name="numMatchesThresh1">Minimum number of matches required for the 2D projective transform
    /// estimation used in the inliers classification step</param>
    /// <param name="numMatchesThresh2">Minimum number of matches required for the 2D projective transform
    /// re-estimation on inliers</param>
    public BestOf2NearestMatcher(
        bool tryUseGpu = false, 
        float matchConf = 0.3f, 
        int numMatchesThresh1 = 6,
        int numMatchesThresh2 = 6)
        : base(Create(tryUseGpu, matchConf, numMatchesThresh1, numMatchesThresh2))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="p"></param>
    protected BestOf2NearestMatcher(IntPtr p) : base(p) { }
        
    private static IntPtr Create(
        bool tryUseGpu,
        float matchConf,
        int numMatchesThresh1,
        int numMatchesThresh2)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_BestOf2NearestMatcher_new(
                tryUseGpu ? 1 : 0,
                matchConf,
                numMatchesThresh1,
                numMatchesThresh2,
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
                NativeMethods.stitching_BestOf2NearestMatcher_delete(ptr));
            ptr = IntPtr.Zero;
        }
    }

    /// <summary>
    /// Frees unused memory allocated before if there is any.
    /// </summary>
    public override void CollectGarbage()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_BestOf2NearestMatcher_collectGarbage(ptr));
        GC.KeepAlive(this);
    }
}
