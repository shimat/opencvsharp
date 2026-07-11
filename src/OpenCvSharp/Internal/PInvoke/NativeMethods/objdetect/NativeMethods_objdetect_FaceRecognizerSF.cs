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
    public static partial ExceptionStatus objdetect_FaceRecognizerSF_create(
        IntPtr model,
        IntPtr config,
        int backendId,
        int targetId,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_FaceRecognizerSF_create_buffer(
        IntPtr framework,
        IntPtr bufferModel,
        IntPtr bufferConfig,
        int backendId,
        int targetId,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_Ptr_FaceRecognizerSF_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus objdetect_Ptr_FaceRecognizerSF_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceRecognizerSF_alignCrop(
        OpenCvSafeHandle obj, in InputArrayProxy srcImg, in InputArrayProxy faceBox, in OutputArrayProxy alignedImg);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceRecognizerSF_feature(
        OpenCvSafeHandle obj, in InputArrayProxy alignedImg, in OutputArrayProxy faceFeature);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus objdetect_FaceRecognizerSF_match(
        OpenCvSafeHandle obj, in InputArrayProxy faceFeature1, in InputArrayProxy faceFeature2, int disType, out double returnValue);
}
