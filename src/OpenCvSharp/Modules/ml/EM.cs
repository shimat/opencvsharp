using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// The class implements the Expectation Maximization algorithm.
/// </summary>
public class EM : Algorithm
{
    private Ptr? ptrObj;

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
    /// Creates instance by pointer cv::Ptr&lt;EM&gt;
    /// </summary>
    protected EM(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates empty EM model. 
    /// </summary>
    /// <returns></returns>
    public static EM Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_EM_create(out var ret));
        return new EM(ret);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static EM Load(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
        NativeMethods.HandleException(
            NativeMethods.ml_EM_load(filePath, out var ret));
        return new EM(ret);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public static EM LoadFromString(string strModel)
    {
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
        NativeMethods.HandleException(
            NativeMethods.ml_EM_loadFromString(strModel, out var ret));
        return new EM(ret);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected override void DisposeManaged()
    {
        ptrObj?.Dispose();
        ptrObj = null;
        base.DisposeManaged();
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
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_EM_getClustersNumber(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_EM_setClustersNumber(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Constraint on covariance matrices which defines type of matrices.
    /// </summary>
    public int CovarianceMatrixType
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_EM_getCovarianceMatrixType(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_EM_setCovarianceMatrixType(ptr, value));
            GC.KeepAlive(this);
        }
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
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_EM_getTermCriteria(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_EM_setTermCriteria(ptr, value));
            GC.KeepAlive(this);
        }
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
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_EM_getWeights(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the cluster centers (means of the Gaussian mixture).
    /// Returns matrix with the number of rows equal to the number of mixtures and 
    /// number of columns equal to the space dimensionality.
    /// </summary>
    /// <returns></returns>
    public Mat GetMeans()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_EM_getMeans(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// Returns covariation matrices.
    /// Returns vector of covariation matrices. Number of matrices is the number of 
    /// gaussian mixtures, each matrix is a square floating-point matrix NxN, where N is the space dimensionality.
    /// </summary>
    public Mat[] GetCovs()
    {
        ThrowIfDisposed();

        using var vec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.ml_EM_getCovs(ptr, vec.CvPtr));
        GC.KeepAlive(this);
        return vec.ToArray();
    }

    /// <summary>
    /// Estimate the Gaussian mixture parameters from a samples set.
    /// </summary>
    /// <param name="samples">Samples from which the Gaussian mixture model will be estimated. It should be a
    /// one-channel matrix, each row of which is a sample. If the matrix does not have CV_64F type
    /// it will be converted to the inner matrix of such type for the further computing.</param>
    /// <param name="logLikelihoods">The optional output matrix that contains a likelihood logarithm value for
    /// each sample. It has \f$nsamples \times 1\f$ size and CV_64FC1 type.</param>
    /// <param name="labels">The optional output "class label" for each sample:
    /// \f$\texttt{labels}_i=\texttt{arg max}_k(p_{i,k}), i=1..N\f$ (indices of the most probable
    /// mixture component for each sample). It has \f$nsamples \times 1\f$ size and CV_32SC1 type.</param>
    /// <param name="probs">The optional output matrix that contains posterior probabilities of each Gaussian
    /// mixture component given the each sample. It has \f$nsamples \times nclusters\f$ size and CV_64FC1 type.</param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public virtual bool TrainEM(
        InputArray samples,
        OutputArray? logLikelihoods = null,
        OutputArray? labels = null,
        OutputArray? probs = null)
    {
        ThrowIfDisposed();
        if (samples is null)
            throw new ArgumentNullException(nameof(samples));
        samples.ThrowIfDisposed();

        logLikelihoods?.ThrowIfNotReady();
        labels?.ThrowIfNotReady();
        probs?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_EM_trainEM(
                ptr,
                samples.CvPtr,
                Cv2.ToPtr(logLikelihoods),
                Cv2.ToPtr(labels),
                Cv2.ToPtr(probs),
                out var ret));

        logLikelihoods?.Fix();
        labels?.Fix();
        probs?.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(samples);
        GC.KeepAlive(logLikelihoods);
        GC.KeepAlive(labels);
        GC.KeepAlive(probs);
        return ret != 0;
    }

    /// <summary>
    /// Estimate the Gaussian mixture parameters from a samples set.
    /// </summary>
    /// <param name="samples">Samples from which the Gaussian mixture model will be estimated. It should be a
    /// one-channel matrix, each row of which is a sample. If the matrix does not have CV_64F type
    /// it will be converted to the inner matrix of such type for the further computing.</param>
    /// <param name="means0">Initial means \f$a_k\f$ of mixture components. It is a one-channel matrix of
    /// \f$nclusters \times dims\f$ size. If the matrix does not have CV_64F type it will be
    /// converted to the inner matrix of such type for the further computing.</param>
    /// <param name="covs0">The vector of initial covariance matrices \f$S_k\f$ of mixture components. Each of
    /// covariance matrices is a one-channel matrix of \f$dims \times dims\f$ size. If the matrices
    /// do not have CV_64F type they will be converted to the inner matrices of such type for the further computing.</param>
    /// <param name="weights0">Initial weights \f$\pi_k\f$ of mixture components. It should be a one-channel
    /// floating-point matrix with \f$1 \times nclusters\f$ or \f$nclusters \times 1\f$ size.</param>
    /// <param name="logLikelihoods">The optional output matrix that contains a likelihood logarithm value for
    /// each sample. It has \f$nsamples \times 1\f$ size and CV_64FC1 type.</param>
    /// <param name="labels">The optional output "class label" for each sample:
    /// \f$\texttt{labels}_i=\texttt{arg max}_k(p_{i,k}), i=1..N\f$ (indices of the most probable
    /// mixture component for each sample). It has \f$nsamples \times 1\f$ size and CV_32SC1 type.</param>
    /// <param name="probs">The optional output matrix that contains posterior probabilities of each Gaussian
    /// mixture component given the each sample. It has \f$nsamples \times nclusters\f$ size and CV_64FC1 type.</param>
    public virtual bool TrainE(
        InputArray samples,
        InputArray means0,
        InputArray? covs0 = null,
        InputArray? weights0 = null,
        OutputArray? logLikelihoods = null,
        OutputArray? labels = null,
        OutputArray? probs = null)
    {
        ThrowIfDisposed();
        if (samples is null)
            throw new ArgumentNullException(nameof(samples));
        if (means0 is null)
            throw new ArgumentNullException(nameof(means0));
        samples.ThrowIfDisposed();
        means0.ThrowIfDisposed();

        logLikelihoods?.ThrowIfNotReady();
        covs0?.ThrowIfDisposed();
        weights0?.ThrowIfDisposed();
        labels?.ThrowIfNotReady();
        probs?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_EM_trainE(
                ptr,
                samples.CvPtr,
                means0.CvPtr,
                Cv2.ToPtr(covs0),
                Cv2.ToPtr(weights0),
                Cv2.ToPtr(logLikelihoods),
                Cv2.ToPtr(labels),
                Cv2.ToPtr(probs),
                out var ret));

        logLikelihoods?.Fix();
        labels?.Fix();
        probs?.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(samples);
        GC.KeepAlive(means0);
        GC.KeepAlive(covs0);
        GC.KeepAlive(weights0);
        GC.KeepAlive(logLikelihoods);
        GC.KeepAlive(labels);
        GC.KeepAlive(probs);
        return ret != 0;
    }

    /// <summary>
    /// Estimate the Gaussian mixture parameters from a samples set.
    /// </summary>
    /// <param name="samples">Samples from which the Gaussian mixture model will be estimated. It should be a
    /// one-channel matrix, each row of which is a sample. If the matrix does not have CV_64F type
    /// it will be converted to the inner matrix of such type for the further computing.</param>
    /// <param name="probs0">the probabilities</param>
    /// <param name="logLikelihoods">The optional output matrix that contains a likelihood logarithm value for
    /// each sample. It has \f$nsamples \times 1\f$ size and CV_64FC1 type.</param>
    /// <param name="labels">The optional output "class label" for each sample:
    /// \f$\texttt{labels}_i=\texttt{arg max}_k(p_{i,k}), i=1..N\f$ (indices of the most probable
    /// mixture component for each sample). It has \f$nsamples \times 1\f$ size and CV_32SC1 type.</param>
    /// <param name="probs">The optional output matrix that contains posterior probabilities of each Gaussian
    /// mixture component given the each sample. It has \f$nsamples \times nclusters\f$ size and CV_64FC1 type.</param>
    public virtual bool TrainM(
        InputArray samples,
        InputArray probs0,
        OutputArray? logLikelihoods = null,
        OutputArray? labels = null,
        OutputArray? probs = null)
    {
        ThrowIfDisposed();
        if (samples is null)
            throw new ArgumentNullException(nameof(samples));
        if (probs0 is null)
            throw new ArgumentNullException(nameof(probs0));
        samples.ThrowIfDisposed();
        probs0.ThrowIfDisposed();

        logLikelihoods?.ThrowIfNotReady();
        labels?.ThrowIfNotReady();
        probs?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_EM_trainM(
                ptr,
                samples.CvPtr,
                probs0.CvPtr,
                Cv2.ToPtr(logLikelihoods),
                Cv2.ToPtr(labels),
                Cv2.ToPtr(probs), 
                out var ret));

        logLikelihoods?.Fix();
        labels?.Fix();
        probs?.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(samples);
        GC.KeepAlive(probs0);
        GC.KeepAlive(logLikelihoods);
        GC.KeepAlive(labels);
        GC.KeepAlive(probs);

        return ret != 0;
    }

