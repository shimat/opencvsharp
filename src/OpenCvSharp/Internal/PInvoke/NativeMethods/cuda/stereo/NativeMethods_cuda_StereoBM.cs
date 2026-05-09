#if ENABLED_CUDA
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_createStereoBM(int numDisparities, int blockSize, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_StereoBM_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_StereoBM_delete(IntPtr ptr);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_StereoBM_compute(
    IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity, IntPtr stream);

}
#endif
