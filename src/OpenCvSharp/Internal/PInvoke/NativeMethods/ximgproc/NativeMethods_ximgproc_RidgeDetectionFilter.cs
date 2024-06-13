using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_RidgeDetectionFilter_create(
        MatType ddepth, int dx, int dy, int ksize, MatType outDtype, double scale, double delta, int borderType,
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_RidgeDetectionFilter_getRidgeFilteredImage(
        IntPtr obj, IntPtr _img, IntPtr @out);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_Ptr_RidgeDetectionFilter_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_Ptr_RidgeDetectionFilter_get(IntPtr ptr, out IntPtr returnValue);
}
