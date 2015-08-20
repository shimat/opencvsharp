using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int contrib_initModule_contrib();

        #region CvAdaptiveSkinDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr contrib_CvAdaptiveSkinDetector_new(int samplingDivider, int morphingMethod);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_CvAdaptiveSkinDetector_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_CvAdaptiveSkinDetector_process(IntPtr self, IntPtr inputBgrImage, IntPtr outputHueMask);
        #endregion

        #region FaceRecognizer

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_train(
            IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_update(
            IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int contrib_FaceRecognizer_predict1(IntPtr obj, IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_predict2(
            IntPtr obj, IntPtr src, out int label, out double confidence);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_save1(IntPtr obj, string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_load1(IntPtr obj, string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_save2(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_FaceRecognizer_load2(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr contrib_FaceRecognizer_info(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr contrib_createEigenFaceRecognizer(
            int numComponents, double threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr contrib_createFisherFaceRecognizer(
            int numComponents, double threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr contrib_createLBPHFaceRecognizer(
            int radius, int neighbors, int gridX, int gridY, double threshold);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr contrib_Ptr_FaceRecognizer_obj(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_Ptr_FaceRecognizer_delete(IntPtr obj);

        #endregion

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int contrib_chamerMatching(IntPtr img, IntPtr templ,
            IntPtr results, IntPtr cost,
            double templScale, int maxMatches, double minMatchDistance, int padX,
            int padY, int scales, double minScale, double maxScale,
            double orientationWeight, double truncate);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void contrib_applyColorMap(IntPtr src, IntPtr dst, int colormap);

    }
}