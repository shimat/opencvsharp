using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Abstract base class for shape distance algorithms.
/// </summary>
public abstract class ShapeDistanceExtractor : Algorithm
{
    /// <inheritdoc />
    protected ShapeDistanceExtractor(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Compute the shape distance between two shapes defined by its contours.
    /// </summary>
    /// <param name="contour1">Contour defining first shape.</param>
    /// <param name="contour2">Contour defining second shape.</param>
    /// <returns></returns>
        /// <inheritdoc/>
    public virtual float ComputeDistance(InputArrayRef contour1, InputArrayRef contour2)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeDistanceExtractor_computeDistance(
                Handle, contour1.Proxy, contour2.Proxy, out var ret));

        GC.KeepAlive(contour1.Source);
        GC.KeepAlive(contour2.Source);

        return ret;
    }
}
