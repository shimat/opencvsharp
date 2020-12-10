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
        // readNetFromDarknet

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromDarknet")]
        public static extern ExceptionStatus dnn_readNetFromDarknet_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string cfgFile, 
            [MarshalAs(StringUnmanagedTypeNotWindows)] string? darknetModel, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromDarknet")]
        public static extern ExceptionStatus dnn_readNetFromDarknet_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string cfgFile, 
            [MarshalAs(StringUnmanagedTypeWindows)] string? darknetModel,
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNetFromDarknet(string cfgFile, string? darknetModel, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNetFromDarknet_Windows(cfgFile, darknetModel, out returnValue);
            return dnn_readNetFromDarknet_NotWindows(cfgFile, darknetModel, out returnValue);
        }

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromDarknet_InputArray")]
        public static extern ExceptionStatus dnn_readNetFromDarknet(byte[] cfgFileData, IntPtr cfgFileDataLength,
            byte[] darknetModelData, IntPtr darknetModelDataLength,
            out IntPtr returnValue);

        // readNetFromCaffe

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromCaffe")]
        public static extern ExceptionStatus dnn_readNetFromCaffe_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string prototxt, 
            [MarshalAs(StringUnmanagedTypeNotWindows)] string? caffeModel,
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromCaffe")]
        public static extern ExceptionStatus dnn_readNetFromCaffe_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string prototxt, 
            [MarshalAs(StringUnmanagedTypeWindows)] string? caffeModel,
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNetFromCaffe(string prototxt, string? caffeModel, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNetFromCaffe_Windows(prototxt, caffeModel, out returnValue);
            return dnn_readNetFromCaffe_NotWindows(prototxt, caffeModel, out returnValue);
        }

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromCaffe_InputArray")]
        public static extern ExceptionStatus dnn_readNetFromCaffe(byte[] prototxt, IntPtr prototxtLength,
            byte[] caffeModel, IntPtr caffeModelLength,
            out IntPtr returnValue);

        // readNetFromTensorflow

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromTensorflow")]
        public static extern ExceptionStatus dnn_readNetFromTensorflow_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string model, 
            [MarshalAs(StringUnmanagedTypeNotWindows)] string? config, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromTensorflow")]
        public static extern ExceptionStatus dnn_readNetFromTensorflow_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string model, 
            [MarshalAs(StringUnmanagedTypeWindows)] string? config, 
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNetFromTensorflow(string model, string? config, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNetFromTensorflow_Windows(model, config, out returnValue);
            return dnn_readNetFromTensorflow_NotWindows(model, config, out returnValue);
        }

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromTensorflow_InputArray")]
        public static extern ExceptionStatus dnn_readNetFromTensorflow(byte[] modelData, IntPtr modelDataLength,
            byte[] configData, IntPtr configDataLength,
            out IntPtr returnValue);

        // readNetFromTorch

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromTorch")]
        public static extern ExceptionStatus dnn_readNetFromTorch_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string model, 
            int isBinary,
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromTorch")]
        public static extern ExceptionStatus dnn_readNetFromTorch_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string model,
            int isBinary,
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNetFromTorch(string model, int isBinary, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNetFromTorch_Windows(model, isBinary, out returnValue);
            return dnn_readNetFromTorch_NotWindows(model, isBinary, out returnValue);
        }

        // readNet

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNet")]
        public static extern ExceptionStatus dnn_readNet_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
            [MarshalAs(StringUnmanagedTypeNotWindows)] string config, 
            [MarshalAs(UnmanagedType.LPStr)] string framework, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNet")]
        public static extern ExceptionStatus dnn_readNet_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string model, 
            [MarshalAs(StringUnmanagedTypeWindows)] string config, 
            [MarshalAs(UnmanagedType.LPStr)] string framework,
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNet(string model, string config, string framework, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNet_Windows(model, config, framework, out returnValue);
            return dnn_readNet_NotWindows(model, config, framework, out returnValue);
        }

        // readTorchBlob

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readTorchBlob")]
        public static extern ExceptionStatus dnn_readTorchBlob_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string fileName,
            int isBinary, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readTorchBlob")]
        public static extern ExceptionStatus dnn_readTorchBlob_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string fileName,
            int isBinary,
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readTorchBlob(string fileName, int isBinary, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readTorchBlob_Windows(fileName, isBinary, out returnValue);
            return dnn_readTorchBlob_NotWindows(fileName, isBinary, out returnValue);
        }

        // readNetFromModelOptimizer

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromModelOptimizer")]
        public static extern ExceptionStatus dnn_readNetFromModelOptimizer_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string xml,
            [MarshalAs(StringUnmanagedTypeNotWindows)] string bin,
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromModelOptimizer")]
        public static extern ExceptionStatus dnn_readNetFromModelOptimizer_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string xml,
            [MarshalAs(StringUnmanagedTypeWindows)] string bin, 
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNetFromModelOptimizer(string xml, string bin, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNetFromModelOptimizer_Windows(xml, bin, out returnValue);
            return dnn_readNetFromModelOptimizer_NotWindows(xml, bin, out returnValue);
        }

        // readNetFromONNX

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromONNX")]
        public static extern ExceptionStatus dnn_readNetFromONNX_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string onnxFile, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readNetFromONNX")]
        public static extern ExceptionStatus dnn_readNetFromONNX_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string onnxFile,
            out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readNetFromONNX(string onnxFile, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readNetFromONNX_Windows(onnxFile, out returnValue);
            return dnn_readNetFromONNX_NotWindows(onnxFile, out returnValue);
        }

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromONNX_InputArray")]
        public static extern ExceptionStatus dnn_readNetFromONNX(byte[] onnxFileData, IntPtr onnxFileLength, out IntPtr returnValue);

        // readTensorFromONNX

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readTensorFromONNX")]
        public static extern ExceptionStatus dnn_readTensorFromONNX_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string path, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
             EntryPoint = "dnn_readTensorFromONNX")]
        public static extern ExceptionStatus dnn_readTensorFromONNX_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string path, out IntPtr returnValue);

        [Pure]
        public static ExceptionStatus dnn_readTensorFromONNX(string path, out IntPtr returnValue)
        {
            if (IsWindows())
                return dnn_readTensorFromONNX_Windows(path, out returnValue);
            return dnn_readTensorFromONNX_NotWindows(path, out returnValue);
        }

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_blobFromImage(
            IntPtr image, double scaleFactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_blobFromImages(
            IntPtr[] images, int imagesLength, double scaleFactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

        // shrinkCaffeModel

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_shrinkCaffeModel_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string src, [MarshalAs(StringUnmanagedTypeNotWindows)] string dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_shrinkCaffeModel_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string src, [MarshalAs(StringUnmanagedTypeWindows)] string dst);

        [Pure]
        public static ExceptionStatus dnn_shrinkCaffeModel(string src, string dst)
        {
            if (IsWindows())
                return dnn_shrinkCaffeModel_Windows(src, dst);
            return dnn_shrinkCaffeModel_NotWindows(src, dst);
        }

        // writeTextGraph

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_writeTextGraph_NotWindows(
            [MarshalAs(StringUnmanagedTypeNotWindows)] string model, [MarshalAs(StringUnmanagedTypeNotWindows)] string output);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern ExceptionStatus dnn_writeTextGraph_Windows(
            [MarshalAs(StringUnmanagedTypeWindows)] string model, [MarshalAs(StringUnmanagedTypeWindows)] string output);

        [Pure]
        public static ExceptionStatus dnn_writeTextGraph(string path, string output)
        {
            if (IsWindows())
                return dnn_writeTextGraph_Windows(path, output);
            return dnn_writeTextGraph_NotWindows(path, output);
        }

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
