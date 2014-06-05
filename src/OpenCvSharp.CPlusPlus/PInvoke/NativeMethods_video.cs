using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_initModule_video();

        #region background_segm
        #region BackgroundSubtractor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractor_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractor_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractor_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractor_obj(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractor_info(IntPtr obj);
        #endregion
        #region BackgroundSubtractorMOG
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG_initialize(IntPtr self, CvSize frameSize, int frameType);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorMOG_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorMOG_obj(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG_info(IntPtr obj);
        #endregion
        #region BackgroundSubtractorMOG2
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG2_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG2_new2(int history, float varThreshold, int bShadowDetection);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_initialize(IntPtr self, CvSize frameSize, int frameType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorMOG2_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorMOG2_obj(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorMOG2_info(IntPtr obj);
        #endregion
        #region BackgroundSubtractorGMG

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorGMG_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorGMG_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorGMG_operator(
            IntPtr obj, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorGMG_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorGMG_initialize(
            IntPtr obj, CvSize frameSize, double min, double max);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorGMG_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorGMG_obj(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_BackgroundSubtractorGMG_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* video_BackgroundSubtractorGMG_maxFeatures(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* video_BackgroundSubtractorGMG_learningRate(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* video_BackgroundSubtractorGMG_numInitializationFrames(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* video_BackgroundSubtractorGMG_quantizationLevels(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* video_BackgroundSubtractorGMG_backgroundPrior(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* video_BackgroundSubtractorGMG_decisionThreshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* video_BackgroundSubtractorGMG_smoothingRadius(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorGMG_updateBackgroundModel_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorGMG_updateBackgroundModel_set(IntPtr obj, int value);

        #endregion
        #endregion

        #region tracking

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_updateMotionHistory(
            IntPtr silhouette, IntPtr mhi,
            double timestamp, double duration);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_calcMotionGradient(
            IntPtr mhi, IntPtr mask, IntPtr orientation,
            double delta1, double delta2, int apertureSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_calcGlobalOrientation(
            IntPtr orientation, IntPtr mask,
            IntPtr mhi, double timestamp, double duration);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_segmentMotion(
            IntPtr mhi, IntPtr segmask, IntPtr boundingRects,
            double timestamp, double segThresh);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D video_CamShift(
            IntPtr probImage, ref CvRect window, CvTermCriteria criteria);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_meanShift(
            IntPtr probImage, ref CvRect window, CvTermCriteria criteria);


        // Kalman filter
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams,
            int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_KalmanFilter_init(IntPtr obj, int dynamParams, int measureParams,
            int controlParams, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_KalmanFilter_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_predict(IntPtr obj, IntPtr control);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_correct(IntPtr obj, IntPtr measurement);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_statePre(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_statePost(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_transitionMatrix(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_controlMatrix(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_measurementMatrix(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_processNoiseCov(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_measurementNoiseCov(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_errorCovPre(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_gain(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_KalmanFilter_errorCovPost(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_buildOpticalFlowPyramid(
            IntPtr img, IntPtr pyramid,
            CvSize winSize, int maxLevel, int withDerivatives,
            int pyrBorder, int derivBorder, int tryReuseInputImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_calcOpticalFlowPyrLK_InputArray(
            IntPtr prevImg, IntPtr nextImg,
            IntPtr prevPts, IntPtr nextPts,
            IntPtr status, IntPtr err,
            CvSize winSize, int maxLevel, CvTermCriteria criteria,
            int flags, double minEigThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_calcOpticalFlowPyrLK_vector(
            IntPtr prevImg, IntPtr nextImg,
            Point2f[] prevPts, int prevPtsSize,
            IntPtr nextPts, IntPtr status, IntPtr err,
            CvSize winSize, int maxLevel, CvTermCriteria criteria,
            int flags, double minEigThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_calcOpticalFlowFarneback(
            IntPtr prev, IntPtr next,
            IntPtr flow, double pyrScale, int levels, int winSize,
            int iterations, int polyN, double polySigma, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_estimateRigidTransform(
            IntPtr src, IntPtr dst, int fullAffine);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_calcOpticalFlowSF1(
            IntPtr from,
            IntPtr to,
            IntPtr flow,
            int layers,
            int averagingBlockSize,
            int maxFlow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_calcOpticalFlowSF2(
            IntPtr from,
            IntPtr to,
            IntPtr flow,
            int layers,
            int averagingBlockSize,
            int maxFlow,
            double sigmaDist,
            double sigmaColor,
            int postprocessWindow,
            double sigmaDistFix,
            double sigmaColorFix,
            double occThr,
            int upscaleAveragingRadius,
            double upscaleSigmaDist,
            double upscaleSigmaColor,
            double speedUpThr);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_DenseOpticalFlow_calc(
            IntPtr obj, IntPtr i0, IntPtr i1, IntPtr flow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_DenseOpticalFlow_collectGarbage(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_DenseOpticalFlow_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_createOptFlow_DualTVL1();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_DenseOpticalFlow_obj(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);

        #endregion
    }
}