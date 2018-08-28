using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_ImgHashBase_compute(IntPtr obj, IntPtr inputArr, IntPtr outputArr);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double img_hash_ImgHashBase_compare(IntPtr obj, IntPtr hashOne, IntPtr hashTwo);


        // AverageHash

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_AverageHash_create();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_Ptr_AverageHash_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_Ptr_AverageHash_get(IntPtr ptr);

        // BlockMeanHash

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_BlockMeanHash_create(int mode);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_Ptr_BlockMeanHash_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_Ptr_BlockMeanHash_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_BlockMeanHash_setMode(IntPtr obj, int mode);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_BlockMeanHash_getMean(IntPtr obj, IntPtr outVec);

        // ColorMomentHash

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_ColorMomentHash_create();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_Ptr_ColorMomentHash_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_Ptr_ColorMomentHash_get(IntPtr ptr);

        // MarrHildrethHash

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_MarrHildrethHash_create(float alpha, float scale);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_Ptr_MarrHildrethHash_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_Ptr_MarrHildrethHash_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_MarrHildrethHash_setKernelParam(IntPtr obj, float alpha, float scale);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float img_hash_MarrHildrethHash_getAlpha(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float img_hash_MarrHildrethHash_getScale(IntPtr obj);

        // PHash

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_PHash_create();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_Ptr_PHash_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_Ptr_PHash_get(IntPtr ptr);

        // RadialVarianceHash

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_RadialVarianceHash_create(double sigma, int numOfAngleLine);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_Ptr_RadialVarianceHash_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr img_hash_Ptr_RadialVarianceHash_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_RadialVarianceHash_setNumOfAngleLine(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void img_hash_RadialVarianceHash_setSigma(IntPtr obj, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int img_hash_RadialVarianceHash_getNumOfAngleLine(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double img_hash_RadialVarianceHash_getSigma(IntPtr obj);
    }
}