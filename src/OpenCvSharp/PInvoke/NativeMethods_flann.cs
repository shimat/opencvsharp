using System;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Flann;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region Index
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_Index_new(IntPtr features, IntPtr @params, int distType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_knnSearch1(IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_knnSearch2(IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, int knn, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_knnSearch3(IntPtr obj, IntPtr queries, [Out] int[] indices, [Out] float[] dists, int knn, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_radiusSearch1(IntPtr obj, [In] float[] queries, int queriesLength, [Out] int[] indices, int indicesLength, [Out] float[] dists, int dists_length, float radius, int maxResults, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_radiusSearch2(IntPtr obj, IntPtr queries, IntPtr indices, IntPtr dists, float radius, int maxResults, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_Index_radiusSearch3(IntPtr obj, IntPtr queries, [Out] int[] indices, int indicesLength, [Out] float[] dists, int distsLength, float radius, int maxResults, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_Index_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int flann_Index_veclen(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int flann_Index_size(IntPtr obj);
        #endregion
        #region IndexParams
        #region IndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_IndexParams_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_IndexParams_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_IndexParams_getString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string defaultVal, [MarshalAs(UnmanagedType.LPStr)] StringBuilder result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int flann_IndexParams_getInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int defaultVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern double flann_IndexParams_getDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double defaultVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_IndexParams_setString(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_IndexParams_setInt(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_IndexParams_setDouble(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_IndexParams_setFloat(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void flann_IndexParams_setBool(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string key, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_IndexParams_setAlgorithm(IntPtr obj, int value);
        #endregion
        #region LinearIndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_LinearIndexParams_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_LinearIndexParams_delete(IntPtr obj);
        #endregion
        #region KDTreeIndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_KDTreeIndexParams_new(int trees);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_KDTreeIndexParams_delete(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe int* flann_KDTreeIndexParams_trees(IntPtr obj);
        #endregion
        #region KMeansIndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_KMeansIndexParams_new(
            int branching, int iterations, [MarshalAs(UnmanagedType.I4)] FlannCentersInit centers_init, float cb_index);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_KMeansIndexParams_delete(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe int* flann_KMeansIndexParams_branching(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe int* flann_KMeansIndexParams_iterations(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe FlannCentersInit* flann_KMeansIndexParams_centers_init(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe float* flann_KMeansIndexParams_cb_index(IntPtr obj);
        #endregion
        #region CompositeIndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_CompositeIndexParams_new(int trees, int branching, int iterations, FlannCentersInit centers_init, float cb_index);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_CompositeIndexParams_delete(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe int* flann_CompositeIndexParams_trees(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe int* flann_CompositeIndexParams_branching(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe int* flann_CompositeIndexParams_iterations(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe FlannCentersInit* flann_CompositeIndexParams_centers_init(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe float* flann_CompositeIndexParams_cb_index(IntPtr obj);
        #endregion
        #region AutotunedIndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_AutotunedIndexParams_new(float targetPrecision, float build_weight, float memory_weight, float sample_fraction);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_AutotunedIndexParams_delete(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe float* flann_AutotunedIndexParams_target_precision(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe float* flann_AutotunedIndexParams_build_weight(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe float* flann_AutotunedIndexParams_memory_weight(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe float* flann_AutotunedIndexParams_sample_fraction(IntPtr obj);
        #endregion
        #region SavedIndexParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr flann_SavedIndexParams_new([MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_SavedIndexParams_delete(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.LPStr)]
        //public static extern string flann_SavedIndexParams_filename_get(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void flann_SavedIndexParams_filename_set(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);
        #endregion
        #region SearchParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr flann_SearchParams_new(int checks, float eps, int sorted);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void flann_SearchParams_delete(IntPtr obj);
        #endregion

        #endregion
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int flann_hierarchicalClustering(IntPtr features, IntPtr centers, IntPtr @params);
    }
}