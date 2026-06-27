using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DenseOpticalFlowExt_calc(
        OpenCvSafeHandle obj, IntPtr frame0, IntPtr frame1, IntPtr flow1, IntPtr flow2);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DenseOpticalFlowExt_collectGarbage(OpenCvSafeHandle obj);
        
    #region FarnebackOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_createOptFlow_Farneback(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_createOptFlow_Farneback_CUDA(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_FarnebackOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_FarnebackOpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getPyrScale(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setPyrScale(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getLevelsNumber(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setLevelsNumber(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getWindowSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setWindowSize(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setIterations(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getPolyN(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setPolyN(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getPolySigma(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setPolySigma(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_getFlags(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_FarnebackOpticalFlow_setFlags(OpenCvSafeHandle obj, int val);

    #endregion

    #region DualTVL1OpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_createOptFlow_DualTVL1(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_createOptFlow_DualTVL1_CUDA(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_DualTVL1OpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_DualTVL1OpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getTau(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setTau(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getLambda(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setLambda(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getTheta(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setTheta(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getScalesNumber(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setScalesNumber(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getWarpingsNumber(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setWarpingsNumber(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getEpsilon(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setEpsilon(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setIterations(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_getUseInitialFlow(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_DualTVL1OpticalFlow_setUseInitialFlow(OpenCvSafeHandle obj, int val);

    #endregion

    #region BroxOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_createOptFlow_Brox_CUDA(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_BroxOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_BroxOpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_getAlpha(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_setAlpha(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_getGamma(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_setGamma(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_getScaleFactor(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_setScaleFactor(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_getInnerIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_setInnerIterations(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_getOuterIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_setOuterIterations(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_getSolverIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_BroxOpticalFlow_setSolverIterations(OpenCvSafeHandle obj, int val);

    #endregion

    #region PyrLKOpticalFlow

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_createOptFlow_PyrLK_CUDA(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_PyrLKOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_Ptr_PyrLKOpticalFlow_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_PyrLKOpticalFlow_getWindowSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_PyrLKOpticalFlow_setWindowSize(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_PyrLKOpticalFlow_getMaxLevel(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_PyrLKOpticalFlow_setMaxLevel(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_PyrLKOpticalFlow_getIterations(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus superres_PyrLKOpticalFlow_setIterations(OpenCvSafeHandle obj, int val);

    #endregion
}
