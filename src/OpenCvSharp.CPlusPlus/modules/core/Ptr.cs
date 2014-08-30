using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Template class for smart reference-counting pointers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Ptr<T> : DisposableCvObject
    {
        private delegate void ReleaseFunc(IntPtr ptr);
        private delegate IntPtr ObjFunc(IntPtr ptr);

        private bool disposed;
        private readonly ReleaseFunc releaseFunc;
        private readonly ObjFunc objFunc;

        private static readonly Dictionary<Type, ReleaseFunc> definedReleaseFunctions;
        private static readonly Dictionary<Type, ObjFunc> definedObjFunctions;

        /// <summary>
        /// Static constructor
        /// </summary>
        static Ptr()
        {
            definedReleaseFunctions = new Dictionary<Type, ReleaseFunc>
                {
                    { typeof(Algorithm), NativeMethods.core_Ptr_Algorithm_delete },
                    { typeof(FaceRecognizer), NativeMethods.contrib_Ptr_FaceRecognizer_delete },
                    { typeof(DescriptorMatcher), NativeMethods.features2d_Ptr_DescriptorMatcher_delete },
                    { typeof(BFMatcher), NativeMethods.features2d_Ptr_BFMatcher_delete },
                    { typeof(FlannBasedMatcher), NativeMethods.features2d_Ptr_FlannBasedMatcher_delete },
                    { typeof(FeatureDetector), NativeMethods.features2d_Ptr_FeatureDetector_delete },
                    { typeof(Feature2D), NativeMethods.features2d_Ptr_Feature2D_delete },
                    { typeof(BRISK), NativeMethods.features2d_Ptr_BRISK_delete },
                    { typeof(DenseFeatureDetector), NativeMethods.features2d_Ptr_DenseFeatureDetector_delete },
                    { typeof(FastFeatureDetector), NativeMethods.features2d_Ptr_FastFeatureDetector_delete },
                    { typeof(FREAK), NativeMethods.features2d_Ptr_FREAK_delete },
                    { typeof(GFTTDetector), NativeMethods.features2d_Ptr_GFTTDetector_delete },
                    { typeof(MSER), NativeMethods.features2d_Ptr_MSER_delete },
                    { typeof(ORB), NativeMethods.features2d_Ptr_ORB_delete },
                    { typeof(SimpleBlobDetector), NativeMethods.features2d_Ptr_SimpleBlobDetector_delete },
                    { typeof(StarDetector), NativeMethods.features2d_Ptr_StarDetector_delete },
                    { typeof(DescriptorExtractor), NativeMethods.features2d_Ptr_DescriptorExtractor_delete },
                    { typeof(BriefDescriptorExtractor), NativeMethods.features2d_Ptr_BriefDescriptorExtractor_delete },
                    { typeof(SIFT), NativeMethods.nonfree_Ptr_SIFT_delete },
                    { typeof(SURF), NativeMethods.nonfree_Ptr_SURF_delete },
                    { typeof(EM), NativeMethods.ml_Ptr_EM_delete },
                    { typeof(FrameSource), NativeMethods.superres_Ptr_FrameSource_delete },
                    { typeof(SuperResolution), NativeMethods.superres_Ptr_SuperResolution_delete },
                    { typeof(DenseOpticalFlowExt), NativeMethods.superres_Ptr_DenseOpticalFlowExt_delete },
                    { typeof(DenseOpticalFlow), NativeMethods.video_Ptr_DenseOpticalFlow_delete },
                    { typeof(BackgroundSubtractor), NativeMethods.video_Ptr_BackgroundSubtractor_delete },
                    { typeof(BackgroundSubtractorMOG), NativeMethods.video_Ptr_BackgroundSubtractorMOG_delete },
                    { typeof(BackgroundSubtractorMOG2), NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete },
                    { typeof(BackgroundSubtractorGMG), NativeMethods.video_Ptr_BackgroundSubtractorGMG_delete },
                    { typeof(CLAHE), NativeMethods.imgproc_Ptr_CLAHE_delete },
                };
            definedObjFunctions = new Dictionary<Type, ObjFunc>
                {
                    { typeof(Algorithm), NativeMethods.core_Ptr_Algorithm_obj },
                    { typeof(FaceRecognizer), NativeMethods.contrib_Ptr_FaceRecognizer_obj },
                    { typeof(DescriptorMatcher), NativeMethods.features2d_Ptr_DescriptorMatcher_obj },
                    { typeof(BFMatcher), NativeMethods.features2d_Ptr_BFMatcher_obj },
                    { typeof(FlannBasedMatcher), NativeMethods.features2d_Ptr_FlannBasedMatcher_obj },
                    { typeof(FeatureDetector), NativeMethods.features2d_Ptr_FeatureDetector_obj },
                    { typeof(Feature2D), NativeMethods.features2d_Ptr_Feature2D_obj },
                    { typeof(BRISK), NativeMethods.features2d_Ptr_BRISK_obj },
                    { typeof(DenseFeatureDetector), NativeMethods.features2d_Ptr_DenseFeatureDetector_obj },
                    { typeof(FastFeatureDetector), NativeMethods.features2d_Ptr_FastFeatureDetector_obj },
                    { typeof(FREAK), NativeMethods.features2d_Ptr_FREAK_obj },
                    { typeof(GFTTDetector), NativeMethods.features2d_Ptr_GFTTDetector_obj },
                    { typeof(MSER), NativeMethods.features2d_Ptr_MSER_obj },
                    { typeof(ORB), NativeMethods.features2d_Ptr_ORB_obj },
                    { typeof(SimpleBlobDetector), NativeMethods.features2d_Ptr_SimpleBlobDetector_obj },
                    { typeof(StarDetector), NativeMethods.features2d_Ptr_StarDetector_obj },
                    { typeof(DescriptorExtractor), NativeMethods.features2d_Ptr_DescriptorExtractor_obj },
                    { typeof(BriefDescriptorExtractor), NativeMethods.features2d_Ptr_BriefDescriptorExtractor_obj },
                    { typeof(SIFT), NativeMethods.nonfree_Ptr_SIFT_obj },
                    { typeof(SURF), NativeMethods.nonfree_Ptr_SURF_obj },
                    { typeof(EM), NativeMethods.ml_Ptr_EM_obj },
                    { typeof(FrameSource), NativeMethods.superres_Ptr_FrameSource_obj },
                    { typeof(SuperResolution), NativeMethods.superres_Ptr_SuperResolution_obj },
                    { typeof(DenseOpticalFlowExt), NativeMethods.superres_Ptr_DenseOpticalFlowExt_obj },
                    { typeof(DenseOpticalFlow), NativeMethods.video_Ptr_DenseOpticalFlow_obj },
                    { typeof(BackgroundSubtractor), NativeMethods.video_Ptr_BackgroundSubtractor_obj },
                    { typeof(BackgroundSubtractorMOG), NativeMethods.video_Ptr_BackgroundSubtractorMOG_obj },
                    { typeof(BackgroundSubtractorMOG2), NativeMethods.video_Ptr_BackgroundSubtractorMOG2_obj },
                    { typeof(BackgroundSubtractorGMG), NativeMethods.video_Ptr_BackgroundSubtractorGMG_obj },
                    { typeof(CLAHE), NativeMethods.imgproc_Ptr_CLAHE_obj },
                };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public Ptr(IntPtr ptr)
        {
            Type type = typeof(T);
            if (!definedReleaseFunctions.TryGetValue(type, out releaseFunc))
                throw new OpenCvSharpException("Ptr<{0}> not supported", type.Name);
            if (!definedObjFunctions.TryGetValue(type, out objFunc))
                throw new OpenCvSharpException("Ptr<{0}> not supported", type.Name);

            this.ptr = ptr;
        }

        /// <summary>
        /// Release function
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        releaseFunc(ptr);
                    } 
                    ptr = IntPtr.Zero;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// Returns Ptr&lt;T&gt;.obj pointer
        /// </summary>
        public virtual IntPtr Obj
        {
            get { return objFunc(ptr); }
        }
    }
}
