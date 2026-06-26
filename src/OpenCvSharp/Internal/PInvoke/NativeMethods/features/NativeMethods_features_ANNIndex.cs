using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_create(int dim, int distType, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_ANNIndex_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_ANNIndex_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_addItems(IntPtr obj, IntPtr features);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_build(IntPtr obj, int trees);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_knnSearch(
        IntPtr obj, IntPtr query, IntPtr indices, IntPtr dists, int knn, int search_k);

    [LibraryImport(DllExtern, EntryPoint = "features_ANNIndex_save"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_save_NotWindows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, int prefault);

    [LibraryImport(DllExtern, EntryPoint = "features_ANNIndex_save"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_save_Windows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeWindows)] string filename, int prefault);

    public static ExceptionStatus features_ANNIndex_save(IntPtr obj, string filename, int prefault)
        => IsWindows()
            ? features_ANNIndex_save_Windows(obj, filename, prefault)
            : features_ANNIndex_save_NotWindows(obj, filename, prefault);

    [LibraryImport(DllExtern, EntryPoint = "features_ANNIndex_load"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_load_NotWindows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, int prefault);

    [LibraryImport(DllExtern, EntryPoint = "features_ANNIndex_load"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_load_Windows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeWindows)] string filename, int prefault);

    public static ExceptionStatus features_ANNIndex_load(IntPtr obj, string filename, int prefault)
        => IsWindows()
            ? features_ANNIndex_load_Windows(obj, filename, prefault)
            : features_ANNIndex_load_NotWindows(obj, filename, prefault);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_getTreeNumber(IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_getItemNumber(IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern, EntryPoint = "features_ANNIndex_setOnDiskBuild"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_setOnDiskBuild_NotWindows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, out int returnValue);

    [LibraryImport(DllExtern, EntryPoint = "features_ANNIndex_setOnDiskBuild"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_setOnDiskBuild_Windows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeWindows)] string filename, out int returnValue);

    public static ExceptionStatus features_ANNIndex_setOnDiskBuild(IntPtr obj, string filename, out int returnValue)
        => IsWindows()
            ? features_ANNIndex_setOnDiskBuild_Windows(obj, filename, out returnValue)
            : features_ANNIndex_setOnDiskBuild_NotWindows(obj, filename, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ANNIndex_setSeed(IntPtr obj, int seed);
}