    /// <summary>
    /// Predicts the response for sample
    /// </summary>
    /// <param name="sample">A sample for classification. It should be a one-channel matrix of
    /// \f$1 \times dims\f$ or \f$dims \times 1\f$ size.</param>
    /// <param name="probs">Optional output matrix that contains posterior probabilities of each component
    /// given the sample. It has \f$1 \times nclusters\f$ size and CV_64FC1 type.</param>
    public virtual Vec2d Predict2(InputArray sample, OutputArray? probs = null)
    {
        ThrowIfDisposed();
        if (sample is null)
            throw new ArgumentNullException(nameof(sample));
        sample.ThrowIfDisposed();
        probs?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_EM_predict2(ptr, sample.CvPtr, Cv2.ToPtr(probs), out var ret));
        probs?.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(sample);
        GC.KeepAlive(probs);
        return ret;
    }

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_EM_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_EM_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}

#pragma warning disable CA1027 // Mark enums with FlagsAttribute

/// <summary>
/// Type of covariation matrices
/// </summary>
public enum EMTypes
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

/// <summary>
/// The initial step the algorithm starts from
/// </summary>
public enum EMStartStep
{
    /// <summary>
    /// The algorithm starts with E-step. 
    /// At least, the initial values of mean vectors, CvEMParams.Means must be passed. 
    /// Optionally, the user may also provide initial values for weights (CvEMParams.Weights) 
    /// and/or covariation matrices (CvEMParams.Covs).
    /// [CvEM::START_E_STEP]
    /// </summary>
    E = 1,

    /// <summary>
    /// The algorithm starts with M-step. The initial probabilities p_i,k must be provided.
    /// [CvEM::START_M_STEP]
    /// </summary>
    M = 2,

    /// <summary>
    /// No values are required from the user, k-means algorithm is used to estimate initial mixtures parameters. 
    /// [CvEM::START_AUTO_STEP]
    /// </summary>
    Auto = 0,
}
