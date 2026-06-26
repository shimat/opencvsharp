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
    // ------------------------------------------------------------------------
    // TextRecognitionModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_TextRecognitionModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_setDecodeType(
        IntPtr model, [MarshalAs(UnmanagedType.LPStr)] string decodeType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_getDecodeType(IntPtr model, IntPtr outString);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_setDecodeOptsCTCPrefixBeamSearch(
        IntPtr model, int beamSize, int vocPruneSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_setVocabulary(
        IntPtr model, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] vocabulary, int vocabularyLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_getVocabulary(IntPtr model, IntPtr outVec);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextRecognitionModel_recognize(IntPtr model, IntPtr frame, IntPtr outString);

    // ------------------------------------------------------------------------
    // TextDetectionModel (base; shared by EAST and DB)
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_detect(
        IntPtr model, IntPtr frame, IntPtr detections, IntPtr confidences);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_detectTextRectangles(
        IntPtr model, IntPtr frame, IntPtr detections, IntPtr confidences);

    // ------------------------------------------------------------------------
    // TextDetectionModel_EAST
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_TextDetectionModel_EAST_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_setConfidenceThreshold(IntPtr model, float confThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_getConfidenceThreshold(IntPtr model, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_setNMSThreshold(IntPtr model, float nmsThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_EAST_getNMSThreshold(IntPtr model, out float returnValue);

    // ------------------------------------------------------------------------
    // TextDetectionModel_DB
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_TextDetectionModel_DB_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_setBinaryThreshold(IntPtr model, float binaryThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_getBinaryThreshold(IntPtr model, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_setPolygonThreshold(IntPtr model, float polygonThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_getPolygonThreshold(IntPtr model, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_setUnclipRatio(IntPtr model, double unclipRatio);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_getUnclipRatio(IntPtr model, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_setMaxCandidates(IntPtr model, int maxCandidates);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_TextDetectionModel_DB_getMaxCandidates(IntPtr model, out int returnValue);
}
