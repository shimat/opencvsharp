using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Detail;

/// <summary>
/// Feature matchers base class.
/// </summary>
public abstract class FeaturesMatcher : DisposableCvObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ptr"></param>
    protected FeaturesMatcher(IntPtr ptr)
        : base(ptr)
    {
    }

    /// <summary>
    /// Performs images matching.
    /// </summary>
    /// <param name="features1">First image features</param>
    /// <param name="features2">Second image features</param>
    /// <returns>Found matches</returns>
    public virtual MatchesInfo Apply(
        ImageFeatures features1, ImageFeatures features2)
    {
        ThrowIfDisposed();

        if (features1 is null)
            throw new ArgumentNullException(nameof(features1));
        if (features2 is null) 
            throw new ArgumentNullException(nameof(features2));
        if (features1.Descriptors is null)
            throw new ArgumentException($"{nameof(features1)}.Descriptors is null", nameof(features1));
        if (features2.Descriptors is null)
            throw new ArgumentException($"{nameof(features2)}.Descriptors is null", nameof(features1));
        features1.Descriptors.ThrowIfDisposed();
        features2.Descriptors.ThrowIfDisposed();

        using var keypointsVec1 = new VectorOfKeyPoint(features1.Keypoints);
        using var keypointsVec2 = new VectorOfKeyPoint(features2.Keypoints);
        var features1Cpp = new WImageFeatures
        {
            ImgIdx = features1.ImgIdx,
            ImgSize = features1.ImgSize,
            Keypoints = keypointsVec1.CvPtr,
            Descriptors = features1.Descriptors.CvPtr,
        };
        var features2Cpp = new WImageFeatures
        {
            ImgIdx = features2.ImgIdx,
            ImgSize = features2.ImgSize,
            Keypoints = keypointsVec2.CvPtr,
            Descriptors = features2.Descriptors.CvPtr,
        };
        using var matchesVec = new VectorOfDMatch();
        using var inliersMaskVec = new VectorOfByte();
        var h = new Mat();
        NativeMethods.HandleException(
            NativeMethods.stitching_FeaturesMatcher_apply(
                ptr,
                ref features1Cpp,
                ref features2Cpp,
                out var srcImgIdx, 
                out var dstImgIdx,
                matchesVec.CvPtr,
                inliersMaskVec.CvPtr,
                out var numInliers,
                h.CvPtr,
                out var confidence));

        GC.KeepAlive(this);

        return new MatchesInfo(
            srcImgIdx, dstImgIdx, matchesVec.ToArray(), inliersMaskVec.ToArray(), 
            numInliers, h, confidence);
    }

    /// <summary>
    /// Performs images matching.
    /// </summary>
    /// <param name="features">Features of the source images</param>
    /// <param name="mask">Mask indicating which image pairs must be matched</param>
    /// <returns>Found pairwise matches</returns>
    public virtual MatchesInfo[] Apply(
        IEnumerable<ImageFeatures> features, Mat? mask = null)
    {
        if (features is null) 
            throw new ArgumentNullException(nameof(features));
        ThrowIfDisposed();

        var featuresArray = features.CastOrToArray();
        if (featuresArray.Length == 0)
            throw new ArgumentException("Empty features array", nameof(features));

        var keypointVecs = new VectorOfKeyPoint?[featuresArray.Length];
        var wImageFeatures = new WImageFeatures[featuresArray.Length];
        try
        {
            for (int i = 0; i < featuresArray.Length; i++)
            {
                if (featuresArray[i].Descriptors is null)
                    throw new ArgumentException("features contain null descriptor mat", nameof(features));
                featuresArray[i].Descriptors.ThrowIfDisposed();

                keypointVecs[i] = new VectorOfKeyPoint();
                wImageFeatures[i] = new WImageFeatures
                {
                    ImgIdx = featuresArray[i].ImgIdx,
                    ImgSize = featuresArray[i].ImgSize,
                    Keypoints = keypointVecs[i]!.CvPtr,
                    Descriptors = featuresArray[i].Descriptors.CvPtr,
                };
            }

            using var srcImgIndexVecs = new VectorOfInt32();
            using var dstImgIndexVecs = new VectorOfInt32();
            using var matchesVec = new VectorOfVectorDMatch();
            using var inlinersMaskVec = new VectorOfVectorByte();
            using var numInliersVecs = new VectorOfInt32();
            using var hVecs = new VectorOfMat();
            using var confidenceVecs = new VectorOfDouble();
            NativeMethods.HandleException(
                NativeMethods.stitching_FeaturesMatcher_apply2(
                    ptr, 
                    wImageFeatures, wImageFeatures.Length,
                    mask?.CvPtr ?? IntPtr.Zero,
                    srcImgIndexVecs.CvPtr,
                    dstImgIndexVecs.CvPtr,
                    matchesVec.CvPtr,
                    inlinersMaskVec.CvPtr,
                    numInliersVecs.CvPtr,
                    hVecs.CvPtr,
                    confidenceVecs.CvPtr
                ));

            var srcImgIndices = srcImgIndexVecs.ToArray();
            var dstImgIndices = dstImgIndexVecs.ToArray();
            var matches = matchesVec.ToArray();
            var inlinersMasks = inlinersMaskVec.ToArray();
            var numInliers = numInliersVecs.ToArray();
            var hs = hVecs.ToArray();
            var confidences = confidenceVecs.ToArray();
            var result = new MatchesInfo[srcImgIndices.Length];
            for (int i = 0; i < srcImgIndices.Length; i++)
            {
                result[i] = new MatchesInfo(
                    srcImgIndices[i],
                    dstImgIndices[i], 
                    matches[i],
                    inlinersMasks[i],
                    numInliers[i],
                    hs[i],
                    confidences[i]);
            }
            return result;
        }
        finally
        {
            foreach (var vec in keypointVecs)
            {
                vec?.Dispose();
            }
            GC.KeepAlive(this);
        }
    }
        
    /// <summary>
    /// True, if it's possible to use the same matcher instance in parallel, false otherwise
    /// </summary>
    /// <returns></returns>
    public virtual bool IsThreadSafe()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_FeaturesMatcher_isThreadSafe(ptr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }
        
    /// <summary>
    /// Frees unused memory allocated before if there is any.
    /// </summary>
    public virtual void CollectGarbage()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_FeaturesMatcher_collectGarbage(ptr));
        GC.KeepAlive(this);
    }
}
