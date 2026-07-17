using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Detail;

/// <summary>
/// Rotation estimator base class. It takes features of all images, pairwise matches between all images
/// and estimates rotations of all cameras.
/// </summary>
public abstract class Estimator : CvObject
{
    /// <summary>
    /// Constructor
    /// </summary>
    protected Estimator(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// Estimates camera parameters.
    /// </summary>
    /// <param name="features">Features of images</param>
    /// <param name="pairwiseMatches">Pairwise matches of images</param>
    /// <param name="cameras">Initial camera parameters to refine, one per image; refined in place</param>
    /// <returns>True in case of success, false otherwise</returns>
    public bool Apply(IReadOnlyList<ImageFeatures> features, IReadOnlyList<MatchesInfo> pairwiseMatches, CameraParams[] cameras)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(features);
        ArgumentNullException.ThrowIfNull(pairwiseMatches);
        ArgumentNullException.ThrowIfNull(cameras);
        if (cameras.Length != features.Count)
            throw new ArgumentException($"{nameof(cameras)}.Length must equal {nameof(features)}.Count", nameof(cameras));

        var featuresArray = features.CastOrToArray();
        var matchesArray = pairwiseMatches.CastOrToArray();

        var keypointVecs = new StdVector<KeyPoint>?[featuresArray.Length];
        var wFeatures = new WImageFeatures[featuresArray.Length];
        var wMatches = new WMatchesInfo[matchesArray.Length];
        var matchesVecs = new StdVector<DMatch>?[matchesArray.Length];
        var inliersMaskVecs = new StdVector<byte>?[matchesArray.Length];
        var wCameras = new WCameraParams[cameras.Length];
        try
        {
            for (var i = 0; i < featuresArray.Length; i++)
            {
                ArgumentNullException.ThrowIfNull(featuresArray[i].Descriptors, $"{nameof(features)}[{i}].Descriptors");
                keypointVecs[i] = new StdVector<KeyPoint>(featuresArray[i].Keypoints);
                wFeatures[i] = new WImageFeatures
                {
                    ImgIdx = featuresArray[i].ImgIdx,
                    ImgSize = featuresArray[i].ImgSize,
                    Keypoints = keypointVecs[i]!.CvPtr,
                    Descriptors = featuresArray[i].Descriptors.CvPtr,
                };
            }

            for (var i = 0; i < matchesArray.Length; i++)
            {
                matchesVecs[i] = new StdVector<DMatch>(matchesArray[i].Matches);
                inliersMaskVecs[i] = new StdVector<byte>(matchesArray[i].InliersMask);
                wMatches[i] = new WMatchesInfo
                {
                    SrcImgIdx = matchesArray[i].SrcImgIdx,
                    DstImgIdx = matchesArray[i].DstImgIdx,
                    Matches = matchesVecs[i]!.CvPtr,
                    InliersMask = inliersMaskVecs[i]!.CvPtr,
                    NumInliers = matchesArray[i].NumInliers,
                    H = matchesArray[i].H.CvPtr,
                    Confidence = matchesArray[i].Confidence,
                };
            }

            for (var i = 0; i < cameras.Length; i++)
            {
                wCameras[i] = new WCameraParams
                {
                    Focal = cameras[i].Focal,
                    Aspect = cameras[i].Aspect,
                    Ppx = cameras[i].Ppx,
                    Ppy = cameras[i].Ppy,
                    R = cameras[i].R.CvPtr,
                    T = cameras[i].T.CvPtr,
                };
            }

            NativeMethods.HandleException(
                NativeMethods.stitching_Estimator_apply(
                    Handle,
                    wFeatures, wFeatures.Length,
                    wMatches, wMatches.Length,
                    wCameras, wCameras.Length,
                    out var ret));

            for (var i = 0; i < cameras.Length; i++)
            {
                cameras[i].Focal = wCameras[i].Focal;
                cameras[i].Aspect = wCameras[i].Aspect;
                cameras[i].Ppx = wCameras[i].Ppx;
                cameras[i].Ppy = wCameras[i].Ppy;
            }

            return ret != 0;
        }
        finally
        {
            foreach (var vec in keypointVecs)
                vec?.Dispose();
            foreach (var vec in matchesVecs)
                vec?.Dispose();
            foreach (var vec in inliersMaskVecs)
                vec?.Dispose();
        }
    }
}
