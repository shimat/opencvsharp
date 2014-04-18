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
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_initModule_ml();

        #region StatModel

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_CvStatModel_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_save(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_CvStatModel_read(IntPtr obj, IntPtr storage, IntPtr node);
        #endregion

#if false
        #region CvEM
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_EM_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cv_EM_new(int nclusters, [MarshalAs(UnmanagedType.I4)] EMCovMatType covMatType, CvTermCriteria termCrit);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_EM_delete(IntPtr model);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_EM_clear(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_EM_train(IntPtr model, IntPtr samples, IntPtr logLikelihoods, IntPtr labels, IntPtr probs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_EM_trainE(IntPtr model, IntPtr samples, IntPtr covs0, IntPtr weights0,
            IntPtr logLikelihoods, IntPtr labels, IntPtr probs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_EM_trainM(IntPtr model, IntPtr samples, IntPtr probs0, IntPtr logLikelihoods, IntPtr labels, IntPtr probs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cv_EM_predict(IntPtr model, IntPtr sample, IntPtr probs, out float ret0, out float ret1);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cv_EM_isTrained(IntPtr model);
        #endregion

        #region CvKNearest
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvKNearest_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvKNearest_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvKNearest_construct_training(IntPtr _train_data, IntPtr _responses, IntPtr _sample_idx, bool _is_regression, int max_k);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvKNearest_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvKNearest_train(IntPtr obj, IntPtr _train_data, IntPtr _responses, IntPtr _sample_idx, bool is_regression, int _max_k, bool _update_base);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvKNearest_find_nearest(IntPtr obj, IntPtr _samples, int k, IntPtr results, [In, Out] IntPtr[] neighbors, IntPtr neighbor_responses, IntPtr dist);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvKNearest_find_nearest(IntPtr obj, IntPtr _samples, int k, IntPtr results, IntPtr neighbors, IntPtr neighbor_responses, IntPtr dist);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvKNearest_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvKNearest_get_max_k(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvKNearest_get_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvKNearest_get_sample_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvKNearest_is_regression(IntPtr obj);
        #endregion

        #region CvNormalBayesClassifier
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvNormalBayesClassifier_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvNormalBayesClassifier_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvNormalBayesClassifier_construct_training(IntPtr _train_data, IntPtr _responses, IntPtr _var_idx, IntPtr _sample_idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvNormalBayesClassifier_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvNormalBayesClassifier_train(IntPtr obj, IntPtr _train_data, IntPtr _responses, IntPtr _var_idx, IntPtr _sample_idx, bool update);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvNormalBayesClassifier_predict(IntPtr obj, IntPtr _samples, IntPtr results);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvNormalBayesClassifier_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvNormalBayesClassifier_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvNormalBayesClassifier_read(IntPtr obj, IntPtr storage, IntPtr node);
        #endregion

        #region CvRTrees
        // CvRTParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvRTParams_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvRTParams_construct(int _max_depth, int _min_sample_count,
                        float _regression_accuracy, bool _use_surrogates,
                        int _max_categories, IntPtr _priors, bool _calc_var_importance,
                        int _nactive_vars, int max_num_of_trees_in_the_forest,
                        float forest_accuracy, int termcrit_type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTParams_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvRTParams_calc_var_importance_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTParams_calc_var_importance_set(IntPtr obj, bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvRTParams_nactive_vars_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTParams_nactive_vars_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvTermCriteria CvRTParams_term_crit_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTParams_term_crit_set(IntPtr obj, CvTermCriteria value);

        // CvRTrees
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvRTrees_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTrees_construct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTrees_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvRTrees_train(IntPtr obj, IntPtr _train_data, int _tflag, IntPtr _responses, IntPtr _var_idx,
                                IntPtr _sample_idx, IntPtr _var_type, IntPtr _missing_mask, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvRTrees_predict(IntPtr obj, IntPtr sample, IntPtr missing);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTrees_clear(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvRTrees_get_var_importance(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvRTrees_get_proximity(IntPtr obj, IntPtr sample1, IntPtr sample2,
                IntPtr missing1, IntPtr missing2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTrees_read(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvRTrees_write(IntPtr obj, IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvRTrees_get_active_var_mask(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvRTrees_get_rng(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvRTrees_get_tree_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvRTrees_get_tree(IntPtr obj, int i);
        
        // CvForestTree
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvForestTree_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvForestTree_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvForestTree_destruct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvForestTree_train(IntPtr obj, IntPtr _train_data, IntPtr _subsample_idx, IntPtr forest);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvForestTree_get_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvForestTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr forest, IntPtr _data);
        #endregion

        #region CvSVM
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVMParams_construct_default(ref WCvSVMParams p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVMParams_construct(ref WCvSVMParams p, int _svm_type, int _kernel_type, double _degree, double _gamma, double _coef0,
                                   double _C, double _nu, double _p, IntPtr _class_weights, CvTermCriteria _term_crit);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvSVM_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvSVM_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvSVM_construct_training(IntPtr _train_data, IntPtr _responses, IntPtr _var_idx, IntPtr _sample_idx, WCvSVMParams _params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVM_destruct(IntPtr model);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVM_get_default_grid(ref CvParamGrid grid, int param_id);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvParamGrid_check(CvParamGrid grid);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvSVM_train(IntPtr model, IntPtr _train_data, IntPtr _responses, IntPtr _var_idx, IntPtr _sample_idx, WCvSVMParams _params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvSVM_train_auto(IntPtr model, IntPtr _train_data, IntPtr _responses, IntPtr _var_idx, IntPtr _sample_idx, WCvSVMParams _params,
           int k_fold, CvParamGrid C_grid, CvParamGrid gamma_grid, CvParamGrid p_grid, CvParamGrid nu_grid, CvParamGrid coef_grid, CvParamGrid degree_grid);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvSVM_predict(IntPtr model, IntPtr _sample);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* CvSVM_get_support_vector(IntPtr model, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvSVM_get_support_vector_count(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvSVM_get_var_count(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVM_get_params(IntPtr model, ref WCvSVMParams p);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVM_clear(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVM_write(IntPtr model, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvSVM_read(IntPtr model, IntPtr storage, IntPtr node);
        #endregion

        #region CvERTrees
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvERTrees_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvERTrees_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvERTrees_destruct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvERTrees_train1(IntPtr obj, IntPtr train_data, int tflag, IntPtr responses,
                                    IntPtr _var_idx, IntPtr _sample_idx, IntPtr var_type, IntPtr missing_mask, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvERTrees_train2(IntPtr obj, IntPtr data, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvERTrees_grow_forest(IntPtr obj, CvTermCriteria term_crit);
        #endregion

        #region CvTrainTestSplit
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTrainTestSplit_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvTrainTestSplit_construct1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvTrainTestSplit_construct2(int train_sample_count, [MarshalAs(UnmanagedType.Bool)] bool mix);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvTrainTestSplit_construct3(float train_sample_portion, [MarshalAs(UnmanagedType.Bool)] bool mix);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrainTestSplit_destruct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTrainTestSplit_train_sample_part_count_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrainTestSplit_train_sample_part_count_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvTrainTestSplit_train_sample_part_portion_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrainTestSplit_train_sample_part_portion_set(IntPtr obj, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTrainTestSplit_train_sample_part_mode_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrainTestSplit_train_sample_part_mode_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* CvTrainTestSplit_class_part_count_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* CvTrainTestSplit_class_part_portion_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvTrainTestSplit_class_part_mode_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrainTestSplit_class_part_mode_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CvTrainTestSplit_mix_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvTrainTestSplit_mix_set(IntPtr obj, [MarshalAs(UnmanagedType.Bool)] bool value);
        #endregion

        #region CvMLData
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvMLData_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_destruct(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvMLData_read_csv(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_values(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_responses(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_missing(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_set_response_idx(IntPtr obj, int idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvMLData_get_response_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_train_sample_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_test_sample_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_mix_train_and_test_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_set_train_test_split(IntPtr obj, IntPtr spl);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_var_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_change_var_idx(IntPtr obj, int vi, [MarshalAs(UnmanagedType.Bool)] bool state);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvMLData_get_var_types(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvMLData_get_var_type(IntPtr obj, int var_idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_set_var_types(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string str);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_change_var_type(IntPtr obj, int var_idx, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_set_delimiter(IntPtr obj, byte ch);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte CvMLData_get_delimiter(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvMLData_set_miss_ch(IntPtr obj, byte ch);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte CvMLData_get_miss_ch(IntPtr obj);
        #endregion
#endif
    }
}