using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region Tonemap

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Tonemap_process(OpenCvSafeHandle obj, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Tonemap_getGamma(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Tonemap_setGamma(OpenCvSafeHandle obj, float gamma);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createTonemap(float gamma, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_Tonemap_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_Tonemap_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region TonemapDrago

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapDrago_getSaturation(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapDrago_setSaturation(OpenCvSafeHandle obj, float saturation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapDrago_getBias(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapDrago_setBias(OpenCvSafeHandle obj, float bias);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createTonemapDrago(
        float gamma, float saturation, float bias, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_TonemapDrago_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_TonemapDrago_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region TonemapReinhard

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapReinhard_getIntensity(
        OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapReinhard_setIntensity(
        OpenCvSafeHandle obj, float intensity);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapReinhard_getLightAdaptation(
        OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapReinhard_setLightAdaptation(
        OpenCvSafeHandle obj, float light_adapt);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapReinhard_getColorAdaptation(
        OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapReinhard_setColorAdaptation(
        OpenCvSafeHandle obj, float color_adapt);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createTonemapReinhard(
        float gamma, float intensity, float light_adapt, float color_adapt, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_TonemapReinhard_delete(
        IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_TonemapReinhard_get(
        IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region TonemapMantiuk

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapMantiuk_getScale(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapMantiuk_setScale(OpenCvSafeHandle obj, float scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapMantiuk_getSaturation(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_TonemapMantiuk_setSaturation(OpenCvSafeHandle obj, float saturation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createTonemapMantiuk(
        float gamma, float scale, float saturation, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_TonemapMantiuk_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_TonemapMantiuk_get(IntPtr ptr, out IntPtr returnValue);

    #endregion
}
