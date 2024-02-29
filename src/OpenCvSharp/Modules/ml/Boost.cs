using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

/// <summary>
/// Boosted tree classifier derived from DTrees
/// </summary>
public class Boost : DTrees
{
    private Ptr? ptrObj;

    #region Init and Disposal

    /// <summary>
    /// Creates instance by raw pointer cv::ml::Boost*
    /// </summary>
    protected Boost(IntPtr p)
    {
        ptrObj = new Ptr(p);
        ptr = ptrObj.Get();
    }

    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public new static Boost Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_Boost_create(out var ptr));
        return new Boost(ptr);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public new static Boost Load(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
        NativeMethods.HandleException(
            NativeMethods.ml_Boost_load(filePath, out var ptr));
        return new Boost(ptr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public new static Boost LoadFromString(string strModel)
    {
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
        NativeMethods.HandleException(
            NativeMethods.ml_Boost_loadFromString(strModel, out var ptr));
        return new Boost(ptr);
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
    /// Type of the boosting algorithm.
    /// See Boost::Types. Default value is Boost::REAL.
    /// </summary>
    public Types BoostType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_Boost_getBoostType(ptr, out var ret));
            GC.KeepAlive(this);
            return (Types)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_Boost_setBoostType(ptr, (int) value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The number of weak classifiers. 
    /// Default value is 100.
    /// </summary>
    public int WeakCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_Boost_getWeakCount(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_Boost_setWeakCount(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// A threshold between 0 and 1 used to save computational time. 
    /// Samples with summary weight \f$\leq 1 - weight_trim_rate
    /// do not participate in the *next* iteration of training. 
    /// Set this parameter to 0 to turn off this functionality. Default value is 0.95.
    /// </summary>
    public double WeightTrimRate
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_Boost_getWeightTrimRate(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ml_Boost_setWeightTrimRate(ptr, value));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Types

    /// <summary>
    /// Boosting type.
    /// Gentle AdaBoost and Real AdaBoost are often the preferable choices.
    /// </summary>
    public enum Types
    {
        /// <summary>
        /// Discrete AdaBoost.
        /// </summary>
        Discrete = 0,

        /// <summary>
        /// Real AdaBoost. It is a technique that utilizes confidence-rated predictions
        /// and works well with categorical data.
        /// </summary>
        Real = 1,

        /// <summary>
        /// LogitBoost. It can produce good regression fits.
        /// </summary>
        Logit = 2,

        /// <summary>
        /// Gentle AdaBoost. It puts less weight on outlier data points and for that
        /// reason is often good with regression data.
        /// </summary>
        Gentle = 3
    };

    #endregion

    internal new class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_Boost_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.ml_Ptr_Boost_delete(ptr));
            base.DisposeUnmanaged();
        }
    }
}
