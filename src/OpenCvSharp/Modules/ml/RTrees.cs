using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

/// <summary>
/// The class implements the random forest predictor.
/// </summary>
public class RTrees : DTrees
{
    #region Init and Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::ml::RTrees*
    /// </summary>
    private RTrees(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ml_Ptr_RTrees_delete(p)))
    { }
    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public new static RTrees Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_RTrees_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_RTrees_get(smartPtr, out var rawPtr));
        return new RTrees(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public new static RTrees Load(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        NativeMethods.HandleException(
            NativeMethods.ml_RTrees_load(filePath, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_RTrees_get(smartPtr, out var rawPtr));
        return new RTrees(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public new static RTrees LoadFromString(string strModel)
    {
        ArgumentNullException.ThrowIfNull(strModel);
        NativeMethods.HandleException(
            NativeMethods.ml_RTrees_loadFromString(strModel, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_RTrees_get(smartPtr, out var rawPtr));
        return new RTrees(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// If true then variable importance will be calculated and then 
    /// it can be retrieved by RTrees::getVarImportance. Default value is false.
    /// </summary>
    public bool CalculateVarImportance
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_getCalculateVarImportance(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setCalculateVarImportance(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// The size of the randomly selected subset of features at each tree node 
    /// and that are used to find the best split(s).
    /// </summary>
    public int ActiveVarCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_getActiveVarCount(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setActiveVarCount(Handle, value));
        }
    }

    /// <summary>
    /// The termination criteria that specifies when the training algorithm stops.
    /// </summary>
    public TermCriteria TermCriteria
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_getTermCriteria(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setTermCriteria(Handle, value));
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns the variable importance array.
    /// The method returns the variable importance vector, computed at the training
    /// stage when CalculateVarImportance is set to true. If this flag was set to false,
    /// the empty matrix is returned.
    /// </summary>
    /// <returns></returns>
    public Mat GetVarImportance()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_RTrees_getVarImportance(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the class probabilities for each sample, as voted by each of the trees.
    /// </summary>
    /// <param name="samples">Array containing the samples for which votes will be calculated.</param>
    /// <param name="results">Array where the result of the calculation will be written.</param>
    /// <param name="flags">Flags for defining the type of RTrees.</param>
    public void GetVotes(InputArray samples, OutputArray results, int flags)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ml_RTrees_getVotes(Handle, samples.Proxy, results.Proxy, flags));
        GC.KeepAlive(samples.Source);
        GC.KeepAlive(results.Source);
    }

    #endregion
}
