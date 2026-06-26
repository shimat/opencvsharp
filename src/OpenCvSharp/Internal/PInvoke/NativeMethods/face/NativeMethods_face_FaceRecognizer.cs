using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region FaceRecognizer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_train(
        OpenCvSafeHandle obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_update(
        OpenCvSafeHandle obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_predict1(OpenCvSafeHandle obj, IntPtr src, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_predict2(
        OpenCvSafeHandle obj, IntPtr src, out int label, out double confidence);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_write1(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_read1(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_write2(OpenCvSafeHandle obj, IntPtr fs);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_read2(OpenCvSafeHandle obj, IntPtr fs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_setLabelInfo(
        OpenCvSafeHandle obj, int label, [MarshalAs(UnmanagedType.LPStr)] string strInfo);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_getLabelInfo(OpenCvSafeHandle obj, int label, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_getLabelsByString(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string str, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_getThreshold(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FaceRecognizer_setThreshold(OpenCvSafeHandle obj, double val);

    #endregion

    #region BasicFaceRecognizer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getNumComponents(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_setNumComponents(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getThreshold(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_setThreshold(OpenCvSafeHandle obj, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getProjections(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getLabels(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getEigenValues(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getEigenVectors(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_BasicFaceRecognizer_getMean(OpenCvSafeHandle obj, IntPtr dst);

    #endregion

    #region EigenFaceRecognizer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_EigenFaceRecognizer_create(int numComponents, double threshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_EigenFaceRecognizer_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_EigenFaceRecognizer_delete(IntPtr obj);

    #endregion

    #region FisherFaceRecognizer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_FisherFaceRecognizer_create(int numComponents, double threshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FisherFaceRecognizer_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_FisherFaceRecognizer_delete(IntPtr obj);

    #endregion

    #region LBPHFaceRecognizer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_create(
        int radius, int neighbors, int gridX, int gridY, double threshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getGridX(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_setGridX(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getGridY(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_setGridY(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getRadius(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_setRadius(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getNeighbors(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_setNeighbors(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getThreshold(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_setThreshold(OpenCvSafeHandle obj, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getHistograms(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_LBPHFaceRecognizer_getLabels(OpenCvSafeHandle obj, IntPtr dst);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_LBPHFaceRecognizer_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus face_Ptr_LBPHFaceRecognizer_delete(IntPtr obj);

    #endregion
}
