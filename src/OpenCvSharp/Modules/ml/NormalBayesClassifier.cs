using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

/// <summary>
/// Bayes classifier for normally distributed data
/// </summary>
public class NormalBayesClassifier : StatModel
{
    private Ptr? ptrObj;

    /// <summary>
    /// Creates instance by raw pointer cv::ml::NormalBayesClassifier*
    /// </summary>
    protected NormalBayesClassifier(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates empty model. 
    /// Use StatModel::train to train the model after creation.
    /// </summary>
    /// <returns></returns>
    public static NormalBayesClassifier Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_NormalBayesClassifier_create(out var ptr));
        return new NormalBayesClassifier(ptr);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static NormalBayesClassifier Load(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
        NativeMethods.HandleException(
            NativeMethods.ml_NormalBayesClassifier_load(filePath, out var ptr));
        return new NormalBayesClassifier(ptr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public static NormalBayesClassifier LoadFromString(string strModel)
    {
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
        NativeMethods.HandleException(
            NativeMethods.ml_NormalBayesClassifier_loadFromString(strModel, out var ptr));
        return new NormalBayesClassifier(ptr);
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

    /// <summary>
    /// Predicts the response for sample(s).
    /// </summary>
    /// <param name="inputs"></param>
    /// <param name="outputs"></param>
    /// <param name="outputProbs"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    /// <remarks>
    /// The method estimates the most probable classes for input vectors. Input vectors (one or more)
    /// are stored as rows of the matrix inputs. In case of multiple input vectors, there should be one 
    /// output vector outputs. The predicted class for a single input vector is returned by the method. 
    /// The vector outputProbs contains the output probabilities corresponding to each element of result.
    /// </remarks>
    public float PredictProb(InputArray inputs, OutputArray outputs,
        OutputArray outputProbs, int flags = 0)
    {
        ThrowIfDisposed();
        if (inputs is null)
            throw new ArgumentNullException(nameof(inputs));
        if (outputs is null)
            throw new ArgumentNullException(nameof(outputs));
        if (outputProbs is null)
            throw new ArgumentNullException(nameof(outputProbs));

        inputs.ThrowIfDisposed();
        outputs.ThrowIfNotReady();
        outputProbs.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_NormalBayesClassifier_predictProb(
                ptr, inputs.CvPtr, outputs.CvPtr, outputProbs.CvPtr, flags, out var ret));
        outputs.Fix();
        outputProbs.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(inputs);
        GC.KeepAlive(outputs);
        GC.KeepAlive(outputProbs);
        return ret;
    }

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_NormalBayesClassifier_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_NormalBayesClassifier_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
