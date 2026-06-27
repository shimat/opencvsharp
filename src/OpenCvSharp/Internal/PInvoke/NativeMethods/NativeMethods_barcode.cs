using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1707 // Underscore
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style


namespace OpenCvSharp.Internal;

static partial class NativeMethods
{

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_create(
        [MarshalAs(UnmanagedType.LPStr)] string super_resolution_model_path,
        out IntPtr ptr
    );

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_setDownsamplingThreshold(
        IntPtr obj,
        double thresh
    );

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_setDetectorScales(
        IntPtr obj,
        IntPtr sizes
    );

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_setGradientThreshold(
        IntPtr obj,
        double thresh
    );

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_decodeWithType(
        IntPtr obj,
        IntPtr inputImage,
        IntPtr points,
        IntPtr infos,
        IntPtr types
    );

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus barcode_BarcodeDetector_detectAndDecodeWithType(
        IntPtr obj,
        IntPtr inputImage,
        IntPtr points,
        IntPtr infos,
        IntPtr types
    );
}
