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
    public static partial ExceptionStatus core_copyMakeBorder(
        IntPtr src, IntPtr dst, int top, int bottom, int left, int right, int borderType, Scalar value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_add(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_subtract_InputArray2(
        IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_subtract_InputArrayScalar(
        IntPtr src1, Scalar src2, IntPtr dst, IntPtr mask, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_subtract_ScalarInputArray(
        Scalar src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_multiply(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_divide1(double scale, IntPtr src2, IntPtr dst, int dtype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_divide2(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_scaleAdd(IntPtr src1, double alpha, IntPtr src2,IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_addWeighted(IntPtr src1, double alpha, IntPtr src2,
        double beta, double gamma, IntPtr dst, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_LUT(IntPtr src, IntPtr lut, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_sum(IntPtr src, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_countNonZero(IntPtr src, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_findNonZero(IntPtr src, IntPtr idx);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_mean(IntPtr src, IntPtr mask, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_meanStdDev_OutputArray(
        IntPtr src, IntPtr mean, IntPtr stddev, IntPtr mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_meanStdDev_Scalar(
        IntPtr src, out Scalar mean, out Scalar stddev, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_norm1(
        IntPtr src1, int normType, IntPtr mask, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_norm2(
        IntPtr src1, IntPtr src2, int normType, IntPtr mask, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PSNR(IntPtr src1, IntPtr src2, double r, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_batchDistance(IntPtr src1, IntPtr src2,
        IntPtr dist, int dtype, IntPtr nidx,
        int normType, int k, IntPtr mask,
        int update, int crosscheck);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_normalize(IntPtr src, IntPtr dst, double alpha, double beta,
        int normType, int dtype, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_reduceArgMax(IntPtr src, IntPtr dst, int axis, [MarshalAs(UnmanagedType.U1)] bool lastIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_reduceArgMin(IntPtr src, IntPtr dst, int axis, [MarshalAs(UnmanagedType.U1)] bool lastIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_minMaxLoc1(IntPtr src, out double minVal, out double maxVal);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_minMaxLoc2(IntPtr src, out double minVal, out double maxVal,
        out Point minLoc, out Point maxLoc, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_minMaxIdx1(IntPtr src, out double minVal, out double maxVal);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_minMaxIdx2(IntPtr src, out double minVal, out double maxVal,
        [MarshalAs(UnmanagedType.LPArray), Out] int[] minIdx, [MarshalAs(UnmanagedType.LPArray), Out] int[] maxIdx, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_reduce(IntPtr src, IntPtr dst, int dim, int rtype, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_merge([MarshalAs(UnmanagedType.LPArray)] IntPtr[] mv, uint count, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_split(IntPtr src, IntPtr mv);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_mixChannels(IntPtr[] src, uint nsrcs,
        IntPtr[] dst, uint ndsts, int[] fromTo, uint npairs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_extractChannel(IntPtr src, IntPtr dst, int coi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_insertChannel(IntPtr src, IntPtr dst, int coi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_flip(IntPtr src, IntPtr dst, int flipCode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_rotate(IntPtr src, IntPtr dst, int rotateCode);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_repeat1(IntPtr src, int ny, int nx, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_repeat2(IntPtr src, int ny, int nx, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_hconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_hconcat2(IntPtr src1, IntPtr src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_vconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_vconcat2(IntPtr src1, IntPtr src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_bitwise_and(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_bitwise_or(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_bitwise_xor(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_bitwise_not(IntPtr src, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_absdiff(IntPtr src1, IntPtr src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_copyTo(IntPtr src, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_inRange_InputArray(IntPtr src, IntPtr lowerb, IntPtr upperb, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_inRange_Scalar(IntPtr src, Scalar lowerb, Scalar upperb, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_compare(IntPtr src1, IntPtr src2, IntPtr dst, int cmpop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min1(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_min_MatDouble(IntPtr src1, double src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max1(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_max_MatDouble(IntPtr src1, double src2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_sqrt(IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_pow_Mat(IntPtr src, double power, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_exp_Mat(IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_log_Mat(IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_polarToCart(IntPtr magnitude, IntPtr angle, IntPtr x, IntPtr y, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_cartToPolar(IntPtr x, IntPtr y, IntPtr magnitude, IntPtr angle, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_phase(IntPtr x, IntPtr y, IntPtr angle, int angleInDegrees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_magnitude_Mat(IntPtr x, IntPtr y, IntPtr magnitude);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_checkRange(IntPtr a, int quiet, out Point pos, double minVal, double maxVal, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_patchNaNs(IntPtr a, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_gemm(IntPtr src1, IntPtr src2, double alpha, IntPtr src3, double gamma, IntPtr dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_mulTransposed(IntPtr src, IntPtr dst, int aTa, IntPtr delta, double scale, int dtype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_transpose(IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_transform(IntPtr src, IntPtr dst, IntPtr m);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_perspectiveTransform(IntPtr src, IntPtr dst, IntPtr m);
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_setIdentity(IntPtr mtx, Scalar s);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_determinant(IntPtr mtx, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_trace(IntPtr mtx, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_invert(IntPtr src, IntPtr dst, int flags, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_solve(IntPtr src1, IntPtr src2, IntPtr dst, int flags, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_solveLP(IntPtr func, IntPtr constr, IntPtr z, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_sort(IntPtr src, IntPtr dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_sortIdx(IntPtr src, IntPtr dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_solveCubic(IntPtr coeffs, IntPtr roots, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_solvePoly(IntPtr coeffs, IntPtr roots, int maxIters, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_eigen(IntPtr src, IntPtr eigenvalues, IntPtr eigenvectors, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_eigenNonSymmetric(IntPtr src, IntPtr eigenvalues, IntPtr eigenvectors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_calcCovarMatrix_Mat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] samples, 
        int nsamples, IntPtr covar, IntPtr mean, int flags, int ctype);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_calcCovarMatrix_InputArray(IntPtr samples, IntPtr covar,
        IntPtr mean, int flags, int ctype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCACompute(IntPtr data, IntPtr mean, IntPtr eigenvectors, int maxComponents);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCACompute2(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr eigenvalues, int maxComponents);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCAComputeVar(IntPtr data, IntPtr mean, IntPtr eigenvectors, double retainedVariance);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCAComputeVar2(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr eigenvalues, double retainedVariance);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCAProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_PCABackProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVDecomp(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_SVBackSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mahalanobis(IntPtr v1, IntPtr v2, IntPtr icovar, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_dft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_idft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_dct(IntPtr src, IntPtr dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_idct(IntPtr src, IntPtr dst, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_mulSpectrums(IntPtr a, IntPtr b, IntPtr c, int flags, int conjB);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_getOptimalDFTSize(int vecsize, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_theRNG_get(out ulong returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_theRNG_set(ulong returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_randu_InputArray(IntPtr dst, IntPtr low, IntPtr high);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_randu_Scalar(IntPtr dst, Scalar low, Scalar high);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_randn_InputArray(IntPtr dst, IntPtr mean, IntPtr stddev);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_randn_Scalar(IntPtr dst, Scalar mean, Scalar stddev);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_randShuffle(IntPtr dst, double iterFactor, ref ulong rng);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_randShuffle(IntPtr dst, double iterFactor, IntPtr rng);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_kmeans(
        IntPtr data, int k, IntPtr bestLabels,
        TermCriteria criteria, int attempts, int flags, IntPtr centers,
        out double returnValue);

    #region base.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_cubeRoot(float val, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_fastAtan2(float y, float x, out float returnValue);

    #endregion
}
