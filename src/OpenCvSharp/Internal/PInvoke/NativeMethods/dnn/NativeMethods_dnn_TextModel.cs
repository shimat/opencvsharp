using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    // ------------------------------------------------------------------------
    // TextRecognitionModel
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_TextRecognitionModel_new_String")]
    public static extern ExceptionStatus dnn_TextRecognitionModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_TextRecognitionModel_new_String")]
    public static extern ExceptionStatus dnn_TextRecognitionModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_TextRecognitionModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_TextRecognitionModel_new_String_Windows(model, config, out returnValue)
            : dnn_TextRecognitionModel_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_setDecodeType(
        IntPtr model, [MarshalAs(UnmanagedType.LPStr)] string decodeType);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_getDecodeType(IntPtr model, IntPtr outString);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_setDecodeOptsCTCPrefixBeamSearch(
        IntPtr model, int beamSize, int vocPruneSize);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_setVocabulary(
        IntPtr model, string[] vocabulary, int vocabularyLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_getVocabulary(IntPtr model, IntPtr outVec);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextRecognitionModel_recognize(IntPtr model, IntPtr frame, IntPtr outString);

    // ------------------------------------------------------------------------
    // TextDetectionModel (base; shared by EAST and DB)
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_detect(
        IntPtr model, IntPtr frame, IntPtr detections, IntPtr confidences);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_detectTextRectangles(
        IntPtr model, IntPtr frame, IntPtr detections, IntPtr confidences);

    // ------------------------------------------------------------------------
    // TextDetectionModel_EAST
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_TextDetectionModel_EAST_new_String")]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_TextDetectionModel_EAST_new_String")]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_TextDetectionModel_EAST_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_TextDetectionModel_EAST_new_String_Windows(model, config, out returnValue)
            : dnn_TextDetectionModel_EAST_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_setConfidenceThreshold(IntPtr model, float confThreshold);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_getConfidenceThreshold(IntPtr model, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_setNMSThreshold(IntPtr model, float nmsThreshold);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_EAST_getNMSThreshold(IntPtr model, out float returnValue);

    // ------------------------------------------------------------------------
    // TextDetectionModel_DB
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_TextDetectionModel_DB_new_String")]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_TextDetectionModel_DB_new_String")]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_TextDetectionModel_DB_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_TextDetectionModel_DB_new_String_Windows(model, config, out returnValue)
            : dnn_TextDetectionModel_DB_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_setBinaryThreshold(IntPtr model, float binaryThreshold);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_getBinaryThreshold(IntPtr model, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_setPolygonThreshold(IntPtr model, float polygonThreshold);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_getPolygonThreshold(IntPtr model, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_setUnclipRatio(IntPtr model, double unclipRatio);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_getUnclipRatio(IntPtr model, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_setMaxCandidates(IntPtr model, int maxCandidates);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_TextDetectionModel_DB_getMaxCandidates(IntPtr model, out int returnValue);
}
