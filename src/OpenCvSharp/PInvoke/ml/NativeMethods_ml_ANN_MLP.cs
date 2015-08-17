using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setTrainMethod(IntPtr obj, int method, double param1, double param2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_ANN_MLP_getTrainMethod(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setActivationFunction(IntPtr obj, int type, double param1, double param2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setLayerSizes(IntPtr obj, IntPtr layerSizes);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_ANN_MLP_getLayerSizes(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern TermCriteria ml_ANN_MLP_getTermCriteria(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setTermCriteria(IntPtr obj, TermCriteria val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getBackpropWeightScale(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setBackpropWeightScale(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getBackpropMomentumScale(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setBackpropMomentumScale(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getRpropDW0(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setRpropDW0(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getRpropDWPlus(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setRpropDWPlus(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getRpropDWMinus(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setRpropDWMinus(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getRpropDWMin(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setRpropDWMin(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ml_ANN_MLP_getRpropDWMax(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_setRpropDWMax(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_ANN_MLP_getWeights(IntPtr obj, int layerIdx);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_ANN_MLP_create();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_Ptr_ANN_MLP_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_Ptr_ANN_MLP_get(IntPtr obj);
    }
}