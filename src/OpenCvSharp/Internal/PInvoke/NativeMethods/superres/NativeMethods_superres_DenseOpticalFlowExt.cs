using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DenseOpticalFlowExt_calc(
        IntPtr obj, IntPtr frame0, IntPtr frame1, IntPtr flow1, IntPtr flow2);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DenseOpticalFlowExt_collectGarbage(IntPtr obj);
        
    #region FarnebackOpticalFlow

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_createOptFlow_Farneback(out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_createOptFlow_Farneback_CUDA(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_FarnebackOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_FarnebackOpticalFlow_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getPyrScale(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setPyrScale(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getLevelsNumber(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setLevelsNumber(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getWindowSize(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setWindowSize(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setIterations(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getPolyN(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setPolyN(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getPolySigma(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setPolySigma(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_getFlags(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_FarnebackOpticalFlow_setFlags(IntPtr obj, int val);

    #endregion

    #region DualTVL1OpticalFlow

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_createOptFlow_DualTVL1(out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_createOptFlow_DualTVL1_CUDA(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_DualTVL1OpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_DualTVL1OpticalFlow_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getTau(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setTau(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getLambda(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setLambda(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getTheta(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setTheta(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getScalesNumber(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setScalesNumber(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getWarpingsNumber(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setWarpingsNumber(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getEpsilon(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setEpsilon(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setIterations(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_getUseInitialFlow(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_DualTVL1OpticalFlow_setUseInitialFlow(IntPtr obj, int val);

    #endregion

    #region BroxOpticalFlow

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_createOptFlow_Brox_CUDA(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_BroxOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_BroxOpticalFlow_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_getAlpha(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_setAlpha(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_getGamma(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_setGamma(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_getScaleFactor(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_setScaleFactor(IntPtr obj, double val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_getInnerIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_setInnerIterations(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_getOuterIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_setOuterIterations(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_getSolverIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_BroxOpticalFlow_setSolverIterations(IntPtr obj, int val);

    #endregion

    #region PyrLKOpticalFlow

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_createOptFlow_PyrLK_CUDA(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_PyrLKOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_Ptr_PyrLKOpticalFlow_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_PyrLKOpticalFlow_getWindowSize(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_PyrLKOpticalFlow_setWindowSize(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_PyrLKOpticalFlow_getMaxLevel(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_PyrLKOpticalFlow_setMaxLevel(IntPtr obj, int val);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_PyrLKOpticalFlow_getIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus superres_PyrLKOpticalFlow_setIterations(IntPtr obj, int val);

    #endregion
}
