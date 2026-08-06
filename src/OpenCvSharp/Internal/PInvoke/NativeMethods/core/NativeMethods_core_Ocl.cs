using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_haveOpenCL(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_useOpenCL(out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_setUseOpenCL(int flag);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_finish();

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_getPlatformsInfo(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_PlatformInfoVector_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_PlatformInfoVector_size(
        OpenCvSafeHandle obj,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_PlatformInfoVector_getPlatform(
        OpenCvSafeHandle obj,
        int platformIndex,
        IntPtr name,
        IntPtr vendor,
        IntPtr version,
        out int versionMajor,
        out int versionMinor,
        out int deviceCount);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_ocl_PlatformInfoVector_getDevice(
        OpenCvSafeHandle obj,
        int platformIndex,
        int deviceIndex,
        IntPtr name,
        IntPtr vendorName,
        IntPtr version,
        IntPtr openCLVersion,
        IntPtr openCLCVersion,
        IntPtr driverVersion,
        out int type,
        out int addressBits,
        out int available,
        out int compilerAvailable,
        out int linkerAvailable,
        out int maxClockFrequency,
        out int maxComputeUnits,
        out ulong globalMemorySize,
        out ulong localMemorySize,
        out int hostUnifiedMemory,
        out int imageSupport);
}
