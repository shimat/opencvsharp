using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_new2(
        [MarshalAs(UnmanagedType.LPStr)] string source, 
        int flags, 
        [MarshalAs(UnmanagedType.LPStr)] string? encoding, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_open(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename, 
        int flags, [MarshalAs(UnmanagedType.LPStr)] string? encoding, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_isOpened(OpenCvSafeHandle obj, out int returnValue);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus core_FileStorage_release(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_releaseAndGetString(
        OpenCvSafeHandle obj, IntPtr outString);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_getFirstTopLevelNode(
        OpenCvSafeHandle obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_root(
        OpenCvSafeHandle obj, int streamIdx, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_indexer(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_writeRaw(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_writeComment(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string comment, int append);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_getDefaultObjectName(
        [MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_elname(OpenCvSafeHandle obj, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_startWriteStruct(
        OpenCvSafeHandle obj,
        [MarshalAs(UnmanagedType.LPStr)] string name,
        int flags,
        [MarshalAs(UnmanagedType.LPStr)] string typeName);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_endWriteStruct(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_state(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_int(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_float(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, float value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_double(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_String(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_Mat(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_SparseMat(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_vectorOfKeyPoint(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_write_vectorOfDMatch(
        OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_writeScalar_int(OpenCvSafeHandle fs, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_writeScalar_float(OpenCvSafeHandle fs, float value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_writeScalar_double(OpenCvSafeHandle fs, double value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_writeScalar_String(OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string value);
        

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_String(OpenCvSafeHandle fs, [MarshalAs(UnmanagedType.LPStr)] string val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_int(OpenCvSafeHandle fs, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_float(OpenCvSafeHandle fs, float val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_double(OpenCvSafeHandle fs, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Mat(OpenCvSafeHandle fs, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_SparseMat(OpenCvSafeHandle fs, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Range(OpenCvSafeHandle fs, Range val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_KeyPoint(OpenCvSafeHandle fs, KeyPoint val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_DMatch(OpenCvSafeHandle fs, DMatch val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_vectorOfKeyPoint(OpenCvSafeHandle fs, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_vectorOfDMatch(OpenCvSafeHandle fs, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Point2i(OpenCvSafeHandle fs, Point val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Point2f(OpenCvSafeHandle fs, Point2f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Point2d(OpenCvSafeHandle fs, Point2d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Point3i(OpenCvSafeHandle fs, Point3i val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Point3f(OpenCvSafeHandle fs, Point3f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Point3d(OpenCvSafeHandle fs, Point3d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Size2i(OpenCvSafeHandle fs, Size val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Size2f(OpenCvSafeHandle fs, Size2f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Size2d(OpenCvSafeHandle fs, Size2d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Rect2i(OpenCvSafeHandle fs, Rect val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Rect2f(OpenCvSafeHandle fs, Rect2f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Rect2d(OpenCvSafeHandle fs, Rect2d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Scalar(OpenCvSafeHandle fs, Scalar val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec2i(OpenCvSafeHandle fs, Vec2i val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec3i(OpenCvSafeHandle fs, Vec3i val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec4i(OpenCvSafeHandle fs, Vec4i val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec6i(OpenCvSafeHandle fs, Vec6i val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec2d(OpenCvSafeHandle fs, Vec2d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec3d(OpenCvSafeHandle fs, Vec3d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec4d(OpenCvSafeHandle fs, Vec4d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec6d(OpenCvSafeHandle fs, Vec6d val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec2f(OpenCvSafeHandle fs, Vec2f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec3f(OpenCvSafeHandle fs, Vec3f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec4f(OpenCvSafeHandle fs, Vec4f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec6f(OpenCvSafeHandle fs, Vec6f val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec2b(OpenCvSafeHandle fs, Vec2b val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec3b(OpenCvSafeHandle fs, Vec3b val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec4b(OpenCvSafeHandle fs, Vec4b val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec6b(OpenCvSafeHandle fs, Vec6b val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec2s(OpenCvSafeHandle fs, Vec2s val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec3s(OpenCvSafeHandle fs, Vec3s val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec4s(OpenCvSafeHandle fs, Vec4s val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec6s(OpenCvSafeHandle fs, Vec6s val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec2w(OpenCvSafeHandle fs, Vec2w val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec3w(OpenCvSafeHandle fs, Vec3w val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec4w(OpenCvSafeHandle fs, Vec4w val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_FileStorage_shift_Vec6w(OpenCvSafeHandle fs, Vec6w val);
}
