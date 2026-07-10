using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

// ReSharper disable InconsistentNaming
/// <summary>
/// Stochastic Gradient Descent SVM classifier
/// </summary>
public class SVMSGD : StatModel
{
    #region Init and Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::ml::SVMSGD*
    /// </summary>
    private SVMSGD(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ml_Ptr_SVMSGD_delete(p)))
    { }

    /// <summary>
    /// Creates empty model.
    /// Use StatModel::Train to train the model.
    /// Since %SVMSGD has several parameters, you may want to find the best
    /// parameters for your problem or use SetOptimalParameters to set some default parameters.
    /// </summary>
    /// <returns></returns>
    public static SVMSGD Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_SVMSGD_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_SVMSGD_get(smartPtr, out var rawPtr));
        return new SVMSGD(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads and creates a serialized SVMSGD from a file.
    /// Use SVMSGD::save to serialize and store an SVMSGD to disk.
    /// Load the SVMSGD from this file again, by calling this function with the path to the file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static SVMSGD Load(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        NativeMethods.HandleException(
            NativeMethods.ml_SVMSGD_load(filePath, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_SVMSGD_get(smartPtr, out var rawPtr));
        return new SVMSGD(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">The string variable containing the model you want to load.</param>
    /// <returns></returns>
    public static SVMSGD LoadFromString(string strModel)
    {
        ArgumentNullException.ThrowIfNull(strModel);
        NativeMethods.HandleException(
            NativeMethods.ml_SVMSGD_loadFromString(strModel, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_SVMSGD_get(smartPtr, out var rawPtr));
        return new SVMSGD(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Algorithm type, one of SVMSGD::SvmsgdType.
    /// </summary>
    public SvmsgdTypes SvmsgdType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_getSvmsgdType(Handle, out var ret));
            return (SvmsgdTypes)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_setSvmsgdType(Handle, (int)value));
        }
    }

    /// <summary>
    /// Margin type, one of SVMSGD::MarginType.
    /// </summary>
    public MarginTypes MarginType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_getMarginType(Handle, out var ret));
            return (MarginTypes)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_setMarginType(Handle, (int)value));
        }
    }

    /// <summary>
    /// Parameter marginRegularization of a %SVMSGD optimization problem.
    /// </summary>
    public float MarginRegularization
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_getMarginRegularization(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_setMarginRegularization(Handle, value));
        }
    }

    /// <summary>
    /// Parameter initialStepSize of a %SVMSGD optimization problem.
    /// </summary>
    public float InitialStepSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_getInitialStepSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_setInitialStepSize(Handle, value));
        }
    }

    /// <summary>
    /// Parameter stepDecreasingPower of a %SVMSGD optimization problem.
    /// </summary>
    public float StepDecreasingPower
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_getStepDecreasingPower(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_setStepDecreasingPower(Handle, value));
        }
    }

    /// <summary>
    /// Termination criteria of the training algorithm.
    /// You can specify the maximum number of iterations (maxCount) and/or how much the error could
    /// change between the iterations to make the algorithm continue (epsilon).
    /// </summary>
    public TermCriteria TermCriteria
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_getTermCriteria(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_SVMSGD_setTermCriteria(Handle, value));
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns the weights of the trained model (decision function f(x) = weights * x + shift).
    /// </summary>
    /// <returns></returns>
    public Mat GetWeights()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_SVMSGD_getWeights(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the shift of the trained model (decision function f(x) = weights * x + shift).
    /// </summary>
    /// <returns></returns>
    public float GetShift()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_SVMSGD_getShift(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Function sets optimal parameters values for chosen SVM SGD model.
    /// </summary>
    /// <param name="svmsgdType">is the type of SVMSGD classifier.</param>
    /// <param name="marginType">is the type of margin constraint.</param>
    public void SetOptimalParameters(
        SvmsgdTypes svmsgdType = SvmsgdTypes.Asgd, MarginTypes marginType = MarginTypes.SoftMargin)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_SVMSGD_setOptimalParameters(Handle, (int)svmsgdType, (int)marginType));
    }

    #endregion

    #region Types

#pragma warning disable CA1008

    /// <summary>
    /// SVMSGD type. ASGD is often the preferable choice.
    /// </summary>
    public enum SvmsgdTypes
    {
        /// <summary>
        /// Stochastic Gradient Descent
        /// </summary>
        Sgd,

        /// <summary>
        /// Average Stochastic Gradient Descent
        /// </summary>
        Asgd
    }

    /// <summary>
    /// Margin type
    /// </summary>
    public enum MarginTypes
    {
        /// <summary>
        /// General case, suits to the case of non-linearly separable sets, allows outliers.
        /// </summary>
        SoftMargin,

        /// <summary>
        /// More accurate for the case of linearly separable sets.
        /// </summary>
        HardMargin
    }

#pragma warning restore CA1008

    #endregion
}
