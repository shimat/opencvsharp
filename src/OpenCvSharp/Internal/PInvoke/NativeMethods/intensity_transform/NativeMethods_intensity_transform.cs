using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus intensity_transform_logTransform(IntPtr input, IntPtr output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus intensity_transform_gammaCorrection(IntPtr input, IntPtr output, float gamma);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus intensity_transform_autoscaling(IntPtr input, IntPtr output);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus intensity_transform_contrastStretching(
        IntPtr input, IntPtr output, int r1, int s1, int r2, int s2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus intensity_transform_bimef1(
        in InputArrayProxy input, in OutputArrayProxy output, float mu, float a, float b);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus intensity_transform_bimef2(
        in InputArrayProxy input, in OutputArrayProxy output, float exposureRatio, float mu, float a, float b);
}
