using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // Blender

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Blender_createDefault(int type, int tryGpu, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Ptr_Blender_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Ptr_Blender_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Blender_prepare1(
        OpenCvSafeHandle obj, Point[] corners, int cornersLength, Size[] sizes, int sizesLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Blender_prepare2(OpenCvSafeHandle obj, Rect dstRoi);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_Blender_feed(
        OpenCvSafeHandle obj, in InputArrayProxy img, in InputArrayProxy mask, Point tl);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_Blender_blend(
        OpenCvSafeHandle obj, in InputOutputArrayProxy dst, in InputOutputArrayProxy dstMask);


    // FeatherBlender

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FeatherBlender_new(float sharpness, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FeatherBlender_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FeatherBlender_getSharpness(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FeatherBlender_setSharpness(OpenCvSafeHandle obj, float val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FeatherBlender_createWeightMaps(
        OpenCvSafeHandle obj,
        IntPtr[] masks, int masksLength,
        Point[] corners, int cornersLength,
        IntPtr[] weightMaps, int weightMapsLength,
        out Rect returnValue);


    // MultiBandBlender

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_MultiBandBlender_new(int tryGpu, int numBands, int weightType, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_MultiBandBlender_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_MultiBandBlender_getNumBands(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_MultiBandBlender_setNumBands(OpenCvSafeHandle obj, int val);


    // Auxiliary functions

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_normalizeUsingWeightMap(in InputArrayProxy weight, in InputOutputArrayProxy src);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_createWeightMap(in InputArrayProxy mask, float sharpness, in InputOutputArrayProxy weight);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_createLaplacePyr(in InputArrayProxy img, int numLevels, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_restoreImageFromLaplacePyr(IntPtr[] pyr, int pyrLength, IntPtr returnValue);
}
