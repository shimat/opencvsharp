using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;
// ReSharper disable InconsistentNaming
#pragma warning disable 1591

/// <summary>
/// Class implementing two-dimensional phase unwrapping based on the quality-guided phase unwrapping
/// method. First, it computes a reliability map from second differences between a pixel and its eight
/// neighbours. Reliability values lie between 0 and 16*pi*pi. Then, this reliability map is used to
/// compute the reliabilities of "edges". An edge is an entity defined by two pixels that are connected
/// horizontally or vertically. Its reliability is found by adding the reliabilities of the two pixels
/// connected through it. Edges are sorted in a histogram based on their reliability values. This
/// histogram is then used to unwrap pixels, starting from the highest quality pixel.
/// The wrapped phase map and the unwrapped result are stored in CV_32FC1 Mat.
/// </summary>
public class HistogramPhaseUnwrapping : PhaseUnwrapping
{
    private HistogramPhaseUnwrapping(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(
            NativeMethods.phase_unwrapping_Ptr_HistogramPhaseUnwrapping_delete(p)))
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="parameters">HistogramPhaseUnwrapping parameters: width, height of the phase map and
    /// histogram characteristics. If not specified, the default parameters are used.</param>
    public static HistogramPhaseUnwrapping Create(Params? parameters = null)
    {
        var p = parameters ?? Params.Default;

        NativeMethods.HandleException(
            NativeMethods.phase_unwrapping_HistogramPhaseUnwrapping_create(ref p, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.phase_unwrapping_Ptr_HistogramPhaseUnwrapping_get(smartPtr, out var rawPtr));
        return new HistogramPhaseUnwrapping(smartPtr, rawPtr);
    }

    /// <summary>
    /// Get the reliability map computed from the wrapped phase map.
    /// </summary>
    /// <param name="reliabilityMap">Image where the reliability map is stored.</param>
    public virtual void GetInverseReliabilityMap(OutputArray reliabilityMap)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.phase_unwrapping_HistogramPhaseUnwrapping_getInverseReliabilityMap(Handle, reliabilityMap.Proxy));

        GC.KeepAlive(this);
        GC.KeepAlive(reliabilityMap.Source);
    }

    /// <summary>
    /// Parameters of HistogramPhaseUnwrapping constructor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Params
    {
        /// <summary>
        /// Phase map width.
        /// </summary>
        public int Width;

        /// <summary>
        /// Phase map height.
        /// </summary>
        public int Height;

        /// <summary>
        /// Bins in the histogram are not of equal size. Default value is 3*pi*pi. The ones before
        /// "HistThresh" value are smaller.
        /// </summary>
        public float HistThresh;

        /// <summary>
        /// Number of bins between 0 and "HistThresh". Default value is 10.
        /// </summary>
        public int NbrOfSmallBins;

        /// <summary>
        /// Number of bins between "HistThresh" and 32*pi*pi (highest edge reliability value).
        /// Default value is 5.
        /// </summary>
        public int NbrOfLargeBins;

        /// <summary>
        /// The default parameters used by the native HistogramPhaseUnwrapping::Params() constructor:
        /// width=800, height=600, histThresh=3*pi*pi, nbrOfSmallBins=10, nbrOfLargeBins=5.
        /// </summary>
        public static Params Default => new()
        {
            Width = 800,
            Height = 600,
            HistThresh = (float)(3 * Math.PI * Math.PI),
            NbrOfSmallBins = 10,
            NbrOfLargeBins = 5,
        };
    }
}
