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
    public static partial ExceptionStatus objdetect_FaceDetectorYN_create(
        IntPtr model,
        IntPtr config,
        ref Size inputSize,
        float scoreThreshold,
        float nmsThreshold,
        int topK,
        int backendId,
        int targetId,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_FaceDetectorYN_create_buffer(
        IntPtr framework,
        IntPtr bufferModel,
        IntPtr bufferConfig,
        Size inputSize,
        float scoreThreshold,
        float nmsThreshold,
        int topK,
        int backendId,
        int targetId,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_Ptr_FaceDetectorYN_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_Ptr_FaceDetectorYN_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_setInputSize(
        OpenCvSafeHandle obj, Size inputSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_getInputSize(
        OpenCvSafeHandle obj, out Size returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_setScoreThreshold(
        OpenCvSafeHandle obj, float scoreThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_getScoreThreshold(
        OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_setNMSThreshold(
        OpenCvSafeHandle obj, float nmsThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_getNMSThreshold(
        OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_setTopK(
        OpenCvSafeHandle obj, int topK);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_getTopK(
        OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceDetectorYN_detect(
        OpenCvSafeHandle obj, in InputArrayProxy image, in OutputArrayProxy faces, out int returnValue);
}
