using System;
using System.Runtime.InteropServices;
using OpenCvSharp.ML;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_SVM_getType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setType(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getGamma(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setGamma(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getCoef0(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setCoef0(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getDegree(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setDegree(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getC(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setC(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getP(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setP(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getNu(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setNu(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_SVM_getClassWeights(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setClassWeights(IntPtr obj, IntPtr val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern TermCriteria ml_SVM_getTermCriteria(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setTermCriteria(IntPtr obj, TermCriteria val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_SVM_getKernelType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_SVM_setKernel(IntPtr obj, int kernelType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_SVM_getSupportVectors(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_SVM_getDecisionFunction(
            IntPtr obj, int i, IntPtr alpha, IntPtr svidx);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ParamGrid ml_SVM_getDefaultGrid(int paramId);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_SVM_create();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_Ptr_SVM_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_Ptr_SVM_get(IntPtr obj);
    }
}