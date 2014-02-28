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
        #region Algorithm

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Algorithm_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_name(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Algorithm_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Algorithm_getInt(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_Algorithm_getDouble(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool core_Algorithm_getBool(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_getString(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_getMat(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr outMat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_getMatVector(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr outVec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_Algorithm_getAlgorithm(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setInt(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setDouble(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setBool(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setString(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setMat(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setMatVector(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_setAlgorithm(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        #endregion

        #region Array Operations

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_add(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_subtract(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_multiply(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_divide1")]
        public static extern void core_divide(double scale, IntPtr src2, IntPtr dst, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_divide2")]
        public static extern void core_divide(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_scaleAdd(IntPtr src1, double alpha, IntPtr src2,IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_addWeighted(IntPtr src1, double alpha, IntPtr src2,
            double beta, double gamma, IntPtr dst, int dtype);

        #endregion

        #region Drawing
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_line(IntPtr img, Point pt1, Point pt2, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_rectangle1")]
        public static extern void core_rectangle(IntPtr img, Point pt1, Point pt2, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_rectangle2")]
        public static extern void core_rectangle(IntPtr img, Rect rect, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_circle(IntPtr img, Point center, int radius, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_ellipse1")]
        public static extern void core_ellipse(IntPtr img, Point center, Size axes,
            double angle, double startAngle, double endAngle, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_ellipse2")]
        public static extern void core_ellipse(IntPtr img, RotatedRect box, CvScalar color, int thickness, int lineType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fillConvexPoly(IntPtr img, Point[] pts, int npts, CvScalar color, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fillPoly(IntPtr img, IntPtr[] pts, int[] npts, int ncontours,
            CvScalar color, int lineType, int shift, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_polylines(IntPtr img, IntPtr[] pts, int[] npts,
            int ncontours, int isClosed, CvScalar color, int thickness, int lineType, int shift);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_clipLine1")]
        public static extern int core_clipLine(Size imgSize, ref Point pt1, ref Point pt2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_clipLine2")]
        public static extern int core_clipLine(Rect imgRect, ref Point pt1, ref Point pt2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_putText(IntPtr img, string text, CvPoint org,
            int fontFace, double fontScale, CvScalar color,
            int thickness, int lineType, int bottomLeftOrigin);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize core_getTextSize(string text, int fontFace,
	        double fontScale, int thickness, out int baseLine);

        #endregion

        #region Miscellaneous
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_setNumThreads(int nthreads);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getNumThreads();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getThreadNum();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_getBuildInformation([MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, uint maxLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern long core_getTickCount();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_getTickFrequency();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern long core_getCPUTickCount();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_checkHardwareSupport([MarshalAs(UnmanagedType.I4)] HardwareSupport feature);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getNumberOfCPUs();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_fastMalloc(IntPtr bufSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fastFree(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_setUseOptimized(int onoff);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_useOptimized();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_cvarrToMat(IntPtr arr, int copyData, int allowND, int coiMode);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_extractImageCOI(IntPtr arr, IntPtr coiimg, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_insertImageCOI(IntPtr coiimg, IntPtr arr, int coi);
        #endregion
        

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_LUT(IntPtr src, IntPtr lut, IntPtr dst, int interpolation);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar core_sum(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_countNonZero(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_findNonZero(IntPtr src, IntPtr idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar core_mean(IntPtr src, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_meanStdDev(IntPtr src, IntPtr mean,
                                                  IntPtr stddev, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_norm1")]
        public static extern double core_norm(IntPtr src1, int normType, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_norm2")]
        public static extern double core_norm(IntPtr src1, IntPtr src2,
                                               int normType, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_batchDistance(IntPtr src1, IntPtr src2,
                                                     IntPtr dist, int dtype, IntPtr nidx,
                                                     int normType, int k, IntPtr mask,
                                                     int update, int crosscheck);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_normalize(IntPtr src, IntPtr dst, double alpha, double beta,
                             int normType, int dtype, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_minMaxLoc1")]
        public static extern void core_minMaxLoc(IntPtr src, out double minVal, out double maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_minMaxLoc2")]
        public static extern void core_minMaxLoc(IntPtr src, out double minVal, out double maxVal,
            out CvPoint minLoc, out CvPoint maxLoc, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_minMaxIdx1")]
        public static extern void core_minMaxIdx(IntPtr src, out double minVal, out double maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_minMaxIdx2")]
        public static extern void core_minMaxIdx(IntPtr src, out double minVal, out double maxVal,
            out int minIdx, out int maxIdx, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_reduce(IntPtr src, IntPtr dst, int dim, int rtype, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_merge([MarshalAs(UnmanagedType.LPArray)] IntPtr[] mv, uint count, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_split(IntPtr src, out IntPtr mv);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_mixChannels(IntPtr[] src, uint nsrcs,
            IntPtr[] dst, uint ndsts, int[] fromTo, uint npairs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_extractChannel(IntPtr src, IntPtr dst, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_insertChannel(IntPtr src, IntPtr dst, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_flip(IntPtr src, IntPtr dst, int flipCode);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_repeat1")]
        public static extern void core_repeat(IntPtr src, int ny, int nx, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_repeat2")]
        public static extern IntPtr core_repeat(IntPtr src, int ny, int nx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_hconcat1")]
        public static extern void core_hconcat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_hconcat2")]
        public static extern void core_hconcat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_vconcat1")]
        public static extern void core_vconcat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_vconcat2")]
        public static extern void core_vconcat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_and(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_or(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_xor(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_not(IntPtr src, IntPtr dst, IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen1")]
        public static extern int core_eigen(IntPtr src, IntPtr eigenvalues, int lowindex, int highindex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen2")]
        public static extern int core_eigen(IntPtr src, IntPtr eigenvalues,
            IntPtr eigenvectors, int lowindex, int highindex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
        public static extern int core_eigen(IntPtr src, bool computeEigenvectors,
            IntPtr eigenvalues, IntPtr eigenvectors);
    }
}