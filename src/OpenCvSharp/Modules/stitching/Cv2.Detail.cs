using OpenCvSharp.Detail;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::detail functions
    /// </summary>
    public static partial class Detail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="featuresFinder"></param>
        /// <param name="images"></param>
        /// <param name="masks"></param>
        public static ImageFeatures[] ComputeImageFeatures(
            Feature2D featuresFinder,
            IEnumerable<Mat> images,
            IEnumerable<Mat>? masks = null)
        {
            ArgumentNullException.ThrowIfNull(featuresFinder);
            ArgumentNullException.ThrowIfNull(images);
            featuresFinder.ThrowIfDisposed();

            var imagesArray = images as Mat[] ?? images.ToArray();
            if (imagesArray.Length == 0)
                throw new ArgumentException("Empty array", nameof(images));
            
            var imagesPointers = imagesArray.Select(i => i.CvPtr).ToArray();
            var masksPointers = masks?.Select(i => i.CvPtr).ToArray();
            if (masksPointers is not null && imagesPointers.Length != masksPointers.Length)
                throw new ArgumentException("size of images != size of masks");

            using var wImageFeaturesVec = new VectorOfImageFeatures();
            NativeMethods.HandleException(
                NativeMethods.stitching_computeImageFeatures1(
                    featuresFinder.RawPtr,
                    imagesPointers,
                    imagesPointers.Length,
                    wImageFeaturesVec.CvPtr,
                    masksPointers));
            
            GC.KeepAlive(featuresFinder);
            GC.KeepAlive(images);
            GC.KeepAlive(masks);
            GC.KeepAlive(imagesPointers);

            return wImageFeaturesVec.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featuresFinder"></param>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        public static ImageFeatures ComputeImageFeatures(
            Feature2D featuresFinder,
            InputArray image,
            InputArray mask = default)
        {
            ArgumentNullException.ThrowIfNull(featuresFinder);
            featuresFinder.ThrowIfDisposed();

            var descriptorsMat = new Mat();
            using var keypointsVec = new StdVector<KeyPoint>();
            var wImageFeatures = new WImageFeatures
            {
                Keypoints = keypointsVec.CvPtr,
                Descriptors = descriptorsMat.CvPtr
            };

            unsafe
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_computeImageFeatures2(featuresFinder.RawPtr, image.Proxy, &wImageFeatures, mask.Proxy));
            }
            
            GC.KeepAlive(featuresFinder);
            GC.KeepAlive(image.Source);
            GC.KeepAlive(mask.Source);
            GC.KeepAlive(descriptorsMat);

            return new ImageFeatures(
                wImageFeatures.ImgIdx,
                wImageFeatures.ImgSize,
                keypointsVec.ToArray(),
                descriptorsMat);
        }

        /// <summary>
        /// Normalizes the given image using a weight map.
        /// </summary>
        /// <param name="weight">Weight map</param>
        /// <param name="src">Image to normalize, in place</param>
        public static void NormalizeUsingWeightMap(InputArray weight, InputOutputArray src)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_normalizeUsingWeightMap(weight.Proxy, src.Proxy));
            GC.KeepAlive(weight.Source);
            GC.KeepAlive(src.Source);
        }

        /// <summary>
        /// Creates a weight map from the given mask.
        /// </summary>
        /// <param name="mask">Source mask</param>
        /// <param name="sharpness">Sharpness of the weight map border</param>
        /// <param name="weight">Resulting weight map</param>
        public static void CreateWeightMap(InputArray mask, float sharpness, InputOutputArray weight)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_createWeightMap(mask.Proxy, sharpness, weight.Proxy));
            GC.KeepAlive(mask.Source);
            GC.KeepAlive(weight.Source);
        }

        /// <summary>
        /// Builds a Laplacian pyramid for the given image.
        /// </summary>
        /// <param name="img">Source image</param>
        /// <param name="numLevels">Number of pyramid levels</param>
        public static Mat[] CreateLaplacePyr(InputArray img, int numLevels)
        {
            using var pyr = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.stitching_createLaplacePyr(img.Proxy, numLevels, pyr.CvPtr));
            GC.KeepAlive(img.Source);
            return pyr.ToArray();
        }

        /// <summary>
        /// Restores the source image from its Laplacian pyramid.
        /// </summary>
        /// <param name="pyr">Laplacian pyramid, as produced by <see cref="CreateLaplacePyr"/></param>
        public static Mat RestoreImageFromLaplacePyr(IEnumerable<Mat> pyr)
        {
            ArgumentNullException.ThrowIfNull(pyr);

            var pyrArray = pyr as Mat[] ?? [.. pyr];
            var pyrPtrs = pyrArray.Select(m => m.CvPtr).ToArray();
            var dst = new Mat();
            NativeMethods.HandleException(
                NativeMethods.stitching_restoreImageFromLaplacePyr(pyrPtrs, pyrPtrs.Length, dst.CvPtr));
            GC.KeepAlive(pyrArray);
            return dst;
        }

        /// <summary>
        /// Tries to make the panorama more horizontal (or vertical).
        /// </summary>
        /// <param name="rmats">Camera rotation matrices, refined in place</param>
        /// <param name="kind">Correction kind</param>
        public static void WaveCorrect(IEnumerable<Mat> rmats, WaveCorrectKind kind)
        {
            ArgumentNullException.ThrowIfNull(rmats);

            var rmatsArray = rmats as Mat[] ?? [.. rmats];
            var ptrs = rmatsArray.Select(m => m.CvPtr).ToArray();
            NativeMethods.HandleException(NativeMethods.stitching_waveCorrect(ptrs, ptrs.Length, (int)kind));
            GC.KeepAlive(rmatsArray);
        }

        /// <summary>
        /// Returns a matches graph representation in DOT language.
        /// </summary>
        /// <param name="numImages">Number of images</param>
        /// <param name="pairwiseMatches">Pairwise matches of images</param>
        /// <param name="confThreshold">Confidence threshold</param>
        public static string MatchesGraphAsString(int numImages, IReadOnlyList<MatchesInfo> pairwiseMatches, float confThreshold)
        {
            ArgumentNullException.ThrowIfNull(pairwiseMatches);

            var (wMatches, matchesVecs, inliersMaskVecs) = ToWMatchesInfoArray(pairwiseMatches);
            try
            {
                using var buf = new StdString();
                NativeMethods.HandleException(
                    NativeMethods.stitching_matchesGraphAsString(numImages, wMatches, wMatches.Length, confThreshold, buf.CvPtr));
                return buf.ToString();
            }
            finally
            {
                DisposeAll(matchesVecs);
                DisposeAll(inliersMaskVecs);
            }
        }

        /// <summary>
        /// Finds the indices, within <paramref name="features"/>, of the images belonging to the
        /// largest connected component of the pairwise-matches graph.
        /// </summary>
        /// <param name="features">Features of the source images</param>
        /// <param name="pairwiseMatches">Pairwise matches of images</param>
        /// <param name="confThreshold">Confidence threshold</param>
        public static int[] LeaveBiggestComponent(
            IReadOnlyList<ImageFeatures> features, IReadOnlyList<MatchesInfo> pairwiseMatches, float confThreshold)
        {
            ArgumentNullException.ThrowIfNull(features);
            ArgumentNullException.ThrowIfNull(pairwiseMatches);

            var (wFeatures, keypointVecs) = ToWImageFeaturesArray(features);
            var (wMatches, matchesVecs, inliersMaskVecs) = ToWMatchesInfoArray(pairwiseMatches);
            try
            {
                using var indices = new StdVector<int>();
                NativeMethods.HandleException(
                    NativeMethods.stitching_leaveBiggestComponent(
                        wFeatures, wFeatures.Length, wMatches, wMatches.Length, confThreshold, indices.CvPtr));
                return indices.ToArray();
            }
            finally
            {
                DisposeAll(keypointVecs);
                DisposeAll(matchesVecs);
                DisposeAll(inliersMaskVecs);
            }
        }

        private static void DisposeAll<T>(IEnumerable<StdVector<T>?> vecs)
            where T : unmanaged
        {
            foreach (var vec in vecs)
                vec?.Dispose();
        }

        private static (WImageFeatures[] wFeatures, StdVector<KeyPoint>?[] keypointVecs) ToWImageFeaturesArray(
            IReadOnlyList<ImageFeatures> features)
        {
            var featuresArray = features.CastOrToArray();
            var keypointVecs = new StdVector<KeyPoint>?[featuresArray.Length];
            var wFeatures = new WImageFeatures[featuresArray.Length];
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
            return (wFeatures, keypointVecs);
        }

        private static (WMatchesInfo[] wMatches, StdVector<DMatch>?[] matchesVecs, StdVector<byte>?[] inliersMaskVecs) ToWMatchesInfoArray(
            IReadOnlyList<MatchesInfo> pairwiseMatches)
        {
            var matchesArray = pairwiseMatches.CastOrToArray();
            var matchesVecs = new StdVector<DMatch>?[matchesArray.Length];
            var inliersMaskVecs = new StdVector<byte>?[matchesArray.Length];
            var wMatches = new WMatchesInfo[matchesArray.Length];
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
            return (wMatches, matchesVecs, inliersMaskVecs);
        }
    }
}
