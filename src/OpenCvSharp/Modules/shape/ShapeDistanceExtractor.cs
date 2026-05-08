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
    public virtual float ComputeDistance(InputArray contour1, InputArray contour2)
    {
        ThrowIfDisposed();
        if (contour1 is null)
            throw new ArgumentNullException(nameof(contour1));
        if (contour2 is null)
            throw new ArgumentNullException(nameof(contour2));
        contour1.ThrowIfDisposed();
        contour2.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeDistanceExtractor_computeDistance(
                RawPtr, contour1.CvPtr, contour2.CvPtr, out var ret));

        GC.KeepAlive(this);
        GC.KeepAlive(contour1);
        GC.KeepAlive(contour2);

        return ret;
    }
}
