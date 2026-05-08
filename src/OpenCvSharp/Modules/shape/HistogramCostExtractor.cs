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
        InputArray descriptors1, InputArray descriptors2, OutputArray costMatrix)
    {
        ThrowIfDisposed();
        if (descriptors1 is null)
            throw new ArgumentNullException(nameof(descriptors1));
        if (descriptors2 is null)
            throw new ArgumentNullException(nameof(descriptors2));
        if (costMatrix is null)
            throw new ArgumentNullException(nameof(costMatrix));
        descriptors1.ThrowIfDisposed();
        descriptors2.ThrowIfDisposed();
        costMatrix.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.shape_HistogramCostExtractor_buildCostMatrix(
                RawPtr, descriptors1.CvPtr, descriptors2.CvPtr, costMatrix.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(descriptors1);
        GC.KeepAlive(descriptors2);
        costMatrix.Fix();
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
                NativeMethods.shape_HistogramCostExtractor_getNDummies(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_HistogramCostExtractor_setNDummies(RawPtr, value));
            GC.KeepAlive(this);
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
                NativeMethods.shape_HistogramCostExtractor_getDefaultCost(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.shape_HistogramCostExtractor_setDefaultCost(RawPtr, value));
            GC.KeepAlive(this);
        }
    }
}