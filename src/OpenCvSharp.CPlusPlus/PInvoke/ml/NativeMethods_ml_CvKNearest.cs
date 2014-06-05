using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvKNearest_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvKNearest_new2_CvMat(
            IntPtr trainData, IntPtr responses, IntPtr sampleIdx, int isRegression, int maxK);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvKNearest_new2_Mat(
            IntPtr trainData, IntPtr responses, IntPtr sampleIdx, int isRegression, int maxK);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvKNearest_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvKNearest_train_CvMat(
            IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr sampleIdx, 
            int isRegression, int maxK, int updateBase);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvKNearest_train_Mat(
            IntPtr obj, IntPtr trainData, IntPtr responses, IntPtr sampleIdx,
            int isRegression, int maxK, int updateBase);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvKNearest_find_nearest_CvMat(
            IntPtr obj, IntPtr samples, int k, IntPtr results, 
            [In, Out] IntPtr[] neighbors, IntPtr neighborResponses, IntPtr dist);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvKNearest_find_nearest_Mat(
            IntPtr obj, IntPtr samples, int k, IntPtr results, 
            IntPtr neighborResponses, IntPtr dists);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvKNearest_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvKNearest_get_max_k(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvKNearest_get_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvKNearest_get_sample_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvKNearest_is_regression(IntPtr obj);
    }
}