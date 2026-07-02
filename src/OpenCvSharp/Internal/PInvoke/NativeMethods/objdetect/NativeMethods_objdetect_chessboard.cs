using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_checkChessboard(
        in InputArrayProxy img, Size size, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_findChessboardCornersSB_OutputArray(
        in InputArrayProxy image, Size patternSize, in OutputArrayProxy corners, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_findChessboardCornersSB_vector(
        in InputArrayProxy image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_find4QuadCornerSubpix_InputArray(
        in InputArrayProxy img, in InputOutputArrayProxy corners, Size regionSize, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_find4QuadCornerSubpix_vector(
        in InputArrayProxy img, IntPtr corners, Size regionSize, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_drawChessboardCorners_InputArray(
        in InputOutputArrayProxy image, Size patternSize, in InputArrayProxy corners, int patternWasFound);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_drawChessboardCorners_array(
        in InputOutputArrayProxy image, Size patternSize, [In] Point2f[] corners, int cornersLength, int patternWasFound);
}
