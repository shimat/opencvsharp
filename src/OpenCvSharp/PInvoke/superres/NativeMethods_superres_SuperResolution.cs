using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setInput(IntPtr obj, IntPtr frameSource);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_nextFrame(IntPtr obj, IntPtr frame);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_reset(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_collectGarbage(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr superres_createSuperResolution_BTVL1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr superres_createSuperResolution_BTVL1_CUDA();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr superres_Ptr_SuperResolution_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_Ptr_SuperResolution_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int superres_SuperResolution_getScale(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setScale(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int superres_SuperResolution_getIterations(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setIterations(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double superres_SuperResolution_getTau(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setTau(IntPtr obj, double val);
        
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double superres_SuperResolution_getLambda(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setLambda(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double superres_SuperResolution_getAlpha(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setAlpha(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int superres_SuperResolution_getKernelSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setKernelSize(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int superres_SuperResolution_getBlurKernelSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setBlurKernelSize(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double superres_SuperResolution_getBlurSigma(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setBlurSigma(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int superres_SuperResolution_getTemporalAreaRadius(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setTemporalAreaRadius(IntPtr obj,int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr superres_SuperResolution_getOpticalFlow(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void superres_SuperResolution_setOpticalFlow(IntPtr obj, IntPtr val);
    }
}