using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Security;
using System.Security.Permissions;
using OpenCvSharp;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
    /// DllImportによるmlの関数をまとめたクラス
    /// </summary>
#else
    /// <summary>
    /// ml functions that declared by DllImport
    /// </summary>
#endif
    [SuppressUnmanagedCodeSecurity]
    internal static class MLInvoke
    {
        /// <summary>
        /// DLL file name
        /// </summary>
        public const string DllExtern = "OpenCvSharpExtern";

        #region Static constructor
        /// <summary>
        /// このクラスを最初に参照した時に1度だけ Unmanaged権限チェックを行う
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static MLInvoke()
        {
            TryPInvoke();
        }

#if LANG_JP
        /// <summary>
        /// PInvokeが正常に行えるかチェックする
        /// </summary>
#else
        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
#endif
        private static void TryPInvoke()
        {
            // call cv to enable redirecting 
            Cv.GetTickCount();
            try
            {
                CvSVM_sizeof();
            }
            catch (DllNotFoundException e)
            {
                PInvokeHelper.DllImportError(e);
            }
            catch (BadImageFormatException e)
            {
                PInvokeHelper.DllImportError(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region ML factory methods
        #region CvStatModel
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvStatModel_clear(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvStatModel_save(IntPtr model, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvStatModel_load(IntPtr model, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvStatModel_write(IntPtr model, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvStatModel_read(IntPtr model, IntPtr storage, IntPtr node);
        #endregion
        #region CvANN_MLP
        #region CvANN_MLP_TrainParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvANN_MLP_TrainParams_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvANN_MLP_TrainParams_construct(
            CvTermCriteria term_crit, int train_method, double param1, double param2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvANN_MLP_TrainParams_destruct(IntPtr obj);
        #endregion
        #region CvANN_MLP
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvANN_MLP_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvANN_MLP_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvANN_MLP_construct_training(IntPtr _layer_sizes, int _activ_func, double _f_param1, double _f_param2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvANN_MLP_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvANN_MLP_train(IntPtr obj, IntPtr _inputs, IntPtr _outputs, IntPtr _sample_weights,
                        IntPtr _sample_idx, WCvANN_MLP_TrainParams _params, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvANN_MLP_predict(IntPtr obj, IntPtr _inputs, IntPtr _outputs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvANN_MLP_create(IntPtr obj, IntPtr _layer_sizes, int _activ_func, double _f_param1, double _f_param2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvANN_MLP_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvANN_MLP_read(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvANN_MLP_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvANN_MLP_get_layer_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvANN_MLP_get_layer_sizes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe double* CvANN_MLP_get_weights(IntPtr obj, int layer);
        #endregion
        #endregion
        #region CvBoost
        #region CvBoost
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBoost_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_construct_training(IntPtr _train_data, int _tflag, IntPtr _responses,
                    IntPtr _var_idx, IntPtr _sample_idx, IntPtr _var_type, IntPtr _missing_mask, IntPtr pparams);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoost_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvBoost_train(IntPtr obj, IntPtr _train_data, int _tflag, IntPtr _responses,
                                  IntPtr _var_idx, IntPtr _sample_idx, IntPtr _var_type,
                                  IntPtr _missing_mask, IntPtr pparams, bool update);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvBoost_predict(IntPtr obj, IntPtr _sample, IntPtr _missing,
                                     IntPtr weak_responses, CvSlice slice, bool raw_mode);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoost_prune(IntPtr obj, CvSlice slice);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoost_clear(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoost_write(IntPtr obj, IntPtr storage, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoost_read(IntPtr obj, IntPtr storage, IntPtr node);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_get_weak_predictors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_get_weights(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_get_subtree_weights(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_get_weak_response(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoost_get_params(IntPtr obj);
        #endregion
        #region CvBoostTree
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
        #endregion
        #region CvBoostParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBoostParams_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoostParams_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvBoostParams_construct(int boost_type, int weak_count, double weight_trim_rate,
                           int max_depth, bool use_surrogates, IntPtr priors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostParams_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBoostParams_boost_type_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostParams_boost_type_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBoostParams_weak_count_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostParams_weak_count_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvBoostParams_split_criteria_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostParams_split_criteria_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double CvBoostParams_weight_trim_rate_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvBoostParams_weight_trim_rate_set(IntPtr obj, double value);
        #endregion
        #endregion
        #region CvDTree
        #region CvDTreeParams
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeParams_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeParams_construct(int _max_depth, int _min_sample_count, float _regression_accuracy, bool _use_surrogates,
                           int _max_categories, int _cv_folds, bool _use_1se_rule, bool _truncate_pruned_tree, IntPtr _priors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_destruct(IntPtr p);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeParams_max_categories_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_max_categories_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeParams_max_depth_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_max_depth_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeParams_min_sample_count_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_min_sample_count_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeParams_cv_folds_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_cv_folds_set(IntPtr p, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeParams_use_surrogates_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_use_surrogates_set(IntPtr p, bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeParams_use_1se_rule_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_use_1se_rule_set(IntPtr p, bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeParams_truncate_pruned_tree_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_truncate_pruned_tree_set(IntPtr p, bool value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float CvDTreeParams_regression_accuracy_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeParams_regression_accuracy_set(IntPtr p, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* CvDTreeParams_priors_get(IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void CvDTreeParams_priors_set(IntPtr p, float* value);
        #endregion
        #region CvDTreeTrainData
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_construct_default();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_construct_training(IntPtr _train_data, int _tflag, IntPtr _responses,
            IntPtr _var_idx, IntPtr _sample_idx, IntPtr _var_type, IntPtr _missing_mask,
            IntPtr _params, bool _shared, bool _add_labels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_destruct(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_set_data(IntPtr obj, IntPtr _train_data, int _tflag, IntPtr _responses,
            IntPtr _var_idx, IntPtr _sample_idx, IntPtr _var_type, IntPtr _missing_mask,
            IntPtr _param, bool _shared, bool _add_labels, bool _update_data);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void CvDTreeTrainData_get_vectors(IntPtr obj, IntPtr _subsample_idx, float* values, byte* missing, float* responses, bool get_class_idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_subsample_data(IntPtr obj, IntPtr _subsample_idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_write_params(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_read_params(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_get_num_classes(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_get_var_type(IntPtr obj, int vi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_get_work_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr CvDTreeTrainData_get_class_labels(IntPtr obj, IntPtr n, [In, Out] int[] labels_buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr CvDTreeTrainData_get_ord_responses(IntPtr obj, IntPtr n, [In, Out] float[] values_buf, [In, Out] int[] sample_indices_buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr CvDTreeTrainData_get_cv_labels(IntPtr obj, IntPtr n, [In, Out] int[] labels_buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr CvDTreeTrainData_get_cat_var_data(IntPtr obj, IntPtr n, int vi, [In, Out] int[] cat_values_buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void CvDTreeTrainData_get_ord_var_data(IntPtr obj, IntPtr n, int vi, [In, Out] float[] ord_values_buf, [In, Out] int[] sorted_indices_buf,
            [In] float[][] ord_values, [In] int[][] sorted_indices, [In, Out] int[] sample_indices_buf);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_get_child_buf_idx(IntPtr obj, IntPtr n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeTrainData_set_params(IntPtr obj, IntPtr @params);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_new_node(IntPtr obj, IntPtr parent, int count, int storage_idx, int offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_new_split_ord(IntPtr obj, int vi, float cmp_val, int split_point, int inversed, float quality);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_new_split_cat(IntPtr obj, int vi, float quality);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_free_node_data(IntPtr obj, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_free_train_data(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTreeTrainData_free_node(IntPtr obj, IntPtr node);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_sample_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_var_all(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_max_c_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_ord_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_cat_var_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeTrainData_have_labels(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeTrainData_have_priors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeTrainData_is_classifier(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_buf_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTreeTrainData_buf_size(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTreeTrainData_shared(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_cat_count(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_cat_ofs(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_cat_map(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_counts(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_buf(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_direction(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_split_buf(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_var_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_var_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_priors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_priors_mult(IntPtr obj);
        //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void CvDTreeTrainData_params(IntPtr obj, out WCvDTreeParams p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_tree_storage(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_temp_storage(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_data_root(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_node_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_split_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_cv_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTreeTrainData_nv_heap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt64 CvDTreeTrainData_rng(IntPtr obj);
        #endregion
        #region CvDTree
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTree_sizeof();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTree_construct();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTree_destruct(IntPtr obj);

        [DllImport(DllExtern, EntryPoint = "CvDTree_train1", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTree_train(IntPtr obj, IntPtr _train_data, int _tflag, IntPtr _responses,
            IntPtr _var_idx, IntPtr _sample_idx, IntPtr _var_type, IntPtr _missing_mask, IntPtr @params);
        [DllImport(DllExtern, EntryPoint = "CvDTree_train2", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CvDTree_train(IntPtr obj, IntPtr _train_data, IntPtr _subsample_idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTree_predict(IntPtr obj, IntPtr _sample, IntPtr _missing_data_mask, bool preprocessed_input);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTree_get_var_importance(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTree_get_root(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CvDTree_get_pruned_tree_idx(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CvDTree_get_data(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTree_clear(IntPtr obj);
        [DllImport(DllExtern, EntryPoint = "CvDTree_read1", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTree_read(IntPtr obj, IntPtr fs, IntPtr node);
        [DllImport(DllExtern, EntryPoint = "CvDTree_read2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTree_read(IntPtr obj, IntPtr fs, IntPtr node, IntPtr data);
        [DllImport(DllExtern, EntryPoint = "CvDTree_write1", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTree_write(IntPtr obj, IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name);
        [DllImport(DllExtern, EntryPoint = "CvDTree_write2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CvDTree_write(IntPtr obj, IntPtr fs);
        #endregion
        #endregion
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
        #region CvRTParams
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

        #endregion
        #region CvRTrees
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
        #endregion
        #region CvForestTree
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
        #endregion
    }
}
