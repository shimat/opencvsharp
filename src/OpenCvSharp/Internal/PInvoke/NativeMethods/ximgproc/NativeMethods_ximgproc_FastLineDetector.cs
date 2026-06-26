using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_FastLineDetector_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_FastLineDetector_get(IntPtr ptr, out IntPtr returnValue);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_FastLineDetector_detect_OutputArray(OpenCvSafeHandle obj, IntPtr image, IntPtr lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_FastLineDetector_detect_vector(OpenCvSafeHandle obj, IntPtr image, IntPtr lines);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_FastLineDetector_drawSegments_InputArray(OpenCvSafeHandle obj, IntPtr image, IntPtr lines, int draw_arrow);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_FastLineDetector_drawSegments_vector(OpenCvSafeHandle obj, IntPtr image, IntPtr lines, int draw_arrow);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createFastLineDetector(
        int length_threshold, float distance_threshold, double canny_th1, double canny_th2, int canny_aperture_size,
        int do_merge, out IntPtr returnValue);

}
