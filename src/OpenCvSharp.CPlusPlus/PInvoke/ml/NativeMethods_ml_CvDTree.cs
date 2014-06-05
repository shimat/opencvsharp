using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        // CvDTreeParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeParams_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeParams_new2(
            int maxDepth, int minSampleCount, float regressionAccuracy, int useSurrogates,
            int maxCategories, int cvFolds, int use1SeRule, int truncatePrunedTree, IntPtr priors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_delete(IntPtr p);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_max_categories_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_max_categories_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_max_depth_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_max_depth_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_min_sample_count_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_min_sample_count_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_cv_folds_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_cv_folds_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_use_surrogates_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_use_surrogates_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_use_1se_rule_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_use_1se_rule_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeParams_truncate_pruned_tree_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_truncate_pruned_tree_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ml_CvDTreeParams_regression_accuracy_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_regression_accuracy_set(IntPtr p, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* ml_CvDTreeParams_priors_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeParams_priors_set(IntPtr p, IntPtr value);
        
        // CvDTreeTrainData
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_new2(
            IntPtr trainData, int tflag, IntPtr responses,
            IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask,
            IntPtr param, int shared, int addLabels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_set_data(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses,
            IntPtr varIdx, IntPtr sampleIdx, IntPtr varType, IntPtr missingMask,
            IntPtr param, int shared, int addLabels, int updateData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void ml_CvDTreeTrainData_get_vectors(
            IntPtr obj, IntPtr subsampleIdx, float* values, byte* missing, float* responses, int getClassIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_subsample_data(
            IntPtr obj, IntPtr subsampleIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_write_params(
            IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_read_params(
            IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_get_num_classes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_get_var_type(IntPtr obj, int vi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_get_work_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_get_class_labels(
            IntPtr obj, IntPtr n, [In, Out] int[] labelsBuf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_get_ord_responses(
            IntPtr obj, IntPtr n, [In, Out] float[] valuesBuf, [In, Out] int[] sampleIndicesBuf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_get_cv_labels(
            IntPtr obj, IntPtr n, [In, Out] int[] labelsBuf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_get_cat_var_data(
            IntPtr obj, IntPtr n, int vi, [In, Out] int[] catValuesBuf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_get_ord_var_data(
            IntPtr obj, IntPtr n, int vi, [In, Out] float[] ordValuesBuf, [In, Out] int[] sortedIndicesBuf,
            [In] float[][] ordValues, [In] int[][] sortedIndices, [In, Out] int[] sampleIndicesBuf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_get_child_buf_idx(IntPtr obj, IntPtr n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_set_params(IntPtr obj, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_new_node(
            IntPtr obj, IntPtr parent, int count, int storageIdx, int offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_new_split_ord(
            IntPtr obj, int vi, float cmpVal, int splitPoint, int inversed, float quality);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_new_split_cat(
            IntPtr obj, int vi, float quality);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_free_node_data(
            IntPtr obj, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_free_train_data(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTreeTrainData_free_node(IntPtr obj, IntPtr node);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_sample_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_var_all(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_max_c_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_ord_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_cat_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_have_labels(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_have_priors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_is_classifier(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_buf_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_buf_size(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTreeTrainData_shared(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_cat_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_cat_ofs(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_cat_map(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_counts(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_buf(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_direction(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_split_buf(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_var_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_var_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_priors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_priors_mult(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void ml_CvDTreeTrainData_params(IntPtr obj, out WCvDTreeParams p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_tree_storage(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_temp_storage(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_data_root(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_node_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_split_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_cv_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTreeTrainData_nv_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt64 ml_CvDTreeTrainData_rng(IntPtr obj);
        
        // CvDTree
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTree_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTree_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTree_train1(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTree_train2(
            IntPtr obj, IntPtr trainData, IntPtr subsampleIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTree_train3(
            IntPtr obj, IntPtr trainData, IntPtr param);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTree_train_Mat(
            IntPtr obj, IntPtr trainData, int tflag, IntPtr responses, IntPtr varIdx, 
            IntPtr sampleIdx, IntPtr varType, IntPtr missingMask, IntPtr @params);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTree_predict_CvMat(
            IntPtr obj, IntPtr sample, IntPtr missingDataMask, int preprocessedInput);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTree_predict_Mat(
            IntPtr obj, IntPtr sample, IntPtr missingDataMask, int preprocessedInput);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTree_getVarImportance(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTree_get_root(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_CvDTree_get_pruned_tree_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvDTree_get_data(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTree_clear(IntPtr obj);
        [DllImport(DllExtern, EntryPoint = "CvDTree_read1", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTree_read(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, EntryPoint = "CvDTree_read2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr data);
        [DllImport(DllExtern, EntryPoint = "CvDTree_write1", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTree_write(IntPtr obj, IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, EntryPoint = "CvDTree_write2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvDTree_write(IntPtr obj, IntPtr fs);
    }
}