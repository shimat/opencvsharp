using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Aruco;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetectorAruco_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetectorAruco_new_Params(
        in QRCodeDetectorArucoParams parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetectorAruco_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_getDetectorParameters(
        OpenCvSafeHandle obj, out QRCodeDetectorArucoParams returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_setDetectorParameters(
        OpenCvSafeHandle obj, in QRCodeDetectorArucoParams parameters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_getArucoParameters(
        OpenCvSafeHandle obj, out DetectorParameters returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_setArucoParameters(
        OpenCvSafeHandle obj, in DetectorParameters parameters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_detect(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr points, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_decode(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr points, in OutputArrayProxy straightQrCode, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_detectAndDecode(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr points, in OutputArrayProxy straightQrCode, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_detectMulti(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr points, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_decodeMulti(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr points, IntPtr decodedInfo, IntPtr straightQrCode, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_decodeMulti_NoStraightQrCode(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr points, IntPtr decodedInfo, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeDetectorAruco_detectAndDecodeMulti(
        OpenCvSafeHandle obj, in InputArrayProxy img, IntPtr decodedInfo, IntPtr points, IntPtr straightQrCode, out int returnValue);
}
