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
    public static extern ExceptionStatus cuda_buildWarpAffineMaps(IntPtr M, int inverse, Size dsize, IntPtr xmap, IntPtr ymap, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_buildWarpPerspectiveMaps(IntPtr M, int inverse, Size dsize, IntPtr xmap, IntPtr ymap, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_pyrDown(IntPtr src, IntPtr dst, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_pyrUp(IntPtr src, IntPtr dst, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_remap(IntPtr src, IntPtr dst, IntPtr xmap, IntPtr ymap, int interpolation, int borderMode, Scalar borderValue, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_resize(IntPtr src, IntPtr dst, Size dsize, double fx, double fy, int interpolation, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_rotate(IntPtr src, IntPtr dst, Size dsize, double angle, double xShift, double yShift, int interpolation, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_warpAffine(IntPtr src, IntPtr dst, IntPtr M, Size dsize, int flags, int borderMode, Scalar borderValue, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_warpPerspective(IntPtr src, IntPtr dst, IntPtr M, Size dsize, int flags, int borderMode, Scalar borderValue, IntPtr stream);
}
#endif
