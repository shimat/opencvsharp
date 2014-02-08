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
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class CppInvoke
    {
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
    }
}