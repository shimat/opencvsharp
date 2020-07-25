using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Detail
{
    /// <summary>
    /// cv::detail functions
    /// </summary>
    public static class CvDetail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="featuresFinder"></param>
        /// <param name="images"></param>
        /// <param name="features"></param>
        /// <param name="masks"></param>
        public static void ComputeImageFeatures(
            Feature2D featuresFinder,
            IEnumerable<Mat> images,
            out ImageFeatures[] features,
            IEnumerable<Mat>? masks = null)
        {
            if (featuresFinder == null)
                throw new ArgumentNullException(nameof(featuresFinder));
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            featuresFinder.ThrowIfDisposed();

            var imagesArray = images as Mat[] ?? images.ToArray();
            if (imagesArray.Length == 0)
                throw new ArgumentException("Empty array", nameof(images));

            var descriptorsMat = new Mat[imagesArray.Length];
            var keypointsVec = new VectorOfKeyPoint[imagesArray.Length];
            var wImageFeatures = new WImageFeatures[imagesArray.Length];
            for (int i = 0; i < imagesArray.Length; i++)
            {
                descriptorsMat[i] = new Mat();
                keypointsVec[i] = new VectorOfKeyPoint();
                wImageFeatures[i] = new WImageFeatures
                {
                    Keypoints = keypointsVec[i].CvPtr,
                    Descriptors = descriptorsMat[i].CvPtr
                };
            }

            var imagesPointers = imagesArray.Select(i => i.CvPtr).ToArray();
            var masksPointers = masks?.Select(i => i.CvPtr).ToArray();
            if (masksPointers != null && imagesPointers.Length != masksPointers.Length)
                throw new ArgumentException("size of images != size of masks");

            var wImageFeaturesPointers = new GCHandle[wImageFeatures.Length];
            try
            {
                for (int i = 0; i < wImageFeatures.Length; i++)
                {
                    wImageFeaturesPointers[i] = GCHandle.Alloc(wImageFeatures[i], GCHandleType.Pinned);
                }

                if (masksPointers == null)
                {
                    NativeMethods.HandleException(
                        NativeMethods.stitching_computeImageFeatures1_2(
                            featuresFinder.CvPtr,
                            imagesPointers,
                            imagesPointers.Length,
                            wImageFeaturesPointers.Select(gch => gch.AddrOfPinnedObject()).ToArray(),
                            IntPtr.Zero));
                }
                else
                {
                    NativeMethods.HandleException(
                        NativeMethods.stitching_computeImageFeatures1_1(
                            featuresFinder.CvPtr,
                            imagesPointers,
                            imagesPointers.Length,
                            wImageFeaturesPointers.Select(gch => gch.AddrOfPinnedObject()).ToArray(),
                            masksPointers));
                }
            }
            finally
            {
                for (int i = 0; i < wImageFeaturesPointers.Length; i++)
                {
                    wImageFeaturesPointers[i].Free();
                }
            }

            features = new ImageFeatures[wImageFeatures.Length];
            for (int i = 0; i < wImageFeaturesPointers.Length; i++)
            {
                features[i] = new ImageFeatures(
                    wImageFeatures[i].ImgIdx,
                    wImageFeatures[i].ImgSize,
                    keypointsVec[i].ToArray(),
                    descriptorsMat[i]);
            }

            GC.KeepAlive(featuresFinder);
            GC.KeepAlive(images);
            GC.KeepAlive(masks);
            GC.KeepAlive(descriptorsMat);
            GC.KeepAlive(imagesPointers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featuresFinder"></param>
        /// <param name="image"></param>
        /// <param name="features"></param>
        /// <param name="mask"></param>
        public static void ComputeImageFeatures(
            Feature2D featuresFinder,
            InputArray image,
            out ImageFeatures features,
            InputArray? mask = null)
        {
            if (featuresFinder == null)
                throw new ArgumentNullException(nameof(featuresFinder));
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            featuresFinder.ThrowIfDisposed();
            image.ThrowIfDisposed();

            var descriptorsMat = new Mat();
            var keypointsVec = new VectorOfKeyPoint();
            var wImageFeatures = new WImageFeatures
            {
                Keypoints = keypointsVec.CvPtr,
                Descriptors = descriptorsMat.CvPtr
            };

            unsafe
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_computeImageFeatures2(
                        featuresFinder.CvPtr, image.CvPtr, &wImageFeatures, mask?.CvPtr ?? IntPtr.Zero));
            }

            features = new ImageFeatures(
                wImageFeatures.ImgIdx,
                wImageFeatures.ImgSize,
                keypointsVec.ToArray(),
                descriptorsMat);

            GC.KeepAlive(featuresFinder);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            GC.KeepAlive(descriptorsMat);
        }
    }
}
