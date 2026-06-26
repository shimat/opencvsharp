using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_CamShift(
        IntPtr probImage, ref Rect window, TermCriteria criteria, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_meanShift(
        IntPtr probImage, ref Rect window, TermCriteria criteria, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_buildOpticalFlowPyramid1(
        IntPtr img, IntPtr pyramid,
        Size winSize, int maxLevel, int withDerivatives,
        int pyrBorder, int derivBorder, int tryReuseInputImage, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_buildOpticalFlowPyramid2(
        IntPtr img, IntPtr pyramidVec,
        Size winSize, int maxLevel, int withDerivatives,
        int pyrBorder, int derivBorder, int tryReuseInputImage, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_calcOpticalFlowPyrLK_InputArray(
        IntPtr prevImg, IntPtr nextImg,
        IntPtr prevPts, IntPtr nextPts,
        IntPtr status, IntPtr err,
        Size winSize, int maxLevel, TermCriteria criteria,
        int flags, double minEigThreshold);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_calcOpticalFlowPyrLK_vector(
        IntPtr prevImg, IntPtr nextImg,
        Point2f[] prevPts, int prevPtsSize,
        IntPtr nextPts, IntPtr status, IntPtr err,
        Size winSize, int maxLevel, TermCriteria criteria,
        int flags, double minEigThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_calcOpticalFlowFarneback(
        IntPtr prev, IntPtr next,
        IntPtr flow, double pyrScale, int levels, int winSize,
        int iterations, int polyN, double polySigma, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_computeECC(
        IntPtr templateImage, IntPtr inputImage, IntPtr inputMask, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_findTransformECC1(
        IntPtr templateImage, IntPtr inputImage,
        IntPtr warpMatrix, int motionType, TermCriteria criteria,
        IntPtr inputMask, int gaussFiltSize, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_findTransformECC2(
        IntPtr templateImage, IntPtr inputImage,
        IntPtr warpMatrix, int motionType, TermCriteria criteria, 
        IntPtr inputMask, out double returnValue);

    #region Kalman filter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_new2(
        int dynamParams, int measureParams, int controlParams, int type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_init(IntPtr obj, int dynamParams, int measureParams,
        int controlParams, int type);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_predict(IntPtr obj, IntPtr control, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_correct(IntPtr obj, IntPtr measurement, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_statePre(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_statePost(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_transitionMatrix(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_controlMatrix(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_measurementMatrix(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_processNoiseCov(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_measurementNoiseCov(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_errorCovPre(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_gain(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_errorCovPost(IntPtr obj, out IntPtr returnValue);

    #endregion

    #region Tracker

    // Tracker

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Tracker_init(OpenCvSafeHandle obj, IntPtr image, Rect boundingBox);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Tracker_update(OpenCvSafeHandle obj, IntPtr image, ref Rect boundingBox, out int returnValue);
        

    // TrackerMIL

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_TrackerMIL_create1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus video_TrackerMIL_create2(TrackerMIL.Params* parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerMIL_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerMIL_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    // TODO
    /*
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DenseOpticalFlow_calc(
        IntPtr obj, IntPtr i0, IntPtr i1, IntPtr flow);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DenseOpticalFlow_collectGarbage(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DenseOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);
    //*/
}
