using System;

// ReSharper disable once InconsistentNaming

namespace OpenCvSharp.CPlusPlus
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
    public class EM : Algorithm
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<EM> modelPtr;

        #region Constants
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        // Default parameters
	    public const int DEFAULT_NCLUSTERS = 5, 
            DEFAULT_MAX_ITERS = 100;
        // Type of covariation matrices
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
        /// <param name="nClusters"></param>
        /// <param name="covMatType"></param>
        /// <param name="termCrit"></param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="nClusters"></param>
        /// <param name="covMatType"></param>
        /// <param name="termCrit"></param>
#endif
        public EM(
            int nClusters = DEFAULT_NCLUSTERS, 
            EMCovMatType covMatType = EMCovMatType.Diagonal, 
            TermCriteria? termCrit = null)
        {
            var termCrit0 = termCrit.GetValueOrDefault(
                TermCriteria.Both(DEFAULT_MAX_ITERS, Double.Epsilon));
            ptr = NativeMethods.ml_EM_new(nClusters, (int)covMatType, termCrit0);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal EM(Ptr<EM> detectorPtr)
        {
            this.modelPtr = detectorPtr;
            this.ptr = detectorPtr.Obj;
        }
        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal EM(IntPtr rawPtr)
        {
            modelPtr = null;
            ptr = rawPtr;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static EM FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<EM> pointer");
            var ptrObj = new Ptr<EM>(ptr);
            return new EM(ptrObj);
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
                        if (modelPtr != null)
                        {
                            modelPtr.Dispose();
                            modelPtr = null;
                        }
                        else
                        {
                            if(ptr != IntPtr.Zero)
                                NativeMethods.ml_EM_delete(ptr);
                            ptr = IntPtr.Zero;
                        }
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
        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.ml_EM_info(ptr); }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public bool IsTrained
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("EM");
                return NativeMethods.ml_EM_isTrained(ptr) != 0;
            }
        }
        #endregion

        #region Methods

#if LANG_JP
	    /// <summary>
	    /// サンプル集合からガウス混合パラメータを推定する
	    /// </summary>
	    /// <param name="samples"></param>
        /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
        /// <param name="probs"></param>
#else
        /// <summary>
	    /// Estimates Gaussian mixture parameters from the sample set
	    /// </summary>
	    /// <param name="samples"></param>
        /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
        /// <param name="probs"></param>
#endif
        public virtual bool Train(
            InputArray samples, 
            OutputArray logLikelihoods = null,
            OutputArray labels = null,
            OutputArray probs = null)
	    {
            if (disposed)
                throw new ObjectDisposedException("EM");
            if (samples == null)
                throw new ArgumentNullException("samples");
            samples.ThrowIfDisposed();
            if (logLikelihoods != null)
                logLikelihoods.ThrowIfNotReady();
            if (labels != null)
                labels.ThrowIfNotReady();
            if (probs != null)
                probs.ThrowIfNotReady();

            int ret = NativeMethods.ml_EM_train(
                ptr, 
                samples.CvPtr, 
                Cv2.ToPtr(logLikelihoods), 
                Cv2.ToPtr(labels), 
                Cv2.ToPtr(probs));

            if (logLikelihoods != null)
                logLikelihoods.Fix();
            if (labels != null)
                labels.Fix();
            if (probs != null)
                probs.Fix();

            return ret != 0;
	    }

#if LANG_JP
	    /// <summary>
	    /// サンプル集合からガウス混合パラメータを推定する
	    /// </summary>
	    /// <param name="samples"></param>
	    /// <param name="means0"></param>
	    /// <param name="covs0"></param>
	    /// <param name="weights0"></param>
	    /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
        /// <param name="probs"></param>
#else
        /// <summary>
	    /// Estimates Gaussian mixture parameters from the sample set
	    /// </summary>
	    /// <param name="samples"></param>
	    /// <param name="means0"></param>
	    /// <param name="covs0"></param>
	    /// <param name="weights0"></param>
	    /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
	    /// <param name="probs"></param>
