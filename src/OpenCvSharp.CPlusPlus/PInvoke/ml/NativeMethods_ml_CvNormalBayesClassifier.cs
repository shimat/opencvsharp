using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvNormalBayesClassifier_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvNormalBayesClassifier_new2_CvMat(
            IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvNormalBayesClassifier_new2_Mat(
            IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvNormalBayesClassifier_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvNormalBayesClassifier_train_CvMat(
            IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, int update);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvNormalBayesClassifier_train_Mat(
            IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, int update);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvNormalBayesClassifier_predict_CvMat(
            IntPtr obj, IntPtr samples, IntPtr results);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvNormalBayesClassifier_predict_Mat(
            IntPtr obj, IntPtr samples, IntPtr results);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvNormalBayesClassifier_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvNormalBayesClassifier_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvNormalBayesClassifier_read(IntPtr obj, IntPtr storage, IntPtr node);
        
    }
}