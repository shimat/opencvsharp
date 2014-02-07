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

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// P/Invoke methods of OpenCV C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class CppInvoke
    {
        /// <summary>
        /// DLL file name
        /// </summary>
        public const string DllExtern = "OpenCvSharpExtern";

        #region Static constructor
        /// <summary>
        /// Static constructor
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static CppInvoke()
        {
            // call cv to enable redirecting 
            Cv.GetTickCount();
            TryPInvoke();
        }

#if LANG_JP
        /// <summary>
        /// PInvokeが正常に行えるかチェックする
        /// </summary>
#else
        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
#endif
        private static void TryPInvoke()
        {
            if (tried)
                return;
            tried = true;

            try
            {
                core_Mat_sizeof();
            }
            catch (DllNotFoundException e)
            {
                throw PInvokeHelper.CreateException(e);
            }
            catch (BadImageFormatException e)
            {
                throw PInvokeHelper.CreateException(e);
            }
        }
        private static bool tried = false;
        #endregion

        #region DllImport
        #region Mat
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
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_convertTo1")]
        public static extern void core_Mat_convertTo(IntPtr self, IntPtr m, int rtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_convertTo2")]
        public static extern void core_Mat_convertTo(IntPtr self, IntPtr m, int rtype, double alpha);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_Mat_convertTo3")]
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
        public static extern void core_Mat_CvMat(IntPtr self, IntPtr outMat);

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
        #endregion
        #region MatExpr
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_new1")]
        public static extern IntPtr core_MatExpr_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_new2")]
        public static extern IntPtr core_MatExpr_new(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_MatExpr_delete(IntPtr expr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_toMat(IntPtr expr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorUnaryMinus_MatExpr(IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorUnaryNot_MatExpr(IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_MatExprMat(IntPtr e, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_MatMatExpr(IntPtr m, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_MatExprScalar(IntPtr e, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_ScalarMatExpr(CvScalar s, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorAdd_MatExprMatExpr(IntPtr e1, IntPtr e2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_MatExprMat(IntPtr e, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_MatMatExpr(IntPtr m, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_MatExprScalar(IntPtr e, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_ScalarMatExpr(CvScalar s, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorSubtract_MatExprMatExpr(IntPtr e1, IntPtr e2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_MatExprMat(IntPtr e, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_MatMatExpr(IntPtr m, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_MatExprDouble(IntPtr e, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_DoubleMatExpr(double s, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorMultiply_MatExprMatExpr(IntPtr e1, IntPtr e2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_MatExprMat(IntPtr e, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_MatMatExpr(IntPtr m, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_MatExprDouble(IntPtr e, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_DoubleMatExpr(double s, IntPtr e);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_operatorDivide_MatExprMatExpr(IntPtr e1, IntPtr e2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_row(IntPtr self, int y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_col(IntPtr self, int x);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_diag1")]
        public static extern IntPtr core_MatExpr_diag(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_diag2")]
        public static extern IntPtr core_MatExpr_diag(IntPtr self, int d);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_submat(IntPtr self, int rowStart, int rowEnd, int colStart, int colEnd);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_cross(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_MatExpr_dot(IntPtr self, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_t(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_inv1")]
        public static extern IntPtr core_MatExpr_inv(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_MatExpr_inv2")]
        public static extern IntPtr core_MatExpr_inv(IntPtr self, int method);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_mul_toMatExpr(IntPtr self, IntPtr e, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_MatExpr_mul_toMat(IntPtr self, IntPtr m, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize core_MatExpr_size(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_MatExpr_type(IntPtr self);

        #endregion
        #region InputArray/OutputArray
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_InputArray_new_byMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_InputArray_delete(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_OutputArray_new_byMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_OutputArray_delete(IntPtr oa);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_InputArray_kind(IntPtr ia);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_OutputArray_getMat(IntPtr oa);
        #endregion

        #region imgproc

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_getGaborKernel(CvSize ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_getStructuringElement(int shape, CvSize ksize, CvPoint anchor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_copyMakeBorder(IntPtr src, IntPtr dst, int top, int bottom, int left,
                                                         int right, int borderType, CvScalar value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_medianBlur(IntPtr src, IntPtr dst, int ksize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GaussianBlur(IntPtr src, IntPtr dst, CvSize ksize, double sigmaX,
                                                       double sigmaY, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_bilateralFilter(IntPtr src, IntPtr dst, int d, double sigmaColor,
                                                          double sigmaSpace, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_adaptiveBilateralFilter(IntPtr src, IntPtr dst, CvSize ksize,
            double sigmaSpace, double maxSigmaColor, CvPoint anchor, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_boxFilter(IntPtr src, IntPtr dst, int ddepth, CvSize ksize, CvPoint anchor,
                                                    int normalize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_blur(IntPtr src, IntPtr dst, CvSize ksize, CvPoint anchor, int borderType);

        #endregion

        #region cv
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Canny(IntPtr image, IntPtr edges, double threshold1, double threshold2, [MarshalAs(UnmanagedType.I4)] ApertureSize apertureSize, [MarshalAs(UnmanagedType.Bool)] bool l2Gradient);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_convertMaps(IntPtr map1, IntPtr map2, IntPtr dstmap1, IntPtr dstmap2, int dstmap1Type, int nninterpolation);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_cornerEigenValsAndVecs(IntPtr src, IntPtr dst, int blockSize, int ksize, [MarshalAs(UnmanagedType.I4)] BorderType borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_cornerHarris(IntPtr src, IntPtr dst, int blockSize, int ksize, double k, [MarshalAs(UnmanagedType.I4)] BorderType borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_cornerSubPix(IntPtr image, IntPtr corners, CvSize winSize, CvSize zeroZone, CvTermCriteria criteria);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_cvtColor(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.I4)] ColorConversion code, int dstCn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_erode(IntPtr src, IntPtr dst, IntPtr kernel, CvPoint anchor, int iterations, [MarshalAs(UnmanagedType.I4)] BorderType borderType, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_dilate(IntPtr src, IntPtr dst, IntPtr kernel, CvPoint anchor, int iterations, [MarshalAs(UnmanagedType.I4)] BorderType borderType, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_HoughCircles(IntPtr image, IntPtr circles, [MarshalAs(UnmanagedType.I4)] HoughCirclesMethod method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_HoughLines(IntPtr image, IntPtr lines, double rho, double theta, int threshold, double srn, double stn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_HoughLinesP(IntPtr image, IntPtr lines, double rho, double theta, int threshold, double minLineLength, double maxLineGap);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_morphologyEx(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.I4)] MorphologyOperation op, IntPtr kernel, CvPoint anchor, int iterations, [MarshalAs(UnmanagedType.I4)] BorderType borderType, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_preCornerDetect(IntPtr src, IntPtr dst, int ksize, [MarshalAs(UnmanagedType.I4)] BorderType borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_remap(IntPtr src, IntPtr dst, IntPtr map1, IntPtr map2, [MarshalAs(UnmanagedType.I4)] Interpolation interpolation, [MarshalAs(UnmanagedType.I4)] BorderType borderMode, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_resize(IntPtr src, IntPtr dst, CvSize dsize, double fx, double fy, [MarshalAs(UnmanagedType.I4)] Interpolation interpolation);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_warpAffine(IntPtr src, IntPtr dst, IntPtr M, CvSize dsize, [MarshalAs(UnmanagedType.I4)] Interpolation flags, [MarshalAs(UnmanagedType.I4)] BorderType borderMode, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_warpPerspective(IntPtr src, IntPtr dst, IntPtr M, CvSize dsize, [MarshalAs(UnmanagedType.I4)] Interpolation flags, [MarshalAs(UnmanagedType.I4)]  BorderType borderMode, CvScalar borderValue);
        #region StereoSGBM
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr StereoSGBM_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr StereoSGBM_new2(int minDisparity, int numDisparities, int sadWindowSize, int p1, int p2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, [MarshalAs(UnmanagedType.Bool)] bool fullDP);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_exec(IntPtr self, IntPtr left, IntPtr right, IntPtr disp);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_minDisparity_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_minDisparity_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_numberOfDisparities_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_numberOfDisparities_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_SADWindowSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_SADWindowSize_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_preFilterCap_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_preFilterCap_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_uniquenessRatio_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_uniquenessRatio_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_P1_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_P1_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_P2_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_P2_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_speckleWindowSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_speckleWindowSize_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_speckleRange_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_speckleRange_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_disp12MaxDiff_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_disp12MaxDiff_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_fullDP_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_fullDP_set(IntPtr self, int value);
        #endregion
        #endregion
        #region core
        #region Algorithm

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv_Algorithm_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_name(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_Algorithm_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_Algorithm_getInt(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cv_Algorithm_getDouble(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cv_Algorithm_getBool(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_getString(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_getMat(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr outMat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_getMatVector(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr outVec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv_Algorithm_getAlgorithm(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setInt(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setDouble(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setBool(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setString(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setMat(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setMatVector(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setAlgorithm(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        #endregion
        #region MatND
        #region Init & Disposal
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MatND_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_new1();
        #endregion
        #region Fields
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MatND_flags_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MatND_dims_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_refcount_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_data_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_datastart_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_dataend_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_size_get(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_step_get(IntPtr src);
        #endregion
        #region Operators
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_opRange(IntPtr src, CvSlice[] ranges, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_opMat(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_opCvMatND(IntPtr src, IntPtr dst);
        #endregion
        #region Methods
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_copyTo1(IntPtr src, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_copyTo2(IntPtr src, IntPtr m, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_convertTo(IntPtr src, IntPtr m, [MarshalAs(UnmanagedType.I4)] MatrixType rtype, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_setTo(IntPtr src, CvScalar s, IntPtr mask, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_reshape(IntPtr src, int newCn, int newNdims, [MarshalAs(UnmanagedType.LPArray)] int[] newsz, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_ptr1(IntPtr src, int i0);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_ptr2(IntPtr src, int i0, int i1);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_ptr3(IntPtr src, int i0, int i1, int i2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MatND_ptr4(IntPtr src, [MarshalAs(UnmanagedType.LPArray)] int[] idx);
        #endregion
        #endregion
        #region Array Operations
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_abs1(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_add1(IntPtr a, IntPtr b, IntPtr c, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_add2(IntPtr a, CvScalar s, IntPtr c, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_subtract1(IntPtr a, IntPtr b, IntPtr c, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_subtract2(IntPtr a, CvScalar s, IntPtr c, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_subtract3(CvScalar s, IntPtr a, IntPtr c, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_multiply(IntPtr a, IntPtr b, IntPtr c, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_divide1(IntPtr a, IntPtr b, IntPtr c, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_divide2(double scale, IntPtr b, IntPtr c);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);
        #endregion
        #region Miscellaneous
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_setNumThreads(int nthreads);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_getNumThreads();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_getThreadNum();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string cv_getBuildInformation();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int64 cv_getTickCount();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cv_getTickFrequency();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int64 cv_getCPUTickCount();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cv_checkHardwareSupport([MarshalAs(UnmanagedType.I4)] HardwareSupport feature);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_getNumberOfCPUs();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv_fastMalloc(IntPtr bufSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_fastFree(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_cvarrToMat(IntPtr arr, [MarshalAs(UnmanagedType.Bool)] bool copyData, [MarshalAs(UnmanagedType.Bool)] bool allowND, int coiMode, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_extractImageCOI(IntPtr arr, IntPtr coiimg, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_insertImageCOI(IntPtr coiimg, IntPtr arr, int coi);
        #endregion

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_solvePnP(IntPtr selfectPoints, IntPtr imagePoints, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvec, IntPtr tvec, bool useExtrinsicGuess);

        #endregion
        #region highgui
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winname, [MarshalAs(UnmanagedType.I4)] WindowMode flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_imshow([MarshalAs(UnmanagedType.LPStr)] string winname, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imread(string filename, [MarshalAs(UnmanagedType.I4)] LoadMode flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imdecode(IntPtr buf, [MarshalAs(UnmanagedType.I4)] LoadMode flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_imencode([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, out IntPtr buf, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_waitKey(int delay);
        #endregion
        #region cvaux
        #region CvCamShiftTracker
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvCamShiftTracker_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvCamShiftTracker_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_get_orientation(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_get_length(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_get_width(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint2D32f CvCamShiftTracker_get_center(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect CvCamShiftTracker_get_window(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_threshold(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_hist_dims(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] dims);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_min_ch_val(IntPtr self, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_max_ch_val(IntPtr self, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_window(IntPtr self, CvRect window);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_threshold(IntPtr self, int threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_hist_bin_range(IntPtr self, int dim, int minVal, int maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_hist_dims(IntPtr self, int cDims, [MarshalAs(UnmanagedType.LPArray)] int[] dims);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_min_ch_val(IntPtr self, int channel, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_max_ch_val(IntPtr self, int channel, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_track_object(IntPtr self, IntPtr curFrame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_update_histogram(IntPtr self, IntPtr curFrame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvCamShiftTracker_reset_histogram(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvCamShiftTracker_get_back_project(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_query(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] bin);
        #endregion
        #region CvAdaptiveSkinDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvAdaptiveSkinDetector_new(int samplingDivider, [MarshalAs(UnmanagedType.I4)] MorphingMethod morphingMethod);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvAdaptiveSkinDetector_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvAdaptiveSkinDetector_process(IntPtr self, IntPtr inputBgrImage, IntPtr outputHueMask);
        #endregion
        #region HOGDescriptor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new2(CvSize winSize, CvSize blockSize, CvSize blockStride, CvSize cellSize,
            int nbins, int derivAperture, double winSigma, [MarshalAs(UnmanagedType.I4)] HistogramNormType histogramNormType,
            double l2HysThreshold, bool gammaCorrection, int nlevels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new3([MarshalAs(UnmanagedType.LPStr)] string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_getDescriptorSize(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HOGDescriptor_checkDetectorSize(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_getWinSigma(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_setSVMDetector(IntPtr self, IntPtr svmdetector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HOGDescriptor_load(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_save(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_compute(IntPtr self, IntPtr img, IntPtr descriptors,
                         CvSize winStride, CvSize padding, [In] CvPoint[] locations, int locationsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_detect(IntPtr self, IntPtr img, IntPtr foundLocations,
                        double hitThreshold, CvSize winStride, CvSize padding, [In] CvPoint[] searchLocations, int searchLocationsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_detectMultiScale(IntPtr self, IntPtr img, IntPtr foundLocations,
                                  double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_computeGradient(IntPtr self, IntPtr img, IntPtr grad, IntPtr angleOfs, CvSize paddingTL, CvSize paddingBR);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_winSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_blockSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_blockStride_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_cellSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_nbins_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_derivAperture_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_winSigma_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_histogramNormType_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_L2HysThreshold_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_gammaCorrection_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_nlevels_get(IntPtr self);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_winSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_blockSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_blockStride_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_cellSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_nbins_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_derivAperture_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_winSigma_set(IntPtr self, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_histogramNormType_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_L2HysThreshold_set(IntPtr self, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_gammaCorrection_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_nlevels_set(IntPtr self, int value);
        #endregion
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_FAST(IntPtr image, IntPtr keypoints, int threshold, [MarshalAs(UnmanagedType.Bool)] bool nonmaxSupression);
        #endregion
        #region nonfree
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cv_initModule_nonfree();
        #endregion
        #region video
        #region BackgroundSubtractor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BackgroundSubtractor_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractor_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        #endregion
        #region BackgroundSubtractorMOG
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BackgroundSubtractorMOG_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_initialize(IntPtr self, CvSize frameSize, int frameType);
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize BackgroundSubtractorMOG_frameSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_frameSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_frameType(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG_bgmodel(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_nframes(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_history(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_nmixtures(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* BackgroundSubtractorMOG_varThreshold(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* BackgroundSubtractorMOG_backgroundRatio(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* BackgroundSubtractorMOG_noiseSigma(IntPtr self);
        //*/
        #endregion
        #region BackgroundSubtractorMOG2
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BackgroundSubtractorMOG2_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG2_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG2_new2(int history, float varThreshold, int bShadowDetection);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_operator(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_initialize(IntPtr self, CvSize frameSize, int frameType);
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize BackgroundSubtractorMOG2_frameSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_frameSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_frameType(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG2_bgmodel(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG2_bgmodelUsedModes(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_nframes(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_history(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_nmixtures(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_varThreshold(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_backgroundRatio(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_varThresholdGen(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fVarInit(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fVarMin(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fVarMax(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fCT(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool* BackgroundSubtractorMOG2_bShadowDetection(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* BackgroundSubtractorMOG2_nShadowDetection(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fTau(IntPtr self);
        //*/
        #endregion
        #endregion
        #region std::vector<T>
        #region uchar
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_new3([In] byte[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_uchar_delete(IntPtr vector);
        #endregion
        #region float
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_new3([In] float[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_float_delete(IntPtr vector);
        #endregion
        #region cv::Vec2f
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec2f_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec2f_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec2f_new3([In] Vec2fElem[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec2f_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec2f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_Vec2f_delete(IntPtr vector);
        #endregion
        #region cv::Vec3f
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec3f_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec3f_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec3f_new3([In] Vec3fElem[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec3f_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec3f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_Vec3f_delete(IntPtr vector);
        #endregion
        #region cv::Vec4i
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec4i_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec4i_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec4i_new3([In] Vec4iElem[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec4i_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Vec4i_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_Vec4i_delete(IntPtr vector);
        #endregion
        #region cv::Point
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Point_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Point_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Point_new3([In] CvPoint[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Point_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Point_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_Point_delete(IntPtr vector);
        #endregion
        #region cv::Rect
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Rect_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Rect_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Rect_new3([In] CvRect[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Rect_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_Rect_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_Rect_delete(IntPtr vector);
        #endregion
        #region cv::KeyPoint
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_KeyPoint_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_KeyPoint_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_KeyPoint_new3([In]KeyPoint[] data, IntPtr dataLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_KeyPoint_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_KeyPoint_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_KeyPoint_delete(IntPtr vector);
        #endregion
        #endregion
        #endregion
    }
}