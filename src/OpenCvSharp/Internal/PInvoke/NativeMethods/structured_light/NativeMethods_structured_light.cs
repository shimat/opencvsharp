using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_SinusoidalPattern_create(
        int width, int height, int periods, float shiftValue, int methodId,
        int pixelsBetweenMarkers, int horizontal, int setMarkers, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_Ptr_SinusoidalPattern_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_Ptr_SinusoidalPattern_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_SinusoidalPattern_computePhaseMap(
        OpenCvSafeHandle obj, IntPtr images, in OutputArrayProxy wrappedPhaseMap,
        in OutputArrayProxy shadowMask, in InputArrayProxy fundamental);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_SinusoidalPattern_unwrapPhaseMap(
        OpenCvSafeHandle obj, in InputArrayProxy wrappedPhaseMap,
        in OutputArrayProxy unwrappedPhaseMap, Size camSize, in InputArrayProxy shadowMask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_SinusoidalPattern_findProCamMatches(
        OpenCvSafeHandle obj, in InputArrayProxy projectorPhase,
        in InputArrayProxy cameraPhase, IntPtr matches);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_SinusoidalPattern_computeDataModulationTerm(
        OpenCvSafeHandle obj, IntPtr images, in OutputArrayProxy modulation,
        in InputArrayProxy shadowMask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_Ptr_GrayCodePattern_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_Ptr_GrayCodePattern_get(
        IntPtr obj,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_GrayCodePattern_create(
        int width,
        int height,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_StructuredLightPattern_generate(
        OpenCvSafeHandle obj,
        IntPtr patternImages,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_StructuredLightPattern_decode(
        OpenCvSafeHandle obj,
        [In] IntPtr[] patternImages,
        [In] int[] patternImageCounts,
        int cameraCount,
        IntPtr blackImages,
        IntPtr whiteImages,
        in OutputArrayProxy disparityMap,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_GrayCodePattern_getNumberOfPatternImages(
        OpenCvSafeHandle obj,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_GrayCodePattern_setWhiteThreshold(
        OpenCvSafeHandle obj,
        int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_GrayCodePattern_setBlackThreshold(
        OpenCvSafeHandle obj,
        int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_GrayCodePattern_getImagesForShadowMasks(
        OpenCvSafeHandle obj,
        in OutputArrayProxy blackImage,
        in OutputArrayProxy whiteImage);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus structured_light_GrayCodePattern_getProjectorPixel(
        OpenCvSafeHandle obj,
        IntPtr patternImages,
        int x,
        int y,
        out Point projectorPixel,
        out int returnValue);
}
