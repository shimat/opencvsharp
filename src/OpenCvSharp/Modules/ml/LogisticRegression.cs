using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

/// <summary>
/// Implements Logistic Regression classifier.
/// </summary>
public class LogisticRegression : StatModel
{
    private Ptr? ptrObj;

    #region Init and Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::ml::LogisticRegression*
    /// </summary>
    protected LogisticRegression(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static LogisticRegression Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_LogisticRegression_create(out var ptr));
        return new LogisticRegression(ptr);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static LogisticRegression Load(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
        NativeMethods.HandleException(
            NativeMethods.ml_LogisticRegression_load(filePath, out var ptr));
        return new LogisticRegression(ptr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public static LogisticRegression LoadFromString(string strModel)
    {
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
        NativeMethods.HandleException(
            NativeMethods.ml_LogisticRegression_loadFromString(strModel, out var ptr));
        return new LogisticRegression(ptr);
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
    /// Learning rate
    /// </summary>
    public double LearningRate
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_getLearningRate(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_setLearningRate(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Number of iterations.
    /// </summary>
    public int Iterations
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_getIterations(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_setIterations(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Kind of regularization to be applied. See LogisticRegression::RegKinds.
    /// </summary>
    public RegKinds Regularization
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_getRegularization(ptr, out var ret));
            GC.KeepAlive(this);
            return (RegKinds)ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_setRegularization(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Kind of training method used. See LogisticRegression::Methods.
    /// </summary>
    public Methods TrainMethod
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_getTrainMethod(ptr, out var ret));
            GC.KeepAlive(this);
            return (Methods)ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_setTrainMethod(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Specifies the number of training samples taken in each step of Mini-Batch Gradient. 
    /// Descent. Will only be used if using LogisticRegression::MINI_BATCH training algorithm. 
    /// It has to take values less than the total number of training samples.
    /// </summary>
    public int MiniBatchSize
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_getMiniBatchSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_setMiniBatchSize(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Termination criteria of the training algorithm.
    /// </summary>
    public TermCriteria TermCriteria
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_getTermCriteria(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_LogisticRegression_setTermCriteria(ptr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Predicts responses for input samples and returns a float type.
    /// </summary>
    /// <param name="samples">The input data for the prediction algorithm. Matrix [m x n], 
    /// where each row contains variables (features) of one object being classified. 
    /// Should have data type CV_32F.</param>
    /// <param name="results">Predicted labels as a column matrix of type CV_32S.</param>
    /// <param name="flags">Not used.</param>
    /// <returns></returns>
    public float Predict(InputArray samples, OutputArray? results = null, int flags = 0)
    {
        ThrowIfDisposed();
        if (samples is null)
            throw new ArgumentNullException(nameof(samples));
        samples.ThrowIfDisposed();
        results?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_LogisticRegression_predict(ptr, samples.CvPtr, Cv2.ToPtr(results), flags, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(samples);
        GC.KeepAlive(results);
        results?.Fix();

        return ret;
    }

    /// <summary>
    /// This function returns the trained parameters arranged across rows.
    ///  For a two class classification problem, it returns a row matrix. 
    /// It returns learnt parameters of the Logistic Regression as a matrix of type CV_32F.
    /// </summary>
    /// <returns></returns>
    public Mat GetLearntThetas()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ml_LogisticRegression_get_learnt_thetas(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    #endregion

    #region Types

    /// <summary>
    /// Regularization kinds
    /// </summary>
    public enum RegKinds
    {
        /// <summary>
        /// Regularization disabled
        /// </summary>
        RegDisable = -1,

        /// <summary>
        /// L1 norm
        /// </summary>
        RegL1 = 0,

        /// <summary>
        /// L2 norm
        /// </summary>
        RegL2 = 1
    }

    /// <summary>
    /// Training methods
    /// </summary>
    public enum Methods
    {
        /// <summary>
        /// 
        /// </summary>
        Batch = 0,

        /// <summary>
        /// Set MiniBatchSize to a positive integer when using this method.
        /// </summary>
        MiniBatch = 1
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
                NativeMethods.ml_Ptr_LogisticRegression_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_LogisticRegression_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
