using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromDarknet(
            [MarshalAs(UnmanagedType.LPStr)] string cfgFile, [MarshalAs(UnmanagedType.LPStr)] string darknetModel);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromCaffe(
            [MarshalAs(UnmanagedType.LPStr)] string prototxt, [MarshalAs(UnmanagedType.LPStr)] string caffeModel);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromTensorflow(
            [MarshalAs(UnmanagedType.LPStr)] string model, [MarshalAs(UnmanagedType.LPStr)] string config);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromTorch([MarshalAs(UnmanagedType.LPStr)] string model, int isBinary);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNet(
            [MarshalAs(UnmanagedType.LPStr)] string model, [MarshalAs(UnmanagedType.LPStr)] string config, [MarshalAs(UnmanagedType.LPStr)] string framework);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readTorchBlob([MarshalAs(UnmanagedType.LPStr)] string filename, int isBinary);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromModelOptimizer([MarshalAs(UnmanagedType.LPStr)] string xml, [MarshalAs(UnmanagedType.LPStr)] string bin);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromONNX([MarshalAs(UnmanagedType.LPStr)] string onnxFile);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readTensorFromONNX([MarshalAs(UnmanagedType.LPStr)] string path);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_blobFromImage(
            IntPtr image, double scalefactor, Size size, Scalar mean, int swapRB, int crop);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_blobFromImages(
            IntPtr[] images, int imagesLength, double scalefactor, Size size, Scalar mean, int swapRB, int crop);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_shrinkCaffeModel(
            [MarshalAs(UnmanagedType.LPStr)] string src, [MarshalAs(UnmanagedType.LPStr)] string dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_writeTextGraph([MarshalAs(UnmanagedType.LPStr)] string model, [MarshalAs(UnmanagedType.LPStr)] string output);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_NMSBoxes_Rect(
            IntPtr bboxes, IntPtr scores,
            float score_threshold, float nms_threshold,
            IntPtr indices, float eta, int top_k);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_NMSBoxes_Rect2d(
            IntPtr bboxes, IntPtr scores,
            float score_threshold, float nms_threshold,
            IntPtr indices, float eta, int top_k);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern void dnn_NMSBoxes_RotatedRect(
            IntPtr bboxes, IntPtr scores,
            float score_threshold, float nms_threshold,
            IntPtr indices, float eta, int top_k);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_resetMyriadDevice();
    }
}
