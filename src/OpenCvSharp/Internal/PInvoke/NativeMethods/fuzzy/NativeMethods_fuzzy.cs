using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_createKernel(
        int function, int radius, in OutputArrayProxy kernel, int channels);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_createKernelFromFunctions(
        in InputArrayProxy a, in InputArrayProxy b, in OutputArrayProxy kernel, int channels);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_filter(
        in InputArrayProxy image, in InputArrayProxy kernel, in OutputArrayProxy output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_inpaint(
        in InputArrayProxy image, in InputArrayProxy mask, in OutputArrayProxy output,
        int radius, int function, int algorithm);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_ft02dProcess(
        in InputArrayProxy image, in InputArrayProxy kernel, in OutputArrayProxy output, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_ft12dProcess(
        in InputArrayProxy image, in InputArrayProxy kernel, in OutputArrayProxy output, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_ft02dFastLinearProcess(
        in InputArrayProxy image, int radius, in OutputArrayProxy output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus fuzzy_ft02dFastLinearProcessFloat(
        in InputArrayProxy image, int radius, in OutputArrayProxy output);
}
