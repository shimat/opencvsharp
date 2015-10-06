using System;
using OpenCvSharp.ML;

// ReSharper disable once InconsistentNaming

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// EMモデルクラス
    /// </summary>
#else
    /// <summary>
    /// The class implements the Expectation Maximization algorithm.
    /// </summary>
#endif
    public class EM : Algorithm
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<EM> ptrObj;

        #region Constants

#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        public const int DEFAULT_NCLUSTERS = 5;
        public const int DEFAULT_MAX_ITERS = 100;
// ReSharper restore InconsistentNaming
#pragma warning restore 1591

        #endregion

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::EM*
        /// </summary>
        protected EM(IntPtr p)
        {
            ptrObj = new Ptr<EM>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates empty EM model. 
        /// </summary>
        /// <returns></returns>
        public static EM Create()
	    {
            IntPtr ptr = NativeMethods.ml_SVM_create();
            return new EM(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    ptr = IntPtr.Zero;
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
        /// The number of mixture components in the Gaussian mixture model.
        /// Default value of the parameter is EM::DEFAULT_NCLUSTERS=5. 
        /// Some of EM implementation could determine the optimal number of mixtures 
        /// within a specified value range, but that is not the case in ML yet.
        /// </summary>
        public int ClustersNumber
        {
            get { return NativeMethods.ml_EM_getClustersNumber(ptr); }
            set { NativeMethods.ml_EM_setClustersNumber(ptr, value); }
        }

        /// <summary>
        /// Constraint on covariance matrices which defines type of matrices.
        /// </summary>
        public int CovarianceMatrixType
        {
            get { return NativeMethods.ml_EM_getCovarianceMatrixType(ptr); }
            set { NativeMethods.ml_EM_setCovarianceMatrixType(ptr, value); }
        }

        /// <summary>
        /// The termination criteria of the %EM algorithm.
        /// The EM algorithm can be terminated by the number of iterations 
        /// termCrit.maxCount (number of M-steps) or when relative change of likelihood 
        /// logarithm is less than termCrit.epsilon. 
        /// Default maximum number of iterations is EM::DEFAULT_MAX_ITERS=100.
        /// </summary>
        public TermCriteria TermCriteria
        {
            get { return NativeMethods.ml_EM_getTermCriteria(ptr); }
            set { NativeMethods.ml_EM_setTermCriteria(ptr, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns weights of the mixtures.
        /// Returns vector with the number of elements equal to the number of mixtures.
        /// </summary>
        /// <returns></returns>
        public Mat GetWeights()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            IntPtr p = NativeMethods.ml_EM_getWeights(ptr);
            return new Mat(p);
        }

        /// <summary>
        /// Returns the cluster centers (means of the Gaussian mixture).
        /// Returns matrix with the number of rows equal to the number of mixtures and 
        /// number of columns equal to the space dimensionality.
        /// </summary>
        /// <returns></returns>
        public Mat GetMeans()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            IntPtr p = NativeMethods.ml_EM_getMeans(ptr);
            return new Mat(p);
        }

        /// <summary>
        /// Returns covariation matrices.
        /// Returns vector of covariation matrices. Number of matrices is the number of 
        /// gaussian mixtures, each matrix is a square floating-point matrix NxN, where N is the space dimensionality.
        /// </summary>
        public Mat[] GetCovs()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            using (var vec = new VectorOfMat())
            {
                NativeMethods.ml_EM_getCovs(ptr, vec.CvPtr);
                return vec.ToArray();
            }
            
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
                throw new ObjectDisposedException(GetType().Name);
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
            GC.KeepAlive(samples);
            GC.KeepAlive(means0);
            GC.KeepAlive(covs0);
            GC.KeepAlive(weights0);

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
                throw new ObjectDisposedException(GetType().Name);
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
            GC.KeepAlive(samples);
            GC.KeepAlive(probs0);

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
        public virtual Vec2d Predict2(InputArray sample, OutputArray probs = null)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();
            if (probs != null)
                probs.ThrowIfNotReady();

            Vec2d ret = NativeMethods.ml_EM_predict2(ptr, sample.CvPtr, Cv2.ToPtr(probs));
            if (probs != null)
                probs.Fix();
            GC.KeepAlive(sample);
            return ret;
        }

        #endregion

        #region Types

        /// <summary>
        /// Type of covariation matrices
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// A scaled identity matrix \f$\mu_k * I\f$. 
            /// There is the only parameter \f$\mu_k\f$ to be estimated for each matrix. 
            /// The option may be used in special cases, when the constraint is relevant, 
            /// or as a first step in the optimization (for example in case when the data is 
            /// preprocessed with PCA). The results of such preliminary estimation may be 
            /// passed again to the optimization procedure, this time with covMatType=EM::COV_MAT_DIAGONAL.
            /// </summary>
            CovMatSpherical = 0,

            /// <summary>
            /// A diagonal matrix with positive diagonal elements. 
            /// The number of free parameters is d for each matrix. 
            /// This is most commonly used option yielding good estimation results. 
            /// </summary>
            CovMatDiagonal = 1,

            /// <summary>
            /// A symmetric positively defined matrix. The number of free parameters in each 
            /// matrix is about \f$d^2/2\f$. It is not recommended to use this option, unless 
            /// there is pretty accurate initial estimation of the parameters and/or a huge number 
            /// of training samples.
            /// </summary>
            CovMatGeneric = 2,

            /// <summary>
            /// 
            /// </summary>
            CovMatDefault = CovMatSpherical,
        }

#if LANG_JP
    /// <summary>
	/// アルゴリズムをスタートする最初のステップ
	/// </summary>
#else
        /// <summary>
        /// The initial step the algorithm starts from
        /// </summary>
#endif
        public enum StartStep : int
        {
#if LANG_JP
		/// <summary>
		/// アルゴリズムはE-stepでスタートする. 少なくとも平均ベクトルの初期値 CvEMParams.Means が渡されなければならない． 
		/// オプションとして，ユーザは重み（CvEMParams.Weights）と/または共変動行列（CvEMParams.Covs）を与えることもできる．
		/// [CvEM::START_E_STEP]
		/// </summary>
#else
            /// <summary>
            /// The algorithm starts with E-step. 
            /// At least, the initial values of mean vectors, CvEMParams.Means must be passed. 
            /// Optionally, the user may also provide initial values for weights (CvEMParams.Weights) 
            /// and/or covariation matrices (CvEMParams.Covs).
            /// [CvEM::START_E_STEP]
            /// </summary>
#endif
            E = 1,
#if LANG_JP
		/// <summary>
		/// アルゴリズムはM-stepでスタートする.初期確率 p_i,k が与えられなければならない．
		/// [CvEM::START_M_STEP]
		/// </summary>
#else
            /// <summary>
            /// The algorithm starts with M-step. The initial probabilities p_i,k must be provided.
            /// [CvEM::START_M_STEP]
            /// </summary>
#endif
            M = 2,
#if LANG_JP
		/// <summary>
		/// ユーザから必要な値が指定されない場合，k-meansアルゴリズムが混合分布パラメータの初期値推定に用いられる．
		/// [CvEM::START_AUTO_STEP]
		/// </summary>
#else
            /// <summary>
            /// No values are required from the user, k-means algorithm is used to estimate initial mixtures parameters. 
            /// [CvEM::START_AUTO_STEP]
            /// </summary>
#endif
            Auto = 0,
        }

        #endregion
    }
}
