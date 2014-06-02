using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 決定木の学習パラメータ
    /// </summary>
#else
	/// <summary>
    /// Decision tree training parameters
    /// </summary>
#endif
    public class CvDTreeParams : DisposableCvObject
    {
        protected float[] priors;
        protected GCHandle handle;

        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal protected CvDTreeParams(IntPtr ptr)
        {
            this.ptr = ptr;
            this.priors = null;
        }

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
		/// Default constructor
		/// </summary>
#endif
        public CvDTreeParams()
        {
            ptr = NativeMethods.ml_CvDTreeParams_new1();
            priors = null;
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="maxDepth">このパラメータは木が取りうる最大の深さを決定する．学習アルゴリズムは，ノードの深さが max_depth  よりも小さいならば，それを分岐させようとする．他の終了条件が満たされた場合や（セクション始めにある学習手続きの概要を参照）， あるいは/さらに，木が刈り込まれた場合など，実際の深さはもっと浅いかもしれない．</param>
        /// <param name="minSampleCount">あるノードに対するサンプル数がこのパラメータ値よりも少ない場合，そのノードは分岐しない． </param>
        /// <param name="regressionAccuracy">別の終了条件 - 回帰木の場合のみ． 推定されたノード値が，そのノードの学習サンプルの応答に対して，このパラメータ値よりも低い精度を持つ場合，ノードはそれ以上分岐しなくなる．</param>
        /// <param name="useSurrogates">trueの場合，代理分岐が構築される． 代理分岐は観測値データの欠損を処理する場合や，変数の重要度の推定に必要である．</param>
        /// <param name="maxCategories">学習手続きが分岐を作るときの離散変数が max_categoriesよりも多くの値を取ろうとするならば， （アルゴリズムが指数関数的であるので）正確な部分集合推定を行う場合に非常に時間がかかる可能性がある． 代わりに，（MLを含む）多くの決定木エンジンが，全サンプルを max_categories 個のクラスタに分類することによって （つまりいくつかのカテゴリは一つにマージされる），この場合の次善最適分岐を見つけようとする．このテクニックは，N(>2)-クラス分類問題においてのみ適用されることに注意する． 回帰および 2-クラス分類の場合は，このような手段をとらなくても効率的に最適分岐を見つけることができるので，このパラメータは使用されない．</param>
        /// <param name="cvFolds">このパラメータが >1 の場合，木は cv_folds 分割交差検証法により刈り込まれる． </param>
        /// <param name="use1seRule">true の場合，木は刈り込み手続きによって切り捨てられる． これにより，コンパクトで学習データノイズに対してより耐性を持つような木になるが，決定木の正確さはやや劣る． </param>
        /// <param name="truncatePrunedTree">true の場合，（Tn≤CvDTree::pruned_tree_idxである） カットオフノードが，木から物理的に削除される． そうでない場合は，それらは削除はされず，CvDTree::pruned_tree_idx を減らす（例えば -1 を設定する） ことによって，オリジナルの刈り込みされていない（あるいは積極的には刈り込まれていない）木からの結果を得ることができる．</param>
		/// <param name="priors">クラスラベル値によって保存されたクラス事前確率の配列． このパラメータは，ある特定のクラスに対する決定木の優先傾向を調整するために用いられる． 例えば，もしユーザがなんらかの珍しい例外的発生を検出したいと考えた場合，学習データは，おそらく例外的なケースよりもずっと多くの正常なケースを含んでいるので， 全ケースが正常であるとみなすだけで，非常に優れた分類性能が実現されるだろう． このように例外ケースを無視して分類性能を上げることを避けるために，事前確率を指定することができる． 例外的なケースの確率を人工的に増加させる（0.5 まで，あるいはそれ以上に）ことで，分類に失敗した例外の重みがより大きくなり，木は適切に調節される． </param>
#else
		/// <summary>
		/// Training constructor
		/// </summary>
		/// <param name="maxDepth">This parameter specifies the maximum possible depth of the tree. That is the training algorithms attempts to split a node while its depth is less than max_depth. The actual depth may be smaller if the other termination criteria are met (see the outline of the training procedure in the beginning of the section), and/or if the tree is pruned. </param>
		/// <param name="minSampleCount">A node is not split if the number of samples directed to the node is less than the parameter value. </param>
		/// <param name="regressionAccuracy">Another stop criteria - only for regression trees. As soon as the estimated node value differs from the node training samples responses by less than the parameter value, the node is not split further. </param>
		/// <param name="useSurrogates">If true, surrogate splits are built. Surrogate splits are needed to handle missing measurements and for variable importance estimation. </param>
		/// <param name="maxCategories">If a discrete variable, on which the training procedure tries to make a split, takes more than max_categories values, the precise best subset estimation may take a very long time (as the algorithm is exponential). Instead, many decision trees engines (including ML) try to find sub-optimal split in this case by clustering all the samples into max_categories clusters (i.e. some categories are merged together). Note that this technique is used only in N(>2)-class classification problems. In case of regression and 2-class classification the optimal split can be found efficiently without employing clustering, thus the parameter is not used in these cases. </param>
		/// <param name="cvFolds">If this parameter is >1, the tree is pruned using cv_folds-fold cross validation. </param>
        /// <param name="use1seRule">If true, the tree is truncated a bit more by the pruning procedure. That leads to compact, and more resistant to the training data noise, but a bit less accurate decision tree. </param>
		/// <param name="truncatePrunedTree">If true, the cut off nodes (with Tn≤CvDTree::pruned_tree_idx) are physically removed from the tree. Otherwise they are kept, and by decreasing CvDTree::pruned_tree_idx (e.g. setting it to -1) it is still possible to get the results from the original un-pruned (or pruned less aggressively) tree. </param>
		/// <param name="priors">The array of a priori class probabilities, sorted by the class label value. The parameter can be used to tune the decision tree preferences toward a certain class. For example, if users want to detect some rare anomaly occurrence, the training base will likely contain much more normal cases than anomalies, so a very good classification performance will be achieved just by considering every case as normal. To avoid this, the priors can be specified, where the anomaly probability is artificially increased (up to 0.5 or even greater), so the weight of the misclassified anomalies becomes much bigger, and the tree is adjusted properly. </param>
#endif
        public CvDTreeParams(int maxDepth, int minSampleCount, float regressionAccuracy,
            bool useSurrogates, int maxCategories, int cvFolds, bool use1seRule, 
            bool truncatePrunedTree, float[] priors)
        {					
            IntPtr priorsPtr = IntPtr.Zero;
            if (priors != null)
            {
                handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
                priorsPtr = handle.AddrOfPinnedObject();
            }

            ptr = NativeMethods.ml_CvDTreeParams_new2(
                maxDepth, minSampleCount, regressionAccuracy, useSurrogates ? 1 : 0,
                maxCategories, cvFolds, use1seRule ? 1: 0, truncatePrunedTree ? 1 : 0, 
                priorsPtr);

            this.priors = priors;
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (handle.IsAllocated)
                        {
                            handle.Free();
                        }
                    }
                    if (IsEnabledDispose)
                    {
                        if(ptr != IntPtr.Zero)
                            NativeMethods.ml_CvDTreeParams_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties

#if LANG_JP
        /// <summary>
        /// 学習手続きが分岐を作るときの離散変数が MaxCategoriesよりも多くの値を取ろうとするならば，
		/// （アルゴリズムが指数関数的であるので）正確な部分集合推定を行う場合に非常に時間がかかる可能性がある． 
		/// 代わりに，（MLを含む）多くの決定木エンジンが，全サンプルを MaxCategories 個のクラスタに分類することによって
		/// （つまりいくつかのカテゴリは一つにマージされる），この場合の次善最適分岐を見つけようとする．
		/// このテクニックは，N(>2)-クラス分類問題においてのみ適用されることに注意する． 
		/// 回帰および 2-クラス分類の場合は，このような手段をとらなくても効率的に最適分岐を見つけることができるので，このパラメータは使用されない． 
        /// </summary>
#else
        /// <summary>
        /// If a discrete variable, on which the training procedure tries to make a split, takes more than MaxCategories values, 
		/// the precise best subset estimation may take a very long time (as the algorithm is exponential). 
		/// Instead, many decision trees engines (including ML) try to find sub-optimal split in this case by clustering 
		/// all the samples into MaxCategories clusters (i.e. some categories are merged together).
		/// Note that this technique is used only in N(>2)-class classification problems. In case of regression and 2-class classification
		/// the optimal split can be found efficiently without employing clustering, thus the parameter is not used in these cases. 
        /// </summary>
#endif
        public int MaxCategories
        {
            get { return NativeMethods.ml_CvDTreeParams_max_categories_get(ptr); }
            set { NativeMethods.ml_CvDTreeParams_max_categories_set(ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// このパラメータは木が取りうる最大の深さを決定する．学習アルゴリズムは，ノードの深さが max_depth  よりも小さいならば，
		/// それを分岐させようとする．他の終了条件が満たされた場合や（セクション始めにある学習手続きの概要を参照），
		/// あるいは/さらに，木が刈り込まれた場合など，実際の深さはもっと浅いかもしれない． 
        /// </summary>
#else
		/// <summary>
        /// This parameter specifies the maximum possible depth of the tree. That is the training algorithms attempts to split a node 
		/// while its depth is less than max_depth. The actual depth may be smaller if the other termination criteria are met
		/// (see the outline of the training procedure in the beginning of the section), and/or if the tree is pruned. 
        /// </summary>
#endif
        public int MaxDepth
        {
            get { return NativeMethods.ml_CvDTreeParams_max_depth_get(ptr); }
            set { NativeMethods.ml_CvDTreeParams_max_depth_set(ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// あるノードに対するサンプル数がこのパラメータ値よりも少ない場合，そのノードは分岐しない．
        /// </summary>
#else
		/// <summary>
        /// A node is not split if the number of samples directed to the node is less than the parameter value. 
        /// </summary>
#endif
        public int MinSampleCount
        {
            get { return NativeMethods.ml_CvDTreeParams_min_sample_count_get(ptr); }
            set { NativeMethods.ml_CvDTreeParams_min_sample_count_set(ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// このパラメータが >1 の場合，木は cv_folds 分割交差検証法により刈り込まれる． 
        /// </summary>
#else
		/// <summary>
        /// If this parameter is >1, the tree is pruned using cv_folds-fold cross validation. 
        /// </summary>
#endif
        public int CvFolds
        {
            get { return NativeMethods.ml_CvDTreeParams_cv_folds_get(ptr); }
            set { NativeMethods.ml_CvDTreeParams_cv_folds_set(ptr, value); }
        }

#if LANG_JP
        /// <summary>
        /// trueの場合，代理分岐が構築される． 代理分岐は観測値データの欠損を処理する場合や，変数の重要度の推定に必要である．
        /// </summary>
#else
		/// <summary>
        /// If true, surrogate splits are built. Surrogate splits are needed to handle missing measurements and for variable importance estimation. 
        /// </summary>
#endif
        public bool UseSurrogates
        {
            get { return NativeMethods.ml_CvDTreeParams_use_surrogates_get(ptr) != 0; }
            set { NativeMethods.ml_CvDTreeParams_use_surrogates_set(ptr, value ? 1 : 0); }
        }
#if LANG_JP
        /// <summary>
        /// true の場合，木は刈り込み手続きによって切り捨てられる．
		/// これにより，コンパクトで学習データノイズに対してより耐性を持つような木になるが，決定木の正確さはやや劣る． 
        /// </summary>
#else
		/// <summary>
        /// If true, the tree is truncated a bit more by the pruning procedure. 
		/// That leads to compact, and more resistant to the training data noise, but a bit less accurate decision tree. 
        /// </summary>
#endif
        public bool Use1seRule
        {
            get { return NativeMethods.ml_CvDTreeParams_use_1se_rule_get(ptr) != 0; }
            set { NativeMethods.ml_CvDTreeParams_use_1se_rule_set(ptr, value ? 1 : 0); }
        }
#if LANG_JP
        /// <summary>
        /// true の場合，（Tn≤CvDTree::PrunedTreeIdxである） カットオフノードが，木から物理的に削除される． 
		/// そうでない場合は，それらは削除はされず，CvDTree::pruned_tree_idx を減らす（例えば -1 を設定する） ことによって，
		/// オリジナルの刈り込みされていない（あるいは積極的には刈り込まれていない）木からの結果を得ることができる． 
        /// </summary>
#else
		/// <summary>
        /// If true, the cut off nodes (with Tn≤CvDTree::pruned_tree_idx) are physically removed from the tree. 
		/// Otherwise they are kept, and by decreasing CvDTree::PrunedTreeIdx (e.g. setting it to -1) 
		/// it is still possible to get the results from the original un-pruned (or pruned less aggressively) tree. 
        /// </summary>
#endif
        public bool TruncatePrunedTree
        {
            get { return NativeMethods.ml_CvDTreeParams_truncate_pruned_tree_get(ptr) != 0; }
            set { NativeMethods.ml_CvDTreeParams_truncate_pruned_tree_set(ptr, value ? 1 : 0); }
        }

#if LANG_JP
        /// <summary>
        /// 別の終了条件 - 回帰木の場合のみ． 推定されたノード値が，そのノードの学習サンプルの応答に対して，
		/// このパラメータ値よりも低い精度を持つ場合，ノードはそれ以上分岐しなくなる．
        /// </summary>
#else
		/// <summary>
        /// Another stop criteria - only for regression trees. As soon as the estimated node value differs 
		/// from the node training samples responses by less than the parameter value, the node is not split further. 
        /// </summary>
#endif
        public float RegressionAccuracy
        {
            get { return NativeMethods.ml_CvDTreeParams_regression_accuracy_get(ptr); }
            set { NativeMethods.ml_CvDTreeParams_regression_accuracy_set(ptr, value); }
        }

#if LANG_JP
        /// <summary>
        /// クラスラベル値によって保存されたクラス事前確率の配列． 
		/// このパラメータは，ある特定のクラスに対する決定木の優先傾向を調整するために用いられる． 例えば，
		/// もしユーザがなんらかの珍しい例外的発生を検出したいと考えた場合，学習データは，おそらく例外的なケースよりも
		/// ずっと多くの正常なケースを含んでいるので， 全ケースが正常であるとみなすだけで，非常に優れた分類性能が実現されるだろう． 
		/// このように例外ケースを無視して分類性能を上げることを避けるために，事前確率を指定することができる． 
		/// 例外的なケースの確率を人工的に増加させる（0.5 まで，あるいはそれ以上に）ことで，分類に失敗した例外の重みがより大きくなり，木は適切に調節される． 
        /// </summary>
#else
		/// <summary>
        /// The array of a priori class probabilities, sorted by the class label value. 
		/// The parameter can be used to tune the decision tree preferences toward a certain class. 
		/// For example, if users want to detect some rare anomaly occurrence, the training base will likely contain much more normal cases
		/// than anomalies, so a very good classification performance will be achieved just by considering every case as normal. 
		/// To avoid this, the priors can be specified, where the anomaly probability is artificially increased (up to 0.5 or even greater), 
		/// so the weight of the misclassified anomalies becomes much bigger, and the tree is adjusted properly. 
        /// </summary>
#endif
        public float[] Priors
        {
            get { return priors; }
            set 
            { 
                priors = value;

                if (handle.IsAllocated)
                {
                    handle.Free();
                }
                if (value != null)
                {
                    handle = GCHandle.Alloc(value, GCHandleType.Pinned);
                    NativeMethods.ml_CvDTreeParams_priors_set(ptr, handle.AddrOfPinnedObject());
                }
            }
        }
		#endregion
    }
}
