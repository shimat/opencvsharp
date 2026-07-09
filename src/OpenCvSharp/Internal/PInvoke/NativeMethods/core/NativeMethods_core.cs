using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial RotatedRect core_RotatedRect_byThreeVertexPoints(Point2f p1, Point2f p2, Point2f p3);

    #region utility.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int core_setBreakOnError(int flag);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr redirectError(CvErrorCallback errCallback, IntPtr userdata, ref IntPtr prevUserdata);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_setSilentErrorHandler();

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getLastException(out int code, out int line, IntPtr func, IntPtr file, IntPtr message);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_setNumThreads(int nthreads);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getNumThreads(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getThreadNum(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getBuildInformation(IntPtr buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus core_getVersionString(byte* buf, int maxLength);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getVersionMajor(out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getVersionMinor(out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getVersionRevision(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getTickCount(out long returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getTickFrequency(out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getCPUTickCount(out long returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_checkHardwareSupport(int feature, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getHardwareFeatureName(int feature, IntPtr buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getCPUFeaturesLine(IntPtr buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getNumberOfCPUs(out int returnValue);

    /*
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr core_fastMalloc(IntPtr bufSize);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void core_fastFree(IntPtr ptr);
    */

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_setUseOptimized(int onoff);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_useOptimized(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_useIPP(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_setUseIPP(int flag);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getIppVersion(IntPtr buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_useIPP_NotExact(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_setUseIPP_NotExact(int flag);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_format(in InputArrayProxy mtx, int fmt, IntPtr buf);

    #endregion

    #region logger.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_logger_setLogLevel(LogLevel logLevel, out LogLevel returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_logger_getLogLevel(out LogLevel returnValue);

    #endregion

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_borderInterpolate(
        int p, int len, int borderType, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_copyMakeBorder(
        in InputArrayProxy src, in OutputArrayProxy dst, int top, int bottom, int left, int right, int borderType, Scalar value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_add(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, in InputArrayProxy mask, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_subtract_InputArray2(
        in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, in InputArrayProxy mask, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_subtract_InputArrayScalar(
        in InputArrayProxy src1, Scalar src2, in OutputArrayProxy dst, in InputArrayProxy mask, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_subtract_ScalarInputArray(
        Scalar src1, in InputArrayProxy src2, in OutputArrayProxy dst, in InputArrayProxy mask, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_multiply(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_divide1(double scale, in InputArrayProxy src2, in OutputArrayProxy dst, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_divide2(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_scaleAdd(in InputArrayProxy src1, double alpha, in InputArrayProxy src2, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_addWeighted(in InputArrayProxy src1, double alpha, in InputArrayProxy src2,
        double beta, double gamma, in OutputArrayProxy dst, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_convertScaleAbs(in InputArrayProxy src, in OutputArrayProxy dst, double alpha, double beta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_LUT(in InputArrayProxy src, in InputArrayProxy lut, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sum(in InputArrayProxy src, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_hasNonZero(in InputArrayProxy src, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_countNonZero(in InputArrayProxy src, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_findNonZero(in InputArrayProxy src, in OutputArrayProxy idx);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mean(in InputArrayProxy src, in InputArrayProxy mask, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_meanStdDev_OutputArray(
        in InputArrayProxy src, in OutputArrayProxy mean, in OutputArrayProxy stddev, in InputArrayProxy mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_meanStdDev_Scalar(
        in InputArrayProxy src, out Scalar mean, out Scalar stddev, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_norm1(
        in InputArrayProxy src1, int normType, in InputArrayProxy mask, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_norm2(
        in InputArrayProxy src1, in InputArrayProxy src2, int normType, in InputArrayProxy mask, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PSNR(in InputArrayProxy src1, in InputArrayProxy src2, double r, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_batchDistance(in InputArrayProxy src1, in InputArrayProxy src2,
        in OutputArrayProxy dist, int dtype, in OutputArrayProxy nidx,
        int normType, int k, in InputArrayProxy mask,
        int update, int crosscheck);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_normalize(in InputArrayProxy src, in InputOutputArrayProxy dst, double alpha, double beta,
        int normType, int dtype, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_reduceArgMax(in InputArrayProxy src, in OutputArrayProxy dst, int axis, [MarshalAs(UnmanagedType.U1)] bool lastIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_reduceArgMin(in InputArrayProxy src, in OutputArrayProxy dst, int axis, [MarshalAs(UnmanagedType.U1)] bool lastIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxLoc1(in InputArrayProxy src, out double minVal, out double maxVal);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxLoc2(in InputArrayProxy src, out double minVal, out double maxVal,
        out Point minLoc, out Point maxLoc, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxIdx1(in InputArrayProxy src, out double minVal, out double maxVal);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxIdx2(in InputArrayProxy src, out double minVal, out double maxVal,
        [MarshalAs(UnmanagedType.LPArray), Out] int[] minIdx, [MarshalAs(UnmanagedType.LPArray), Out] int[] maxIdx, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_reduce(in InputArrayProxy src, in OutputArrayProxy dst, int dim, int rtype, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_merge(ReadOnlySpan<IntPtr> mv, uint count, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_split(IntPtr src, IntPtr mv);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mixChannels(ReadOnlySpan<IntPtr> src, uint nsrcs,
        ReadOnlySpan<IntPtr> dst, uint ndsts, int[] fromTo, uint npairs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_extractChannel(in InputArrayProxy src, in OutputArrayProxy dst, int coi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_insertChannel(in InputArrayProxy src, in InputOutputArrayProxy dst, int coi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_flip(in InputArrayProxy src, in OutputArrayProxy dst, int flipCode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_flipND(in InputArrayProxy src, in OutputArrayProxy dst, int axis);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_broadcast(in InputArrayProxy src, in InputArrayProxy shape, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_rotate(in InputArrayProxy src, in OutputArrayProxy dst, int rotateCode);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_repeat1(in InputArrayProxy src, int ny, int nx, in OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_repeat2(IntPtr src, int ny, int nx, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_hconcat1(ReadOnlySpan<IntPtr> src, uint nsrc, in OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_hconcat2(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_vconcat1(ReadOnlySpan<IntPtr> src, uint nsrc, in OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_vconcat2(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_and(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_or(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_xor(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_not(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_absdiff(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_copyTo(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_inRange_InputArray(in InputArrayProxy src, in InputArrayProxy lowerb, in InputArrayProxy upperb, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_inRange_Scalar(in InputArrayProxy src, Scalar lowerb, Scalar upperb, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_compare(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, int cmpop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_min1(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min_MatDouble(IntPtr src1, double src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_max1(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max_MatDouble(IntPtr src1, double src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sqrt(in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_pow_Mat(in InputArrayProxy src, double power, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_exp_Mat(in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_log_Mat(in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_polarToCart(in InputArrayProxy magnitude, in InputArrayProxy angle, in OutputArrayProxy x, in OutputArrayProxy y, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_cartToPolar(in InputArrayProxy x, in InputArrayProxy y, in OutputArrayProxy magnitude, in OutputArrayProxy angle, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_phase(in InputArrayProxy x, in InputArrayProxy y, in OutputArrayProxy angle, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_magnitude_Mat(in InputArrayProxy x, in InputArrayProxy y, in OutputArrayProxy magnitude);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_checkRange(in InputArrayProxy a, int quiet, out Point pos, double minVal, double maxVal, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_patchNaNs(in InputOutputArrayProxy a, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_finiteMask(in InputArrayProxy src, in OutputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_gemm(in InputArrayProxy src1, in InputArrayProxy src2, double alpha, in InputArrayProxy src3, double gamma, in OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mulTransposed(in InputArrayProxy src, in OutputArrayProxy dst, int aTa, in InputArrayProxy delta, double scale, int dtype);

    // MIGRATION (issue #1976, strategy 3): array arguments are ArrayProxy passed BY VALUE; the native
    // side rebuilds cv::_InputArray/_OutputArray on its stack. One signature serves both the ref-struct
    // path (optimized kinds) and the still-class path (Raw kinds wrapping an existing cv::_InputArray*).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_transpose(in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_transposeND(
        in InputArrayProxy src, [In] int[] order, int orderLength, in OutputArrayProxy dst);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_transform(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy m);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_perspectiveTransform(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform_Mat(IntPtr src, IntPtr dst, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_perspectiveTransform_Point2f(IntPtr src, int srcLength, IntPtr dst, int dstLength, in InputArrayProxy m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_perspectiveTransform_Point2d(IntPtr src, int srcLength, IntPtr dst, int dstLength, in InputArrayProxy m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_perspectiveTransform_Point3f(IntPtr src, int srcLength, IntPtr dst, int dstLength, in InputArrayProxy m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_perspectiveTransform_Point3d(IntPtr src, int srcLength, IntPtr dst, int dstLength, in InputArrayProxy m);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_completeSymm(in InputOutputArrayProxy mtx, int lowerToUpper);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_setIdentity(in InputOutputArrayProxy mtx, Scalar s);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_determinant(in InputArrayProxy mtx, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_trace(in InputArrayProxy mtx, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_invert(in InputArrayProxy src, in OutputArrayProxy dst, int flags, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solve(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solveLP(in InputArrayProxy func, in InputArrayProxy constr, in OutputArrayProxy z, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sort(in InputArrayProxy src, in OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sortIdx(in InputArrayProxy src, in OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solveCubic(in InputArrayProxy coeffs, in OutputArrayProxy roots, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solvePoly(in InputArrayProxy coeffs, in OutputArrayProxy roots, int maxIters, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_eigen(in InputArrayProxy src, in OutputArrayProxy eigenvalues, in OutputArrayProxy eigenvectors, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_eigenNonSymmetric(in InputArrayProxy src, in OutputArrayProxy eigenvalues, in OutputArrayProxy eigenvectors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_calcCovarMatrix_Mat(ReadOnlySpan<IntPtr> samples,
        int nsamples, IntPtr covar, IntPtr mean, int flags, int ctype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_calcCovarMatrix_InputArray(in InputArrayProxy samples, in OutputArrayProxy covar,
        in InputOutputArrayProxy mean, int flags, int ctype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCACompute(in InputArrayProxy data, in InputOutputArrayProxy mean, in OutputArrayProxy eigenvectors, int maxComponents);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCACompute2(in InputArrayProxy data, in InputOutputArrayProxy mean, in OutputArrayProxy eigenvectors, in OutputArrayProxy eigenvalues, int maxComponents);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCAComputeVar(in InputArrayProxy data, in InputOutputArrayProxy mean, in OutputArrayProxy eigenvectors, double retainedVariance);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCAComputeVar2(in InputArrayProxy data, in InputOutputArrayProxy mean, in OutputArrayProxy eigenvectors, in OutputArrayProxy eigenvalues, double retainedVariance);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCAProject(in InputArrayProxy data, in InputArrayProxy mean, in InputArrayProxy eigenvectors, in OutputArrayProxy result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCABackProject(in InputArrayProxy data, in InputArrayProxy mean, in InputArrayProxy eigenvectors, in OutputArrayProxy result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_SVDecomp(in InputArrayProxy src, in OutputArrayProxy w, in OutputArrayProxy u, in OutputArrayProxy vt, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_SVBackSubst(in InputArrayProxy w, in InputArrayProxy u, in InputArrayProxy vt, in InputArrayProxy rhs, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_Mahalanobis(in InputArrayProxy v1, in InputArrayProxy v2, in InputArrayProxy icovar, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_dft(in InputArrayProxy src, in OutputArrayProxy dst, int flags, int nonzeroRows);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_idft(in InputArrayProxy src, in OutputArrayProxy dst, int flags, int nonzeroRows);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_dct(in InputArrayProxy src, in OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_idct(in InputArrayProxy src, in OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mulSpectrums(in InputArrayProxy a, in InputArrayProxy b, in OutputArrayProxy c, int flags, int conjB);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getOptimalDFTSize(int vecsize, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_theRNG_get(out ulong returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_theRNG_set(ulong returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randu_InputArray(in InputOutputArrayProxy dst, in InputArrayProxy low, in InputArrayProxy high);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randu_Scalar(in InputOutputArrayProxy dst, Scalar low, Scalar high);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randn_InputArray(in InputOutputArrayProxy dst, in InputArrayProxy mean, in InputArrayProxy stddev);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randn_Scalar(in InputOutputArrayProxy dst, Scalar mean, Scalar stddev);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randShuffle(in InputOutputArrayProxy dst, double iterFactor, ref ulong rng);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randShuffle(in InputOutputArrayProxy dst, double iterFactor, IntPtr rng);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_kmeans(
        in InputArrayProxy data, int k, in InputOutputArrayProxy bestLabels,
        TermCriteria criteria, int attempts, int flags, in OutputArrayProxy centers,
        out double returnValue);

    #region base.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_cubeRoot(float val, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_fastAtan2(float y, float x, out float returnValue);

    #endregion
}
