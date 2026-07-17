using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable P/Invoke representation of the scalar/POD fields of <c>cv::ECCParameters</c>
/// (everything except <c>itersPerLevel</c>, a <c>std::vector&lt;int&gt;</c> passed as a separate
/// argument). This type is internal; use <c>OpenCvSharp.ECCParameters</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvECCParameters
{
    public int MotionType;
    public TermCriteria Criteria;
    public int GaussFiltSize;
    public int NLevels;
    public int Interpolation;
}

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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_findTransformECCWithMask(
        in InputArrayProxy templateImage, in InputArrayProxy inputImage,
        in InputArrayProxy templateMask, in InputArrayProxy inputMask,
        in InputOutputArrayProxy warpMatrix, int motionType, TermCriteria criteria,
        int gaussFiltSize, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_findTransformECCMultiScale(
        in InputArrayProxy reference, in InputArrayProxy sample,
        in InputOutputArrayProxy warpMatrix, in CvECCParameters eccParameters,
        IntPtr itersPerLevel,
        in InputArrayProxy referenceMask, in InputArrayProxy sampleMask, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_readOpticalFlow(
        [MarshalAs(UnmanagedType.LPStr)] string path, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_writeOpticalFlow(
        [MarshalAs(UnmanagedType.LPStr)] string path, in InputArrayProxy flow, out int returnValue);

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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Tracker_getTrackingScore(OpenCvSafeHandle obj, out float returnValue);

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

    #region DenseOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_DenseOpticalFlow_calc(
        OpenCvSafeHandle obj, in InputArrayProxy i0, in InputArrayProxy i1, in InputOutputArrayProxy flow);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DenseOpticalFlow_collectGarbage(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DenseOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DenseOpticalFlow_delete(IntPtr ptr);

    #endregion

    #region SparseOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_SparseOpticalFlow_calc(
        OpenCvSafeHandle obj, in InputArrayProxy prevImg, in InputArrayProxy nextImg,
        in InputArrayProxy prevPts, in InputOutputArrayProxy nextPts,
        in OutputArrayProxy status, in OutputArrayProxy err);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_SparseOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_SparseOpticalFlow_delete(IntPtr ptr);

    #endregion

    #region FarnebackOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_create(
        int numLevels, double pyrScale, int fastPyramids, int winSize, int numIters,
        int polyN, double polySigma, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_FarnebackOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_FarnebackOpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getNumLevels(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setNumLevels(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getPyrScale(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setPyrScale(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getFastPyramids(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setFastPyramids(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getWinSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setWinSize(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getNumIters(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setNumIters(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getPolyN(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setPolyN(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getPolySigma(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setPolySigma(OpenCvSafeHandle obj, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_getFlags(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_FarnebackOpticalFlow_setFlags(OpenCvSafeHandle obj, int value);

    #endregion

    #region VariationalRefinement

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_create(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_VariationalRefinement_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_VariationalRefinement_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus video_VariationalRefinement_calcUV(
        OpenCvSafeHandle obj, in InputArrayProxy i0, in InputArrayProxy i1,
        in InputOutputArrayProxy flowU, in InputOutputArrayProxy flowV);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getFixedPointIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setFixedPointIterations(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getSorIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setSorIterations(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getOmega(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setOmega(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getAlpha(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setAlpha(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getDelta(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setDelta(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getGamma(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setGamma(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_getEpsilon(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_VariationalRefinement_setEpsilon(OpenCvSafeHandle obj, float value);

    #endregion

    #region DISOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_create(int preset, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DISOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_DISOpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getFinestScale(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setFinestScale(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getCoarsestScale(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setCoarsestScale(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getPatchSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setPatchSize(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getPatchStride(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setPatchStride(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getGradientDescentIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setGradientDescentIterations(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getVariationalRefinementIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setVariationalRefinementIterations(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getVariationalRefinementAlpha(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setVariationalRefinementAlpha(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getVariationalRefinementDelta(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setVariationalRefinementDelta(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getVariationalRefinementGamma(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setVariationalRefinementGamma(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getVariationalRefinementEpsilon(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setVariationalRefinementEpsilon(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getUseMeanNormalization(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setUseMeanNormalization(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_getUseSpatialPropagation(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_DISOpticalFlow_setUseSpatialPropagation(OpenCvSafeHandle obj, int value);

    #endregion

    #region SparsePyrLKOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_create(
        Size winSize, int maxLevel, TermCriteria criteria, int flags, double minEigThreshold, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_SparsePyrLKOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_SparsePyrLKOpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_getWinSize(OpenCvSafeHandle obj, out Size returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_setWinSize(OpenCvSafeHandle obj, Size value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_getMaxLevel(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_setMaxLevel(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_getTermCriteria(OpenCvSafeHandle obj, out TermCriteria returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_setTermCriteria(OpenCvSafeHandle obj, TermCriteria value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_getFlags(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_setFlags(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_getMinEigThreshold(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_SparsePyrLKOpticalFlow_setMinEigThreshold(OpenCvSafeHandle obj, double value);

    #endregion

    #region TrackerDaSiamRPN

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus video_TrackerDaSiamRPN_create(WTrackerDaSiamRPNParams* parameters, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerDaSiamRPN_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerDaSiamRPN_delete(IntPtr ptr);

    #endregion

    #region TrackerNano

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus video_TrackerNano_create(WTrackerNanoParams* parameters, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerNano_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerNano_delete(IntPtr ptr);

    #endregion

    #region TrackerVit

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus video_TrackerVit_create(WTrackerVitParams* parameters, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerVit_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_TrackerVit_delete(IntPtr ptr);

    #endregion
}
