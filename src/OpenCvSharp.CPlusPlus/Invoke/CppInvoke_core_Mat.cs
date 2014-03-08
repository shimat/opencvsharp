/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class CppInvoke
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong core_Mat_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new1")]
        public static extern IntPtr core_Mat_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new2")]
        public static extern IntPtr core_Mat_new(int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new3")]
        public static extern IntPtr core_Mat_new(int rows, int cols, int type, CvScalar scalar);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new4")]
        public static extern IntPtr core_Mat_new(IntPtr mat, CvSlice rowRange, CvSlice colRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new5")]
        public static extern IntPtr core_Mat_new(IntPtr mat, CvSlice rowRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new6")]
        public static extern IntPtr core_Mat_new(IntPtr mat, CvRect roi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new7")]
        public static extern IntPtr core_Mat_new(int rows, int cols, int type, IntPtr data, IntPtr step);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new8")]
        public static extern IntPtr core_Mat_new(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, 
            int type, IntPtr data, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] steps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_new8")]
        public static extern IntPtr core_Mat_new(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes,
                                int type, IntPtr data, [MarshalAs(UnmanagedType.LPArray)] IntPtr steps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_new_FromIplImage(IntPtr img, int copyData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_new_FromCvMat(IntPtr mat, int copyData);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_release(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_delete(IntPtr mat);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_adjustROI(IntPtr nativeObj, int dtop, int dbottom, int dleft, int dright);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_assignTo1")]
        public static extern void core_Mat_assignTo(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_assignTo2")]
        public static extern void core_Mat_assignTo(IntPtr self, IntPtr m, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_channels(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_checkVector1")]
        public static extern int core_Mat_checkVector(IntPtr self, int elemChannels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_checkVector2")]
        public static extern int core_Mat_checkVector(IntPtr self, int elemChannels, int depth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_checkVector3")]
        public static extern int core_Mat_checkVector(IntPtr self, int elemChannels, int depth, int requireContinuous);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_clone(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_col_toMat(IntPtr self, int x);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_col_toMatExpr(IntPtr self, int x);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_cols(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_colRange_toMat(IntPtr self, int startCol, int endCol);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_colRange_toMatExpr(IntPtr self, int startCol, int endCol);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_dims(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_convertTo(IntPtr self, IntPtr m, int rtype, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_copyTo(IntPtr self, IntPtr m, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_create1")]
        public static extern void core_Mat_create(IntPtr self, int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_create2")]
        public static extern void core_Mat_create(IntPtr self, int ndims, 
            [MarshalAs(UnmanagedType.LPArray)] int[] sizes, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_cross(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* core_Mat_data(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_datastart(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_dataend(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_depth(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_diag1")]
        public static extern IntPtr core_Mat_diag(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_diag2")]
        public static extern IntPtr core_Mat_diag(IntPtr self, int d);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_Mat_dot(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong core_Mat_elemSize(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong core_Mat_elemSize1(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_empty(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_eye(int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_inv1")]
        public static extern IntPtr core_Mat_inv(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_inv2")]
        public static extern IntPtr core_Mat_inv(IntPtr self, int method);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_isContinuous(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_isSubmatrix(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_locateROI(IntPtr self, out CvSize wholeSize, out CvPoint ofs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_mul1")]
        public static extern IntPtr core_Mat_mul(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_mul2")]
        public static extern IntPtr core_Mat_mul(IntPtr self, IntPtr m, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_ones1")]
        public static extern IntPtr core_Mat_ones(int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_ones2")]
        public static extern IntPtr core_Mat_ones(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sz, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_push_back(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_push_back1")]
        public static extern IntPtr core_Mat_reshape(IntPtr self, int cn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_push_back2")]
        public static extern IntPtr core_Mat_reshape(IntPtr self, int cn, int rows);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_push_back3")]
        public static extern IntPtr core_Mat_reshape(IntPtr self, int cn, int newndims, [MarshalAs(UnmanagedType.LPArray)] int[] newsz);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_rows(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_row_toMat(IntPtr self, int y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_row_toMatExpr(IntPtr self, int y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_rowRange_toMat(IntPtr self, int startRow, int endRow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_rowRange_toMatExpr(IntPtr self, int startRow, int endRow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_setTo1")]
        public static extern IntPtr core_Mat_setTo(IntPtr self, CvScalar value, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_setTo2")]
        public static extern IntPtr core_Mat_setTo(IntPtr self, IntPtr value, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize core_Mat_size(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_sizeAt(IntPtr self, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_step11")]
        public static extern ulong core_Mat_step1(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_step12")]
        public static extern ulong core_Mat_step1(IntPtr self, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern long core_Mat_step(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong core_Mat_stepAt(IntPtr self, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_subMat1")]
        public static extern IntPtr core_Mat_subMat(IntPtr self, int rowStart, int rowEnd, int colStart, int colEnd);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_subMat2")]
        public static extern IntPtr core_Mat_subMat(IntPtr self, int nRanges, CvSlice[] ranges);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_t(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong core_Mat_total(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_type(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_zeros1")]
        public static extern IntPtr core_Mat_zeros(int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_zeros2")]
        public static extern IntPtr core_Mat_zeros(int ndims, [MarshalAs(UnmanagedType.LPArray)] int[] sz, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe sbyte* core_Mat_dump(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string format);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void core_Mat_dump_delete(sbyte* buf);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_ptr1d(IntPtr self, int i0);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_ptr2d(IntPtr self, int i0, int i1);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_ptr3d(IntPtr self, int i0, int i1, int i2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Mat_ptrnd(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] idx);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_assignment_FromMat(IntPtr self, IntPtr newMat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_assignment_FromMatExpr(IntPtr self, IntPtr newMatExpr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_assignment_FromScalar(IntPtr self, CvScalar scalar);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_IplImage(IntPtr self, IntPtr outImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_IplImage_alignment(IntPtr self, out IntPtr outImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Mat_CvMat(IntPtr self, IntPtr outMat);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorUnaryMinus_Mat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_MatScalar(IntPtr a, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_ScalarMat(CvScalar s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMinus_Mat(IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_MatScalar(IntPtr a, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_ScalarMat(CvScalar s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_MatDouble(IntPtr a, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_DoubleMat(double s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_MatDouble(IntPtr a, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_DoubleMat(double s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAnd_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAnd_MatDouble(IntPtr a, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAnd_DoubleMat(double s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorOr_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorOr_MatDouble(IntPtr a, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorOr_DoubleMat(double s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorXor_MatMat(IntPtr a, IntPtr b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorXor_MatDouble(IntPtr a, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorXor_DoubleMat(double s, IntPtr a);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorNot_Mat(IntPtr a);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_abs_Mat(IntPtr e);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetB(IntPtr obj, int row, int col, 
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetS(IntPtr obj, int row, int col, 
            [In, MarshalAs(UnmanagedType.LPArray)] short[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetI(IntPtr obj, int row, int col, 
            [In, MarshalAs(UnmanagedType.LPArray)] int[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetF(IntPtr obj, int row, int col, 
            [In, MarshalAs(UnmanagedType.LPArray)] float[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetD(IntPtr obj, int row, int col, 
            [In, MarshalAs(UnmanagedType.LPArray)] double[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetVec3b(IntPtr obj, int row, int col,
            [In, MarshalAs(UnmanagedType.LPArray)] Vec3b[] vals, int valsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nSetPoint(IntPtr obj, int row, int col,
            [In, MarshalAs(UnmanagedType.LPArray)] Point[] vals, int valsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetB(IntPtr obj, int row, int col, 
            [In, Out, MarshalAs(UnmanagedType.LPArray)] byte[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetS(IntPtr obj, int row, int col, 
            [In, Out, MarshalAs(UnmanagedType.LPArray)] short[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetI(IntPtr obj, int row, int col, 
            [In, Out, MarshalAs(UnmanagedType.LPArray)] int[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetF(IntPtr obj, int row, int col, 
            [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetD(IntPtr obj, int row, int col, 
            [In, Out, MarshalAs(UnmanagedType.LPArray)] double[] vals, int valsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetVec3b(IntPtr obj, int row, int col,
            [In, Out, MarshalAs(UnmanagedType.LPArray)] Vec3b[] vals, int valsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Mat_nGetPoint(IntPtr obj, int row, int col,
            [In, Out, MarshalAs(UnmanagedType.LPArray)] Point[] vals, int valsLength);
    }
}