using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Sample Consensus algorithm segmentation of 3D point cloud model.
/// </summary>
/// <remarks>
/// See <see cref="SacMethod"/> for supported algorithms and <see cref="SacModelType"/> for supported models.
/// </remarks>
public class SACSegmentation : Algorithm
{
    /// <summary>
    /// Custom function that takes the model coefficients and returns whether the model is acceptable or not.
    /// </summary>
    /// <param name="modelCoefficients">
    /// The content of modelCoefficients depends on the model. Refer to the comments inside <see cref="SacModelType"/>.
    /// </param>
    public delegate bool ModelConstraintFunction(double[] modelCoefficients);

    // Roots the context (and thus the delegate) for the lifetime of this instance, or until replaced,
    // so the GC does not collect it while native code may still invoke the callback during Segment().
    // The native-facing function pointer passed alongside it is always the fixed trampoline below.
    private GCHandle constraintContextHandle;
    private ModelConstraintFunction? customModelConstraints;

    private SACSegmentation(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.geometry_Ptr_SACSegmentation_delete(p)))
    {
    }

    /// <summary>
    /// Creates a SACSegmentation object.
    /// </summary>
    /// <param name="sacModelType">The type of sample consensus model to use.</param>
    /// <param name="sacMethod">The type of sample consensus method to use.</param>
    /// <param name="threshold">The distance to the model threshold.</param>
    /// <param name="maxIterations">The maximum number of iterations to attempt.</param>
    /// <returns>SACSegmentation instance</returns>
    public static SACSegmentation Create(
        SacModelType sacModelType = SacModelType.SAC_MODEL_PLANE,
        SacMethod sacMethod = SacMethod.SAC_METHOD_RANSAC,
        double threshold = 0.5,
        int maxIterations = 1000)
    {
        NativeMethods.HandleException(
            NativeMethods.geometry_createSACSegmentation((int)sacModelType, (int)sacMethod, threshold, maxIterations, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.geometry_Ptr_SACSegmentation_get(smartPtr, out var rawPtr));
        return new SACSegmentation(smartPtr, rawPtr);
    }

    /// <summary>
    /// Executes segmentation using the sample consensus method.
    /// </summary>
    /// <param name="inputPts">Original point cloud, vector of Point3 or Mat of size Nx3/3xN.</param>
    /// <param name="labels">The label corresponds to the model number, 0 means it does not belong to
    /// any model, range [0, Number of final resultant models obtained].</param>
    /// <param name="modelsCoefficients">The resultant models coefficients. Placed in a matrix of NxK
    /// with depth CV_64F, where N is the number of models and K is the number of coefficients of one model.</param>
    /// <returns>Number of final resultant models obtained by segmentation.</returns>
    public virtual int Segment(InputArray inputPts, OutputArray labels, OutputArray modelsCoefficients)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.geometry_SACSegmentation_segment(Handle, inputPts.Proxy, labels.Proxy, modelsCoefficients.Proxy, out var ret));
        GC.KeepAlive(inputPts.Source);
        return ret;
    }

    /// <summary>
    /// The type of sample consensus model to use.
    /// </summary>
    public virtual SacModelType SacModelType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getSacModelType(Handle, out var ret));
            return (SacModelType)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setSacModelType(Handle, (int)value));
        }
    }

    /// <summary>
    /// The type of sample consensus method to use.
    /// </summary>
    public virtual SacMethod SacMethodType
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getSacMethodType(Handle, out var ret));
            return (SacMethod)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setSacMethodType(Handle, (int)value));
        }
    }

    /// <summary>
    /// The distance to the model threshold. Considered as inlier point if distance to the model
    /// is less than threshold.
    /// </summary>
    public virtual double DistanceThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getDistanceThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setDistanceThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Sets the minimum and maximum radius limits for the model.
    /// Only used for models whose model parameters include a radius.
    /// </summary>
    public virtual void SetRadiusLimits(double radiusMin, double radiusMax)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.geometry_SACSegmentation_setRadiusLimits(Handle, radiusMin, radiusMax));
    }

    /// <summary>
    /// Gets the minimum and maximum radius limits for the model.
    /// </summary>
    public virtual void GetRadiusLimits(out double radiusMin, out double radiusMax)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.geometry_SACSegmentation_getRadiusLimits(Handle, out radiusMin, out radiusMax));
    }

    /// <summary>
    /// The maximum number of iterations to attempt.
    /// </summary>
    public virtual int MaxIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getMaxIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setMaxIterations(Handle, value));
        }
    }

    /// <summary>
    /// The confidence that ensures at least one of the selections is an error-free set of data points.
    /// </summary>
    public virtual double Confidence
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getConfidence(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setConfidence(Handle, value));
        }
    }

    /// <summary>
    /// The number of models expected.
    /// </summary>
    public virtual int NumberOfModelsExpected
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getNumberOfModelsExpected(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setNumberOfModelsExpected(Handle, value));
        }
    }

    /// <summary>
    /// Whether to use parallelism or not. The number of threads is set by <see cref="Cv2.SetNumThreads"/>.
    /// </summary>
    public virtual bool IsParallel
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_isParallel(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setParallel(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// State used to initialize the RNG (Random Number Generator).
    /// </summary>
    public virtual ulong RandomGeneratorState
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_getRandomGeneratorState(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_SACSegmentation_setRandomGeneratorState(Handle, value));
        }
    }

    /// <summary>
    /// Sets a custom model coefficient constraint function.
    /// A custom function that takes model coefficients and returns whether the model is acceptable or not.
    /// Pass null to clear a previously set constraint function.
    /// </summary>
    public virtual void SetCustomModelConstraints(ModelConstraintFunction? customModelConstraints)
    {
        ThrowIfDisposed();

        this.customModelConstraints = customModelConstraints;

        var oldHandle = constraintContextHandle;
        var callbackPtr = IntPtr.Zero;
        var userData = IntPtr.Zero;
        if (customModelConstraints is not null)
        {
            constraintContextHandle = GCHandle.Alloc(customModelConstraints);
            callbackPtr = GetConstraintTrampolinePointer();
            userData = GCHandle.ToIntPtr(constraintContextHandle);
        }

        NativeMethods.HandleException(
            NativeMethods.geometry_SACSegmentation_setCustomModelConstraints(Handle, callbackPtr, userData));

        if (oldHandle.IsAllocated)
            oldHandle.Free();
    }

    /// <summary>
    /// Gets the custom model coefficient constraint function previously set via
    /// <see cref="SetCustomModelConstraints"/>, or null if none is set.
    /// </summary>
    public virtual ModelConstraintFunction? GetCustomModelConstraints()
    {
        ThrowIfDisposed();
        return customModelConstraints;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static int ModelConstraintTrampoline(IntPtr userData, IntPtr coefficients, int length)
    {
        try
        {
            var constraint = (ModelConstraintFunction)GCHandle.FromIntPtr(userData).Target!;
            var managedCoefficients = new double[length];
            Marshal.Copy(coefficients, managedCoefficients, 0, length);
            return constraint(managedCoefficients) ? 1 : 0;
        }
        catch
        {
            // Exceptions must never unwind into native code from an UnmanagedCallersOnly method;
            // fail safe by rejecting the model.
            return 0;
        }
    }

    private static unsafe IntPtr GetConstraintTrampolinePointer() =>
        (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, int>)&ModelConstraintTrampoline;

    /// <inheritdoc />
    protected override void DisposeManaged()
    {
        if (constraintContextHandle.IsAllocated)
            constraintContextHandle.Free();
        base.DisposeManaged();
    }
}
