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
    public static partial ExceptionStatus dnn_Model_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputSize(OpenCvSafeHandle model, Size size);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputMean(OpenCvSafeHandle model, Scalar mean);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputScale(OpenCvSafeHandle model, Scalar scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputCrop(OpenCvSafeHandle model, int crop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputSwapRB(OpenCvSafeHandle model, int swapRB);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setInputParams(
        OpenCvSafeHandle model, double scale, Size size, Scalar mean, int swapRB, int crop);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setOutputNames(OpenCvSafeHandle model, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] outNames, int outNamesLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_predict(OpenCvSafeHandle model, IntPtr frame, IntPtr outs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setPreferableBackend(OpenCvSafeHandle model, int backendId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_setPreferableTarget(OpenCvSafeHandle model, int targetId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_Model_enableWinograd(OpenCvSafeHandle model, int useWinograd);

    // ------------------------------------------------------------------------
    // ClassificationModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_ClassificationModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_setEnableSoftmaxPostProcessing(OpenCvSafeHandle model, int enable);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_getEnableSoftmaxPostProcessing(OpenCvSafeHandle model, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_ClassificationModel_classify(OpenCvSafeHandle model, IntPtr frame, out int classId, out float conf);

    // ------------------------------------------------------------------------
    // DetectionModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_DetectionModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_setNmsAcrossClasses(OpenCvSafeHandle model, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_getNmsAcrossClasses(OpenCvSafeHandle model, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_DetectionModel_detect(
        OpenCvSafeHandle model, IntPtr frame, IntPtr classIds, IntPtr confidences, IntPtr boxes,
        float confThreshold, float nmsThreshold);

    // ------------------------------------------------------------------------
    // SegmentationModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_SegmentationModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_SegmentationModel_segment(OpenCvSafeHandle model, IntPtr frame, IntPtr mask);

    // ------------------------------------------------------------------------
    // KeypointsModel
    // ------------------------------------------------------------------------

    [LibraryImport(DllExtern, EntryPoint = "dnn_KeypointsModel_new_String"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_new_String(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string model,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? config,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_new_Net(IntPtr network, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_delete(IntPtr model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_KeypointsModel_estimate(OpenCvSafeHandle model, IntPtr frame, IntPtr keypoints, float thresh);
}
