using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region BackgroundSubtractor

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractor_getBackgroundImage(IntPtr self, IntPtr backgroundImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractor_apply(IntPtr self, IntPtr image, IntPtr fgmask, double learningRate);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractor_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractor_get(IntPtr ptr);

        #endregion

        #region BackgroundSubtractorMOG2
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_createBackgroundSubtractorMOG2(
            int history, double varThreshold, int detectShadows);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorMOG2_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorMOG2_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorMOG2_getHistory(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setHistory(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorMOG2_getNMixtures(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setNMixtures(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getBackgroundRatio(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setBackgroundRatio(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getVarThreshold(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setVarThreshold(IntPtr ptr, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getVarThresholdGen(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setVarThresholdGen(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getVarInit(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setVarInit(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getVarMin(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setVarMin(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getVarMax(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setVarMax(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorMOG2_getDetectShadows(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setDetectShadows(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorMOG2_getShadowValue(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setShadowValue(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorMOG2_getShadowThreshold(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorMOG2_setShadowThreshold(IntPtr ptr, double value);

        #endregion

        #region BackgroundSubtractorKNN

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_createBackgroundSubtractorKNN(
            int history, double dist2Threshold, int detectShadows);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_Ptr_BackgroundSubtractorKNN_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr video_Ptr_BackgroundSubtractorKNN_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorKNN_getHistory(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setHistory(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorKNN_getNSamples(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setNSamples(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorKNN_getDist2Threshold(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setDist2Threshold(IntPtr ptr, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorKNN_getkNNSamples(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setkNNSamples(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorKNN_getDetectShadows(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setDetectShadows(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int video_BackgroundSubtractorKNN_getShadowValue(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setShadowValue(IntPtr ptr, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double video_BackgroundSubtractorKNN_getShadowThreshold(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void video_BackgroundSubtractorKNN_setShadowThreshold(IntPtr ptr, double value);

        #endregion
    }
}