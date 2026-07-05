using OpenCvSharp.Detail;
using OpenCvSharp.Internal;
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
    }
}
