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
    public static partial ExceptionStatus core_format(IntPtr mtx, int fmt, IntPtr buf);

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
        InputArrayProxy src, OutputArrayProxy dst, int top, int bottom, int left, int right, int borderType, Scalar value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_add(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, InputArrayProxy mask, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_subtract_InputArray2(
        InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, InputArrayProxy mask, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_subtract_InputArrayScalar(
        InputArrayProxy src1, Scalar src2, OutputArrayProxy dst, InputArrayProxy mask, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_subtract_ScalarInputArray(
        Scalar src1, InputArrayProxy src2, OutputArrayProxy dst, InputArrayProxy mask, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_multiply(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_divide1(double scale, InputArrayProxy src2, OutputArrayProxy dst, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_divide2(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_scaleAdd(InputArrayProxy src1, double alpha, InputArrayProxy src2, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_addWeighted(InputArrayProxy src1, double alpha, InputArrayProxy src2,
        double beta, double gamma, OutputArrayProxy dst, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_convertScaleAbs(InputArrayProxy src, OutputArrayProxy dst, double alpha, double beta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_LUT(InputArrayProxy src, InputArrayProxy lut, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sum(InputArrayProxy src, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_countNonZero(InputArrayProxy src, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_findNonZero(InputArrayProxy src, OutputArrayProxy idx);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mean(InputArrayProxy src, InputArrayProxy mask, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_meanStdDev_OutputArray(
        InputArrayProxy src, OutputArrayProxy mean, OutputArrayProxy stddev, InputArrayProxy mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_meanStdDev_Scalar(
        InputArrayProxy src, out Scalar mean, out Scalar stddev, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_norm1(
        InputArrayProxy src1, int normType, InputArrayProxy mask, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_norm2(
        InputArrayProxy src1, InputArrayProxy src2, int normType, InputArrayProxy mask, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PSNR(InputArrayProxy src1, InputArrayProxy src2, double r, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_batchDistance(InputArrayProxy src1, InputArrayProxy src2,
        OutputArrayProxy dist, int dtype, OutputArrayProxy nidx,
        int normType, int k, InputArrayProxy mask,
        int update, int crosscheck);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_normalize(InputArrayProxy src, InputOutputArrayProxy dst, double alpha, double beta,
        int normType, int dtype, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_reduceArgMax(InputArrayProxy src, OutputArrayProxy dst, int axis, [MarshalAs(UnmanagedType.U1)] bool lastIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_reduceArgMin(InputArrayProxy src, OutputArrayProxy dst, int axis, [MarshalAs(UnmanagedType.U1)] bool lastIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxLoc1(InputArrayProxy src, out double minVal, out double maxVal);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxLoc2(InputArrayProxy src, out double minVal, out double maxVal,
        out Point minLoc, out Point maxLoc, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxIdx1(InputArrayProxy src, out double minVal, out double maxVal);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_minMaxIdx2(InputArrayProxy src, out double minVal, out double maxVal,
        [MarshalAs(UnmanagedType.LPArray), Out] int[] minIdx, [MarshalAs(UnmanagedType.LPArray), Out] int[] maxIdx, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_reduce(InputArrayProxy src, OutputArrayProxy dst, int dim, int rtype, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_merge([MarshalAs(UnmanagedType.LPArray)] IntPtr[] mv, uint count, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_split(IntPtr src, IntPtr mv);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_mixChannels(IntPtr[] src, uint nsrcs,
        IntPtr[] dst, uint ndsts, int[] fromTo, uint npairs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_extractChannel(InputArrayProxy src, OutputArrayProxy dst, int coi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_insertChannel(InputArrayProxy src, InputOutputArrayProxy dst, int coi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_flip(InputArrayProxy src, OutputArrayProxy dst, int flipCode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_rotate(InputArrayProxy src, OutputArrayProxy dst, int rotateCode);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_repeat1(InputArrayProxy src, int ny, int nx, OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_repeat2(IntPtr src, int ny, int nx, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_hconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_hconcat2(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_vconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_vconcat2(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_and(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_or(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_xor(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_bitwise_not(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_absdiff(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_copyTo(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_inRange_InputArray(InputArrayProxy src, InputArrayProxy lowerb, InputArrayProxy upperb, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_inRange_Scalar(InputArrayProxy src, Scalar lowerb, Scalar upperb, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_compare(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, int cmpop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_min1(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min_MatDouble(IntPtr src1, double src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_max1(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max_MatDouble(IntPtr src1, double src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sqrt(InputArrayProxy src, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_pow_Mat(InputArrayProxy src, double power, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_exp_Mat(InputArrayProxy src, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_log_Mat(InputArrayProxy src, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_polarToCart(InputArrayProxy magnitude, InputArrayProxy angle, OutputArrayProxy x, OutputArrayProxy y, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_cartToPolar(InputArrayProxy x, InputArrayProxy y, OutputArrayProxy magnitude, OutputArrayProxy angle, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_phase(InputArrayProxy x, InputArrayProxy y, OutputArrayProxy angle, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_magnitude_Mat(InputArrayProxy x, InputArrayProxy y, OutputArrayProxy magnitude);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_checkRange(InputArrayProxy a, int quiet, out Point pos, double minVal, double maxVal, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_patchNaNs(InputOutputArrayProxy a, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_gemm(InputArrayProxy src1, InputArrayProxy src2, double alpha, InputArrayProxy src3, double gamma, OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mulTransposed(InputArrayProxy src, OutputArrayProxy dst, int aTa, InputArrayProxy delta, double scale, int dtype);

    // MIGRATION (issue #1976, strategy 3): array arguments are ArrayProxy passed BY VALUE; the native
    // side rebuilds cv::_InputArray/_OutputArray on its stack. One signature serves both the ref-struct
    // path (optimized kinds) and the still-class path (Raw kinds wrapping an existing cv::_InputArray*).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_transpose(InputArrayProxy src, OutputArrayProxy dst);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_transform(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy m);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_perspectiveTransform(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform_Mat(IntPtr src, IntPtr dst, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform_Point2f(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform_Point2d(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform_Point3f(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform_Point3d(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_completeSymm(IntPtr mtx, int lowerToUpper);

    // FOUNDATION: ref-struct proxy path for an InputOutputArray argument.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_completeSymm_io(InputOutputArrayProxy mtx, int lowerToUpper);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_setIdentity(InputOutputArrayProxy mtx, Scalar s);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_determinant(InputArrayProxy mtx, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_trace(InputArrayProxy mtx, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_invert(InputArrayProxy src, OutputArrayProxy dst, int flags, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solve(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solveLP(InputArrayProxy func, InputArrayProxy constr, OutputArrayProxy z, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sort(InputArrayProxy src, OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_sortIdx(InputArrayProxy src, OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solveCubic(InputArrayProxy coeffs, OutputArrayProxy roots, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_solvePoly(InputArrayProxy coeffs, OutputArrayProxy roots, int maxIters, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_eigen(InputArrayProxy src, OutputArrayProxy eigenvalues, OutputArrayProxy eigenvectors, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_eigenNonSymmetric(InputArrayProxy src, OutputArrayProxy eigenvalues, OutputArrayProxy eigenvectors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_calcCovarMatrix_Mat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] samples,
        int nsamples, IntPtr covar, IntPtr mean, int flags, int ctype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_calcCovarMatrix_InputArray(InputArrayProxy samples, OutputArrayProxy covar,
        InputOutputArrayProxy mean, int flags, int ctype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCACompute(InputArrayProxy data, InputOutputArrayProxy mean, OutputArrayProxy eigenvectors, int maxComponents);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCACompute2(InputArrayProxy data, InputOutputArrayProxy mean, OutputArrayProxy eigenvectors, OutputArrayProxy eigenvalues, int maxComponents);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCAComputeVar(InputArrayProxy data, InputOutputArrayProxy mean, OutputArrayProxy eigenvectors, double retainedVariance);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCAComputeVar2(InputArrayProxy data, InputOutputArrayProxy mean, OutputArrayProxy eigenvectors, OutputArrayProxy eigenvalues, double retainedVariance);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCAProject(InputArrayProxy data, InputArrayProxy mean, InputArrayProxy eigenvectors, OutputArrayProxy result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_PCABackProject(InputArrayProxy data, InputArrayProxy mean, InputArrayProxy eigenvectors, OutputArrayProxy result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_SVDecomp(InputArrayProxy src, OutputArrayProxy w, OutputArrayProxy u, OutputArrayProxy vt, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_SVBackSubst(InputArrayProxy w, InputArrayProxy u, InputArrayProxy vt, InputArrayProxy rhs, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_Mahalanobis(InputArrayProxy v1, InputArrayProxy v2, InputArrayProxy icovar, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_dft(InputArrayProxy src, OutputArrayProxy dst, int flags, int nonzeroRows);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_idft(InputArrayProxy src, OutputArrayProxy dst, int flags, int nonzeroRows);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_dct(InputArrayProxy src, OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_idct(InputArrayProxy src, OutputArrayProxy dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_mulSpectrums(InputArrayProxy a, InputArrayProxy b, OutputArrayProxy c, int flags, int conjB);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getOptimalDFTSize(int vecsize, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_theRNG_get(out ulong returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_theRNG_set(ulong returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randu_InputArray(InputOutputArrayProxy dst, InputArrayProxy low, InputArrayProxy high);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randu_Scalar(InputOutputArrayProxy dst, Scalar low, Scalar high);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randn_InputArray(InputOutputArrayProxy dst, InputArrayProxy mean, InputArrayProxy stddev);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randn_Scalar(InputOutputArrayProxy dst, Scalar mean, Scalar stddev);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randShuffle(InputOutputArrayProxy dst, double iterFactor, ref ulong rng);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_randShuffle(InputOutputArrayProxy dst, double iterFactor, IntPtr rng);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus core_kmeans(
        InputArrayProxy data, int k, InputOutputArrayProxy bestLabels,
        TermCriteria criteria, int attempts, int flags, OutputArrayProxy centers,
        out double returnValue);

    #region base.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_cubeRoot(float val, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_fastAtan2(float y, float x, out float returnValue);

    #endregion
}
