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

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_Model_new_String")]
    public static extern ExceptionStatus dnn_Model_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_Model_new_String")]
    public static extern ExceptionStatus dnn_Model_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_Model_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_Model_new_String_Windows(model, config, out returnValue)
            : dnn_Model_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setInputSize(IntPtr model, Size size);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setInputMean(IntPtr model, Scalar mean);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setInputScale(IntPtr model, Scalar scale);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setInputCrop(IntPtr model, int crop);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setInputSwapRB(IntPtr model, int swapRB);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setInputParams(
        IntPtr model, double scale, Size size, Scalar mean, int swapRB, int crop);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus dnn_Model_setOutputNames(IntPtr model, string[] outNames, int outNamesLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_predict(IntPtr model, IntPtr frame, IntPtr outs);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setPreferableBackend(IntPtr model, int backendId);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_setPreferableTarget(IntPtr model, int targetId);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_Model_enableWinograd(IntPtr model, int useWinograd);

    // ------------------------------------------------------------------------
    // ClassificationModel
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_ClassificationModel_new_String")]
    public static extern ExceptionStatus dnn_ClassificationModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_ClassificationModel_new_String")]
    public static extern ExceptionStatus dnn_ClassificationModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_ClassificationModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_ClassificationModel_new_String_Windows(model, config, out returnValue)
            : dnn_ClassificationModel_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_ClassificationModel_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_ClassificationModel_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_ClassificationModel_setEnableSoftmaxPostProcessing(IntPtr model, int enable);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_ClassificationModel_getEnableSoftmaxPostProcessing(IntPtr model, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_ClassificationModel_classify(IntPtr model, IntPtr frame, out int classId, out float conf);

    // ------------------------------------------------------------------------
    // DetectionModel
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_DetectionModel_new_String")]
    public static extern ExceptionStatus dnn_DetectionModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_DetectionModel_new_String")]
    public static extern ExceptionStatus dnn_DetectionModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_DetectionModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_DetectionModel_new_String_Windows(model, config, out returnValue)
            : dnn_DetectionModel_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_DetectionModel_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_DetectionModel_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_DetectionModel_setNmsAcrossClasses(IntPtr model, int value);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_DetectionModel_getNmsAcrossClasses(IntPtr model, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_DetectionModel_detect(
        IntPtr model, IntPtr frame, IntPtr classIds, IntPtr confidences, IntPtr boxes,
        float confThreshold, float nmsThreshold);

    // ------------------------------------------------------------------------
    // SegmentationModel
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_SegmentationModel_new_String")]
    public static extern ExceptionStatus dnn_SegmentationModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_SegmentationModel_new_String")]
    public static extern ExceptionStatus dnn_SegmentationModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_SegmentationModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_SegmentationModel_new_String_Windows(model, config, out returnValue)
            : dnn_SegmentationModel_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_SegmentationModel_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_SegmentationModel_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_SegmentationModel_segment(IntPtr model, IntPtr frame, IntPtr mask);

    // ------------------------------------------------------------------------
    // KeypointsModel
    // ------------------------------------------------------------------------

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_KeypointsModel_new_String")]
    public static extern ExceptionStatus dnn_KeypointsModel_new_String_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string model,
        [MarshalAs(StringUnmanagedTypeNotWindows)] string? config,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "dnn_KeypointsModel_new_String")]
    public static extern ExceptionStatus dnn_KeypointsModel_new_String_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string model,
        [MarshalAs(StringUnmanagedTypeWindows)] string? config,
        out IntPtr returnValue);

    public static ExceptionStatus dnn_KeypointsModel_new_String(string model, string? config, out IntPtr returnValue)
        => IsWindows()
            ? dnn_KeypointsModel_new_String_Windows(model, config, out returnValue)
            : dnn_KeypointsModel_new_String_NotWindows(model, config, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_KeypointsModel_new_Net(IntPtr network, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_KeypointsModel_delete(IntPtr model);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_KeypointsModel_estimate(IntPtr model, IntPtr frame, IntPtr keypoints, float thresh);
}
