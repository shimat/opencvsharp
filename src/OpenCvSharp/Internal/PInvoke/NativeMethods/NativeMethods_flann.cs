using System.Runtime.InteropServices;
using OpenCvSharp.Flann;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region Index

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_new(IntPtr features, IntPtr @params, int distType, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_knnSearch1(
        IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_knnSearch2(
        IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, int knn, IntPtr @params);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_knnSearch3(
        IntPtr obj, IntPtr queries, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_radiusSearch1(
        IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, int indicesLength, [Out] float[] dists, int distsLength, double radius, int maxResults, IntPtr @params);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_radiusSearch2(
        IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, double radius, int maxResults, IntPtr @params);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_radiusSearch3(
        IntPtr obj, IntPtr queries, [Out] int[] indices, int indicesLength, [Out] float[] dists, int distsLength, double radius, int maxResults, IntPtr @params);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Index_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

    #endregion

    #region IndexParams
    #region IndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_IndexParams_new(out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_IndexParams_get(IntPtr ptr, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_IndexParams_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_getString(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string? defaultVal, IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_getInt(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int defaultVal, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_getDouble(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double defaultVal, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_setString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_setInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_setDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_setFloat(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, float value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_setBool(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_IndexParams_setAlgorithm(IntPtr obj, int value);

    #endregion

    #region LinearIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_LinearIndexParams_new(out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_LinearIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_LinearIndexParams_delete(IntPtr obj);

    #endregion

    #region KDTreeIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_KDTreeIndexParams_new(int trees, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_KDTreeIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_KDTreeIndexParams_delete(IntPtr obj);

    #endregion

    #region KMeansIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_KMeansIndexParams_new(
        int branching, int iterations, [MarshalAs(UnmanagedType.I4)] FlannCentersInit centersInit, float cbIndex, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_KMeansIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_KMeansIndexParams_delete(IntPtr obj);

    #endregion

    #region LshIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_LshIndexParams_new(
        int tableNumber, int keySize, int multiProbeLevel, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_LshIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_LshIndexParams_delete(IntPtr obj);

    #endregion

    #region CompositeIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_CompositeIndexParams_new(
        int trees, int branching, int iterations, FlannCentersInit centersInit, float cbIndex, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_CompositeIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_CompositeIndexParams_delete(IntPtr obj);

    #endregion

    #region AutotunedIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_AutotunedIndexParams_new(
        float targetPrecision, float buildWeight, float memoryWeight, float sampleFraction, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_AutotunedIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_AutotunedIndexParams_delete(IntPtr obj);

    #endregion

    #region SavedIndexParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_SavedIndexParams_new(
        [MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_SavedIndexParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_SavedIndexParams_delete(IntPtr obj);

    #endregion

    #region SearchParams

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_SearchParams_new(int checks, float eps, int sorted, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_SearchParams_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus flann_Ptr_SearchParams_delete(IntPtr obj);

    #endregion

    #endregion
}
