using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect video_CamShift(
            IntPtr probImage, ref Rect window, TermCriteria criteria);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_meanShift(
            IntPtr probImage, ref Rect window, TermCriteria criteria);
        
        // Kalman filter
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_new1();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_new2(int dynamParams, int measureParams, int controlParams,
            int type);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_KalmanFilter_init(IntPtr obj, int dynamParams, int measureParams,
            int controlParams, int type);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_KalmanFilter_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_predict(IntPtr obj, IntPtr control);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_correct(IntPtr obj, IntPtr measurement);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_statePre(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_statePost(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_transitionMatrix(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_controlMatrix(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_measurementMatrix(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_processNoiseCov(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_measurementNoiseCov(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_errorCovPre(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_gain(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_KalmanFilter_errorCovPost(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_buildOpticalFlowPyramid1(
            IntPtr img, IntPtr pyramid,
            Size winSize, int maxLevel, int withDerivatives,
            int pyrBorder, int derivBorder, int tryReuseInputImage);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_buildOpticalFlowPyramid2(
            IntPtr img, IntPtr pyramidVec,
            Size winSize, int maxLevel, int withDerivatives,
            int pyrBorder, int derivBorder, int tryReuseInputImage);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_calcOpticalFlowPyrLK_InputArray(
            IntPtr prevImg, IntPtr nextImg,
            IntPtr prevPts, IntPtr nextPts,
            IntPtr status, IntPtr err,
            Size winSize, int maxLevel, TermCriteria criteria,
            int flags, double minEigThreshold);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_calcOpticalFlowPyrLK_vector(
            IntPtr prevImg, IntPtr nextImg,
            Point2f[] prevPts, int prevPtsSize,
            IntPtr nextPts, IntPtr status, IntPtr err,
            Size winSize, int maxLevel, TermCriteria criteria,
            int flags, double minEigThreshold);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_calcOpticalFlowFarneback(
            IntPtr prev, IntPtr next,
            IntPtr flow, double pyrScale, int levels, int winSize,
            int iterations, int polyN, double polySigma, int flags);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_DenseOpticalFlow_calc(
            IntPtr obj, IntPtr i0, IntPtr i1, IntPtr flow);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_DenseOpticalFlow_collectGarbage(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_Ptr_DenseOpticalFlow_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);
    }
}