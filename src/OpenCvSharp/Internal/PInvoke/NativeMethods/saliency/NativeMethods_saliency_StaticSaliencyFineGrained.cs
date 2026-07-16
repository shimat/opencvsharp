using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_Ptr_StaticSaliencyFineGrained_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_Ptr_StaticSaliencyFineGrained_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencyFineGrained_create(
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus saliency_StaticSaliencyFineGrained_computeSaliency(
        OpenCvSafeHandle obj, in InputArrayProxy image, in OutputArrayProxy saliencyMap, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus saliency_StaticSaliencyFineGrained_computeBinaryMap(
        OpenCvSafeHandle obj, in InputArrayProxy saliencyMap, in OutputArrayProxy binaryMap, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencyFineGrained_write(OpenCvSafeHandle obj, IntPtr fs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus saliency_StaticSaliencyFineGrained_read(OpenCvSafeHandle obj, IntPtr fn);
}
