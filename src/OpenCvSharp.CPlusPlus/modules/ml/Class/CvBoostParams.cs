using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// ブースティングの学習パラメータ
    /// </summary>
#else
	/// <summary>
    /// Boosting training parameters
    /// </summary>
#endif
    public class CvBoostParams : CvDTreeParams
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
        internal CvBoostParams(IntPtr ptr, bool isEnabledDispose)
        {
            this.ptr = ptr;
            IsEnabledDispose = isEnabledDispose;
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
        public CvBoostParams()
        {
            ptr = NativeMethods.ml_BoostParams_new1();
        }

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="boostType">ブースティングの種類</param>
        /// <param name="weakCount">構築する弱い分類器の個数</param>
        /// <param name="weightTrimRate">トリミング重み比率．0..1 の範囲内．もしこのパラメータが ≤0 あるいは >1 の場合，トリミングは行われず，全てのサンプルが各繰り返し計算で用いられる．デフォルト値は 0.95 である</param>
        /// <param name="maxDepth">このパラメータは木が取りうる最大の深さを決定する．学習アルゴリズムは，ノードの深さが max_depth  よりも小さいならば，それを分岐させようとする．他の終了条件が満たされた場合や（セクション始めにある学習手続きの概要を参照）， あるいは/さらに，木が刈り込まれた場合など，実際の深さはもっと浅いかもしれない．</param>
        /// <param name="useSurrogates">trueの場合，代理分岐が構築される． 代理分岐は観測値データの欠損を処理する場合や，変数の重要度の推定に必要である． </param>
		/// <param name="priors">クラスラベル値によって保存されたクラス事前確率の配列． このパラメータは，ある特定のクラスに対する決定木の優先傾向を調整するために用いられる． 例えば，もしユーザがなんらかの珍しい例外的発生を検出したいと考えた場合，学習データは，おそらく例外的なケースよりもずっと多くの正常なケースを含んでいるので， 全ケースが正常であるとみなすだけで，非常に優れた分類性能が実現されるだろう． このように例外ケースを無視して分類性能を上げることを避けるために，事前確率を指定することができる． 例外的なケースの確率を人工的に増加させる（0.5 まで，あるいはそれ以上に）ことで，分類に失敗した例外の重みがより大きくなり，木は適切に調節される． </param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="boostType">Boosting type</param>
        /// <param name="weakCount">The number of weak classifiers to build. </param>
        /// <param name="weightTrimRate">he weight trimming ratio, within 0..1. If the parameter is ≤0 or >1, the trimming is not used, all the samples are used at each iteration. The default value is 0.95. </param>
        /// <param name="maxDepth">This parameter specifies the maximum possible depth of the tree. That is the training algorithms attempts to split a node while its depth is less than max_depth. The actual depth may be smaller if the other termination criteria are met (see the outline of the training procedure in the beginning of the section), and/or if the tree is pruned. </param>
        /// <param name="useSurrogates">If true, surrogate splits are built. Surrogate splits are needed to handle missing measurements and for variable importance estimation. </param>
        /// <param name="priors">The array of a priori class probabilities, sorted by the class label value. The parameter can be used to tune the decision tree preferences toward a certain class. For example, if users want to detect some rare anomaly occurrence, the training base will likely contain much more normal cases than anomalies, so a very good classification performance will be achieved just by considering every case as normal. To avoid this, the priors can be specified, where the anomaly probability is artificially increased (up to 0.5 or even greater), so the weight of the misclassified anomalies becomes much bigger, and the tree is adjusted properly. </param>
#endif
        public CvBoostParams(BoostType boostType, int weakCount, double weightTrimRate,
            int maxDepth, bool useSurrogates, float[] priors)
        {
            IntPtr priorsPtr = IntPtr.Zero;
            if (priors != null)
            {
                handle = GCHandle.Alloc(priors, GCHandleType.Pinned);
                priorsPtr = handle.AddrOfPinnedObject();
            }
            base.priors = priors;

            ptr = NativeMethods.ml_BoostParams_new2(
                (int)boostType,
                weakCount,
                weightTrimRate,
                maxDepth,
                useSurrogates ? 1 : 0,
                priorsPtr
            );
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
                        if(ptr != IntPtr.Zero)
                            NativeMethods.ml_BoostParams_delete(ptr);
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
        /// ブースティングの種類
        /// </summary>
#else
	    /// <summary>
	    /// Boosting type
	    /// </summary>
#endif
	    public unsafe BoostType BoostType
	    {
	        get
	        {
	            int val = *NativeMethods.ml_BoostParams_boost_type(ptr);
	            return (BoostType)val;
	        }
	        set { *NativeMethods.ml_BoostParams_boost_type(ptr) = (int)value; }
	    }

#if LANG_JP
        /// <summary>
        /// 構築する弱い分類器の個数． 
        /// </summary>
#else
        /// <summary>
        /// The number of weak classifiers to build. 
        /// </summary>
#endif
        public unsafe int WeakCount
        {
            get { return *NativeMethods.ml_BoostParams_weak_count(ptr); }
            set { *NativeMethods.ml_BoostParams_weak_count(ptr) = value; }
        }
#if LANG_JP
        /// <summary>
        /// 弱い木を構築するときの最適分岐を選択する際に用いられる分岐規則
        /// </summary>
#else
        /// <summary>
        /// Splitting criteria, used to choose optimal splits during a weak tree construction
        /// </summary>
#endif
        public unsafe BoostSplitCriteria SplitCriteria
        {
            get
            {
                int val = *NativeMethods.ml_BoostParams_split_criteria(ptr);
                return (BoostSplitCriteria)val;
            }
            set
            {
                *NativeMethods.ml_BoostParams_split_criteria(ptr) = (int)value;
            }
        }
#if LANG_JP
        /// <summary>
        /// トリミング重み比率．0..1 の範囲内．
		/// もしこのパラメータが ≤0 あるいは >1 の場合，トリミングは行われず，
		/// 全てのサンプルが各繰り返し計算で用いられる．デフォルト値は 0.95 である．
        /// </summary>
#else
        /// <summary>
        /// The weight trimming ratio, within 0..1. 
        /// If the parameter is ≤0 or >1, the trimming is not used, 
        /// all the samples are used at each iteration. The default value is 0.95. 
        /// </summary>
#endif
        public unsafe double WeightTrimRate
        {
            get { return *NativeMethods.ml_BoostParams_weight_trim_rate(ptr); }
            set { *NativeMethods.ml_BoostParams_weight_trim_rate(ptr) = value; }
        }
        #endregion
    }
}
