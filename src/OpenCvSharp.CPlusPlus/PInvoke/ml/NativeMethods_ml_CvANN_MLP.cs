using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        // ANN_MLP_TrainParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_TrainParams_new1(
            out WCvANN_MLP_TrainParams result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_ANN_MLP_TrainParams_new2(
            CvTermCriteria termCrit, int trainMethod, double param1, double param2,
            out WCvANN_MLP_TrainParams result);

        // ANN_MLP
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvANN_MLP_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvANN_MLP_new2_CvMat(
            IntPtr layerSizes, int activFunc, double fParam1, double fParam2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvANN_MLP_new2_Mat(
            IntPtr layerSizes, int activFunc, double fParam1, double fParam2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvANN_MLP_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvANN_MLP_create_CvMat(
            IntPtr obj, IntPtr layerSizes, int activFunc, double fParam1, double fParam2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvANN_MLP_create_Mat(
            IntPtr obj, IntPtr layerSizes, int activFunc, double fParam1, double fParam2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvANN_MLP_train_CvMat(
            IntPtr obj, IntPtr inputs, IntPtr outputs, IntPtr sampleWeights,
            IntPtr sampleIdx, WCvANN_MLP_TrainParams param, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvANN_MLP_train_Mat(
            IntPtr obj, IntPtr inputs, IntPtr outputs, IntPtr sampleWeights,
            IntPtr sampleIdx, WCvANN_MLP_TrainParams param, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvANN_MLP_predict_CvMat(
            IntPtr obj, IntPtr inputs, IntPtr outputs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvANN_MLP_predict_Mat(
            IntPtr obj, IntPtr inputs, IntPtr outputs);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvANN_MLP_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvANN_MLP_read(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvANN_MLP_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvANN_MLP_get_layer_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvANN_MLP_get_layer_sizes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* ml_CvANN_MLP_get_weights(IntPtr obj, int layer);

    }
}