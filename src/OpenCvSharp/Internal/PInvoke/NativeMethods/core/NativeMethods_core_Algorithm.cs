using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // The Algorithm object handle is an OpenCvSafeHandle, so the marshaller keeps the managed object
    // alive for the call and callers drop GC.KeepAlive(this). Shared by all Algorithm-derived types.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Algorithm_write(OpenCvSafeHandle obj, IntPtr fs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Algorithm_read(OpenCvSafeHandle obj, IntPtr fn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Algorithm_empty(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Algorithm_save(OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Algorithm_getDefaultName(OpenCvSafeHandle obj, IntPtr buf);
}
