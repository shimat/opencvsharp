using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVMParams_new1(ref WCvSVMParams result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVMParams_new2(ref WCvSVMParams result, 
            int svmType, int kernelType, double degree, double gamma, double coef0,
            double c, double nu, double p, IntPtr classWeights, CvTermCriteria termCrit);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvSVM_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvSVM_new2_CvMat(
            IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvSVM_new2_Mat(
            IntPtr trainData, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, WCvSVMParams param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVM_delete(IntPtr model);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVM_get_default_grid(
            ref CvParamGrid grid, int paramId);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvParamGrid_check(CvParamGrid grid);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvSVM_train_CvMat(
            IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, WCvSVMParams param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvSVM_train_Mat(
            IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx,
            IntPtr sampleIdx, WCvSVMParams param);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvSVM_train_auto_CvMat(
            IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, WCvSVMParams param, int kFold, CvParamGrid cGrid,
            CvParamGrid gammaGrid, CvParamGrid pGrid, CvParamGrid nuGrid,
            CvParamGrid coefGrid, CvParamGrid degreeGrid, int balanced);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvSVM_train_auto_Mat(
            IntPtr model, IntPtr trainData, IntPtr responses, IntPtr varIdx,
            IntPtr sampleIdx, WCvSVMParams param, int kFold, CvParamGrid cGrid,
            CvParamGrid gammaGrid, CvParamGrid pGrid, CvParamGrid nuGrid,
            CvParamGrid coefGrid, CvParamGrid degreeGrid, int balanced);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvSVM_predict_CvMat1(IntPtr model, IntPtr sample, int returnDFVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvSVM_predict_CvMat2(IntPtr model, IntPtr sample, IntPtr results);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvSVM_predict_Mat1(IntPtr model, IntPtr sample, int returnDFVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvSVM_predict_Mat2(IntPtr model, IntPtr samples, IntPtr results);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* ml_CvSVM_get_support_vector(IntPtr model, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvSVM_get_support_vector_count(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvSVM_get_var_count(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVM_get_params(IntPtr model, ref WCvSVMParams p);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVM_clear(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVM_write(IntPtr model, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvSVM_read(IntPtr model, IntPtr storage, IntPtr node);
    }
}