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
    /// Creates instance from cv::Ptr&lt;T&gt; .
    /// ptr is disposed when the wrapper disposes.
    /// </summary>
    /// <param name="ptr"></param>
    internal static HistogramCostExtractor FromPtr(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Invalid HistogramCostExtractor pointer");

        NativeMethods.HandleException(NativeMethods.shape_Ptr_HistogramCostExtractor_get(ptr, out var rawPtr));
        return new GenericHistogramCostExtractor(ptr, rawPtr);
    }

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

    private sealed class GenericHistogramCostExtractor : HistogramCostExtractor
    {
        public GenericHistogramCostExtractor(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.shape_Ptr_HistogramCostExtractor_delete(p)))
        {
        }
    }
}