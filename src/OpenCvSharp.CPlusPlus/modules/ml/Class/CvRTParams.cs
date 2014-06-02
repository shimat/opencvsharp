using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// ランダムツリーの学習パラメータ
    /// </summary>
#else
	/// <summary>
    /// Training Parameters of Random Trees
    /// </summary>
#endif
    public class CvRTParams : CvDTreeParams
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
        internal protected CvRTParams(IntPtr ptr)
            : base(ptr)
        {
        }

#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
		/// <summary>
		/// Default constructor
		/// </summary>
#endif
		public CvRTParams() 
            : base(IntPtr.Zero)
		{
			ptr = NativeMethods.ml_CvRTParams_new1();
		}

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="maxDepth">このパラメータは木が取りうる最大の深さを決定する．学習アルゴリズムは，ノードの深さが max_depth  よりも小さいならば，それを分岐させようとする．他の終了条件が満たされた場合や（セクション始めにある学習手続きの概要を参照）， あるいは/さらに，木が刈り込まれた場合など，実際の深さはもっと浅いかもしれない．</param>
        /// <param name="minSampleCount">あるノードに対するサンプル数がこのパラメータ値よりも少ない場合，そのノードは分岐しない．</param>
        /// <param name="regressionAccuracy">別の終了条件 - 回帰木の場合のみ． 推定されたノード値が，そのノードの学習サンプルの応答に対して，このパラメータ値よりも低い精度を持つ場合，ノードはそれ以上分岐しなくなる．</param>
        /// <param name="useSurrogates">trueの場合，代理分岐が構築される． 代理分岐は観測値データの欠損を処理する場合や，変数の重要度の推定に必要である．</param>
        /// <param name="maxCategories">学習手続きが分岐を作るときの離散変数が max_categoriesよりも多くの値を取ろうとするならば， （アルゴリズムが指数関数的であるので）正確な部分集合推定を行う場合に非常に時間がかかる可能性がある． 代わりに，（MLを含む）多くの決定木エンジンが，全サンプルを max_categories 個のクラスタに分類することによって （つまりいくつかのカテゴリは一つにマージされる），この場合の次善最適分岐を見つけようとする．このテクニックは，N(>2)-クラス分類問題においてのみ適用されることに注意する． 回帰および 2-クラス分類の場合は，このような手段をとらなくても効率的に最適分岐を見つけることができるので，このパラメータは使用されない．</param>
		/// <param name="priors">クラスラベル値によって保存されたクラス事前確率の配列． このパラメータは，ある特定のクラスに対する決定木の優先傾向を調整するために用いられる． 例えば，もしユーザがなんらかの珍しい例外的発生を検出したいと考えた場合，学習データは，おそらく例外的なケースよりもずっと多くの正常なケースを含んでいるので， 全ケースが正常であるとみなすだけで，非常に優れた分類性能が実現されるだろう． このように例外ケースを無視して分類性能を上げることを避けるために，事前確率を指定することができる． 例外的なケースの確率を人工的に増加させる（0.5 まで，あるいはそれ以上に）ことで，分類に失敗した例外の重みがより大きくなり，木は適切に調節される． </param>
        /// <param name="calcVarImportance">セットされている場合，変数の重要度が学習の際に計算される． 計算した変数の重要度の配列を取り出すためには，CvRTrees::get_var_importance()を呼びだす. </param>
        /// <param name="nactiveVars">変数の数．それぞれのツリーでランダムに選択され，最適な分割を求めるために使用される．</param>
        /// <param name="termCrit">forestの成長に対する終了条件． term_crit.max_iterは，forestの中のツリーの最大数 （コンストラクタのパラメータであるmax_tree_countも参照する，デフォルトでは50）．term_crit.epsilonは，満足される精度を表す（OOB error）. </param>
