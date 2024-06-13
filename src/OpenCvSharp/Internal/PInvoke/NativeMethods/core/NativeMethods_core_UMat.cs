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
    public static extern ExceptionStatus core_UMat_new1(int usageFlags, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new2(int rows, int cols, MatType type, int usageFlags, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new3(int rows, int cols, MatType type, Scalar scalar, int usageFlags, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new4(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, MatType type, out IntPtr returnValue);
        
    // Not exported
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new5(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, MatType type, Scalar s, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new6(IntPtr umat, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new7(IntPtr umat, Range rowRange, Range colRange, int usageFlags, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new8(IntPtr umat, Rect roi, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_new9(IntPtr umat, Range[] ranges, out IntPtr returnValue);



    //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus core_UMat_release(IntPtr mat);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_delete(IntPtr umat);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_getMat(IntPtr self, int accessFlag, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_row(IntPtr self, int y, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_col(IntPtr self, int x, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_rowRange(IntPtr self, int startRow, int endRow, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_colRange(IntPtr self, int startCol, int endCol, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_diag(IntPtr self, int d, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_diag_static(IntPtr self, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_clone(IntPtr self, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_copyTo1(IntPtr self, IntPtr m);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_copyTo2(IntPtr self, IntPtr m, IntPtr mask);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_copyTo_toUMat1(IntPtr self, IntPtr m);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_copyTo_toUMat2(IntPtr self, IntPtr m, IntPtr mask);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_convertTo(IntPtr self, IntPtr m, MatType rtype, double alpha, double beta);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_assignTo(IntPtr self, IntPtr m, int type);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_setTo_Scalar(IntPtr self, Scalar value, IntPtr mask);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_setTo_InputArray(IntPtr self, IntPtr value, IntPtr mask);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_reshape1(
        IntPtr self, int cn, int rows, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_reshape2(
        IntPtr self, int cn, int newndims, [MarshalAs(UnmanagedType.LPArray), In] int[] newsz, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_t(IntPtr self, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_inv(IntPtr self, int method, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_mul(IntPtr self, IntPtr m, double scale, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_dot(IntPtr self, IntPtr m, out double returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_zeros1(
        int rows, int cols, MatType type, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_zeros2(
        int ndims, [MarshalAs(UnmanagedType.LPArray), In] int[] sz, MatType type, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_ones1(
        int rows, int cols, MatType type, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_ones2(
        int ndims, [MarshalAs(UnmanagedType.LPArray), In] int[] sz, MatType type, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_eye(int rows, int cols, MatType type, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_create1(
        IntPtr self, int rows, int cols, MatType type);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_create2(
        IntPtr self, int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, MatType type);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_locateROI(IntPtr self, out Size wholeSize, out Point ofs);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_adjustROI(
        IntPtr nativeObj, int dtop, int dbottom, int dleft, int dright, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_subMat1(
        IntPtr self, int rowStart, int rowEnd, int colStart, int colEnd, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_subMat2(
        IntPtr self, int nRanges, Range[] ranges, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_isContinuous(IntPtr self, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_isSubmatrix(IntPtr self, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_elemSize(IntPtr self, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_elemSize1(IntPtr self, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_type(IntPtr self, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_depth(IntPtr self, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_channels(IntPtr self, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_step1(IntPtr self, int i, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_empty(IntPtr self, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_total(IntPtr self, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_checkVector(
        IntPtr self, int elemChannels, int depth, int requireContinuous, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_flags(IntPtr self, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_dims(IntPtr self, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_rows(IntPtr self, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_cols(IntPtr self, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_size(IntPtr self, out Size returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_sizeAt(IntPtr self, int i, out int returnValue);
        
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_step(IntPtr self, out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_UMat_stepAt(IntPtr self, int i, out IntPtr returnValue);
}
