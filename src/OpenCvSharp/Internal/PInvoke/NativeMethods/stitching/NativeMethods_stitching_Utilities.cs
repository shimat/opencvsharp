using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_focalsFromHomography(
        IntPtr homography, out double f0, out double f1, out int f0Ok, out int f1Ok);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_calibrateRotatingCamera(
        IntPtr homographies, IntPtr cameraMatrix, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_overlapRoi(
        Point tl1, Point tl2, Size sz1, Size sz2, out Rect roi, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_resultRoiSizes(
        Point[] corners, Size[] sizes, int length, out Rect returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_resultRoiImages(
        Point[] corners, IntPtr[] images, int length, out Rect returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_resultRoiIntersection(
        Point[] corners, Size[] sizes, int length, out Rect returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_resultTl(
        Point[] corners, int length, out Point returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_selectRandomSubset(
        int count, int size, IntPtr subset);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_getLogLevel(out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_detail_setLogLevel(int value);
}
