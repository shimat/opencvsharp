using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Face;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region Utilities

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_getFacesHAAR(
        in InputArrayProxy image, in OutputArrayProxy faces, string cascadeName, out int returnValue);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_loadDatasetList(
        string imageList, string annotationList, IntPtr images, IntPtr annotations, out int returnValue);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_loadTrainingData1(
        string filename, IntPtr images, IntPtr facePoints, byte delim, float offset, out int returnValue);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_loadTrainingData2(
        string imageList, string groundTruth, IntPtr images, IntPtr facePoints, float offset, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_loadTrainingData3(
        IntPtr filenames, IntPtr landmarks, IntPtr images, out int returnValue);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_loadFacePoints(
        string filename, IntPtr points, float offset, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_drawFacemarks(
        in InputOutputArrayProxy image, in InputArrayProxy points, Scalar color);

    #endregion

    #region Facemark

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Facemark_loadModel(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string model);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_Facemark_fit(
        OpenCvSafeHandle obj, in InputArrayProxy image, in InputArrayProxy faces, IntPtr landmarks, out int returnValue);

    #endregion

    #region FacemarkTrain

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkTrain_addTrainingSample(
        OpenCvSafeHandle obj, in InputArrayProxy image, in InputArrayProxy landmarks, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkTrain_training(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkTrain_getFaces(
        OpenCvSafeHandle obj, in InputArrayProxy image, IntPtr faces, out int returnValue);

    // callback is a function pointer to a static, [UnmanagedCallersOnly] trampoline (see
    // FacemarkFaceDetectorBridge); userData is a GCHandle to the context rooting the real managed
    // detector, round-tripped opaquely through callbackData/face_Facemark_faceDetectorThunk.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkTrain_setFaceDetector(
        OpenCvSafeHandle obj, IntPtr callback, IntPtr userData,
        out IntPtr callbackData, out int returnValue);

    #endregion

    #region FacemarkLBF

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_create(IntPtr @params, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkLBF_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkLBF_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_write(OpenCvSafeHandle obj, IntPtr fs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_read(OpenCvSafeHandle obj, IntPtr fn);

    #region Params

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_getAll(
        IntPtr obj, out FacemarkLBFParamsData data, IntPtr cascadeFace, IntPtr modelFilename,
        IntPtr featsM, IntPtr radiusM, IntPtr pupils0, IntPtr pupils1);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_setAll(
        IntPtr obj, FacemarkLBFParamsData data, [MarshalAs(UnmanagedType.LPStr)] string cascadeFace,
        [MarshalAs(UnmanagedType.LPStr)] string modelFilename, IntPtr featsM, IntPtr radiusM, IntPtr pupils0, IntPtr pupils1);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_read(IntPtr obj, IntPtr fn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkLBF_Params_write(IntPtr obj, IntPtr fs);

    #endregion

    #endregion

    #region FacemarkAAM

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_create(IntPtr @params, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkAAM_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FacemarkAAM_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_write(OpenCvSafeHandle obj, IntPtr fs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_read(OpenCvSafeHandle obj, IntPtr fn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkAAM_fitConfig(
        OpenCvSafeHandle obj,
        in InputArrayProxy image,
        in InputArrayProxy roi,
        IntPtr landmarks,
        IntPtr[] rotations,
        Point2f[] translations,
        float[] scales,
        int[] modelScaleIndexes,
        int configLength,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkAAM_getData(
        OpenCvSafeHandle obj, IntPtr s0, out int returnValue);

    #region Params

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_getAll(
        IntPtr obj, out FacemarkAAMParamsData data, IntPtr modelFilename, IntPtr scales);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_setAll(
        IntPtr obj, FacemarkAAMParamsData data, [MarshalAs(UnmanagedType.LPStr)] string modelFilename, IntPtr scales);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_read(IntPtr obj, IntPtr fn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FacemarkAAM_Params_write(IntPtr obj, IntPtr fs);

    #endregion

    #endregion

    #region FacemarkKazemi

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_create(
        IntPtr parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_Ptr_FacemarkKazemi_get(
        IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_Ptr_FacemarkKazemi_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_write(OpenCvSafeHandle obj, IntPtr fs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_read(OpenCvSafeHandle obj, IntPtr fn);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_training(
        OpenCvSafeHandle obj,
        IntPtr[] images,
        int imagesLength,
        IntPtr[] landmarks,
        int[] landmarkSizes,
        int landmarksLength,
        string configFile,
        Size scale,
        string modelFilename,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_getFaces(
        OpenCvSafeHandle obj, in InputArrayProxy image, IntPtr faces, out int returnValue);

    // callback is a function pointer to a static, [UnmanagedCallersOnly] trampoline (see
    // FacemarkFaceDetectorBridge); userData is a GCHandle to the context rooting the real managed
    // detector, round-tripped opaquely through callbackData/face_Facemark_faceDetectorThunk.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_setFaceDetector(
        OpenCvSafeHandle obj, IntPtr callback, IntPtr userData,
        out IntPtr callbackData, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkFaceDetectorCallbackData_delete(IntPtr callbackData);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_Params_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_Params_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_Params_getAll(
        IntPtr obj, out FacemarkKazemiParamsData data, IntPtr configFile);

    [LibraryImport(DllExtern, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus face_FacemarkKazemi_Params_setAll(
        IntPtr obj, FacemarkKazemiParamsData data, string configFile);

    #endregion
}
