using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region Inpainting

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_inpaint(IntPtr prt, IntPtr src, IntPtr dst, int algorithm);

        #endregion

        #region WhiteBalance

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_applyChannelGains(IntPtr src, IntPtr dst, float gainB, float gainG, float gainR);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_createGrayworldWB();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_Ptr_GrayworldWB_delete(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_Ptr_GrayworldWB_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_GrayworldWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_GrayworldWB_SaturationThreshold_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_GrayworldWB_SaturationThreshold_set(IntPtr ptr, float val);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_createLearningBasedWB(string trackerType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_Ptr_LearningBasedWB_delete(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_Ptr_LearningBasedWB_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_LearningBasedWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_LearningBasedWB_extractSimpleFeatures(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_LearningBasedWB_HistBinNum_set(IntPtr prt, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_LearningBasedWB_RangeMaxVal_set(IntPtr prt, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_LearningBasedWB_SaturationThreshold_set(IntPtr prt, float value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xphoto_LearningBasedWB_HistBinNum_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xphoto_LearningBasedWB_RangeMaxVal_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_LearningBasedWB_SaturationThreshold_get(IntPtr prt);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_createSimpleWB();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_Ptr_SimpleWB_delete(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xphoto_Ptr_SimpleWB_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_SimpleWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_InputMax_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_InputMax_set(IntPtr prt, float value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_InputMin_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_InputMin_set(IntPtr prt, float value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_OutputMax_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_OutputMax_set(IntPtr prt, float value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_OutputMin_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_OutputMin_set(IntPtr prt, float value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_P_get(IntPtr prt);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float xphoto_SimpleWB_P_set(IntPtr prt, float value);

        #endregion

        #region Denoising

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_dctDenoising(IntPtr src, IntPtr dst, double sigma, int psize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_bm3dDenoising1(
            IntPtr src,
            IntPtr dstStep1,
            IntPtr dstStep2,
            float h,
            int templateWindowSize,
            int searchWindowSize,
            int blockMatchingStep1,
            int blockMatchingStep2,
            int groupSize,
            int slidingStep,
            float beta,
            int normType,
            int step,
            int transformType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xphoto_bm3dDenoising2(
            IntPtr src,
            IntPtr dst,
            float h,
            int templateWindowSize,
            int searchWindowSize,
            int blockMatchingStep1,
            int blockMatchingStep2,
            int groupSize,
            int slidingStep,
            float beta,
            int normType,
            int step,
            int transformType);

        #endregion
    }
}