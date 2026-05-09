#if ENABLED_CUDA
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_StreamAccessor_getStream(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_StreamAccessor_wrapStream(IntPtr rawHandle, out IntPtr returnValue);
}
#endif
