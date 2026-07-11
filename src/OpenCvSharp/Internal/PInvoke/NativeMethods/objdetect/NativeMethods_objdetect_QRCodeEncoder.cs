using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_QRCodeEncoder_create(
        in QRCodeEncoderParams parameters,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_Ptr_QRCodeEncoder_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_Ptr_QRCodeEncoder_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeEncoder_encode(
        OpenCvSafeHandle obj,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string encodedInfo,
        in OutputArrayProxy qrcode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_QRCodeEncoder_encodeStructuredAppend(
        OpenCvSafeHandle obj,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string encodedInfo,
        IntPtr qrcodes);
}
