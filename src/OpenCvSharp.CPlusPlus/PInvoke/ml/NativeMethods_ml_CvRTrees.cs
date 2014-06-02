using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        // CvRTParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTParams_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTParams_new2(
            int maxDepth, int minSampleCount, float regressionAccuracy, 
            int useSurrogates, int maxCategories, IntPtr priors, int calcVarImportance,
            int nactiveVars, int maxNumOfTreesInTheForest, float forestAccuracy,
            int termcritType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTParams_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvRTParams_calc_var_importance_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTParams_calc_var_importance_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvRTParams_nactive_vars_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTParams_nactive_vars_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvTermCriteria ml_CvRTParams_term_crit_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTParams_term_crit_set(IntPtr obj, CvTermCriteria value);

        // CvRTrees
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTrees_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTrees_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvRTrees_train_CvMat(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvRTrees_train_Mat(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx,
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvRTrees_train_MLData(IntPtr obj, IntPtr data, IntPtr param);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvRTrees_predict_CvMat(IntPtr obj, IntPtr sample, IntPtr missing);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvRTrees_predict_Mat(IntPtr obj, IntPtr sample, IntPtr missing);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvRTrees_predict_prob_CvMat(IntPtr obj, IntPtr sample, IntPtr missing);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvRTrees_predict_prob_Mat(IntPtr obj, IntPtr sample, IntPtr missing);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTrees_clear(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTrees_getVarImportance(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvRTrees_get_proximity(IntPtr obj, IntPtr sample1, IntPtr sample2,
                IntPtr missing1, IntPtr missing2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTrees_read(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvRTrees_write(IntPtr obj, IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTrees_get_active_var_mask(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTrees_get_rng(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvRTrees_get_tree_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvRTrees_get_tree(IntPtr obj, int i);
        
        // CvForestTree
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvForestTree_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvForestTree_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvForestTree_train(IntPtr obj, IntPtr _train_data, IntPtr _subsample_idx, IntPtr forest);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvForestTree_get_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvForestTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr forest, IntPtr _data);

    }
}