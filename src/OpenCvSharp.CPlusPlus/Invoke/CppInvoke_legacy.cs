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
        #region legacy_CvCamShiftTracker
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr legacy_CvCamShiftTracker_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr legacy_CvCamShiftTracker_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void legacy_CvCamShiftTracker_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float legacy_CvCamShiftTracker_get_orientation(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float legacy_CvCamShiftTracker_get_length(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float legacy_CvCamShiftTracker_get_width(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint2D32f legacy_CvCamShiftTracker_get_center(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect legacy_CvCamShiftTracker_get_window(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_get_threshold(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_get_hist_dims(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] dims);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_get_min_ch_val(IntPtr self, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_get_max_ch_val(IntPtr self, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_set_window(IntPtr self, CvRect window);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_set_threshold(IntPtr self, int threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_set_hist_bin_range(IntPtr self, int dim, int minVal, int maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_set_hist_dims(IntPtr self, int cDims, [MarshalAs(UnmanagedType.LPArray)] int[] dims);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_set_min_ch_val(IntPtr self, int channel, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_set_max_ch_val(IntPtr self, int channel, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_track_object(IntPtr self, IntPtr curFrame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int legacy_CvCamShiftTracker_update_histogram(IntPtr self, IntPtr curFrame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void legacy_CvCamShiftTracker_reset_histogram(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr legacy_CvCamShiftTracker_get_back_project(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float legacy_CvCamShiftTracker_query(IntPtr self, [MarshalAs(UnmanagedType.LPArray)] int[] bin);
        #endregion
    }
}