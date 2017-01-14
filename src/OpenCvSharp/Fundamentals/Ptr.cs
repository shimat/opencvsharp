using System;
using System.Collections.Generic;
using OpenCvSharp.Face;
using OpenCvSharp.ML;
using OpenCvSharp.XFeatures2D;

namespace OpenCvSharp
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
        private readonly ObjFunc getFunc;

        private static readonly Dictionary<Type, ReleaseFunc> definedReleaseFunctions;
        private static readonly Dictionary<Type, ObjFunc> definedGetFunctions;

        /// <summary>
        /// Static constructor
        /// </summary>
        static Ptr()
        {
            definedReleaseFunctions = new Dictionary<Type, ReleaseFunc>
            {
                {typeof (Algorithm), NativeMethods.core_Ptr_Algorithm_delete},
                {typeof (FaceRecognizer), NativeMethods.face_Ptr_FaceRecognizer_delete},
                {typeof (DescriptorMatcher), NativeMethods.features2d_Ptr_DescriptorMatcher_delete},
                {typeof (BFMatcher), NativeMethods.features2d_Ptr_BFMatcher_delete},
                {typeof (FlannBasedMatcher), NativeMethods.features2d_Ptr_FlannBasedMatcher_delete},
                {typeof (Feature2D), NativeMethods.features2d_Ptr_Feature2D_delete},
                {typeof (BRISK), NativeMethods.features2d_Ptr_BRISK_delete},
                //{ typeof(DenseFeatureDetector), NativeMethods.features2d_Ptr_DenseFeatureDetector_delete },
                {typeof (FastFeatureDetector), NativeMethods.features2d_Ptr_FastFeatureDetector_delete},
                {typeof (FREAK), NativeMethods.xfeatures2d_Ptr_FREAK_delete},
                {typeof (AgastFeatureDetector), NativeMethods.features2d_Ptr_AgastFeatureDetector_delete},
                {typeof (GFTTDetector), NativeMethods.features2d_Ptr_GFTTDetector_delete},
                {typeof (KAZE), NativeMethods.features2d_Ptr_KAZE_delete},
                {typeof (AKAZE), NativeMethods.features2d_Ptr_AKAZE_delete},
                {typeof (MSER), NativeMethods.features2d_Ptr_MSER_delete},
                {typeof (ORB), NativeMethods.features2d_Ptr_ORB_delete},
                {typeof (SimpleBlobDetector), NativeMethods.features2d_Ptr_SimpleBlobDetector_delete},
                {typeof (StarDetector), NativeMethods.xfeatures2d_Ptr_StarDetector_delete},
                {typeof (BriefDescriptorExtractor), NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_delete},
                {typeof (SIFT), NativeMethods.xfeatures2d_Ptr_SIFT_delete},
                {typeof (SURF), NativeMethods.xfeatures2d_Ptr_SURF_delete},
                {typeof (FrameSource), NativeMethods.superres_Ptr_FrameSource_delete},
                {typeof (SuperResolution), NativeMethods.superres_Ptr_SuperResolution_delete},
                {typeof (DenseOpticalFlowExt), NativeMethods.superres_Ptr_DenseOpticalFlowExt_delete},
                {typeof (DenseOpticalFlow), NativeMethods.video_Ptr_DenseOpticalFlow_delete},
                {typeof (BackgroundSubtractor), NativeMethods.video_Ptr_BackgroundSubtractor_delete},
                {typeof (BackgroundSubtractorMOG2), NativeMethods.video_Ptr_BackgroundSubtractorMOG2_delete},
                {typeof (BackgroundSubtractorKNN), NativeMethods.video_Ptr_BackgroundSubtractorKNN_delete},
                {typeof (BackgroundSubtractorMOG), NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_delete},
                {typeof (BackgroundSubtractorGMG), NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_delete},
                {typeof (GeneralizedHoughBallard), NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_delete},
                {typeof (GeneralizedHoughGuil), NativeMethods.imgproc_Ptr_GeneralizedHoughGuil_delete},
                {typeof (CLAHE), NativeMethods.imgproc_Ptr_CLAHE_delete},
                {typeof (LineSegmentDetector), NativeMethods.imgproc_Ptr_LineSegmentDetector_delete},
                {typeof (StereoBM), NativeMethods.calib3d_Ptr_StereoBM_delete},
                {typeof (StereoSGBM), NativeMethods.calib3d_Ptr_StereoSGBM_delete},
                {typeof (SVM), NativeMethods.ml_Ptr_SVM_delete},
                {typeof (EM), NativeMethods.ml_Ptr_EM_delete},
                {typeof (NormalBayesClassifier), NativeMethods.ml_Ptr_NormalBayesClassifier_delete},
                {typeof (KNearest), NativeMethods.ml_Ptr_KNearest_delete},
                {typeof (DTrees), NativeMethods.ml_Ptr_DTrees_delete},
                {typeof (RTrees), NativeMethods.ml_Ptr_RTrees_delete},
                {typeof (Boost), NativeMethods.ml_Ptr_Boost_delete},
                {typeof (ANN_MLP), NativeMethods.ml_Ptr_ANN_MLP_delete},
                {typeof (LogisticRegression), NativeMethods.ml_Ptr_LogisticRegression_delete},
                {typeof (Stitcher), NativeMethods.stitching_Ptr_Stitcher_delete},
                {typeof (ShapeContextDistanceExtractor), NativeMethods.shape_Ptr_ShapeContextDistanceExtractor_delete},
                {typeof (HausdorffDistanceExtractor), NativeMethods.shape_Ptr_HausdorffDistanceExtractor_delete},
                {typeof (CalibrateDebevec), NativeMethods.photo_Ptr_CalibrateDebevec_delete},
            };
            definedGetFunctions = new Dictionary<Type, ObjFunc>
            {
                {typeof (Algorithm), NativeMethods.core_Ptr_Algorithm_get},
                {typeof (FaceRecognizer), NativeMethods.face_Ptr_FaceRecognizer_get},
                {typeof (DescriptorMatcher), NativeMethods.features2d_Ptr_DescriptorMatcher_get},
                {typeof (BFMatcher), NativeMethods.features2d_Ptr_BFMatcher_get},
                {typeof (FlannBasedMatcher), NativeMethods.features2d_Ptr_FlannBasedMatcher_get},
                {typeof (Feature2D), NativeMethods.features2d_Ptr_Feature2D_get},
                {typeof (BRISK), NativeMethods.features2d_Ptr_BRISK_get},
                //{ typeof(DenseFeatureDetector), NativeMethods.features2d_Ptr_DenseFeatureDetector_get },
                {typeof (FastFeatureDetector), NativeMethods.features2d_Ptr_FastFeatureDetector_get},
                {typeof (FREAK), NativeMethods.xfeatures2d_Ptr_FREAK_get},
                {typeof (AgastFeatureDetector), NativeMethods.features2d_Ptr_AgastFeatureDetector_get},
                {typeof (GFTTDetector), NativeMethods.features2d_Ptr_GFTTDetector_get},
                {typeof (KAZE), NativeMethods.features2d_Ptr_KAZE_get},
                {typeof (AKAZE), NativeMethods.features2d_Ptr_AKAZE_get},
                {typeof (MSER), NativeMethods.features2d_Ptr_MSER_get},
                {typeof (ORB), NativeMethods.features2d_Ptr_ORB_get},
                {typeof (SimpleBlobDetector), NativeMethods.features2d_Ptr_SimpleBlobDetector_get},
                {typeof (StarDetector), NativeMethods.xfeatures2d_Ptr_StarDetector_get},
                {typeof (BriefDescriptorExtractor), NativeMethods.xfeatures2d_Ptr_BriefDescriptorExtractor_get},
                {typeof (SIFT), NativeMethods.xfeatures2d_Ptr_SIFT_get},
                {typeof (SURF), NativeMethods.xfeatures2d_Ptr_SURF_get},
                {typeof (FrameSource), NativeMethods.superres_Ptr_FrameSource_get},
                {typeof (SuperResolution), NativeMethods.superres_Ptr_SuperResolution_get},
                {typeof (DenseOpticalFlowExt), NativeMethods.superres_Ptr_DenseOpticalFlowExt_get},
                {typeof (DenseOpticalFlow), NativeMethods.video_Ptr_DenseOpticalFlow_get},
                {typeof (BackgroundSubtractor), NativeMethods.video_Ptr_BackgroundSubtractor_get},
                {typeof (BackgroundSubtractorMOG2), NativeMethods.video_Ptr_BackgroundSubtractorMOG2_get},
                {typeof (BackgroundSubtractorKNN), NativeMethods.video_Ptr_BackgroundSubtractorKNN_get},
                {typeof (BackgroundSubtractorMOG), NativeMethods.bgsegm_Ptr_BackgroundSubtractorMOG_get},
                {typeof (BackgroundSubtractorGMG), NativeMethods.bgsegm_Ptr_BackgroundSubtractorGMG_get},
                {typeof (GeneralizedHoughBallard), NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_get},
                {typeof (GeneralizedHoughGuil), NativeMethods.imgproc_Ptr_GeneralizedHoughGuil_get},
                {typeof (CLAHE), NativeMethods.imgproc_Ptr_CLAHE_get},
                {typeof (LineSegmentDetector), NativeMethods.imgproc_Ptr_LineSegmentDetector_get},
                {typeof (SVM), NativeMethods.ml_Ptr_SVM_get},
                {typeof (EM), NativeMethods.ml_Ptr_EM_get},
                {typeof (NormalBayesClassifier), NativeMethods.ml_Ptr_NormalBayesClassifier_get},
                {typeof (KNearest), NativeMethods.ml_Ptr_KNearest_get},
                {typeof (DTrees), NativeMethods.ml_Ptr_DTrees_get},
                {typeof (RTrees), NativeMethods.ml_Ptr_RTrees_get},
                {typeof (Boost), NativeMethods.ml_Ptr_Boost_get},
                {typeof (ANN_MLP), NativeMethods.ml_Ptr_ANN_MLP_get},
                {typeof (LogisticRegression), NativeMethods.ml_Ptr_LogisticRegression_get},
                {typeof (Stitcher), NativeMethods.stitching_Ptr_Stitcher_get},
                {typeof (ShapeContextDistanceExtractor), NativeMethods.shape_Ptr_ShapeContextDistanceExtractor_get},
                {typeof (HausdorffDistanceExtractor), NativeMethods.shape_Ptr_HausdorffDistanceExtractor_get},
                {typeof (CalibrateDebevec), NativeMethods.photo_Ptr_CalibrateDebevec_get},
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr"></param>
        public Ptr(IntPtr ptr)
        {
            Type type = typeof (T);
            if (!definedReleaseFunctions.TryGetValue(type, out releaseFunc))
                throw new OpenCvSharpException("Ptr<{0}> not supported", type.Name);
            if (!definedGetFunctions.TryGetValue(type, out getFunc))
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
        /// Returns Ptr&lt;T&gt;.get() pointer
        /// </summary>
        public virtual IntPtr Get()
        {
            return getFunc(ptr);
        }
    }
}
