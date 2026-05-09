#if ENABLED_CUDA
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Internal;
#pragma warning disable 1591
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_fastNlMeansDenoising(IntPtr src, IntPtr dst, float h, int searchWindow, int blockSize, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_fastNlMeansDenoisingColored(IntPtr src, IntPtr dst, float hLuminance, float photoRender, int searchWindow, int blockSize, IntPtr stream);
}
#endif
