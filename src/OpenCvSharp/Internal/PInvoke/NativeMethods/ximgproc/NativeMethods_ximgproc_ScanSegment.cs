using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_ScanSegment_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_ScanSegment_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_ScanSegment_getNumberOfSuperpixels(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_ScanSegment_iterate(OpenCvSafeHandle obj, in InputArrayProxy img);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_ScanSegment_getLabels(OpenCvSafeHandle obj, in OutputArrayProxy labelsOut);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_ScanSegment_getLabelContourMask(OpenCvSafeHandle obj, in OutputArrayProxy image, int thickLine);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createScanSegment(
        int imageWidth, int imageHeight, int numSuperpixels, int slices, int mergeSmall, out IntPtr returnValue);
}
