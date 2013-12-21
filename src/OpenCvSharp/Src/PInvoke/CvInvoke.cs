/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Security;
using System.Security.Permissions;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// DllImportによるOpenCVの関数をまとめたクラス
    /// </summary>
#else
    /// <summary>
    /// OpenCV functions that declared by DllImport
    /// </summary>
#endif
#if SUPPRESS_SECURITY
    [SuppressUnmanagedCodeSecurity]
#endif
    public static class CvInvoke
    {
        #region Fields
        /// <summary>
        /// cvLoadが一度でも呼ばれたかどうか
        /// </summary>
        private static bool _cvLoadCalled;
        /// <summary>
        /// Qtが有効かどうか
        /// </summary>
        private static bool? _hasQt;
        #endregion

        #region DLL File Name
        public const string DllCalib3d = "opencv_calib3d245";
        public const string DllCore = "opencv_core245";
        public const string DllFeatures2d = "opencv_features2d245";
        public const string DllHighgui = "opencv_highgui245";
        public const string DllImgproc = "opencv_imgproc245";
        public const string DllLegacy = "opencv_legacy245";    
        public const string DllObjdetect = "opencv_objdetect245";
        public const string DllPhoto = "opencv_photo245";
        public const string DllVideo = "opencv_video245";
        #endregion

        #region Static constructor
        /// <summary>
        /// このクラスを最初に参照した時に1度だけ Unmanaged権限チェックを行う
        /// </summary>
#if SUPPRESS_SECURITY
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
#endif
        static CvInvoke()
        {
            _cvLoadCalled = false;            

            // PInvokeできるかチェック            
            PInvokeHelper.TryPInvoke();

            // Qtが有効かチェック
            //_hasQt = HasQt();

            // エラーをリダイレクト
            IntPtr zero = IntPtr.Zero;
            IntPtr current = cvRedirectError(ErrorHandlerThrowException, zero, ref zero);
            if (current != IntPtr.Zero)
            {
                ErrorHandlerDefault = (CvErrorCallback)Marshal.GetDelegateForFunctionPointer(
                    current,
                    typeof(CvErrorCallback)
                );
            }
            else
            {
                ErrorHandlerDefault = null;
            }
        }

#if LANG_JP
        /// <summary>
        /// Qtを有効にしてビルドされたhighguiライブラリであればtrueを返す
        /// </summary>
#else
        /// <summary>
        /// Returns true if the library is compiled with Qt
        /// </summary>
#endif
        public static bool HasQt
        {
            get
            {
                if (!_hasQt.HasValue)
                {
                    // 乱暴だけど、cvFontQtを呼んでみて、呼べなかったらエントリポイントがないのだろうと推定
                    try
                    {
                        cvFontQt_("", -1, CvColor.Black, FontWeight.Normal, FontStyle.Normal, 0);
                    }
                    catch
                    {
                        _hasQt = false;
                        return false;
                    }
                    _hasQt = true;
                }
                return _hasQt.Value;
            }
            private set
            {
                _hasQt = value;
            }
        }
        /// <summary>
        /// Qtが有効かチェックし、無効であれば例外を投げる
        /// </summary>
        private static void CheckQt()
        {
            if (!HasQt)
                throw new OpenCvSharpException("The library is compiled without Qt support");
        }
        #endregion

        #region Error redirection
#if LANG_JP
        /// <summary>
        /// エラーをリダイレクトする際に呼ばれるエラーハンドラ
        /// </summary>
#else
        /// <summary>
        /// Custom error handler to be thrown by OpenCV
        /// </summary>
#endif
        public static readonly CvErrorCallback ErrorHandlerThrowException =
            delegate(CvStatus status, string func_name, string err_msg, string file_name, int line, IntPtr userdata)
            {
                try
                {
                    cvSetErrStatus(CvStatus.StsOk);
                    return 0;
                }
                finally
                {
                    
                    throw new OpenCVException(status, func_name, err_msg, file_name, line);
                }
            };
#if LANG_JP
        /// <summary>
        /// エラーを無視する際に呼ばれるエラーハンドラ
        /// </summary>
#else
        /// <summary>
        /// Custom error handler to ignore all OpenCV errors
        /// </summary>
#endif
        public static readonly CvErrorCallback ErrorHandlerIgnorance =
            delegate(CvStatus status, string func_name, string err_msg, string file_name, int line, IntPtr userdata)
            {
                cvSetErrStatus(CvStatus.StsOk);
                return 0;
            };
#if LANG_JP
        /// <summary>
        /// OpenCV既定ののエラーハンドラ
        /// </summary>
#else
        /// <summary>
        /// Default error handler
        /// </summary>
#endif
        public static CvErrorCallback ErrorHandlerDefault;
        #endregion

        #region DllImport
        #region Imgproc
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv2DRotationMatrix(CvPoint2D32f center, double angle, double scale, IntPtr map_matrix);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAcc(IntPtr image, IntPtr sum, IntPtr mask);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAdaptiveThreshold(IntPtr src, IntPtr dst, double max_value, AdaptiveThresholdType adaptiveType,
            ThresholdType threshold_type, int block_size, double param1);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvApproxChains(IntPtr src_seq, IntPtr storage, [MarshalAs(UnmanagedType.U4)] ContourChain method,
            double parameter, int minimal_perimeter, [MarshalAs(UnmanagedType.Bool)] bool recursive);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvApproxPoly(IntPtr src_seq, int header_size, IntPtr storage, ApproxPolyMethod method, double parameter,
            [MarshalAs(UnmanagedType.Bool)] bool parameter2);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvArcLength(IntPtr curve, CvSlice slice, int is_closed);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect cvBoundingRect(IntPtr points, [MarshalAs(UnmanagedType.Bool)] bool update);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvBoxPoints(CvBox2D box, [Out] CvPoint2D32f[] pt);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcArrHist(IntPtr[] image, IntPtr hist, [MarshalAs(UnmanagedType.Bool)] bool accumulate, IntPtr mask);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcArrBackProject(IntPtr[] image, IntPtr back_project, IntPtr hist);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcArrBackProjectPatch(IntPtr[] image, IntPtr dst, CvSize patch_size, IntPtr hist, int method, float factor);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcBayesianProb(IntPtr[] src, int number, IntPtr[] dst);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern float cvCalcEMD2(IntPtr signature1, IntPtr signature2, DistanceType distance_type, [MarshalAs(UnmanagedType.FunctionPtr)] CvDistanceFunction distance_func,
            IntPtr cost_matrix, IntPtr flow, ref float lower_bound, [MarshalAs(UnmanagedType.AsAny)] object userdata);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern float cvCalcEMD2(IntPtr signature1, IntPtr signature2, DistanceType distance_type, IntPtr distance_func,
            IntPtr cost_matrix, IntPtr flow, ref float lower_bound, [MarshalAs(UnmanagedType.AsAny)] object userdata);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcProbDensity(IntPtr hist1, IntPtr hist2, IntPtr dst_hist, double scale);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCanny(IntPtr image, IntPtr edges, double threshold1, double threshold2, [MarshalAs(UnmanagedType.U4)] ApertureSize aperture_size);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cvCheckContourConvexity(IntPtr contour);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearHist(IntPtr hist);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvCompareHist(IntPtr hist1, IntPtr hist2, HistogramComparison method);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvContourArea(IntPtr contour, CvSlice slice);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertMaps(IntPtr mapx, IntPtr mapy, IntPtr mapxy, IntPtr mapalpha);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvConvexHull2(IntPtr input, IntPtr hull_storage, [MarshalAs(UnmanagedType.I4)] ConvexHullOrientation orientation, int return_points);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvConvexityDefects(IntPtr contour, IntPtr convexhull, IntPtr storage);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCopyHist(IntPtr src, ref IntPtr dst);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCopyMakeBorder(IntPtr src, IntPtr dst, CvPoint offset, BorderType bordertype, CvScalar value);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCornerEigenValsAndVecs(IntPtr image, IntPtr eigenvv, int block_size, ApertureSize aperture_size);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCornerHarris(IntPtr image, IntPtr harris_responce, int block_size, ApertureSize aperture_size, double k);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCornerMinEigenVal(IntPtr image, IntPtr eigenval, int block_size, ApertureSize aperture_size);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateFeatureTree(IntPtr desc);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateHist(int dims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, HistogramFormat type,
            IntPtr[] ranges, [MarshalAs(UnmanagedType.Bool)] bool uniform);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateHist(int dims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, HistogramFormat type,
            IntPtr ranges, [MarshalAs(UnmanagedType.Bool)] bool uniform);

        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreatePyramid(IntPtr img, int extra_layers, double rate, [In] CvSize[] layer_sizes,
            IntPtr bufarr, [MarshalAs(UnmanagedType.Bool)] bool calc, CvFilter filter);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateStructuringElementEx(int cols, int rows, int anchorX, int anchorY, ElementShape shape, int[,] values);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCvtColor(IntPtr src, IntPtr dst, ColorConversion code);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDilate(IntPtr src, IntPtr dst, IntPtr element, int iterations);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDistTransform(IntPtr src, IntPtr dst, DistanceType distanceType, int mask_size, float[] mask, IntPtr labels, [MarshalAs(UnmanagedType.I4)] DistTransformLabelType labelType);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvEndFindContours(ref IntPtr scanner);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEqualizeHist(IntPtr src, IntPtr dst);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvErode(IntPtr src, IntPtr dst, IntPtr element, int iterations);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFilter2D(IntPtr src, IntPtr dst, IntPtr kernel, CvPoint anchor);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindContours(IntPtr image, IntPtr storage, ref IntPtr first_contour, int header_size,
            [MarshalAs(UnmanagedType.U4)] ContourRetrieval mode, [MarshalAs(UnmanagedType.I4)] ContourChain method, CvPoint offset);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindCornerSubPix(IntPtr image, [In, Out]CvPoint2D32f[] corners, int count, CvSize win, CvSize zero_zone, CvTermCriteria criteria);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindCornerSubPix(IntPtr image, IntPtr[] corners, int count, CvSize win, CvSize zero_zone, CvTermCriteria criteria);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindNextContour(IntPtr scanner);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D cvFitEllipse2(IntPtr points);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void cvFitLine(IntPtr points, [MarshalAs(UnmanagedType.I4)] DistanceType dist_type, double param, double reps, double aeps, [In, Out] float[] line);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFloodFill(IntPtr image, CvPoint seed_point, CvScalar new_val, CvScalar lo_diff, CvScalar up_diff, IntPtr comp, int flags, IntPtr mask);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetAffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, IntPtr map_matrix);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetCentralMoment([In, Out] CvMoments moments, int x_order, int y_order);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetHuMoments([In] CvMoments moments, [In, Out] CvHuMoments hu_moments);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetMinMaxHistValue(IntPtr hist, ref float min_value, ref float max_value, int[] min_idx, int[] max_idx);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetNormalizedCentralMoment([In] CvMoments moments, int x_order, int y_order);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, IntPtr map_matrix);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetQuadrangleSubPix(IntPtr src, IntPtr dst, IntPtr map_matrix);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetRectSubPix(IntPtr src, IntPtr dst, CvPoint2D32f center);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetSpatialMoment([In] CvMoments moments, int x_order, int y_order);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGoodFeaturesToTrack(IntPtr image, IntPtr eig_image, IntPtr temp_image, IntPtr corners, ref int corner_count,
            double quality_level, double min_distance, IntPtr mask, int block_size, [MarshalAs(UnmanagedType.Bool)] bool use_harris, double k);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGoodFeaturesToTrack(IntPtr image, IntPtr eig_image, IntPtr temp_image, [Out] CvPoint2D32f[] corners,
            ref int corner_count, double quality_level, double min_distance, IntPtr mask, int block_size, [MarshalAs(UnmanagedType.Bool)] bool use_harris, double k);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvHoughLines2(IntPtr image, IntPtr line_storage, HoughLinesMethod method, double rho, double theta,
            int threshold, double param1, double param2);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvHoughCircles(IntPtr image, IntPtr circle_storage, HoughCirclesMethod method, double dp, double min_dist,
            double param1, double param2, int min_radius, int max_radius);

        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitUndistortMap(IntPtr intrinsic_matrix, IntPtr distortion_coeffs, IntPtr mapx, IntPtr mapy);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitUndistortRectifyMap(IntPtr camera_matrix, IntPtr dist_coeffs, IntPtr R, IntPtr new_camera_matrix, IntPtr mapx, IntPtr mapy);
        [DllImport(DllPhoto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInpaint(IntPtr src, IntPtr mask, IntPtr dst, double inpaintRadius, InpaintMethod flags);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvIntegral(IntPtr image, IntPtr sum, IntPtr sqsum, IntPtr tilted_sum);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLaplace(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.U4)] ApertureSize aperture_size);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLinearPolar(IntPtr src, IntPtr dst, CvPoint2D32f center, double maxRadius, [MarshalAs(UnmanagedType.I4)] Interpolation flags);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLogPolar(IntPtr src, IntPtr dst, CvPoint2D32f center, double M, Interpolation flags);

        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvMakeHistHeaderForArray(int dims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, IntPtr hist,
            [MarshalAs(UnmanagedType.LPArray)] float[] data, IntPtr ranges, [MarshalAs(UnmanagedType.Bool)] bool uniform);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvMakeHistHeaderForArray(int dims, [MarshalAs(UnmanagedType.LPArray)] int[] sizes, IntPtr hist,
            [MarshalAs(UnmanagedType.LPArray)] float[] data, IntPtr[] ranges, [MarshalAs(UnmanagedType.Bool)] bool uniform);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvMatchShapes(IntPtr object1, IntPtr object2, [MarshalAs(UnmanagedType.U4)] MatchShapesMethod method, double parameter);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMatchTemplate(IntPtr image, IntPtr templ, IntPtr result, [MarshalAs(UnmanagedType.U4)] MatchTemplateMethod method);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect cvMaxRect(ref CvRect rect1, ref CvRect rect2);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D cvMinAreaRect2(IntPtr points, IntPtr storage);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cvMinEnclosingCircle(IntPtr points, ref CvPoint2D32f center, ref float radius);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMoments(IntPtr image, [In, Out] CvMoments moments, [MarshalAs(UnmanagedType.Bool)] bool isBinary);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMorphologyEx(IntPtr src, IntPtr dst, IntPtr temp, IntPtr element, MorphologyOperation operation, int iterations);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMultiplyAcc(IntPtr image1, IntPtr image2, IntPtr acc, IntPtr mask);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvNormalizeHist(IntPtr hist, double factor);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvPointPolygonTest(IntPtr contour, CvPoint2D32f pt, int measure_dist);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPointSeqFromMat([MarshalAs(UnmanagedType.I4)] SeqType seq_kind, IntPtr mat, IntPtr contour_header, IntPtr block);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPreCornerDetect(IntPtr image, IntPtr corners, [MarshalAs(UnmanagedType.U4)] ApertureSize aperture_size);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrDown(IntPtr src, IntPtr dst, CvFilter filter);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrMeanShiftFiltering(IntPtr src, IntPtr dst, double sp, double sr, int max_level, CvTermCriteria termcrit);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrUp(IntPtr src, IntPtr dst, CvFilter filter);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint cvReadChainPoint(IntPtr reader);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseHist(ref IntPtr hist);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleasePyramid(ref IntPtr pyramid, int extra_layers);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseStructuringElement(ref IntPtr element);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRemap(IntPtr src, IntPtr dst, IntPtr mapx, IntPtr mapy, [MarshalAs(UnmanagedType.U4)] Interpolation flags, CvScalar fillval);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRepeat(IntPtr src, IntPtr dst);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvResize(IntPtr src, IntPtr dst, Interpolation interpolation);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRunningAvg(IntPtr image, IntPtr acc, double alpha, IntPtr mask);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSampleLine(IntPtr image, CvPoint pt1, CvPoint pt2, IntPtr buffer, int connectivity);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetHistBinRanges(IntPtr hist, IntPtr[] ranges, [MarshalAs(UnmanagedType.Bool)] bool uniform);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSmooth(IntPtr src, IntPtr dst, SmoothType type, int param1, int param2, double param3, double param4);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSobel(IntPtr src, IntPtr dst, int xorder, int yorder, [MarshalAs(UnmanagedType.U4)] ApertureSize aperture_size);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSquareAcc(IntPtr image, IntPtr sqsum, IntPtr mask);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvStartFindContours(IntPtr image, IntPtr storage, int header_size, [MarshalAs(UnmanagedType.U4)] ContourRetrieval mode,
            [MarshalAs(UnmanagedType.U4)] ContourChain method, CvPoint offset);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartReadChainPoints(IntPtr chain, IntPtr reader);

        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSubstituteContour(IntPtr scanner, IntPtr new_contour);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvThreshHist(IntPtr hist, double threshold);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvThreshold(IntPtr src, IntPtr dst, double threshold, double maxValue, [MarshalAs(UnmanagedType.U4)] ThresholdType thresholdType);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUndistort2(IntPtr src, IntPtr dst, IntPtr intrinsic_matrix, IntPtr distortion_coeffs, IntPtr new_camera_matrix);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUndistortPoints(IntPtr src, IntPtr dst, IntPtr camera_matrix, IntPtr dist_coeffs, IntPtr R, IntPtr P);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWarpAffine(IntPtr src, IntPtr dst, IntPtr map_matrix, [MarshalAs(UnmanagedType.U4)] Interpolation flags, CvScalar fillval);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWarpPerspective(IntPtr src, IntPtr dst, IntPtr map_matrix, Interpolation flags, CvScalar fillval);
        [DllImport(DllImgproc, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWatershed(IntPtr image, IntPtr markers);
        #endregion
        #region Core
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAbsDiff(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAbsDiffS(IntPtr src, IntPtr dst, CvScalar value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAdd(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAddS(IntPtr src, CvScalar value, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAddWeighted(IntPtr src1, double alpha, IntPtr src2, double beta, double gamma, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvAlloc(uint size);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAnd(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAndS(IntPtr src, CvScalar value, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvAvg(IntPtr arr, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAvgSdv(IntPtr arr, ref CvScalar mean, ref CvScalar std_dev, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvBackProjectPCA(IntPtr proj, IntPtr avg, IntPtr eigenvects, IntPtr result);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcCovarMatrix(IntPtr[] vects, int count, IntPtr covMat, IntPtr avg, CovarMatrixFlag flags);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcPCA(IntPtr proj, IntPtr avg, IntPtr eigenvalues, IntPtr eigenvects, PCAFlag flag);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCartToPolar(IntPtr x, IntPtr y, IntPtr magnitude, IntPtr angle, [MarshalAs(UnmanagedType.I4)] AngleUnit angle_in_degrees);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern float cvCbrt(float value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvChangeSeqBlock(IntPtr reader, int direction);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCheckArr(IntPtr arr, CheckArrFlag flags, double min_val, double max_val);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cvCheckHardwareSupport([MarshalAs(UnmanagedType.I4)] HardwareSupport feature);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvTermCriteria cvCheckTermCriteria(CvTermCriteria criteria, double default_eps, int default_max_iters);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCircle(IntPtr img, CvPoint center, int radius, CvScalar color, int thickness, [MarshalAs(UnmanagedType.U4)] LineType line_type, int shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearGraph(IntPtr graph);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearMemStorage(IntPtr storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearND(IntPtr arr, int[] idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearSeq(IntPtr seq);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearSet(IntPtr set_header);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvClipLine(CvSize img_size, ref CvPoint pt1, ref CvPoint pt2);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvClone(IntPtr struct_ptr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCloneGraph(IntPtr graph, IntPtr storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCloneImage(IntPtr image);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCloneMat(IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCloneMatND(IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCloneSparseMat(IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCmp(IntPtr src1, IntPtr src2, IntPtr dst, ArrComparison cmp_op);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCmpS(IntPtr src, double value, IntPtr dst, ArrComparison cmp_op);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCompleteSymm(IntPtr matrix, [MarshalAs(UnmanagedType.Bool)] bool LtoR);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertScale(IntPtr src, IntPtr dst, double scale, double shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertScaleAbs(IntPtr src, IntPtr dst, double scale, double shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCopy(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCountNonZero(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateChildMemStorage(IntPtr parent);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCreateData(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateGraph([MarshalAs(UnmanagedType.I4)] SeqType graph_flags, int header_size, int vtx_size, int edge_size, IntPtr storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateGraphScanner(IntPtr graph, IntPtr vtx, [MarshalAs(UnmanagedType.I4)] GraphScannerMask mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateImage(CvSize size, BitDepth depth, int channels);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateImageHeader(CvSize size, BitDepth depth, int channels);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateMat(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateMatHeader(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateMatND(int dims, int[] sizes, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateMatNDHeader(int dims, int[] sizes, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateMemStorage(int block_size);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateSeq(SeqType seq_flags, int header_size, int elem_size, IntPtr storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCreateSeqBlock(IntPtr writer);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateSet(SeqType set_flags, int header_size, int elem_size, IntPtr storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateSparseMat(int dims, [In] int[] sizes, MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCrossProduct(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCvtSeqToArray(IntPtr seq, IntPtr elements, CvSlice slice);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvDet(IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDCT(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.U4)] DCTFlag flags);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDFT(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.U4)] DFTFlag flags, int nonzero_rows);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDiv(IntPtr src1, IntPtr src2, IntPtr dst, double scale);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvDotProduct(IntPtr src1, IntPtr src2);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDrawContours(IntPtr img, IntPtr contour, CvScalar external_color, CvScalar hole_color, int maxLevel, int thickness,
            [MarshalAs(UnmanagedType.U4)] LineType line_type, CvPoint offset);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEigenVV(IntPtr mat, IntPtr evects, IntPtr evals, double eps, int lowindex, int highindex);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEllipse(IntPtr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color,
            int thickness, [MarshalAs(UnmanagedType.U4)] LineType line_type, int shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvEllipse2Poly(CvPoint center, CvSize axes, int angle, int arc_start, int arc_end, [In, Out] CvPoint[] pts, int delta);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvEndWriteSeq(IntPtr writer);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEndWriteStruct(IntPtr fs);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvError([MarshalAs(UnmanagedType.I4)] CvStatus status, [MarshalAs(UnmanagedType.LPStr)] string func_name,
            [MarshalAs(UnmanagedType.LPStr)] string err_msg, [MarshalAs(UnmanagedType.LPStr)] string file_name, int line);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string cvErrorStr([MarshalAs(UnmanagedType.I4)] CvStatus status);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvExp(IntPtr src, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern float cvFastArctan(float y, float x);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFillConvexPoly(IntPtr img, [In] CvPoint[] pts, int npts, CvScalar color, [MarshalAs(UnmanagedType.U4)] LineType lineType, int shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFillPoly(IntPtr img, [In] IntPtr[] pts, [In] int[] npts, int contours, CvScalar color,
            [MarshalAs(UnmanagedType.U4)] LineType line_type, int shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindGraphEdge(IntPtr graph, int start_idx, int end_idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindGraphEdgeByPtr(IntPtr graph, IntPtr start_vtx, IntPtr end_vtx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindType([MarshalAs(UnmanagedType.LPStr)] string type_name);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFirstType();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFlip(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.U4)] FlipMode flipMode);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFlushSeqWriter(IntPtr writer);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFree_(IntPtr ptr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGEMM(IntPtr src1, IntPtr src2, double alpha, IntPtr src3, double beta, IntPtr dst, [MarshalAs(UnmanagedType.U4)] GemmOperation tABC);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvGet1D(IntPtr arr, int idx0);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvGet2D(IntPtr arr, int idx0, int idx1);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvGet3D(IntPtr arr, int idx0, int idx1, int idx2);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvGetND(IntPtr arr, [MarshalAs(UnmanagedType.LPArray)] int[] idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetCols(IntPtr arr, IntPtr submat, int start_col, int end_col);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetDiag(IntPtr arr, IntPtr submat, DiagType diag);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetDims(IntPtr arr, IntPtr sizes);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetDimSize(IntPtr arr, int index);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetElemType(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern ErrMode cvGetErrMode();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern CvStatus cvGetErrStatus();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetFileNode(IntPtr fs, IntPtr map, IntPtr key, [MarshalAs(UnmanagedType.Bool)] bool create_missing);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetFileNodeByName(IntPtr fs, IntPtr map, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string cvGetFileNodeName(IntPtr node);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetGraphVtx(IntPtr graph, int vtx_idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetHashedKey(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, int len, [MarshalAs(UnmanagedType.Bool)] bool create_missing);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetImage(IntPtr arr, IntPtr image_header);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetImageCOI(IntPtr image);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect cvGetImageROI(IntPtr image);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetMat(IntPtr arr, IntPtr header, out int coi, [MarshalAs(UnmanagedType.Bool)] bool allowND);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetModuleInfo([MarshalAs(UnmanagedType.LPStr)] string module_name, ref IntPtr version, ref IntPtr loaded_addon_plugins);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetNumThreads();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetOptimalDFTSize(int size0);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetRawData(IntPtr arr, ref IntPtr data, ref int step, ref CvSize roi_size);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetReal1D(IntPtr arr, int idx0);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetReal2D(IntPtr arr, int idx0, int idx1);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetReal3D(IntPtr arr, int idx0, int idx1, int idx2);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetRealND(IntPtr arr, [MarshalAs(UnmanagedType.LPArray)] int[] idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetRootFileNode(IntPtr fs, int stream_index);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetRows(IntPtr arr, IntPtr submat, int start_row, int end_row, int delta_row);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetSeqElem(IntPtr seq, int index);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetSeqReaderPos(IntPtr reader);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize cvGetSize(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetSubRect(IntPtr arr, IntPtr submat, CvRect rect);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetTextSize([MarshalAs(UnmanagedType.LPStr)] string text_string, IntPtr font, out CvSize text_size, out int baseline);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetThreadNum();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int64 cvGetTickCount();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetTickFrequency();
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphAddEdge(IntPtr graph, int start_idx, int end_idx, IntPtr edge, ref IntPtr inserted_edge);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphAddEdgeByPtr(IntPtr graph, IntPtr start_idx, IntPtr end_idx, IntPtr edge, ref IntPtr inserted_edge);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphAddVtx(IntPtr graph, IntPtr vtx, ref IntPtr inserted_vtx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphEdgeIdx(IntPtr graph, IntPtr edge);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGraphRemoveEdge(IntPtr graph, int start_idx, int end_idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGraphRemoveEdgeByPtr(IntPtr graph, IntPtr start_vtx, IntPtr end_vtx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphRemoveVtx(IntPtr graph, int index);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphRemoveVtxByPtr(IntPtr graph, IntPtr vtx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphVtxDegree(IntPtr graph, int vtx_idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphVtxDegreeByPtr(IntPtr graph, IntPtr vtx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGraphVtxIdx(IntPtr graph, IntPtr vtx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitFont(IntPtr font, FontFace font_face, double hscale, double vscale, double shear, int thickness,
            [MarshalAs(UnmanagedType.U4)] LineType line_type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvInitImageHeader(IntPtr image, CvSize size, BitDepth depth, int channels, ImageOrigin origin, int align);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvInitLineIterator(IntPtr image, CvPoint pt1, CvPoint pt2, IntPtr line_iterator,
            [MarshalAs(UnmanagedType.I4)] PixelConnectivity connectivity, [MarshalAs(UnmanagedType.Bool)] bool left_to_right);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvInitMatHeader(IntPtr mat, int rows, int cols, MatrixType type, IntPtr data, int step);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvInitMatNDHeader(IntPtr mat, int dims, int[] sizes, MatrixType type, IntPtr data);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvInitSparseMatIterator(IntPtr mat, IntPtr mat_iterator);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitTreeNodeIterator([In, Out] CvTreeNodeIterator tree_iterator, IntPtr first, int max_level);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInRange(IntPtr src, IntPtr lower, IntPtr upper, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInRangeS(IntPtr src, CvScalar lower, CvScalar upper, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInsertNodeIntoTree(IntPtr node, IntPtr parent, IntPtr frame);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvInvert(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.U4)] InvertMethod method);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern float cvInvSqrt(float value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvKMeans2(IntPtr samples, int cluster_count, IntPtr labels, CvTermCriteria termcrit,
            int attempts, ref UInt64 rng, [MarshalAs(UnmanagedType.I4)] KMeansFlag flags, IntPtr _centers, out double compactness);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLine(IntPtr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, [MarshalAs(UnmanagedType.I4)] LineType line_type, int shift);
        [DllImport(DllCore, EntryPoint = "cvLoad")]
        private static extern IntPtr cvLoad_([MarshalAs(UnmanagedType.LPStr)] string file_name, IntPtr memstorage,
            [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr real_name);
        [DllImport(DllCore, EntryPoint = "cvLoad")]
        private static extern IntPtr cvLoad_([MarshalAs(UnmanagedType.LPStr)] string file_name, IntPtr memstorage,
            [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] StringBuilder real_name);
        public static IntPtr cvLoad(string fileName, IntPtr memstorage, string name, IntPtr real_name)
        {
            if (!_cvLoadCalled)
            {
                // あらかじめcvを先に呼んでおかなければだめらしい
                IntPtr cascade = IntPtr.Zero;
                cvReleaseHaarClassifierCascade(ref cascade);
                _cvLoadCalled = true;
            }
            return cvLoad_(fileName, memstorage, name, real_name);
        }
        public static IntPtr cvLoad(string fileName, IntPtr memstorage, string name, StringBuilder real_name)
        {
            if (!_cvLoadCalled)
            {
                // あらかじめcvを先に呼んでおかなければだめらしい
                IntPtr cascade = IntPtr.Zero;
                cvReleaseHaarClassifierCascade(ref cascade);
                _cvLoadCalled = true;
            }
            return cvLoad_(fileName, memstorage, name, real_name);
        }
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLog(IntPtr src, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLUT(IntPtr src, IntPtr dst, IntPtr lut);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvMahalanobis(IntPtr vec1, IntPtr vec2, IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvMakeSeqHeaderForArray(SeqType seq_type, int header_size, int elem_size, IntPtr elements, int total, IntPtr seq, IntPtr block);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMax(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMaxS(IntPtr src, double value, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvMemStorageAlloc(IntPtr storage, uint size);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvString cvMemStorageAllocString(IntPtr storage, IntPtr ptr, int len);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe CvString cvMemStorageAllocString(IntPtr storage, char* ptr, int len);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMerge(IntPtr src0, IntPtr src1, IntPtr src2, IntPtr src3, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMin(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMinS(IntPtr src, double value, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMixChannels(IntPtr[] src, int src_count, IntPtr[] dst, int dst_count, int[] from_to, int pair_count);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMinMaxLoc(IntPtr arr, ref double minVal, ref double maxVal, ref CvPoint minLoc, ref CvPoint maxLoc, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMul(IntPtr src1, IntPtr src2, IntPtr dst, double scale);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMulSpectrums(IntPtr src1, IntPtr src2, IntPtr dst, MulSpectrumsFlag flags);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMulTransposed(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.Bool)] bool order, IntPtr delta, double scale);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvNextGraphItem(IntPtr scanner);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvNextTreeNode([In, Out] CvTreeNodeIterator tree_iterator);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvNorm(IntPtr arr1, IntPtr arr2, [MarshalAs(UnmanagedType.U4)] NormType norm_type, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvNormalize(IntPtr src, IntPtr dst, double a, double b, NormType norm_type, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvNot(IntPtr src, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvOpenFileStorage([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr memstorage, [MarshalAs(UnmanagedType.I4)] FileStorageMode flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvOr(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvOrS(IntPtr src, CvScalar value, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPerspectiveTransform(IntPtr src, IntPtr dst, IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPolarToCart(IntPtr magnitude, IntPtr angle, IntPtr x, IntPtr y, [MarshalAs(UnmanagedType.I4)] AngleUnit angle_in_degrees);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPolyLine(IntPtr img, IntPtr[] pts, int[] npts, int contours, [MarshalAs(UnmanagedType.Bool)] bool is_closed, CvScalar color,
            int thickness, [MarshalAs(UnmanagedType.U4)] LineType line_type, int shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPow(IntPtr src, IntPtr dst, double power);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPrevTreeNode([In, Out] CvTreeNodeIterator tree_iterator);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvProjectPCA(IntPtr proj, IntPtr avg, IntPtr eigenvects, IntPtr result);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPtr1D(IntPtr arr, int idx0, [MarshalAs(UnmanagedType.U4)] out MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPtr2D(IntPtr arr, int idx0, int idx1, [MarshalAs(UnmanagedType.U4)] out MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPtr3D(IntPtr arr, int idx0, int idx1, int idx2, [MarshalAs(UnmanagedType.U4)] out MatrixType type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPtrND(IntPtr arr, int[] idx, [MarshalAs(UnmanagedType.U4)] out MatrixType type, [MarshalAs(UnmanagedType.Bool)] bool create_node,
            IntPtr precalc_hashval);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPutText(IntPtr img, [MarshalAs(UnmanagedType.LPStr)] string text, CvPoint org, IntPtr font, CvScalar color);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRandArr(ref UInt64 rng, IntPtr arr, DistributionType dist_type, CvScalar param1, CvScalar param2);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRandShuffle(IntPtr mat, ref UInt64 rng, double iter_factor);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRange(IntPtr mat, double start, double end);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvRead(IntPtr fs, IntPtr node, IntPtr attributes);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReadRawData(IntPtr fs, IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.LPStr)] string dt);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReadRawDataSlice(IntPtr fs, IntPtr reader, int count, IntPtr dst, [MarshalAs(UnmanagedType.LPStr)] string dt);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRectangle(IntPtr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, [MarshalAs(UnmanagedType.U4)] LineType line_type, int shift);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvRedirectError(CvErrorCallback error_handler, IntPtr userdata, ref IntPtr prev_userdata);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvRedirectError(IntPtr error_handler, IntPtr userdata, ref IntPtr prev_userdata);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReduce(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.U4)] ReduceDimension dim, [MarshalAs(UnmanagedType.U4)] ReduceOperation type);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRegisterType(IntPtr info);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRelease(ref IntPtr struct_ptr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseData(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseFileStorage(ref IntPtr fs);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseGraphScanner(ref IntPtr scanner);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseImage(ref IntPtr image);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseImageHeader(ref IntPtr image);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseMat(ref IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseMemStorage(ref IntPtr storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseSparseMat(ref IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRemoveNodeFromTree(IntPtr node, IntPtr frame);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvResetImageROI(IntPtr image);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvReshape(IntPtr arr, IntPtr header, int new_cn, int new_rows);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvReshapeMatND(IntPtr arr, int sizeof_header, IntPtr header, int new_cn, int new_dims, [In] int[] new_sizes);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRestoreMemStoragePos(IntPtr storage, IntPtr pos);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSave([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr struct_ptr,
             [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string comment, CvAttrList attributes);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSaveMemStoragePos(IntPtr storage, IntPtr pos);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvScaleAdd(IntPtr src1, CvScalar scale, IntPtr src2, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSeqElemIdx(IntPtr seq, IntPtr element, ref IntPtr block);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSeqInsert(IntPtr seq, int before_index, IntPtr element);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqInsertSlice(IntPtr seq, int before_index, IntPtr from_arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqInvert(IntPtr seq);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqPop(IntPtr seq, IntPtr element);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqPopFront(IntPtr seq, IntPtr element);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqPopMulti(IntPtr seq, IntPtr elements, int count, InsertPosition in_front);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqRemove(IntPtr seq, int index);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqRemoveSlice(IntPtr seq, CvSlice slice);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSeqPartition(IntPtr seq, IntPtr storage, ref IntPtr labels, CvCmpFunc is_equal, IntPtr userdata);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSeqPartition(IntPtr seq, IntPtr storage, ref IntPtr labels, IntPtr is_equal, IntPtr userdata);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSeqPush(IntPtr seq, IntPtr element);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqPushMulti(IntPtr seq, IntPtr elements, int count, InsertPosition in_front);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSeqPushFront(IntPtr seq, IntPtr element);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSeqSearch(IntPtr seq, IntPtr elem, CvCmpFunc func, [MarshalAs(UnmanagedType.Bool)] bool is_sorted, out int elem_idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSeqSearch(IntPtr seq, IntPtr elem, IntPtr func, [MarshalAs(UnmanagedType.Bool)] bool is_sorted, out int elem_idx);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSeqSlice(IntPtr seq, CvSlice slice, IntPtr storage, [MarshalAs(UnmanagedType.Bool)] bool copy_data);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSeqSort(IntPtr seq, CvCmpFunc func, IntPtr userdata);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSet(IntPtr arr, CvScalar value, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSet1D(IntPtr arr, int idx0, CvScalar value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSet2D(IntPtr arr, int idx0, int idx1, CvScalar value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSet3D(IntPtr arr, int idx0, int idx1, int idx2, CvScalar value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetND(IntPtr arr, int[] idx, CvScalar value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSetAdd(IntPtr set_header, IntPtr elem, ref IntPtr inserted_elem);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetData(IntPtr arr, IntPtr data, int step);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern ErrMode cvSetErrMode(ErrMode mode);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetErrStatus([MarshalAs(UnmanagedType.I4)] CvStatus status);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetIdentity(IntPtr mat, CvScalar value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetImageCOI(IntPtr image, int coi);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetImageROI(IntPtr image, CvRect rect);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetNumThreads(int threads);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetReal1D(IntPtr arr, int idx0, double value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetReal2D(IntPtr arr, int idx0, int idx1, double value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetReal3D(IntPtr arr, int idx0, int idx1, int idx2, double value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetRealND(IntPtr arr, [MarshalAs(UnmanagedType.LPArray)] int[] idx, double value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetRemove(IntPtr set_header, int index);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetSeqBlockSize(IntPtr seq, int delta_elems);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetSeqReaderPos(IntPtr reader, int index, [MarshalAs(UnmanagedType.Bool)] bool is_relative);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetZero(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSliceLength(CvSlice slice, IntPtr seq);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSolve(IntPtr src1, IntPtr src2, IntPtr dst, InvertMethod method);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSolveCubic(IntPtr coeffs, IntPtr roots);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSolvePoly(IntPtr coeffs, IntPtr roots, int maxiter, int fig);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSort(IntPtr src, IntPtr dst, IntPtr idxmat, SortFlag flags);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSplit(IntPtr src, IntPtr dst0, IntPtr dst1, IntPtr dst2, IntPtr dst3);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern float cvSqrt(float value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartAppendToSeq(IntPtr seq, IntPtr writer);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartNextStream(IntPtr fs);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartReadRawData(IntPtr fs, IntPtr src, IntPtr reader);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartReadSeq(IntPtr seq, IntPtr reader, [MarshalAs(UnmanagedType.Bool)] bool reverse);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartWriteSeq(SeqType seq_flags, int header_size, int elem_size, IntPtr storage, IntPtr writer);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStartWriteStruct(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, NodeType struct_flags,
            [MarshalAs(UnmanagedType.LPStr)] string type_name/*, CvAttrList attributes*/);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSub(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSubRS(IntPtr src, CvScalar value, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvSum(IntPtr arr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSVBkSb(IntPtr W, IntPtr U, IntPtr V, IntPtr B, IntPtr X, SVDFlag flags);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSVD(IntPtr A, IntPtr W, IntPtr U, IntPtr V, SVDFlag flags);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvTrace(IntPtr mat);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvTransform(IntPtr src, IntPtr dst, IntPtr transmat, IntPtr shiftvec);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvTranspose(IntPtr src, IntPtr dst);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvTreeToNodeSeq(IntPtr first, int header_size, CvMemStorage storage);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvTypeOf(IntPtr struct_ptr);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUnregisterType([MarshalAs(UnmanagedType.LPStr)] string type_name);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvUseOptimized([MarshalAs(UnmanagedType.Bool)] bool on_off);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWrite(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr ptr, CvAttrList attributes);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWriteFileNode(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string new_node_name, IntPtr node, [MarshalAs(UnmanagedType.Bool)] bool embed);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWriteInt(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWriteRawData(IntPtr fs, IntPtr src, int len, [MarshalAs(UnmanagedType.LPStr)] string dt);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWriteReal(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWriteString(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string str, [MarshalAs(UnmanagedType.Bool)] bool quote);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWriteComment(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string comment, [MarshalAs(UnmanagedType.Bool)] bool eol_comment);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvXor(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllCore, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvXorS(IntPtr src, CvScalar value, IntPtr dst, IntPtr mask);
        #endregion
        #region HighGUI
        #region Qt
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvFontQt")]
        private static extern WCvFont cvFontQt_([MarshalAs(UnmanagedType.LPStr)] string nameFont, int pointSize, CvScalar color,
            [MarshalAs(UnmanagedType.I4)] FontWeight weight, [MarshalAs(UnmanagedType.I4)] FontStyle style, int spacing);
        public static WCvFont cvFontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight, FontStyle style, int spacing)
        {
            CheckQt();
            return cvFontQt_(nameFont, pointSize, color, weight, style, spacing);
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvAddText")]
        private static extern void cvAddText_(IntPtr img, [MarshalAs(UnmanagedType.LPStr)] string text, CvPoint location, IntPtr font);
        public static unsafe void cvAddText(IntPtr img, string text, CvPoint location, IntPtr font)
        {
            CheckQt();
            cvAddText_(img, text, location, font);
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvDisplayOverlay")]
        private static extern void cvDisplayOverlay_([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string text, int delayms);
        public static void cvDisplayOverlay(string name, string text, int delayms)
        {
            CheckQt();
            cvDisplayOverlay_(name, text, delayms);
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvDisplayStatusBar")]
        private static extern void cvDisplayStatusBar_([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string text, int delayms);
        public static void cvDisplayStatusBar(string name, string text, int delayms)
        {
            CheckQt();
            cvDisplayStatusBar_(name, text, delayms);
        }
        
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCreateOpenGLCallback(string window_name, CvOpenGLCallback callbackOpenGL, IntPtr userdata, double angle, double zmin, double zmax);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvSaveWindowParameters")]
        private static extern void cvSaveWindowParameters_([MarshalAs(UnmanagedType.LPStr)] string name);
        public static void cvSaveWindowParameters(string name)
        {
            CheckQt();
            cvSaveWindowParameters_(name);
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvLoadWindowParameters")]
        private static extern void cvLoadWindowParameters_([MarshalAs(UnmanagedType.LPStr)] string name);
        public static void cvLoadWindowParameters(string name)
        {
            CheckQt();
            cvLoadWindowParameters_(name);
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvStartLoop")]
        private static extern unsafe int cvStartLoop_(IntPtr pt2Func, int argc, char** argv);
        public static unsafe int cvStartLoop(IntPtr pt2Func, int argc, char** argv)
        {
            CheckQt();
            return cvStartLoop_(pt2Func, argc, argv);
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvStopLoop")]
        private static extern void cvStopLoop_();
        public static void cvStopLoop()
        {
            CheckQt();
            cvStopLoop_();
        }
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvCreateButton")]
        private static extern int cvCreateButton_([MarshalAs(UnmanagedType.LPStr)] string name, IntPtr callback, IntPtr userdata,
            [MarshalAs(UnmanagedType.I4)] ButtonType button_type, int initial_button_state);
        public static int cvCreateButton(string name, IntPtr callback, IntPtr userdata, ButtonType button_type, int initial_button_state)
        {
            CheckQt();
            return cvCreateButton_(name, callback, userdata, button_type, initial_button_state);
        }
        #endregion

        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertImage(IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.I4)] ConvertImageFlag flags);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateCameraCapture(int index);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateFileCapture([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCreateTrackbar([MarshalAs(UnmanagedType.LPStr)] string trackbar_name, [MarshalAs(UnmanagedType.LPStr)] string window_name,
            ref int value, int count, [MarshalAs(UnmanagedType.FunctionPtr)] CvTrackbarCallback on_change);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCreateTrackbar([MarshalAs(UnmanagedType.LPStr)] string trackbar_name, [MarshalAs(UnmanagedType.LPStr)] string window_name,
            ref int value, int count, IntPtr on_change);

        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCreateTrackbar2([MarshalAs(UnmanagedType.LPStr)] string trackbar_name, [MarshalAs(UnmanagedType.LPStr)] string window_name,
            ref int value, int count, [MarshalAs(UnmanagedType.FunctionPtr)] CvTrackbarCallback2Native on_change, IntPtr userdata);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCreateTrackbar2([MarshalAs(UnmanagedType.LPStr)] string trackbar_name, [MarshalAs(UnmanagedType.LPStr)] string window_name,
            ref int value, int count, IntPtr on_change, IntPtr userdata);

        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateVideoWriter([MarshalAs(UnmanagedType.LPStr)] string filename, int fourcc, double fps, CvSize frame_size,
            [MarshalAs(UnmanagedType.Bool)] bool is_color);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvDecodeImage(IntPtr buf, [MarshalAs(UnmanagedType.I4)] LoadMode iscolor);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvDecodeImageM(IntPtr buf, [MarshalAs(UnmanagedType.I4)] LoadMode iscolor);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDestroyAllWindows();
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDestroyWindow([MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvEncodeImage([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr image, [In] int[] @params);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetCaptureProperty(IntPtr capture, int property_id);        
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetCaptureProperty(IntPtr capture, [MarshalAs(UnmanagedType.I4)] CaptureProperty property_id);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetTrackbarPos([MarshalAs(UnmanagedType.LPStr)] string trackbar_name, [MarshalAs(UnmanagedType.LPStr)] string window_name);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetWindowHandle([MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string cvGetWindowName(IntPtr window_handle);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetWindowProperty([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.I4)] WindowProperty prop_id);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGrabFrame(IntPtr capture);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvInitSystem(int argc, string[] argv);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvLoadImage([MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.I4)] LoadMode flags);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvLoadImageM([MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.I4)] LoadMode flags);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMoveWindow([MarshalAs(UnmanagedType.LPStr)] string name, int x, int y);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvNamedWindow([MarshalAs(UnmanagedType.LPStr)] string name, WindowMode flags);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvQueryFrame(IntPtr capture);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseCapture(ref IntPtr capture);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseVideoWriter(ref IntPtr writer);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvResizeWindow([MarshalAs(UnmanagedType.LPStr)] string name, int width, int height);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvRetrieveFrame(IntPtr capture, int streamIdx);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSaveImage([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr image, [In] int[] @params);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSetCaptureProperty(IntPtr capture, int property_id, double value);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSetCaptureProperty(IntPtr capture, [MarshalAs(UnmanagedType.I4)] CaptureProperty property_id, double value);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetMouseCallback([MarshalAs(UnmanagedType.LPStr)] string window_name, [MarshalAs(UnmanagedType.FunctionPtr)] CvMouseCallback on_mouse);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetPostprocessFuncWin32(CvWin32WindowCallback on_postprocess);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetPreprocessFuncWin32(CvWin32WindowCallback on_preprocess);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetTrackbarPos(string trackbar_name, string window_name, int pos);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetWindowProperty([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.I4)] WindowProperty prop_id, double prop_value);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvShowImage([MarshalAs(UnmanagedType.LPStr)] string name, IntPtr image);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvStartWindowThread();
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvWaitKey(int delay);
        [DllImport(DllHighgui, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvWriteFrame(IntPtr writer, IntPtr image);
        #endregion
        #region Video
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvBGCodeBookClearStale(IntPtr model, int staleThresh, CvRect roi, IntPtr mask);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvBGCodeBookDiff(IntPtr model, IntPtr image, IntPtr fgmask, CvRect roi);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvBGCodeBookUpdate(IntPtr model, IntPtr image, CvRect roi, IntPtr mask);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcAffineFlowPyrLK(IntPtr prev, IntPtr curr, IntPtr prev_pyr, IntPtr curr_pyr,
            [In] CvPoint2D32f[] prev_features, [Out] CvPoint2D32f[] curr_features, [Out] float[] matrices, int count,
            CvSize win_size, int level, [Out] sbyte[] status, [Out] float[] track_error, CvTermCriteria criteria, [MarshalAs(UnmanagedType.I4)] LKFlowFlag flags);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvCalcGlobalOrientation(IntPtr orientation, IntPtr mask, IntPtr mhi, double timestamp, double duration);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcMotionGradient(IntPtr mhi, IntPtr mask, IntPtr orientation, double delta1, double delta2,
            [MarshalAs(UnmanagedType.U4)] ApertureSize aperture_size);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowFarneback(IntPtr prev, IntPtr next, IntPtr flow,
            double pyr_scale, int levels, int winsize, int iterations, int poly_n, double poly_sigma, [MarshalAs(UnmanagedType.I4)] LKFlowFlag flags);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowPyrLK(IntPtr prev, IntPtr curr, IntPtr prev_pyr, IntPtr curr_pyr,
            [In] CvPoint2D32f[] prev_features, [Out] CvPoint2D32f[] curr_features, int count, CvSize winSize,
            int level, [Out] sbyte[] status, [Out] float[] track_error, CvTermCriteria criteria, [MarshalAs(UnmanagedType.I4)] LKFlowFlag flags);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCamShift(IntPtr prob_image, CvRect window, CvTermCriteria criteria, IntPtr comp, ref CvBox2D box);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateBGCodeBookModel();
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateKalman(int dynam_params, int measure_params, int control_params);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvEstimateRigidTransform(IntPtr A, IntPtr B, IntPtr M, [MarshalAs(UnmanagedType.Bool)] bool full_affine);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvKalmanCorrect(IntPtr kalman, IntPtr measurement);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvKalmanPredict(IntPtr kalman, IntPtr control);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvMeanShift(IntPtr prob_image, CvRect window, CvTermCriteria criteria, IntPtr comp);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseBGCodeBookModel(ref IntPtr _ptr);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseKalman(ref IntPtr kalman);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSegmentFGMask(IntPtr fgmask, [MarshalAs(UnmanagedType.Bool)] bool poly1Hull0, float perimScale, IntPtr storage, CvPoint offset);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSegmentMotion(IntPtr mhi, IntPtr seg_mask, IntPtr storage, double timestamp, double seg_thresh);
        [DllImport(DllVideo, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUpdateMotionHistory(IntPtr silhouette, IntPtr mhi, double timestamp, double duration);
        #endregion
        #region Legacy
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateSubdiv2D([MarshalAs(UnmanagedType.U4)] SeqType subdiv_type, int header_size, int vtx_size, int quadedge_size, IntPtr storage);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitSubdivDelaunay2D(IntPtr subdiv, CvRect rect);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSubdivDelaunay2DInsert(IntPtr subdiv, CvPoint2D32f pt);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSubdiv2DPointLocation cvSubdiv2DLocate(IntPtr subdiv, CvPoint2D32f pt, out CvSubdiv2DEdge edge, ref IntPtr vertex);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcSubdivVoronoi2D(IntPtr subdiv);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvClearSubdivVoronoi2D(IntPtr subdiv);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindNearestPoint2D(IntPtr subdiv, CvPoint2D32f pt);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateLSH(IntPtr ops, int d, int L, int k, MatrixType type, double r, Int64 seed);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateMemoryLSH(int d, int n, int L, int k, MatrixType type, double r, Int64 seed);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLSHAdd(IntPtr lsh, IntPtr data, IntPtr indices);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLSHQuery(IntPtr lsh, IntPtr query_points, IntPtr indices, IntPtr dist, int k, int emax);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLSHRemove(IntPtr lsh, IntPtr indices);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint LSHSize(IntPtr lsh);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseLSH(ref IntPtr lsh);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateStereoGCState(int numberOfDisparities, int maxIters);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindStereoCorrespondenceGC(IntPtr left, IntPtr right, IntPtr dispLeft, IntPtr dispRight, IntPtr state,
            [MarshalAs(UnmanagedType.Bool)] bool useDisparityGuess);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseStereoGCState(ref IntPtr state);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowBM(IntPtr prev, IntPtr curr, CvSize block_size, CvSize shift_size,
            CvSize max_range, [MarshalAs(UnmanagedType.Bool)] bool use_previous, IntPtr velx, IntPtr vely);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowHS(IntPtr prev, IntPtr curr, [MarshalAs(UnmanagedType.Bool)] bool use_previous,
            IntPtr velx, IntPtr vely, double lambda, CvTermCriteria criteria);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowLK(IntPtr prev, IntPtr curr, CvSize winSize, IntPtr velx, IntPtr vely);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateKDTree(IntPtr desc);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateSpillTree(IntPtr raw_data, int naive, double rho, double tau);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseFeatureTree(IntPtr tr);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindFeatures(IntPtr tr, IntPtr desc, IntPtr results, IntPtr dist, int k, int emax);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindFeaturesBoxed(IntPtr tr, IntPtr bounds_min, IntPtr bounds_max, IntPtr results);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvExtractMSER(IntPtr img, IntPtr mask, ref IntPtr contours, IntPtr storage, WCvMSERParams @params);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvExtractSURF(IntPtr image, IntPtr mask, ref IntPtr keypoints, ref IntPtr descriptors, IntPtr storage,
            WCvSURFParams parameters, [MarshalAs(UnmanagedType.Bool)] bool useProvidedKeyPts);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvGetStarKeypoints(IntPtr img, IntPtr storage, WCvStarDetectorParams @params);
        
        [Obsolete]
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern WCvMSERParams cvMSERParams(int delta, int min_area, int max_area, float max_variation, float min_diversity,
            int max_evolution, double area_threshold, double min_margin, int edge_blur_size);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern WCvSURFParams cvSURFParams(double hessianThreshold, [MarshalAs(UnmanagedType.Bool)] bool extended);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrSegmentation(IntPtr src, IntPtr dst, IntPtr storage, out IntPtr comp, int level, double threshold1, double threshold2);

        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcCovarMatrixEx(int object_count, CvCallback input, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag io_flags, int iobuf_size,
            [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, IntPtr userdata, IntPtr avg, [In] float[] covar_matrix);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcCovarMatrixEx(int object_count, IntPtr input, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag io_flags, int iobuf_size,
            IntPtr buffer, IntPtr userdata, IntPtr avg, [In] float[] covar_matrix);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcEigenObjects(int nObjects, IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag ioFlags,
                         int ioBufSize, IntPtr userData, ref CvTermCriteria calcLimit, IntPtr avg, [In] float[] eigVals);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcEigenObjects(int nObjects, CvCallback input, IntPtr output, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag ioFlags,
                         int ioBufSize, IntPtr userData, ref CvTermCriteria calcLimit, IntPtr avg, [In] float[] eigVals);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcEigenObjects(int nObjects, IntPtr input, CvCallback output, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag ioFlags,
                         int ioBufSize, IntPtr userData, ref CvTermCriteria calcLimit, IntPtr avg, [In] float[] eigVals);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcEigenObjects(int nObjects, CvCallback input, CvCallback output, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag ioFlags,
                         int ioBufSize, IntPtr userData, ref CvTermCriteria calcLimit, IntPtr avg, [In] float[] eigVals);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvCalcDecompCoeff(IntPtr obj, IntPtr eigObj, IntPtr avg);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcImageHomography([MarshalAs(UnmanagedType.LPArray)] float[] line, ref CvPoint3D32f center,
            [MarshalAs(UnmanagedType.LPArray)] float[,] intrinsic, [Out] [MarshalAs(UnmanagedType.LPArray)] float[,] homography);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcPGH(IntPtr contour, IntPtr hist);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConDensInitSampleSet(IntPtr condens, IntPtr lower_bound, IntPtr upper_bound);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvContourFromContourTree(IntPtr tree, IntPtr storage, CvTermCriteria criteria);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateConDensation(int dynam_params, int measure_params, int sample_count);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateContourTree(IntPtr contour, IntPtr storage, double threshold);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDeleteMoire(IntPtr img);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEigenDecomposite(IntPtr obj, int eigenvec_count, IntPtr eigInput, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag ioFlags, IntPtr userData, IntPtr avg, [In] float[] coeffs);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEigenDecomposite(IntPtr obj, int eigenvec_count, CvCallback eigInput, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag ioFlags, IntPtr userData, IntPtr avg, [In] float[] coeffs);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEigenProjection(IntPtr input_vecs, int eigenvec_count, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag io_flags, IntPtr userdata, float[] coeffs, IntPtr avg, IntPtr proj);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEigenProjection(CvCallback input_vecs, int eigenvec_count, [MarshalAs(UnmanagedType.I4)] EigenObjectsIOFlag io_flags, IntPtr userdata, float[] coeffs, IntPtr avg, IntPtr proj);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConDensUpdateByTime(IntPtr condens);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindDominantPoints(IntPtr contour, IntPtr storage, [MarshalAs(UnmanagedType.I4)] DominantsFlag method,
             double parameter1, double parameter2, double parameter3, double parameter4);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvFindFace(IntPtr image, IntPtr storage);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindStereoCorrespondence(IntPtr leftImage, IntPtr rightImage, DisparityMode mode, IntPtr depthImage, int maxDisparity, double param1, double param2, double param3, double param4, double param5);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvInitFaceTracker(IntPtr pFaceTracker, IntPtr imgGray, [In] CvRect[] pRects, int nRects);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMakeScanlines(double[,] matrix, CvSize img_size, int[] scanlines1, int[] scanlines2, int[] lengths1, int[] lengths2, out int line_count);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvMatchContourTrees(IntPtr tree1, IntPtr tree2, [MarshalAs(UnmanagedType.U4)] ContourTreesMatchMethod method, double threshold);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvPostBoostingFindFace(IntPtr image, IntPtr storage);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseConDensation(ref IntPtr condens);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseFaceTracker(ref IntPtr ppFaceTracker);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvSegmentImage(IntPtr srcarr, IntPtr dstarr, double canny_threshold, double ffill_threshold, IntPtr storage);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSnakeImage(IntPtr image, IntPtr points, int length, ref float alpha, ref float beta, ref float gamma,
            int coeffUsage, CvSize win, CvTermCriteria criteria, [MarshalAs(UnmanagedType.Bool)] bool calc_gradient);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSnakeImage(IntPtr image, IntPtr points, int length,
            [MarshalAs(UnmanagedType.LPArray)] float[] alpha, [MarshalAs(UnmanagedType.LPArray)] float[] beta, [MarshalAs(UnmanagedType.LPArray)] float[] gamma,
            int coeffUsage, CvSize win, CvTermCriteria criteria, [MarshalAs(UnmanagedType.Bool)] bool calc_gradient);
        [DllImport(DllLegacy, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool cvTrackFace(IntPtr pFaceTracker, IntPtr imgGray, [Out] CvRect[] pRects, int nRects, out CvPoint ptRotate, out double dbAngleRotate);
        #endregion
        #region Calib3d
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcMatMulDeriv(IntPtr A, IntPtr B, IntPtr dABdA, IntPtr dABdB);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalibrateCamera2(IntPtr object_points, IntPtr image_points, IntPtr point_counts, CvSize image_size,
            IntPtr intrinsic_matrix, IntPtr distortion_coeffs, IntPtr rotation_vectors, IntPtr translation_vectors, CalibrationFlag flags);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalibrationMatrixValues(IntPtr camera_matrix, CvSize image_size, double aperture_width, double aperture_height,
            out double fovx, out double fovy, out double focal_length, out CvPoint2D64f principal_point, out double pixel_aspect_ratio);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCheckChessboard(IntPtr src, CvSize size);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvComposeRT(IntPtr rvec1, IntPtr tvec1, IntPtr rvec2, IntPtr tvec2, IntPtr rvec3, IntPtr tvec3,
                         IntPtr dr3dr1, IntPtr dr3dt1, IntPtr dr3dr2, IntPtr dr3dt2, IntPtr dt3dr1, IntPtr dt3dt1, IntPtr dt3dr2, IntPtr dt3dt2);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvComputeCorrespondEpilines(IntPtr points, int which_image, IntPtr fundamental_matrix, IntPtr correspondent_lines);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertPointsHomogeneous(IntPtr src, IntPtr dst);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCorrectMatches(IntPtr F, IntPtr points1, IntPtr points2, IntPtr new_points1, IntPtr new_points2);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreatePOSITObject([In] CvPoint3D32f[] points, int point_count);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateStereoBMState(StereoBMPreset type, int numberOfDisparities);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDecomposeProjectionMatrix(IntPtr projMatr, IntPtr calibMatr, IntPtr rotMatr, IntPtr posVect,
            IntPtr rotMatrX, IntPtr rotMatrY, IntPtr rotMatrZ, ref CvPoint3D64f eulerAngles);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDrawChessboardCorners(IntPtr image, CvSize pattern_size, [In] CvPoint2D32f[] corners, int count,
            [MarshalAs(UnmanagedType.Bool)] bool pattern_was_found);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindChessboardCorners(IntPtr image, CvSize pattern_size, IntPtr corners, ref int corner_count, [MarshalAs(UnmanagedType.I4)] ChessboardFlag flags);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindExtrinsicCameraParams2(IntPtr object_points, IntPtr image_points, IntPtr intrinsic_matrix,
            IntPtr distortion_coeffs, IntPtr rotation_vector, IntPtr translation_vector, [MarshalAs(UnmanagedType.Bool)] bool use_extrinsic_guess);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindFundamentalMat(IntPtr points1, IntPtr points2, IntPtr fundamental_matrix, FundamentalMatMethod method,
            double param1, double param2, IntPtr status);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindHomography(IntPtr src_points, IntPtr dst_points, IntPtr homography, [MarshalAs(UnmanagedType.I4)] HomographyMethod method, double ransacReprojThreshold, IntPtr mask);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindStereoCorrespondenceBM(IntPtr left, IntPtr right, IntPtr disparity, IntPtr state);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetOptimalNewCameraMatrix(IntPtr cameraMatrix, IntPtr distCoeffs, CvSize imageSize, double alpha, IntPtr newCameraMatrix, CvSize newImageSize, out CvRect validPixROI);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect cvGetValidDisparityROI(CvRect roi1, CvRect roi2, int minDisparity, int numberOfDisparities, int SADWindowSize);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitIntrinsicParams2D(IntPtr object_points, IntPtr image_points, IntPtr npoints, CvSize image_size, IntPtr camera_matrix, double aspect_ratio);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPOSIT(IntPtr posit_object, [MarshalAs(UnmanagedType.LPArray)]  CvPoint2D32f[] image_points, double focal_length,
            CvTermCriteria criteria, [MarshalAs(UnmanagedType.LPArray)] float[,] rotation_matrix, [MarshalAs(UnmanagedType.LPArray)] float[] translation_vector);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvProjectPoints2(IntPtr object_points, IntPtr rotation_vector, IntPtr translation_vector, IntPtr intrinsic_matrix,
            IntPtr distortion_coeffs, IntPtr image_points, IntPtr dpdrot, IntPtr dpdt, IntPtr dpdf, IntPtr dpdc, IntPtr dpddist, double aspect_ratio);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvRANSACUpdateNumIters(double p, double err_prob, int model_points, int max_iters);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleasePOSITObject(ref IntPtr posit_object);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseStereoBMState(ref IntPtr state);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReprojectImageTo3D(IntPtr disparity, IntPtr image3D, IntPtr Q);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvRodrigues2(IntPtr src, IntPtr dst, IntPtr jacobian);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRQDecomp3x3(IntPtr matrixM, IntPtr matrixR, IntPtr matrixQ,
                           IntPtr matrixQx, IntPtr matrixQy, IntPtr matrixQz, ref CvPoint3D64f eulerAngles);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStereoCalibrate(IntPtr object_points, IntPtr image_points1, IntPtr image_points2, IntPtr npoints,
                               IntPtr camera_matrix1, IntPtr dist_coeffs1, IntPtr camera_matrix2, IntPtr dist_coeffs2,
                               CvSize image_size, IntPtr R, IntPtr T, IntPtr E, IntPtr F,
                               CvTermCriteria term_crit, CalibrationFlag flags);

        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvStereoRectify(IntPtr camera_matrix1, IntPtr camera_matrix2, IntPtr dist_coeffs1, IntPtr dist_coeffs2,
                             CvSize image_size, IntPtr R, IntPtr T, IntPtr R1, IntPtr R2, IntPtr P1, IntPtr P2,
                             IntPtr Q, StereoRectificationFlag flags,
                             double alpha, CvSize new_image_size, out CvRect valid_pix_ROI1, out CvRect valid_pix_ROI2);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvStereoRectifyUncalibrated(IntPtr points1, IntPtr points2, IntPtr F, CvSize img_size, IntPtr H1, IntPtr H2, double threshold);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvTriangulatePoints(IntPtr projMatr1, IntPtr projMatr2, IntPtr projPoints1, IntPtr projPoints2, IntPtr points4D);
        [DllImport(DllCalib3d, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvValidateDisparity(IntPtr disparity, IntPtr cost, int minDisparity, int numberOfDisparities, int disp12MaxDiff);
        #endregion
        #region Features2d
        #endregion
        #region Objdetect
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvHaarDetectObjects(IntPtr image, IntPtr cascade, IntPtr storage, double scale_factor, int min_neighbors,
            [MarshalAs(UnmanagedType.U4)] HaarDetectionType flags, CvSize min_size);
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvLoadHaarClassifierCascade([MarshalAs(UnmanagedType.LPStr)] string directory, CvSize orig_window_size);
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseHaarClassifierCascade(ref IntPtr cascade);
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvRunHaarClassifierCascade(IntPtr cascade, CvPoint pt, [MarshalAs(UnmanagedType.Bool)] bool start_stage);
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetImagesForHaarClassifierCascade(IntPtr cascade, IntPtr sum, IntPtr sqsum, IntPtr tilted_sum, double scale);

        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvLoadLatentSvmDetector([MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseLatentSvmDetector(ref IntPtr detector);
        [DllImport(DllObjdetect, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvLatentSvmDetectObjects(IntPtr image, IntPtr detector, IntPtr storage, float overlap_threshold, int numThreads);
        #endregion
        #endregion
    }
}

// ReSharper restore InconsistentNaming
