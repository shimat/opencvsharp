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

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_train(
        IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_update(
        IntPtr obj, IntPtr[] src, int srcLength, int[] labels, int labelsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_predict1(IntPtr obj, IntPtr src, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_predict2(
        IntPtr obj, IntPtr src, out int label, out double confidence);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_write1(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_read1(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_write2(IntPtr obj, IntPtr fs);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_read2(IntPtr obj, IntPtr fs);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_setLabelInfo(
        IntPtr obj, int label, [MarshalAs(UnmanagedType.LPStr)] string strInfo);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_getLabelInfo(IntPtr obj, int label, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_getLabelsByString(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string str, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_getThreshold(IntPtr obj, out double returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FaceRecognizer_setThreshold(IntPtr obj, double val);

    #endregion

    #region BasicFaceRecognizer

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getNumComponents(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_setNumComponents(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getThreshold(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_setThreshold(IntPtr obj, double val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getProjections(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getLabels(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getEigenValues(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getEigenVectors(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_BasicFaceRecognizer_getMean(IntPtr obj, IntPtr dst);

    #endregion

    #region EigenFaceRecognizer

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_EigenFaceRecognizer_create(int numComponents, double threshold, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_EigenFaceRecognizer_get(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_EigenFaceRecognizer_delete(IntPtr obj);

    #endregion

    #region FisherFaceRecognizer

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_FisherFaceRecognizer_create(int numComponents, double threshold, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_FisherFaceRecognizer_get(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_FisherFaceRecognizer_delete(IntPtr obj);

    #endregion

    #region LBPHFaceRecognizer

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_create(
        int radius, int neighbors, int gridX, int gridY, double threshold, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getGridX(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_setGridX(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getGridY(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_setGridY(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getRadius(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_setRadius(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getNeighbors(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_setNeighbors(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getThreshold(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_setThreshold(IntPtr obj, double val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getHistograms(IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_LBPHFaceRecognizer_getLabels(IntPtr obj, IntPtr dst);


    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_LBPHFaceRecognizer_get(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus face_Ptr_LBPHFaceRecognizer_delete(IntPtr obj);

    #endregion
}
