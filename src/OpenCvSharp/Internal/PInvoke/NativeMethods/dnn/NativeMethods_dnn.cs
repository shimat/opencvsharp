using System.Runtime.CompilerServices;
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

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromTensorflow"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromTensorflow_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        int engine,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromTensorflow"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromTensorflow_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        int engine,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromTensorflow(string model, string? config, int engine, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNetFromTensorflow_Windows(model, config, engine, out returnValue);
        return dnn_readNetFromTensorflow_NotWindows(model, config, engine, out returnValue);
    }

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromTensorflow_InputArray"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus dnn_readNetFromTensorflow(
        byte* bufferModel, IntPtr modelDataLength,
        byte* bufferConfig, IntPtr configDataLength,
        int engine,
        out IntPtr returnValue);

    // readNet

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNet"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNet_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string config,
        [MarshalAs(UnmanagedType.LPStr)] string framework,
        int engine,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNet"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNet_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string config,
        [MarshalAs(UnmanagedType.LPStr)] string framework,
        int engine,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNet(string model, string config, string framework, int engine, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNet_Windows(model, config, framework, engine, out returnValue);
        return dnn_readNet_NotWindows(model, config, framework, engine, out returnValue);
    }

    // readNetFromModelOptimizer

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromModelOptimizer"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromModelOptimizer_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string xml,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string bin,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromModelOptimizer"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromModelOptimizer_Windows(
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

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromONNX"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromONNX_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string onnxFile,
        int engine,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromONNX"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromONNX_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string onnxFile,
        int engine,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromONNX(string onnxFile, int engine, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readNetFromONNX_Windows(onnxFile, engine, out returnValue);
        return dnn_readNetFromONNX_NotWindows(onnxFile, engine, out returnValue);
    }

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromONNX_InputArray"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus dnn_readNetFromONNX(
        byte* buffer, IntPtr sizeBuffer, int engine, out IntPtr returnValue);

    // readTensorFromONNX

    [LibraryImport(DllExtern, EntryPoint = "dnn_readTensorFromONNX"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readTensorFromONNX_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string path, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readTensorFromONNX"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readTensorFromONNX_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string path, out IntPtr returnValue);

    public static ExceptionStatus dnn_readTensorFromONNX(string path, out IntPtr returnValue)
    {
        if (IsWindows())
            return dnn_readTensorFromONNX_Windows(path, out returnValue);
        return dnn_readTensorFromONNX_NotWindows(path, out returnValue);
    }

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_blobFromImage(
        IntPtr image, double scaleFactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_blobFromImages(
        IntPtr[] images, int imagesLength, double scaleFactor, Size size, Scalar mean, int swapRB, int crop, out IntPtr returnValue);

    // writeTextGraph

    [LibraryImport(DllExtern, EntryPoint = "dnn_writeTextGraph"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_writeTextGraph_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model, [MarshalAs(StringUnmanagedTypeNotWindows)] string output);

    [LibraryImport(DllExtern, EntryPoint = "dnn_writeTextGraph"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_writeTextGraph_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model, [MarshalAs(StringUnmanagedTypeWindows)] string output);

    public static ExceptionStatus dnn_writeTextGraph(string path, string output)
    {
        if (IsWindows())
            return dnn_writeTextGraph_Windows(path, output);
        return dnn_writeTextGraph_NotWindows(path, output);
    }

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_NMSBoxes_Rect(
        IntPtr bboxes, IntPtr scores,
        float score_threshold, float nms_threshold,
        IntPtr indices, float eta, int top_k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_NMSBoxes_Rect2d(
        IntPtr bboxes, IntPtr scores,
        float score_threshold, float nms_threshold,
        IntPtr indices, float eta, int top_k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_NMSBoxes_RotatedRect(
        IntPtr bboxes, IntPtr scores,
        float score_threshold, float nms_threshold,
        IntPtr indices, float eta, int top_k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_resetMyriadDevice();

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_getAvailableTargets(int be, IntPtr targets);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_getAvailableBackends(IntPtr backends, IntPtr targets);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_enableModelDiagnostics(int isDiagnosticsMode);

    // readNetFromTFLite

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromTFLite"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromTFLite_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model, int engine, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromTFLite"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_readNetFromTFLite_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model, int engine, out IntPtr returnValue);

    public static ExceptionStatus dnn_readNetFromTFLite(string model, int engine, out IntPtr returnValue)
        => IsWindows()
            ? dnn_readNetFromTFLite_Windows(model, engine, out returnValue)
            : dnn_readNetFromTFLite_NotWindows(model, engine, out returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_readNetFromTFLite_InputArray"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus dnn_readNetFromTFLite(
        byte* bufferModel, IntPtr lenModel, int engine, out IntPtr returnValue);

    // blobFromImageWithParams

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_blobFromImageWithParams(
        IntPtr image, Scalar scalefactor, Size size, Scalar mean,
        int swapRB, int ddepth, int datalayout, int paddingmode, Scalar borderValue, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_blobFromImagesWithParams(
        IntPtr[] images, int imagesLength, Scalar scalefactor, Size size, Scalar mean,
        int swapRB, int ddepth, int datalayout, int paddingmode, Scalar borderValue, out IntPtr returnValue);

    // imagesFromBlob

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_imagesFromBlob(IntPtr blob, IntPtr images);

    // NMSBoxesBatched

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_NMSBoxesBatched_Rect(
        IntPtr bboxes, IntPtr scores, IntPtr classIds,
        float score_threshold, float nms_threshold, IntPtr indices, float eta, int top_k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_NMSBoxesBatched_Rect2d(
        IntPtr bboxes, IntPtr scores, IntPtr classIds,
        float score_threshold, float nms_threshold, IntPtr indices, float eta, int top_k);

    // softNMSBoxes

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_softNMSBoxes_Rect(
        IntPtr bboxes, IntPtr scores, IntPtr updated_scores,
        float score_threshold, float nms_threshold, IntPtr indices, UIntPtr top_k, float sigma, int method);
}
