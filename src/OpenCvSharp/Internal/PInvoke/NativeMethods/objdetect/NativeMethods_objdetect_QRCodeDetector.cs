using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_setEpsX(IntPtr obj, double epsX);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_setEpsY(IntPtr obj, double epsY);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_detect(IntPtr obj, IntPtr img, IntPtr points, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_decode(
        IntPtr obj, IntPtr img, IntPtr points, IntPtr straightQrCode, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_detectAndDecode(
        IntPtr obj, IntPtr img, IntPtr points,
        IntPtr straightQrCode, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_detectMulti(IntPtr obj, IntPtr img, IntPtr points, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_decodeMulti(
        IntPtr obj, IntPtr img, IntPtr points, IntPtr decodedInfo, IntPtr straightQrCode, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeDetector_decodeMulti_NoStraightQrCode(
        IntPtr obj, IntPtr img, IntPtr points, IntPtr decodedInfo, out int returnValue);
}