#else
		/// <summary>
		/// Training constructor
		/// </summary>
		/// <param name="maxDepth">This parameter specifies the maximum possible depth of the tree. That is the training algorithms attempts to split a node while its depth is less than max_depth. The actual depth may be smaller if the other termination criteria are met (see the outline of the training procedure in the beginning of the section), and/or if the tree is pruned. </param>
		/// <param name="minSampleCount">A node is not split if the number of samples directed to the node is less than the parameter value. </param>
		/// <param name="regressionAccuracy">Another stop criteria - only for regression trees. As soon as the estimated node value differs from the node training samples responses by less than the parameter value, the node is not split further. </param>
		/// <param name="useSurrogates">If true, surrogate splits are built. Surrogate splits are needed to handle missing measurements and for variable importance estimation. </param>
		/// <param name="maxCategories">If a discrete variable, on which the training procedure tries to make a split, takes more than max_categories values, the precise best subset estimation may take a very long time (as the algorithm is exponential). Instead, many decision trees engines (including ML) try to find sub-optimal split in this case by clustering all the samples into max_categories clusters (i.e. some categories are merged together). Note that this technique is used only in N(>2)-class classification problems. In case of regression and 2-class classification the optimal split can be found efficiently without employing clustering, thus the parameter is not used in these cases. </param>
		/// <param name="priors">The array of a priori class probabilities, sorted by the class label value. The parameter can be used to tune the decision tree preferences toward a certain class. For example, if users want to detect some rare anomaly occurrence, the training base will likely contain much more normal cases than anomalies, so a very good classification performance will be achieved just by considering every case as normal. To avoid this, the priors can be specified, where the anomaly probability is artificially increased (up to 0.5 or even greater), so the weight of the misclassified anomalies becomes much bigger, and the tree is adjusted properly. </param>
		/// <param name="calcVarImportance">If it is set, then variable importance is computed by the training procedure. To retrieve the computed variable importance array, call the method CvRTrees::get_var_importance(). </param>
		/// <param name="nactiveVars">The number of variables that are randomly selected at each tree node and that are used to find the best split(s). </param>
		/// <param name="termCrit">Termination criteria for growing the forest: term_crit.max_iter is the maximum number of trees in the forest (see also max_tree_count parameter of the constructor, by default it is set to 50) term_crit.epsilon is the sufficient accuracy (OOB error). </param>
#endif
        public CvRTParams(
            int maxDepth, int minSampleCount, float regressionAccuracy, 
            bool useSurrogates, int maxCategories, float[] priors,
            bool calcVarImportance, int nactiveVars, CvTermCriteria termCrit)
            : base(IntPtr.Zero)
        {
            IntPtr priorsPtr = IntPtr.Zero;
            if (priors != null)
            {
                handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
                priorsPtr = handle.AddrOfPinnedObject();
            }
            this.priors = priors;

            ptr = NativeMethods.ml_CvRTParams_new2(
                maxDepth, minSampleCount, regressionAccuracy, useSurrogates ? 1 : 0, 
                maxCategories, priorsPtr, calcVarImportance ? 1 : 0, nactiveVars, 
                termCrit.MaxIter, (float)termCrit.Epsilon, (int)termCrit.Type);
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
                    }
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.ml_CvRTParams_delete(ptr);
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
        /// セットされている場合，変数の重要度が学習の際に計算される． 計算した変数の重要度の配列を取り出すためには，CvRTrees::get_var_importance()を呼びだす. 
        /// </summary>
#else
		/// <summary>
        /// If it is set, then variable importance is computed by the training procedure. To retrieve the computed variable importance array, call the method CvRTrees::get_var_importance(). 
        /// </summary>
#endif
        public bool CalcVarImportance
        {
            get { return NativeMethods.ml_CvRTParams_calc_var_importance_get(ptr) != 0; }
            set { NativeMethods.ml_CvRTParams_calc_var_importance_set(ptr, value ? 1 : 0); }
        }
#if LANG_JP
        /// <summary>
        /// 変数の数．それぞれのツリーでランダムに選択され，最適な分割を求めるために使用される． 
        /// </summary>
#else
		/// <summary>
        /// The number of variables that are randomly selected at each tree node and that are used to find the best split(s). 
        /// </summary>
#endif
        public int NactiveVars
        {
            get { return NativeMethods.ml_CvRTParams_nactive_vars_get(ptr); }
            set { NativeMethods.ml_CvRTParams_nactive_vars_set(ptr, value); }
        }
#if LANG_JP
        /// <summary>
        /// forestの成長に対する終了条件． 
		/// term_crit.max_iterは，forestの中のツリーの最大数 （コンストラクタのパラメータであるmax_tree_countも参照する，デフォルトでは50）．
		/// term_crit.epsilonは，満足される精度を表す（OOB error）. 
        /// </summary>
#else
		/// <summary>
        /// Termination criteria for growing the forest: 
		/// term_crit.max_iter is the maximum number of trees in the forest (see also max_tree_count parameter of the constructor, by default it is set to 50)
		/// term_crit.epsilon is the sufficient accuracy (OOB error). 
        /// </summary>
#endif
		public CvTermCriteria TermCrit
        {
            get { return NativeMethods.ml_CvRTParams_term_crit_get(ptr); }
            set { NativeMethods.ml_CvRTParams_term_crit_set(ptr, value); }
        }
		#endregion
    }
}
