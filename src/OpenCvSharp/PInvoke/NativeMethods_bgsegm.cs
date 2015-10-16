using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region BackgroundSubtractorMOG

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr bgsegm_createBackgroundSubtractorMOG(
            int history, int nmixtures, double backgroundRatio, double noiseSigma);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_Ptr_BackgroundSubtractorMOG_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr bgsegm_Ptr_BackgroundSubtractorMOG_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorMOG_getHistory(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorMOG_setHistory(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorMOG_getNMixtures(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorMOG_setNMixtures(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(IntPtr ptr, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorMOG_getNoiseSigma(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorMOG_setNoiseSigma(IntPtr ptr, double value);

        #endregion

        #region BackgroundSubtractorGMG

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr bgsegm_createBackgroundSubtractorGMG(
            int initializationFrames, double decisionThreshold);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_Ptr_BackgroundSubtractorGMG_delete(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr bgsegm_Ptr_BackgroundSubtractorGMG_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorGMG_getMaxFeatures(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setMaxFeatures(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(IntPtr ptr, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorGMG_getNumFrames(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setNumFrames(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(IntPtr ptr, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(IntPtr ptr, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(IntPtr ptr, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorGMG_getMinVal(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setMinVal(IntPtr ptr, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double bgsegm_BackgroundSubtractorGMG_getMaxVal(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void bgsegm_BackgroundSubtractorGMG_setMaxVal(IntPtr ptr, double value);

        #endregion
    }
}