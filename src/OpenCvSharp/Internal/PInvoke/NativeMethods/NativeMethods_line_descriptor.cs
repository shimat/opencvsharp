using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus line_descriptor_LSDDetector_new1(
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus line_descriptor_LSDDetector_new2(
        double scale,
        double sigmaScale,
        double quant,
        double angTh,
        double logEps,
        double densityTh,
        int nBins,
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus line_descriptor_LSDDetector_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus line_descriptor_LSDDetector_detect1(
        IntPtr obj, IntPtr image, IntPtr keypoints, int scale, int numOctaves, IntPtr mask);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus line_descriptor_LSDDetector_detect2(
        IntPtr obj,
        IntPtr[] images, int imagesSize,
        IntPtr keyLines, int scale, int numOctaves,
        IntPtr[] masks, int masksSize);
}
