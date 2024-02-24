using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_CamShift(
        IntPtr probImage, ref Rect window, TermCriteria criteria, out RotatedRect returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_meanShift(
        IntPtr probImage, ref Rect window, TermCriteria criteria, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_buildOpticalFlowPyramid1(
        IntPtr img, IntPtr pyramid,
        Size winSize, int maxLevel, int withDerivatives,
        int pyrBorder, int derivBorder, int tryReuseInputImage, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_buildOpticalFlowPyramid2(
        IntPtr img, IntPtr pyramidVec,
        Size winSize, int maxLevel, int withDerivatives,
        int pyrBorder, int derivBorder, int tryReuseInputImage, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_calcOpticalFlowPyrLK_InputArray(
        IntPtr prevImg, IntPtr nextImg,
        IntPtr prevPts, IntPtr nextPts,
        IntPtr status, IntPtr err,
        Size winSize, int maxLevel, TermCriteria criteria,
        int flags, double minEigThreshold);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_calcOpticalFlowPyrLK_vector(
        IntPtr prevImg, IntPtr nextImg,
        Point2f[] prevPts, int prevPtsSize,
        IntPtr nextPts, IntPtr status, IntPtr err,
        Size winSize, int maxLevel, TermCriteria criteria,
        int flags, double minEigThreshold);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_calcOpticalFlowFarneback(
        IntPtr prev, IntPtr next,
        IntPtr flow, double pyrScale, int levels, int winSize,
        int iterations, int polyN, double polySigma, int flags);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_computeECC(
        IntPtr templateImage, IntPtr inputImage, IntPtr inputMask, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_findTransformECC1(
        IntPtr templateImage, IntPtr inputImage,
        IntPtr warpMatrix, int motionType, TermCriteria criteria,
        IntPtr inputMask, int gaussFiltSize, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_findTransformECC2(
        IntPtr templateImage, IntPtr inputImage,
        IntPtr warpMatrix, int motionType, TermCriteria criteria, 
        IntPtr inputMask, out double returnValue);

    #region Kalman filter

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_new1(out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_new2(
        int dynamParams, int measureParams, int controlParams, int type, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_init(IntPtr obj, int dynamParams, int measureParams,
        int controlParams, int type);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_predict(IntPtr obj, IntPtr control, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_correct(IntPtr obj, IntPtr measurement, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_statePre(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_statePost(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_transitionMatrix(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_controlMatrix(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_measurementMatrix(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_processNoiseCov(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_measurementNoiseCov(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_errorCovPre(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_gain(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_KalmanFilter_errorCovPost(IntPtr obj, out IntPtr returnValue);

    #endregion

    #region Tracker

    // Tracker

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Tracker_init(IntPtr obj, IntPtr image, Rect boundingBox);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Tracker_update(IntPtr obj, IntPtr image, ref Rect boundingBox, out int returnValue);
        

    // TrackerMIL

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_TrackerMIL_create1(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus video_TrackerMIL_create2(TrackerMIL.Params* parameters, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Ptr_TrackerMIL_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Ptr_TrackerMIL_get(IntPtr ptr, out IntPtr returnValue);


    // TrackerGOTURN

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_TrackerGOTURN_create1(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus video_TrackerGOTURN_create2(TrackerGOTURN.Params* parameters, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Ptr_TrackerGOTURN_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Ptr_TrackerGOTURN_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    // TODO
    /*
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_DenseOpticalFlow_calc(
        IntPtr obj, IntPtr i0, IntPtr i1, IntPtr flow);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_DenseOpticalFlow_collectGarbage(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Ptr_DenseOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);
    //*/
}
