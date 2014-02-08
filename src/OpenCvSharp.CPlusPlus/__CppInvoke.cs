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
using OpenCvSharp.CPlusPlus.Prototype;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [Obsolete]
    public static class __CppInvoke
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
        static __CppInvoke()
        {
            // call cv to enable redirecting
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
            if (_tried)
                return;
            _tried = true;

            // call cv to enable redirecting 
            Cv.GetTickCount();
            try
            {
                Mat_sizeof();
            }
            catch (DllNotFoundException e)
            {
                PInvokeHelper.DllImportError(e);
            }
            catch (BadImageFormatException e)
            {
                PInvokeHelper.DllImportError(e);
            }
            /*catch (Exception e)
            {
                throw;
            }*/
        }
        private static bool _tried = false;
        #endregion

        #region DllImport
        #region cv

        #region StereoSGBM
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr StereoSGBM_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr StereoSGBM_new2(int minDisparity, int numDisparities, int SADWindowSize, int P1, int P2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, [MarshalAs(UnmanagedType.Bool)] bool fullDP);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_exec(IntPtr obj, IntPtr left, IntPtr right, IntPtr disp);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_minDisparity_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_minDisparity_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_numberOfDisparities_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_numberOfDisparities_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_SADWindowSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_SADWindowSize_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_preFilterCap_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_preFilterCap_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_uniquenessRatio_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_uniquenessRatio_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_P1_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_P1_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_P2_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_P2_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_speckleWindowSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_speckleWindowSize_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_speckleRange_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_speckleRange_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_disp12MaxDiff_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_disp12MaxDiff_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoSGBM_fullDP_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoSGBM_fullDP_set(IntPtr obj, int value);
        #endregion
        #endregion
        #region core
        #region Algorithm

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv_Algorithm_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_name(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_Algorithm_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_Algorithm_getInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cv_Algorithm_getDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cv_Algorithm_getBool(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_getString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_getMat(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr outMat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_getMatVector(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr outVec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv_Algorithm_getAlgorithm(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setBool(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setMat(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setMatVector(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Algorithm_setAlgorithm(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        #endregion
        #region Mat
        #region Init & Disposal
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mat_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new2(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new3(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new4(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, IntPtr data, uint step);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new5(IntPtr m, CvSlice rowRange, CvSlice colRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new6(IntPtr m, CvRect roi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new7(IntPtr m, [MarshalAs(UnmanagedType.Bool)] bool copyData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new8(IntPtr img, [MarshalAs(UnmanagedType.Bool)] bool copyData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_new9(IntPtr vec, int vecSize, int depthType, int elemSize, [MarshalAs(UnmanagedType.Bool)] bool copyData);
        #endregion
        #region Fields
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mat_flags(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mat_rows(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mat_cols(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint Mat_step(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_data(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_refcount(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_datastart(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mat_dataend(IntPtr obj);
        #endregion
        #region Operators
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opUnaryMinus(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opBinaryPlus1(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opBinaryPlus2(IntPtr src1, CvScalar src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opBinaryMinus1(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opBinaryMinus2(IntPtr src1, CvScalar src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opBinaryMultiply(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opBinaryDivide(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opRange1(IntPtr src, CvRect roi, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opRange2(IntPtr src, CvSlice rowRange, CvSlice colRange, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opCvMat(IntPtr obj, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_opIplImage(IntPtr obj, IntPtr value);
        #endregion
        #region Methods
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_row(IntPtr obj, int y, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_col(IntPtr obj, int x, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_rowRange(IntPtr obj, int startrow, int endrow, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_colRange(IntPtr obj, int startcol, int endcol, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_diag1(IntPtr obj, [MarshalAs(UnmanagedType.I4)]  MatDiagType d, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_diag2(IntPtr d, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_clone(IntPtr obj, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_copyTo1(IntPtr obj, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_copyTo2(IntPtr obj, IntPtr m, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_convertTo(IntPtr obj, IntPtr m, [MarshalAs(UnmanagedType.I4)] MatrixType rtype, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_assignTo(IntPtr obj, IntPtr m, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_setTo(IntPtr obj, IntPtr value, IntPtr mask, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_reshape(IntPtr obj, int cn, int rows, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_cross(IntPtr obj, IntPtr m, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mat_dot(IntPtr obj, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_zeros(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_ones(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_eye(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_create(IntPtr obj, int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_locateROI(IntPtr obj, out CvSize wholeSize, out CvPoint ofs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_adjustROI(IntPtr obj, int dtop, int dbottom, int dleft, int dright, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_t(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mat_inv(IntPtr src, [MarshalAs(UnmanagedType.I4)] InvertMethod method, IntPtr dst);
        #endregion
        #endregion
        #region MatND
        #region Init & Disposal
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MatND_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MatND_delete(IntPtr obj);
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
        public static extern void MatND_reshape(IntPtr src, int _newcn, int _newndims, [MarshalAs(UnmanagedType.LPArray)] int[] _newsz, IntPtr dst);
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

        #endregion
        
        #region cvaux
        #region CvCamShiftTracker
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvCamShiftTracker_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvCamShiftTracker_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_get_orientation(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_get_length(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_get_width(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint2D32f CvCamShiftTracker_get_center(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect CvCamShiftTracker_get_window(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_threshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_hist_dims(IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] int[] dims);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_min_ch_val(IntPtr obj, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvCamShiftTracker_get_max_ch_val(IntPtr obj, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_window(IntPtr obj, CvRect window);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_threshold(IntPtr obj, int threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_hist_bin_range(IntPtr obj, int dim, int min_val, int max_val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_hist_dims(IntPtr obj, int c_dims, [MarshalAs(UnmanagedType.LPArray)] int[] dims);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_min_ch_val(IntPtr obj, int channel, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_set_max_ch_val(IntPtr obj, int channel, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_track_object(IntPtr obj, IntPtr cur_frame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvCamShiftTracker_update_histogram(IntPtr obj, IntPtr cur_frame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvCamShiftTracker_reset_histogram(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvCamShiftTracker_get_back_project(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvCamShiftTracker_query(IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] int[] bin);
        #endregion
        #region CvAdaptiveSkinDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvAdaptiveSkinDetector_new(int samplingDivider, [MarshalAs(UnmanagedType.I4)] MorphingMethod morphingMethod);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvAdaptiveSkinDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvAdaptiveSkinDetector_process(IntPtr obj, IntPtr inputBGRImage, IntPtr outputHueMask);
        #endregion
        #region HOGDescriptor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new2(CvSize winSize, CvSize blockSize, CvSize blockStride, CvSize cellSize,
            int nbins, int derivAperture, double winSigma, [MarshalAs(UnmanagedType.I4)] HistogramNormType histogramNormType,
            double L2HysThreshold, bool gammaCorrection, int nlevels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new3([MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_getDescriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HOGDescriptor_checkDetectorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_getWinSigma(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_setSVMDetector(IntPtr obj, IntPtr svmdetector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HOGDescriptor_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_compute(IntPtr obj, IntPtr img, IntPtr descriptors,
                         CvSize winStride, CvSize padding, [In] CvPoint[] locations, int locations_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_detect(IntPtr obj, IntPtr img, IntPtr foundLocations,
                        double hitThreshold, CvSize winStride, CvSize padding, [In] CvPoint[] searchLocations, int searchLocationsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_detectMultiScale(IntPtr obj, IntPtr img, IntPtr foundLocations,
                                  double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_computeGradient(IntPtr obj, IntPtr img, IntPtr grad, IntPtr angleOfs, CvSize paddingTL, CvSize paddingBR);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_winSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_blockSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_blockStride_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_cellSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_nbins_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_derivAperture_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_winSigma_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_histogramNormType_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_L2HysThreshold_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_gammaCorrection_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_nlevels_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_winSize_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_blockSize_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_blockStride_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_cellSize_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_nbins_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_derivAperture_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_winSigma_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_histogramNormType_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_L2HysThreshold_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_gammaCorrection_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_nlevels_set(IntPtr obj, int value);
        #endregion
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_FAST(IntPtr image, IntPtr keypoints, int threshold, [MarshalAs(UnmanagedType.Bool)] bool nonmax_supression);
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
        public static extern void BackgroundSubtractor_getBackgroundImage(IntPtr obj, IntPtr backgroundImage);
        #endregion
        #region BackgroundSubtractorMOG
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BackgroundSubtractorMOG_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG_new2(int history, int nmixtures, double backgroundRatio, double noiseSigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_operator(IntPtr obj, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_initialize(IntPtr obj, CvSize frameSize, int frameType);
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize BackgroundSubtractorMOG_frameSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG_frameSize_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_frameType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG_bgmodel(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_nframes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_history(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG_nmixtures(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* BackgroundSubtractorMOG_varThreshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* BackgroundSubtractorMOG_backgroundRatio(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* BackgroundSubtractorMOG_noiseSigma(IntPtr obj);
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
        public static extern void BackgroundSubtractorMOG2_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_operator(IntPtr obj, IntPtr image, IntPtr fgmask, double learningRate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_getBackgroundImage(IntPtr obj, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_initialize(IntPtr obj, CvSize frameSize, int frameType);
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize BackgroundSubtractorMOG2_frameSize_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundSubtractorMOG2_frameSize_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_frameType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG2_bgmodel(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BackgroundSubtractorMOG2_bgmodelUsedModes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_nframes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_history(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* BackgroundSubtractorMOG2_nmixtures(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_varThreshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_backgroundRatio(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_varThresholdGen(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fVarInit(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fVarMin(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fVarMax(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fCT(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool* BackgroundSubtractorMOG2_bShadowDetection(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* BackgroundSubtractorMOG2_nShadowDetection(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* BackgroundSubtractorMOG2_fTau(IntPtr obj);
        //*/
        #endregion
        #endregion
        #endregion
    }
}