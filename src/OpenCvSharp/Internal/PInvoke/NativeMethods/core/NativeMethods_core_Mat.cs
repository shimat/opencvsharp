using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591

#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong core_Mat_sizeof();

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new2(int rows, int cols, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new3(int rows, int cols, MatType type, Scalar scalar, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new4(IntPtr mat, Range rowRange, Range colRange, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new5(IntPtr mat, Range rowRange, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new6(IntPtr mat, [MarshalAs(UnmanagedType.LPArray)] Range[] rowRange, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new7(IntPtr mat, Rect roi, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new8(int rows, int cols, MatType type, IntPtr data, IntPtr step, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new9(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes,
        MatType type, IntPtr data, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] steps, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new9(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes,
        MatType type, IntPtr data, IntPtr steps, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new10(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new11(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, MatType type, Scalar s, out IntPtr returnValue);

    // MatShape (OpenCV 5)
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_shape(
        OpenCvSafeHandle self, [MarshalAs(UnmanagedType.LPArray)] int[] sizes,
        out int outNdims, out int outLayout, out int outC, out int outEmpty);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_newFromMatShape(
        int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int layout, int channels, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_newFromMatShapeScalar(
        int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int layout, int channels, MatType type, Scalar s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_reshapeMatShape(
        OpenCvSafeHandle self, int cn, int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int layout, int channels, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_zeros_MatShape(
        int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int layout, int channels, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ones_MatShape(
        int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int layout, int channels, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_new12(IntPtr mat, out IntPtr returnValue);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus core_Mat_release(IntPtr mat);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_delete(IntPtr mat);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_getUMat(OpenCvSafeHandle self, int accessFlag, int usageFlags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_row(OpenCvSafeHandle self, int y, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_col(OpenCvSafeHandle self, int x, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_rowRange(OpenCvSafeHandle self, int startRow, int endRow, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_colRange(OpenCvSafeHandle self, int startCol, int endCol, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_diag(OpenCvSafeHandle self, int d, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_diag_static(IntPtr self, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_clone(OpenCvSafeHandle self, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_copyTo1(OpenCvSafeHandle self, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_copyTo2(OpenCvSafeHandle self, IntPtr m, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_copyTo_toMat1(OpenCvSafeHandle self, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_copyTo_toMat2(OpenCvSafeHandle self, IntPtr m, IntPtr mask);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_convertTo(OpenCvSafeHandle self, IntPtr m, MatType rtype, double alpha, double beta);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_assignTo(OpenCvSafeHandle self, IntPtr m, int type);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_setTo_Scalar(OpenCvSafeHandle self, Scalar value, IntPtr mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_setTo_InputArray(OpenCvSafeHandle self, IntPtr value, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_reshape1(
        OpenCvSafeHandle self, int cn, int rows, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_reshape2(
        OpenCvSafeHandle self, int cn, int newndims, [MarshalAs(UnmanagedType.LPArray), In] int[] newsz, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_t(OpenCvSafeHandle self, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_inv(OpenCvSafeHandle self, int method, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_mul(OpenCvSafeHandle self, IntPtr m, double scale, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_cross(OpenCvSafeHandle self, IntPtr m, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_dot(OpenCvSafeHandle self, IntPtr m, out double returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_zeros1(
        int rows, int cols, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_zeros2(
        int ndims, [MarshalAs(UnmanagedType.LPArray), In] int[] sz, MatType type, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ones1(
        int rows, int cols, MatType type, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ones2(
        int ndims, [MarshalAs(UnmanagedType.LPArray), In] int[] sz, MatType type, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_eye(int rows, int cols, MatType type, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_create1(
        OpenCvSafeHandle self, int rows, int cols, MatType type);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_create2(
        OpenCvSafeHandle self, int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, MatType type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_reserve(OpenCvSafeHandle self, IntPtr sz);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_reserveBuffer(OpenCvSafeHandle self, IntPtr sz);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_resize1(OpenCvSafeHandle obj, IntPtr sz);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_resize2(OpenCvSafeHandle obj, IntPtr sz, Scalar s);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_pop_back(OpenCvSafeHandle obj, IntPtr nelems);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_locateROI(OpenCvSafeHandle self, out Size wholeSize, out Point ofs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_adjustROI(
        OpenCvSafeHandle nativeObj, int dtop, int dbottom, int dleft, int dright, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_subMat1(
        OpenCvSafeHandle self, int rowStart, int rowEnd, int colStart, int colEnd, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_subMat2(
        OpenCvSafeHandle self, int nRanges, Range[] ranges, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_isContinuous(OpenCvSafeHandle self, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_isSubmatrix(OpenCvSafeHandle self, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_elemSize(OpenCvSafeHandle self, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_elemSize1(OpenCvSafeHandle self, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_type(OpenCvSafeHandle self, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_depth(OpenCvSafeHandle self, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_channels(OpenCvSafeHandle self, out int returnValue);

        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_empty(OpenCvSafeHandle self, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_total1(OpenCvSafeHandle self, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_total2(OpenCvSafeHandle self, int startDim, int endDim, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_checkVector(
        OpenCvSafeHandle self, int elemChannels, int depth, int requireContinuous, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ptr1d(OpenCvSafeHandle self, int i0, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ptr2d(OpenCvSafeHandle self, int i0, int i1, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ptr3d(OpenCvSafeHandle self, int i0, int i1, int i2, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_ptrnd(OpenCvSafeHandle self, [MarshalAs(UnmanagedType.LPArray), In] int[] idx, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_flags(OpenCvSafeHandle self, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_dims(OpenCvSafeHandle self, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_rows(OpenCvSafeHandle self, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_cols(OpenCvSafeHandle self, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus core_Mat_data(OpenCvSafeHandle self, out byte* returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_datastart(OpenCvSafeHandle self, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_dataend(OpenCvSafeHandle self, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_datalimit(OpenCvSafeHandle self, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_size(OpenCvSafeHandle self, out Size returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_sizeAt(OpenCvSafeHandle self, int i, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_step1(OpenCvSafeHandle self, int i, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_step(OpenCvSafeHandle self, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_stepAt(OpenCvSafeHandle self, int i, out IntPtr returnValue);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus core_Mat_assignment_FromMat(IntPtr self, IntPtr newMat);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus core_Mat_assignment_FromScalar(IntPtr self, Scalar scalar);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_abs_Mat(IntPtr e, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus core_Mat_setMatData(OpenCvSafeHandle obj, byte* vals, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus core_Mat_getMatData(OpenCvSafeHandle obj, byte* vals, out int returnValue);
        
    #region push_back

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Mat(OpenCvSafeHandle self, IntPtr m);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_char(OpenCvSafeHandle self, sbyte v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_uchar(OpenCvSafeHandle self, byte v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_short(OpenCvSafeHandle self, short v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_ushort(OpenCvSafeHandle self, ushort v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_int(OpenCvSafeHandle self, int v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_float(OpenCvSafeHandle self, float v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_double(OpenCvSafeHandle self, double v);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec2b(OpenCvSafeHandle self, Vec2b v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec3b(OpenCvSafeHandle self, Vec3b v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec4b(OpenCvSafeHandle self, Vec4b v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec6b(OpenCvSafeHandle self, Vec6b v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec2s(OpenCvSafeHandle self, Vec2s v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec3s(OpenCvSafeHandle self, Vec3s v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec4s(OpenCvSafeHandle self, Vec4s v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec6s(OpenCvSafeHandle self, Vec6s v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec2w(OpenCvSafeHandle self, Vec2w v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec3w(OpenCvSafeHandle self, Vec3w v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec4w(OpenCvSafeHandle self, Vec4w v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec6w(OpenCvSafeHandle self, Vec6w v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec2i(OpenCvSafeHandle self, Vec2i v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec3i(OpenCvSafeHandle self, Vec3i v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec4i(OpenCvSafeHandle self, Vec4i v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec6i(OpenCvSafeHandle self, Vec6i v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec2f(OpenCvSafeHandle self, Vec2f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec3f(OpenCvSafeHandle self, Vec3f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec4f(OpenCvSafeHandle self, Vec4f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec6f(OpenCvSafeHandle self, Vec6f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec2d(OpenCvSafeHandle self, Vec2d v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec3d(OpenCvSafeHandle self, Vec3d v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec4d(OpenCvSafeHandle self, Vec4d v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Vec6d(OpenCvSafeHandle self, Vec6d v);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Point(OpenCvSafeHandle self, Point v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Point2f(OpenCvSafeHandle self, Point2f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Point2d(OpenCvSafeHandle self, Point2d v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Point3i(OpenCvSafeHandle self, Point3i v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Point3f(OpenCvSafeHandle self, Point3f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Point3d(OpenCvSafeHandle self, Point3d v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Size(OpenCvSafeHandle self, Size v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Size2f(OpenCvSafeHandle self, Size2f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Size2d(OpenCvSafeHandle self, Size2d v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Rect(OpenCvSafeHandle self, Rect v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Rect2f(OpenCvSafeHandle self, Rect2f v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_push_back_Rect2d(OpenCvSafeHandle self, Rect2d v);

    #endregion

    #region forEach

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_uchar(OpenCvSafeHandle m, MatForeachFunctionByte proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec2b(OpenCvSafeHandle m, MatForeachFunctionVec2b proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec3b(OpenCvSafeHandle m, MatForeachFunctionVec3b proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec4b(OpenCvSafeHandle m, MatForeachFunctionVec4b proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec6b(OpenCvSafeHandle m, MatForeachFunctionVec6b proc);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_short(OpenCvSafeHandle m, MatForeachFunctionInt16 proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec2s(OpenCvSafeHandle m, MatForeachFunctionVec2s proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec3s(OpenCvSafeHandle m, MatForeachFunctionVec3s proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec4s(OpenCvSafeHandle m, MatForeachFunctionVec4s proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec6s(OpenCvSafeHandle m, MatForeachFunctionVec6s proc);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_int(OpenCvSafeHandle m, MatForeachFunctionInt32 proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec2i(OpenCvSafeHandle m, MatForeachFunctionVec2i proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec3i(OpenCvSafeHandle m, MatForeachFunctionVec3i proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec4i(OpenCvSafeHandle m, MatForeachFunctionVec4i proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec6i(OpenCvSafeHandle m, MatForeachFunctionVec6i proc);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_float(OpenCvSafeHandle m, MatForeachFunctionFloat proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec2f(OpenCvSafeHandle m, MatForeachFunctionVec2f proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec3f(OpenCvSafeHandle m, MatForeachFunctionVec3f proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec4f(OpenCvSafeHandle m, MatForeachFunctionVec4f proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec6f(OpenCvSafeHandle m, MatForeachFunctionVec6f proc);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_double(OpenCvSafeHandle m, MatForeachFunctionDouble proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec2d(OpenCvSafeHandle m, MatForeachFunctionVec2d proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec3d(OpenCvSafeHandle m, MatForeachFunctionVec3d proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec4d(OpenCvSafeHandle m, MatForeachFunctionVec4d proc);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_forEach_Vec6d(OpenCvSafeHandle m, MatForeachFunctionVec6d proc);

    #endregion

    #region Operators
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorUnaryMinus(IntPtr mat, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorAdd_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorAdd_MatScalar(IntPtr a, Scalar s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorAdd_ScalarMat(Scalar s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorMinus_Mat(IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorSubtract_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorSubtract_MatScalar(IntPtr a, Scalar s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorSubtract_ScalarMat(Scalar s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorMultiply_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorMultiply_MatDouble(IntPtr a, double s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorMultiply_DoubleMat(double s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorDivide_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorDivide_MatDouble(IntPtr a, double s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorDivide_DoubleMat(double s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorAnd_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorAnd_MatDouble(IntPtr a, double s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorAnd_DoubleMat(double s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorOr_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorOr_MatDouble(IntPtr a, double s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorOr_DoubleMat(double s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorXor_MatMat(IntPtr a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorXor_MatDouble(IntPtr a, double s, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorXor_DoubleMat(double s, IntPtr a, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorNot(IntPtr a, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorLT_MatMat(OpenCvSafeHandle a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorLT_DoubleMat(double a, OpenCvSafeHandle b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorLT_MatDouble(OpenCvSafeHandle a, double b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorLE_MatMat(OpenCvSafeHandle a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorLE_DoubleMat(double a, OpenCvSafeHandle b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorLE_MatDouble(OpenCvSafeHandle a, double b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorGT_MatMat(OpenCvSafeHandle a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorGT_DoubleMat(double a, OpenCvSafeHandle b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorGT_MatDouble(OpenCvSafeHandle a, double b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorGE_MatMat(OpenCvSafeHandle a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorGE_DoubleMat(double a, OpenCvSafeHandle b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorGE_MatDouble(OpenCvSafeHandle a, double b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorEQ_MatMat(OpenCvSafeHandle a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorEQ_DoubleMat(double a, OpenCvSafeHandle b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorEQ_MatDouble(OpenCvSafeHandle a, double b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorNE_MatMat(OpenCvSafeHandle a, IntPtr b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorNE_DoubleMat(double a, OpenCvSafeHandle b, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus core_Mat_operatorNE_MatDouble(OpenCvSafeHandle a, double b, out IntPtr returnValue);

    #endregion
}
