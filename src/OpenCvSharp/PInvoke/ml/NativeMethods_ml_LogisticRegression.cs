using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_LogisticRegression_getLearningRate(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_LogisticRegression_setLearningRate(IntPtr obj, double val);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_LogisticRegression_getIterations(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_LogisticRegression_setIterations(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_LogisticRegression_getRegularization(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_LogisticRegression_setRegularization(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_LogisticRegression_getTrainMethod(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_LogisticRegression_setTrainMethod(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_LogisticRegression_getMiniBatchSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_LogisticRegression_setMiniBatchSize(IntPtr obj, int val);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern TermCriteria ml_LogisticRegression_getTermCriteria(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_LogisticRegression_setTermCriteria(IntPtr obj, TermCriteria val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_LogisticRegression_predict(
            IntPtr obj, IntPtr samples, IntPtr results, int flags);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_LogisticRegression_get_learnt_thetas(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_LogisticRegression_create();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_Ptr_LogisticRegression_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_Ptr_LogisticRegression_get(IntPtr obj);
    }
}