using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal; 

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    // readNetFromTensorflow

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromTensorflow")]
    public static extern ExceptionStatus dnn_readNetFromTensorflow_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model, 
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromTensorflow")]
    public static extern ExceptionStatus dnn_readNetFromTensorflow_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model, 
        [MarshalAs(StringUnmanagedTypeWindows)] string? config, 
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromTensorflow(string model, string? config, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNetFromTensorflow_Windows(model, config, out returnValue);
        return dnn_readNetFromTensorflow_NotWindows(model, config, out returnValue);
    }

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromTensorflow_InputArray")]
    public static extern unsafe ExceptionStatus dnn_readNetFromTensorflow(
        byte* bufferModel, IntPtr modelDataLength,
        byte* bufferConfig, IntPtr configDataLength,
        out IntPtr returnValue);

    // readNet

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNet")]
    public static extern ExceptionStatus dnn_readNet_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string config, 
        [MarshalAs(UnmanagedType.LPStr)] string framework, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNet")]
    public static extern ExceptionStatus dnn_readNet_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model, 
        [MarshalAs(StringUnmanagedTypeWindows)] string config, 
        [MarshalAs(UnmanagedType.LPStr)] string framework,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNet(string model, string config, string framework, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNet_Windows(model, config, framework, out returnValue);
        return dnn_readNet_NotWindows(model, config, framework, out returnValue);
    }

    // readNetFromModelOptimizer

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromModelOptimizer")]
    public static extern ExceptionStatus dnn_readNetFromModelOptimizer_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string xml,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string bin,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromModelOptimizer")]
    public static extern ExceptionStatus dnn_readNetFromModelOptimizer_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string xml,
        [MarshalAs(StringUnmanagedTypeWindows)] string bin, 
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromModelOptimizer(string xml, string bin, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNetFromModelOptimizer_Windows(xml, bin, out returnValue);
        return dnn_readNetFromModelOptimizer_NotWindows(xml, bin, out returnValue);
    }

    // readNetFromONNX

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromONNX")]
    public static extern ExceptionStatus dnn_readNetFromONNX_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string onnxFile, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromONNX")]
    public static extern ExceptionStatus dnn_readNetFromONNX_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string onnxFile,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromONNX(string onnxFile, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNetFromONNX_Windows(onnxFile, out returnValue);
        return dnn_readNetFromONNX_NotWindows(onnxFile, out returnValue);
    }

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromONNX_InputArray")]
    public static extern unsafe ExceptionStatus dnn_readNetFromONNX(
        byte* buffer, IntPtr sizeBuffer, out IntPtr returnValue);

    // readTensorFromONNX

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readTensorFromONNX")]
    public static extern ExceptionStatus dnn_readTensorFromONNX_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string path, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readTensorFromONNX")]
    public static extern ExceptionStatus dnn_readTensorFromONNX_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string path, out IntPtr returnValue);

    public static ExceptionStatus dnn_readTensorFromONNX(string path, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readTensorFromONNX_Windows(path, out returnValue);
        return dnn_readTensorFromONNX_NotWindows(path, out returnValue);
    }

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_blobFromImage(
        IntPtr image, double scaleFactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_blobFromImages(
        IntPtr[] images, int imagesLength, double scaleFactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

    // writeTextGraph

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_writeTextGraph")]
    public static extern ExceptionStatus dnn_writeTextGraph_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model, [MarshalAs(StringUnmanagedTypeNotWindows)] string output);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_writeTextGraph")]
    public static extern ExceptionStatus dnn_writeTextGraph_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model, [MarshalAs(StringUnmanagedTypeWindows)] string output);

    public static ExceptionStatus dnn_writeTextGraph(string path, string output)
    {
        if (IsWindows())
            return dnn_writeTextGraph_Windows(path, output);
        return dnn_writeTextGraph_NotWindows(path, output);
    }

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_NMSBoxes_Rect(
        IntPtr bboxes, IntPtr scores,
        float score_threshold, float nms_threshold,
        IntPtr indices, float eta, int top_k);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_NMSBoxes_Rect2d(
        IntPtr bboxes, IntPtr scores,
        float score_threshold, float nms_threshold,
        IntPtr indices, float eta, int top_k);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_NMSBoxes_RotatedRect(
        IntPtr bboxes, IntPtr scores,
        float score_threshold, float nms_threshold,
        IntPtr indices, float eta, int top_k);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_resetMyriadDevice();

    // readNetFromTFLite

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromTFLite")]
    public static extern ExceptionStatus dnn_readNetFromTFLite_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_readNetFromTFLite")]
    public static extern ExceptionStatus dnn_readNetFromTFLite_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model, out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromTFLite(string model, out IntPtr returnValue)
        => IsWindows()
            ? dnn_readNetFromTFLite_Windows(model, out returnValue)
            : dnn_readNetFromTFLite_NotWindows(model, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dnn_readNetFromTFLite_InputArray")]
    public static extern unsafe ExceptionStatus dnn_readNetFromTFLite(
        byte* bufferModel, IntPtr lenModel, out IntPtr returnValue);

    // blobFromImageWithParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_blobFromImageWithParams(
        IntPtr image, Scalar scalefactor, Size size, Scalar mean,
        int swapRB, int ddepth, int datalayout, int paddingmode, Scalar borderValue, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_blobFromImagesWithParams(
        IntPtr[] images, int imagesLength, Scalar scalefactor, Size size, Scalar mean,
        int swapRB, int ddepth, int datalayout, int paddingmode, Scalar borderValue, out IntPtr returnValue);

    // imagesFromBlob

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_imagesFromBlob(IntPtr blob, IntPtr images);

    // NMSBoxesBatched

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_NMSBoxesBatched_Rect(
        IntPtr bboxes, IntPtr scores, IntPtr classIds,
        float score_threshold, float nms_threshold, IntPtr indices, float eta, int top_k);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_NMSBoxesBatched_Rect2d(
        IntPtr bboxes, IntPtr scores, IntPtr classIds,
        float score_threshold, float nms_threshold, IntPtr indices, float eta, int top_k);

    // softNMSBoxes

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_softNMSBoxes_Rect(
        IntPtr bboxes, IntPtr scores, IntPtr updated_scores,
        float score_threshold, float nms_threshold, IntPtr indices, UIntPtr top_k, float sigma, int method);
}
