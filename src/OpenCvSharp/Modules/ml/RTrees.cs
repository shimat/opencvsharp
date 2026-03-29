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
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
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
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
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
                NativeMethods.ml_RTrees_getCalculateVarImportance(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setCalculateVarImportance(RawPtr, value ? 1 : 0));
            GC.KeepAlive(this);
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
                NativeMethods.ml_RTrees_getActiveVarCount(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setActiveVarCount(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.ml_RTrees_getTermCriteria(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setTermCriteria(RawPtr, value));
            GC.KeepAlive(this);
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
            NativeMethods.ml_RTrees_getVarImportance(RawPtr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    #endregion
}
