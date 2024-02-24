using OpenCvSharp.Internal;

#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp.ML;

/// <summary>
/// K nearest neighbors classifier
/// </summary>
public class KNearest : StatModel
{
    private Ptr? ptrObj;

    #region Init and Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::ml::KNearest*
    /// </summary>
    protected KNearest(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates the empty model
    /// </summary>
    /// <returns></returns>
    public static KNearest Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_KNearest_create(out var ptr));
        return new KNearest(ptr);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static KNearest Load(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
        NativeMethods.HandleException(
            NativeMethods.ml_KNearest_load(filePath, out var ptr));
        return new KNearest(ptr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public static KNearest LoadFromString(string strModel)
    {
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
        NativeMethods.HandleException(
            NativeMethods.ml_KNearest_loadFromString(strModel, out var ptr));
        return new KNearest(ptr);
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
    /// Default number of neighbors to use in predict method.
    /// </summary>
    public int DefaultK
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_getDefaultK(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_setDefaultK(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Whether classification or regression model should be trained.
    /// </summary>
    public new bool IsClassifier
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_getIsClassifier(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_setIsClassifier(ptr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Parameter for KDTree implementation
    /// </summary>
    public int Emax
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_getEmax(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_setEmax(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Algorithm type, one of KNearest::Types.
    /// </summary>
    public Types AlgorithmType
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_getAlgorithmType(ptr, out var ret));
            GC.KeepAlive(this);
            return (Types)ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_KNearest_setAlgorithmType(ptr, (int)value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Finds the neighbors and predicts responses for input vectors.
    /// </summary>
    /// <param name="samples">Input samples stored by rows. 
    /// It is a single-precision floating-point matrix of `[number_of_samples] * k` size.</param>
    /// <param name="k">Number of used nearest neighbors. Should be greater than 1.</param>
    /// <param name="results">Vector with results of prediction (regression or classification) for each 
    /// input sample. It is a single-precision floating-point vector with `[number_of_samples]` elements.</param>
    /// <param name="neighborResponses">neighborResponses Optional output values for corresponding neighbors. 
    /// It is a single-precision floating-point matrix of `[number_of_samples] * k` size.</param>
    /// <param name="dist">Optional output distances from the input vectors to the corresponding neighbors. 
    /// It is a single-precision floating-point matrix of `[number_of_samples] * k` size.</param>
    /// <returns></returns>
    public float FindNearest(InputArray samples, int k, OutputArray results,
        OutputArray? neighborResponses = null, OutputArray? dist = null)
    {
        ThrowIfDisposed();
        if (samples is null)
            throw new ArgumentNullException(nameof(samples));
        if (results is null)
            throw new ArgumentNullException(nameof(results));
        samples.ThrowIfDisposed();
        results.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ml_KNearest_findNearest(
                ptr,
                samples.CvPtr, k, results.CvPtr,
                Cv2.ToPtr(neighborResponses), Cv2.ToPtr(dist), out var ret));

        GC.KeepAlive(this);
        GC.KeepAlive(samples);
        GC.KeepAlive(results);
        GC.KeepAlive(neighborResponses);
        GC.KeepAlive(dist);
        results.Fix();
        neighborResponses?.Fix();
        dist?.Fix();
        return ret;
    }

    #endregion

    #region Types

    /// <summary>
    /// Implementations of KNearest algorithm
    /// </summary>
    public enum Types
    {
#pragma warning disable 1591
        BruteForce = 1,
        KdTree = 2
#pragma warning restore 1591
    };

    #endregion

    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_KNearest_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_KNearest_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
