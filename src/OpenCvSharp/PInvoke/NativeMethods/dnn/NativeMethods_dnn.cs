using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNetFromDarknet(
            [MarshalAs(StringUnmanagedType)] string cfgFile, [MarshalAs(UnmanagedType.LPStr)] string? darknetModel, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNetFromCaffe(
            [MarshalAs(StringUnmanagedType)] string prototxt, [MarshalAs(UnmanagedType.LPStr)] string? caffeModel, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNetFromTensorflow(
            [MarshalAs(StringUnmanagedType)] string model, [MarshalAs(UnmanagedType.LPStr)] string? config, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNetFromTorch(
            [MarshalAs(StringUnmanagedType)] string model, int isBinary, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNet(
            [MarshalAs(StringUnmanagedType)] string model, [MarshalAs(UnmanagedType.LPStr)] string config, [MarshalAs(UnmanagedType.LPStr)] string framework, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readTorchBlob(
            [MarshalAs(StringUnmanagedType)] string filename, int isBinary, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNetFromModelOptimizer(
            [MarshalAs(StringUnmanagedType)] string xml, [MarshalAs(UnmanagedType.LPStr)] string bin, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readNetFromONNX(
            [MarshalAs(StringUnmanagedType)] string onnxFile, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_readTensorFromONNX(
            [MarshalAs(StringUnmanagedType)] string path, out IntPtr returnValue);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_blobFromImage(
            IntPtr image, double scalefactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_blobFromImages(
            IntPtr[] images, int imagesLength, double scalefactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_shrinkCaffeModel(
            [MarshalAs(StringUnmanagedType)] string src, [MarshalAs(UnmanagedType.LPStr)] string dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_writeTextGraph(
            [MarshalAs(StringUnmanagedType)] string model, [MarshalAs(UnmanagedType.LPStr)] string output);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_NMSBoxes_Rect(
            IntPtr bboxes, IntPtr scores,
            float score_threshold, float nms_threshold,
            IntPtr indices, float eta, int top_k);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_NMSBoxes_Rect2d(
            IntPtr bboxes, IntPtr scores,
            float score_threshold, float nms_threshold,
            IntPtr indices, float eta, int top_k);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern ExceptionStatus dnn_NMSBoxes_RotatedRect(
            IntPtr bboxes, IntPtr scores,
            float score_threshold, float nms_threshold,
            IntPtr indices, float eta, int top_k);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_resetMyriadDevice();
    }
}
