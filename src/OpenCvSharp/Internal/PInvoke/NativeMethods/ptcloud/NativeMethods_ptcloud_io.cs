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

    // loadPointCloud

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_loadPointCloud")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_loadPointCloud_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, IntPtr vertices, IntPtr normals, IntPtr rgb);

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_loadPointCloud")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_loadPointCloud_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string filename, IntPtr vertices, IntPtr normals, IntPtr rgb);

    public static ExceptionStatus ptcloud_loadPointCloud(string filename, IntPtr vertices, IntPtr normals, IntPtr rgb)
        => IsWindows()
            ? ptcloud_loadPointCloud_Windows(filename, vertices, normals, rgb)
            : ptcloud_loadPointCloud_NotWindows(filename, vertices, normals, rgb);

    // savePointCloud

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_savePointCloud")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_savePointCloud_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, IntPtr vertices, IntPtr normals, IntPtr rgb);

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_savePointCloud")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_savePointCloud_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string filename, IntPtr vertices, IntPtr normals, IntPtr rgb);

    public static ExceptionStatus ptcloud_savePointCloud(string filename, IntPtr vertices, IntPtr normals, IntPtr rgb)
        => IsWindows()
            ? ptcloud_savePointCloud_Windows(filename, vertices, normals, rgb)
            : ptcloud_savePointCloud_NotWindows(filename, vertices, normals, rgb);

    // loadMesh

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_loadMesh")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_loadMesh_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, IntPtr vertices, IntPtr indices, IntPtr normals, IntPtr colors, IntPtr texCoords);

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_loadMesh")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_loadMesh_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string filename, IntPtr vertices, IntPtr indices, IntPtr normals, IntPtr colors, IntPtr texCoords);

    public static ExceptionStatus ptcloud_loadMesh(string filename, IntPtr vertices, IntPtr indices, IntPtr normals, IntPtr colors, IntPtr texCoords)
        => IsWindows()
            ? ptcloud_loadMesh_Windows(filename, vertices, indices, normals, colors, texCoords)
            : ptcloud_loadMesh_NotWindows(filename, vertices, indices, normals, colors, texCoords);

    // saveMesh

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_saveMesh")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_saveMesh_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, IntPtr vertices, IntPtr indices, IntPtr normals, IntPtr colors, IntPtr texCoords);

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_saveMesh")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_saveMesh_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string filename, IntPtr vertices, IntPtr indices, IntPtr normals, IntPtr colors, IntPtr texCoords);

    public static ExceptionStatus ptcloud_saveMesh(string filename, IntPtr vertices, IntPtr indices, IntPtr normals, IntPtr colors, IntPtr texCoords)
        => IsWindows()
            ? ptcloud_saveMesh_Windows(filename, vertices, indices, normals, colors, texCoords)
            : ptcloud_saveMesh_NotWindows(filename, vertices, indices, normals, colors, texCoords);
}
