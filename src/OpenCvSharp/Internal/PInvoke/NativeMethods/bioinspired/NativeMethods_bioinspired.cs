using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Ptr_Retina_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Ptr_Retina_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Retina_create(int width, int height, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Retina_run(OpenCvSafeHandle obj, in InputArrayProxy input);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Retina_getParvo(OpenCvSafeHandle obj, in OutputArrayProxy output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Retina_getMagno(OpenCvSafeHandle obj, in OutputArrayProxy output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Retina_clearBuffers(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Ptr_TransientAreasSegmentation_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_Ptr_TransientAreasSegmentation_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_TransientAreasSegmentation_create(
        int width, int height, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_TransientAreasSegmentation_run(
        OpenCvSafeHandle obj, in InputArrayProxy input, int channelIndex);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_TransientAreasSegmentation_getPicture(
        OpenCvSafeHandle obj, in OutputArrayProxy output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bioinspired_TransientAreasSegmentation_clearBuffers(OpenCvSafeHandle obj);
}
