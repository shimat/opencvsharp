using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect video_CamShift(
            IntPtr probImage, ref Rect window, TermCriteria criteria);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_meanShift(
            IntPtr probImage, ref Rect window, TermCriteria criteria);
        
        // Kalman filter
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams,
            int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_KalmanFilter_init(IntPtr obj, int dynamParams, int measureParams,
            int controlParams, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_KalmanFilter_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_predict(IntPtr obj, IntPtr control);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_correct(IntPtr obj, IntPtr measurement);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_statePre(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_statePost(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_transitionMatrix(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_controlMatrix(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_measurementMatrix(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_processNoiseCov(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_measurementNoiseCov(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_errorCovPre(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_gain(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_errorCovPost(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_buildOpticalFlowPyramid1(
            IntPtr img, IntPtr pyramid,
            Size winSize, int maxLevel, int withDerivatives,
            int pyrBorder, int derivBorder, int tryReuseInputImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_buildOpticalFlowPyramid2(
            IntPtr img, IntPtr pyramidVec,
            Size winSize, int maxLevel, int withDerivatives,
            int pyrBorder, int derivBorder, int tryReuseInputImage);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_calcOpticalFlowPyrLK_InputArray(
            IntPtr prevImg, IntPtr nextImg,
            IntPtr prevPts, IntPtr nextPts,
            IntPtr status, IntPtr err,
            Size winSize, int maxLevel, TermCriteria criteria,
            int flags, double minEigThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_calcOpticalFlowPyrLK_vector(
            IntPtr prevImg, IntPtr nextImg,
            Point2f[] prevPts, int prevPtsSize,
            IntPtr nextPts, IntPtr status, IntPtr err,
            Size winSize, int maxLevel, TermCriteria criteria,
            int flags, double minEigThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_calcOpticalFlowFarneback(
            IntPtr prev, IntPtr next,
            IntPtr flow, double pyrScale, int levels, int winSize,
            int iterations, int polyN, double polySigma, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_DenseOpticalFlow_calc(
            IntPtr obj, IntPtr i0, IntPtr i1, IntPtr flow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_DenseOpticalFlow_collectGarbage(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_Ptr_DenseOpticalFlow_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);
    }
}