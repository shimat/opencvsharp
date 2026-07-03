using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_CamShift(
        in InputArrayProxy probImage, ref Rect window, TermCriteria criteria, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_meanShift(
        in InputArrayProxy probImage, ref Rect window, TermCriteria criteria, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_buildOpticalFlowPyramid1(
        in InputArrayProxy img, in OutputArrayProxy pyramid,
        Size winSize, int maxLevel, int withDerivatives,
        int pyrBorder, int derivBorder, int tryReuseInputImage, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_buildOpticalFlowPyramid2(
        in InputArrayProxy img, IntPtr pyramidVec,
        Size winSize, int maxLevel, int withDerivatives,
        int pyrBorder, int derivBorder, int tryReuseInputImage, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_calcOpticalFlowPyrLK_InputArray(
        in InputArrayProxy prevImg, in InputArrayProxy nextImg,
        in InputArrayProxy prevPts, in InputOutputArrayProxy nextPts,
        in OutputArrayProxy status, in OutputArrayProxy err,
        Size winSize, int maxLevel, TermCriteria criteria,
        int flags, double minEigThreshold);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_calcOpticalFlowPyrLK_vector(
        in InputArrayProxy prevImg, in InputArrayProxy nextImg,
        Point2f[] prevPts, int prevPtsSize,
        IntPtr nextPts, IntPtr status, IntPtr err,
        Size winSize, int maxLevel, TermCriteria criteria,
        int flags, double minEigThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_calcOpticalFlowFarneback(
        in InputArrayProxy prev, in InputArrayProxy next,
        in InputOutputArrayProxy flow, double pyrScale, int levels, int winSize,
        int iterations, int polyN, double polySigma, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_computeECC(
        in InputArrayProxy templateImage, in InputArrayProxy inputImage, in InputArrayProxy inputMask, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_findTransformECC1(
        in InputArrayProxy templateImage, in InputArrayProxy inputImage,
        in InputOutputArrayProxy warpMatrix, int motionType, TermCriteria criteria,
        in InputArrayProxy inputMask, int gaussFiltSize, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_findTransformECC2(
        in InputArrayProxy templateImage, in InputArrayProxy inputImage,
        in InputOutputArrayProxy warpMatrix, int motionType, TermCriteria criteria, 
        in InputArrayProxy inputMask, out double returnValue);

    #region Kalman filter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_new2(
        int dynamParams, int measureParams, int controlParams, int type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_init(OpenCvSafeHandle obj, int dynamParams, int measureParams,
        int controlParams, int type);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_predict(OpenCvSafeHandle obj, OpenCvSafeHandle control, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_correct(OpenCvSafeHandle obj, IntPtr measurement, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_statePre(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_statePost(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_transitionMatrix(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_controlMatrix(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_measurementMatrix(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_processNoiseCov(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_measurementNoiseCov(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_errorCovPre(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_gain(OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_KalmanFilter_errorCovPost(OpenCvSafeHandle obj, out IntPtr returnValue);

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
    internal static partial ExceptionStatus video_DenseOpticalFlow_calc(
        IntPtr obj, in InputArrayProxy i0, in InputArrayProxy i1, in InputOutputArrayProxy flow);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DenseOpticalFlow_collectGarbage(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DenseOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);
    //*/
}
