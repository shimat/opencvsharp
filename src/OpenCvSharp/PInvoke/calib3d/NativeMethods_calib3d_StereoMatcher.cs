
using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        #region StereoMatcher

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_compute(
            IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calib3d_Ptr_StereoMatcher_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoMatcher_getMinDisparity(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_setMinDisparity(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoMatcher_getNumDisparities(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_setNumDisparities(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoMatcher_getBlockSize(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_setBlockSize(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoMatcher_getSpeckleWindowSize(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_setSpeckleWindowSize(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoMatcher_getSpeckleRange(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_setSpeckleRange(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoMatcher_getDisp12MaxDiff(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoMatcher_setDisp12MaxDiff(IntPtr obj, int value);

        #endregion

        #region StereoBM

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_Ptr_StereoBM_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calib3d_StereoBM_create(int numDisparities, int blockSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calib3d_Ptr_StereoBM_info(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoBM_getPreFilterType(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setPreFilterType(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoBM_getPreFilterSize(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setPreFilterSize(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoBM_getPreFilterCap(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setPreFilterCap(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoBM_getTextureThreshold(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setTextureThreshold(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoBM_getUniquenessRatio(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setUniquenessRatio(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoBM_getSmallerBlockSize(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setSmallerBlockSize(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rect calib3d_StereoBM_getROI1(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setROI1(IntPtr obj, Rect value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rect calib3d_StereoBM_getROI2(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoBM_setROI2(IntPtr obj, Rect value);

        #endregion

        #region StereoSGBM

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_Ptr_StereoSGBM_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calib3d_StereoSGBM_create(
            int minDisparity, int numDisparities, int blockSize,
            int P1, int P2, int disp12MaxDiff,
            int preFilterCap, int uniquenessRatio,
            int speckleWindowSize, int speckleRange, int mode);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr calib3d_Ptr_StereoSGBM_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoSGBM_getPreFilterCap(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoSGBM_setPreFilterCap(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoSGBM_getUniquenessRatio(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoSGBM_setUniquenessRatio(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoSGBM_getP1(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoSGBM_setP1(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoSGBM_getP2(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoSGBM_setP2(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int calib3d_StereoSGBM_getMode(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void calib3d_StereoSGBM_setMode(IntPtr obj, int value);

        #endregion
    }
}