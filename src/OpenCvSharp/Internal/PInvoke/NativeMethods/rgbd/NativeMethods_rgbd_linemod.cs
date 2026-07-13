using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_ColorGradient_create(
        float weakThreshold, nuint numFeatures, float strongThreshold, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_DepthNormal_create(
        int distanceThreshold, int differenceThreshold, nuint numFeatures, int extractThreshold, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Modality_create(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string modalityType, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Modality_createFromFileNode(
        OpenCvSafeHandle node, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Ptr_Modality_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Ptr_Modality_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Modality_name(OpenCvSafeHandle obj, IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Modality_process(
        OpenCvSafeHandle obj, OpenCvSafeHandle src, OpenCvSafeHandle mask, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Modality_read(OpenCvSafeHandle obj, OpenCvSafeHandle node);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Modality_write(OpenCvSafeHandle obj, OpenCvSafeHandle fs);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_ColorGradient_get(
        OpenCvSafeHandle obj, out float weakThreshold, out nuint numFeatures, out float strongThreshold);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_DepthNormal_get(
        OpenCvSafeHandle obj, out int distanceThreshold, out int differenceThreshold,
        out nuint numFeatures, out int extractThreshold);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Ptr_QuantizedPyramid_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Ptr_QuantizedPyramid_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_QuantizedPyramid_quantize(OpenCvSafeHandle obj, OpenCvSafeHandle dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_QuantizedPyramid_pyrDown(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_QuantizedPyramid_extractTemplate(
        OpenCvSafeHandle obj, out int width, out int height, out int pyramidLevel, IntPtr features, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_new(
        IntPtr[] modalities, int modalitiesLength, int[] tPyramid, int tPyramidLength, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_newEmpty(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_getDefaultLINE(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_getDefaultLINEMOD(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_addTemplate(
        OpenCvSafeHandle obj, IntPtr sources, [MarshalAs(UnmanagedType.LPUTF8Str)] string classId,
        OpenCvSafeHandle objectMask, out Rect boundingBox, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_addSyntheticTemplate(
        OpenCvSafeHandle obj, IntPtr headers, IntPtr features,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string classId, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_match(
        OpenCvSafeHandle obj, IntPtr sources, float threshold, IntPtr values, IntPtr classIds,
        IntPtr filterClassIds, IntPtr quantizedImages, IntPtr masks);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_getT(OpenCvSafeHandle obj, int level, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_pyramidLevels(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_numTemplates(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_numTemplatesByClass(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string classId, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_numClasses(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_classIds(OpenCvSafeHandle obj, IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_getTemplates(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string classId,
        int templateId, IntPtr headers, IntPtr features);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_getModalitiesSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_getModality(OpenCvSafeHandle obj, int index, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_read(OpenCvSafeHandle obj, OpenCvSafeHandle node);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_write(OpenCvSafeHandle obj, OpenCvSafeHandle fs);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_readClass(
        OpenCvSafeHandle obj, OpenCvSafeHandle node,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string classIdOverride, IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_writeClass(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string classId, OpenCvSafeHandle fs);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_readClasses(
        OpenCvSafeHandle obj, IntPtr classIds, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_linemod_Detector_writeClasses(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);
}
