using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_new1(out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_new2(int dims, int[] sizes, MatType type, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_new3(IntPtr m, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_operatorAssign_SparseMat(IntPtr obj, IntPtr m);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_operatorAssign_Mat(IntPtr obj, IntPtr m);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_clone(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_copyTo_SparseMat(IntPtr obj, IntPtr m);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_copyTo_Mat(IntPtr obj, IntPtr m);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_convertTo_SparseMat(
        IntPtr obj, IntPtr m, MatType rtype, double alpha);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_convertTo_Mat(
        IntPtr obj, IntPtr m, MatType rtype, double alpha, double beta);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_assignTo(IntPtr obj, IntPtr m, MatType type);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_create(IntPtr obj, int dims, int[] sizes, MatType type);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_clear(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_addref(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_release(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_elemSize(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_elemSize1(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_type(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_depth(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_channels(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_size1(IntPtr obj, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_size2(IntPtr obj, int i, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_dims(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_nzcount(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_hash_1d(IntPtr obj, int i0, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_hash_2d(IntPtr obj, int i0, int i1, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_hash_3d(IntPtr obj, int i0, int i1, int i2, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_SparseMat_hash_nd(IntPtr obj, int[] idx, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus core_SparseMat_ptr_1d(
        IntPtr obj, int i0, int createMissing, ulong* hashVal, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus core_SparseMat_ptr_2d(
        IntPtr obj, int i0, int i1, int createMissing, ulong* hashVal, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus core_SparseMat_ptr_3d(
        IntPtr obj, int i0, int i1, int i2, int createMissing, ulong* hashVal, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus core_SparseMat_ptr_nd(
        IntPtr obj, int[] idx, int createMissing, ulong* hashVal, out IntPtr returnValue);

}
