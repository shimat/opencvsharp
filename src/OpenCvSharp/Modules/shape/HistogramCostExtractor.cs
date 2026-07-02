using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Abstract base class for histogram cost algorithms used in shape matching.
/// </summary>
public abstract class HistogramCostExtractor : Algorithm
{
    /// <inheritdoc />
    protected HistogramCostExtractor(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Builds a cost matrix from two sets of descriptors.
    /// </summary>
    /// <param name="descriptors1">First set of descriptors.</param>
    /// <param name="descriptors2">Second set of descriptors.</param>
    /// <param name="costMatrix">Output cost matrix.</param>
    public virtual void BuildCostMatrix(
        InputArrayRef descriptors1, InputArrayRef descriptors2, OutputArrayRef costMatrix)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.shape_HistogramCostExtractor_buildCostMatrix(
                Handle, descriptors1.Proxy, descriptors2.Proxy, costMatrix.Proxy));

        GC.KeepAlive(descriptors1.Source);
        GC.KeepAlive(descriptors2.Source);
    }

    /// <summary>
    /// The number of dummy histogram bins added to each histogram to handle size differences.
    /// </summary>
    public int NDummies
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_HistogramCostExtractor_getNDummies(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_HistogramCostExtractor_setNDummies(Handle, value));
        }
    }

    /// <summary>
    /// The default cost assigned to dummy bins.
    /// </summary>
    public float DefaultCost
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_HistogramCostExtractor_getDefaultCost(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_HistogramCostExtractor_setDefaultCost(Handle, value));
        }
    }
}