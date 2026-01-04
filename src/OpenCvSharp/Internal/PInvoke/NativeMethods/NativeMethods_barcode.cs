using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1707 // Underscore
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style


namespace OpenCvSharp.Internal;

static partial class NativeMethods
{

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_BarcodeDetector_create(
        [MarshalAs(UnmanagedType.LPStr)] string super_resolution_prototxt_path,
        [MarshalAs(UnmanagedType.LPStr)] string super_resolution_caffe_model_path,
        out IntPtr ptr
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_BarcodeDetector_setDownsamplingThreshold(
        IntPtr obj,
        double thresh
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_BarcodeDetector_setDetectorScales(
        IntPtr obj,
        IntPtr sizes
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_BarcodeDetector_setGradientThreshold(
        IntPtr obj,
        double thresh
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_Ptr_BarcodeDetector_get(
        IntPtr ptr,
        out IntPtr ret
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_Ptr_BarcodeDetector_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_BarcodeDetector_decodeWithType(
        IntPtr obj,
        IntPtr inputImage,
        IntPtr points,
        IntPtr infos,
        IntPtr types
    );

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus barcode_BarcodeDetector_detectAndDecodeWithType(
        IntPtr obj,
        IntPtr inputImage,
        IntPtr points,
        IntPtr infos,
        IntPtr types
    );
}
