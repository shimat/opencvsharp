using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Class for individual tree of the Global Patch Collider (GPC).
/// </summary>
public class GPCTree : Algorithm
{
    private GPCTree(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.optflow_Ptr_GPCTree_delete(p)))
    {
    }

    /// <summary>
    /// Creates an empty GPC tree.
    /// </summary>
    public static GPCTree Create()
    {
        NativeMethods.HandleException(NativeMethods.optflow_createGPCTree(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.optflow_Ptr_GPCTree_get(smartPtr, out var rawPtr));
        return new GPCTree(smartPtr, rawPtr);
    }

    /// <summary>
    /// Trains the tree using the given training samples.
    /// </summary>
    /// <param name="samples">Training samples, e.g. obtained via <see cref="GPCTrainingSamples.Create"/>.</param>
    /// <param name="trainingParams">Training parameters. Uses the native defaults when null.</param>
    public void Train(GPCTrainingSamples samples, GPCTrainingParams? trainingParams = null)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(samples);
        samples.ThrowIfDisposed();

        var nativeParams = (trainingParams ?? new GPCTrainingParams()).ToNative();
        NativeMethods.HandleException(
            NativeMethods.optflow_GPCTree_train(Handle, samples.Handle, in nativeParams));

        GC.KeepAlive(this);
        GC.KeepAlive(samples);
    }

    /// <summary>
    /// Descriptor type used by this tree, as set by the last call to <see cref="Train"/>.
    /// </summary>
    public GPCDescType GetDescriptorType()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.optflow_GPCTree_getDescriptorType(Handle, out var ret));
        GC.KeepAlive(this);
        return (GPCDescType)ret;
    }
}
