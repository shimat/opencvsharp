/*
 * (C) 2008-2013 Schima
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

using CvLabel = System.UInt32;
using CvID = System.UInt32;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static class CppInvoke
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
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_Canny(IntPtr image, IntPtr edges, double threshold1, double threshold2, [MarshalAs(UnmanagedType.I4)] ApertureSize apertureSize, [MarshalAs(UnmanagedType.Bool)] bool L2gradient);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_convertMaps(IntPtr map1, IntPtr map2, IntPtr dstmap1, IntPtr dstmap2, [MarshalAs(UnmanagedType.I4)]  MatrixType dstmap1type, [MarshalAs(UnmanagedType.Bool)] bool nninterpolation);
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
        public static extern void cv_solvePnP(IntPtr objectPoints, IntPtr imagePoints, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvec, IntPtr tvec, bool useExtrinsicGuess);

        #endregion
        #region highgui
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winname, [MarshalAs(UnmanagedType.I4)] WindowMode flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_imshow([MarshalAs(UnmanagedType.LPStr)] string winname, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_imread(string filename, [MarshalAs(UnmanagedType.I4)] LoadMode flags, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cv_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int params_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_imdecode(IntPtr buf, [MarshalAs(UnmanagedType.I4)] LoadMode flags, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cv_imencode([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int params_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_waitKey(int delay);
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
        #region std::vector<T>
        #region uchar
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_uchar_new3([In] byte[] data, IntPtr data_length);
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
        public static extern IntPtr vector_float_new3([In] float[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_float_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_float_delete(IntPtr vector);
        #endregion
        #region cv::Vec2f
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec2f_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec2f_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec2f_new3([In] Vec2fElem[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec2f_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec2f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_cvVec2f_delete(IntPtr vector);
        #endregion
        #region cv::Vec3f
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec3f_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec3f_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec3f_new3([In] Vec3fElem[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec3f_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec3f_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_cvVec3f_delete(IntPtr vector);
        #endregion
        #region cv::Vec4i
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec4i_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec4i_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec4i_new3([In] Vec4iElem[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec4i_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvVec4i_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_cvVec4i_delete(IntPtr vector);
        #endregion
        #region cv::Point
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvPoint_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvPoint_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvPoint_new3([In] CvPoint[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvPoint_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvPoint_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_cvPoint_delete(IntPtr vector);
        #endregion
        #region cv::Rect
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvRect_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvRect_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvRect_new3([In] CvRect[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvRect_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvRect_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_cvRect_delete(IntPtr vector);
        #endregion
        #region cv::KeyPoint
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvKeyPoint_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvKeyPoint_new2(IntPtr size);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvKeyPoint_new3([In]KeyPoint[] data, IntPtr data_length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvKeyPoint_getSize(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vector_cvKeyPoint_getPointer(IntPtr vector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void vector_cvKeyPoint_delete(IntPtr vector);
        #endregion
        #endregion
        #endregion
    }
}