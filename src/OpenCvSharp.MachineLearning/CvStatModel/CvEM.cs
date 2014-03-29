/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
    /// EMモデルクラス
    /// </summary>
#else
	/// <summary>
    /// EM model (cv::EM)
    /// </summary>
#endif
    public class CvEM : CvStatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Constants
        /// <summary>
        /// sizeof(cvEM)
        /// </summary>
        public static readonly int SizeOf = MLInvoke.cv_EM_sizeof();
#pragma warning disable 1591
        // Type of covariation matrices
        // ReSharper disable InconsistentNaming
		public const EMCovMatType COV_MAT_SPHERICAL = EMCovMatType.Spherical;
		public const EMCovMatType COV_MAT_DIAGONAL = EMCovMatType.Diagonal;
		public const EMCovMatType COV_MAT_GENERIC = EMCovMatType.Generic;
        // The initial step
		public const EMStartStep START_E_STEP = EMStartStep.E;
		public const EMStartStep START_M_STEP = EMStartStep.M;
		public const EMStartStep START_AUTO_STEP = EMStartStep.Auto;
        // ReSharper restore InconsistentNaming
#pragma warning restore 1591
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
#endif
        public CvEM()
            : this(5)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="nclusters"></param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="nclusters"></param>
#endif
        public CvEM(int nclusters)
            : this(nclusters, EMCovMatType.Diagonal)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="nclusters"></param>
        /// <param name="covMatType"></param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="nclusters"></param>
        /// <param name="covMatType"></param>
#endif
        public CvEM(int nclusters, EMCovMatType covMatType)
            : this(nclusters, covMatType, new CvTermCriteria(100, double.Epsilon))
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="nclusters"></param>
        /// <param name="covMatType"></param>
        /// <param name="termCrit"></param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="nclusters"></param>
        /// <param name="covMatType"></param>
        /// <param name="termCrit"></param>
#endif
        public CvEM(int nclusters, EMCovMatType covMatType, CvTermCriteria termCrit)
        {
            ptr = MLInvoke.cv_EM_new(nclusters, covMatType, termCrit);
			NotifyMemoryPressure(SizeOf);
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        MLInvoke.cv_EM_delete(ptr);
                        //ML.CvEM_clear(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /*
#if LANG_JP
        /// <summary>
	    /// 混合数を返す
	    /// </summary>
	    /// <returns>混合数</returns>
#else
		/// <summary>
	    /// Returns the number of mixtures
	    /// </summary>
	    /// <returns>the number of mixtures</returns>
#endif
	    public int GetNClusters()
	    {
            return MLInvoke.CvEM_get_nclusters(ptr);
	    }
#if LANG_JP
        /// <summary>
        /// 混合分布の平均a_kの初期値を返す
        /// </summary>
        /// <returns>混合分布の平均a_kの初期値</returns>
#else
		/// <summary>
        /// Returns initial mixture means a_k
        /// </summary>
        /// <returns>initial mixture means a_k</returns>
#endif
		public CvMat GetMeans()
        {
            IntPtr p = MLInvoke.CvEM_get_means(ptr);
            if (p == IntPtr.Zero)
                return null;
            else
                return new CvMat(p, false);
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の共変動行列S_kの初期値を返す
        /// </summary>
        /// <returns></returns>
#else
		/// <summary>
        /// Returns initial mixture covariation matrices S_k
        /// </summary>
        /// <returns>initial mixture covariation matrices S_k</returns>
#endif
        public CvMat[] GetCovs()
        {
            int nclusters = GetNClusters();
            IntPtr[] src = new IntPtr[nclusters];
            MLInvoke.CvEM_get_covs2(ptr, src, nclusters);
            CvMat[] result = new CvMat[nclusters];
            //IntPtr p = MLInvoke.CvEM_get_covs(ptr);
            //p.ToString();
            for (int i = 0; i < nclusters; i++)
            {
                result[i] = new CvMat(src[i], false);
            }
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の共変動行列S_kの初期値へのポインタ(const CvMat**)を返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns initial mixture covariation matrices S_k
        /// </summary>
        /// <returns>initial mixture covariation matrices S_k</returns>
#endif
        public IntPtr GetCovsPtr()
        {
            return MLInvoke.CvEM_get_covs(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の重みπ_kの初期値を返す
        /// </summary>
        /// <returns></returns>
#else
		/// <summary>
        /// Returns initial mixture weights π_k
        /// </summary>
        /// <returns>initial mixture weights π_k</returns>
#endif
		public CvMat GetWeights()
        {
            IntPtr p = MLInvoke.CvEM_get_weights(ptr);
            if (p == IntPtr.Zero)
                return null;
            else
                return new CvMat(p, false);
        }
#if LANG_JP
        /// <summary>
        /// 確率p_i,kの初期値を返す
        /// </summary>
        /// <returns></returns>
#else
		/// <summary>
        /// Returns initial probabilities p_i,k,
        /// </summary>
        /// <returns></returns>
#endif
		public CvMat GetProbs()
        {
            IntPtr p = MLInvoke.CvEM_get_probs(ptr);
            if (p == IntPtr.Zero)
                return null;
            else
                return new CvMat(p, false);
        }
        //*/
#if LANG_JP
        /// <summary>
	    /// サンプルに対する応答を予測する
	    /// </summary>
	    /// <param name="sample"></param>
	    /// <param name="probs"></param>
#else
		/// <summary>
	    /// Predicts the response for sample
	    /// </summary>
	    /// <param name="sample"></param>
	    /// <param name="probs"></param>
#endif
        public virtual float[] Predict(CvMat sample, CvMat probs)
	    {
		    if(sample == null)
                throw new ArgumentNullException("sample");
            IntPtr probsPtr = (probs == null) ? IntPtr.Zero : probs.CvPtr;

            float ret0, ret1;
            MLInvoke.cv_EM_predict(ptr, sample.CvPtr, probsPtr, out ret0, out ret1);
            return new float[2] { ret0, ret1 };
	    }

#if LANG_JP
	    /// <summary>
	    /// サンプル集合からガウス混合パラメータを推定する
	    /// </summary>
	    /// <param name="samples"></param>
	    /// <param name="sample_idx"></param>
        /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
        /// <param name="probs"></param>
#else
        /// <summary>
	    /// Estimates Gaussian mixture parameters from the sample set
	    /// </summary>
	    /// <param name="samples"></param>
	    /// <param name="sampleIdx"></param>
        /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
        /// <param name="probs"></param>
#endif
        public virtual bool Train(CvMat samples, CvMat sampleIdx, CvMat logLikelihoods, CvMat labels, CvMat probs)
	    {
            if (samples == null)
                throw new ArgumentNullException("samples");

            IntPtr logLikelihoodsPtr = (logLikelihoods == null) ? IntPtr.Zero : logLikelihoods.CvPtr;
            IntPtr labelsPtr = (labels == null) ? IntPtr.Zero : labels.CvPtr;
            IntPtr probsPtr = (probs == null) ? IntPtr.Zero : probs.CvPtr;

            return MLInvoke.cv_EM_train(ptr, samples.CvPtr, logLikelihoodsPtr, labelsPtr, probsPtr) != 0;
	    }

#if LANG_JP
        /// <summary>
        /// メモリを解放し，モデルの状態をリセットする
        /// </summary>
#else
		/// <summary>
        /// Deallocates memory and resets the model state
        /// </summary>
#endif
        public override void Clear() 
        {
            MLInvoke.cv_EM_clear(ptr);
        }
        #endregion
    }
}
