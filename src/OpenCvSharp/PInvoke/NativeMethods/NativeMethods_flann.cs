using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Flann;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region Index
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Index_new(IntPtr features, IntPtr @params, int distType);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_knnSearch1(IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_knnSearch2(IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, int knn, IntPtr @params);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_knnSearch3(IntPtr obj, IntPtr queries, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_radiusSearch1(IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, int indicesLength, [Out] float[] dists, int distsLength, float radius, int maxResults, IntPtr @params);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_radiusSearch2(IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, float radius, int maxResults, IntPtr @params);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Index_radiusSearch3(IntPtr obj, IntPtr queries, [Out] int[] indices, int indicesLength, [Out] float[] dists, int distsLength, float radius, int maxResults, IntPtr @params);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_Index_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern int flann_Index_veclen(IntPtr obj);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern int flann_Index_size(IntPtr obj);
        #endregion
        #region IndexParams
        #region IndexParams
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_IndexParams_new();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_IndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_IndexParams_new();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_IndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_IndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_IndexParams_getString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string? defaultVal, [MarshalAs(UnmanagedType.LPStr)] StringBuilder result);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern int flann_IndexParams_getInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int defaultVal);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern double flann_IndexParams_getDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double defaultVal);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_IndexParams_setString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_IndexParams_setInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_IndexParams_setDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_IndexParams_setFloat(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, float value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void flann_IndexParams_setBool(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_IndexParams_setAlgorithm(IntPtr obj, int value);
        #endregion
        #region LinearIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_LinearIndexParams_new();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_LinearIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_LinearIndexParams_new();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_LinearIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_LinearIndexParams_delete(IntPtr obj);

        #endregion
        #region KDTreeIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_KDTreeIndexParams_new(int trees);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_KDTreeIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_KDTreeIndexParams_new(int trees);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_KDTreeIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_KDTreeIndexParams_delete(IntPtr obj);

        #endregion
        #region KMeansIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_KMeansIndexParams_new(
            int branching, int iterations, [MarshalAs(UnmanagedType.I4)] FlannCentersInit centersInit, float cbIndex);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_KMeansIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_KMeansIndexParams_new(
            int branching, int iterations, [MarshalAs(UnmanagedType.I4)] FlannCentersInit centersInit, float cbIndex);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_KMeansIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_KMeansIndexParams_delete(IntPtr obj);

        #endregion
        #region LshIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_LshIndexParams_new(
            int tableNumber, int keySize, int multiProbeLevel);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_LshIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_LshIndexParams_new(
            int tableNumber, int keySize, int multiProbeLevel);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_LshIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_LshIndexParams_delete(IntPtr obj);

        #endregion
        #region CompositeIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_CompositeIndexParams_new(int trees, int branching, int iterations, FlannCentersInit centersInit, float cbIndex);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_CompositeIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_CompositeIndexParams_new(int trees, int branching, int iterations, FlannCentersInit centersInit, float cbIndex);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_CompositeIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_CompositeIndexParams_delete(IntPtr obj);

        #endregion
        #region AutotunedIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_AutotunedIndexParams_new(float targetPrecision, float buildWeight, float memoryWeight, float sampleFraction);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_AutotunedIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_AutotunedIndexParams_new(float targetPrecision, float buildWeight, float memoryWeight, float sampleFraction);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_AutotunedIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_AutotunedIndexParams_delete(IntPtr obj);

        #endregion
        #region SavedIndexParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern IntPtr flann_SavedIndexParams_new([MarshalAs(UnmanagedType.LPStr)] string filename);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_SavedIndexParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_SavedIndexParams_new([MarshalAs(UnmanagedType.LPStr)] string filename);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_SavedIndexParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_SavedIndexParams_delete(IntPtr obj);

        #endregion
        #region SearchParams

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_SearchParams_new(int checks, float eps, int sorted);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_SearchParams_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_SearchParams_new(int checks, float eps, int sorted);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr flann_Ptr_SearchParams_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void flann_Ptr_SearchParams_delete(IntPtr obj);

        #endregion

        #endregion

        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern int flann_hierarchicalClustering(IntPtr features, IntPtr centers, IntPtr @params);
    }
}