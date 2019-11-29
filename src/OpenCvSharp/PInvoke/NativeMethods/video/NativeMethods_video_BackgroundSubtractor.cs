using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region BackgroundSubtractor

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractor_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractor_apply(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_Ptr_BackgroundSubtractor_delete(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_Ptr_BackgroundSubtractor_get(IntPtr ptr);

        #endregion

        #region BackgroundSubtractorMOG2
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_createBackgroundSubtractorMOG2(
            int history, double varThreshold, int detectShadows);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_Ptr_BackgroundSubtractorMOG2_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorMOG2_get(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorMOG2_getHistory(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setHistory(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorMOG2_getNMixtures(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setNMixtures(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getBackgroundRatio(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setBackgroundRatio(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getVarThreshold(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setVarThreshold(IntPtr ptr, double value);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getVarThresholdGen(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setVarThresholdGen(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getVarInit(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setVarInit(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getVarMin(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setVarMin(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getVarMax(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setVarMax(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorMOG2_getDetectShadows(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setDetectShadows(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorMOG2_getShadowValue(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setShadowValue(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorMOG2_getShadowThreshold(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorMOG2_setShadowThreshold(IntPtr ptr, double value);

        #endregion

        #region BackgroundSubtractorKNN

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_createBackgroundSubtractorKNN(
            int history, double dist2Threshold, int detectShadows);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_Ptr_BackgroundSubtractorKNN_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorKNN_get(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorKNN_getHistory(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setHistory(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorKNN_getNSamples(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setNSamples(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorKNN_getDist2Threshold(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setDist2Threshold(IntPtr ptr, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorKNN_getkNNSamples(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setkNNSamples(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorKNN_getDetectShadows(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setDetectShadows(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int video_BackgroundSubtractorKNN_getShadowValue(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setShadowValue(IntPtr ptr, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double video_BackgroundSubtractorKNN_getShadowThreshold(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void video_BackgroundSubtractorKNN_setShadowThreshold(IntPtr ptr, double value);

        #endregion
    }
}