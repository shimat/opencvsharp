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
    // Model (base class)
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_Model_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_Model_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_Model_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_Model_new_String_Windows(model, config, out returnValue)
            : dnn_Model_new_String_NotWindows(model, config, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputSize(IntPtr model, Size size);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputMean(IntPtr model, Scalar mean);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputScale(IntPtr model, Scalar scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputCrop(IntPtr model, int crop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputSwapRB(IntPtr model, int swapRB);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputParams(
        IntPtr model, double scale, Size size, Scalar mean, int swapRB, int crop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setOutputNames(IntPtr model, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] outNames, int outNamesLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_predict(IntPtr model, IntPtr frame, IntPtr outs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setPreferableBackend(IntPtr model, int backendId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setPreferableTarget(IntPtr model, int targetId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_enableWinograd(IntPtr model, int useWinograd);

    // ------------------------------------------------------------------------
    // ClassificationModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_ClassificationModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_ClassificationModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_ClassificationModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_ClassificationModel_new_String_Windows(model, config, out returnValue)
            : dnn_ClassificationModel_new_String_NotWindows(model, config, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_setEnableSoftmaxPostProcessing(IntPtr model, int enable);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_getEnableSoftmaxPostProcessing(IntPtr model, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_classify(IntPtr model, IntPtr frame, out int classId, out float conf);

    // ------------------------------------------------------------------------
    // DetectionModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_DetectionModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_DetectionModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_DetectionModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_DetectionModel_new_String_Windows(model, config, out returnValue)
            : dnn_DetectionModel_new_String_NotWindows(model, config, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_setNmsAcrossClasses(IntPtr model, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_getNmsAcrossClasses(IntPtr model, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_detect(
        IntPtr model, IntPtr frame, IntPtr classIds, IntPtr confidences, IntPtr boxes,
        float confThreshold, float nmsThreshold);

    // ------------------------------------------------------------------------
    // SegmentationModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_SegmentationModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_SegmentationModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_SegmentationModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_SegmentationModel_new_String_Windows(model, config, out returnValue)
            : dnn_SegmentationModel_new_String_NotWindows(model, config, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_segment(IntPtr model, IntPtr frame, IntPtr mask);

    // ------------------------------------------------------------------------
    // KeypointsModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_KeypointsModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "dnn_KeypointsModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_KeypointsModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_KeypointsModel_new_String_Windows(model, config, out returnValue)
            : dnn_KeypointsModel_new_String_NotWindows(model, config, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_estimate(IntPtr model, IntPtr frame, IntPtr keypoints, float thresh);
}
