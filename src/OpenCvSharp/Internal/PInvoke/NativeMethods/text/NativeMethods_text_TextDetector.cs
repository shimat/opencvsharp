using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable once IdentifierTypo
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_TextDetector_detect(OpenCvSafeHandle obj, IntPtr inputImage, IntPtr bbox, IntPtr confidence);

    // ReSharper disable once IdentifierTypo
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_TextDetectorCNN_detect(OpenCvSafeHandle obj, IntPtr inputImage, IntPtr bbox, IntPtr confidence);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_TextDetectorCNN_create1(
        [MarshalAs(UnmanagedType.LPStr)] string modelArchFilename,
        [MarshalAs(UnmanagedType.LPStr)] string modelWeightsFilename,
        [MarshalAs(UnmanagedType.LPArray)] Size[] detectionSizes, int detectionSizesLength, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_TextDetectorCNN_create2(
        [MarshalAs(UnmanagedType.LPStr)] string modelArchFilename, 
        [MarshalAs(UnmanagedType.LPStr)] string modelWeightsFilename, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_TextDetectorCNN_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_TextDetectorCNN_get(IntPtr obj, out IntPtr returnValue);
}
