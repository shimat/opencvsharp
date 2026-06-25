using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_Ptr_StaticSaliencySpectralResidual_delete(IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_Ptr_StaticSaliencySpectralResidual_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_create(
        out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_computeSaliency(
        IntPtr obj, IntPtr image, IntPtr saliencyMap, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_computeBinaryMap(
        IntPtr obj, IntPtr saliencyMap, IntPtr binaryMap, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_getImageWidth(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_setImageWidth(
        IntPtr obj, int val);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_getImageHeight(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencySpectralResidual_setImageHeight(
        IntPtr obj, int val);
}