#endif
        public virtual bool TrainE(
            InputArray samples,
            InputArray means0,
            InputArray covs0 = null,
            InputArray weights0 = null,
            OutputArray logLikelihoods = null,
            OutputArray labels = null,
            OutputArray probs = null)
        {
            if (disposed)
                throw new ObjectDisposedException("EM");
            if (samples == null)
                throw new ArgumentNullException("samples");
            if (means0 == null)
                throw new ArgumentNullException("means0");
            samples.ThrowIfDisposed();
            means0.ThrowIfDisposed();

            if (logLikelihoods != null)
                logLikelihoods.ThrowIfNotReady();
            if (covs0 != null)
                covs0.ThrowIfDisposed();
            if (weights0 != null)
                weights0.ThrowIfDisposed();
            if (labels != null)
                labels.ThrowIfNotReady();
            if (probs != null)
                probs.ThrowIfNotReady();

            int ret = NativeMethods.ml_EM_trainE(
                ptr,
                samples.CvPtr,
                means0.CvPtr,
                Cv2.ToPtr(covs0),
                Cv2.ToPtr(weights0),
                Cv2.ToPtr(logLikelihoods),
                Cv2.ToPtr(labels),
                Cv2.ToPtr(probs));

            if (logLikelihoods != null)
                logLikelihoods.Fix();
            if (labels != null)
                labels.Fix();
            if (probs != null)
                probs.Fix();

            return ret != 0;
        }

#if LANG_JP
	    /// <summary>
	    /// サンプル集合からガウス混合パラメータを推定する
	    /// </summary>
	    /// <param name="samples"></param>
	    /// <param name="probs0"></param>
	    /// <param name="logLikelihoods"></param>
	    /// <param name="labels"></param>
        /// <param name="probs"></param>
#else
        /// <summary>
        /// Estimates Gaussian mixture parameters from the sample set
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="probs0"></param>
        /// <param name="logLikelihoods"></param>
        /// <param name="labels"></param>
        /// <param name="probs"></param>
#endif
        public virtual bool TrainM(
            InputArray samples,
            InputArray probs0,
            OutputArray logLikelihoods = null,
            OutputArray labels = null,
            OutputArray probs = null)
        {
            if (disposed)
                throw new ObjectDisposedException("EM");
            if (samples == null)
                throw new ArgumentNullException("samples");
            if (probs0 == null)
                throw new ArgumentNullException("probs0");
            samples.ThrowIfDisposed();
            probs0.ThrowIfDisposed();

            if (logLikelihoods != null)
                logLikelihoods.ThrowIfNotReady();
            if (labels != null)
                labels.ThrowIfNotReady();
            if (probs != null)
                probs.ThrowIfNotReady();

            int ret = NativeMethods.ml_EM_trainM(
                ptr,
                samples.CvPtr,
                probs0.CvPtr,
                Cv2.ToPtr(logLikelihoods),
                Cv2.ToPtr(labels),
                Cv2.ToPtr(probs));

            if (logLikelihoods != null)
                logLikelihoods.Fix();
            if (labels != null)
                labels.Fix();
            if (probs != null)
                probs.Fix();

            return ret != 0;
        }

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
        public virtual Vec2d Predict(InputArray sample, OutputArray probs = null)
        {
            if (disposed)
                throw new ObjectDisposedException("EM");
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();
            if(probs != null)
                probs.ThrowIfNotReady();

            Vec2d ret;
            NativeMethods.ml_EM_predict(ptr, sample.CvPtr, Cv2.ToPtr(probs), out ret);
            if (probs != null) 
                probs.Fix();
            return ret;
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
        public void Clear() 
        {
            if (disposed)
                throw new ObjectDisposedException("EM");
            NativeMethods.ml_EM_clear(ptr);
        }
        #endregion
    }
}
