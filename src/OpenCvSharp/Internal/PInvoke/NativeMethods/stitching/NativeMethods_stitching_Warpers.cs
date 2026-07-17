using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // PyRotationWarper

    [LibraryImport(DllExtern, EntryPoint = "stitching_PyRotationWarper_new"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_PyRotationWarper_new_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string type, float scale, out IntPtr returnValue);
    [LibraryImport(DllExtern, EntryPoint = "stitching_PyRotationWarper_new"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus stitching_PyRotationWarper_new_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string type, float scale, out IntPtr returnValue);
    public static ExceptionStatus stitching_PyRotationWarper_new(string type, float scale, out IntPtr returnValue)
        => IsWindows()
            ? stitching_PyRotationWarper_new_Windows(type, scale, out returnValue)
            : stitching_PyRotationWarper_new_NotWindows(type, scale, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PyRotationWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_PyRotationWarper_warpPoint(
        OpenCvSafeHandle obj, Point2f pt, in InputArrayProxy k, in InputArrayProxy r, out Point2f returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_PyRotationWarper_warpPointBackward(
        OpenCvSafeHandle obj, Point2f pt, in InputArrayProxy k, in InputArrayProxy r, out Point2f returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_PyRotationWarper_buildMaps(
        OpenCvSafeHandle obj, Size srcSize, in InputArrayProxy k, in InputArrayProxy r,
        in OutputArrayProxy xmap, in OutputArrayProxy ymap, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_PyRotationWarper_warp(
        OpenCvSafeHandle obj, in InputArrayProxy src, in InputArrayProxy k, in InputArrayProxy r,
        int interpMode, int borderMode, in OutputArrayProxy dst, out Point returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_PyRotationWarper_warpBackward(
        OpenCvSafeHandle obj, in InputArrayProxy src, in InputArrayProxy k, in InputArrayProxy r,
        int interpMode, int borderMode, Size dstSize, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus stitching_PyRotationWarper_warpRoi(
        OpenCvSafeHandle obj, Size srcSize, in InputArrayProxy k, in InputArrayProxy r, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PyRotationWarper_getScale(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PyRotationWarper_setScale(OpenCvSafeHandle obj, float val);


    // WarperCreator concrete factories

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PlaneWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PlaneWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_AffineWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_AffineWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_CylindricalWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_CylindricalWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_SphericalWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_SphericalWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FisheyeWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_FisheyeWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_StereographicWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_StereographicWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_MercatorWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_MercatorWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_TransverseMercatorWarper_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_TransverseMercatorWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_CompressedRectilinearWarper_new(float a, float b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_CompressedRectilinearWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_CompressedRectilinearPortraitWarper_new(float a, float b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_CompressedRectilinearPortraitWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PaniniWarper_new(float a, float b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PaniniWarper_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PaniniPortraitWarper_new(float a, float b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_PaniniPortraitWarper_delete(IntPtr obj);
}
