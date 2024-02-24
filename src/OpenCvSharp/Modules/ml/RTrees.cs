using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

/// <summary>
/// The class implements the random forest predictor.
/// </summary>
public class RTrees : DTrees
{
    private Ptr? ptrObj;

    #region Init and Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::ml::RTrees*
    /// </summary>
    protected RTrees(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public new static RTrees Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_RTrees_create(out var ptr));
        return new RTrees(ptr);
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
            NativeMethods.ml_RTrees_load(filePath, out var ptr));
        return new RTrees(ptr);
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
            NativeMethods.ml_RTrees_loadFromString(strModel, out var ptr));
        return new RTrees(ptr);
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
    /// If true then variable importance will be calculated and then 
    /// it can be retrieved by RTrees::getVarImportance. Default value is false.
    /// </summary>
    public bool CalculateVarImportance
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_getCalculateVarImportance(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setCalculateVarImportance(ptr, value ? 1 : 0));
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
                NativeMethods.ml_RTrees_getActiveVarCount(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setActiveVarCount(ptr, value));
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
                NativeMethods.ml_RTrees_getTermCriteria(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_RTrees_setTermCriteria(ptr, value));
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
            NativeMethods.ml_RTrees_getVarImportance(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    #endregion

    internal new class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_RTrees_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_RTrees_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
