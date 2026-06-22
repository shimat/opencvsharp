using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_checkChessboard(
        IntPtr img, Size size, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_findChessboardCornersSB_OutputArray(
        IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_findChessboardCornersSB_vector(
        IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_find4QuadCornerSubpix_InputArray(
        IntPtr img, IntPtr corners, Size regionSize, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_find4QuadCornerSubpix_vector(
        IntPtr img, IntPtr corners, Size regionSize, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_drawChessboardCorners_InputArray(
        IntPtr image, Size patternSize, IntPtr corners, int patternWasFound);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_drawChessboardCorners_array(
        IntPtr image, Size patternSize, [In] Point2f[] corners, int cornersLength, int patternWasFound);
}
