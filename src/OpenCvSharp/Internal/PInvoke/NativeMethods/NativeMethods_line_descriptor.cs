using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_new1(
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_new2(
        double scale,
        double sigmaScale,
        double quant,
        double angTh,
        double logEps,
        double densityTh,
        int nBins,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_detect1(
        OpenCvSafeHandle obj, IntPtr image, IntPtr keypoints, int scale, int numOctaves, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_detect2(
        OpenCvSafeHandle obj,
        IntPtr[] images, int imagesSize,
        IntPtr keyLines, int scale, int numOctaves,
        IntPtr[] masks, int masksSize);
}
