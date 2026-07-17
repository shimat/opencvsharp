using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // SeamFinder

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_SeamFinder_createDefault(int type, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Ptr_SeamFinder_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Ptr_SeamFinder_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_SeamFinder_find(
        OpenCvSafeHandle obj,
        IntPtr[] src, int srcLength,
        Point[] corners, int cornersLength,
        IntPtr[] masks, int masksLength);


    // NoSeamFinder

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_NoSeamFinder_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_NoSeamFinder_delete(IntPtr obj);


    // VoronoiSeamFinder

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_VoronoiSeamFinder_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_VoronoiSeamFinder_delete(IntPtr obj);


    // DpSeamFinder

    [LibraryImport(DllExtern, EntryPoint = "stitching_DpSeamFinder_new"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_DpSeamFinder_new_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string costFunc, out IntPtr returnValue);
    [LibraryImport(DllExtern, EntryPoint = "stitching_DpSeamFinder_new"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_DpSeamFinder_new_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string costFunc, out IntPtr returnValue);
    public static ExceptionStatus stitching_DpSeamFinder_new(string costFunc, out IntPtr returnValue)
        => IsWindows()
            ? stitching_DpSeamFinder_new_Windows(costFunc, out returnValue)
            : stitching_DpSeamFinder_new_NotWindows(costFunc, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_DpSeamFinder_delete(IntPtr obj);

    [LibraryImport(DllExtern, EntryPoint = "stitching_DpSeamFinder_setCostFunction"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_DpSeamFinder_setCostFunction_Windows(
        OpenCvSafeHandle obj, [MarshalAs(StringUnmanagedTypeWindows)] string val);
    [LibraryImport(DllExtern, EntryPoint = "stitching_DpSeamFinder_setCostFunction"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_DpSeamFinder_setCostFunction_NotWindows(
        OpenCvSafeHandle obj, [MarshalAs(StringUnmanagedTypeNotWindows)] string val);
    public static ExceptionStatus stitching_DpSeamFinder_setCostFunction(OpenCvSafeHandle obj, string val)
        => IsWindows()
            ? stitching_DpSeamFinder_setCostFunction_Windows(obj, val)
            : stitching_DpSeamFinder_setCostFunction_NotWindows(obj, val);


    // GraphCutSeamFinder

    [LibraryImport(DllExtern, EntryPoint = "stitching_GraphCutSeamFinder_new"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_GraphCutSeamFinder_new_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string costType, float terminalCost, float badRegionPenalty, out IntPtr returnValue);
    [LibraryImport(DllExtern, EntryPoint = "stitching_GraphCutSeamFinder_new"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_GraphCutSeamFinder_new_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string costType, float terminalCost, float badRegionPenalty, out IntPtr returnValue);
    public static ExceptionStatus stitching_GraphCutSeamFinder_new(
        string costType, float terminalCost, float badRegionPenalty, out IntPtr returnValue)
        => IsWindows()
            ? stitching_GraphCutSeamFinder_new_Windows(costType, terminalCost, badRegionPenalty, out returnValue)
            : stitching_GraphCutSeamFinder_new_NotWindows(costType, terminalCost, badRegionPenalty, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_GraphCutSeamFinder_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_GraphCutSeamFinder_find(
        OpenCvSafeHandle obj,
        IntPtr[] src, int srcLength,
        Point[] corners, int cornersLength,
        IntPtr[] masks, int masksLength);
}
