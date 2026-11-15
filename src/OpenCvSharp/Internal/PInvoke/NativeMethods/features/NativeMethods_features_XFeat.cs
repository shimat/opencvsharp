using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_create(
        string modelPath, int maxKeypoints, float scoreThreshold, Size inputSize, int backend, int target, out IntPtr value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_create_buffer(
        ReadOnlySpan<byte> modelData, nuint length, int maxKeypoints, float scoreThreshold, Size inputSize,
        int backend, int target, out IntPtr value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_Ptr_XFeat_get(IntPtr obj, out IntPtr value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_Ptr_XFeat_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_getMaxKeypoints(OpenCvSafeHandle obj, out int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_setMaxKeypoints(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_getScoreThreshold(OpenCvSafeHandle obj, out float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_setScoreThreshold(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_getInputSize(OpenCvSafeHandle obj, out Size value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus features_XFeat_setInputSize(OpenCvSafeHandle obj, Size value);
}
