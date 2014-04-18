/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        // Boost
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_new_CvMat(
            IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx, 
            IntPtr varType, IntPtr missingMask, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_new_Mat(
            IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, IntPtr sampleIdx,
            IntPtr varType, IntPtr missingMask, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvBoost_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvBoost_train_CvMat(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param, int update);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvBoost_train_Mat(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx,
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param, int update);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvBoost_predict_CvMat(
            IntPtr obj, IntPtr sample, IntPtr missing, IntPtr weakResponses, 
            CvSlice slice, int rawMode, int returnSum);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvBoost_predict_Mat(
            IntPtr obj, IntPtr sample, IntPtr missing, 
            CvSlice slice, int rawMode, int returnSum);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvBoost_prune(IntPtr obj, CvSlice slice);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvBoost_clear(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvBoost_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvBoost_read(IntPtr obj, IntPtr storage, IntPtr node);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_get_weak_predictors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_get_weights(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_get_subtree_weights(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_get_weak_response(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoost_get_params(IntPtr obj);
        
        // CvBoostTree
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBoostTree_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoostTree_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostTree_destruct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvBoostTree_train(IntPtr obj, IntPtr _train_data, IntPtr subsample_idx, IntPtr ensemble);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostTree_scale(IntPtr obj, double s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr ensemble, IntPtr _data);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostTree_clear(IntPtr obj);
        
        // CvBoostParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvBoostParams_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoostParams_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvBoostParams_new2(
            int boostType, int weakCount, double weightTrimRate,
            int maxDepth, int useSurrogates, IntPtr priors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvBoostParams_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* ml_CvBoostParams_boost_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* ml_CvBoostParams_weak_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* ml_CvBoostParams_split_criteria(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* ml_CvBoostParams_weight_trim_rate(IntPtr obj);

    }
}