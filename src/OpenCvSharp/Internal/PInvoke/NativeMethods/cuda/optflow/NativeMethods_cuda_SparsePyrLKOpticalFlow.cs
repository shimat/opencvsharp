#if ENABLED_CUDA
#pragma warning disable 1591

using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_createSparsePyrLKOpticalFlow(
    Size winSize, int maxLevel, int iters, int useInitialFlow, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_delete(IntPtr ptr);

    // Properties
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_getMaxLevel(IntPtr obj, out int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_setMaxLevel(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_getNumIters(IntPtr obj, out int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_setNumIters(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_getUseInitialFlow(IntPtr obj, out int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_setUseInitialFlow(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_getWinSize(IntPtr obj, out Size val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparsePyrLKOpticalFlow_setWinSize(IntPtr obj, Size val);
}
#endif
